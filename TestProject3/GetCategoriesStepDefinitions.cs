using System;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;
namespace TestProject3
{
    [Binding]
    public class GetCategoriesStepDefinitions
    {
        RestClient client = new RestClient("http://demostore.gatling.io/");
        RestRequest request = new RestRequest("api/category/{category}", Method.Get);
        RestResponse response;
        string ID = null;

        [Given(@"I have an id categorie with value (.*)")]
        public void GivenIHaveAnIdCategorieWithValue(int p0)
        {
            request.AddUrlSegment("category", p0);
        }

        [When(@"I send a get request to API")]
        public void WhenISendAGetRequestToAPI()
        {
            response = client.Execute(request);
            var jsonObject = JObject.Parse(response.Content);
            ID = jsonObject.SelectToken("id").ToString();
        }

        [Then(@"I expected a valid code response \((.*)\)")]
        public void ThenIExpectedAValidCodeResponse(int p0)
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(ID, Is.EqualTo("5"));
        }
    }
}
