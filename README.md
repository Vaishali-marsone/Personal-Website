# Personal Portfolio Site

Interactive, adaptive personal website built with **Angular 19** (frontend) and **.NET 9 Web API** (backend).

Sample profile data uses **Emily Chen** (fictional). Replace your details in `backend/PersonalSite.Api/Services/SampleContentService.cs`.

## Features

- **Adaptive UI** — responsive layout, mobile nav, fluid typography
- **Dark / light theme** — persisted in `localStorage`, respects system preference
- **Education timeline** — expandable cards with highlights
- **Experience tabs** — switch roles interactively
- **Achievements** — category filters + flip cards
- **Animated skill bars** — animate on scroll into view
- **Contact form** — posts to API (`/api/content/contact`)
- **Hero typing effect** — animated tagline

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Node.js 20+](https://nodejs.org/) with **npm** (required for Angular; install separately if using Cursor’s bundled Node only)

## Quick start

### 1. Backend API

```powershell
cd backend/PersonalSite.Api
dotnet run
```

API: `http://localhost:5155`  
Swagger (dev): `http://localhost:5155/openapi/v1.json`

### 2. Frontend

```powershell
cd frontend/personal-site
npm install
npm start
```

App: `http://localhost:4200`

The dev server proxies `/api` to the backend via `proxy.conf.json`.

## Customize your data

Edit `backend/PersonalSite.Api/Services/SampleContentService.cs`:

| Section | What to change |
|---------|----------------|
| `Profile` | Name, title, bio, email, avatar URL |
| `Education` | Degrees, schools, years |
| `Experiences` | Jobs, tech stack, bullets |
| `Achievements` | Certifications, awards, speaking |
| `Skills` | Name, level (0–100), category |

For a real avatar, replace `AvatarUrl` with your image path or upload to `wwwroot` and serve statically.

## API endpoints

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/content` | Full site payload |
| GET | `/api/content/profile` | Profile only |
| GET | `/api/content/education` | Education list |
| GET | `/api/content/experiences` | Work history |
| GET | `/api/content/achievements` | Achievements |
| GET | `/api/content/skills` | Skills |
| POST | `/api/content/contact` | Contact form |

## Suggested next steps

1. **Database** — move content to SQL Server / PostgreSQL with EF Core
2. **Admin panel** — CRUD UI to edit sections without redeploying
3. **Email** — wire contact form to SendGrid / SMTP
4. **Deploy** — API to Azure App Service, frontend to Azure Static Web Apps or nginx
5. **PDF resume** — add download button linking to `wwwroot/resume.pdf`
6. **i18n** — Angular `@angular/localize` for multiple languages
7. **Analytics** — privacy-friendly Plausible or Application Insights

## Project structure

```
PersonalSite/
├── backend/PersonalSite.Api/    # .NET Web API
├── frontend/personal-site/        # Angular SPA
├── PersonalSite.sln
└── README.md
```

## Production build

```powershell
# API
dotnet publish backend/PersonalSite.Api -c Release -o ./publish/api

# Angular
cd frontend/personal-site
npm run build
# Output: dist/personal-site/
```

Serve the Angular `dist` folder and host the API behind the same domain (or configure CORS in `appsettings.json`).
