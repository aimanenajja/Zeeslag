import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { GameInfo } from '../_models/game-info.model';
import { GameSettings } from '../_models/game-settings.model';

@Injectable({ providedIn: 'root' })
export class GameService {
  private gameSettingsSubject: BehaviorSubject<GameSettings>;
  public gameSettings$: Observable<GameSettings>;
  private gameInfoSubject: BehaviorSubject<GameInfo>;
  public gameInfo$: Observable<GameInfo>;

  constructor(private http: HttpClient) {
    this.gameSettingsSubject = new BehaviorSubject<GameSettings>(JSON.parse(localStorage.getItem('gameSettings')));
    this.gameSettings$ = this.gameSettingsSubject.asObservable();
    this.gameInfoSubject = new BehaviorSubject<GameInfo>(JSON.parse(localStorage.getItem('gameInfo')));
    this.gameInfo$ = this.gameInfoSubject.asObservable();
  }

  public get gameSettings(): GameSettings {
    return this.gameSettingsSubject.value;
  }

  public get gameInfo(): GameInfo {
    return this.gameInfoSubject.value;
  }

  saveGameSettings(gameSettings: GameSettings): Observable<GameSettings> {
    localStorage.setItem('gameSettings', JSON.stringify(gameSettings));
    this.gameSettingsSubject.next(gameSettings);
    return this.gameSettings$;
  }

  createNewSinglePlayerGame(): Observable<GameInfo> {
    return this.http.post<GameInfo>(`${environment.apiUrl}/Games`, this.gameSettings ?? {}).pipe(
      map((gameInfo) => {
        localStorage.setItem('gameInfo', JSON.stringify(gameInfo));
        this.gameInfoSubject.next(gameInfo);
        return gameInfo;
      })
    );
  }

  endGame() {
    localStorage.removeItem('gameInfo');
    this.gameInfoSubject.next(null);
  }
}
