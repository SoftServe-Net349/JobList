import { OnInit, Component, ViewChild } from '@angular/core';
import { SelectItem, ConfirmationService } from 'primeng/api';
import { Paginator } from 'primeng/primeng';
import { Recruiter } from 'src/app/shared/models/recruiter.model';
import { RecruiterService } from 'src/app/core/services/recruiter.service';

@Component({
    selector: 'app-admin-recruiters',
    templateUrl: './admin-recruiters.component.html',
    styleUrls: ['./admin-recruiters.component.sass']
})
export class AdminRecruitersComponent implements OnInit {

    recruiters: Recruiter[];

    sortKey: string;
    sortOrder: boolean;
    sortField: string;
    sortOptions: SelectItem[];

    pageSize: number;
    pageNumber: number;
    totalRecords: number;
    rowsPerPage: number[];

    searchString: string;
    searchedRecruiter: Recruiter;
    searchOptions: SelectItem[];
    searchField: string;

    suggestField: string;
    placeholder: string;

    @ViewChild('p') paginator: Paginator;

    constructor(private confirmationService: ConfirmationService, private recruiterService: RecruiterService, ) {
        this.recruiters = [];

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

    onSortChange(event) {
        const value = event.value;

        if (value.indexOf('!') === 0) {
            this.sortOrder = false;
            this.sortField = value.substring(1, value.length);
        } else {
            this.sortOrder = true;
            this.sortField = value;
        }

        this.loadRecruiters();
    }

    onSearchFieldChange(event) {
        this.suggestField = this.searchField = event.value;
        this.placeholder = this.getPlaceholder();
    }

    paginate(event) {
        this.pageNumber = event.page + 1;
        this.pageSize = event.rows;

        this.loadRecruiters();
    }

    filterRecruiter(event) {
        this.searchString = event.query;
        this.loadRecruiters();

        this.paginator.changePage(0);
    }

    select(event) {
        this.searchString = this.getSearchStringFromSearchField(event);
        this.recruiters = [];
        this.recruiters[0] = event;
        this.totalRecords = 1;
    }

    clear() {
        this.searchString = '';
        this.loadRecruiters();
    }


    loadRecruiters() {
        this.recruiterService.getFullResponse(this.searchString, this.searchField, 
            this.sortField, this.sortOrder, this.pageSize, this.pageNumber)
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

    deleteConfirm(id: number) {
        this.confirmationService.confirm({
            message: 'Do you want to delete this record?',
            header: 'Delete Confirmation',
            icon: 'pi pi-info-circle',
            accept: () => {
                this.recruiterService.delete(id).subscribe(data => this.loadRecruiters());
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

    getSearchStringFromSearchField(recruiter: Recruiter): string {
        switch (this.searchField) {
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
