import { Component, OnInit } from '@angular/core';
import { Chart, registerables } from 'chart.js';
import { Observable } from 'rxjs';
import { AjaxErrorNames } from 'rxjs/internal/observable/dom/AjaxObservable';
import { TenderingServiceService } from '../services/tendering-service.service';
Chart.register(...registerables);

@Component({
  selector: 'app-tender-statistics',
  templateUrl: './tender-statistics.component.html',
  styleUrls: ['./tender-statistics.component.css']
})
export class TenderStatisticsComponent implements OnInit {

  public pharmacyNames: string[] = [];

  constructor(private _tenderService: TenderingServiceService) { }

  ngOnInit(): void {
    this.createWinParticipateBarChart();
    this.createWinPieChart();
    this.createBestOfferBarChart();
    this.getPharmacyNames();
  }

  getPharmacyNames(): void {
    this._tenderService.getPharmacyNames().subscribe(
      names => {
        this.pharmacyNames = names;
        console.log(this.pharmacyNames)
    });
  }

  createWinParticipateBarChart() {
    //var names: string[] = ['Benu', 'Jankovic', 'Irisfarm', 'Zegin'];
    var names: string[] = this.pharmacyNames;
    console.log(names)
    var wins: number[] = [2];
    var offers: number[] = [3];
    var myChart = new Chart("winParticipateBarChart", {
      type: 'bar',
      data: {
        labels: names, 
        datasets: [{
          label: 'Wins',
          data: wins, 
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)'
          ],
          borderWidth: 1
        },
        {
          label: 'Participations',
          data: offers,
          backgroundColor: [
            'rgba(54, 162, 235, 0.2)'
          ],
          borderColor: [
            'rgba(54, 162, 235, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true,
          },
        }
      }
    });
  }

  createBestOfferBarChart() {
    var myChart = new Chart("bestOfferBarChart", {
      type: 'bar',
      data: {
        labels: ['T1', 'T2', 'T3', 'T4', 'T5'], //tender names
        datasets: [{
          label: 'Benu',  // pharmacy Benu
          data: [2, 5.1, 3, 7.9, 4], // best offers for each tender for pharmacy Benu
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)'
          ],
          borderWidth: 1
        },
        {
          label: 'Jankovic',  //pharmacy Jankovic
          data: [2.4, 4.6, 2.7, 8.1, 3], // best offers for each tender for pharmacy Jankovic
          backgroundColor: [
            'rgba(255, 206, 86, 0.2)'
          ],
          borderColor: [
            'rgba(255, 206, 86, 1)'
          ],
          borderWidth: 1
        },
        {
          label: 'Irisfarm',  //pharmacy Irisfarm
          data: [3, 5, 3.4, 7.6, 2.5], // best offers for each tender for pharmacy Irisfarm
          backgroundColor: [
            'rgba(153, 102, 255, 0.2)'
          ],
          borderColor: [
            'rgba(153, 102, 255, 1)'
          ],
          borderWidth: 1
        },
        {
          label: 'Zegin', //pharmacy Zegin
          data: [2.1, 5.4, 6, 7.2, 4.5], // best offers for each tender for pharmacy Zegin
          backgroundColor: [
            'rgba(255, 159, 64, 0.2)'
          ],
          borderColor: [
            'rgba(255, 159, 64, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true,
          },
        }
      }
    });
  }
  
  createWinPieChart() {
    var pharmacyNames: string[] = ['Benu', 'Jankovic', 'Irisfarm', 'Zegin'];
    var wins: number[] = [2, 1, 3, 1];
    var myChart = new Chart("winPieChart", {
      type: 'pie',
      data: {
        labels: pharmacyNames,
        datasets: [{
          label: 'Wins',
          data: wins,
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true,
          },
        }
      }
    });
  }

  createChart() {
    var myChart = new Chart("myChart", {
      type: 'bar',
      data: {
        labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
        datasets: [{
          label: '# of Votes',
          data: [12, 19, 3, 5, 2, 3],
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });
  }

}
