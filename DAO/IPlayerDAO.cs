using PlayerWebApp.Model;

namespace PlayerWebApp.DAO
{
    public interface IPlayerDAO
    {
        void Insert(Player? player);
        void Update(Player? player);
        void Delete(int id);
        Player? GetById(int id);
        /*Player? GetByUsername(string username);
        Player? GetByEmail(string email);*/
        List<Player> GetAll();
        bool Exists(string username, string email);
    }
}
