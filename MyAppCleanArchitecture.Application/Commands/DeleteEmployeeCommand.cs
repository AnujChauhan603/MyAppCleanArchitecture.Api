using MediatR;
using MyAppCleanArchitecture.Core.Entities;
using MyAppCleanArchitecture.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppCleanArchitecture.Application.Commands
{
    public record DeleteEmployeeCommand(Guid employeeId):IRequest<bool>;
    public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.DeleteEmployeesAsync(request.employeeId);
        }
    }
}
