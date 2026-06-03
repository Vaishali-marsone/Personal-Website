import { Component, inject, input, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { Profile } from '../../core/models/site-content.model';
import { ContentService } from '../../core/services/content.service';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.scss'
})
export class ContactComponent {
  readonly profile = input.required<Profile>();
  private readonly fb = inject(FormBuilder);
  private readonly contentService = inject(ContentService);

  readonly submitting = signal(false);
  readonly feedback = signal<{ type: 'ok' | 'err'; text: string } | null>(null);

  readonly form = this.fb.nonNullable.group({
    name: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    subject: [''],
    message: ['', [Validators.required, Validators.minLength(10)]]
  });

  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      this.feedback.set({
        type: 'err',
        text: 'Please fix the highlighted fields before sending.'
      });
      return;
    }

    this.submitting.set(true);
    this.feedback.set(null);

    this.contentService.submitContact(this.form.getRawValue()).subscribe({
      next: (res) => {
        this.feedback.set({ type: 'ok', text: res.message });
        this.form.reset({ name: '', email: '', subject: '', message: '' });
        this.submitting.set(false);
      },
      error: (err: HttpErrorResponse) => {
        const serverMsg =
          typeof err.error === 'object' && err.error?.message
            ? err.error.message
            : null;
        const hint =
          err.status === 0
            ? 'Cannot reach the API. Start the backend (dotnet run) and keep npm start running.'
            : serverMsg ?? `Request failed (${err.status}). Please try again.`;
        this.feedback.set({ type: 'err', text: hint });
        this.submitting.set(false);
      }
    });
  }
}
