using Emdep.Geos.Services.Core.Models;

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

        // Dependência: Employee (Já refatorado)
        public List<Employee> Employees { get; set; } = new();

        // Dependência: JobDescription (Já está no Placeholders.cs)
        public List<JobDescription> JobDescriptions { get; set; } = new();

        public List<Department> ChildDepartments { get; set; } = new();

        // Dependência: LookupValue (Já refatorado)
        public LookupValue DepartmentArea { get; set; }

        public Department ParentDepartment { get; set; }

        public uint EmployeesCount { get; set; }
        public decimal YearsCount { get; set; }
        public decimal EmployeesRecordCount { get; set; }

        public override string ToString() => DepartmentName;
    }
}