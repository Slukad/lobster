import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Adventure } from '../shared/adventure.model';
import { Decision } from '../shared/decision.model';
import { Router } from '@angular/router';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public adventures: Adventure[];
  public decisions: Decision[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {    
    this.loadAdventures(http, baseUrl);    
  }

  private loadAdventures(http: HttpClient, baseUrl: string) {
    http.get<Adventure[]>(baseUrl + 'api/adventure').subscribe(result => {
      this.adventures = result;
    }, error => console.error(error));
  }

  data(args: any) {
    this.router.navigateByUrl('/viewer', { state: args });
  }
}
