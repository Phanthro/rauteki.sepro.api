using AutoMapper;
using Rauteki.Fire.Api.Features.Helpers;
using Rauteki.Fire.Api.Repositories.Interfaces;
using MediatR;

namespace Rauteki.Fire.Api.Features.Usuario.Queries.ObterUsuario;

public class ObterUsuario
{

    public record Query(int UsuarioId) : IQuery<ObterUsuarioDto>;

    public class Handler : IRequestHandler<Query, ObterUsuarioDto>
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IMapper _mapper;

        public Handler(IUsuarioRepository usuarioRepo, IMapper mapper)
        {
            _usuarioRepo = usuarioRepo;
            _mapper = mapper;
        }

        public async Task<ObterUsuarioDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var dbResult = await _usuarioRepo.ObterUsuarioById(request.UsuarioId);
            
            if(dbResult is null) throw new Exception("Usuário não encontrado.");

            var result = new ObterUsuarioDto()
                {
                    UsuarioId = dbResult.UsuarioId,
                    Email = dbResult.Email,
                    IsAtivo = dbResult.IsAtivo,
                    Nome = dbResult.Nome,
                    Telefone = dbResult.Telefone
                };

            return result;
            
        }
    }

}