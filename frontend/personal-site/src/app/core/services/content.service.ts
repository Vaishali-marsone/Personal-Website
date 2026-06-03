import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ContactMessage, SiteContent } from '../models/site-content.model';

@Injectable({ providedIn: 'root' })
export class ContentService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = environment.apiUrl;

  getSiteContent(): Observable<SiteContent> {
    return this.http.get<SiteContent>(`${this.baseUrl}/content`);
  }

  submitContact(message: ContactMessage): Observable<{ success: boolean; message: string }> {
    return this.http.post<{ success: boolean; message: string }>(
      `${this.baseUrl}/content/contact`,
      message
    );
  }
}
