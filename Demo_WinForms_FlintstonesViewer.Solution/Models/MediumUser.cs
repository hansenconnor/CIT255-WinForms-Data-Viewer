using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_WinForms_FlintstonesViewer
{
    public class MediumUser
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string profileUrl { get; set; }
        public string profileImageUrl { get; set; }

        //
        // SEE BELOW => Sample JSON response from APi
        //

        //  "id":"1d082c97938d3c4ceb54152619125181d164016ad373e48393cad0d889e3648c3",
        //"username":"hanse174",
        //"name":"Connor Hansen",
        //"url":"https://medium.com/@hanse174",
        //"imageUrl":"https://cdn-images-1.medium.com/fit/c/400/400/0*HhGsNYIsmXMI3fzt"
    }

    public class RootObject
    {
        public List<MediumUser> Data { get; set; }
    }
}
