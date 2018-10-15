import { OnInit, Component, ViewChild } from "@angular/core";
import { User } from "src/app/shared/models/user.model";
import { UserService } from "src/app/core/services/user.service";
import { SelectItem, ConfirmationService } from "primeng/api";
import { isNullOrUndefined } from "util";
import { Paginator } from "primeng/primeng";

@Component({
    selector: 'app-admin-users',
    templateUrl: './admin-users.component.html',
    styleUrls: ['./admin-users.component.sass']
})
export class AdminUsersComponent implements OnInit {

    users: User[];

    displayDialog: boolean = false;

    sortKey: string = '';
    sortOrder: boolean = false;
    sortField: string = '';

    sortOptions: SelectItem[];

    pageSize: number = 4;
    pageNumber: number = 1;
    totalRecords: number = 0;

    searchString: string = '';
    searchedUser: User = null;

    @ViewChild('p') paginator: Paginator;

    constructor(private confirmationService: ConfirmationService, private userService: UserService) {
        this.users = [];
    }

    ngOnInit() {
        this.loadUsers();

        this.sortOptions = [
            { label: 'Newest First', value: '!Birthdate' },
            { label: 'Oldest First', value: 'Birthdate' },
            { label: 'Email', value: 'Email' }
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

    filterUsers(event) {
        this.searchString = event.query;
        this.pageNumber = 1;
        this.loadUsers();
        
        this.paginator.changePage(0);
    }

    select(event) {
        this.searchString = event.email;
        this.pageNumber = 1;
        this.loadUsers();

        this.paginator.changePage(0);
    }

    search() {
        if (isNullOrUndefined(this.searchedUser)) {
            this.searchString = '';
        }
        else if (isNullOrUndefined(this.searchedUser.email)) {
            this.searchString = this.searchedUser.toString();
        }

        this.pageNumber = 1;
        this.loadUsers();

        this.paginator.changePage(0);
    }


    loadUsers() {
        this.userService.getFullResponse(this.searchString, this.sortField, this.sortOrder, this.pageSize, this.pageNumber)
            .subscribe((response) => {
                if (response.body !== null) {
                    this.users = response.body;
                    this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
                }
                else {
                    this.users = null;
                    this.totalRecords = 0;
                }
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