import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IConsumptionReport } from '../consumption-report/IConsumption';

@Injectable({
  providedIn: 'root'
})
export class ConsumptionReportService {
  private serverUrl: string = 'http://localhost:65508';

  constructor(private http: HttpClient) { }

  generateReport(report:IConsumptionReport) {
    let params = new HttpParams();
    params = params.append("start", report.start);
    params = params.append("end", report.end);
    return this.http.get(this.serverUrl + "/hospital/report/generate", { params: params });
  }
}
