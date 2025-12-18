using Emdep.Geos.Services.Core.Models;

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
        public string FullAddress { get; set; }
        public long AddressIdCountry { get; set; }

        public ushort Disability { get; set; }
        public byte IsEnabled { get; set; }
        public byte IsTrainer { get; set; }
        public string Remarks { get; set; }
        public int IdCompanyShift { get; set; }

        // Dependências (Agora usam os Placeholders se ainda não tiveres o ficheiro real)
        public LookupValue Gender { get; set; }
        public LookupValue MaritalStatus { get; set; }
        public Country Nationality { get; set; }
        public Country AddressCountry { get; set; }
        public CompanyShift CompanyShift { get; set; }

        // Listas de Detalhes
        public List<EmployeeContact> EmployeePersonalContacts { get; set; } = new();
        public List<EmployeeDocument> EmployeeDocuments { get; set; } = new();
        public List<EmployeeLanguage> EmployeeLanguages { get; set; } = new();
        public List<EmployeeEducationQualification> EmployeeEducationQualifications { get; set; } = new();
        public List<EmployeeContractSituation> EmployeeContractSituations { get; set; } = new();
        public List<EmployeeFamilyMember> EmployeeFamilyMembers { get; set; } = new();
        public List<EmployeeJobDescription> EmployeeJobDescriptions { get; set; } = new();
        public List<EmployeeChangelog> EmployeeChangelogs { get; set; } = new();
        public List<EmployeeContact> EmployeeProfessionalContacts { get; set; } = new();
        public List<EmployeeProfessionalEducation> EmployeeProfessionalEducations { get; set; } = new();

        public byte[] ProfileImageInBytes { get; set; }
        public bool IsProfileImageDeleted { get; set; }

        public EmployeeJobDescription EmployeeJobDescription { get; set; }
        public EmployeePolyvalence EmplyeePolyvalence { get; set; }

        // Contactos diretos
        public string EmployeeContactEmail { get; set; }
        public string EmployeeContactMobile { get; set; }
        public string EmployeeContactSkype { get; set; }
        public string EmployeeContactLandline { get; set; }
        public string EmployeeContactTraning { get; set; }
        public string EmployeeContactHome { get; set; }

        // Listas de Contactos da Empresa
        public List<string> EmployeeContactCompanyEmailList { get; set; } = new();
        public string EmployeeContactCompanyMobiles { get; set; }
        public List<string> EmployeeContactCompanyMobileList { get; set; } = new();
        public string EmployeeContactCompanySkypes { get; set; }
        public List<string> EmployeeContactCompanySkypeList { get; set; } = new();
        public string EmployeeContactCompanyLandlines { get; set; }
        public List<string> EmployeeContactCompanyLandlineList { get; set; } = new();
        public string EmployeeContactTranings { get; set; }
        public List<string> EmployeeContactTraningList { get; set; } = new();

        // Contactos Privados
        public List<string> EmployeeContactPrivateEmailList { get; set; } = new();
        public string EmployeeContactPrivateMobiles { get; set; }
        public List<string> EmployeeContactPrivateMobileList { get; set; } = new();

        public string EmployeeJobTitles { get; set; }
        public string EmployeePolyvalence { get; set; } // String descritiva
        public List<EmployeePolyvalence> EmployeePolyvalences { get; set; } = new(); // Lista detalhada

        public ContractSituation ContractSituation { get; set; }
        public int LengthOfService { get; set; }
        public int IdParent { get; set; }

        public List<EmployeeAnnualLeave> EmployeeAnnualLeaves { get; set; } = new();

        public string TotalWorkedHours { get; set; }
        public string TotalNonWorkingHours { get; set; }
        public TimeSpan? DayWorkedHours { get; set; }
        public DateTime? HireDate { get; set; }
        public string FullName => $"{FirstName} {LastName}".Trim();

        public int? IdEmployeeStatus { get; set; }
        public LookupValue EmployeeStatus { get; set; }

        // Saída (Exit)
        public DateTime? ExitDate { get; set; }
        public int? ExitIdReason { get; set; }
        public LookupValue ExitReason { get; set; }
        public string ExitRemarks { get; set; }
        public string ExitFileName { get; set; }
        public byte[] EmployeeExitDocInBytes { get; set; }
        public bool IsemployeeExitDocDeleted { get; set; }

        public List<string> EmployeeJobCodes { get; set; } = new();
        public EmployeeDocument EmployeeDocument { get; set; }

        public string Languages { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public EmployeeContractSituation EmployeeContractSituation { get; set; }

        public string EmpJobCodes { get; set; }
        public string EmpJobCodeAbbreviations { get; set; }
        public string LengthOfServiceString { get; set; }

        public List<EmployeeShift> EmployeeShifts { get; set; } = new();

        public string EmployeeDocNationalId { get; set; }
        public string EmployeeDocPassport { get; set; }
        public string EmployeeDocDrLicense { get; set; }
        public string EmployeeDocPubIns { get; set; }
        public string EmployeeDocPriIns { get; set; }
        public string EmployeeDocVisa { get; set; }
        public string EmployeeDocOther { get; set; }
        public string EmployeeDocClockId { get; set; }

        public List<EmployeeLeave> EmployeeLeave { get; set; } = new();

        public string EmployeeDepartments { get; set; }
        public string EmployeeCompanyAlias { get; set; }

        public byte IsLongTermAbsent { get; set; }
        public int? IdCompanyLocation { get; set; }
        public Company CompanyLocation { get; set; }
        public List<Department> LstEmployeeDepartments { get; set; } = new();

        public string Organization { get; set; }
        public string Company { get; set; }
        public string EmployeeDepartmentsHtmlColors { get; set; }
        public string EmployeeCompanyIds { get; set; }

        public EmployeeAnnualLeave EmployeeAnnualLeave { get; set; }
        public EmployeeExitEvent EmployeeExitEvent { get; set; }
        public List<EmployeeExitEvent> EmployeeExitEvents { get; set; } = new();

        public string EmployeeShiftNames { get; set; }
        public string EmployeeShiftScheduleNames { get; set; }
        public byte HasWelcomeMessageBeenReceived { get; set; }

        public string EmployeeExitDateInCurrentMonth { get; set; }
        public string EmployeeTransferredCompanyInCurrentMonth { get; set; }
        public bool IsEmployeeExitDateInCurrentMonth { get; set; }
        public bool IsEmployeeTransferredCompanyInCurrentMonth { get; set; }

        public DateTime JDStartDate { get; set; }
        public List<EmployeeAnnualAdditionalLeave> EmployeeAnnualLeavesAdditional { get; set; } = new();
        public bool IsnolongerTrainer { get; set; }

        public int IdProfessionalTrainingTrainee { get; set; }
        public int IdProfessionalTraining { get; set; }
        public int SrNo { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedIn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedIn { get; set; }

        public bool IsChecked { get; set; }
        public bool IsNoLongerResponsible { get; set; }
        public int? IdEmployeeBackup { get; set; }
        public Employee EmployeeBackup { get; set; }

        public string EmployeeMainJDAbbreviation { get; set; }
        public string IsLongTermAbsentYesNo { get; set; }
        public string EmployeeStatusWithLongTermAbsent { get; set; }
        public bool IsEmployeeStatus { get; set; }

        public DateTime EmployeeContractSituationStartDate { get; set; }
        public string EmployeeContractStartDate { get; set; }
        public string ProfileImagePath { get; set; }

        // Removido ImageSource OwnerImage (Incompatível com API)
        public string ImageText { get; set; }

        public uint IdApprovalResponsible { get; set; }
        public uint IdExtraHoursTime { get; set; }
        public uint IdEmployeeContact { get; set; }
        public string EmployeeContactProfessionalEmail { get; set; }

        public bool IsProfileUpdate { get; set; }
        public bool IsSelected { get; set; }
        public decimal BacklogHours { get; set; }
        public decimal DailyWorkingHours { get; set; }

        public List<EmployeeEquipmentAndTools> RequiredEquipmentList { get; set; } = new();
        public List<EmployeeEquipmentAndTools> EmployeeEquipmentList { get; set; } = new();

        public string EmployeeCodeWithIdGender { get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}".Trim();
        }
    }
}