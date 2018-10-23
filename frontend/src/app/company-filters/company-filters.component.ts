import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { CityService } from '../core/services/city.service';
import { WorkAreaService } from '../core/services/work-area.service';
import { FacultyService } from '../core/services/faculty.service';
import { SchoolService } from '../core/services/school.service';
import { LanguageService } from '../core/services/language.service';
import { WorkArea } from '../shared/models/work-area.model';
import { School } from '../shared/models/school.model';
import { Faculty } from '../shared/models/faculty.model';
import { City } from '../shared/models/city.model';
import { Language } from '../shared/models/language.model';
import { ResumessearchQuery } from '../shared/filterQueries/ResumessearchQuery';

@Component({
  selector: 'app-company-filters',
  templateUrl: './company-filters.component.html',
  styleUrls: ['./company-filters.component.sass']
})
export class CompanyFiltersComponent implements OnInit {

  workAreas: WorkArea[];
  selectedWorkArea: WorkArea;

  schools: School[];
  selectedSchools: School[];

  faculties: Faculty[];
  selectedFaculties: Faculty[];

  cities: City[];
  selectedCity: City;

  languages: Language[];
  selectedLanguages: Language[];

  @Output() filteredResumes = new EventEmitter<ResumessearchQuery>();

  rangeValues: number[] = [20, 30];

  constructor(private cityService: CityService, private workAreaService: WorkAreaService,
    private facultyService: FacultyService, private schoolService: SchoolService,
    private languageService: LanguageService) {
  }


  ngOnInit() {
    this.loadWorkAreas();
    this.loadFaculties();
    this.loadSchools();
    this.loadLanguages();
  }

  loadCities() {
    this.cityService.getAll()
    .subscribe((data: City[]) => this.cities = data);
  }

  loadWorkAreas() {
    this.workAreaService.getAll()
    .subscribe((data: WorkArea[]) => this.workAreas = data);
  }

  loadSchools() {
    this.schoolService.getAll()
    .subscribe((data: School[]) => this.schools = data);
  }

  loadFaculties() {
    this.facultyService.getAll()
    .subscribe((data: Faculty[]) => this.faculties = data);
  }

  loadLanguages() {
    this.languageService.getAll()
    .subscribe((data: Language[]) => this.languages = data);
  }

  filter() {
    this.filteredResumes.emit({
      workArea: this.selectedWorkArea === undefined ? '' : this.selectedWorkArea.name,
      schools: this.selectedSchools === undefined ||
               this.selectedSchools === null ? [] : this.selectedSchools.map(s => s.name),
      faculties: this.selectedFaculties === undefined ||
                 this.selectedFaculties === null ? [] : this.selectedFaculties.map(f => f.name),
      age: this.rangeValues === undefined ||
           this.rangeValues === null || this.rangeValues[0].toString() === '' ? 0 : this.rangeValues[0],
      languages: this.selectedLanguages === undefined ||
                 this.selectedLanguages === null ? [] : this.selectedLanguages.map(l => l.name),
      city: null,
      name: null
    });
  }
}
