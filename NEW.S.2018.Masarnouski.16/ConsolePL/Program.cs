using BLL;
using DAL;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DependencyResolver;
using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IXmlConverter xmlConverter = resolver.Get<IXmlConverter>();
            XDocument document = xmlConverter.GetXMLDocument(resolver.Get<IUrlConverter>(), resolver.Get<IFileReader>());
            document.Save("XML_result.xml");
        }
    }
}
