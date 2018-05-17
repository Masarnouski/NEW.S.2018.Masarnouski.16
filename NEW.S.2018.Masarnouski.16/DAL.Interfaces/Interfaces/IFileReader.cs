using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Interfaces
{
    public interface IFileReader
    {
        string FilePath { set; }
        IEnumerable<string> GetNextLine();
    }
}
