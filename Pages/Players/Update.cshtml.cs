using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayerWebApp.DTO;
using PlayerWebApp.Model;
using PlayerWebApp.Service;

namespace PlayerWebApp.Pages.Players
{
    public class UpdateModel : PageModel
    {
		private readonly IPlayerService service;
		public string ErrorMessage { get; set; } = "";
		public string SuccessMessage { get; set; } = "";
		public PlayerDTO PlayerDto { get; set; } = new();


		public UpdateModel(IPlayerService service) { this.service = service; }


		public void OnGet()
		{
            try
			{
				Player? player;
				int id = int.Parse(Request.Query["id"]);
				player = service.GetPlayerById(id);
                PlayerDto = ConvertToDTO(player!);
            }
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}
		}


		public void OnPost()
		{
			PlayerDto.Id = int.Parse(Request.Form["id"]);
			PlayerDto.Username = Request.Form["username"];
			PlayerDto.Password = Request.Form["password"];
			PlayerDto.Email = Request.Form["email"];

			try
			{
				service.UpdatePlayer(PlayerDto);
				SuccessMessage = "Update succesful";
			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}
		}


		// Helper
		private PlayerDTO ConvertToDTO(Player player)
		{
			PlayerDTO dto = new()
			{
				Id = player.Id,
				Username = player.Username,
				Password = player.Password,
				Email = player.Email
			};
			return dto;
		}
    }
}
