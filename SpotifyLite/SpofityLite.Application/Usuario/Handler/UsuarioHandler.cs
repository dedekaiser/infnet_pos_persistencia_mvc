﻿using MediatR;
using SpofityLite.Application.Usuario.Handler.Command;
using SpofityLite.Application.Usuario.Handler.Query;
using SpofityLite.Application.Usuario.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Usuario.Handler
{

    public class UsuarioHandler : IRequestHandler<CreateUsuarioCommand, CreateUsuarioCommandResponse>,
                            IRequestHandler<GetAllUsuarioQuery, GetAllUsuarioQueryResponse>
    {
        private readonly IUsuarioService _UsuarioService;

        public UsuarioHandler(IUsuarioService UsuarioService)
        {
            _UsuarioService = UsuarioService;
        }

        public async Task<CreateUsuarioCommandResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._UsuarioService.Criar(request.usuario);
            return new CreateUsuarioCommandResponse(result);
        }

        public async Task<GetAllUsuarioQueryResponse> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await this._UsuarioService.ObterTodos();
            return new GetAllUsuarioQueryResponse(result);
        }
        public async Task<GetUsuarioQueryResponse> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await this._UsuarioService.ObterUm(request.IdUsuario);
            return new GetUsuarioQueryResponse(result);
        }

        public async Task<DeleteUsuarioCommandResponse> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            await this._UsuarioService.Deletar(request.IdUsuario);
            return new DeleteUsuarioCommandResponse();
        }

        public async Task<EditUsuarioCommandResponse> Handle(EditUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._UsuarioService.Editar(request.IdUsuario, request.Usuario);
            return new EditUsuarioCommandResponse(result);
        }
    }
}
