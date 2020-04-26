import { Component, OnInit } from '@angular/core';
import { Player } from '../_models/player.model';

@Component({
  templateUrl: 'home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  player: Player;

  constructor() {}

  ngOnInit() {
    localStorage.getItem('accessPass');
  }
}
