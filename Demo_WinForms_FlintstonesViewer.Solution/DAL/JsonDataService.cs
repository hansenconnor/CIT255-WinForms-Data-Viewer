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
        /// read the json response and load a list of publications
        /// </summary>
        /// <returns>list of users</returns>
        public List<MediumPublication> ReadAll()
        {

            // Get authorization token for use in request header
            var accessToken = System.Configuration.ConfigurationManager.AppSettings["Authorization"];


            //
            // Make the GET request
            //
            string html = string.Empty;
            string url = _apiBaseUrl; // => https://api.medium.com/v1/me

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

            // Grab the values from the JSON string
            var userId = JObject.Parse(html)["data"]["id"].ToString();
            var userName = JObject.Parse(html)["data"]["name"].ToString();
            var userUsername = JObject.Parse(html)["data"]["username"].ToString();
            var userProfileImageUrl = JObject.Parse(html)["data"]["imageUrl"].ToString();
            var userProfileUrl = JObject.Parse(html)["data"]["url"].ToString();

            MediumUser mediumUser = new MediumUser()
            {
                Id = userId,
                name = userName,
                username = userUsername,
                profileImageUrl = userProfileImageUrl,
                profileUrl = userProfileUrl
            };


            //
            // Make another call to retrieve a listof user publications
            //
            userId = userId.Replace("\"", "");
            string publicationUrl = "https://api.medium.com/v1/users/" + userId + "/publications";

            // Create request
            request = (HttpWebRequest)WebRequest.Create(publicationUrl);
            // Pass the access token 
            request.Headers["Authorization"] = accessToken;
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var publications = JObject.Parse(html);

            // Create a list to store the publications
            List<MediumPublication> MediumPublications = new List<MediumPublication>();

            foreach (var publication in publications["data"])
            {
                MediumPublication mediumPublication = new MediumPublication()
                {
                    Id = (string)publication.SelectToken("id"),
                    name = (string)publication.SelectToken("name"),
                    description = (string)publication.SelectToken("description"),
                    url = (string)publication.SelectToken("url"),
                    imageUrl = (string)publication.SelectToken("imageUrl"),
                };
                MediumPublications.Add(mediumPublication);
            };

            return MediumPublications;
        }


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
