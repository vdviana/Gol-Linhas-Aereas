import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Travel } from './../../models/travel';
import { ApiService } from './../api.service';
import { Router, ActivatedRoute } from '@angular/router';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  ngOnInit(): void {

  }

  public logged: boolean;

  constructor(private breakpointObserver: BreakpointObserver, private _api: ApiService, private router: Router) {
    if (sessionStorage.getItem("user") !== undefined && sessionStorage.getItem("user") !== null) {
      this.logged = true;
    }
    else {
      this.logged = false;
    }
  }
  private LogOut() {
    console.log("logout");
    sessionStorage.clear();
    this.router.navigate(["/login"]);

  }

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );
}