import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-order-dialog',
  templateUrl: './order-dialog.component.html',
  styleUrls: ['./order-dialog.component.css']
})
export class OrderDialogComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<OrderDialogComponent>) { }

  ngOnInit(): void {
  }

  order() {
    this.dialogRef.close(true);
  }
  
  close() {
    this.dialogRef.close(false);
  }

}
