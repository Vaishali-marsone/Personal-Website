export interface Profile {
  fullName: string;
  title: string;
  tagline: string;
  bio: string;
  aboutHighlights: string[];
  focusAreas: string[];
  languages: string[];
  email: string;
  phone: string;
  location: string;
  avatarUrl: string;
  resumeUrl: string;
  resumeDownloadName: string;
  socialLinks: string[];
}

export interface Education {
  id: number;
  institution: string;
  degree: string;
  field: string;
  startYear: string;
  endYear: string;
  grade: string;
  description: string;
  highlights: string[];
}

export interface Experience {
  id: number;
  company: string;
  role: string;
  location: string;
  startDate: string;
  endDate: string;
  isCurrent: boolean;
  description: string;
  technologies: string[];
  achievements: string[];
}

export interface Achievement {
  id: number;
  title: string;
  category: string;
  year: string;
  organization: string;
  description: string;
  icon: string;
}

export interface Skill {
  name: string;
  level: number;
  category: string;
}

export interface SiteContent {
  profile: Profile;
  education: Education[];
  experiences: Experience[];
  achievements: Achievement[];
  skills: Skill[];
}

export interface ContactMessage {
  name: string;
  email: string;
  subject: string;
  message: string;
}
