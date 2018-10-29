import { OnInit, Component, ViewChild } from '@angular/core';
import { VacancyService } from 'src/app/core/services/vacancy.service';
import { Vacancy } from 'src/app/shared/models/vacancy.model';
import { ConfirmationService, SelectItem } from 'primeng/api';
import { VacancyRequest } from 'src/app/shared/models/vacancy-request.model';
import { Paginator } from 'primeng/primeng';
import { SortingQuery } from 'src/app/shared/filterQueries/SortingQuery';
import { SearchingQuery } from 'src/app/shared/filterQueries/SearchingQuery';
import { PaginationQuery } from 'src/app/shared/filterQueries/PaginationQuery';

@Component({
    selector: 'app-admin-vacancies',
    templateUrl: './admin-vacancies.component.html',
    styleUrls: ['./admin-vacancies.component.sass']
})
export class AdminVacanciesComponent implements OnInit {

    vacancies: Vacancy[];

    sorting: SortingQuery;
    sortOptions: SelectItem[];

    totalRecords: number;
    rowsPerPage: number[];

    searching: SearchingQuery;

    searchedVacancy: Vacancy;
    searchOptions: SelectItem[];

    suggestField: string;
    placeholder: string;

    pagination: PaginationQuery;

    @ViewChild('p') paginator: Paginator;


    constructor(private vacancyService: VacancyService, private confirmationService: ConfirmationService) {
        this.vacancies = [];

        this.sorting = { sortField: '', sortOrder: false };

        this.totalRecords = 0;
        this.rowsPerPage = [5, 10, 15];

        this.placeholder = 'Enter name';

        this.searching = {
            searchString: '',
            searchField: this.suggestField = 'name'
        };

        this.pagination = {
            pageSize: 10,
            pageNumber: 1
        };
    }

    ngOnInit() {
        this.loadVacancies();

        this.sortOptions = [
            { label: 'Newest First', value: '!createDate' },
            { label: 'Oldest First', value: 'createDate' },
            { label: 'Name', value: 'name' }
        ];

        this.searchOptions = [
            { label: 'Name', value: 'name' }
        ];
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

        this.loadVacancies();
    }

    paginate(event) {
        this.pagination = {
            pageNumber: event.page + 1,
            pageSize: event.rows
        };

        this.loadVacancies();
    }

    filterVacancies(event) {
        this.searching.searchString = event.query;
        this.loadVacancies();

        if (this.paginator.first !== 0) {
            this.paginator.changePage(0);
        }
    }

    select(event) {
        this.searching.searchString = event.name;
        this.vacancies = [];
        this.vacancies[0] = event;
        this.totalRecords = 1;
    }

    clear() {
        this.searching.searchString = '';
        this.loadVacancies();
    }

    checkConfirm(vacancy: Vacancy, isChecked: boolean) {
        const request: VacancyRequest = this.getRequest(vacancy, isChecked);

        if (!isChecked) {
            this.confirmationService.confirm({
                message: 'Do you want to check this record?',
                header: 'Check Confirmation',
                icon: 'pi pi-info-circle',
                accept: () => {
                    this.vacancyService.update(vacancy.id, request).subscribe();
                    vacancy.isChecked = true;
                }
            });
        } else {
            this.confirmationService.confirm({
                message: 'Do you want to uncheck this record?',
                header: 'Uncheck Confirmation',
                icon: 'pi pi-info-circle',
                accept: () => {
                    this.vacancyService.update(vacancy.id, request).subscribe();
                    vacancy.isChecked = false;
                }
            });
        }
    }


    getRequest(vacancy: Vacancy, isChecked: boolean): VacancyRequest {
        return {
            name: vacancy.name,
            description: vacancy.description,
            offering: vacancy.offering,
            requirements: vacancy.requirements,
            bePlus: vacancy.bePlus,
            isChecked: !isChecked,
            salary: vacancy.salary,
            fullPartTime: vacancy.fullPartTime,
            createDate: vacancy.createDate,
            cityId: vacancy.city.id,
            recruiterId: vacancy.recruiter.id,
            workAreaId: vacancy.workArea.id
        };
    }

    loadVacancies() {
        this.vacancyService.getAdminResponse(this.searching, this.sorting, this.pagination)
            .subscribe((response) => {
                if (response.body !== null) {
                    this.vacancies = response.body;
                    this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
                } else {
                    this.vacancies = null;
                    this.totalRecords = 0;
                }
            });
    }
}
