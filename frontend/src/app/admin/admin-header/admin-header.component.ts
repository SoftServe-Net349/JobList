import { OnInit, Component } from '@angular/core';
import { AuthHelper } from 'src/app/shared/helpers/auth-helper';
import { Router } from '@angular/router';

@Component({
    selector: 'app-admin-header',
    templateUrl: './admin-header.component.html',
    styleUrls: ['./admin-header.component.sass']
})
export class AdminHeaderComponent implements OnInit {
    constructor(private authHelper: AuthHelper,
        private router: Router) {

    }

    ngOnInit() {
    }


    signOut() {
        this.authHelper.logout();
        this.router.navigate(['/']);
    }
}
