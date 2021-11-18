using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestratorApp
{
    public class QueryEngine
    {
        const string URLEFDB = "https://localhost:44375/api/SearchedResults/";
        const string URLApiAdapter = "https://localhost:44308/api/ExternalAPI/";

        void InvokeAPI() { 
            

        
        }//end of InvokeAPI

        public void SearchDBFirst(string authorname,string bookname) {

            //Looks for similar information on the Database already searched



                //IF there isnt info then it will query the external APIs for it

                //Once information is found, the DB is updated with the new search 

            //returns response back

        }//end of SearchDBFirst

        public void SearchCloudFirst() {
            //invokes the externalAPIAdapter for the query 

            //updates the DB with the search result

        }//end of SearchCloudFirst
        
    }//end of class

}//end of namespace
