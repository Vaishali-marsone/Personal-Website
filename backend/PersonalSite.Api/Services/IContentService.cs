using PersonalSite.Api.Models;

namespace PersonalSite.Api.Services;

public interface IContentService
{
    SiteContentDto GetSiteContent();
    ProfileDto GetProfile();
    IReadOnlyList<EducationDto> GetEducation();
    IReadOnlyList<ExperienceDto> GetExperiences();
    IReadOnlyList<AchievementDto> GetAchievements();
    IReadOnlyList<SkillDto> GetSkills();
    bool SubmitContact(ContactMessageDto message);
    IReadOnlyList<ContactMessageSummary> GetContactMessages();
    string? GetContactMessage(string fileName);
}
