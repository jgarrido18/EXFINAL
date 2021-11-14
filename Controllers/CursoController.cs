using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EXFIN.Models;
namespace EXFIN.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            IEnumerable<CURSO> alobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var consumeapi = hc.GetAsync("CursoAPI");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<CURSO>>();
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
        public ActionResult Create(CURSO al)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var insertCli = hc.PostAsJsonAsync<CURSO>("CursoAPI", al);
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
            CursoClass objal = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var consumeAPI = hc.GetAsync("CursoAPI?id=" + id.ToString());
            consumeAPI.Wait();

            var readdata = consumeAPI.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayCliDetatails = readdata.Content.ReadAsAsync<CursoClass>();
                displayCliDetatails.Wait();
                objal = displayCliDetatails.Result;
            }
            return View(objal);
        }
        public ActionResult Edit(int id)
        {
            CursoClass objcli = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/");

            var consumeAPI = hc.GetAsync("CursoAPI?id=" + id.ToString());
            consumeAPI.Wait();

            var readdata = consumeAPI.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayCliDetatails = readdata.Content.ReadAsAsync<CursoClass>();
                displayCliDetatails.Wait();
                objcli = displayCliDetatails.Result;
            }
            return View(objcli);
        }

        [HttpPost]
        public ActionResult Edit(CursoClass al)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44338/api/CursoAPI");

            var updateal = hc.PutAsJsonAsync<CursoClass>("CursoAPI", al);
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
            hc.BaseAddress = new Uri("https://localhost:44338/api/CursoAPI");

            var deleteal = hc.DeleteAsync("CursoAPI/" + id.ToString());
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
