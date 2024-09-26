using MediatR;
using MyAppCleanArchitecture.Core.Entities;
using MyAppCleanArchitecture.Core.Interfaces;

namespace MyAppCleanArchitecture.Application.Commands
{
    public record UpdateEmployeeCommand(Guid employeeId, EmployeeEntity employee) : IRequest<EmployeeEntity>;
    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<UpdateEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.UpdateEmployeesAsync(request.employeeId, request.employee);
        }
    }
}
