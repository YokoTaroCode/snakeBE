using SnakeBE.Domain; 
using SnakeBE.Domain.dto;

namespace SnakeBE.Application.services
{
    public class Mapper
    {
        /// <summary>
        /// Map Player to Player With Identity
        /// </summary>
        public Player IdentityModelToEntity(IdentifiedUserCreateModel model)
        {
            if (model == null) return null!;

            return new Player
            {
                Username = model.Username,
                IdentityUserId = model.IdentityUserId,
                SubDate = DateTime.Now, 
                Games = [] 
            };
        }

        /// <summary>
        /// Map Player to Web Player Dto
        /// </summary>
        public UserDto? UserToDto(Player user)
        {
            if (user == null) return null;

            return new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                SubDate = user.SubDate,     
                Games = user.Games?.Select(GameToDto).ToList() ?? []
            };
        }
        
        /// <summary>
        /// Map Game Dto to game entity
        /// </summary>
        public Game GameDtoToEntity(GameDto gameDto)
        {
            if (gameDto == null) return null!;

            return new Game
            {
                Points = gameDto.Points,
                Time = gameDto.Time,
                Date = gameDto.Date != default ? gameDto.Date : DateTime.Now,
                UserId = gameDto.UserId 
            };
        }

        /// <summary>
        /// Map entity Game to Game Dto
        /// </summary>
        public GameDto GameToDto(Game game)
        {
            if (game == null) return null!;

            return new GameDto
            {
                Id = game.GameId,
                Points = game.Points,
                Time = game.Time,
                Date = game.Date,
                UserId = game.UserId
            };
        }
    }
}
