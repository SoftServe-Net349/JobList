import { Component, OnInit } from '@angular/core';
import { CityService } from '../../core/services/city.service';
import { VacancyService } from '../../core/services/vacancy.service';
import { Vacancy } from '../../shared/models/vacancy.model';
import { City } from '../../shared/models/city.model';
import { SafeUrl, DomSanitizer } from '@angular/platform-browser';
import { Company } from '../../shared/models/company.model';
import { CompanyService } from '../../core/services/company.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-search',
  templateUrl: './main-search.component.html',
  styleUrls: ['./main-search.component.sass'],
  providers: [CityService]
})

export class MainSearchComponent implements OnInit {

  cities: City[];
  selectedCity: City;

  companies: Company[];

  vacancies: Vacancy[];

  searchString: string;

  constructor(private cityService: CityService,
    private vacancyService: VacancyService,
    private _sanitizer: DomSanitizer,
    private companyService: CompanyService,
    private router: Router) {
  }

  ngOnInit() {
    this.loadCities();
    this.loadVacancies();
    this.loadCompanies();
  }

  loadCities() {
    this.cityService.getAll()
      .subscribe((data: City[]) => this.cities = data);
  }

  loadVacancies() {
    this.vacancyService.getAll()
      .subscribe((data: Vacancy[]) => this.vacancies = data);
  }

  loadCompanies() {
    this.companyService.getAll()
      .subscribe((data: Company[]) => this.companies = data);
  }


  sanitizeCityImg(imageBase64, city: City): SafeUrl {

    if (this.cities !== undefined && city.photoData !== undefined &&
      city.photoData !== null && city.photoData !== '') {
      return this._sanitizer.bypassSecurityTrustUrl(`data:image/${city.photoMimetype};base64,` + imageBase64);

    } else {

      return '../../../images/defaultUser.png';

    }
  }

  sanitizeCompanyImg(imageBase64, company: Company): SafeUrl {

    if (this.cities !== undefined && company.logoData !== undefined &&
      company.logoData !== null && company.logoData !== '') {
      return this._sanitizer.bypassSecurityTrustUrl(`data:image/${company.logoMimetype};base64,` + imageBase64);

    } else {

      return '../../../images/yourLogoHere.png';

    }
  }

  goToJobSearch() {
    this.router.navigate(
      ['/jobsearch'],
      {
        queryParams:
        {
          'searchString': this.searchString,
          'city': this.selectedCity === undefined ? '' : this.selectedCity.name
        }
      }
    );
  }
  goToJobSearchByVacancy(vacancyName: string) {
    this.router.navigate(
      ['/jobsearch'],
      {
        queryParams:
        {
          'searchString': vacancyName
        }
      }
    );
  }

  goToJobSearchByCompany(companyName: string) {
    this.router.navigate(
      ['/jobsearch'],
      {
        queryParams:
        {
          'company': companyName
        }
      }
    );
  }

  goToJobSearchByCity(cityName: string) {
    this.router.navigate(
      ['/jobsearch'],
      {
        queryParams:
        {
          'city': cityName
        }
      }
    );
  }
}
