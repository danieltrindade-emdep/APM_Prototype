using Emdep.Geos.Services.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Emdep.Geos.Core.Models
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public bool IsActive { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string NativeName { get; set; }
        public DateTime BirthDate { get; set; }
        public uint IdGender { get; set; }
        public uint IdMaritalStatus { get; set; }
        public long IdNationality { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressRegion { get; set; }
        public string AddressZipCode { get; set; }
        [NotMapped]
        public string FullAddress { get; set; }
        public long AddressIdCountry { get; set; }
        public ushort Disability { get; set; }
        [NotMapped]
        public byte IsEnabled { get; set; }
        public byte IsTrainer { get; set; }
        [NotMapped]
        public string Remarks { get; set; }
        public int IdCompanyShift { get; set; }

        [NotMapped]
        public LookupValue Gender { get; set; }
        [NotMapped]
        public LookupValue MaritalStatus { get; set; }
        [NotMapped]
        public Country Nationality { get; set; }
        public Country AddressCountry { get; set; }
        [NotMapped]
        public CompanyShift CompanyShift { get; set; }

        [NotMapped]
        public List<EmployeeContact> EmployeePersonalContacts { get; set; } = new();
        [NotMapped]
        public List<EmployeeDocument> EmployeeDocuments { get; set; } = new();
        [NotMapped]
        public List<EmployeeLanguage> EmployeeLanguages { get; set; } = new();
        [NotMapped]
        public List<EmployeeEducationQualification> EmployeeEducationQualifications { get; set; } = new();
        [NotMapped]
        public List<EmployeeContractSituation> EmployeeContractSituations { get; set; } = new();
        [NotMapped]
        public List<EmployeeFamilyMember> EmployeeFamilyMembers { get; set; } = new();
        [NotMapped]
        public List<EmployeeJobDescription> EmployeeJobDescriptions { get; set; } = new();
        [NotMapped]
        public List<EmployeeChangelog> EmployeeChangelogs { get; set; } = new();
        [NotMapped]
        public List<EmployeeContact> EmployeeProfessionalContacts { get; set; } = new();
        [NotMapped]
        public List<EmployeeProfessionalEducation> EmployeeProfessionalEducations { get; set; } = new();
        [NotMapped]
        public byte[] ProfileImageInBytes { get; set; }
        [NotMapped]
        public bool IsProfileImageDeleted { get; set; }
        [NotMapped]
        public EmployeeJobDescription EmployeeJobDescription { get; set; }
        [NotMapped]
        public EmployeePolyvalence EmplyeePolyvalence { get; set; }

        [NotMapped]
        public string EmployeeContactEmail { get; set; }
        [NotMapped]
        public string EmployeeContactMobile { get; set; }
        [NotMapped]
        public string EmployeeContactSkype { get; set; }
        [NotMapped]
        public string EmployeeContactLandline { get; set; }
        [NotMapped]
        public string EmployeeContactTraning { get; set; }
        [NotMapped]
        public string EmployeeContactHome { get; set; }

        [NotMapped]
        public List<string> EmployeeContactCompanyEmailList { get; set; } = new();
        [NotMapped]
        public string EmployeeContactCompanyMobiles { get; set; }
        [NotMapped]
        public List<string> EmployeeContactCompanyMobileList { get; set; } = new();
        [NotMapped]
        public string EmployeeContactCompanySkypes { get; set; }
        [NotMapped]
        public List<string> EmployeeContactCompanySkypeList { get; set; } = new();
        [NotMapped]
        public string EmployeeContactCompanyLandlines { get; set; }
        [NotMapped]
        public List<string> EmployeeContactCompanyLandlineList { get; set; } = new();
        [NotMapped]
        public string EmployeeContactTranings { get; set; }
        [NotMapped]
        public List<string> EmployeeContactTraningList { get; set; } = new();

        [NotMapped]
        public List<string> EmployeeContactPrivateEmailList { get; set; } = new();
        [NotMapped]
        public string EmployeeContactPrivateMobiles { get; set; }
        [NotMapped]
        public List<string> EmployeeContactPrivateMobileList { get; set; } = new();
        [NotMapped]
        public string EmployeeJobTitles { get; set; }
        [NotMapped]
        public string EmployeePolyvalence { get; set; } // String descritiva
        [NotMapped]
        public List<EmployeePolyvalence> EmployeePolyvalences { get; set; } = new(); // Lista detalhada
        [NotMapped]
        public ContractSituation ContractSituation { get; set; }
        [NotMapped]
        public int LengthOfService { get; set; }
        [NotMapped]
        public int IdParent { get; set; }
        [NotMapped]
        public List<EmployeeAnnualLeave> EmployeeAnnualLeaves { get; set; } = new();
        [NotMapped]
        public string TotalWorkedHours { get; set; }
        [NotMapped]
        public string TotalNonWorkingHours { get; set; }
        [NotMapped]
        public TimeSpan? DayWorkedHours { get; set; }
        [NotMapped]
        public DateTime? HireDate { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}".Trim();
        public int? IdEmployeeStatus { get; set; }
        [NotMapped]
        public LookupValue EmployeeStatus { get; set; }

        public DateTime? ExitDate { get; set; }
        public int? ExitIdReason { get; set; }
        [NotMapped]
        public LookupValue ExitReason { get; set; }
        public string ExitRemarks { get; set; }
        [NotMapped]
        public string ExitFileName { get; set; }
        [NotMapped]
        public byte[] EmployeeExitDocInBytes { get; set; }
        [NotMapped]
        public bool IsemployeeExitDocDeleted { get; set; }
        [NotMapped]
        public List<string> EmployeeJobCodes { get; set; } = new();
        [NotMapped]
        public EmployeeDocument EmployeeDocument { get; set; }
        [NotMapped]
        public string Languages { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [NotMapped]
        public EmployeeContractSituation EmployeeContractSituation { get; set; }

        [NotMapped]
        public string EmpJobCodes { get; set; }
        [NotMapped]
        public string EmpJobCodeAbbreviations { get; set; }
        [NotMapped]
        public string LengthOfServiceString { get; set; }

        [NotMapped]
        public List<EmployeeShift> EmployeeShifts { get; set; } = new();

        [NotMapped]
        public string EmployeeDocNationalId { get; set; }
        [NotMapped]
        public string EmployeeDocPassport { get; set; }
        [NotMapped]
        public string EmployeeDocDrLicense { get; set; }
        [NotMapped]
        public string EmployeeDocPubIns { get; set; }
        [NotMapped]
        public string EmployeeDocPriIns { get; set; }
        [NotMapped]
        public string EmployeeDocVisa { get; set; }
        [NotMapped]
        public string EmployeeDocOther { get; set; }
        [NotMapped]
        public string EmployeeDocClockId { get; set; }

        [NotMapped]
        public List<EmployeeLeave> EmployeeLeave { get; set; } = new();

        [NotMapped]
        public string EmployeeDepartments { get; set; }
        [NotMapped]
        public string EmployeeCompanyAlias { get; set; }

        [NotMapped]
        public byte IsLongTermAbsent { get; set; }
        public int? IdCompanyLocation { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Company CompanyLocation { get; set; }
        [NotMapped]
        public List<Department> LstEmployeeDepartments { get; set; } = new();

        [NotMapped]
        public string Organization { get; set; }
        [NotMapped]
        public string Company { get; set; }
        [NotMapped]
        public string EmployeeDepartmentsHtmlColors { get; set; }
        [NotMapped]
        public string EmployeeCompanyIds { get; set; }

        [NotMapped]
        public EmployeeAnnualLeave EmployeeAnnualLeave { get; set; }
        [NotMapped]
        public EmployeeExitEvent EmployeeExitEvent { get; set; }
        [NotMapped]
        public List<EmployeeExitEvent> EmployeeExitEvents { get; set; } = new();

        [NotMapped]
        public string EmployeeShiftNames { get; set; }
        [NotMapped]
        public string EmployeeShiftScheduleNames { get; set; }
        [NotMapped]
        public byte HasWelcomeMessageBeenReceived { get; set; }

        [NotMapped]
        public string EmployeeExitDateInCurrentMonth { get; set; }
        [NotMapped]
        public string EmployeeTransferredCompanyInCurrentMonth { get; set; }
        [NotMapped]
        public bool IsEmployeeExitDateInCurrentMonth { get; set; }
        [NotMapped]
        public bool IsEmployeeTransferredCompanyInCurrentMonth { get; set; }

        [NotMapped]
        public DateTime JDStartDate { get; set; }
        [NotMapped]
        public List<EmployeeAnnualAdditionalLeave> EmployeeAnnualLeavesAdditional { get; set; } = new();
        [NotMapped]
        public bool IsnolongerTrainer { get; set; }

        public int IdProfessionalTrainingTrainee { get; set; }
        public int IdProfessionalTraining { get; set; }
        public int SrNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedIn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedIn { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }
        [NotMapped]
        public bool IsNoLongerResponsible { get; set; }
        [NotMapped]
        public int? IdEmployeeBackup { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Employee EmployeeBackup { get; set; }

        public string EmployeeMainJDAbbreviation { get; set; }
        public string IsLongTermAbsentYesNo { get; set; }
        public string EmployeeStatusWithLongTermAbsent { get; set; }
        [NotMapped]
        public bool IsEmployeeStatus { get; set; }

        [NotMapped]
        public DateTime EmployeeContractSituationStartDate { get; set; }
        [NotMapped]
        public string EmployeeContractStartDate { get; set; }
        public string ProfileImagePath { get; set; }

        [NotMapped]
        public string ImageText { get; set; }

        [NotMapped]
        public uint IdApprovalResponsible { get; set; }
        [NotMapped]
        public uint IdExtraHoursTime { get; set; }
        [NotMapped]
        public uint IdEmployeeContact { get; set; }
        [NotMapped]
        public string EmployeeContactProfessionalEmail { get; set; }

        public bool IsProfileUpdate { get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }
        [NotMapped]
        public decimal BacklogHours { get; set; }
        [NotMapped]
        public decimal DailyWorkingHours { get; set; }

        [NotMapped]
        public List<EmployeeEquipmentAndTools> RequiredEquipmentList { get; set; } = new();
        [NotMapped]
        public List<EmployeeEquipmentAndTools> EmployeeEquipmentList { get; set; } = new();

        [NotMapped]
        public string EmployeeCodeWithIdGender { get; set; }
        [NotMapped]
        public int IdUser { get; set; }
        [NotMapped]
        public string UserName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}".Trim();
        }
    }
}