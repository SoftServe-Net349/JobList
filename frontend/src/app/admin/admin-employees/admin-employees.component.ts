import { OnInit, Component, ViewChild } from '@angular/core';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { SelectItem, ConfirmationService } from 'primeng/api';
import { Paginator } from 'primeng/primeng';
import { Employee } from 'src/app/shared/models/employee.model';

@Component({
    selector: 'app-admin-employees',
    templateUrl: './admin-employees.component.html',
    styleUrls: ['./admin-employees.component.sass']
})
export class AdminEmployeesComponent implements OnInit {

    employees: Employee[];

    sortKey: string;
    sortOrder: boolean;
    sortField: string;
    sortOptions: SelectItem[];

    pageSize: number;
    pageNumber: number;
    totalRecords: number;
    rowsPerPage: number[];

    searchString: string;
    searchedEmployee: Employee;
    searchOptions: SelectItem[];
    searchField: string;

    suggestField: string;
    placeholder: string;

    @ViewChild('p') paginator: Paginator;

    constructor(private confirmationService: ConfirmationService, private userService: EmployeeService) {
        this.employees = [];

        this.sortKey = '';
        this.sortOrder = false;
        this.sortField = '';

        this.pageSize = 4;
        this.pageNumber = 1;
        this.totalRecords = 0;
        this.rowsPerPage = [2, 4, 6];

        this.searchString = '';

        this.suggestField = this.searchField = 'email';
        this.placeholder = 'Enter email';
    }

    ngOnInit() {
        this.loadEmployees();

        this.sortOptions = [
            { label: 'Newest First', value: '!birthDate' },
            { label: 'Oldest First', value: 'birthDate' },
            { label: 'Email', value: 'email' }
        ];

        this.searchOptions = [
            { label: 'Email', value: 'email' },
            { label: 'First Name', value: 'firstName' },
            { label: 'Last Name', value: 'lastName' }
        ];
    }

    onSearchFieldChange(event) {
        this.suggestField = this.searchField = event.value;
        this.placeholder = this.getPlaceholder();
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

        this.loadEmployees();
    }

    paginate(event) {
        this.pageNumber = event.page + 1;
        this.pageSize = event.rows;

        this.loadEmployees();
    }

    filterEmployees(event) {
        this.searchString = event.query;
        this.loadEmployees();

        this.paginator.changePage(0);
    }

    select(event) {
        this.searchString = this.getSearchStringFromSearchField(event);
        this.employees = [];
        this.employees[0] = event;
        this.totalRecords = 1;
    }

    clear() {
        this.searchString = '';
        this.loadEmployees();
    }

    deleteConfirm(id: number) {
        this.confirmationService.confirm({
            message: 'Do you want to delete this record?',
            header: 'Delete Confirmation',
            icon: 'pi pi-info-circle',
            accept: () => {
                this.userService.delete(id).subscribe(data => this.loadEmployees());
            }
        });
    }

    loadEmployees() {
        this.userService.getFullResponse(this.searchString, this.searchField,
            this.sortField, this.sortOrder, this.pageSize, this.pageNumber)
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

    getPlaceholder(): string {
        switch (this.searchField) {
            case 'email':
                return 'Enter email';
            case 'firstName':
                return 'Enter first name';
            case 'lastName':
                return 'Enter last name';

            default: return null;
        }
    }

    getSearchStringFromSearchField(employee: Employee): string {
        switch (this.searchField) {
            case 'email':
                return employee.email;
            case 'firstName':
                return employee.firstName;
            case 'lastName':
                return employee.lastName;

            default: return null;
        }
    }
}
