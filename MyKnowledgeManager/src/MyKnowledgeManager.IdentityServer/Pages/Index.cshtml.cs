using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyKnowledgeManager.IdentityServer.Models;
using MyKnowledgeManager.IdentityServer.Utilities;

namespace MyKnowledgeManager.IdentityServer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(
            ILogger<IndexModel> logger, 
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var applicationUsers = await _userManager.GetUsersInRoleAsync(CustomRoles.Administrator);

            if (applicationUsers is null || applicationUsers.Count is 0)
            {
                return Redirect("/Identity/Account/Register");
            }

            return Page();
        }
    }
}