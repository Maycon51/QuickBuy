import { Component } from '@angular/core';

@Component({
  selector: 'app-root',// a partir dessa tag que me uapp vai ser reenderizado
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']//folha estilo
})
export class AppComponent {
  title = 'app';
}
