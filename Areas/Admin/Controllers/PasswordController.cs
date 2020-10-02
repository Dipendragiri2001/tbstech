using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TBSTech.ViewModels;

namespace TBSTech.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PasswordController:Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public PasswordController(SignInManager<IdentityUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }
   
        public IActionResult ChangePassword()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user= await _userManager.GetUserAsync(User);
                if(user ==null)
                {
                    return RedirectToAction("Index");
                }
                var result = await _userManager.ChangePasswordAsync(user,
                model.CurrentPassword,model.NewPassword);
                if(!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,error.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction(nameof(ChangePassword));
            }
            return View(model);
        }

    }
}