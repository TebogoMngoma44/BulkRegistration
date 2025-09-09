namespace Speccon.Learnership.FrontEnd.Models.Qualification
{
    public class QualificationDto
    {
        public int QualificationId { get; set; }
        public Guid QualificationKey { get; set; }
        public string QualificationName { get; set; } = string.Empty;
        public string QualificationDescription { get; set; } = string.Empty;
        public int QualificationTypeId { get; set; }
        public string QualificationCode { get; set; } = string.Empty;
        public int NqfLevel { get; set; }
        public int ClientId { get; set; }
        public string Credits { get; set; } = string.Empty;
        public byte[] RowVersion { get; set; }
        public DateTime CreateDate { get; set; }
        public int RecordStatusId { get; set; }
    }

    public class QualificationCreateDto
    {
        public string QualificationName { get; set; } = string.Empty;
        public string QualificationDescription { get; set; } = string.Empty;
        public int QualificationTypeId { get; set; }
        public string QualificationCode { get; set; } = string.Empty;
        public int NqfLevel { get; set; }
        public int ClientId { get; set; }
        public string Credits { get; set; } = string.Empty;
    }

    public class QualificationUpdateDto
    {
        public int QualificationId { get; set; }
        public Guid QualificationKey { get; set; }
        public string QualificationName { get; set; } = string.Empty;
        public string QualificationDescription { get; set; } = string.Empty;
        public int QualificationTypeId { get; set; }
        public string QualificationCode { get; set; } = string.Empty;
        public int NqfLevel { get; set; }
        public int ClientId { get; set; }
        public string Credits { get; set; } = string.Empty;
    }

    public class QualificationDeleteDto
    {
        public Guid QualificationKey { get; set; }
    }

    //========TINA
    public class Unit
    {
        public string UnitStandard { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ProgressStatus { get; set; } = string.Empty;
    }

    public class Module
    {
        public int ModuleNumber { get; set; }
        public string ModuleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ProgressPercentage { get; set; }
        public string FeedbackStatus { get; set; } = string.Empty;
        public int UnitsCompleted { get; set; }
        public int TotalUnits { get; set; }
        public bool IsLocked { get; set; }
        public bool ShowUnits { get; set; }
        public List<Unit> Units { get; set; } = new List<Unit>();
    }

    // Added missing DTO class
    public class QualificationOptionDto
    {
        public int Id { get; set; }
        public string Value { get; set; } = "";
        public string Label { get; set; } = "";
        public string QualificationName { get; set; } = "";
        public string Description { get; set; } = "";
        public string Status { get; set; } = "";
        public int NQFLevel { get; set; }
        public int Credits { get; set; }
        public string SETA { get; set; } = "";
    }

    public class SetaQualificationModel
    {
        // Added missing Id property
        public int Id { get; set; }

        public string QualificationName { get; set; } = "National Certificate: Business Administration Services";
        public int NQFLevel { get; set; } = 5;
        public string Status { get; set; } = "In Progress";
        public int OverallProgress { get; set; } = 75;
        public int UnitsCompleted { get; set; } = 10;
        public int TotalUnits { get; set; } = 15;
        public int MonthsRemaining { get; set; } = 3;
        public DateTime ExpectedEndDate { get; set; } = new DateTime(2025, 12, 30);
        public string DealNumber { get; set; } = "SPCC-2024-001";
        public string ClientCompany { get; set; } = "ABC Corp";
        public string Facilitator { get; set; } = "Ms. Jane Doe";
        public string ChiefLearningOfficer { get; set; } = "Mr. John Smith";
        public DateTime StartDate { get; set; } = new DateTime(2024, 4, 1);
        public string SETA { get; set; } = "Services SETA";
        public string QualificationCode { get; set; } = "45678";
        public int Credits { get; set; } = 130;
        public int ProgrammeDurationMonths { get; set; } = 18;
        public string WorkplaceMentor { get; set; } = "Ms. Sarah Brown";
        public List<Module> Modules { get; set; } = new List<Module>();

        // Added missing GetSampleQualifications method (made static)
        public static List<QualificationOptionDto> GetSampleQualifications()
        {
            return new List<QualificationOptionDto>
            {
                new QualificationOptionDto
                {
                    Id = 1,
                    Value = "bus-admin-nqf5",
                    Label = "National Certificate: Business Administration Services",
                    QualificationName = "National Certificate: Business Administration Services",
                    Description = "Comprehensive business administration qualification",
                    Status = "In Progress",
                    NQFLevel = 5,
                    Credits = 130,
                    SETA = "Services SETA"
                },
                new QualificationOptionDto
                {
                    Id = 2,
                    Value = "project-mgmt-nqf4",
                    Label = "FET Certificate: Project Management",
                    QualificationName = "FET Certificate: Project Management",
                    Description = "Project management fundamentals and practices",
                    Status = "Completed",
                    NQFLevel = 4,
                    Credits = 140,
                    SETA = "Services SETA"
                },
                new QualificationOptionDto
                {
                    Id = 3,
                    Value = "office-admin-nqf3",
                    Label = "National Certificate: Office Administration",
                    QualificationName = "National Certificate: Office Administration",
                    Description = "Essential office administration skills",
                    Status = "Available",
                    NQFLevel = 3,
                    Credits = 120,
                    SETA = "Services SETA"
                }
              
            };
        }
    }

    public class QualificationOption
    {
        public string Value { get; set; } = "";
        public string Label { get; set; } = "";
    }

    public class QualificationDataService
    {
        public SetaQualificationModel GetQualificationData(string qualificationId)
        {
            if (qualificationId == "qualification2")
            {
                return new SetaQualificationModel
                {
                    Id = 2, // Added Id
                    QualificationName = "FET Certificate: Project Management",
                    NQFLevel = 4,
                    Status = "COMPLETED",
                    OverallProgress = 100,
                    UnitsCompleted = 12,
                    TotalUnits = 12,
                    MonthsRemaining = 0,
                    ExpectedEndDate = new DateTime(2024, 12, 15),
                    DealNumber = "SPCC-2023-005",
                    ClientCompany = "Tech Innovators",
                    Facilitator = "Mr. David Green",
                    ChiefLearningOfficer = "Ms. Emily White",
                    StartDate = new DateTime(2023, 1, 10),
                    SETA = "SETA Name 2",
                    QualificationCode = "98765",
                    Credits = 140,
                    ProgrammeDurationMonths = 12,
                    WorkplaceMentor = "Mr. Alex Blue",
                    Modules = GetProjectManagementModules()
                };
            }

            return new SetaQualificationModel
            {
                Id = 1, // Added Id
                QualificationName = "National Certificate: Business Administration Services",
                NQFLevel = 5,
                Status = "In Progress",
                OverallProgress = 75,
                UnitsCompleted = 10,
                TotalUnits = 15,
                MonthsRemaining = 3,
                ExpectedEndDate = new DateTime(2026, 9, 30),
                DealNumber = "SPCC-2024-001",
                ClientCompany = "ABC Corp",
                Facilitator = "Ms. Jane Doe",
                ChiefLearningOfficer = "Mr. John Smith",
                StartDate = new DateTime(2024, 4, 1),
                SETA = "Services SETA",
                QualificationCode = "45678",
                Credits = 130,
                ProgrammeDurationMonths = 18,
                WorkplaceMentor = "Ms. Sarah Brown",
                Modules = GetBusinessAdminModules()
            };
        }

        private List<Module> GetProjectManagementModules()
        {
            return new List<Module>
            {
                new Module
                {
                    ModuleNumber = 1,
                    ModuleName = "Project Initiation",
                    Description = "Defining project scope and objectives",
                    ProgressPercentage = 100,
                    FeedbackStatus = "View Feedback",
                    UnitsCompleted = 4,
                    TotalUnits = 4,
                    IsLocked = false,
                    ShowUnits = false,
                    Units = new List<Unit>
                    {
                        new Unit { UnitStandard = "PROJ101", UnitName = "Project Charter", Type = "Documentation", ProgressStatus = "Completed" },
                        new Unit { UnitStandard = "PROJ102", UnitName = "Stakeholder Analysis", Type = "Assessment", ProgressStatus = "Completed" },
                        new Unit { UnitStandard = "PROJ103", UnitName = "Scope Definition", Type = "Practical", ProgressStatus = "Completed" },
                    }
                },
                new Module
                {
                    ModuleNumber = 2,
                    ModuleName = "Project Planning",
                    Description = "Developing project plans and schedules",
                    ProgressPercentage = 100,
                    FeedbackStatus = "View Feedback",
                    UnitsCompleted = 5,
                    TotalUnits = 5,
                    IsLocked = false,
                    ShowUnits = false,
                    Units = new List<Unit>
                    {
                        new Unit { UnitStandard = "PROJ201", UnitName = "Work Breakdown Structure", Type = "Practical", ProgressStatus = "Completed" },
                        new Unit { UnitStandard = "PROJ202", UnitName = "Scheduling", Type = "Assessment", ProgressStatus = "Completed" },
                    }
                },
                new Module
                {
                    ModuleNumber = 3,
                    ModuleName = "Project Execution",
                    Description = "Managing project activities and resources",
                    ProgressPercentage = 100,
                    FeedbackStatus = "View Feedback",
                    UnitsCompleted = 3,
                    TotalUnits = 3,
                    IsLocked = false,
                    ShowUnits = false,
                    Units = new List<Unit>
                    {
                        new Unit { UnitStandard = "PROJ301", UnitName = "Team Management", Type = "Observation", ProgressStatus = "Completed" },
                        new Unit { UnitStandard = "PROJ302", UnitName = "Risk Monitoring", Type = "Case Study", ProgressStatus = "Completed" },
                    }
                }
            };
        }

        private List<Module> GetBusinessAdminModules()
        {
            return new List<Module>
            {
                new Module
                {
                    ModuleNumber = 1,
                    ModuleName = "Communication in the Workplace",
                    Description = "Professional communication skills and workplace interaction",
                    ProgressPercentage = 100,
                    FeedbackStatus = "View Feedback",
                    UnitsCompleted = 5,
                    TotalUnits = 5,
                    IsLocked = false,
                    ShowUnits = false,
                    Units = new List<Unit>
                    {
                        new Unit { UnitStandard = "12344", UnitName = "Workplace Safety", Type = "Knowledge Questions", ProgressStatus = "Completed" },
                        new Unit { UnitStandard = "12345", UnitName = "Time Management", Type = "Practical Task", ProgressStatus = "Completed" },
                        new Unit { UnitStandard = "12345", UnitName = "Conflict Resolution", Type = "Observation Check", ProgressStatus = "Completed" },
                        new Unit { UnitStandard = "12345", UnitName = "Giving and Receiving Constructive Feedback", Type = "Role Play / Simulation", ProgressStatus = "Completed" },
                        new Unit { UnitStandard = "12345", UnitName = "Professional Email and Telephone Etiquette", Type = "Case Study", ProgressStatus = "Completed" },
                        new Unit { UnitStandard = "12345", UnitName = "Workplace Evidence", Type = "Workplace Evidence", ProgressStatus = "20%" },
                        new Unit { UnitStandard = "12345", UnitName = "Communicating with Clients and Stakeholders", Type = "Multiple Choice", ProgressStatus = "Not Started" },
                        new Unit { UnitStandard = "12345", UnitName = "Dealing with Difficult People", Type = "Presentation", ProgressStatus = "Not Started" },
                        new Unit { UnitStandard = "12345", UnitName = "Understanding Diversity and Inclusion", Type = "Long Written Answer / Essay", ProgressStatus = "Not Started" },
                        new Unit { UnitStandard = "12345", UnitName = "Developing Emotional Intelligence", Type = "Portfolio of Evidence (PoE)", ProgressStatus = "Not Started" },
                        new Unit { UnitStandard = "12346", UnitName = "Project Management Fundamentals", Type = "Group Assignment", ProgressStatus = "Not Started" }
                    }
                },
                new Module
                {
                    ModuleNumber = 2,
                    ModuleName = "Workplace Essentials",
                    Description = "Essential skills for effective workplace performance",
                    ProgressPercentage = 50,
                    FeedbackStatus = "New Feedback",
                    UnitsCompleted = 2,
                    TotalUnits = 4,
                    IsLocked = false,
                    ShowUnits = false,
                    Units = new List<Unit>
                    {
                        new Unit { UnitStandard = "12345", UnitName = "Risk Assessment & Management", Type = "Field Assessment", ProgressStatus = "Not Started" },
                        new Unit { UnitStandard = "12345", UnitName = "Business Communication Skills", Type = "Practical Demonstration", ProgressStatus = "Not Started" },
                    }
                },
                new Module
                {
                    ModuleNumber = 3,
                    ModuleName = "Business Writing and Reporting",
                    Description = "Professional writing skills and business documentation",
                    ProgressPercentage = 0,
                    FeedbackStatus = "Awaiting Feedback",
                    UnitsCompleted = 0,
                    TotalUnits = 3,
                    IsLocked = true,
                    ShowUnits = false,
                    Units = new List<Unit>
                    {
                        new Unit { UnitStandard = "12345", UnitName = "Computer Skills Integration", Type = "Integrated Assessment", ProgressStatus = "Not Started" },
                    }
                }
            };
        }

        public IEnumerable<Module> GetCompletedModules(SetaQualificationModel qualification)
        {
            var completedModules = qualification.Modules.Where(m => m.ProgressPercentage == 100).ToList();
            if (!completedModules.Any())
            {
                completedModules = qualification.Modules.Where(m => m.ProgressPercentage >= 90).ToList();
            }
            if (!completedModules.Any())
            {
                completedModules = qualification.Modules.Where(m => m.ModuleNumber <= 3).ToList();
            }
            return completedModules;
        }

        public IEnumerable<Module> GetFilteredModules(SetaQualificationModel qualification)
        {
            return qualification.Modules.Where(m => m.ModuleNumber <= 3);
        }
    }




    //===
}
