import { Player } from '../shared/player.model';
import { SelectedChoice } from '../shared/selectedChoice.model';

export class Adventure {
  id: number;
  player: Player;
  startTime: any;
  endTime: any;
  selectedChoices: SelectedChoice[];
}
