import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'The Dating App';
  // Turning off Typesafety in typescript
  // Essentially, the type of users can be anything, int, string...etc
  users: any;

  constructor(private accountService: AccountService) {}

  ngOnInit() {

    this.setCurrentUser();
  }

  setCurrentUser() {
    // Get the object out of its stringified form into the user object
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }

  // getUsers() {
  //   // when we want to access any property inside a class
  //   // observables are lazy and require a subscribe method to subscribe to the data
  //   // We know we will get a response (We use an arrow function )
  //   this.http.get('https://localhost:5001/api/users').subscribe(response => {
  //     this.users = response;
  //   }, error => {
  //     console.log(error);
  //   })
  // }


}
