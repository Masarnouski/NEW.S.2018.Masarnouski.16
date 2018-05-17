using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;

namespace BLL
{
    public class UrlConverter:IUrlConverter
    {
        private ILogger _logger;

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

                _logger = value;
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


            if (urlAddress == null)
                throw new ArgumentNullException("data is null");

            if (Regex.IsMatch(urlAddress, htmlRegexPattern))
                return true;
            else
                return false;

        }
    }
}