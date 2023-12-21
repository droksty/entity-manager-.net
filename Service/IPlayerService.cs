using PlayerWebApp.DTO;
using PlayerWebApp.Model;

namespace PlayerWebApp.Service
{
    public interface IPlayerService
    {
        void InsertPlayer(PlayerDTO? dto);
        void UpdatePlayer(PlayerDTO? dto);
        void DeletePlayer(int id);
        Player? GetPlayerById(int id);
        /*Player? GetPlayerByUsername(string? username);
        Player? GetPlayerByEmail(string? email);*/
        List<Player> GetPlayerList();
    }
}
