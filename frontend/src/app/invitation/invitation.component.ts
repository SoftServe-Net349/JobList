import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { InvitationHubService } from '../core/hubs/invitation.hub';
import { AuthHelper } from '../shared/helpers/auth-helper';
import { InvitationService } from '../core/services/invitation.service';
import { Invitation } from '../shared/models/invitation.model';
import { Paginator } from 'primeng/primeng';

@Component({
  selector: 'app-invitation',
  templateUrl: './invitation.component.html',
  styleUrls: ['./invitation.component.sass']
})
export class InvitationComponent implements OnInit {

  visibleSidebar = false;

  invitations: Invitation[];
  @Input() employeeId: number;

  invitationCounter = 0;
  pageSize = 6;
  pageNumber = 1;

  constructor(private invitationHub: InvitationHubService,
              private authHelper: AuthHelper,
              private invitationService: InvitationService) { }

  ngOnInit() {

    this.loadInvitations();
    this.subscribeToInvitationEvents();

  }

  loadInvitations(id: number = this.employeeId,
    pageSize: number = this.pageSize,
    pageNumber: number = this.pageNumber): void {

    this.invitationService.getByEmployeeId(id, pageSize, pageNumber )
    .subscribe((response) => {this.invitations = response.body;
      const XPagination = JSON.parse(response.headers.get('X-Pagination'));

      if (XPagination !== null) {

        this.invitationCounter = XPagination.TotalRecords;

      }
    });

  }

  paginate(event) {

    this.pageNumber = ++event.page;
    const pageSize = event.rows;

    this.loadInvitations(this.employeeId, pageSize, this.pageNumber);

  }

  private subscribeToInvitationEvents(): void {

    this.invitationHub.invitationReceived.subscribe((invitation: Invitation) => {
      this.invitationCounter ++;

      if (this.invitations) {

        this.invitations.unshift(invitation);

      } else {

        this.invitations = [invitation];

      }
    });

  }

  acceptInvitation(id: number) {

    this.invitationService.delete(id)
    .subscribe(data => { this.loadInvitations(); });

  }

  rejectInvitation(id: number) {

    this.invitationService.delete(id)
    .subscribe(data => { this.loadInvitations(); });

  }
}
