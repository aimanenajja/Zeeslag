import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { GameInfo } from '../_models/game-info.model';
import { GameSettings } from '../_models/game-settings.model';

@Injectable({ providedIn: 'root' })
export class GameService {
  constructor(private http: HttpClient) {}

  createNewSinglePlayerGame(gameSettings: GameSettings): Observable<GameInfo> {
    return this.http.post<GameInfo>(`${environment.apiUrl}/Games`, gameSettings);
  }
}
