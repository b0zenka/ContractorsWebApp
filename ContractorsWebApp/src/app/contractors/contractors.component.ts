import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Contractor } from '../shared/contractor.model';
import { ContractorService } from '../shared/contractor.service';

@Component({
  selector: 'app-contractors',
  templateUrl: './contractors.component.html',
  styles: [
  ]
})
export class ContractorsComponent implements OnInit {

  constructor(public service: ContractorService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord:Contractor) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Czy na pewno chcesz usunąć kontrahenta?')){
    this.service.deleteContractor(id)
    .subscribe(
      res => {
        this.service.refreshList();
        this.toastr.error("Usunieto kontrahenta");
      },
      err => { console.log(err)}
    )
    }
  }

}
