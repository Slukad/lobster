import { Component, Inject, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Decision } from '../shared/decision.model';
import { Adventure } from '../shared/adventure.model';
import { SelectedChoice } from '../shared/selectedChoice.model';
import { Player } from '../shared/player.model';
import { ActivatedRoute, NavigationStart, Router } from '@angular/router';

@Component({
  selector: 'app-viewer',
  templateUrl: './viewer.component.html',
  styleUrls: ['./viewer.component.css']
})
export class ViewerComponent implements OnInit{
  @Input('player') player: Player;
  @Output() restartAdventure = new EventEmitter<boolean>();
  httpClient: HttpClient;
  baseUrl: string;
  public adventure: Adventure;
  public decisions: Decision[];
  public currentDecision: Decision;
  public currentLevel: number;
  public saved: boolean;
  public finalDecision: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router, private activatedRoute: ActivatedRoute) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
    this.currentLevel = 1;
    this.adventure = new Adventure();
    this.adventure.selectedChoices = [];
  }

  private loadADecisions(http: HttpClient, baseUrl: string) {
    http.get<Decision[]>(baseUrl + 'api/decision').subscribe(result => {
      this.decisions = result;
      this.currentDecision = this.decisions[0];
      this.currentDecision.selectedNode = true;
      for (var i = 0; i < this.decisions.length; i++) {
        this.decisions[i].hideNode = this.decisions[i].level > this.currentLevel;
      }
      this.loadAdventures(this.httpClient, this.baseUrl, this.adventure.id);
    }, error => console.error(error));
  }

  private loadAdventures(http: HttpClient, baseUrl: string, id: number) {
    http.get<Adventure>(baseUrl + 'api/adventure/' + id.toString()).subscribe(result => {
      this.adventure = result;      
      this.autoExpand();
    }, error => console.error(error));
  }

  ngOnInit() {
    this.adventure.id = history.state.id;
    if (this.adventure.id)
      this.loadADecisions(this.httpClient, this.baseUrl);   
  }

  autoExpand() {
    for (var i = 0; i < this.adventure.selectedChoices.length; i++) {
      let selectedChoice = this.adventure.selectedChoices[i];
      selectedChoice.nextDecision = new Decision();
      selectedChoice.nextDecision.level = i + 1;
      selectedChoice.nextDecision = this.getDecisionById(selectedChoice.decisionId);
      
      this.onChoiceSelected(selectedChoice); 
    }
  }

  onChoiceSelected(selectedChoice: SelectedChoice) {
    this.currentLevel = selectedChoice.nextDecision.level;
    for (var i = 0; i < this.decisions.length; i++) {
      this.decisions[i].hideNode = this.decisions[i].level > this.currentLevel;
      this.decisions[i].done = this.decisions[i].level < this.currentLevel;
      if (this.decisions[i].id == selectedChoice.nextDecision.id)
        this.decisions[i].selectedNode = true;
      if (!selectedChoice.nextDecision.choices || selectedChoice.nextDecision.choices.length === 0) {
        //this.decision.resolution = this.nextDecision.text;
      }
    }
    if (!selectedChoice.nextDecision.choices || selectedChoice.nextDecision.choices.length == 0) {      
      this.finalDecision = selectedChoice.nextDecision.text;
    }
    this.currentLevel++;
  }
  
  getDecisionById(decisionId: any) {
    for (let j = 0; j < this.decisions.length; j++) {
      if (this.decisions[j].id === decisionId) {
        return this.decisions[j];
      }
    }
  }
}
