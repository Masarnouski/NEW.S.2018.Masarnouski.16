using BLL;
using BLL.Interfaces.Interfaces;
using DAL;
using DAL.Interfaces.Interfaces;
using Ninject;

namespace DependencyResolver
{
    public static class DependencyConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IFileReader>().To<FileReader>().WithConstructorArgument("file.txt");
            kernel.Bind<ILogger>().To<NLogger>().WithConstructorArgument(typeof(UrlConverter));
            kernel.Bind<IUrlConverter>().To<UrlConverter>();
            kernel.Bind<IXmlConverter>().To<XmlConverter>();
        }
    }
}
