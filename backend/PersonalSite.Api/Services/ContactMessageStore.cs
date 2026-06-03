using PersonalSite.Api.Models;

namespace PersonalSite.Api.Services;

/// <summary>
/// Saves contact form submissions to files under contact-messages/ in the API project folder.
/// </summary>
public class ContactMessageStore(IWebHostEnvironment environment)
{
    private string MessagesFolder =>
        Path.Combine(environment.ContentRootPath, "contact-messages");

    public bool Save(ContactMessageDto message)
    {
        if (string.IsNullOrWhiteSpace(message.Name) ||
            string.IsNullOrWhiteSpace(message.Email) ||
            string.IsNullOrWhiteSpace(message.Message))
        {
            return false;
        }

        var subject = string.IsNullOrWhiteSpace(message.Subject) ? "(no subject)" : message.Subject.Trim();
        var timestamp = DateTime.Now;
        var logLine = $"""
            Received: {timestamp:yyyy-MM-dd HH:mm:ss}
            From: {message.Name}
            Email: {message.Email}
            Subject: {subject}

            Message:
            {message.Message.Trim()}

            ---

            """;

        Directory.CreateDirectory(MessagesFolder);

        var fileName = $"message-{timestamp:yyyyMMdd-HHmmss}.txt";
        var filePath = Path.Combine(MessagesFolder, fileName);
        File.WriteAllText(filePath, logLine);

        var masterLog = Path.Combine(MessagesFolder, "all-messages.txt");
        File.AppendAllText(masterLog, logLine);

        Console.WriteLine($"[Contact] Saved to {filePath}");
        return true;
    }

    public IReadOnlyList<ContactMessageSummary> List()
    {
        if (!Directory.Exists(MessagesFolder))
            return [];

        return Directory.GetFiles(MessagesFolder, "message-*.txt")
            .OrderByDescending(File.GetCreationTime)
            .Select(path => new ContactMessageSummary(
                FileName: Path.GetFileName(path),
                ReceivedAt: File.GetCreationTime(path),
                Preview: File.ReadLines(path).Take(4).Aggregate((a, b) => a + " | " + b)))
            .ToList();
    }

    public string? Read(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName) || fileName.Contains(".."))
            return null;

        var path = Path.Combine(MessagesFolder, fileName);
        return File.Exists(path) ? File.ReadAllText(path) : null;
    }
}

public record ContactMessageSummary(string FileName, DateTime ReceivedAt, string Preview);
