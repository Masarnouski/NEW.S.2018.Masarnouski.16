using DAL.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FileReader:IFileReader
    {
        private string filePath;

        public FileReader(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(FilePath));
                }

                filePath = value;
            }
        }
     
        public IEnumerable<string> GetNextLine()
        {
            using (StreamReader fileStream = new StreamReader(filePath))
            {
                while (!fileStream.EndOfStream)
                {
                    yield return fileStream.ReadLine();
                }
            }
        }
    }
}