import { Component, OnInit } from '@angular/core';
import { MedicineSpecificationService } from 'src/app/services/medicine-specification.service';
import { ISpecification } from 'src/app/medicine-specifications/specification';

@Component({
  selector: 'app-medicine-specifications',
  templateUrl: './medicine-specifications.component.html',
  styleUrls: ['./medicine-specifications.component.css'],
  providers: [ MedicineSpecificationService ]
})
export class MedicineSpecificationsComponent implements OnInit {

  public message: string = "";
  public to: string = "";
  public fileName: string = "";
  public specification: ISpecification = { message: "", to: "", fileName: ""}

  constructor(private _specificationService: MedicineSpecificationService ) {
    this.specification;
   }

  ngOnInit(): void {
  }

  sendMessage(): void {
    this.specification.to = this.to;
    this.specification.message = this.message;
    this.fileName = this.message.toLowerCase();
    this._specificationService.sendMessage(this.specification).subscribe();
  }

  download(): void {
    this.specification.fileName = this.fileName;
    this._specificationService.downloadSpecification(this.specification).subscribe();
    //window.open("../../../assets/brufen.pdf", '_blank');
  }

  openPdf(): void {
    window.open("../../../assets/brufen.pdf", '_blank');
  }
}
