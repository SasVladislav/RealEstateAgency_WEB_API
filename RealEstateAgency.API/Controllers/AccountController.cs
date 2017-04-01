using Microsoft.Owin.Security;
using Ninject;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Interfaces;
using RealEstateAgency.BLL.Interfaces.GenericInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace RealEstateAgency.API.Controllers
{
    [RoutePrefix("Account")]
    public class AccountController : ApiController
    {
        IAuthentificationService<ClaimsIdentity> AuthServiceHttp;
        IAuthentificationService<string> AuthServiceWpf;
        IEmployeeService employeeService;
        public AccountController(IAuthentificationService<ClaimsIdentity> authServiceHttp,
                                 IAuthentificationService<string> authServiceWpf,
                                 IEmployeeService employeeService)
        {
            AuthServiceHttp = authServiceHttp;
            AuthServiceWpf = authServiceWpf;
            this.employeeService = employeeService;
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }
        [HttpGet]
        public IHttpActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<HttpResponseMessage> Login(LoginDto model)
        {
            // await SetInitialDataAsync();
            var response = Request.CreateResponse(HttpStatusCode.MovedPermanently);
            string fullyQualifiedUrl = "";
            
            //LoginDto model = new LoginDto { Email = "admin@gmail.com", Password = "123456" };
            if (ModelState.IsValid)
            {               
                UserDTO userDto = new UserDTO {Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await AuthServiceHttp.AuthenticateAsync(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    fullyQualifiedUrl = "/api/Home/GetIndex";
                    response.Headers.Location = new Uri(fullyQualifiedUrl, UriKind.Relative);
                    return response;
                    //return Redirect("Index", "Home");
                }
            }
            fullyQualifiedUrl = "/api/Account/Login";
            response.Headers.Location = new Uri(fullyQualifiedUrl, UriKind.Relative);
            return response;
        }

        [Route("LoginWPF")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<EmployeeDTO> LoginWPF(LoginDto model)
        {       
            if (ModelState.IsValid)
            {
                EmployeeDTO userDto = new EmployeeDTO { Email = model.Email, Password = model.Password };
                string employeeId = await AuthServiceWpf.AuthenticateAsync(userDto);
                if (employeeId != "")
                {

                    await employeeService.GetEmployeeByIdAsync(employeeId);
                    return await employeeService.GetEmployeeByIdAsync(employeeId);

                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
            }
            return null;
        }
        //public ActionResult Logout()
        //{
        //    AuthenticationManager.SignOut();
        //    return RedirectToAction("Index", "Home");
        //}

        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Register(RegisterModel model)
        //{
        //    await SetInitialDataAsync();
        //    if (ModelState.IsValid)
        //    {
        //        UserDTO userDto = new UserDTO
        //        {
        //            Email = model.Email,
        //            Password = model.Password,
        //            Address = model.Address,
        //            Name = model.Name,
        //            Role = "user"
        //        };
        //        OperationDetails operationDetails = await UserService.Create(userDto);
        //        if (operationDetails.Succedeed)
        //            return View("SuccessRegister");
        //        else
        //            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
        //    }
        //    return View(model);
        //}
        //private async Task SetInitialDataAsync()
        //{
        //    await UserService.SetInitialData(new UserDTO
        //    {
        //        Email = "somemail@mail.ru",
        //        UserName = "somemail@mail.ru",
        //        Password = "ad46D_ewr3",
        //        Name = "Семен Семенович Горбунков",
        //        Address = "ул. Спортивная, д.30, кв.75",
        //        Role = "admin",
        //    }, new List<string> { "user", "admin" });
        //}
    }
}
