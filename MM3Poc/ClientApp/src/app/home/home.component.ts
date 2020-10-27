import { Component, OnInit } from '@angular/core';
import { EmployeeClient, IEmployee, IPerson, Person, Fee, IFee, ITrigger, FeeClient, TriggerClient, Trigger, PersonClient } from '../core/services/api/api.service';
import { Observable } from 'rxjs';
import { debounceTime, map, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

}
