using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayerWebApp.DTO;
using PlayerWebApp.Service;

namespace PlayerWebApp.Pages.Players
{
    public class CreateModel : PageModel
    {
		private readonly IPlayerService service;
        public string ErrorMessage { get; set; } = "";
        public string SuccessMessage { get; set; } = "";
        public PlayerDTO PlayerDTO { get; set; } = new();


        public CreateModel(IPlayerService service) { this.service = service; }


		public void OnGet() {}

        public void OnPost()
        {
            PlayerDTO.Username = Request.Form["username"];
            PlayerDTO.Password = Request.Form["password"];
            PlayerDTO.Email = Request.Form["email"];
            // Add validation layer & logic => error = validate(dto) return if error != ""

            try
            {
                bool exists = service.PlayerExists(PlayerDTO.Username, PlayerDTO.Email);
                if (exists)
                {
                    ErrorMessage = "Error. Username or e-mail already exist.";
                }
                else
                {
                    service.InsertPlayer(PlayerDTO);
                    SuccessMessage = "Player inserted succesfully.";
                    ResetFields();
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                throw;
            }
		}


        // Helper
        private void ResetFields()
        {
            PlayerDTO.Username = "";
            PlayerDTO.Password = "";
            PlayerDTO.Email = "";
		}
    }
}
