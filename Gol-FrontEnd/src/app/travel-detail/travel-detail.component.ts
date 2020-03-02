import { Travel } from './../../models/travel';
import { ApiService } from './../api.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-travel-detail',
  templateUrl: './travel-detail.component.html',
  styleUrls: ['./travel-detail.component.scss']
})
export class TravelDetailComponent implements OnInit {

  travelmodel: Travel = new Travel();
  isLoadingResults = true;

  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService) {

    if (sessionStorage.getItem("user") == undefined || sessionStorage.getItem("user") == null) {
      this.router.navigate(['/login']);
    }

  }

  ngOnInit() {
    this.getTravel(this.route.snapshot.params.id);
  }

  getTravel(id: number) {
    this.api.getTravel(id)
      .subscribe(data => {
        if (data !== null) {
          this.travelmodel = data;
        }


        this.isLoadingResults = false;
      });
  }

  deleteTravel(id: number) {
    this.isLoadingResults = true;
    this.api.deleteTravel(id)
      .subscribe(res => {
        this.isLoadingResults = false;
        this.router.navigate(['/travels']);
      }, (err) => {

        this.isLoadingResults = false;
      }
      );
  }
}
