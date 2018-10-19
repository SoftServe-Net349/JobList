import { OnInit, Component, ViewChild } from '@angular/core';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { SelectItem, ConfirmationService } from 'primeng/api';
import { isNullOrUndefined } from 'util';
import { Paginator } from 'primeng/primeng';
import { Employee } from 'src/app/shared/models/employee.model';

@Component({
    selector: 'app-admin-employees',
    templateUrl: './admin-employees.component.html',
    styleUrls: ['./admin-employees.component.sass']
})
export class AdminEmployeesComponent implements OnInit {

    employees: Employee[];

    displayDialog = false;

    sortKey = '';
    sortOrder = false;
    sortField = '';

    sortOptions: SelectItem[];

    pageSize = 4;
    pageNumber = 1;
    totalRecords = 0;

    searchString = '';
    searchedUser = null;

    @ViewChild('p') paginator: Paginator;

    constructor(private confirmationService: ConfirmationService, private userService: EmployeeService) {
        this.employees = [];
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
        const value = event.value;

        if (value.indexOf('!') === 0) {
            this.sortOrder = false;
            this.sortField = value.substring(1, value.length);
        } else {
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

    filterEmployees(event) {
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
        } else if (isNullOrUndefined(this.searchedUser.email)) {
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
                    this.employees = response.body;
                    this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
                } else {
                    this.employees = null;
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
