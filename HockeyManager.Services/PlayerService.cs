using HockeyManager.DataLayer;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            this._playerRepository = playerRepository;
        }

        public async Task<bool> CreatePlayerAsync(CreatePlayerRequest createPlayerRequest)
        {
            var newPlayer = new Player
            {
                PlayerId = Guid.NewGuid().ToString(),
                Name = createPlayerRequest.Name,
                Surname = createPlayerRequest.Surname,
                Captain = createPlayerRequest.Captain,
                Position = createPlayerRequest.Position
            };
            var result = _playerRepository.CreateAsync(newPlayer);
            if(!result)
                return false;
            await _playerRepository.SaveAsync();
            return true;
        }

        public async Task<bool> UpdatePlayerAsync(ChangePlayerRequest changePlayerRequest)
        {
            var findedPlayer = await _playerRepository.FindByIdAsync(changePlayerRequest.PlayerId);
            if (findedPlayer == null)
                return false;

            findedPlayer.Position = changePlayerRequest.Position;
            findedPlayer.Surname = changePlayerRequest.Surname;
            findedPlayer.Name = changePlayerRequest.Name;
            findedPlayer.Captain = changePlayerRequest.Captain;
            await _playerRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeletePlayerAsync(string id)
        {
            var findedEmployee = await _playerRepository.FindByIdAsync(id);
            if (findedEmployee == null)
                return false;
            _playerRepository.Delete(findedEmployee);
            await _playerRepository.SaveAsync();
            return true;
        } 
    }
}