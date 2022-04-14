using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntegrationTesting.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly UserManager<IdentityUser> roleManager;
        public IList<string> MyRoles { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger, UserManager<IdentityUser> roleManager)
        {
            _logger = logger;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user2 = User;
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var user = await roleManager.FindByNameAsync("Admin@admin.se");
            MyRoles = await roleManager.GetRolesAsync(user);

            return Page();
        }
    }
}