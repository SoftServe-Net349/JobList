import { OnInit, Component } from "@angular/core";
import { CompanyService } from "src/app/core/services/company.service";

@Component({
    selector: 'app-admin-companies',
    templateUrl: './admin-companies.component.html',
    styleUrls: ['./admin-companies.component.sass']
})
export class AdminCompaniesComponent implements OnInit {

    constructor(private companyService: CompanyService){
    }

    ngOnInit() {    
    }
}