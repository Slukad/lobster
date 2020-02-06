import { Component, Inject, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Decision } from '../shared/decision.model';
import { SelectedChoice } from '../shared/selectedChoice.model';
import { Choice } from '../shared/choice.model';

@Component({
  selector: 'app-branch',
  templateUrl: './branch.component.html',
  styleUrls: ['./branch.component.css']
})
export class BranchComponent implements OnInit{
  @Input('decision') decision: Decision;
  @Input('decisions') decisions: Decision[];
  @Input('expandAll') expandAll: string;
  @Output() choiceSelected = new EventEmitter<SelectedChoice>();  
  httpClient: HttpClient;
  baseUrl: string;
  hasChildren: boolean;
  hasChoices: boolean;
  selected: boolean;
  hideLevel: boolean;
  usable: string;
  isRoot: boolean;
  style: string;
  nextDecision: Decision;
  skipDecision: Decision;
  nextLevel: number;
  choiceNumber: number;
  skippedChoiceId: number;
  skippedChoiceNumber: number;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
  }
  
  ngOnInit() {
    this.hasChildren = true;
    this.hasChoices = true;
    this.usable = 'true';
        
    if (this.decision.level === 1) {
      this.isRoot = true;
      this.style = 'treeLevel1';
    }
    else {
      this.isRoot = false;
      this.style = 'treeLevel' + this.decision.level.toString() + this.decision.order;

      if (!this.decision || !this.decision.choices || this.decision.choices.length === 0) {
        this.hasChoices = false;
      }
    }
  }

  onClick(choiceId: any, choiceNumber: any) {
    if (!this.expandAll && !this.decision.done)
    {
      if (this.usable) {
        this.choiceNumber = choiceNumber;
        let decisionId = this.getSelectedDecisionIdByChoiceId(choiceId);
        let skippedDecisionId = this.getSkippedDecisionIdByChoiceId(choiceId);
        this.nextDecision = this.getDecisionById(decisionId);
        this.skipDecision = this.getDecisionById(skippedDecisionId);
        this.nextLevel = this.decision.level + 1;
        this.selected = true;
        this.usable = 'true';
        // if it does have children then true else false
        this.hasChildren = true;

        if (!this.nextDecision.choices || this.nextDecision.choices.length === 0) {
          this.decision.resolution = this.nextDecision.text;
        }

        let choice = new Choice(); 
        choice.id = choiceId;
        let selectedChoice: SelectedChoice =
        {
          id: 0,
          choiceId: choiceId,
          decisionId: decisionId,
          nextDecision : this.nextDecision
        };
        
        this.choiceSelected.emit(selectedChoice);
      }
    }
  }

  getSelectedDecisionIdByChoiceId(choiceId: any) {
    for (let i = 0; i < this.decision.choices.length; i++) {
      if (this.decision.choices[i].id === choiceId) {
        return this.decision.choices[i].nextDecision.id;
      }
    }
  }

  getSkippedChoiceId(choiceId: any) {
    for (let i = 0; i < this.decision.choices.length; i++) {
      if (this.decision.choices[i].id !== choiceId) {
        return this.decision.choices[i].id;
      }
    }
  }

  getSkippedDecisionIdByChoiceId(choiceId: any) {
    for (let i = 0; i < this.decision.choices.length; i++) {
      if (this.decision.choices[i].id !== choiceId) {
        return this.decision.choices[i].nextDecision.id;
      }
    }
  }

  getDecisionById(decisionId: any) {    
    for (let j = 0; j < this.decisions.length; j++) {
      if (this.decisions[j].id === decisionId) {
        return this.decisions[j];
      }
    }
  }
}
