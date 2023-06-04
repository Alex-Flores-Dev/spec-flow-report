using System;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;

namespace TestProject3
{
    [Binding]
    public class GetProductsStepDefinitions
    {
        RestClient client = new RestClient("http://demostore.gatling.io/");
        RestRequest request = new RestRequest("api/product/{product_id}", Method.Get);
        RestResponse response;
        string ID = null;

        [Given(@"I have an id with value (.*)")]
        public void GivenIHaveAnIdWithValue(int p0)
        {
            request.AddUrlSegment("product_id", p0);
        }

        [When(@"I send a get request")]
        public void WhenISendAGetRequest()
        {
            response = client.Execute(request);
            var jsonObject = JObject.Parse(response.Content);
            ID = jsonObject.SelectToken("id").ToString();
        }

        [Then(@"I expected a valid code response")]
        public void ThenIExpectedAValidCodeResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(ID,Is.EqualTo("17"));
        }
    }
}
