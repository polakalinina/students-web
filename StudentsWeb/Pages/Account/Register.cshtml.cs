using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsWeb.DTOs;

namespace StudentsWeb.Pages.Account;

public class Register : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public Register(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    
    public IActionResult OnGet()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return Redirect("/");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPost(RegisterDto registerDto)
    {
        if (_signInManager.IsSignedIn(User))
        {
            return Redirect("/");
        }
        
        if (registerDto.Password != registerDto.RepeatPassword)
        {
            throw new Exception();
        }
        
        var user = new IdentityUser(registerDto.Login);
        await _userManager.CreateAsync(user, registerDto.Password);

        return Redirect("/Account/Login");
    }
}