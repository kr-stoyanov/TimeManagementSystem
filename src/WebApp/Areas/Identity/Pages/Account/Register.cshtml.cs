using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Plugins.DataStore.MongoDb.Models;
using System.Security.Claims;

namespace WebApp.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public InputModel? Input { get; set; }

        public string?  ReturnUrl { get; set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");
            if (ModelState.IsValid && Input?.Password == Input?.ConfirmPassword)
            {
                var identity = new ApplicationUser { UserName = Input?.Email, Email = Input?.Email };
                var result = await this.userManager.CreateAsync(identity, Input?.Password);
                var claims = new List<Claim> 
                {
                    new Claim("firstName", Input.FirstName),
                    new Claim("lastName", Input.LastName)
                };
                var claimResult = await this.userManager.AddClaimsAsync(identity, claims);

                if (result.Succeeded && claimResult.Succeeded)
                {
                    await this.signInManager.CheckPasswordSignInAsync(identity, Input?.Password, lockoutOnFailure: false);
                    await this.signInManager.SignInAsync(identity, isPersistent: false);
                    return LocalRedirect(ReturnUrl);
                }
            }

            return Page();
        }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string? Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            public string? FirstName { get; set; }
            
            [Required]
            [Display(Name = "Last Name")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            public string? LastName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string? Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string? ConfirmPassword { get; set; }
        }
    }
}
