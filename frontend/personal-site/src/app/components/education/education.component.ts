import { Component, input, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Education } from '../../core/models/site-content.model';

@Component({
  selector: 'app-education',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './education.component.html',
  styleUrl: './education.component.scss'
})
export class EducationComponent {
  readonly items = input.required<Education[]>();
  readonly expandedId = signal<number | null>(null);

  toggle(id: number): void {
    this.expandedId.update((current) => (current === id ? null : id));
  }
}
