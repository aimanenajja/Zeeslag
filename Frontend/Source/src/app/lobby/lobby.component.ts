import { Component, OnInit } from '@angular/core';
import { faPlay } from '@fortawesome/free-solid-svg-icons';
import { GameService } from '../_services/game.service';

@Component({
  templateUrl: 'lobby.component.html',
  styleUrls: ['./lobby.component.scss'],
})
export class LobbyComponent implements OnInit {
  faPlay = faPlay;

  constructor(private gameService: GameService) {}

  ngOnInit() {}

  playGame() {
    this.gameService.createNewSinglePlayerGame({} as any);
  }
}
