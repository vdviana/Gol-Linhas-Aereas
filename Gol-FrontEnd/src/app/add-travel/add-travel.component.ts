import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Travel } from 'src/models/travel';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-add-travel',
  templateUrl: './add-travel.component.html',
  styleUrls: ['./add-travel.component.scss']
})
export class AddTravelComponent implements OnInit {

  public travel: Travel = new Travel();
  public isLoadingResults = true;

  constructor(private router: Router, private route: ActivatedRoute, private apiService: ApiService) {
    if (sessionStorage.getItem("user") == undefined || sessionStorage.getItem("user") == null) {
      this.router.navigate(['/login']);
    }
  }

  ngOnInit() {
    var consoleid = this.route.snapshot.params.id;
    console.log(consoleid)
    if (consoleid > 0) {

      this.getTravel(consoleid);
    }
  }

  getTravel(id: number) {
    this.apiService.getTravel(id)
      .subscribe(data => {
        if (data !== null) {
          this.travel = data;
        }
        this.isLoadingResults = false;
      }, err => { this.travel.id = 0; });
  }

  SaveNewTravel() {
    if (this.travel.id > 0) {

      this.apiService.updateTravel(this.travel)
        .subscribe(data => {
          this.router.navigate(['/travels']);
        });

    } else {

      this.apiService.addTravel(this.travel)
        .subscribe(data => {
          this.router.navigate(['/travels']);
        });
    }
  }
  Cancel() {
    this.router.navigate(['/travels']);
  }

}
