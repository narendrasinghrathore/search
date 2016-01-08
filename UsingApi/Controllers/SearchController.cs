using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UsingApi.Data;
using Newtonsoft.Json;
using System.Web.Cors;
using System.Web.Http.Cors;
namespace UsingApi.Controllers
{
    
    public class SearchController : ApiController
    {
        
        // GET api/search

        public string Get()
        {
            using (var en = new searchEngineEntities())
            {
                var words = en.tblWords.Select(w => w.Words).ToList();
                return JsonConvert.SerializeObject(words);
            }
        }
       // GET api/search/id
        public string Get(int id)
        {
            return "Hi, " + id.ToString();
        }

        // POST api/search
        public void Post([FromBody]string value)
        {

        }

        // PUT api/search/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/search/5
        public void Delete(int id)
        {

        }
        [HttpGet]
        // Load all words
        public string All()
        {
            return "All good";
        }

        [HttpGet]
        // Find specific words
        public IEnumerable<string> Find(string word = "")
        {
            var term = word;
            if (term.Length > 0)
            {
                using (var en = new searchEngineEntities())
                {
                    var words = en.tblWords.Where(w => w.Words.Contains(term)).Select(w => w.Words).ToList();
                    return words.ToArray();
                }
            }
            else
            {
                return new string[] {};
            }
        }
    }
}
