import { Decision } from '../shared/decision.model';

export class Choice {
  id: number;
  text: string;
  order: number;
  decision: Decision;
  nextDecision: Decision;
}
