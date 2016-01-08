using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace UsingMvc.Models
{
    public class SearchClass
    {
        public string Term { get; set; }

        public List<string> WordsList { get; set; } 
    }
}