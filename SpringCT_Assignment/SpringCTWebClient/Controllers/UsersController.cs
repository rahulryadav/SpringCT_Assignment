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
    public class UsersController : Controller
    {
        // GET: Users
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:56015/api/Users");
            HttpResponseMessage result = await client.GetAsync(client.BaseAddress);
            if (result.IsSuccessStatusCode)
            {
                List<Users> users = await result.Content.ReadAsAsync<List<Users>>();
                return View(users);
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            Users users = new Users();
            return View(users);
        }

        // POST: Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(Users users)
        {
            try
            {
                // TODO: Add insert logic here
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:56015/api/Users");
                HttpResponseMessage result = await client.PostAsJsonAsync(client.BaseAddress, users);
                if (result.IsSuccessStatusCode)
                {
                    Users _user = await result.Content.ReadAsAsync<Users>();
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

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
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

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:56015/api/Users");
            HttpResponseMessage result = await client.GetAsync($"{client.BaseAddress}/{id}");
            if (result.IsSuccessStatusCode)
            {
                Users user = await result.Content.ReadAsAsync<Users>();
                return View(user);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: Users/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:56015/api/Users");
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
