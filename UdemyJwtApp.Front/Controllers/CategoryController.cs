using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UdemyJwtApp.Front.Models;

namespace UdemyJwtApp.Front.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> List()
        {
            var token = User.Claims.FirstOrDefault(x=> x.Type == "accesToken")?.Value;
            if (token != null) { 
            var client = this.httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                Console.WriteLine($"Token: {token}");
                var response =  await client.GetAsync("http://localhost:5008/api/categories");
               
                if (response.IsSuccessStatusCode) {
                
                   var jsonData =  await response.Content.ReadAsStringAsync();
                   var result = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    return View(result);
                }

            }
            return View();
        }
    }
}
