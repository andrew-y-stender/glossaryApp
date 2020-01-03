using GlossaryMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace GlossaryMVC.Controllers
{
    public class TermController : Controller
    {
        // GET: Term
        public ActionResult Index()
        {
            IEnumerable<mvcTermModel> termList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Term").Result;
            termList = response.Content.ReadAsAsync<IEnumerable<mvcTermModel>>().Result;
            return View(termList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcTermModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Term/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcTermModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcTermModel term)
        {
            if (term.TermID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Term", term).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Term/" + term.TermID, term).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Term/"+id.ToString()).Result;
            return RedirectToAction("Index");

        }
    }
}