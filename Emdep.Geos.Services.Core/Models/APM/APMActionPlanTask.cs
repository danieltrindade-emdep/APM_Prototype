using Emdep.Geos.Services.Core.Models;

namespace Emdep.Geos.Core.Models
{
    public class APMActionPlanTask
    {
        public long IdActionPlanTask { get; set; }
        public int TaskNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdLookupStatus { get; set; }
        public string Status { get; set; }
        public int IdLookupPriority { get; set; }
        public string Priority { get; set; }
        public int IdLookupOrigin { get; set; }
        public string Origin { get; set; }
        public int IdLookupTheme { get; set; }
        public string Theme { get; set; }
        public DateTime DueDate { get; set; }
        public int DueDays { get; set; }
        public int IdDelegated { get; set; }
        public string DelegatedTo { get; set; }
        public int CommentsCount { get; set; }
        public string Comments { get; set; }
        public int FileCount { get; set; }
        public int Progress { get; set; }
        public int IdEmployee { get; set; }
        public string Responsible { get; set; }
        public int IdLookupBusiness { get; set; }
        public string BusinessUnit { get; set; }
        public string DueColor { get; set; }
        public string StatusHTMLColor { get; set; }
        public long IdActionPlan { get; set; }
        public int IdCompany { get; set; }
        public uint CreatedBy { get; set; }
        public string Code { get; set; }
        public string TaskLastComment { get; set; }
        public string EmployeeCode { get; set; }
        public int IdGender { get; set; }
        public int ModifiedBy { get; set; }

        // Dependência: Responsible
        public Responsible SelectedDelegatedTo { get; set; }

        // Convertido de ObservableCollection para List
        public List<Responsible> DelegatedToList { get; set; } = new();

        public DateTime? OpenDate { get; set; }
        public DateTime? OriginalDueDate { get; set; }
        public int Duration { get; set; }
        public DateTime? CloseDate { get; set; }
        public int ChangeCount { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string ActionPlanCode { get; set; }
        public string ThemeHTMLColor { get; set; }

        // NOTA: Removidos tipos de UI (Color/Brush) incompatíveis com Web API pura.
        // Se precisares de enviar a cor, usa strings Hex (ex: "#FF0000")
        // public string TaskTabColor { get; set; }
        // public string TaskTabBrush { get; set; }

        public string Location { get; set; }
        public string BusinessUnitHTMLColor { get; set; }
        public string ActionPlanCodeWithTaskNumber => $"{ActionPlanCode} - {TaskNumber}"; // Propriedade calculada mantida

        public int IdActionPlanResponsible { get; set; }
        public string CardDueColor { get; set; }

        // Dependência: LogEntriesByActionPlan
        public List<LogEntriesByActionPlan> ActionPlanLogEntries { get; set; } = new();

        public bool IsShowIcon { get; set; }
        public int ClosedBy { get; set; }
        public string ClosedByName { get; set; }
        public DateTime? CreatedIn { get; set; }
        public string CreatedByName { get; set; }
        public string TaskOrigin { get; set; }

        // Dependência: Country
        public Country Country { get; set; }

        public string ActionPlanDescription { get; set; }
        public int IdOrigin { get; set; }
        public int IdBusinessUnit { get; set; }
        public int ActionPlanResponsibleIdUser { get; set; }
        public string TaskResponsibleDisplayName { get; set; }
        public string DelegatedDisplayName { get; set; }
        public string TaskStatusComment { get; set; }
        public string TaskStatusDescription { get; set; }

        // Dependência: AttachmentsByTask (Tens de criar este Modelo também)
        public List<AttachmentsByTask> TaskAttachmentList { get; set; } = new();

        public int IdOTItem { get; set; }
        public int IdSite { get; set; }
        public string CodeNumber { get; set; }
        public int IdActionPlanLocation { get; set; }
        public string NumItem { get; set; }
        public long IdOT { get; set; }
        public string OTCode { get; set; }
        public string CustomerName { get; set; }
        public int ParticipantCount { get; set; }
        public string FirstName { get; set; }
        public bool IsSelectedRow { get; set; }
        public bool IsSaved { get; set; }
        public string PriorityHTMLColor { get; set; }
        public byte SettingInUse { get; set; }
        public int IdAppSetting { get; set; }
        public string OpenTaskCount { get; set; }
        public string ResponsibleWithTaskCount { get; set; }
        public int IdEmployeeContact { get; set; }
        public string EmployeeContactValue { get; set; }

        // Autorreferência (Lista da própria classe)
        public List<APMActionPlanTask> EmailTaskDetailsList { get; set; } = new();

        public bool IsTaskAdded { get; set; }
        public long IdParent { get; set; }

        // Dependência: APMActionPlanSubTask (Tens de criar este Modelo)
        public List<APMActionPlanSubTask> SubTaskList { get; set; } = new();

        public int ResponsibleIdUser { get; set; }
        public string GroupName { get; set; }
        public bool IsTaskDeleted { get; set; }
        public string Group { get; set; }
        public string Site { get; set; }
        public int TotalTaskCount { get; set; }
        public int OpenStatusTaskCount { get; set; }
        public int ClosedTaskCount { get; set; }
        public DateTime? SentDateTime { get; set; }
        public string CompanyEmail { get; set; }
        public bool IsPreviewEmail { get; set; }
        public bool SentEmail { get; set; }
        public string OriginWeek { get; set; }
        public string TaskNumberLable { get; set; }
        public string OpenSubtaskCount { get; set; }
        public string YBPCode { get; set; }
        public int IdFiveYearBusinessPlansTaskCodes { get; set; }
    }
}