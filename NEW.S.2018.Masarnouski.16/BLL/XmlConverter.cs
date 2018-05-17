using BLL.Interfaces.Interfaces;
using System;
using System.Web;
using System.Xml.Linq;
using DAL.Interfaces.Interfaces;

namespace BLL
{
    public class XmlConverter:IXmlConverter
    {
        public XDocument GetXMLDocument(IUrlConverter textToUrlConverter, IFileReader fileReader)
        {
            if (ReferenceEquals(textToUrlConverter, null))
            {
                throw new ArgumentNullException(nameof(textToUrlConverter));
            }

            if (ReferenceEquals(fileReader, null))
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            XDocument document = new XDocument();
            XElement urlAddresses = new XElement("urlAddresses");

            foreach (var uri in textToUrlConverter.GetUri(fileReader))
            {
                urlAddresses.Add(GetUrlAddress(uri));
            }

            document.Add(urlAddresses);

            return document;
        }


        private XElement GetUrlAddress(Uri uri)
        {
            XElement address = new XElement("urlAddress");

            address.Add(GetHostName(uri));
            address.Add(GetPathes(uri));
            address.Add(GetParameters(uri));

            return address;
        }

        private XElement GetHostName(Uri uri)
        {
            XElement host = new XElement("host");
            XAttribute hostName = new XAttribute("name", uri.Host);

            host.Add(hostName);

            return host;
        }

        private XElement GetPathes(Uri uri)
        {
            XElement pathes = new XElement("uri");

            foreach (var segment in uri.Segments)
            {
                string segmentValue = segment.Trim('/', ' ');

                if (!string.IsNullOrWhiteSpace(segmentValue))
                {
                    pathes.Add(new XElement("segment", segmentValue));
                }
            }

            return pathes;
        }

        private XElement GetParameters(Uri uri)
        {
            XElement parameters = new XElement("parameters");
            foreach (var key in HttpUtility.ParseQueryString(uri.Query).AllKeys)
            {
                XElement parametr = new XElement("parametr");
                parametr.Add(new XAttribute("value", HttpUtility.ParseQueryString(uri.Query)[key]));
                parametr.Add(new XAttribute("key", key));
                parameters.Add(parametr);
            }

            return parameters;
        }
    }
}
