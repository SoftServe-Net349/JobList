import { OnInit, Component, ViewChild } from '@angular/core';
import { VacancyService } from 'src/app/core/services/vacancy.service';
import { Vacancy } from 'src/app/shared/models/vacancy.model';
import { ConfirmationService, SelectItem } from 'primeng/api';
import { VacancyRequest } from 'src/app/shared/models/vacancy-request.model';
import { Paginator } from 'primeng/primeng';

@Component({
    selector: 'app-admin-vacancies',
    templateUrl: './admin-vacancies.component.html',
    styleUrls: ['./admin-vacancies.component.sass']
})
export class AdminVacanciesComponent implements OnInit {

    vacancies: Vacancy[];

    sortKey: string;
    sortOrder: boolean;
    sortField: string;
    sortOptions: SelectItem[];

    pageSize: number;
    pageNumber: number;
    totalRecords: number;
    rowsPerPage: number[];

    searchString: string;
    searchedVacancy: Vacancy;
    searchOptions: SelectItem[];
    searchField: string;

    suggestField: string;
    placeholder: string;

    @ViewChild('p') paginator: Paginator;


    constructor(private vacancyService: VacancyService, private confirmationService: ConfirmationService) {
        this.vacancies = [];

        this.sortKey = '';
        this.sortOrder = false;
        this.sortField = '';

        this.pageSize = 10;
        this.pageNumber = 1;
        this.totalRecords = 0;
        this.rowsPerPage = [10, 15, 20];

        this.searchString = '';

        this.suggestField = this.searchField = 'name';
        this.placeholder = 'Enter name';
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

        this.loadVacancies();
    }

    paginate(event) {
        this.pageNumber = event.page + 1;
        this.pageSize = event.rows;

        this.loadVacancies();
    }

    filterVacancies(event) {
        this.searchString = event.query;
        this.loadVacancies();

        this.paginator.changePage(0);
    }

    select(event) {
        this.searchString = event.name;
        this.vacancies = [];
        this.vacancies[0] = event;
        this.totalRecords = 1;
    }

    clear() {
        this.searchString = '';
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
        this.vacancyService.getAdminResponse(this.searchString, this.searchField,
            this.sortField, this.sortOrder, this.pageSize, this.pageNumber)
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
