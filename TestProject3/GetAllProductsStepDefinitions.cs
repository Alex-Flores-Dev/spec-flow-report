using System;
using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;

namespace TestProject3
{
    [Binding]
    public class GetAllProductsStepDefinitions
    {
        RestClient client = new RestClient("http://demostore.gatling.io/");
        RestRequest request;
        RestResponse response;
        int countElements;

        [Given(@"the API endpoint ""([^""]*)""")]
        public void GivenTheAPIEndpoint(string p0)
        {
            request = new RestRequest($"api{p0}", Method.Get);
        }

        [When(@"a GET request is sent to the endpoint")]
        public void WhenAGETRequestIsSentToTheEndpoint()
        {
            response = client.Execute(request);
            var jsonObject = JArray.Parse(response.Content);
            countElements = jsonObject.Count;
        }

        [Then(@"a successful response with status code (.*) is received")]
        public void ThenASuccessfulResponseWithStatusCodeIsReceived(int p0)
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(countElements > 0, Is.EqualTo(true));
        }
    }
}
