using Microsoft.AspNetCore.Mvc;
using RamenGoApi2.Models;

namespace RamenGoApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderRequest orderRequest)
        {
            if (orderRequest == null || string.IsNullOrEmpty(orderRequest.Broth) || string.IsNullOrEmpty(orderRequest.Protein))
            {
                return BadRequest("Invalid order request");
            }


            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf");
            var response = client.PostAsync("https://api.tech.redventures.com.br/orders/generate-id", null).Result;
            var orderId = response.Content.ReadAsStringAsync().Result;


            dynamic orderResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(orderId);
            string generatedOrderId = orderResponse.orderid;


            return Ok(new { orderId = generatedOrderId });
        }
    }
}
