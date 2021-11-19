using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedComms.Model;
namespace SharedComms
{
    public class Response
    {
        public string searched_authorname { get; set; }
        public string searched_bookname { get; set; }
        public List<Book> Books { get; set; }
        //int quantitymatches;

        public Response()
        {

            searched_authorname = "";
            searched_bookname = "";
            Books = new List<Book>();

        }
    }
}
