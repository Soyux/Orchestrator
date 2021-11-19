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
        string? searched_authorname;
        string? searched_bookname;
        string bookobject;

        public int Id { get => id; set => id = value; }
        public string Searched_authorname { get => searched_authorname; set => searched_authorname = value; }
        public string Searched_bookname { get => searched_bookname; set => searched_bookname = value; }
        public string Bookobject { get => bookobject; set => bookobject = value; }



        public SearchedResult()
        {
            Id = 0;
            Searched_authorname = "";
            Searched_bookname = "";
            Bookobject = "";

        }


    }//end of class
}//end of namespace
