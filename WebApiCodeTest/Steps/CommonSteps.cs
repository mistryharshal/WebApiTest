using TechTalk.SpecFlow;
using System;
using RestSharp;

namespace WebApiCodeTest.Steps
{
    [Binding]
    public class CommonSteps : StepsBase
    {
        [When(@"(?i)the response is received")]
        public void WhenIGetTheResponseBackFromApi()
        {
            var request = ScenarioContext.Current.Get<RestRequest>("searchRequest");
            Response = Client.Execute<dynamic>(request);
            ScenarioContext.Current.Add("searchResponse", Response);
        }
    }
}
