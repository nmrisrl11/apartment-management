using AutoMapper;
using Leasing.Application.Commands;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;

namespace Leasing.Application.CommandHandler
{
    public class LessorCommands : ILessorCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LessorCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LessorResponse> AddAsync(Guid id, string name, CancellationToken cancellationToken)
        {
            Lessor lessorToCreate = Lessor.Create(id, name);
            await _unitOfWork.Lessors.AddAsync(lessorToCreate);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LessorResponse>(lessorToCreate);
        }
    }
}
