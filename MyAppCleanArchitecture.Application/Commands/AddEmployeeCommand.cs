using MediatR;
using MyAppCleanArchitecture.Core.Entities;
using MyAppCleanArchitecture.Core.Interfaces;

namespace MyAppCleanArchitecture.Application.Commands
{
    public record AddEmployeeCommand(EmployeeEntity Employee):IRequest<EmployeeEntity>;
    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<AddEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
           return await employeeRepository.AddEmployeesAsync(request.Employee);
        }
    }
}
