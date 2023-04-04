﻿using Common;
using MargoFetcher.Domain.Exceptions;
using MargoFetcher.Domain.Entities;
using MargoFetcher.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargoFetcher.Application.Players.Queries
{
    public record GetPlayersQuery(string server) : IRequest<GetPlayersResult>;
    public record GetPlayersResult(IEnumerable<Player> players);
    public class GetPlayersQueryHandler : IRequestHandler<GetPlayersQuery, GetPlayersResult>
    {
        private readonly IPlayerRepository _playerRepository;

        public GetPlayersQueryHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<GetPlayersResult> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
        {
            var result = await _playerRepository.GetAllPlayersByServer(request.server);

            if (result == null)
                throw new PlayerNotFoundException(ExceptionsMessages.PlayerNotFound);

            return new GetPlayersResult(result);
        }
    }
}