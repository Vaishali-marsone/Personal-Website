import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentService } from './core/services/content.service';
import { ThemeService } from './core/services/theme.service';
import { SiteContent } from './core/models/site-content.model';
import { HeaderComponent } from './components/header/header.component';
import { HeroComponent } from './components/hero/hero.component';
import { AboutComponent } from './components/about/about.component';
import { EducationComponent } from './components/education/education.component';
import { ExperienceComponent } from './components/experience/experience.component';
import { AchievementsComponent } from './components/achievements/achievements.component';
import { SkillsComponent } from './components/skills/skills.component';
import { ContactComponent } from './components/contact/contact.component';
import { FooterComponent } from './components/footer/footer.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    HeroComponent,
    AboutComponent,
    EducationComponent,
    ExperienceComponent,
    AchievementsComponent,
    SkillsComponent,
    ContactComponent,
    FooterComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  private readonly contentService = inject(ContentService);
  private readonly themeService = inject(ThemeService);

  readonly content = signal<SiteContent | null>(null);
  readonly loading = signal(true);
  readonly error = signal<string | null>(null);

  ngOnInit(): void {
    this.themeService.init();
    this.contentService.getSiteContent().subscribe({
      next: (data) => {
        this.content.set(data);
        this.loading.set(false);
      },
      error: () => {
        this.error.set('Could not load portfolio data. Is the API running on http://localhost:5155?');
        this.loading.set(false);
      }
    });
  }
}
