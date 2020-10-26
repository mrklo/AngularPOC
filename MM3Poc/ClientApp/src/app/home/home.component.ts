import { Component, OnInit } from '@angular/core';
import { EmployeeClient, IEmployee, IPerson, Person, Fee, IFee, ITrigger, FeeClient, TriggerClient, Trigger, PersonClient } from '../core/services/api/api.service';
import { Observable } from 'rxjs';
import { debounceTime, map, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  private pageSize = 12;
  private errorMessage: string;

  public fee: Fee = new Fee();
  public person: Person = new Person();

  public fees: IFee[];
  public triggers: ITrigger[];
  public employees: IEmployee[];

  _listFilter: string;
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    this.filteredItems = this.listFilter ? this.performFilter(this.listFilter) : this.employees;
  }
  filteredItems: IEmployee[];
  performFilter(filterBy: string): IEmployee[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.employees.filter((product: IEmployee) =>
      product.name.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  search = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(200),
      distinctUntilChanged(),
      map(term => term.length < 2 ? []
        : this.triggers.filter(v => v.name.toLowerCase().indexOf(term.toLowerCase()) > -1).slice(0, 10))
    )

  constructor(
    private personClient: PersonClient,
    private feeClient: FeeClient,
    private triggerClient: TriggerClient,
    private employeeClient: EmployeeClient
  ) {
  }

  ngOnInit() {
    // employees
    this.employeeClient.get().subscribe({
      next: data => {
        this.employees = data;
        console.log(this.employees);
        this.filteredItems = this.employees
      },
      error: err => this.errorMessage = err
    });

    // fees
    this.feeClient.get().subscribe({
      next: data => {
        this.fees = data;
      },
      error: err => this.errorMessage = err
    });

    // triggers
    this.triggerClient.get().subscribe({
      next: data => {
        this.triggers = data;
      },
      error: err => this.errorMessage = err
    });


  }

  formatter = (trigger: Trigger) => null;

  onSave() {
    this.personClient.postPerson(this.person).subscribe({
      next: data => {
        console.log(data);
        if (data.errors) {
          alert(data.errors);
        }
        },
        error: err => { this.errorMessage = err; alert(this.errorMessage) }
      });
  }

  onSaveFee() {
    this.feeClient.postFee(this.fee).subscribe({
      next: data => {
        console.log(data);
      },
      error: err => { this.errorMessage = err; alert(this.errorMessage) }
    });
  }


}
