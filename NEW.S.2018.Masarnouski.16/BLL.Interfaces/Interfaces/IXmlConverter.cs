using DAL.Interfaces.Interfaces;
using System;
using System.Xml.Linq;

namespace BLL.Interfaces.Interfaces
{
    public interface IXmlConverter
    {
        XDocument GetXMLDocument(IUrlConverter textToUrlConverter, IFileReader fileReader);
    }
}
