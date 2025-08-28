using AutoMapper;
using Property.Application.Commands;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.Repositories;

namespace Property.Application.CommandHandler
{
    public class OwnerCommands : IOwnerCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OwnerCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OwnerResponse> AddAsync(Guid id, string name, CancellationToken cancellationToken)
        {
            Owner ownerToCreate = Owner.Create(id, name);
            await _unitOfWork.Owners.AddAsync(ownerToCreate);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OwnerResponse>(ownerToCreate);
        }
    }
}
