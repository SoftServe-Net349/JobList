import { OnInit, Component, ViewChild } from '@angular/core';
import { CompanyService } from 'src/app/core/services/company.service';
import { Company } from 'src/app/shared/models/company.model';
import { SelectItem, ConfirmationService } from 'primeng/api';
import { Paginator } from 'primeng/primeng';
import { isNullOrUndefined } from 'util';

@Component({
    selector: 'app-admin-companies',
    templateUrl: './admin-companies.component.html',
    styleUrls: ['./admin-companies.component.sass']
})
export class AdminCompaniesComponent implements OnInit {

    companies: Company[];

    sortKey: string;
    sortOrder: boolean;
    sortField: string;
    sortOptions: SelectItem[];

    pageSize: number;
    pageNumber: number;
    totalRecords: number;
    rowsPerPage: number[];

    searchString: string;
    searchedCompany: Company;
    searchOptions: SelectItem[];
    searchField: string;

    suggestField: string;
    placeholder: string;

    @ViewChild('p') paginator: Paginator;

    constructor(private confirmationService: ConfirmationService, private companyService: CompanyService, ) {
        this.companies = [];

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
        this.sortOptions = [
            { label: 'Name by ascending', value: 'name' },
            { label: 'Name by decending', value: '!name' }
        ];

        this.searchOptions = [
            { label: 'Email', value: 'email' },
            { label: 'Name', value: 'name' }
        ];

        this.loadCompanies();
    }

    onSearchFieldChange(event) {
        this.suggestField = this.searchField = event.value;
        this.placeholder = 'Enter ' + this.searchField;
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

        this.loadCompanies();
    }


    paginate(event) {
        this.pageNumber = event.page + 1;
        this.pageSize = event.rows;

        this.loadCompanies();
    }

    filterCompanies(event) {
        this.searchString = event.query;
        this.loadCompanies();

        this.paginator.changePage(0);
    }

    select(event) {
        this.searchString = this.getSearchStringFromSearchField(event);
        this.companies = [];
        this.companies[0] = event;
        this.totalRecords = 1;
    }

    clear() {
        this.searchString = '';
        this.loadCompanies();
    }

    search() {
        if (isNullOrUndefined(this.searchedCompany)) {
            this.searchString = '';
        } else if (isNullOrUndefined(this.searchedCompany.name)) {
            this.searchString = this.searchedCompany.toString();
        }

        this.pageNumber = 1;
        this.loadCompanies();

        this.paginator.changePage(0);
    }

    deleteConfirm(id: number) {
        this.confirmationService.confirm({
            message: 'After removing a company, all its recruiters and vacancies are deleted. Do you want to delete this company?',
            header: 'Delete Confirmation',
            icon: 'pi pi-info-circle',
            accept: () => {
                this.companyService.delete(id).subscribe(data => this.loadCompanies());
            }
        });
    }

    loadCompanies() {
        this.companyService.getFullResponse(this.searchString, this.searchField,
            this.sortField, this.sortOrder, this.pageSize, this.pageNumber)
            .subscribe((response) => {
                if (response.body !== null) {
                    this.companies = response.body;
                    this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
                } else {
                    this.companies = null;
                    this.totalRecords = 0;
                }
            });
    }

    getSearchStringFromSearchField(company: Company): string {
        switch (this.searchField) {
            case 'email':
                return company.email;
            case 'name':
                return company.name;

            default: return null;
        }
    }
}
