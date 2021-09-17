import { Injectable } from '@angular/core';
import { Contractor } from './contractor.model';
import { HttpClient } from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class ContractorService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'https://localhost:5001/api/contractors';
  formData:Contractor = new Contractor();
  list : Contractor[];

  postContractor(){
    return this.http.post(this.baseURL, this.formData);
  }

  putContractor(){
    return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData);
  }

  deleteContractor(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList() {
    this.http.get(this.baseURL)
    .toPromise()
    .then(res => this.list = res as Contractor[]);
  }
}
