using System;
using RestSharp;
using TechTalk.SpecFlow;

namespace WebApiCodeTest.Steps
{
    [Binding]
    public class StepsBase
    {
        protected RestClient Client;
        protected RestRequest Request;
        protected IRestResponse Response;

        protected readonly Uri BaseUri = new Uri("http://searchapi.asos.com");

        public StepsBase()
        {
            Client = new RestClient(BaseUri);
        }
    }
}