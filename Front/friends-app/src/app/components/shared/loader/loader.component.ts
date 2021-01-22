import { Component } from '@angular/core';
import { faSpinner } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html'
})
export class LoaderComponent {
  faSpinner = faSpinner;
}
