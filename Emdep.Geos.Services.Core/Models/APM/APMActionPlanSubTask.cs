using Emdep.Geos.Services.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emdep.Geos.Core.Models
{
    public class APMActionPlanSubTask
    {
        [NotMapped]
        public long IdActionPlanTask { get; set; }
        [NotMapped]
        public int TaskNumber { get; set; }
        [NotMapped]
        public string Title { get; set; }
        [NotMapped]
        public string Description { get; set; }
        [NotMapped]
        public int IdLookupStatus { get; set; }
        [NotMapped]
        public string Status { get; set; }
        [NotMapped]
        public string StatusHTMLColor { get; set; }
        [NotMapped]
        public int IdLookupPriority { get; set; }
        [NotMapped]
        public string Priority { get; set; }
        [NotMapped]
        public int IdLookupOrigin { get; set; }
        [NotMapped]
        public string Origin { get; set; }
        [NotMapped]
        public int IdLookupTheme { get; set; }
        [NotMapped]
        public string Theme { get; set; }
        [NotMapped]
        public DateTime DueDate { get; set; }
        [NotMapped]
        public int DueDays { get; set; }
        [NotMapped]
        public int IdDelegated { get; set; }
        [NotMapped]
        public string DelegatedTo { get; set; }
        [NotMapped]
        public int CommentsCount { get; set; }
        [NotMapped]
        public string Comments { get; set; }
        [NotMapped]
        public int FileCount { get; set; }
        [NotMapped]
        public int Progress { get; set; }
        [NotMapped]
        public int IdEmployee { get; set; }
        [NotMapped]
        public string Responsible { get; set; }
        [NotMapped]
        public int IdLookupBusiness { get; set; }
        [NotMapped]
        public string BusinessUnit { get; set; }
        [NotMapped]
        public string DueColor { get; set; }
        [NotMapped]
        public long IdActionPlan { get; set; }
        [NotMapped]
        public int IdCompany { get; set; }
        [NotMapped]
        public uint CreatedBy { get; set; }
        [NotMapped]
        public string Code { get; set; }
        [NotMapped]
        public string TaskLastComment { get; set; }
        [NotMapped]
        public string EmployeeCode { get; set; }
        [NotMapped]
        public int IdGender { get; set; }
        [NotMapped]
        public int ModifiedBy { get; set; }

        [NotMapped]
        public Responsible SelectedDelegatedTo { get; set; }

        [NotMapped]
        public List<Responsible> DelegatedToList { get; set; } = new();

        [NotMapped]
        public DateTime? OpenDate { get; set; }
        [NotMapped]
        public int Duration { get; set; }
        [NotMapped]
        public DateTime? OriginalDueDate { get; set; }
        [NotMapped]
        public DateTime? CloseDate { get; set; }
        [NotMapped]
        public int ChangeCount { get; set; }
        [NotMapped]
        public DateTime? LastUpdated { get; set; }
        [NotMapped]
        public string ActionPlanCode { get; set; }
        [NotMapped]
        public string ThemeHTMLColor { get; set; }

        [NotMapped]
        public string Location { get; set; }
        [NotMapped]
        public string BusinessUnitHTMLColor { get; set; }
        [NotMapped]
        public int IdActionPlanResponsible { get; set; }
        [NotMapped]
        public string CardDueColor { get; set; }

        [NotMapped]
        public List<LogEntriesByActionPlan> ActionPlanLogEntries { get; set; } = new();

        [NotMapped]
        public bool IsShowIcon { get; set; }
        [NotMapped]
        public int ClosedBy { get; set; }
        [NotMapped]
        public string ClosedByName { get; set; }
        [NotMapped]
        public DateTime? CreatedIn { get; set; }
        [NotMapped]
        public string CreatedByName { get; set; }
        [NotMapped]
        public string TaskOrigin { get; set; }

        public Country Country { get; set; }

        [NotMapped]
        public string ActionPlanDescription { get; set; }
        [NotMapped]
        public int IdOrigin { get; set; }
        [NotMapped]
        public int IdBusinessUnit { get; set; }
        [NotMapped]
        public int ActionPlanResponsibleIdUser { get; set; }
        [NotMapped]
        public string TaskResponsibleDisplayName { get; set; }
        [NotMapped]
        public string DelegatedDisplayName { get; set; }
        [NotMapped]
        public string TaskStatusComment { get; set; }
        [NotMapped]
        public string TaskStatusDescription { get; set; }

        [NotMapped]
        public List<AttachmentsByTask> TaskAttachmentList { get; set; } = new();

        [NotMapped]
        public int IdOTItem { get; set; }
        [NotMapped]
        public int IdSite { get; set; }
        [NotMapped]
        public string CodeNumber { get; set; }
        [NotMapped]
        public int IdActionPlanLocation { get; set; }
        [NotMapped]
        public string NumItem { get; set; }
        [NotMapped]
        public long IdOT { get; set; }
        [NotMapped]
        public string OTCode { get; set; }
        [NotMapped]
        public string CustomerName { get; set; }
        [NotMapped]
        public int ParticipantCount { get; set; }
        [NotMapped]
        public string FirstName { get; set; }
        [NotMapped]
        public bool IsSelectedRow { get; set; }
        [NotMapped]
        public bool IsSaved { get; set; }
        [NotMapped]
        public string PriorityHTMLColor { get; set; }
        [NotMapped]
        public byte SettingInUse { get; set; }
        [NotMapped]
        public int IdAppSetting { get; set; }
        [NotMapped]
        public string OpenTaskCount { get; set; }
        [NotMapped]
        public string ResponsibleWithTaskCount { get; set; }
        [NotMapped]
        public int IdEmployeeContact { get; set; }
        [NotMapped]
        public string EmployeeContactValue { get; set; }

        [NotMapped]
        public List<APMActionPlanTask> EmailTaskDetailsList { get; set; } = new();

        [NotMapped]
        public long IdParent { get; set; }
        [NotMapped]
        public long SubTaskNumber { get; set; }
        [NotMapped]
        public long ParentTaskNumber { get; set; }
        [NotMapped]
        public string SubTaskCode { get; set; }
        [NotMapped]
        public bool IsSubTaskAdded { get; set; }
        [NotMapped]
        public bool IsSubTaskDeleted { get; set; }
        [NotMapped]
        public string Group { get; set; }
        [NotMapped]
        public string Site { get; set; }
        [NotMapped]
        public string GroupName { get; set; }
        [NotMapped]
        public string OriginWeek { get; set; }
        [NotMapped]
        public string YBPCode { get; set; }
        [NotMapped]
        public int IdFiveYearBusinessPlansTaskCodes { get; set; }

        [NotMapped]
        public string ActionPlanCodeWithTaskNumber => $"{ActionPlanCode} - {TaskNumber}";
    }
}