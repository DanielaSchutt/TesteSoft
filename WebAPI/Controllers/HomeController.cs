using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using TesteSoftDesign.ViewModels;

namespace TesteSoftDesign.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            if (Session["token"] != null)
            {
                IEnumerable<BookViewModel> books = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["ApiUrl"]);

                    var result = await client.GetAsync("book");

                    if (result.IsSuccessStatusCode)
                    {
                        var readtask = await result.Content.ReadAsAsync<IList<BookViewModel>>();


                        books = readtask;
                    }
                    else
                    {


                        books = Enumerable.Empty<BookViewModel>();

                        ModelState.AddModelError(string.Empty, "Problema no servidor");
                    }
                }


                return View(books);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> Search(string searchString)
        {
            if (Session["token"] != null)
            {
                IEnumerable<BookViewModel> books = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["ApiUrl"]);

                    var result = await client.GetAsync("book?searchString="+ searchString);

                    if (result.IsSuccessStatusCode)
                    {
                        var registers = await result.Content.ReadAsAsync<IList<BookViewModel>>();


                        books = registers;
                    }
                    else
                    {

                        books = Enumerable.Empty<BookViewModel>();

                        ModelState.AddModelError(string.Empty, "Problema no servidor");
                    }
                }

                return View("Index", books);

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
