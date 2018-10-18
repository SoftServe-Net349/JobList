import { OnInit, Component, ViewChild } from '@angular/core';
import { Employee } from '../../shared/models/employee.model';
import { EmployeeService } from '../../core/services/employee.service';
import { SelectItem, ConfirmationService } from 'primeng/api';
import { isNullOrUndefined } from 'util';
import { Paginator } from 'primeng/primeng';

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
    searchedEmployee: Employee = null;

    @ViewChild('p') paginator: Paginator;

    constructor(private confirmationService: ConfirmationService, private employeeService: EmployeeService) {
        this.employees = [];
    }

    ngOnInit() {
        this.loadEmployees();

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

        this.loadEmployees();
    }


    paginate(event) {
        this.pageNumber = event.page + 1;
        this.pageSize = event.rows;

        this.loadEmployees();
    }

    filterEmployees(event) {
        this.searchString = event.query;
        this.pageNumber = 1;
        this.loadEmployees();

        this.paginator.changePage(0);
    }

    select(event) {
        this.searchString = event.email;
        this.pageNumber = 1;
        this.loadEmployees();

        this.paginator.changePage(0);
    }

    search() {
        if (isNullOrUndefined(this.searchedEmployee)) {
            this.searchString = '';
        } else if (isNullOrUndefined(this.searchedEmployee.email)) {
            this.searchString = this.searchedEmployee.toString();
        }

        this.pageNumber = 1;
        this.loadEmployees();

        this.paginator.changePage(0);
    }


    loadEmployees() {
        this.employeeService.getFullResponse(this.searchString, this.sortField, this.sortOrder, this.pageSize, this.pageNumber)
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
                this.employeeService.delete(id).subscribe(data => this.loadEmployees());
            }
        });
    }
}
