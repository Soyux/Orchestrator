using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SharedComms;

namespace EFDB.Model
{
    public class SearchedResult
    {

        int id;
        string autorname;
        string bookname;
        string jsonresponse;
        int foundOn;

        public int Id { get => id; set => id = value; }
        public string Autorname { get => autorname; set => autorname = value; }
        public string Bookname { get => bookname; set => bookname = value; }
        public string Jsonresponse { get => jsonresponse; set => jsonresponse = value; }
        public int FoundOn { get => foundOn; set => foundOn = value; }

        public SearchedResult() {

            FoundOn = (int)FoundType.NotFound;
        }
    }//end of class
}//end of namespace
