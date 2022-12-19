using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsWeb.DTOs;

namespace StudentsWeb.Pages.Account;

public class Login : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public Login(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }
    
    public IActionResult OnGet()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return Redirect("/");
        }

        return Page();
    }

    public async Task<IActionResult> OnPost(LoginDto loginDto)
    {
        if (_signInManager.IsSignedIn(User))
        {
            return Redirect("/");
        }

        var result = await _signInManager.PasswordSignInAsync(loginDto.Login, loginDto.Password, true, false);

        if (result.Succeeded)
        {
            return Redirect("/");
        }

        return Redirect("/Account/Register");
    }
}