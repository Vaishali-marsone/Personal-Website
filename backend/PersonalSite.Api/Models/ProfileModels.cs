namespace PersonalSite.Api.Models;

public record ProfileDto(
    string FullName,
    string Title,
    string Tagline,
    string Bio,
    IReadOnlyList<string> AboutHighlights,
    IReadOnlyList<string> FocusAreas,
    IReadOnlyList<string> Languages,
    string Email,
    string Phone,
    string Location,
    string AvatarUrl,
    string ResumeUrl,
    string ResumeDownloadName,
    IReadOnlyList<string> SocialLinks
);

public record EducationDto(
    int Id,
    string Institution,
    string Degree,
    string Field,
    string StartYear,
    string EndYear,
    string Grade,
    string Description,
    IReadOnlyList<string> Highlights
);

public record ExperienceDto(
    int Id,
    string Company,
    string Role,
    string Location,
    string StartDate,
    string EndDate,
    bool IsCurrent,
    string Description,
    IReadOnlyList<string> Technologies,
    IReadOnlyList<string> Achievements
);

public record AchievementDto(
    int Id,
    string Title,
    string Category,
    string Year,
    string Organization,
    string Description,
    string Icon
);

public record SkillDto(
    string Name,
    int Level,
    string Category
);

public record ContactMessageDto(string Name, string Email, string Subject, string Message);

public record SiteContentDto(
    ProfileDto Profile,
    IReadOnlyList<EducationDto> Education,
    IReadOnlyList<ExperienceDto> Experiences,
    IReadOnlyList<AchievementDto> Achievements,
    IReadOnlyList<SkillDto> Skills
);
