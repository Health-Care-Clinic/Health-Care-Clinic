import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Chart } from 'chart.js';
import { ITender } from '../model/tender';
import { TenderingServiceService } from '../services/tendering-service.service';

@Component({
  selector: 'app-pharmacy-tender-statistics',
  templateUrl: './pharmacy-tender-statistics.component.html',
  styleUrls: ['./pharmacy-tender-statistics.component.css']
})
export class PharmacyTenderStatisticsComponent implements OnInit {
  
  public idp: number = -1;
  public tenders: ITender[] = [];
  public selectedTender: number = 0;
  constructor(private _route: ActivatedRoute, private _tenderService: TenderingServiceService) { }


  ngOnInit(): void {
    this.idp = +this._route.snapshot.paramMap.get('idp');
    this.createWinPieChart();
    this.createOffersBarChart();
    this.createOffersPieChart();
    this.getAllTenders();
  }
  
  getAllTenders(): void {
    this._tenderService.getAllTenders().subscribe(
      tenders => {
        this.tenders = tenders;
      });
  }

  createWinPieChart() {
    var wins = 2;
    var total = 3;
    var chartData: number[] = [wins, total - wins];
    var myChart = new Chart("winPieChart", {
      type: 'pie',
      data: {
        labels: ['Won', 'Did not win'],
        datasets: [{
          label: 'Wins',
          data: chartData,
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

  createOffersBarChart() {
    var offersNum = 3;
    var offerNames: string[] = [];
    for(let i = 1; i <= offersNum; i++){
      offerNames.push("offer "+i);
    }
    var offers: number[] = [32000, 36000, 31000];
    var myChart = new Chart("offersBarChart", {
      type: 'bar',
      data: {
        labels: offerNames, 
        datasets: [{
          label: 'Price',
          data: offers, 
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)'
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

  createOffersPieChart() {
    var offers = 2;
    var totalOffers = 5;
    var chartData: number[] = [offers, totalOffers - offers];
    var myChart = new Chart("offersPieChart", {
      type: 'pie',
      data: {
        labels: ['Pharmacy offers', 'Other offers'],
        datasets: [{
          label: 'Wins',
          data: chartData,
          backgroundColor: [
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)'
          ],
          borderColor: [
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

}
