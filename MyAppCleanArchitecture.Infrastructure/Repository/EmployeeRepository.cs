using Microsoft.EntityFrameworkCore;
using MyAppCleanArchitecture.Core.Entities;
using MyAppCleanArchitecture.Core.Interfaces;
using MyAppCleanArchitecture.Infrastructure.Data;

namespace MyAppCleanArchitecture.Infrastructure.Repository
{
    public class EmployeeRepository(AppDbContext appDbContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<EmployeeEntity>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
        }
        public async Task<EmployeeEntity> GetEmployeesByIdAsync(Guid id)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<EmployeeEntity> AddEmployeesAsync(EmployeeEntity employeeEntity)
        {
            employeeEntity.Id = Guid.NewGuid();
            appDbContext.Employees.Add(employeeEntity);
            await appDbContext.SaveChangesAsync();
            return employeeEntity;
        }
        public async Task<EmployeeEntity> UpdateEmployeesAsync(Guid employeeID, EmployeeEntity employeeEntity)
        {
            var employee = await appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeID);
            if (employee != null)
            {
                employee.Name = employeeEntity.Name;
                employee.Email = employeeEntity.Email;
                employee.Phome = employeeEntity.Phome;
                await appDbContext.SaveChangesAsync();
                return employee;
            }
            return employeeEntity;
        }

        public async Task<bool> DeleteEmployeesAsync(Guid employeeID)
        {
            var employee = await appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeID);
            if (employee != null)
            {
                appDbContext.Employees.Remove(employee);
                return await appDbContext.SaveChangesAsync() > 0;

            }
            return false;
        }
    }
}
