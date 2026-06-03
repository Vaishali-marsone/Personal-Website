import { Component, computed, input, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Achievement } from '../../core/models/site-content.model';

const ICONS: Record<string, string> = {
  cloud: '☁️',
  award: '🏆',
  mic: '🎤',
  code: '💻',
  patent: '📜',
  trophy: '🥇'
};

@Component({
  selector: 'app-achievements',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './achievements.component.html',
  styleUrl: './achievements.component.scss'
})
export class AchievementsComponent {
  readonly items = input.required<Achievement[]>();
  readonly filter = signal<string>('All');

  readonly categories = computed(() => {
    const cats = new Set(this.items().map((a) => a.category));
    return ['All', ...cats];
  });

  readonly filtered = computed(() => {
    const f = this.filter();
    if (f === 'All') return this.items();
    return this.items().filter((a) => a.category === f);
  });

  readonly flippedId = signal<number | null>(null);

  setFilter(cat: string): void {
    this.filter.set(cat);
  }

  toggleFlip(id: number): void {
    this.flippedId.update((c) => (c === id ? null : id));
  }

  icon(key: string): string {
    return ICONS[key] ?? '✨';
  }
}
