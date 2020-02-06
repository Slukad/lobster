import { Component, Inject, Input, OnInit, EventEmitter, Output} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Decision } from '../shared/decision.model';
import { Adventure } from '../shared/adventure.model';
import { SelectedChoice } from '../shared/selectedChoice.model';
import { Player } from '../shared/player.model';

@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.css']
})
export class TreeComponent implements OnInit{
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

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
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
    }, error => console.error(error));
  }

  ngOnInit() {
    this.loadADecisions(this.httpClient, this.baseUrl);
    this.adventure.player = this.player;
    this.adventure.startTime = new Date();
  }

  restart() {
    this.adventure = new Adventure();
    this.currentLevel = 1;
    this.player = null;
    this.restartAdventure.emit(true);
  }

  onChoiceSelected(selectedChoice: SelectedChoice) {
    this.currentLevel = selectedChoice.nextDecision.level;
    for (var i = 0; i < this.decisions.length; i++) {
      this.decisions[i].hideNode = this.decisions[i].level > this.currentLevel;
      this.decisions[i].done = this.decisions[i].level < this.currentLevel;
      if (this.decisions[i].id == selectedChoice.nextDecision.id)
        this.decisions[i].selectedNode = true;
    }
    this.adventure.selectedChoices.push(selectedChoice);
    if (!selectedChoice.nextDecision.choices || selectedChoice.nextDecision.choices.length == 0) {
      this.adventure.endTime = new Date();
      
      this.httpClient.post<Adventure[]>(this.baseUrl + 'api/adventure', this.adventure).subscribe(result => {       
      }, error => console.error(error));

      this.finalDecision = selectedChoice.nextDecision.text;
      this.saved = true;
      
    }
  }
}
