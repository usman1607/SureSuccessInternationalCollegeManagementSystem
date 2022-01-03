using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegistrationPortal.Extensions;
using RegistrationPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationPortal.Controllers
{
    public class AuthController : Controller
    {

        static readonly HttpClient _client = new HttpClient();

        public IActionResult Login()
        {
            ViewBag.Message = null;
            if (HttpContext.Request.Cookies["UserToken"] != null)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var url = $"https://localhost:5041/api/v1/login";
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(url, content);
                var token = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if(!response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Invalid email or password";
                    return View(model);
                }

                HttpContext.Response.Cookies.Append("UserToken", token);

                return RedirectToAction(nameof(Index), "Students");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("UserToken");
            return RedirectToAction(nameof(Login));
        }
    }
}
