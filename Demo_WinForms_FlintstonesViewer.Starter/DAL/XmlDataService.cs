using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Demo_WinForms_FlintstonesViewer

{
    public class XmlDataService : IDataService
    {
        private string _dataFilePath;

        /// <summary>
        /// read the xml file and load a list of character objects
        /// </summary>
        /// <returns>list of characters</returns>
        public List<Character> ReadAll()
        {
            List<Character> characters = new List<Character>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Character>), new XmlRootAttribute("Characters"));

            try
            {
                StreamReader reader = new StreamReader(_dataFilePath);
                using (reader)
                {
                    characters = (List<Character>)serializer.Deserialize(reader);
                }

            }
            catch (Exception)
            {
                throw; // all exceptions are handled in the ListForm class
            }

            return characters;
        }

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

        public XmlDataService()
        {

        }

        public XmlDataService(string datafile)
        {
            _dataFilePath = datafile;
        }
    }
}
