using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayerWebApp.DAO;
using PlayerWebApp.Model;
using PlayerWebApp.Service;

namespace PlayerWebApp.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly IPlayerService service;
        private string errorMessage = "";
        internal List<Player> players = new();


        public IndexModel(IPlayerService service) { this.service = service; }


        public void OnGet()
        {
            errorMessage = "";

            try
            {
                players = service.GetPlayerList();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
        }
    }
}
