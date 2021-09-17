import { Component, OnInit } from '@angular/core';
import { ContractorService } from 'src/app/shared/contractor.service';
import { NgForm } from '@angular/forms';
import { Contractor } from 'src/app/shared/contractor.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-contractor-form',
  templateUrl: './contractor-form.component.html',
  styles: [
  ]
})
export class ContractorFormComponent implements OnInit {

  constructor(public service:ContractorService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postContractor().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Dodano do bazy');
      },
      err => {
        console.log(err);
      }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putContractor().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Zaaktualizowano kontrahenta');
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new Contractor();
  }
}
