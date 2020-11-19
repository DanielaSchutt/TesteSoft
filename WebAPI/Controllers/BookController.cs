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
    public class BookController : Controller
    {

        public async Task<ActionResult> Details(int id)
        {
            if (Session["token"] != null)
            {
                var book = new BookViewModel();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["ApiUrl"]);

                    var result = await client.GetAsync("Book/" + id.ToString());

                    if (result.IsSuccessStatusCode)
                    {
                        var register = await result.Content.ReadAsAsync<BookViewModel>();

                        book = register;
                    }
                    else
                    {
                        book = null;

                        ModelState.AddModelError(string.Empty, "Problema no servidor");
                    }
                }

                return View(book);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public async Task<ActionResult> Put(int id)
        {
            if (Session["token"] != null)
            {
                var book = new BookViewModel();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["ApiUrl"]);

                    var result = await client.PutAsJsonAsync<BookViewModel>("Book/" + id.ToString() +"?userId=" + Session["userId"], book);

                    if (result.IsSuccessStatusCode)
                    {
                        var register = await result.Content.ReadAsAsync<BookViewModel>();

                        book = register;
                    }
                    else
                    {
                        book = null;

                        ModelState.AddModelError(string.Empty, "Problema no servidor");
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}
