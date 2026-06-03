import { Component, input, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Skill } from '../../core/models/site-content.model';

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './skills.component.html',
  styleUrl: './skills.component.scss'
})
export class SkillsComponent implements OnInit {
  readonly items = input.required<Skill[]>();
  readonly animated = signal(false);

  ngOnInit(): void {
    const observer = new IntersectionObserver(
      ([entry]) => {
        if (entry.isIntersecting) {
          this.animated.set(true);
          observer.disconnect();
        }
      },
      { threshold: 0.2 }
    );
    const el = document.getElementById('skills');
    if (el) observer.observe(el);
  }
}
