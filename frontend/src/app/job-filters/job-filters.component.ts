import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { CompanyService } from '../core/services/company.service';
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

  @Input() companyName: string;

  constructor(private companyService: CompanyService, private cityService: CityService,

    private workAreaService: WorkAreaService) {
   }


  ngOnInit() {
    this.loadCompanies();
    this.loadWorkAreas();
  }

  loadCompanies() {
    this.companyService.getAll()
      .subscribe((data: Company[]) => {
        this.companies = data
     if(this.companyName !== '') {
       this.selectedCompanies = [];
       this.selectedCompanies[0] = this.companies.find(c => c.name === this.companyName);
      }
      });
  }

  loadWorkAreas() {
    this.workAreaService.getAll()
      .subscribe((data: WorkArea[]) => this.workAreas = data);
  }

  filter() {
    this.filteredVacancies.emit({
      workArea: this.selectedWorkArea === undefined || this.selectedWorkArea === null ? '' : this.selectedWorkArea.name,
      namesOfCompanies: this.selectedCompanies === undefined ||
                       this.selectedCompanies === null ? [] : this.selectedCompanies.map(a => a.name),
      typeOfEmployment: this.selectedTypeOfEmployment === undefined ||
                       this.selectedTypeOfEmployment === null ? '' : this.selectedTypeOfEmployment,
      isChecked: this.checked === undefined || this.checked === null ? false : this.checked,
      salary: this.salary === undefined ? null : this.salary,
      city: null,
      name: null
    });
  }
  reset() {
    this.selectedWorkArea = null,
    this.selectedCompanies = null,
    this.selectedTypeOfEmployment = null,
    this.checked = null,
    this.salary = null;

    this.filteredVacancies.emit({
      workArea: '',
      namesOfCompanies: [],
      typeOfEmployment: '',
      isChecked: null,
      salary: 0,
      city: null,
      name: null
    });
  }
}
