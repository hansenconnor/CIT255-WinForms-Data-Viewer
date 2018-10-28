using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_WinForms_FlintstonesViewer
{
    public interface IDataService
    {
        List<MediumPublication> ReadAll();
        //void WriteAll(List<MediumUser> characters);
    }
}
