import { GridCoordinate } from './grid-coordinate.model';
import { ShipKind } from './ship-kind.model';

export interface ShipInfo {
  coordinates: GridCoordinate[];
  kind: ShipKind;
  hasSunk: boolean;
}
