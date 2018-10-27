using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_WinForms_FlintstonesViewer
{
    public class Character
    {
        public enum GenderType { Male, Female }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public string ImageFileName { get; set; }
        public string Description { get; set; }

        public string FullName()
        {
            return FirstName + (LastName != null ? " " + LastName : "") ;
        }
    }
}
