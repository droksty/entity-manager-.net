using PlayerWebApp.Model;
using Microsoft.Data.SqlClient;
using System.Numerics;

namespace PlayerWebApp.DAO
{
    public class PlayerDAOImpl : IPlayerDAO
    {
        public void Insert(Player? player)
        {
            if (player == null) return;
            try
            {
                using SqlConnection? connection = DBLUtil.GetConnection();
                connection?.Open();
                string sql = "INSERT INTO player (username, password, email) VALUES (@username, @password, @email)";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@username", player.Username);
                command.Parameters.AddWithValue("@password", player.Password);
                command.Parameters.AddWithValue("@email", player.Email);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public void Update(Player? player)
        {
            if (player == null) return;
            try
            {
                using SqlConnection? connection = DBLUtil.GetConnection();
                connection?.Open();
                string sql = "UPDATE player SET username=@username, password=@password, email=@email WHERE id=@id";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@username", player.Username);
                command.Parameters.AddWithValue("@password", player.Password);
                command.Parameters.AddWithValue("@email", player.Email);
                command.Parameters.AddWithValue("@id", player.Id);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public void Delete(int id)
        {
            try
            {
                using SqlConnection? connection = DBLUtil.GetConnection();
                connection?.Open();
                string sql = "DELETE FROM player WHERE id=@id";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public Player? GetById(int id)
        {
            Player? player = null;
            try
            {
                using SqlConnection? connection = DBLUtil.GetConnection();
                connection?.Open();
                string sql = "SELECT FROM player WHERE id=@id";
                using SqlCommand command = new(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    player = new()
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Email = reader.GetString(3),
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return player;
        }


        public List<Player> GetAll()
        {
            List<Player> players = new();
            try
            {
                using SqlConnection? connection = DBLUtil.GetConnection();
                connection?.Open();
                string sql = "SELECT * player";
                using SqlCommand command = new(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Player player = new()
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Email = reader.GetString(3),
                    };
                    players.Add(player);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return players;
        }
    }
}
