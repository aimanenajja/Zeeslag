import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faPlay, faStop } from '@fortawesome/free-solid-svg-icons';
import { GameInfo } from '../_models/game-info.model';
import { GameService } from '../_services/game.service';

@Component({
  templateUrl: 'lobby.component.html',
  styleUrls: ['./lobby.component.scss'],
})
export class LobbyComponent implements OnInit {
  faPlay = faPlay;
  faStop = faStop;
  error = '';
  loading = false;
  gameInfo: GameInfo;

  constructor(private gameService: GameService, private router: Router) {}

  ngOnInit() {
    this.gameService.gameInfo$.subscribe((x) => (this.gameInfo = x));
  }

  playGame() {
    this.loading = true;
    this.gameService.createNewSinglePlayerGame().subscribe(
      () => this.router.navigate(['/game']),
      (error) => {
        this.error = error;
        this.loading = false;
      }
    );
  }

  endGame() {
    this.gameService.endGame();
  }
}
