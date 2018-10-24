import { Component, OnInit, Input } from '@angular/core';
import { InvitationHubService } from '../core/hubs/invitation.hub';
import { AuthHelper } from '../shared/helpers/auth-helper';
import { InvitationService } from '../core/services/invitation.service';
import { Invitation } from '../shared/models/invitation.model';

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
  pageSize = 10;
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
      this.invitations.unshift(invitation);
    });

  }

}
