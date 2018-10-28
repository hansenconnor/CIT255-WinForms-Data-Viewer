using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_WinForms_FlintstonesViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        // GET request for authorization => https://medium.com/m/oauth/authorize?client_id=435ebff2a47&scope=basicProfile,publishPost,listPublications&state=gogogo&response_type=code&redirect_uri=https://webhook.site/fd7b5ad3-a6a0-4902-881f-91881ade1097
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ListForm());
        }
    }
}
