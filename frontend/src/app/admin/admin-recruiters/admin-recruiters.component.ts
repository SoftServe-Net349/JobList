import { OnInit, Component, ViewChild } from '@angular/core';
import { SelectItem, ConfirmationService } from 'primeng/api';
import { Paginator } from 'primeng/primeng';
import { Recruiter } from 'src/app/shared/models/recruiter.model';
import { RecruiterService } from 'src/app/core/services/recruiter.service';
import { SortingQuery } from 'src/app/shared/filterQueries/SortingQuery';
import { SearchingQuery } from 'src/app/shared/filterQueries/SearchingQuery';
import { PaginationQuery } from 'src/app/shared/filterQueries/PaginationQuery';

@Component({
    selector: 'app-admin-recruiters',
    templateUrl: './admin-recruiters.component.html',
    styleUrls: ['./admin-recruiters.component.sass']
})
export class AdminRecruitersComponent implements OnInit {

    recruiters: Recruiter[];

    sorting: SortingQuery;
    sortOptions: SelectItem[];

    totalRecords: number;
    rowsPerPage: number[];

    searching: SearchingQuery;

    searchedRecruiter: Recruiter;
    searchOptions: SelectItem[];

    suggestField: string;
    placeholder: string;

    pagination: PaginationQuery;

    @ViewChild('p') paginator: Paginator;

    constructor(private confirmationService: ConfirmationService, private recruiterService: RecruiterService, ) {
        this.recruiters = [];

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
        this.loadRecruiters();

        this.sortOptions = [
            { label: 'Email by descending', value: '!email' },
            { label: 'Email by ascending', value: 'email' }
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

        this.loadRecruiters();
    }

    paginate(event) {
        this.pagination = {
            pageNumber: event.page + 1,
            pageSize: event.rows
        };

        this.loadRecruiters();
    }

    filterRecruiter(event) {
        this.searching.searchString = event.query;
        this.loadRecruiters();

        if (this.paginator.first !== 0) {
            this.paginator.changePage(0);
        }
    }

    select(event) {
        this.searching.searchString = this.getSearchStringFromSearchField(event);
        this.recruiters = [];
        this.recruiters[0] = event;
        this.totalRecords = 1;
    }

    clear() {
        this.searching.searchString = '';
        this.loadRecruiters();
    }

    deleteConfirm(id: number) {
        this.confirmationService.confirm({
            message: 'After removing a recruiter, all his vacancies will be deleted. Do you want to delete this recruiter?',
            header: 'Delete Confirmation',
            icon: 'pi pi-info-circle',
            accept: () => {
                this.recruiterService.delete(id).subscribe(data => this.loadRecruiters());
            }
        });
    }

    loadRecruiters() {
        this.recruiterService.getFullResponse(this.searching, this.sorting, this.pagination)
            .subscribe((response) => {
                if (response.body !== null) {
                    this.recruiters = response.body;
                    this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
                } else {
                    this.recruiters = null;
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

    getSearchStringFromSearchField(recruiter: Recruiter): string {
        switch (this.searching.searchField) {
            case 'email':
                return recruiter.email;
            case 'firstName':
                return recruiter.firstName;
            case 'lastName':
                return recruiter.lastName;

            default: return null;
        }
    }
}
