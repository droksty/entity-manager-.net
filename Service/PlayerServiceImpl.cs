using PlayerWebApp.DAO;
using PlayerWebApp.DTO;
using PlayerWebApp.Model;

namespace PlayerWebApp.Service
{
    public class PlayerServiceImpl : IPlayerService
    {
        private readonly IPlayerDAO dao;


        public PlayerServiceImpl(IPlayerDAO dao)
        {
            this.dao = dao;
        }


        /*
             
         */

        public void InsertPlayer(PlayerDTO? dto)
        {
            if (dto == null) return;
            Player? player = Convert(dto);
            try
            {
                dao.Insert(player);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public void UpdatePlayer(PlayerDTO? dto)
        {
            if (dto == null) return;
            Player? player = Convert(dto);
            try
            {
                dao.Update(player);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public void DeletePlayer(int id)
        {
            try
            {
                dao.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public Player? GetPlayerById(int id)
        {
            try
            {
                return dao.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public List<Player> GetPlayerList()
        {
            try
            {
                return dao.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public bool PlayerExists(string username, string email)
        {
            try
            {
                return dao.Exists(username, email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        /*
            Helper
         */
        private static Player? Convert(PlayerDTO dto)
        {
            return new Player() { Id = dto.Id, Username = dto.Username, Password = dto.Password, Email = dto.Email };
        }
    }
}
