using DAL.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Interfaces
{
    public interface IUrlConverter
    {
       IEnumerable<Uri> GetUri(IFileReader fileReader);
    }
}
