namespace PlayerWebApp.DTO
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }


        public override string? ToString()
        {
            return $"{Id} {Username} {Email}";
        }
    }
}
