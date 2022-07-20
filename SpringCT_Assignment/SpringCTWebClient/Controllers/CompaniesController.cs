using SpringCTWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpringCTWebClient.Controllers
{
    public class CompaniesController : Controller
    {
        // GET: Companies
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:56015/api/Companies");
            HttpResponseMessage result = await client.GetAsync(client.BaseAddress);
            if (result.IsSuccessStatusCode)
            {
                List<Company> company = await result.Content.ReadAsAsync<List<Company>>();
                return View(company);
            }
            else
            {
                return View("Error");
            }
    
        }

        // GET: Companies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            Company company = new Company();
            return View(company);
        }

        // POST: Companies/Create
        [HttpPost]
        public async Task<ActionResult> Create(Company company)
        {
            try
            {
                // TODO: Add insert logic here
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:56015/api/Companies");
                HttpResponseMessage result = await client.PostAsJsonAsync(client.BaseAddress, company);
                if (result.IsSuccessStatusCode)
                {
                    Company _company = await result.Content.ReadAsAsync<Company>();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Companies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Companies/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:56015/api/Companies");
            HttpResponseMessage result = await client.GetAsync($"{client.BaseAddress}/{id}");
            if (result.IsSuccessStatusCode)
            {
                Company company = await result.Content.ReadAsAsync<Company>();
                return View(company);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: Companies/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:56015/api/Companies");
                HttpResponseMessage result = await client.DeleteAsync($"{client.BaseAddress}/{id}");
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
