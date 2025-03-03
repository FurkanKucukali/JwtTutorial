using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UdemyJwtApp.Front.Models;

namespace UdemyJwtApp.Front.Controllers
{
    [Authorize(Roles = "Admin,Member")]

    public class ProductController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> List()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = this.httpClientFactory.CreateClient();

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync("https://localhost:7134/api/products");
                if (response.IsSuccessStatusCode)
                {

                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<ProductListModel>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    return View(result);
                }

            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
