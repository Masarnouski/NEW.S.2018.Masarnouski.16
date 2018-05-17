using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader reader = new FileReader("file.txt");
            NLogger logger = new NLogger(typeof(UrlConverter));
            UrlConverter converter = new UrlConverter(logger);
            List<Uri> urilist = converter.GetUri(reader).ToList();
            Console.ReadLine();
            XmlConverter xmlConverter = new XmlConverter();
            XDocument document = xmlConverter.GetXMLDocument(converter, reader);
            document.Save("XML_result.xml");
        }
    }
}
