import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-resume-details',
  templateUrl: './resume-details.component.html',
  styleUrls: ['./resume-details.component.sass']
})
export class ResumeDetailsComponent implements OnInit {

  display: Boolean = false;
  showDialog() {
      this.display = true;
  }

  constructor() { }

  ngOnInit() {
  }

}
