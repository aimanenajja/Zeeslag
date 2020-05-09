import { GridCoordinate } from './grid-coordinate.model';

export interface ShipPositioning {
  shipCode: string;
  segmentCoordinates: GridCoordinate[];
}
