namespace Emdep.Geos.Contracts.APM
{
    public record APMTableViewDTO
    {
        public long IdActionPlan { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public string Location { get; init; }
        public string CountryIso { get; init; }
        public string CountryIconUrl { get; init; }
        public string Responsible { get; init; }
        public string Origin { get; init; }
        public string BusinessUnit { get; init; }
        public string Department { get; init; }
        public string YBPCode { get; init; }
        public string Customer { get; init; }
        public int TotalTasks { get; init; }
        public int OpenTasks { get; init; }
        public int ClosedTasks { get; init; }
        public string ClosedTasksColor { get; init; }
        public int WorkComplete { get; init; }
        public List<TaskViewDTO> Tasks { get; init; } = [];
    }

    public record TaskViewDTO
    {
        public long IdTask { get; init; }
        public string Item { get; init; }
        public string Title { get; init; }
        public string Responsible { get; init; }
        public string Status { get; init; }
        public string StatusColor { get; init; }
        public string Priority { get; init; }
        public string PriorityColor { get; init; }
        public string YBPCode { get; init; }
        public string Theme { get; init; }
        public string Customer { get; init; }
        public DateTime? OpenDate { get; init; }
        public DateTime? OriginalDueDate { get; init; }
        public DateTime DueDate { get; init; }
        public DateTime? CloseDate { get; init; }
        public DateTime CreationDate { get; init; }
        public DateTime? LastUpdated { get; init; }
        public int Duration { get; init; }
        public int DueDays { get; init; }
        public string DueDaysColor { get; init; }
        public int ChangeCount { get; init; }
        public string DelegatedTo { get; init; }
        public string OTItem { get; init; }
        public int Comments { get; init; }
        public int Files { get; init; }
        public int Participants { get; init; }
        public int Progress { get; init; }
        public string ClosedBy { get; init; }
        public string CreatedBy { get; init; }
        public string Description { get; init; }
        public string OriginWeek { get; init; }
        public List<SubTaskViewDTO> SubTasks { get; init; } = [];
    }

    public record SubTaskViewDTO
    {
        public long IdTask { get; init; }
        public string Item { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Responsible { get; init; }
        public string Status { get; init; }
        public string StatusColor { get; init; }
        public string Priority { get; init; }
        public string PriorityColor { get; init; }
        public string YBPCode { get; init; }
        public string Theme { get; init; }
        public DateTime? OpenDate { get; init; }
        public DateTime? OriginalDueDate { get; init; }
        public DateTime DueDate { get; init; }
        public int? Duration { get; init; }
        public int? DueDays { get; init; }
        public string DueDaysColor { get; init; }
        public DateTime? CloseDate { get; init; }
        public DateTime? LastUpdated { get; init; }
        public DateTime CreationDate { get; init; }
        public int ChangeCount { get; init; }
        public string DelegatedTo { get; init; }
        public string ClosedBy { get; init; }
        public string CreatedBy { get; init; }
        public string OTItem { get; init; }
        public int Comments { get; init; }
        public int Files { get; init; }
        public int Participants { get; init; }
        public int Progress { get; init; }
        public string OriginWeek { get; init; }
    }
}
