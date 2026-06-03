import { Component, HostListener, inject, input, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Profile } from '../../core/models/site-content.model';
import { ThemeService } from '../../core/services/theme.service';

const NAV = [
  { id: 'home', label: 'Home' },
  { id: 'about', label: 'About' },
  { id: 'education', label: 'Education' },
  { id: 'experience', label: 'Experience' },
  { id: 'achievements', label: 'Achievements' },
  { id: 'skills', label: 'Skills' },
  { id: 'contact', label: 'Contact' }
];

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  readonly profile = input.required<Profile>();
  readonly theme = inject(ThemeService);
  readonly navItems = NAV;
  readonly menuOpen = signal(false);
  readonly activeSection = signal('home');
  readonly scrolled = signal(false);

  @HostListener('window:scroll')
  onScroll(): void {
    this.scrolled.set(window.scrollY > 40);
    const sections = NAV.map((n) => n.id);
    for (const id of [...sections].reverse()) {
      const el = document.getElementById(id);
      if (el && el.getBoundingClientRect().top <= 120) {
        this.activeSection.set(id);
        break;
      }
    }
  }

  scrollTo(id: string): void {
    document.getElementById(id)?.scrollIntoView({ behavior: 'smooth' });
    this.menuOpen.set(false);
  }

  toggleMenu(): void {
    this.menuOpen.update((v) => !v);
  }
}
