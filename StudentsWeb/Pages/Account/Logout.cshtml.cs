using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentsWeb.Pages.Account;

public class Logout : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public Logout(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }
    
    public IActionResult OnGet()
    {
        if (_signInManager.IsSignedIn(User))
        {
            _signInManager.SignOutAsync();
        }

        return Redirect("/");
    }
}