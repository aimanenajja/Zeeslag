import { GridSquareStatus } from './grid-square-status.enum';

export interface GridSquareInfo {
  status: GridSquareStatus;
  numberOfBombs: number;
}
