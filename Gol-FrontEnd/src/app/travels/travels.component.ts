import { Travel } from './../../models/travel';
import { ApiService } from './../api.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-travels',
  templateUrl: './travels.component.html',
  styleUrls: ['./travels.component.scss']
})

export class TravelsComponent implements OnInit {

  displayedColumns: string[] = ['Nome', 'Origem', 'Destino', 'DataPartida', 'detalhe', 'editar', 'deletar'];
  dataSource: Array<Travel>;
  isLoadingResults = true;

  constructor(private apiService: ApiService, private router: Router) {

    if (sessionStorage.getItem("user") == undefined || sessionStorage.getItem("user") == null) {
      this.router.navigate(['/login']);

    }

  }

  ngOnInit() {
    this.GetAllTravels();
  }

  public GetAllTravels() {
    this.apiService.getAllTravels()
      .subscribe(res => {
        if (res !== null) {
          this.dataSource = res;
        }


        this.isLoadingResults = false;
      }, err => {

        this.isLoadingResults = false;
      });
  }

  deleteTravel(travel: Travel): void {

    if (window.confirm('Deseja deletar esta viagem ' + travel.nome + '?')) {
      this.apiService.deleteTravel(travel.id)
        .subscribe(res => {
          this.GetAllTravels();
        })
    }

  };






}
