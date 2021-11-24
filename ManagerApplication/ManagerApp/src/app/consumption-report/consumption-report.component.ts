import { Component, OnInit } from '@angular/core';
import { ConsumptionReportService } from '../services/consumption-report.service';
import { IConsumptionReport } from './IConsumption';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-consumption-report',
  templateUrl: './consumption-report.component.html',
  styleUrls: ['./consumption-report.component.css'],
  providers: [ ConsumptionReportService, DatePipe ]
})
export class ConsumptionReportComponent implements OnInit {
  public startDate = new Date();
  public endDate = new Date();
  public report: IConsumptionReport = { start: "", end: "" }

  constructor(private _consumptionService: ConsumptionReportService, public datepipe: DatePipe) { 
    this.report;
  }

  ngOnInit(): void {
  }

  formateDate() {

  }

  generateReport(): void {
    this.report.start = this.datepipe.transform(this.startDate, 'yyyy-MM-dd');
    this.report.end = this.datepipe.transform(this.endDate, 'yyyy-MM-dd');
    this._consumptionService.generateReport(this.report).subscribe();
  }

}
