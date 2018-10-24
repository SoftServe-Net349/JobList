import { OnInit, Component, ViewChild } from '@angular/core';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { SelectItem, ConfirmationService } from 'primeng/api';
import { Paginator } from 'primeng/primeng';
import { Employee } from 'src/app/shared/models/employee.model';
import { SortingQuery } from 'src/app/shared/filterQueries/SortingQuery';
import { PaginationQuery } from 'src/app/shared/filterQueries/PaginationQuery';
import { SearchingQuery } from 'src/app/shared/filterQueries/SearchingQuery';

@Component({
    selector: 'app-admin-employees',
    templateUrl: './admin-employees.component.html',
    styleUrls: ['./admin-employees.component.sass']
})
export class AdminEmployeesComponent implements OnInit {

    employees: Employee[];

    sorting: SortingQuery;
    sortOptions: SelectItem[];

    pageSize: number;
    pageNumber: number;
    totalRecords: number;
    rowsPerPage: number[];

    searching: SearchingQuery;

    searchedEmployee: Employee;
    searchOptions: SelectItem[];

    suggestField: string;
    placeholder: string;

    pagination: PaginationQuery;

    @ViewChild('p') paginator: Paginator;

    constructor(private confirmationService: ConfirmationService, private userService: EmployeeService) {
        this.employees = [];

        this.sorting = { sortField: '', sortOrder: false };

        this.totalRecords = 0;
        this.rowsPerPage = [2, 4, 6];

        this.placeholder = 'Enter email';

        this.searching = {
            searchString: '',
            searchField: this.suggestField = 'email'
        };

        this.pagination = {
            pageSize: 4,
            pageNumber: 1
        };
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
        this.suggestField = this.searching.searchField = event.value;
        this.placeholder = this.getPlaceholder();
    }

    onSortChange(event) {
        const value = event.value;

        if (value.indexOf('!') === 0) {
            this.sorting = {
                sortField: value.substring(1, value.length),
                sortOrder: false
            };
        } else {
            this.sorting = {
                sortField: value,
                sortOrder: true
            };
        }

        this.loadEmployees();
    }

    paginate(event) {
        this.pagination = {
            pageNumber: event.page + 1,
            pageSize: event.rows
        };

        this.loadEmployees();
    }

    filterEmployees(event) {
        this.searching.searchString = event.query;
        this.loadEmployees();

        if (this.paginator.first !== 0) {
            this.paginator.changePage(0);
        }
    }

    select(event) {
        this.searching.searchString = this.getSearchStringFromSearchField(event);
        this.employees = [];
        this.employees[0] = event;
        this.totalRecords = 1;
    }

    clear() {
        this.searching.searchString = '';
        this.loadEmployees();
    }

    deleteConfirm(id: number) {
        this.confirmationService.confirm({
            message: 'After removing an employee, all his resumes will be deleted. Do you want to delete this employee?',
            header: 'Delete Confirmation',
            icon: 'pi pi-info-circle',
            accept: () => {
                this.userService.delete(id).subscribe(data => this.loadEmployees());
            }
        });
    }

    loadEmployees() {
        this.userService.getFullResponse(this.searching, this.sorting, this.pagination)
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
        switch (this.searching.searchField) {
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
        switch (this.searching.searchField) {
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
