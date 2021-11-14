using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EXFIN.Models;

namespace EXFIN.Controllers
{
    public class CatedraticoController : Controller
    {
        // GET: Catedratico
        public ActionResult Index()
        {
            IEnumerable<catedratico> alobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var consumeapi = hc.GetAsync("CatedraticoAPI");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<catedratico>>();
                displaydata.Wait();
                alobj = displaydata.Result;
            }
            return View(alobj);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(catedratico al)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var insertCli = hc.PostAsJsonAsync<catedratico>("CatedraticoAPI", al);
            insertCli.Wait();

            var savedata = insertCli.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            CatedraticoClass objal = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var consumeAPI = hc.GetAsync("CatedraticoAPI?id=" + id.ToString());
            consumeAPI.Wait();

            var readdata = consumeAPI.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayCliDetatails = readdata.Content.ReadAsAsync<CatedraticoClass>();
                displayCliDetatails.Wait();
                objal = displayCliDetatails.Result;
            }
            return View(objal);
        }
        public ActionResult Edit(int id)
        {
            CatedraticoClass objcli = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var consumeAPI = hc.GetAsync("CatedraticoAPI?id=" + id.ToString());
            consumeAPI.Wait();

            var readdata = consumeAPI.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayCliDetatails = readdata.Content.ReadAsAsync<CatedraticoClass>();
                displayCliDetatails.Wait();
                objcli = displayCliDetatails.Result;
            }
            return View(objcli);
        }

        [HttpPost]
        public ActionResult Edit(CatedraticoClass al)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/CatedraticoAPI");

            var updateal = hc.PutAsJsonAsync<CatedraticoClass>("CatedraticoAPI", al);
            updateal.Wait();

            var savedata = updateal.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(al);
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/CatedraticoAPI");

            var deleteal = hc.DeleteAsync("CatedraticoAPI/" + id.ToString());
            deleteal.Wait();

            var savedata = deleteal.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }
    }
}
    