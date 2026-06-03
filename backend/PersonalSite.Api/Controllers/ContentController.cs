using Microsoft.AspNetCore.Mvc;
using PersonalSite.Api.Models;
using PersonalSite.Api.Services;

namespace PersonalSite.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContentController(
    IContentService contentService,
    IWebHostEnvironment environment) : ControllerBase
{
    [HttpGet]
    public ActionResult<SiteContentDto> GetAll() => Ok(contentService.GetSiteContent());

    [HttpGet("profile")]
    public ActionResult<ProfileDto> GetProfile() => Ok(contentService.GetProfile());

    [HttpGet("education")]
    public ActionResult<IReadOnlyList<EducationDto>> GetEducation() => Ok(contentService.GetEducation());

    [HttpGet("experiences")]
    public ActionResult<IReadOnlyList<ExperienceDto>> GetExperiences() => Ok(contentService.GetExperiences());

    [HttpGet("achievements")]
    public ActionResult<IReadOnlyList<AchievementDto>> GetAchievements() => Ok(contentService.GetAchievements());

    [HttpGet("skills")]
    public ActionResult<IReadOnlyList<SkillDto>> GetSkills() => Ok(contentService.GetSkills());

    [HttpPost("contact")]
    public IActionResult SubmitContact([FromBody] ContactMessageDto? message)
    {
        if (message is null)
            return BadRequest(new { success = false, message = "Invalid request body." });

        if (!contentService.SubmitContact(message))
            return BadRequest(new { success = false, message = "Name, email, and message are required." });

        return Ok(new
        {
            success = true,
            message = "Thank you! Your message has been received.",
            hint = environment.IsDevelopment()
                ? "View messages at GET /api/content/messages (development only)"
                : null
        });
    }

    /// <summary>Development only — list saved contact form messages.</summary>
    [HttpGet("messages")]
    public IActionResult ListMessages()
    {
        if (!environment.IsDevelopment())
            return NotFound();

        var messages = contentService.GetContactMessages();
        return Ok(new
        {
            count = messages.Count,
            folder = "backend/PersonalSite.Api/contact-messages/",
            messages
        });
    }

    /// <summary>Development only — read one message file by name.</summary>
    [HttpGet("messages/{fileName}")]
    public IActionResult ReadMessage(string fileName)
    {
        if (!environment.IsDevelopment())
            return NotFound();

        var body = contentService.GetContactMessage(fileName);
        if (body is null)
            return NotFound();

        return Ok(new { fileName, body });
    }
}
