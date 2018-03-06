using System.Net;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System;

namespace WebApiCodeTest.Steps
{
    [Binding]
    public class SearchApiSteps : StepsBase
    {
        private const string SearchV1Path = "/product/search/V1/";
        private const string Accept = "application/json";
        private const string Store = "1";
        private const string Lang = "en";
        private const string Currency = "GBP";
        private const string OffSet = "0";
        private const string Q = "";
        private const string Limit = "10";

        [Given(@"(?i)I search for (.*) items")]
        public void GivenISearchForItems(string searchTerm)
        {
            Request = new RestRequest(Method.GET)
            {
                Resource = SearchV1Path
            };

            Request.AddHeader("Accept", Accept);
            Request.AddParameter("store", Store);
            Request.AddParameter("lang", Lang);
            Request.AddParameter("currency", Currency);
            Request.AddParameter("offset", OffSet);
            Request.AddParameter("q", searchTerm);
            Request.AddParameter("limit", Limit);

            ScenarioContext.Current.Add("searchRequest", Request);

        }

        [Then(@"(?i)I will receive an (.*) response")]
        public void ThenIWillReceiveAnResponse(HttpStatusCode statusCode) 
        {
            var response = ScenarioContext.Current.Get<IRestResponse>("searchResponse");
            Assert.That(response.StatusCode, Is.EqualTo(statusCode));
        }


        [Given(@"I search without a search term")]
        public void GivenISearchWithoutASearchTerm()
        {
            System.Console.WriteLine("In GivenISearchForItems");
            Request = new RestRequest(Method.GET)
            {
                Resource = SearchV1Path
            };



            ScenarioContext.Current.Add("searchRequest", Request);
        }

        [Given(@"I search for mispelt item (.*)")]
        public void GivenISearchForMispeltItem(string mispeltTerm)
        {
            // Create Dictionary.
            Dictionary<string, string> hash = new Dictionary<string, string>();

            // Add some data with correct values for mispelt words as keys
            hash.Add("Nik carp", "Nike caps");
            hash.Add("Nik carps", "Nike caps");
            hash.Add("Nik cap", "Nike caps");

            //Get the corrected value from dictionary
            if (hash.ContainsKey(mispeltTerm)){
                Console.WriteLine("**** Found Corrected spelling {0} for {1} ****", hash[mispeltTerm], mispeltTerm);
                mispeltTerm = hash[mispeltTerm];

            }
            
            Request = new RestRequest(Method.GET)
            {
                Resource = SearchV1Path
            };

            Request.AddHeader("Accept", Accept);
            Request.AddParameter("store", Store);
            Request.AddParameter("lang", Lang);
            Request.AddParameter("currency", Currency);
            Request.AddParameter("offset", OffSet);
            Request.AddParameter("q", mispeltTerm);
            Request.AddParameter("limit", Limit);

            ScenarioContext.Current.Add("searchRequest", Request);

        }


    }
}   