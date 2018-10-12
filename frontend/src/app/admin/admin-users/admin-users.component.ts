import { OnInit, Component } from "@angular/core";
import { User } from "src/app/shared/models/user.model";
import { UserService } from "src/app/core/services/user.service";
import { SelectItem, ConfirmationService } from "primeng/api";

@Component({
    selector: 'app-admin-users',
    templateUrl: './admin-users.component.html',
    styleUrls: ['./admin-users.component.sass']
})
export class AdminUsersComponent implements OnInit {

    users: User[];
    selectedUser: User;

    displayDialog: boolean = false;

    sortKey: string = '';
    sortOrder: boolean = false;
    sortField: string = '';

    sortOptions: SelectItem[];

    pageSize: number = 4;
    pageNumber: number = 1;
    totalRecords: number = 0;

    searchString: string = '';


    constructor(private confirmationService: ConfirmationService, private userService: UserService) {
        this.users = [];
    }

    ngOnInit() {
        this.loadUsers();

        this.sortOptions = [
            { label: 'Newest First', value: '!birthdate' },
            { label: 'Oldest First', value: 'birthdate' },
            { label: 'Email', value: 'email' }
        ];
    }


    onSortChange(event) {
        let value = event.value;

        if (value.indexOf('!') === 0) {
            this.sortOrder = false;
            this.sortField = value.substring(1, value.length);
        }
        else {
            this.sortOrder = true;
            this.sortField = value;
        }

        this.loadUsers();
    }


    paginate(event) {
        this.pageNumber = event.page + 1;
        this.pageSize = event.rows;

        this.loadUsers();
    }

    search() {
        this.pageNumber = 1;
        this.loadUsers();
    }

    loadUsers() {
        this.userService.getFullResponse(this.searchString, this.sortField, this.sortOrder, this.pageSize, this.pageNumber)
            .subscribe((response) => {
                this.users = response.body;
                this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
            });
    }

    deleteConfirm(id: number) {
        this.confirmationService.confirm({
            message: 'Do you want to delete this record?',
            header: 'Delete Confirmation',
            icon: 'pi pi-info-circle',
            accept: () => {
                this.userService.delete(id).subscribe(data => this.loadUsers());
            }
        });
    }
}