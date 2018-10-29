import { OnInit, Component, EventEmitter, Output } from '@angular/core';
import { AuthService } from '../core/services/auth.service';
import { AuthHelper } from '../shared/helpers/auth-helper';
import { LoginRequest } from '../shared/models/login-request.model';
import { sha512_224 } from 'js-sha512';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'app-admin-authorization',
    templateUrl: './admin-authorization.component.html',
    styleUrls: ['./admin-authorization.component.sass']
})
export class AdminAuthorizationComponent implements OnInit {

    signInDialog = false;

    authoruzationsForm: FormGroup;
    errorMessage: string;

    @Output()
    chengeAuthenticatedStatus = new EventEmitter();

    constructor(private formBuilder: FormBuilder,
        private authService: AuthService,
        private authHelper: AuthHelper,
        private router: Router) {
    }

    ngOnInit() {
        this.authoruzationsForm = this.getAuthoruzationForm();
    }

    getAuthoruzationForm(): FormGroup {
        return this.formBuilder.group({
            login: ['', [Validators.required]],
            password: ['', [Validators.required]],
        });
    }

    submit() {
        const request: LoginRequest = {
            email: this.authoruzationsForm.get('login').value,
            password: sha512_224(this.authoruzationsForm.get('password').value).toString()
        };

        this.authService.employeeLogin(request)
            .subscribe(token => {
                this.authHelper.setToken(token);
                this.chengeAuthenticatedStatus.emit();
                this.errorMessage = '';
                this.signInDialog = false;
                this.router.navigate(['/admin/admin-companies']);

            },
                error => { this.errorMessage = error.error; }
            );
    }
}
