import { OnInit, Component, ViewChild } from "@angular/core";
import { SelectItem, ConfirmationService } from "primeng/api";
import { Paginator } from "primeng/primeng";
import { isNullOrUndefined } from "util";
import { Recruiter } from "src/app/shared/models/recruiter.model";
import { RecruiterService } from "src/app/core/services/recruiter.service";

@Component({
    selector: 'app-admin-recruiters',
    templateUrl: './admin-recruiters.component.html',
    styleUrls: ['./admin-recruiters.component.sass']
})
export class AdminRecruitersComponent implements OnInit {

    recruiters: Recruiter[];

    displayDialog: boolean = false;

    sortKey: string = '';
    sortOrder: boolean = false;
    sortField: string = '';

    sortOptions: SelectItem[];

    pageSize: number = 4;
    pageNumber: number = 1;
    totalRecords: number = 0;

    searchString: string = '';
    searchedRecruiter: Recruiter = null;

    @ViewChild('p') paginator: Paginator;

    constructor(private confirmationService: ConfirmationService, private recruiterService: RecruiterService, ){
        this.recruiters = [];
    }

    ngOnInit() {    
        
        this.sortOptions = [
            { label: 'Email', value: 'Email' }
        ];

        this.loadRecruiters();
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

        this.loadRecruiters();
    }


    paginate(event) {
        this.pageNumber = event.page + 1;
        this.pageSize = event.rows;

        this.loadRecruiters();
    }

    filterCompanies(event) {
        this.searchString = event.query;
        this.pageNumber = 1;
        this.loadRecruiters();
        
        this.paginator.changePage(0);
    }

    select(event) {
        this.searchString = event.email;
        this.pageNumber = 1;
        this.loadRecruiters();

        this.paginator.changePage(0);
    }

    search() {
        if (isNullOrUndefined(this.searchedRecruiter)) {
            this.searchString = '';
        }
        else if (isNullOrUndefined(this.searchedRecruiter.email)) {
            this.searchString = this.searchedRecruiter.toString();
        }

        this.pageNumber = 1;
        this.loadRecruiters();

        this.paginator.changePage(0);
    }


    loadRecruiters() {
        this.recruiterService.getFullResponse(this.searchString, this.sortField, this.sortOrder, this.pageSize, this.pageNumber)
            .subscribe((response) => {
                if (response.body !== null) {
                    this.recruiters = response.body;
                    this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
                }
                else {
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
}