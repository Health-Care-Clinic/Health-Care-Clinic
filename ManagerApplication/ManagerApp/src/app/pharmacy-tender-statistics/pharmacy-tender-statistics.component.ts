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

  public name: string = "";
  public tenders: ITender[] = [];
  public selectedTender: number = 1;
  public myChart1;
  public myChart2;

  public participations: number = 0;
  public wins: number = 0;
  public pharmacyOffers: number[] = [];
  public totalOffersNumber: number = 0;
  constructor(private _route: ActivatedRoute, private _tenderService: TenderingServiceService) { }


  ngOnInit(): void {
    this.name = this._route.snapshot.paramMap.get('idp');
    this.getAllTenders();
    this._tenderService.getTendersNumberParticipatedByPharmacy(this.name).subscribe(
      res1 => {
        this.participations = res1;
        this._tenderService.getTendersNumberWonByPharmacy(this.name).subscribe(
          res2 => {
            this.wins = res2;
            this.createWinPieChart();
            this.reloadCharts(this.selectedTender);
          }
        );
      }
    )
  }

  reloadCharts(tid: number) {
    this.selectedTender = tid;
    this._tenderService.getPharmacyOffersForTender(this.name, tid).subscribe(
      res3 => {
        this.pharmacyOffers = res3;
        this._tenderService.getOffersNumberByTender(tid).subscribe(
          res4 => {
            this.totalOffersNumber = res4;
            this.createOffersBarChart();
            this.createOffersPieChart();
          }
        )
      }
    )
  }

  getAllTenders(): void {
    this._tenderService.getAllTenders().subscribe(
      tenders => {
        this.tenders = tenders;
      });
  }

  createWinPieChart() {
    var wins = this.wins;
    var total = this.participations;
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
    var offersNum = this.pharmacyOffers.length;
    var offerNames: string[] = [];
    for (let i = 1; i <= offersNum; i++) {
      offerNames.push("offer " + i);
    }
    var offers: number[] = this.pharmacyOffers;
    if (this.myChart1 instanceof Chart) {
      this.myChart1.destroy();
    }
    this.myChart1 = new Chart("offersBarChart", {
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
    var offers = this.pharmacyOffers.length;
    var totalOffers = this.totalOffersNumber;
    var chartData: number[] = [offers, totalOffers - offers];
    if (this.myChart2 instanceof Chart) {
      this.myChart2.destroy();
    }
    this.myChart2 = new Chart("offersPieChart", {
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
