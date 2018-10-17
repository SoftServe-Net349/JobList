import { OnInit, Component, ViewChild } from "@angular/core";
import { VacancyService } from "src/app/core/services/vacancy.service";
import { Vacancy } from "src/app/shared/models/vacancy.model";
import { ConfirmationService, SelectItem } from "primeng/api";
import { VacancyRequest } from "src/app/shared/models/vacancy-request.model";
import { Paginator } from "primeng/primeng";
import { isNullOrUndefined } from "util";

@Component({
    selector: 'app-admin-vacancies',
    templateUrl: './admin-vacancies.component.html',
    styleUrls: ['./admin-vacancies.component.sass']
})
export class AdminVacanciesComponent implements OnInit {

    vacancies: Vacancy[];

    displayDialog: boolean = false;

    sortKey: string = '';
    sortOrder: boolean = false;
    sortField: string = '';

    sortOptions: SelectItem[];

    pageSize: number = 4;
    pageNumber: number = 1;
    totalRecords: number = 0;

    searchString: string = '';
    searchedVacancy: Vacancy = null;

    @ViewChild('p') paginator: Paginator;


    constructor(private vacancyService: VacancyService,
        private confirmationService: ConfirmationService) {
        this.vacancies = [];
    }

    ngOnInit() {
        this.loadVacancies();

        this.sortOptions = [
            { label: 'Newest First', value: '!CreateDate' },
            { label: 'Oldest First', value: 'CreateDate' },
            { label: 'Name', value: 'Name' }
        ];
    }

    onSortChange(event) {
        let value = event.value;

        if (value.indexOf('!') === 0) {
            this.sortOrder = false;
            this.sortField = value.substring(1, value.length);
        }
        else {
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
        this.pageNumber = 1;
        this.loadVacancies();
        
        this.paginator.changePage(0);
    }

    select(event) {
        this.searchString = event.name;
        this.pageNumber = 1;
        this.loadVacancies();

        this.paginator.changePage(0);
    }


    search() {
        if (isNullOrUndefined(this.searchedVacancy)) {
            this.searchString = '';
        }
        else if (isNullOrUndefined(this.searchedVacancy.name)) {
            this.searchString = this.searchedVacancy.toString();
        }

        this.pageNumber = 1;
        this.loadVacancies();

        this.paginator.changePage(0);
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
        this.vacancyService.getAdminResponse(this.searchString, this.sortField, this.sortOrder, this.pageSize, this.pageNumber)
            .subscribe((response) => {
                if (response.body !== null) {
                    this.vacancies = response.body;
                    this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
                }
                else {
                    this.vacancies = null;
                    this.totalRecords = 0;
                }
            });
    }
}