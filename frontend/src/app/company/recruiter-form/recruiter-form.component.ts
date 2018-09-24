import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-recruiter-form',
  templateUrl: './recruiter-form.component.html',
  styleUrls: ['./recruiter-form.component.sass']
})
export class RecruiterFormComponent implements OnInit {

  display: Boolean = false;

  uploadedFiles: any[] = [];

  constructor(private messageService: MessageService) {}

  onUpload(event) {
      for (const file of event.files) {
          this.uploadedFiles.push(file);
      }

      this.messageService.add({severity: 'info', summary: 'File Uploaded', detail: ''});
  }

  ngOnInit() {
  }

  showRecruiterForm() {
    this.display = true;
}

}
