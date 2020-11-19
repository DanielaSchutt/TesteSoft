using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.ViewModels;

namespace TesteSoftDesign.WebAPI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserViewModel user)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["ApiUrl"]);


                var postTask = await client.PostAsJsonAsync<UserViewModel>("Login", user);


                //var result = postTask.
                if (postTask.IsSuccessStatusCode)
                {
                    var result = await postTask.Content.ReadAsAsync<UserViewModel>();
                    Session["token"] = result.Token;
                    Session["userId"] = result.Id;
                    return RedirectToRoute(new
                    {
                        controller = "Home",
                        action = "Index"
                    });
                }
            }

            ModelState.AddModelError(string.Empty, "Usuário ou senha incorretos");

            return View("Index");
        }
    }
}
