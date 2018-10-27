using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Configuration;

namespace Demo_WinForms_FlintstonesViewer

{
    public abstract class JsonDataService : IDataService
    {
        // Abstraction - We don't need the ReadAll method here as we are using GetUsers() instead.
        public abstract List<Character> ReadAll();

        private string _dataFilePath;

        /// <summary>
        /// read the json response and load a list of user objects
        /// </summary>
        /// <returns>list of users</returns>
        public List<MediumUser> GetUsers()
        {
            List<MediumUser> users = new List<MediumUser>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<MediumUser>), new XmlRootAttribute("Characters")); // Probably remove this??


            // Get header info for request
            string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

            var value = System.Configuration.ConfigurationManager.AppSettings["key"];

            //
            // Make the GET request
            //
            string html = string.Empty;
            string url = @"https://api.stackexchange.com/2.2/answers?order=desc&sort=activity&site=stackoverflow";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            Console.WriteLine(html);
            // TODO: Add JSON deserializer here => GET request returns a JSON object which needs to be parsed.


            
            try
            {
                StreamReader reader = new StreamReader(_dataFilePath);
                using (reader)
                {
                    users = (List<MediumUser>)serializer.Deserialize(reader);
                }

            }
            catch (Exception)
            {
                throw; // all exceptions are handled in the ListForm class
            }

            return users;
        }


        // TODO: Create new method to read all 
        // ALTERNATIVELY: Modify ReadAll method to take a Model type, and conditionally handle serialization



        /// <summary>
        /// write the current list of characters to the xml data file
        /// </summary>
        /// <param name="characters">list of characters</param>
        public void WriteAll(List<Character> characters)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Character>), new XmlRootAttribute("Characters"));

            try
            {
                StreamWriter writer = new StreamWriter(_dataFilePath);
                using (writer)
                {
                    serializer.Serialize(writer, characters);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonDataService()
        {

        }


        //
        // Constructor
        //
        public JsonDataService(string datafile)
        {
            _dataFilePath = datafile;
        }
    }
}
