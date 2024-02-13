using MapsterMapper;
using MediatR;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Pharmacy.Commands.DeleteByIdCommand
{
    public record DeleteByIdCommand:IRequest<Response> {
        public int Id { get; set; }
    };

    internal class DeleteByIdCommandHandler : IRequestHandler<DeleteByIdCommand, Response>
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;

        public DeleteByIdCommandHandler(IUnitOfWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        public async Task<Response> Handle(DeleteByIdCommand command, CancellationToken cancellationToken)
        {
            var response=new Response();
            if (_unitofWork.Repository<Domain.Models.Pharmacy>().GetAsync(p => p.Id == command.Id) == null)
                return  await Response.FailureAsync("The pharmacy Don't Exist");
            var pharmacy =_mapper.Map<Domain.Models.Pharmacy>(command);
             await _unitofWork.Repository<Domain.Models.Pharmacy>().DeleteAsync(pharmacy.Id);
            return await Response.SuccessAsync("Successfull Operation");
        }
    }
}
