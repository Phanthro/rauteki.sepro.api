using AutoMapper;
using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;

namespace Rauteki.Fire.Api.Features.Usuario.Queries.ObterPermissoesUsuario;

public class ObterPermissoesUsuario
{

    public record Query(int usuarioId) : IQuery<IEnumerable<ObterPermissoesUsuarioDto>>;

    public class Handler : IRequestHandler<Query, IEnumerable<ObterPermissoesUsuarioDto>>
    {
        private readonly IUsuarioRepository _addressRepo;
        private readonly IMapper _mapper;

        public Handler(IUsuarioRepository addressRepo, IMapper mapper)
        {
            _addressRepo = addressRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ObterPermissoesUsuarioDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var dbResult = await _addressRepo.ObterPermissoesPaginaUsuario(request.usuarioId);

            var result = dbResult.Select(x=> new ObterPermissoesUsuarioDto{
                UsuarioId = x.UsuarioId,
                PermissaoId = x.PaginaId
            });

            return result;
            
        }
    }

}