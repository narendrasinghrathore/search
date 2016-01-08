using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsingMvc.Models
{
    public class FindData
    {
        public static List<string> FindList(string term)
        {
           
            using (var en = new searchEngineEntities())
            {
                var list= en.tblWords.Where(w => w.Words.Contains(term)).Select(w => w.Words).ToList();
                return list;
            }
            
        }
    }
}