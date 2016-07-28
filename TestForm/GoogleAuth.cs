using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestForm
{
    class GoogleAuth
    {
        private const string client_id = "1065091727549-3m9esrj40d6voqpo9gb8fqo81q271s9q.apps.googleusercontent.com";
        private const string client_secret = "0WIqdj1Eg_NiaV9RcaBYj-O5";


        private void Test()
        {
            string gurl = "code=" + "" + "&client_id=" + client_id +
          "&client_secret=" + client_secret + "&redirect_uri=" + "" + "&grant_type=" + "";

            string url = "https://www.googleapis.com/oauth2/v3/token";

            // creates the post data for the POST request
            string postData = (gurl);

            // create the POST request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Host = "www.googleapis.com";

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = postData.Length;

            // POST the data
            using (StreamWriter requestWriter2 = new StreamWriter(webRequest.GetRequestStream()))
            {
                requestWriter2.Write(postData);
            }

            //This actually does the request and gets the response back
            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();

            string googleAuth;

            using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                //dumps the HTML from the response into a string variable
                googleAuth = responseReader.ReadToEnd();
            }
        }
    }
}
