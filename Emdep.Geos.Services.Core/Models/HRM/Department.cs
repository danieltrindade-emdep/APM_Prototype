using Emdep.Geos.Services.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Emdep.Geos.Core.Models
{
    public class Department
    {
        public uint IdDepartment { get; set; }
        public string DepartmentName { get; set; }
        public string Abbreviation { get; set; }
        public uint IdDepartmentParent { get; set; }
        public uint IdDepartmentArea { get; set; }
        public string DepartmentPosition { get; set; }
        public byte DepartmentInUse { get; set; }
        public string DepartmentHtmlColor { get; set; }
        public byte DepartmentIsIsolated { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Employee> Employees { get; set; } = new();
        [NotMapped]
        public List<JobDescription> JobDescriptions { get; set; } = new();
        [NotMapped]
        public List<Department> ChildDepartments { get; set; } = new();

        [NotMapped]
        public LookupValue DepartmentArea { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Department ParentDepartment { get; set; }
        [NotMapped]
        public uint EmployeesCount { get; set; }
        [NotMapped]
        public decimal YearsCount { get; set; }
        [NotMapped]
        public decimal EmployeesRecordCount { get; set; }

        public override string ToString() => DepartmentName;
    }
}