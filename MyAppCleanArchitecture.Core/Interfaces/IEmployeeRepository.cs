using MyAppCleanArchitecture.Core.Entities;

namespace MyAppCleanArchitecture.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployees();
        Task<EmployeeEntity> GetEmployeesByIdAsync(Guid id);
        Task<EmployeeEntity> AddEmployeesAsync(EmployeeEntity employeeEntity);
        Task<EmployeeEntity> UpdateEmployeesAsync(Guid employeeID, EmployeeEntity employeeEntity);
        Task<bool> DeleteEmployeesAsync(Guid employeeID);

    }
}
