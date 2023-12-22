using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayerWebApp.DTO;
using PlayerWebApp.Model;
using PlayerWebApp.Service;

namespace PlayerWebApp.Pages.Players
{
    public class DeleteModel : PageModel
    {
		private readonly IPlayerService service;
		public string ErrorMessage { get; set; } = "";
		public string SuccessMessage { get; set; } = "";


		public DeleteModel(IPlayerService service) { this.service = service; }


		public void OnGet()
		{
			try
			{
				int id = int.Parse(Request.Query["id"]);
				service.DeletePlayer(id);
				SuccessMessage = "Delete successful";
			}
			catch (Exception e)
			{
				ErrorMessage = e.Message;
			}
		}
    }
}
