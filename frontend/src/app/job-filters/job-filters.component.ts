import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../core/services/company.service';
import { CityService } from '../core/services/city.service';
import { WorkAreaService } from '../core/services/work-area.service';
import { WorkArea } from '../shared/models/work-area.model';
import { City } from '../shared/models/city.model';
import { Company } from '../shared/models/company.model';

@Component({
  selector: 'app-job-filters',
  templateUrl: './job-filters.component.html',
  styleUrls: ['./job-filters.component.sass'],
  providers: [CompanyService]
})

export class JobFiltersComponent implements OnInit {

  checked: Boolean = false;

  workAreas: WorkArea[];
  selectedWorkArea: WorkArea;

  cities: City[];
  selectedCity: City;

  companies: Company[];
  selectedCompanies: Company[];


  constructor(private companyService: CompanyService, private cityService: CityService,
    private workAreaService: WorkAreaService) {
   }


  ngOnInit() {
    this.loadCompanies();
    this.loadCities();
    this.loadWorkAreas();
  }


  loadCompanies(){
    this.companyService.getAll()
      .subscribe((data: Company[]) => this.companies = data);
  }

  loadCities(){
    this.cityService.getAll()
      .subscribe((data: City[]) => this.cities = data);
  }

  loadWorkAreas(){
    this.workAreaService.getAll()
      .subscribe((data: WorkArea[]) => this.workAreas = data);
  }
}
