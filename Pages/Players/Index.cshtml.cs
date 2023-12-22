using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayerWebApp.Model;
using PlayerWebApp.Service;

namespace PlayerWebApp.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly IPlayerService service;
        public string? ErrorMessage { get; set; }
        public List<Player> Players { get; set; } = new();


        public IndexModel(IPlayerService service) { this.service = service; }


        public void OnGet()
        {
			ErrorMessage = "";

            try
            {
				Players = service.GetPlayerList();
            }
            catch (Exception e)
            {
				ErrorMessage = e.Message;
                //Response.Redirect("/Error");
            }
        }
    }
}
