import { Component, OnInit } from '@angular/core';
import { GameInfo } from '../_models/game-info.model';
import { GameService } from '../_services/game.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss'],
})
export class GameComponent implements OnInit {
  gameInfo: GameInfo;

  constructor(private gameService: GameService) {}

  ngOnInit(): void {
    this.gameService.gameInfo$.subscribe((x) => (this.gameInfo = x));
  }
}
