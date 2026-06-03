import { Component, input, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Profile } from '../../core/models/site-content.model';

@Component({
  selector: 'app-hero',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './hero.component.html',
  styleUrl: './hero.component.scss'
})
export class HeroComponent implements OnInit {
  readonly profile = input.required<Profile>();
  readonly typedTagline = signal('');
  readonly avatarSrc = signal('');

  ngOnInit(): void {
    this.avatarSrc.set(this.profile().avatarUrl);
    this.typeWriter(this.profile().tagline, 0);
  }

  onAvatarError(): void {
    this.avatarSrc.set(
      'https://api.dicebear.com/7.x/avataaars/svg?seed=VaishaliMarsone&backgroundColor=c4b5fd'
    );
  }

  scrollTo(id: string): void {
    document.getElementById(id)?.scrollIntoView({ behavior: 'smooth' });
  }

  private typeWriter(text: string, i: number): void {
    if (i < text.length) {
      this.typedTagline.set(text.slice(0, i + 1));
      setTimeout(() => this.typeWriter(text, i + 1), 35);
    }
  }
}
