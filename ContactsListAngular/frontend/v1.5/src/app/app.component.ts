import { debugOutputAstAsTypeScript } from '@angular/compiler';
import { Component } from '@angular/core';
import { Contact } from './entities/Contact';
import { currentState } from './store/state';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'AgendaAngular';
  
}
