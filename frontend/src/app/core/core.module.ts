import { NgModule, Optional, SkipSelf } from '@angular/core';
import { throwIfAlreadyLoaded } from './guards/module-import.guard';
import { CommonModule } from '@angular/common';
import { CompanyService } from './services/company.service';
import { CityService } from './services/city.service';
import { WorkAreaService } from './services/work-area.service';
import { FacultyService } from './services/faculty.service';
import { SchoolService } from './services/school.service';
import { LanguageService } from './services/language.service';
import { ApiService } from './services/api.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
		ApiService,
    CompanyService,
    CityService,
    WorkAreaService, 
    SchoolService,
    FacultyService,
    LanguageService
  ],
  declarations: []
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}
