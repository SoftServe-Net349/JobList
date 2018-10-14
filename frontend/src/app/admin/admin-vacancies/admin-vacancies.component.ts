import { OnInit, Component, Output, EventEmitter } from "@angular/core";
import { VacancyService } from "src/app/core/services/vacancy.service";
import { Vacancy } from "src/app/shared/models/vacancy.model";
import { ConfirmationService } from "primeng/api";
import { VacancyRequest } from "src/app/shared/models/vacancy-request.model";

@Component({
    selector: 'app-admin-vacancies',
    templateUrl: './admin-vacancies.component.html',
    styleUrls: ['./admin-vacancies.component.sass']
})
export class AdminVacanciesComponent implements OnInit {

    @Output() loadVacancy = new EventEmitter();

    pageSize: number = 10;
    pageNumber: number = 1;
    totalRecords: number = 0;

    vacancies: Vacancy[];


    constructor(private vacancyService: VacancyService, private confirmationService: ConfirmationService) { 
        this.vacancies = [];
    }

    ngOnInit() {
        this.loadVacancies();
    }

    checkConfirm(vacancy: Vacancy) {
        const request : VacancyRequest = {
            name: vacancy.name,
            description: vacancy.description,
            offering: vacancy.offering,
            requirements: vacancy.requirements,
            bePlus: vacancy.bePlus,
            isChecked: true,
            salary: vacancy.salary,
            fullPartTime: vacancy.fullPartTime,
            createDate: vacancy.createDate,
            cityId: vacancy.city.id,
            recruiterId: vacancy.recruiter.id,
            workAreaId: vacancy.workArea.id
        };

        this.confirmationService.confirm({
            message: 'Do you want to check this record?',
            header: 'Check Confirmation',
            icon: 'pi pi-info-circle',
            accept: () => {
                this.vacancyService.update(vacancy.id, request).subscribe(data => this.loadVacancy.emit());
            }
        });
    }


    loadVacancies() {
        this.vacancyService.getFullResponse(this.pageSize, this.pageNumber)
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