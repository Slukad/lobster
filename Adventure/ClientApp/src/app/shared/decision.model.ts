import { Choice } from '../shared/choice.model';

export class Decision {
  id: number;
  text: string;
  level: number;
  order: number;
  choices: Choice[];
  resolution: string;
  hideNode: boolean;
  selectedNode: boolean;
  done: boolean;
}
