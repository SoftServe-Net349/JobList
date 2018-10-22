import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { CompanyService } from '../core/services/company.service';
import { CityService } from '../core/services/city.service';
import { WorkAreaService } from '../core/services/work-area.service';
import { WorkArea } from '../shared/models/work-area.model';
import { Company } from '../shared/models/company.model';
import { JobSearchQuery } from '../shared/filterQueries/JobsearchQuery';

@Component({
  selector: 'app-job-filters',
  templateUrl: './job-filters.component.html',
  styleUrls: ['./job-filters.component.sass'],
  providers: [CompanyService]
})

export class JobFiltersComponent implements OnInit {

  checked: boolean;
  salary: number;

  workAreas: WorkArea[];
  selectedWorkArea: WorkArea;

  companies: Company[];
  selectedCompanies: Company[];

  selectedTypeOfEmployment: string;
  @Output() filteredVacancies = new EventEmitter<JobSearchQuery>();

  constructor(private companyService: CompanyService, private cityService: CityService,
    private workAreaService: WorkAreaService) {
   }


  ngOnInit() {
    this.loadCompanies();
    this.loadWorkAreas();
  }

  loadCompanies() {
    this.companyService.getAll()
      .subscribe((data: Company[]) => this.companies = data);
  }

  loadWorkAreas() {
    this.workAreaService.getAll()
      .subscribe((data: WorkArea[]) => this.workAreas = data);
  }
  filter() {
    this.filteredVacancies.emit({
      workArea: this.selectedWorkArea === undefined ? '' : this.selectedWorkArea.name,
      namesOfCompanies: this.selectedCompanies === undefined ||
                       this.selectedCompanies === null ? [] : this.selectedCompanies.map(a => a.name),
      typeOfEmployment: this.selectedTypeOfEmployment === undefined ||
                       this.selectedTypeOfEmployment === null ? '' : this.selectedTypeOfEmployment,
      isChecked: this.checked === undefined || this.checked === null ? false : this.checked,
      salary: this.salary === undefined || this.salary === null ||
      this.salary.toString() === '' ? 0 : this.salary,
      city: null,
      name: null
    });
  }
}
