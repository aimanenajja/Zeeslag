import { KeyValue } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { GameSettings } from '../_models/game-settings.model';
import { GameService } from '../_services/game.service';

@Component({ templateUrl: './game-settings.component.html' })
export class GameSettingsComponent implements OnInit {
  gameSettingsForm: FormGroup;
  submitted = false;
  error = '';
  loading = false;
  gameModes = {
    1: 'One shot per turn',
    2: 'Five shots per turn',
    3: 'Size of biggest undamaged ship as number of shots per turn',
    4: 'Number of remaining ships as number of shots per turn',
  };
  selectedGameMode = 'Choose a Game Mode..';

  constructor(private formBuilder: FormBuilder, private router: Router, private gameService: GameService) {}

  ngOnInit() {
    this.gameSettingsForm = this.formBuilder.group({
      gridSize: [null, [Validators.min(10), Validators.max(15), Validators.required]],
      allowDeformedShips: false,
      mode: [null, Validators.required],
      mustReportSunkenShip: false,
      canMoveUndamagedShipsDuringGame: false,
      numberOfTurnsBeforeAShipCanBeMoved: [null, [Validators.min(1), Validators.max(10), Validators.required]],
    });
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.gameSettingsForm.controls;
  }

  changeGameMode(gameMode: KeyValue<number, string>) {
    this.gameSettingsForm.get('mode').setValue(gameMode.key);
    this.selectedGameMode = gameMode.value;
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.gameSettingsForm.invalid) {
      return;
    }

    const gameSettings: GameSettings = {
      ...this.gameSettingsForm.value,
      gridSize: +this.gameSettingsForm.get('gridSize').value,
      mode: +this.gameSettingsForm.get('mode').value,
      numberOfTurnsBeforeAShipCanBeMoved: +this.gameSettingsForm.get('numberOfTurnsBeforeAShipCanBeMoved').value,
    };

    this.loading = true;
    this.gameService.saveGameSettings(gameSettings).subscribe(
      () => this.router.navigate(['/lobby']),
      (error) => {
        this.error = error;
        this.loading = false;
      }
    );
  }
}
