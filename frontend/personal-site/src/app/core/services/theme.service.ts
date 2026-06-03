import { Injectable, signal } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ThemeService {
  readonly isDark = signal(this.readStoredTheme());

  toggle(): void {
    this.isDark.update((v) => !v);
    this.apply();
  }

  apply(): void {
    const dark = this.isDark();
    document.documentElement.setAttribute('data-theme', dark ? 'dark' : 'light');
    localStorage.setItem('portfolio-theme', dark ? 'dark' : 'light');
  }

  init(): void {
    this.apply();
  }

  private readStoredTheme(): boolean {
    const stored = localStorage.getItem('portfolio-theme');
    if (stored) return stored === 'dark';
    return window.matchMedia('(prefers-color-scheme: dark)').matches;
  }
}
