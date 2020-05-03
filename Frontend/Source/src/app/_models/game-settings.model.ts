import { GameMode } from './game-mode.enum';

export interface GameSettings {
  gridSize: number;
  allowDeformedShips: boolean;
  mode: GameMode;
  mustReportSunkenShip: boolean;
  canMoveUndamagedShipsDuringGame: boolean;
  numberOfTurnsBeforeAShipCanBeMoved: number;
}
