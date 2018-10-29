import { OnInit, Component, ViewChild } from '@angular/core';
import { CompanyService } from 'src/app/core/services/company.service';
import { Company } from 'src/app/shared/models/company.model';
import { SelectItem, ConfirmationService } from 'primeng/api';
import { Paginator } from 'primeng/primeng';
import { PaginationQuery } from 'src/app/shared/filterQueries/PaginationQuery';
import { SearchingQuery } from 'src/app/shared/filterQueries/SearchingQuery';
import { SortingQuery } from 'src/app/shared/filterQueries/SortingQuery';

@Component({
    selector: 'app-admin-companies',
    templateUrl: './admin-companies.component.html',
    styleUrls: ['./admin-companies.component.sass']
})
export class AdminCompaniesComponent implements OnInit {

    companies: Company[];

    sorting: SortingQuery;
    sortOptions: SelectItem[];

    totalRecords: number;
    rowsPerPage: number[];

    searching: SearchingQuery;

    searchedCompany: Company;
    searchOptions: SelectItem[];

    suggestField: string;
    placeholder: string;

    pagination: PaginationQuery;

    @ViewChild('p') paginator: Paginator;

    constructor(private confirmationService: ConfirmationService, private companyService: CompanyService, ) {
        this.companies = [];

        this.sorting = { sortField: '', sortOrder: false };

        this.totalRecords = 0;
        this.rowsPerPage = [2, 4, 6];

        this.placeholder = 'Enter email';

        this.searching = {
            searchString: '',
            searchField: this.suggestField = 'email'
        };

        this.pagination = {
            pageSize: 6,
            pageNumber: 1
        };
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
        this.suggestField = this.searching.searchField = event.value;
        this.placeholder = 'Enter ' + this.searching.searchField;
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

        this.loadCompanies();
    }


    paginate(event) {
        this.pagination = {
            pageNumber: event.page + 1,
            pageSize: event.rows
        };

        this.loadCompanies();
    }

    filterCompanies(event) {
        this.searching.searchString = event.query;
        this.loadCompanies();

        if (this.paginator.first !== 0) {
            this.paginator.changePage(0);
        }
    }

    select(event) {
        this.searching.searchString = this.getSearchStringFromSearchField(event);
        this.companies = [];
        this.companies[0] = event;
        this.totalRecords = 1;
    }

    clear() {
        this.searching.searchString = '';
        this.loadCompanies();
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
        this.companyService.getFullResponse(this.searching, this.sorting, this.pagination)
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
        switch (this.searching.searchField) {
            case 'email':
                return company.email;
            case 'name':
                return company.name;

            default: return null;
        }
    }
}
