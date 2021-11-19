using System;
using System.Collections.Generic;
using System.Text;

namespace SharedComms.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public List<string> Authors { get; set; }

        public Book() {
            Title = "";
            Publisher = "";
            Authors = new List<string>();
        
        }

    }//end of class
}//end of namespace
