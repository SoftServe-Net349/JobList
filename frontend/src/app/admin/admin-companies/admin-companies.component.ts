import { OnInit, Component, ViewChild } from "@angular/core";
import { CompanyService } from "src/app/core/services/company.service";
import { Company } from "src/app/shared/models/company.model";
import { SelectItem, ConfirmationService } from "primeng/api";
import { Paginator } from "primeng/primeng";
import { isNullOrUndefined } from "util";

@Component({
    selector: 'app-admin-companies',
    templateUrl: './admin-companies.component.html',
    styleUrls: ['./admin-companies.component.sass']
})
export class AdminCompaniesComponent implements OnInit {

    companies: Company[];

    displayDialog: boolean = false;

    sortKey: string = '';
    sortOrder: boolean = false;
    sortField: string = '';

    sortOptions: SelectItem[];

    pageSize: number = 4;
    pageNumber: number = 1;
    totalRecords: number = 0;

    searchString: string = '';
    searchedCompany: Company = null;

    @ViewChild('p') paginator: Paginator;

    constructor(private confirmationService: ConfirmationService, private companyService: CompanyService, ){
        this.companies = [];
    }

    ngOnInit() {    
        
        this.sortOptions = [
            { label: 'Name', value: 'Name' }
        ];

        this.loadCompanies();
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

        this.loadCompanies();
    }


    paginate(event) {
        this.pageNumber = event.page + 1;
        this.pageSize = event.rows;

        this.loadCompanies();
    }

    filterCompanies(event) {
        this.searchString = event.query;
        this.pageNumber = 1;
        this.loadCompanies();
        
        this.paginator.changePage(0);
    }

    select(event) {
        this.searchString = event.name;
        this.pageNumber = 1;
        this.loadCompanies();

        this.paginator.changePage(0);
    }

    search() {
        if (isNullOrUndefined(this.searchedCompany)) {
            this.searchString = '';
        }
        else if (isNullOrUndefined(this.searchedCompany.name)) {
            this.searchString = this.searchedCompany.toString();
        }

        this.pageNumber = 1;
        this.loadCompanies();

        this.paginator.changePage(0);
    }


    loadCompanies() {
        this.companyService.getFullResponse(this.searchString, this.sortField, this.sortOrder, this.pageSize, this.pageNumber)
            .subscribe((response) => {
                if (response.body !== null) {
                    this.companies = response.body;
                    this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
                }
                else {
                    this.companies = null;
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
                this.companyService.delete(id).subscribe(data => this.loadCompanies());
            }
        });
    }
}