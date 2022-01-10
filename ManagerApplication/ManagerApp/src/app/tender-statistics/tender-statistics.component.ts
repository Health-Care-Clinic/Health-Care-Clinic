import { Component, OnInit } from '@angular/core';
import { Chart, registerables } from 'chart.js';
import { Observable } from 'rxjs';
import { AjaxErrorNames } from 'rxjs/internal/observable/dom/AjaxObservable';
import { TenderingServiceService } from '../services/tendering-service.service';
import jspdf from 'jspdf';
Chart.register(...registerables);

@Component({
  selector: 'app-tender-statistics',
  templateUrl: './tender-statistics.component.html',
  styleUrls: ['./tender-statistics.component.css']
})
export class TenderStatisticsComponent implements OnInit {

  public pharmacyNames: string[] = [];

  constructor(private _tenderService: TenderingServiceService) {
  }

  ngOnInit(): void {
    this.createWinParticipateBarChart();
    this.createWinPieChart();
    this.createBestOfferBarChart();
  }

  generatePDF(): void {
    const canvas = document.getElementById('winParticipateBarChart') as HTMLCanvasElement;
    const canvasImage = canvas.toDataURL('image/jpeg', 1.0)

    const canvas2 = document.getElementById('winPieChart') as HTMLCanvasElement;
    const canvasImage2 = canvas2.toDataURL('image2/jpeg', 1.0)

    const canvas3 = document.getElementById('bestOfferBarChart') as HTMLCanvasElement;
    const canvasImage3 = canvas3.toDataURL('image3/jpeg', 1.0)

    var pdf = new jspdf('portrait');
    pdf.setFontSize(20);
    pdf.text('Tendering statistics', 70, 15);
    pdf.setFontSize(15);
    pdf.text('Ratio of pharmacy wins and participations in tenders', 45, 30);
    pdf.addImage(canvasImage, 'JPEG', 60, 35, 90, 90, "alias1");
    pdf.text('Ratio of pharmacy wins', 75, 140);
    pdf.addImage(canvasImage2, 'JPEG', 60, 160, 90, 90, "alias2");
    pdf.addPage();
    pdf.setPage(2);
    pdf.text('Best offer per tender', 75, 15);
    pdf.addImage(canvasImage3, 'JPEG', 60, 35, 90, 90, "alias3");
    pdf.save('charts.pdf');
  }

  createWinParticipateBarChart() {
    this._tenderService.getPharmacyNames().subscribe(
      names => {
        this._tenderService.getNumberOfWins().subscribe(
          wins => {
            this._tenderService.getNumberOfOffers().subscribe(
              offers => {
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
                      'rgba(255, 206, 86, 0.2)'
                    ],
                    borderColor: [
                      'rgba(255, 206, 86, 1)'
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
          });
        });
      });
  }

  createBestOfferBarChart() {
    this._tenderService.getPharmacyNames().subscribe(
      names => { 
      this._tenderService.getBestOffers().subscribe(
        offers => {
      var myChart = new Chart("bestOfferBarChart", {
        type: 'bar',
        data: {
          labels: ['T1', 'T2'], //tender names
          datasets: [{
            label: names[0],
            data: [offers[0], offers[1]], // best offers for each tender for pharmacy Benu
            backgroundColor: [
              'rgba(255, 99, 132, 0.2)',
            ],
            borderColor: [
              'rgba(255, 99, 132, 1)'
            ],
            borderWidth: 1
          },
          {
            label: names[1],
            data: [offers[2], offers[3]], // best offers for each tender for pharmacy Jankovic
            backgroundColor: [
              'rgba(255, 206, 86, 0.2)'
            ],
            borderColor: [
              'rgba(255, 206, 86, 1)'
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
      });
    });
  }

  createWinPieChart() {
    this._tenderService.getPharmacyNames().subscribe(
      pharmacyNames => {
      this._tenderService.getNumberOfWins().subscribe(
        wins => { 
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
      });
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
