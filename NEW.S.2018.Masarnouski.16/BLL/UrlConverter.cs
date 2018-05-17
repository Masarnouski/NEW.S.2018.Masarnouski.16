using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;

namespace BLL
{
    public class UrlConverter:IUrlConverter
    {
        private ILogger logger;

        public UrlConverter(ILogger logger)
        {
            Logger = logger;
        }

        private ILogger Logger
        {
            set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(Logger));
                }

                logger = value;
            }
        }


        public IEnumerable<Uri> GetUri(IFileReader fileReader)
        {
            if (ReferenceEquals(fileReader, null))
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            foreach (var line in fileReader.GetNextLine())
            {
                if (VerifyURLAddress(line))
                {
                    yield return new Uri(line);
                }
            }
        }

        private bool VerifyURLAddress(string urlAddress)
        {

            string htmlRegexPattern = @"(^((http[s]?|ftp):\/)?\/?([^:\/\s]+)((\/\w+)*\/)([\w\-\.]+[^#?\s]+)(.*)?(#[\w\-]+)?$)*";


            if (String.IsNullOrEmpty(urlAddress))
            {

                logger.Warn(new ArgumentNullException($"URL is null or empty:{nameof(urlAddress)}"), "URL is null or empty");
            }

            if (Regex.IsMatch(urlAddress, htmlRegexPattern))
            {
                logger.Info($"URL {nameof(urlAddress)} has matched");
                return true;
            }
            else
            {
                logger.Warn(new ArgumentNullException($"Incoorect URL:{nameof(urlAddress)}"), "Incoorect URL");
                return false;
            }

        }
    }
}