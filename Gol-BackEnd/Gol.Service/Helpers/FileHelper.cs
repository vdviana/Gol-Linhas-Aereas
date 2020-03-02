using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gol.Service.Helpers
{
    public static class FileHelper
    {

        public static FileStream ReadBytesToAFile(string fileName, byte[] dataArray)
        {

         

            new Random().NextBytes(dataArray);

            using (FileStream
                fileStream = new FileStream(fileName, FileMode.Create))
            {
             
                for (int i = 0; i < dataArray.Length; i++)
                {
                    fileStream.WriteByte(dataArray[i]);
                }

              
                fileStream.Seek(0, SeekOrigin.Begin);

              
                for (int i = 0; i < fileStream.Length; i++)
                {
                    if (dataArray[i] != fileStream.ReadByte())
                    {
                        Console.WriteLine("Error writing data.");

                    }
                }
                Console.WriteLine("The data was written to {0} " +
                    "and verified.", fileStream.Name);

                return fileStream;
            }



        }
    }
}
