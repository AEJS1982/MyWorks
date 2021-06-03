import { debugOutputAstAsTypeScript } from '@angular/compiler';
import { Component } from '@angular/core';
import { Person } from './entities/person';
import { currentState } from './store/state';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'AgendaAngular';
  
}
