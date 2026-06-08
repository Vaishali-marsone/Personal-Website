using PersonalSite.Api.Models;

namespace PersonalSite.Api.Services;

/// <summary>
/// Portfolio content for Vaishali Marsone.
/// </summary>
public class SampleContentService(ContactMessageStore contactStore) : IContentService
{
    private static readonly ProfileDto Profile = new(
        FullName: "Vaishali Marsone",
        Title: ".NET Developer | 3+ Years · ASP.NET Core · REST APIs · Azure (AZ-900)",
        Tagline: "Software Developer at Atharva Infotech · 3+ years building enterprise .NET solutions.",
        Bio: """
            I am an aspiring technologist and .NET developer from Pune with hands-on experience across
            Atharva Infotech, SoftLink International, and industry internships. I focus on translating
            business needs into clean, testable code using modern Microsoft stack practices.
            """,
        AboutHighlights: [
            "Current Software Developer at Atharva Infotech Pvt. Ltd. (Feb 2026 – Present), delivering .NET-based solutions in a collaborative engineering environment",
            "3+ years of professional experience with C#, ASP.NET MVC/Core, REST APIs, and SQL Server",
            "Microsoft Certified: Azure Fundamentals (AZ-900) with practical cloud learning via TechSaksham & AWS Cloud Quest",
            "B.Tech in Information Technology (CGPA 8.59) with a CNN-based capstone on crop disease detection",
            "Strong foundation from diploma in Computer Engineering (92.91%) and consistent academic performance",
            "Fluent in English, Hindi, and Marathi — comfortable working with cross-functional teams"
        ],
        FocusAreas: [
            "C# & .NET Core",
            "ASP.NET MVC",
            "RESTful Web API",
            "Entity Framework",
            "SQL Server",
            "LINQ & ADO.NET",
            "Angular",
            "Microsoft Azure",
            "OOP & SDLC"
        ],
        Languages: ["English", "Hindi", "Marathi"],
        Email: "vaishalimarsone7@gmail.com",
        Phone: "+91 9356553353",
        Location: "Pune District, Maharashtra, India",
        AvatarUrl: "https://unavatar.io/linkedin/vaishali-marsone",
        ResumeUrl: "/resumes/resume.pdf",
        ResumeDownloadName: "Vaishali-Marsone-Resume.pdf",
        SocialLinks: [
            "https://in.linkedin.com/in/vaishali-marsone"
        ]
    );

    private static readonly IReadOnlyList<EducationDto> Education =
    [
        new(1,
            "Government College of Engineering, Aurangabad (Chh. Sambhajinagar)",
            "Bachelor of Technology",
            "Information Technology",
            "2020", "2023", "CGPA 8.593 / 10",
            """
            Studied cloud computing (Microsoft Azure), AI/deep learning, and full-stack development.
            Completed internships at Exposys Data Labs and Globus Info Technology.
            """,
            [
                "Final-year project: Pomegranate Fruit Disease Detection System (CNN)",
                "TechSaksham — Microsoft Azure program (Microsoft, SAP, Edunet Foundation)",
                "Tools: Visual Studio, VS Code, Android Studio, MATLAB"
            ]),
        new(2,
            "Government Residential Women's Polytechnic College, Latur",
            "Diploma",
            "Computer Engineering",
            "2017", "2020", "92.91%",
            """
            Core CS subjects including OS, networks, DSA, software engineering, and DBMS.
            Practical programming in C, C++, Java, and Python.
            """,
            [
                "6 weeks industrial training",
                "Capstone: Online Examination System (HTML, CSS, JavaScript, SQL, PHP)"
            ]),
        new(3,
            "Shri Sai Primary and Secondary High School, Latur",
            "SSC",
            "MSHSE",
            "2009", "2017", "91.20%",
            "Completed primary and secondary education with a strong academic base.",
            ["Foundation for diploma and engineering pursuits"])
    ];

    private static readonly IReadOnlyList<ExperienceDto> Experiences =
    [
        new(1,
            "Atharva Infotech Pvt. Ltd.",
            "Software Developer",
            "Pune, Maharashtra, India",
            "Feb 2026", "Present", true,
            """
            Latest professional engagement building and supporting .NET applications, RESTful services,
            and database-backed features. Working closely with team members on requirements, development,
            testing, and delivery in an agile product environment.
            """,
            ["C#", "ASP.NET Core", "ASP.NET MVC", "RESTful Web API", "SQL Server", "Entity Framework", "LINQ", "ADO.NET", "JavaScript", "Git"],
            [
                "Contributing to enterprise .NET solutions and API integrations",
                "Implementing data access layers with Entity Framework and SQL Server",
                "Collaborating on code quality, debugging, and feature enhancements",
                "Applying OOP principles and SDLC best practices in day-to-day development"
            ]),
        new(2,
            "SoftLink International",
            "Software Engineer",
            "Pune, Maharashtra, India",
            "Jan 2024", "Jan 2026", false,
            """
            Software development for enterprise solutions at a Pune-based company serving clients
            across multiple countries. Delivered .NET applications, APIs, and database-driven modules.
            """,
            ["C#", "ASP.NET MVC", "ASP.NET Core", ".NET", "RESTful Web API", "SQL Server", "Entity Framework", "LINQ", "ADO.NET"],
            [
                "Promoted from trainee to software engineer within the organization",
                "Built and maintained RESTful services and application layers",
                "Worked with SQL Server and ORM patterns for production data access"
            ]),
        new(3,
            "SoftLink International",
            "Trainee Software Engineer",
            "Pune, Maharashtra, India",
            "Jul 2023", "Dec 2023", false,
            """
            Entry-level role focused on .NET fundamentals, production workflows, and team-based
            software delivery after completing B.Tech.
            """,
            ["C#", "ASP.NET", "SQL", "Visual Studio", "Git"],
            [
                "Onboarded to engineering standards and codebase practices",
                "Supported development and testing under senior mentorship"
            ]),
        new(4,
            "Exposys Data Labs",
            "Web Development Intern",
            "Bangalore (Remote)",
            "2022", "2022", false,
            "Web development internship with hands-on project delivery.",
            ["HTML", "CSS", "JavaScript", "Web Development"],
            ["Completed internship as web developer"]),
        new(5,
            "Globus Info Technology",
            "Intern",
            "India",
            "2022", "2022", false,
            "Internship via TechSaksham alongside Microsoft Azure ecosystem learning.",
            ["Microsoft Azure", "Software Development"],
            ["Completed TechSaksham internship (Microsoft, SAP, Edunet Foundation)"])
    ];

    private static readonly IReadOnlyList<AchievementDto> Achievements =
    [
        new(1, "Microsoft Certified: Azure Fundamentals (AZ-900)", "Certification", "2025", "Microsoft",
            "Cloud concepts, Azure services, security, governance, and cost optimization.",
            "cloud"),
        new(2, "Mastering Data Structures & Algorithms (C/C++)", "Certification", "2023", "Udemy (Abdul Bari)",
            "Strengthened DSA fundamentals in C and C++.",
            "code"),
        new(3, "AWS Cloud Quest: Cloud Practitioner", "Certification", "2023", "Amazon Web Services",
            "12 hands-on AWS cloud assignments and scenarios.",
            "cloud"),
        new(4, "Virtual Engineering Program", "Certification", "2022", "Goldman Sachs (Forage)",
            "Completed virtual engineering program.",
            "award"),
        new(5, "B.Tech Capstone — Pomegranate Disease Detection (CNN)", "Project", "2023", "GEC Aurangabad",
            "CNN-based disease detection for pomegranate fruit.",
            "trophy"),
        new(6, "Infosys Springboard — HTML5 & CSS3", "Certification", "2022", "Infosys Springboard",
            "Foundational front-end web courses.",
            "code")
    ];

    private static readonly IReadOnlyList<SkillDto> Skills =
    [
        new("C# / .NET / ASP.NET Core", 95, "Backend"),
        new("ASP.NET MVC & RESTful Web API", 92, "Backend"),
        new("Entity Framework / LINQ / ADO.NET", 88, "Data"),
        new("SQL Server", 90, "Data"),
        new("Object-Oriented Programming (OOP)", 91, "Fundamentals"),
        new("Angular / JavaScript / HTML / CSS", 85, "Frontend"),
        new("Microsoft Azure (AZ-900)", 75, "Cloud"),
        new("Data Structures & Algorithms", 72, "Fundamentals"),
        new("Python / Java / C++", 70, "Languages")
    ];

    public SiteContentDto GetSiteContent() => new(Profile, Education, Experiences, Achievements, Skills);

    public ProfileDto GetProfile() => Profile;

    public IReadOnlyList<EducationDto> GetEducation() => Education;

    public IReadOnlyList<ExperienceDto> GetExperiences() => Experiences;

    public IReadOnlyList<AchievementDto> GetAchievements() => Achievements;

    public IReadOnlyList<SkillDto> GetSkills() => Skills;

    public bool SubmitContact(ContactMessageDto message) => contactStore.Save(message);

    public IReadOnlyList<ContactMessageSummary> GetContactMessages() => contactStore.List();

    public string? GetContactMessage(string fileName) => contactStore.Read(fileName);
}
