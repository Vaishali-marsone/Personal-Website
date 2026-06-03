import { Component, computed, effect, input, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Experience } from '../../core/models/site-content.model';

@Component({
  selector: 'app-experience',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './experience.component.html',
  styleUrl: './experience.component.scss'
})
export class ExperienceComponent {
  readonly items = input.required<Experience[]>();
  readonly selectedId = signal<number | null>(null);

  /** Newest / current roles first (Atharva on top). */
  readonly sortedItems = computed(() => {
    const list = [...this.items()];
    return list.sort((a, b) => {
      if (a.isCurrent !== b.isCurrent) return a.isCurrent ? -1 : 1;
      return a.id - b.id;
    });
  });

  readonly selected = computed(() => {
    const id = this.selectedId();
    const list = this.sortedItems();
    if (id !== null) return list.find((e) => e.id === id) ?? list[0];
    return list[0] ?? null;
  });

  constructor() {
    effect(() => {
      const list = this.sortedItems();
      if (list.length === 0) return;
      const current = list.find((e) => e.isCurrent) ?? list[0];
      if (this.selectedId() === null || !list.some((e) => e.id === this.selectedId())) {
        this.selectedId.set(current.id);
      }
    });
  }

  select(id: number): void {
    this.selectedId.set(id);
  }
}
