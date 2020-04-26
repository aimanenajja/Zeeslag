import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccessPass } from './_models/access-pass.model';
import { AuthenticationService } from './_services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  accessPass: AccessPass;

  constructor(private router: Router, private authenticationService: AuthenticationService) {
    this.authenticationService.accessPass$.subscribe((x) => (this.accessPass = x));
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }
}
