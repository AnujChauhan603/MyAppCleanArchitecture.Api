using MediatR;
using MyAppCleanArchitecture.Core.Entities;
using MyAppCleanArchitecture.Core.Interfaces;

namespace MyAppCleanArchitecture.Application.Queries
{
    public record GetEmployeeByIdQuery(Guid employeeId):IRequest<EmployeeEntity>;
    public  class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeeByIdQuery, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployeesByIdAsync(request.employeeId);
        }
    }
}
