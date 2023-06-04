using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestProject3
{
    public class ProductData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }

    [Binding]
    public class PutProductStepDefinitions
    {
        RestClient client = new RestClient("http://demostore.gatling.io/");
        RestRequest request = new RestRequest("api/product/17", Method.Put);
        RestResponse response;
        string ID;

        [Given(@"I have an object with value")]
        public void GivenIHaveAnObjectWithValue(Table table)
        {
            var productData = table.CreateInstance<ProductData>();
            string jsonBody = JsonConvert.SerializeObject(productData);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            
        }

        [When(@"I send a get request to update")]
        public void WhenISendAGetRequestToUpdate()
        {
            response = client.Execute(request);
        }

        [Then(@"I expected a valid status code")]
        public void ThenIExpectedAValidStatusCode()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
        }
    }
}
