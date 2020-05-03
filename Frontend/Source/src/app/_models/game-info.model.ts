import { GridInfo } from './grid-info.model';
import { ShipInfo } from './ship-info.model';

export interface GameInfo {
  id: string;
  isReadyToStart: boolean;
  hasBombsLoaded: boolean;
  ownGrid: GridInfo;
  ownShips: ShipInfo[];
  opponentGrid: GridInfo;
  sunkenOpponentShips: ShipInfo[];
}
