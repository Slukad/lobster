import { Decision } from '../shared/decision.model';
import { Choice } from './choice.model';

export interface SelectedChoice {
  id: number;
  choiceId: number;
  //choice: Choice;
  decisionId: number;
  nextDecision: Decision;
}
