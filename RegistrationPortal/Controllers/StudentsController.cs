using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RegistrationPortal.Extensions;
using RegistrationPortal.Models;

namespace RegistrationPortal.Controllers
{
    public class StudentsController : Controller
    {
        static readonly HttpClient _client = new HttpClient();

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var url = $"https://localhost:5041/api/v1/read";

            var token = HttpContext.Request.Cookies["UserToken"];

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(requestMessage);
            if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                return RedirectToAction("Login", "Auth");

            return View(await response.ReadContentAs<IList<StudentDto>>());

        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var url = $"https://localhost:5041/api/v1/read/{id}";

            var token = HttpContext.Request.Cookies["UserToken"];

            using (var requestMessage =
            new HttpRequestMessage(HttpMethod.Get, url))
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var response = await _client.SendAsync(requestMessage);
                if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                    return RedirectToAction("Login", "Auth");

                try
                {
                    var student = await response.ReadContentAs<StudentDto>();
                    return View(student);
                }
                catch (Exception)
                {
                    return NotFound();
                }
            }
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] StudentRequestModel model)
        {
            StudentDto student = null;
            StudentResponseModel responseModel = null;
            if (ModelState.IsValid)
            {
                var url = $"https://localhost:5041/api/v1/create";
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(url, content);
                responseModel = await response.ReadContentAs<StudentResponseModel>();
                if (!responseModel.Status)
                {
                    var message = responseModel.Message;
                    ViewBag.Message = message;
                    return View(model);
                }
                student = responseModel.StudentDto;
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var url = $"https://localhost:5041/api/v1/read/{id}";

            var token = HttpContext.Request.Cookies["UserToken"];

            using (var requestMessage =
            new HttpRequestMessage(HttpMethod.Get, url))
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                var response = await _client.SendAsync(requestMessage);
                if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                    return RedirectToAction("Login", "Auth");

                try
                {
                    var student = await response.ReadContentAs<StudentDto>();
                    return View(student);
                }
                catch (Exception)
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] StudentDto model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            StudentDto student = null;
            if (ModelState.IsValid)
            {
                var url = $"https://localhost:5041/api/v1/update/{id}";
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");


                var token = HttpContext.Request.Cookies["UserToken"];

                using var requestMessage = new HttpRequestMessage(HttpMethod.Put, url);
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                requestMessage.Content = content;
                
                var response = await _client.SendAsync(requestMessage);
                if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                    return RedirectToAction("Login", "Auth");

                try
                {
                    student = await response.ReadContentAs<StudentDto>();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var url = $"https://localhost:5041/api/v1/read/{id}";
      
            var token = HttpContext.Request.Cookies["UserToken"];

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(requestMessage);
            if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                return RedirectToAction("Login", "Auth");
       
            try
            {
                var student = await response.ReadContentAs<StudentDto>();
                return View(student);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var url = $"https://localhost:5041/api/v1/delete/{id}";

            var token = HttpContext.Request.Cookies["UserToken"];

            using var requestMessage = new HttpRequestMessage(HttpMethod.Delete, url);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(requestMessage);
            if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
                return RedirectToAction("Login", "Auth");

            return RedirectToAction(nameof(Index));
        }

    }
}
