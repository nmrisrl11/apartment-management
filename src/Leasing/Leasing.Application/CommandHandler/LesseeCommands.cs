using AutoMapper;
using Leasing.Application.Commands;
using Leasing.Application.Response;
using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;

namespace Leasing.Application.CommandHandler
{
    public class LesseeCommands : ILesseeCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LesseeCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LesseeResponse> AddAsync(Guid id, string name, string email, string contactNumber, CancellationToken cancellationToken)
        {
            Lessee lesseeToCreate = Lessee.Create(id, name, email, contactNumber);
            await _unitOfWork.Lessees.AddAsync(lesseeToCreate);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LesseeResponse>(lesseeToCreate);
        }
    }
}
