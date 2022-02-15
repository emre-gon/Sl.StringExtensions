using System;
using System.Linq;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Text.RegularExpressions;
using System.Text;

namespace Sl.Extensions
{
    public static class FileExtensions
    {                       
        /// <summary>
        /// 'xxx.pdf' returns 'xxx'
        /// </summary>
        /// <param name="source"></param>
        /// <param name="Delimeter"></param>
        /// <returns></returns>
        public static string DeleteExtension(this string source, char Delimeter = '.')
        {
            if (source.IndexOf(Delimeter) < 0)
                return source;
            return source.Substring(0, source.LastIndexOf(Delimeter));
        }

        /// <summary>
        /// 'xxx.pdf' returns 'pdf'
        /// </summary>
        /// <param name="source"></param>
        /// <param name="Delimeter"></param>
        /// <returns></returns>
        public static string GetExtension(this string source, char Delimeter = '.')
            => source.Substring(source.LastIndexOf(Delimeter) + 1);


        public static string RenameFileIfExists(string FullFilePath)
        {
            int currentFileNumber = 1;
            while (File.Exists(FullFilePath))
            {

                string extension = "";
                int extensionIndex = FullFilePath.LastIndexOf('.');
                if (extensionIndex != -1)
                {
                    extension = FullFilePath.Substring(extensionIndex);
                    FullFilePath = FullFilePath.Substring(0, extensionIndex);
                }

                if (FullFilePath.Length != 0 && FullFilePath[FullFilePath.Length - 1] == ')')
                {
                    int openPranthesesIndex = FullFilePath.Length - 2;

                    bool isFound = false;
                    while (openPranthesesIndex >= 0)
                    {
                        if (FullFilePath[openPranthesesIndex] == '(')
                        {
                            isFound = true;
                            break;
                        }
                        openPranthesesIndex--;
                    }

                    if (isFound)
                    {
                        int fileNumber;
                        if (int.TryParse(FullFilePath.Substring(openPranthesesIndex + 1, FullFilePath.Length - 1 - openPranthesesIndex - 1), out fileNumber))
                        {
                            currentFileNumber = fileNumber + 1;
                            FullFilePath = FullFilePath.Substring(0, openPranthesesIndex);
                        }
                    }

                }



                FullFilePath += "(" + currentFileNumber + ")" + extension;

                currentFileNumber++;
            }

            return FullFilePath;
        }
    }
}
