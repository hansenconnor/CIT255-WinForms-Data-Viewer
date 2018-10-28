using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Configuration;
using Newtonsoft.Json;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Demo_WinForms_FlintstonesViewer

{
    public class JsonDataService : IDataService
    {

        private string _apiBaseUrl;

        /// <summary>
        /// read the json response and load a list of user objects
        /// </summary>
        /// <returns>list of users</returns>
        public List<MediumUser> ReadAll()
        {
            List<MediumUser> users = new List<MediumUser>();
            // XmlSerializer serializer = new XmlSerializer(typeof(List<MediumUser>), new XmlRootAttribute("Characters")); // Probably remove this??


            // Get authorization token for use in request header
            var accessToken = System.Configuration.ConfigurationManager.AppSettings["Authorization"];
            //string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;


            //
            // Make the GET request
            //
            string html = string.Empty;
            string url = _apiBaseUrl; // => https://api.medium.com/v1/me


            //WebClient webClient = new WebClient();
            //JObject result = JObject.Parse(webClient.DownloadString("YOUR URL"));
            //reader = new JsonTextReader(new System.IO.StringReader(result.ToString()));
            //reader.SupportMultipleContent = true;

            // Create request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // Pass the access token 
            request.Headers["Authorization"] = accessToken;
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            Console.WriteLine(html);
            var userId = Convert.ToInt32(JObject.Parse(html)["data"]["id"]);

            MediumUser mediumUser = new MediumUser()
            {
                Id = userId,
                name = result.name,
                username = result.username,
               profileImageUrl = result.profileImageUrl,
                profileUrl = result.profileUrl
            };

            mediumUser.Id = result.id;

            Console.WriteLine(result);
            // we are going to return a list even though we are only querying one user.. But the user has multiple publications to list

            // TODO: Add JSON deserializer here => GET request returns a JSON object which needs to be parsed

            // TODO: Wrap the GET request inside of try catch

            // TODO: Parse JSON and return list of Users or Publications

            // List the users current publications => https://api.medium.com/v1/users/{{userId}}/publications
            // The User Id is retrieved from the get user request made previously...

            //try
            //{
            //    StreamReader reader = new StreamReader(_dataFilePath);
            //    using (reader)
            //    {
            //        users = (List<MediumUser>)serializer.Deserialize(reader);
            //    }

            //}
            //catch (Exception)
            //{
            //    throw; // all exceptions are handled in the ListForm class
            //}

            return users;
        }


        // TODO: Create new method to read all 
        // ALTERNATIVELY: Modify ReadAll method to take a Model type, and conditionally handle serialization



        /// <summary>
        /// write the current list of characters to the json data file
        /// </summary>
        /// <param name="characters">list of users</param>
        //public void WriteAll(List<MediumUser> characters)
        //{
        //    // TODO: Replace with JSON serialization.
        //    XmlSerializer serializer = new XmlSerializer(typeof(List<Character>), new XmlRootAttribute("Characters"));

        //    try
        //    {
        //        StreamWriter writer = new StreamWriter(_dataFilePath);
        //        using (writer)
        //        {
        //            serializer.Serialize(writer, characters);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public JsonDataService()
        {

        }


        //
        // Constructor
        //
        public JsonDataService(string apiPath)
        {
            _apiBaseUrl = apiPath;
        }
    }
}
