using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_WinForms_FlintstonesViewer
{
    public static class AppConfig
    {
        public static string dataFilePath = @"Data\FlintstoneCharacters.xml";

        // Set base url for Medium API
        public static string apiGetUserPath = "https://api.medium.com/v1/me";
    }
}
