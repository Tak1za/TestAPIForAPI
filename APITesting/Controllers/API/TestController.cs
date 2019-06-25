using APITesting.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace APITesting.Controllers.API
{
    public class TestController : ApiController
    {
        //GET : /api/tests
        public async System.Threading.Tasks.Task<IHttpActionResult> GetTests()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://fakerestapi.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/activities");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var _Data = JsonConvert.DeserializeObject<List<Test>>(data);
                    return Ok(_Data);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                    return Ok();
                }
            }
        }

        public async System.Threading.Tasks.Task<IHttpActionResult> GetTest(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://fakerestapi.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/activities/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<Test>();
                    return Ok(data);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                    return Ok();
                }
            }
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IHttpActionResult> CreateTest()
        {
            Test test = new Test();
            test.Completed = true;
            test.ID = 527366;
            test.Title = "Yolo Solo";
            test.DueDate = DateTime.Now;

            string json = JsonConvert.SerializeObject(test);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://fakerestapi.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/activities", json);
                if (response.IsSuccessStatusCode)
                {
                    return Ok(json);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                    return Ok();
                }
            }
        }
    }
}
