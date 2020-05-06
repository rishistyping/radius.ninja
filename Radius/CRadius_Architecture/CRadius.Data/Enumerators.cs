public class Enumerators
{
    #region Enumerators

    public enum LocationType
    {
        None = 0,
        Radius = 1,
        Polygon = 2,
    }

    public enum Scale
    {
        None = 0,
        MultipleChoice5 = 1,
        Scale10 = 2,
        Percentage = 3,
        MultipleChoice3 = 4,
        Slider5 = 5,
        Quadrant = 6,
    }

    public enum ReviewStatus
    {
        None = 0,
        Draft = 1,
        InProgress = 2,
        Completed = 3,
        Cancelled = 4,
    }

    public enum CRUDTrigger
    {
        None = 0,
        Create = 1,
        Update = 2,
        CreateorUpdate = 3,
        DeleteorInactive = 4,
    }

    public enum HalfDay
    {
        No = 0,
        AM = 1,
        PM = 2,
    }

    public enum AnnouncementType
    {
        Announcement = 1,
        Downtime = 2,
    }

    public enum TimesheetFrequency
    {
        Monthly = 0,
        Weekly = 1,
        Daily = 2,
    }

    public enum DaysOfWeek
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7,
    }
    public enum RateType
    {
        None = 0,
        Daily = 1,
        Hourly = 2,
    }

    public enum DailyRoundingType
    {
        FullDay = 0,
        HalfDay = 1,
        None = 2,
    }

    public enum ApprovalStatus
    {
        Draft = 0,
        Signed = 1,
        Approved = 2,
        Authorized = 3,
        Rejected = 4,
    }

    public enum ExpensesType
    {
        Direct = 1,
        Percent = 2,
        NotChargable = 3
    }
    public enum CtrExpensesType
    {
        Direct = 1,
        Percent = 2,
        NotReimburseable = 3
    }

    public enum ContractType
    {
        FullTime = 1,
        PartTime = 2,
        Consultant = 3,
        Temporary = 4,
        Other = 5,
    }

    public enum Jobs
    {
        ProcessQueue = 0,
        MembershipReport = 1,
        TrialSignupInvitation = 2,
        TrialExpiryWarningEmail = 3,
        TrialExpiryImminentEmail = 4,
        ThanksAndGoodbyeEmail = 5,
    }

    public enum InvoiceStatus
    {
        Draft = 0,
        Calculated = 1,
        Sent = 2,
        Manual = 3,
        Paid = 4,
        Cancelled = 5,
        Free = 6,
        Carried = 7,
    }

    public enum SystemLevel
    {
        Dev = 0,
        Test = 1,
        Live = 2,
    }

    public enum Severity
    {
        Nothing = 0,
        Insignificant = 1,
        Minor = 2,
        Moderate = 3,
        Major = 4,
        Catastrophic = 5
    }

    public enum IncidentType
    {
        Nothing = 0,
        ObservationIssue = 1,
        ObservationNearMiss = 2,
        NonConformity = 3,
        HSLTI = 4,
        HSNonLTI = 5,
        EnvironmentalMajor = 6,
        EnvironmentalMinor = 7
    }

    public enum Country
    {
        Australia = 12,
    }

    public enum RACIRule
    {
        None = 0,
        Email = 1,
        EmailSMS = 2,
    }

    public enum Blockchain
    {
        None = 0,
        Auditable = 1,
        History = 2,
        Both = 3
    }

    public enum CodeGeneration
    {
        Automatic = 0,
        Manual = 1,
        None = 2,
    }

    public enum PublicationLevel
    {
        None = 0,
        Private = 1,
        Public = 2,
    }

    public enum CompetencyEvidence
    {
        Unknown = 0,
        CurrentQualification = 1,
        ExpiredQualification = 2,
        Experience = 3,
    }

    public enum CompetencyLevel
    {
        Unknown = 0,
        NotCompetent = 1,
        Trainee = 2,
        Competent = 3,
        Expert = 4,
        Other = 5,
    }

    public enum CompetencyRequirement
    {
        Unknown = 0,
        Yes = 1,
        No = 2,
        Preferred = 3,
    }

    public enum SysMasterStatus
    {
        Open = 1,
        Closed = 2,
    }

    public enum SortModule
    {
        Legislation = 1,
        Risk = 2,
        Emergency = 3,
        Enviro = 4,
        COSHH = 5,
        Actions = 6,
        Feedback = 7,
        CompanyObjectives = 8,
        Meetings = 9,
        Audits = 10,
        Customers = 11,
        Suppliers = 12,
        Assets = 13,
        Projects = 14,
        AuditResponses = 15,
        MeetingMinutes = 16,
        People = 17,
        AuditTemplates = 18,
        MeetingTemplates = 19,
        PerformanceReview = 20,
        Tables = 21,
        Company = 22,
        Incidents = 23,
        Downloads = 24,
        Documents = 25,
        Clients = 26,
        Consultants = 27,
        Roles = 28,
        Invoicing = 29,
        Timesheet = 30,
        Location = 31,
        PersonCompetency = 32,
        RoleCompetency = 33,
    }

    public enum Module
    {
        Legislation = 1,
        Risk = 2,
        Emergency = 3,
        Enviro = 4,
        COSHH = 5,
        Actions = 6,
        Feedback = 7,
        CompanyObjectives = 8,
        Meetings = 9,
        Audits = 10,
        Customers = 11,
        Suppliers = 12,
        Assets = 13,
        Projects = 14,
        AuditResponses = 15,
        MeetingMinutes = 16,
        People = 17,
        AuditTemplates = 18,
        MeetingTemplates = 19,
        PerformanceReview = 20,
        Tables = 21,
        Company = 22,
        Incidents = 23,
        Timesheet = 24,
        
        // Secondaries
        AuditResponse = 15,
        MeetingMinute = 16,
        CustomerContact = 21,
        CustomerComment = 22,
        PersonCareerHistory = 23,
        PersonCompetency = 24,
        PersonHoliday = 25,
        PersonObjective = 26,
        PersonSickness = 27,
        PersonTraining = 28,
        AuditAgenda = 29,
        AuditAttendee = 30,
        AuditDefaultAgenda = 31,
        AuditDefaultAttendee = 32,
        EmergencyContact = 34,
        EmergencyDrillAttendee = 35,
        EmergencyEnviro = 36,
        EmergencyEquipment = 37,
        EmergencyMaterial = 38,
        EmergencyRiskAssessment = 39,
        EmergencySupplier = 40,
        EnvironmentalCorrectiveAction = 41,
        EnvironmentalImpact = 42,
        MeetingAgenda = 43,
        MeetingAttendee = 44,
        MeetingDefaultAgenda = 45,
        MeetingDefaultAttendee = 46,
        NCRSource = 47, // ??
        RiskActivity = 48,
        RiskMitigationMeasure = 49,
        SupplierContact = 59,
        SupplierCategory = 50,
        ItemSubType = 51, // ??
        ItemType = 52, // ??
        Location = 53, // ??
        Room = 54, // ??
        Site = 55, // ??
        Role = 56, // ??
        //Company = 58,
        Product = 60, // ??
        BusinessProcess = 61, // ??
        Competency = 62,
        COSHHAsset = 64,
        AuditRisk = 65,
        AuditTemplateRisk = 66,
        Incident = 67,
        ProjectRACI = 68,
        EmergencyResponse = 69,
        //Timesheet = 70,
        CompetencyCategory = 71,
    }

    public enum Permissions
    {
        None = 1,
        Read = 2,
        Write = 3,
    }

    public enum AssociationMode
    {
        Global = 1,
        Process = 2,
        ProcessInstance = 3,
    }

    public enum BusinessProcess
    {
        Nothing = 0,

        LegislationIndex = 1,
        RiskAssessments = 2,
        EmergencyPlanning = 3,
        EnvironmentalControls = 4,
        COSHH = 5,
        Actions = 6,
        Feedback = 7,
        CompanyObjectives = 8,
        Meetings = 9,
        Audits = 10,
        Customers = 11,
        Suppliers = 12,
        Assets = 13,
        Projects = 14,
        People = 17,
        AuditTemplates = 18,
        MeetingTemplates = 19,
        PerformanceReviews = 20,

        // Secondaries
        AuditResponse = 15,
        MeetingMinute = 16,
        CustomerContact = 21,
        CustomerComment = 22,
        PersonCareerHistory = 23,
        PersonCompetency = 24,
        PersonHoliday = 25,
        PersonObjective = 26,
        PersonSickness = 27,
        PersonTraining = 28,
        AuditAgenda = 29,
        AuditAttendee = 30,
        AuditDefaultAgenda = 31,
        AuditDefaultAttendee = 32,
        EmergencyContact = 34,
        EmergencyDrillAttendee = 35,
        EmergencyEnviro = 36,
        EmergencyEquipment = 37,
        EmergencyMaterial = 38,
        EmergencyRiskAssessment = 39,
        EmergencySupplier = 40,
        EnvironmentalCorrectiveAction = 41,
        EnvironmentalImpact = 42,
        MeetingAgenda = 43,
        MeetingAttendee = 44,
        MeetingDefaultAgenda = 45,
        MeetingDefaultAttendee = 46,
        NCRSource = 47, // ??
        RiskActivity = 48,
        RiskMitigationMeasure = 49,
        SupplierContact = 59,
        SupplierCategory = 50,
        ItemSubType = 51, // ??
        ItemType = 52, // ??
        Location = 53, // ??
        Room = 54, // ??
        Site = 55, // ??
        Role = 56, // ??
        Company = 58,
        Product = 60, // ??
        BusinessProcess = 61, // ??
        Competency = 62,
        COSHHAsset = 64,
        AuditRisk = 65,
        AuditTemplateRisk = 66,
        Incident = 67,
        ProjectRACI = 68,
        EmergencyResponse = 69,
        Workflow = 70,
        CompetencyCategory = 71,
    }

    public enum ReportSource
    {
        Nothing = 0,

        LegislationIndex = 1,
        RiskAssessment = 2,
        EmergencyPlanning = 3,
        EnvironmentalControls = 4,
        COSHH = 5,
        Action = 6,
        Feedback = 7,
        CompanyObjective = 8,
        Meeting = 9,
        Audit = 10,
        Customer = 11,
        Supplier = 12,
        Asset = 13,
        Project = 14,
        AuditResponse = 15,
        MeetingMinute = 16,
        Person = 17,
        AuditTemplate = 18,
        MeetingTemplate = 19,
        PerformanceReview = 20,
        Incident = 21,

        LegislationIndexList = 101,
        RiskAssessmentList = 102,
        EmergencyPlanningList = 103,
        EnvironmentalControlList = 104,
        COSHHList = 105,
        ActionList = 106,
        FeedbackList = 107,
        CompanyObjectiveList = 108,
        MeetingList = 109,
        AuditList = 110,
        CustomerList = 111,
        SupplierList = 112,
        AssetList = 113,
        ProjectList = 114,
        AuditResponseList = 115,
        MeetingMinuteList = 116,
        PersonList = 117,
        AuditTemplateList = 118,
        MeetingTemplateList = 119,
        PerformanceReviewList = 120,
        DocumentList = 121,
        ClientList = 122,
        ConsultantList = 123,
        TimesheetList = 124,

        AuditGraphs = 210,
        ActionsGraph = 211,

        QtimeCustomerBillingReport = 301,
        QtimePersonReimbursementReport = 302,
        QtimeResourcingReport = 303,
    }

    public enum DocumentStatus
    {
        Active = 1,
        AwaitingReview = 2,
        Replaced = 3,
        Inactive = 4,
    }

    public enum Zone
    {
        SystemZone = 1,
        QuestionZone = 2,
        AdminZone = 3,
        RecordingZone = 4,
    }

    public enum ImpactLevel
    {
        Empty = 1,
        Low = 2,
        Medium = 3,
        High = 4,
        VeryHigh = 5
    }
    
    public enum ActionItemType
    {
        Fix = 1,
        Improvement = 2,
        PersonalObjective = 3,
        CompanyActivity = 4
    }

    public enum FixCategory
    {
        LTI = 1,
        NonLTI = 2,
        NonConformity = 3,
        Observation = 4,
        Other = 5,
    }

    public enum ProjectStatus
    {
        New = 1,
        Planning = 2,
        InProgress = 3,
        Completed = 4,
        Cancelled = 5
    }

    public enum StringType
    {
        ActionStatus = 2,
        ActionPriority = 3,
        Title = 4,
        Sex = 5,
        Status = 6,
        ContractType = 7,
        MaritalStatus = 8,
        Relationship = 9,
        CompetencyLevel = 10,
        Category = 11,
        HolidayType = 12,
        SupplierQuality = 14,
        AuditStatus = 15,
        ResponseStatus = 16,
        ActionItemType = 17,
        ISOProcess = 18,
        MeetingStatus = 19,
        MinuteStatus = 20,
        ProjectStatus = 21,
        COSHHStatus = 22,
        EnviroType = 24,
        ImpactLevel = 25,
        LegislationCategory = 26,
        LegislationType = 27,
        HazardType = 29,
        FixCategory = 30,
        StorageConditions = 31,
        Composition = 32,
        ContainerType = 33,
        Colour = 34,
        Branding = 35,
        COSHHAssessmentStatus = 36,
        COSHHLevel = 37,
        ReviewStatus = 38,
        ObjectiveStatus = 39,
        CommentType = 40,
        //Country = 41,
        DocumentStatus = 42,
        FilenameExtension = 43,
        Period = 44,
        CompetencyEvidence = 45,
        CompetencyRequirement = 46,
        SubscriberType = 47,
        PublicationLevel = 48,
        EnquiryType = 49,
        ConsequenceRating = 50,
        IncidentTrajectory = 51,
        Severity = 52,
        IncidentType = 53,
        SecurityQuestion = 54,
        InvoiceStatus = 55,
        SubscriberTypeInternal = 56,
    }

    public enum ActionStatus
    {
        New = 1,
        InProgress = 2,
        Completed = 3,
        Cancelled = 4,
        CarriedForward = 5,
        Review = 6,
        Template = 7,
        Overdue = 8
    }

    public enum ActionPriority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }

    public enum Status
    {
        Active = 1,
        Inactive = 2
    }

    public enum IncidentStatus
    {
        Active = 1,
        Completed = 2
    }

    public enum ResponseStatus
    {
        Open = 1,
        Closed = 2,
        CarriedForward = 3
    }

    public enum MinuteStatus
    {
        Open = 1,
        Closed = 2,
        CarriedForward = 3
    }

    public enum AuditStatus
    {
        Draft = 1,
        Prepared = 2,
        Completed = 3,
        Cancelled = 4
    }

    public enum MeetingStatus
    {
        Draft = 1,
        Prepared = 2,
        Completed = 3,
        Cancelled = 4
    }

    public enum SubscriberType
    {
        Partner = 1,
        Client = 2,
        OwnerAuditor = 3,
        ProfessionalPartner = 4,
        PremiumPartner = 5,
    }

    public enum EnquiryType
    {
        Partner = 1,
        ProfessionalPartner = 4,
        PremiumPartner = 5,
        LearnMore = 6,
        Other = 7,
    }

    public enum EvidenceType
    {
        EmptyRow = 1,
        Image = 2,
        Zip = 3,
        Document = 4,
        Spreadsheet = 5,
        Presentation = 6,
        Data = 7,
        Other = 8
    }

    public enum State
    {
        Nothing = 0,
        QZoneWelcome = 1,
        Downloads = 2,
        Dashboard = 3,
        Tables = 4,
        Clients = 5,
        Consultants = 6,
        Company = 7,
        People = 8,
        SZoneWelcome = 9,
        Subscriber = 10,
        Documents = 11,
        Billing = 12,
        AuthorHelp = 13,
        Downtime = 14,
        Settings = 15,
        Notifications = 16,
        SubmitJobs = 17,
        Subscribers = 18,
    }

    public enum AuditEntity
    {
        SysSubscriber = 1,	
        SysPerson = 2,
        EmpPersonCareerHistory = 3,
        SysRole = 4,
        AstItem = 5,
        EmpPersonCompetency = 6,
        EmpTraining = 7,
        EmpHoliday = 8,
        EmpSickness = 9,
        SysDocument = 10,
        SupSupplier = 11,
        SupProduct = 12,
        CrmCustomer = 13,
        MgtAuditTemplate = 14,
        MgtAuditDefaultAttendee = 15,
        MgtAuditDefaultAgenda = 16,
        MgtAudit = 17,
        MgtAuditAttendee = 18,
        MgtAuditAgenda = 19,
        MgtAuditResponse = 20,
        SysAction = 21,
        MgtMeetingTemplate = 22,
        MgtMeetingDefaultAttendee = 23,
        MgtMeetingDefaultAgenda = 24,
        MgtMeeting = 25,
        MgtMeetingAttendee = 26,
        MgtMeetingAgenda = 27,
        MgtMeetingMinute = 28,
        VolProject = 29,
        CrmFeedback = 30,
        CrmCustomerComment = 31,
        VolCOSHH = 32,
        MgtEnviro = 33,
        MgtEnviroImpact = 34,
        MgtEnviroCorrectiveAction = 35,
        SysHelp = 36,
        MgtEmergency = 37,
        MgtEmergencyContact = 38,
        MgtEmergencySupplier = 39,
        MgtEmergencyEquipment = 40,
        MgtEmergencyMaterial = 41,
        MgtEmergencyEnviro = 42,
        MgtEmergencyRiskAssessment = 43,
        MgtRisk = 44,
        SysComputer = 45,
        MgtRiskActivity = 46,
        MgtRiskMitigationMeasure = 47,
        MgtLegislation = 48,
        RefSite = 49,
        AstItemType = 50,
        RefRoom = 51,
        AstItemSubType = 52,
        RefCompetency = 53,
        MgtNCRSource = 54,
        RefBusinessProcess = 55,
        EmpPerformanceReview = 56,
        EmpObjective = 57,
        MgtEmergencyDrillAttendee = 58,
        RefLocation = 59,
        RefItemType = 60,
        RefItemSubType = 61,
        DocDocument = 62,
        RefCategory = 63,
        SysMaster = 64,
        VolCOSHHAsset = 65,
        RefRACIRole = 66,
        VolProjectRACI = 67,
        MgtAuditRisk = 68,
        MgtAuditDefaultRisk = 69,
        MgtIncident = 70,
        MemPrice = 71,
        MemInvoice = 72,
        RefRACIRoleOccupant = 73,
        SysQueue = 74,
        MgtEmergencyResponse = 75,
        QtiTimesheet = 76,
        QtiRow = 77,
    }

    public enum AuditAction
    {
        Created = 1,
        Updated = 2,
        Authorized = 3,
        Deleted = 4,
        FileCleared = 5
    }

    public enum Defaults
    {
        UnitedKingdom = 213
    }

    public enum RoleType
    {
        Unused = 1,
        User = 2,
        Entadmin = 3,
        ProjectPerson = 4,
        Sysadmin = 5,
        PersonManager = 6,
    }

    #endregion
}