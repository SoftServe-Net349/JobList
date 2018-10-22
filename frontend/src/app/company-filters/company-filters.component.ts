import { Component, OnInit } from '@angular/core';
import { CityService } from '../core/services/city.service';
import { WorkAreaService } from '../core/services/work-area.service';
import { FacultyService } from '../core/services/faculty.service';
import { SchoolService } from '../core/services/school.service';
import { LanguageService } from '../core/services/language.service';

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
  selectedLanguage: Language;

  rangeValues: number[] = [20, 30];

  constructor(private cityService: CityService, private workAreaService: WorkAreaService,
    private facultyService: FacultyService, private schoolService: SchoolService,
    private languageService: LanguageService) {
  }


  ngOnInit() {
    this.loadCities();
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
}


class WorkArea {
  name: string;
}

class Language {
  name: string;
}

class Faculty {
  name: string;
}

class City {
  name: string;
}

class School {
  name: string;
}
