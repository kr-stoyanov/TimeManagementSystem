using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugins.DataStore.MongoDb.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public InputModel? Input { get; set; }

        public string? ReturnUrl { get; set; }

        public void OnGet() => ReturnUrl = Url.Content("~/");
        
        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");
            if (ModelState.IsValid)
            {
                var identity = await this.userManager.FindByEmailAsync(Input?.Email);
                var result = await this.signInManager.CheckPasswordSignInAsync(identity, Input?.Password, false);
                await this.signInManager.SignInAsync(identity, true);
                if (result.Succeeded) return LocalRedirect(ReturnUrl);
            }

            return Page();
        }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string? Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }
        }
    }
}
