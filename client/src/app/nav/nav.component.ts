import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {}

  constructor(public accountService: AccountService) { } //passes services to the nav component
  ngOnInit(): void {
    console.log(this.accountService.currentUser$)
  }

  login(){
    this.accountService.login(this.model).subscribe(res => {
      console.log(res); 
    }, error => {
      console.log(error);
    })
  }

  logout() {
    this.accountService.logout();
  }
}
