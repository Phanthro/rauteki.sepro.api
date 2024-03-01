using AutoMapper;
using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;

namespace Rauteki.Fire.Api.Features.Usuario.Queries.ListarUsuarios;

public class ListarUsuarios
{

    public record Query(int ClienteId) : IQuery<IEnumerable<ListarUsuariosDto>>;

    public class Handler : IRequestHandler<Query, IEnumerable<ListarUsuariosDto>>
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IMapper _mapper;

        public Handler(IUsuarioRepository usuarioRepo, IMapper mapper)
        {
            _usuarioRepo = usuarioRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListarUsuariosDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var dbResult = await _usuarioRepo.ListarUsuarios(request.ClienteId);

            var result = dbResult.Select(x=> new ListarUsuariosDto{
                UsuarioId = x.UsuarioId,
                Email = x.Email,
                IsAtivo = x.IsAtivo,
                Nome = x.Nome
            });

            return result;
            
        }
    }

}