import { ApiService } from './../api.service';
import { Component, OnInit } from '@angular/core';
import { ɵangular_packages_platform_browser_dynamic_platform_browser_dynamic_a } from '@angular/platform-browser-dynamic';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})


export class LoginComponent implements OnInit {
  public User: string = "";
  public Password: string = "";



  isLoadingResults = true;

  constructor(private _api: ApiService, private _rout: Router) {
    if (sessionStorage.getItem("user") !== undefined && sessionStorage.getItem("user") !== null) {
      _rout.navigate(["/travels"]);
    }

  }
  public Login() {

    console.log("login");

    var authobj: any = { user: this.User, password: this.Password };

    console.log(authobj);
    this._api.Authenticate(authobj).subscribe(res => {

      authobj = res;
      if ((authobj.user as string).length > 0) {
        sessionStorage.setItem("user", authobj.user);
        this._rout.navigate(['/travels']);

      } else {
        alert('não foi possivel autenticar');
      }
    }, (err) => {
      alert(err as string);
    });
  }


  public Register() {
    console.log("register");

    var authobj: any = { user: this.User, password: this.Password };
    console.log(authobj);
    this._api.Register(authobj).subscribe(res => {
      let ret = res as string;
      if (!ret.includes("erro")) {
        alert(ret);
      }
      else {
        alert(ret);
      }
    }, err => { alert(err as string) });
  }


  ngOnInit() {

  }

}
