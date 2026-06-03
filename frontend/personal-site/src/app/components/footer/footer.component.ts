import { Component, input } from '@angular/core';
import { Profile } from '../../core/models/site-content.model';

@Component({
  selector: 'app-footer',
  standalone: true,
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.scss'
})
export class FooterComponent {
  readonly profile = input.required<Profile>();
  readonly year = new Date().getFullYear();

  scrollTop(): void {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
}
