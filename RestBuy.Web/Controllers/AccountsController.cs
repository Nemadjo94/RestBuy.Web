using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RestBuy.Application.Services;
using RestBuy.Application.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestBuy.Web.Controllers
{
    [Route("[controller]")]
    public class AccountsController : Controller
    {

        readonly IRegistrationService registrationService;

        public AccountsController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult RegistrationForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(
            NewUserViewModel newUserViewModel,
            CancellationToken cancellationToken)           
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.registrationService.RegisterUser(newUserViewModel, cancellationToken);
                    return View("SuccesfullyRegistered");
                }
                catch(ValidationException exc)
                {
                    ModelState.AddModelError(nameof(newUserViewModel.Username), exc.Message);
                    SetSkippedIfValid(nameof(newUserViewModel.Password));
                    SetSkippedIfValid(nameof(newUserViewModel.ConfirmPassword));

                     void SetSkippedIfValid(string key)
                    {
                        if(ModelState.GetFieldValidationState(key) == ModelValidationState.Valid)
                        {
                            ModelState.MarkFieldSkipped(key);
                        }
                    }
                }
            }

            return View(nameof(RegistrationForm));

        }

       
    }
}
