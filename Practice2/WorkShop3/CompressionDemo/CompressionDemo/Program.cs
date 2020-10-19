using System;
using System.IO;
using System.IO.Compression;

namespace CompressionDemo
{
    class Program
    {
        public static void Compress(string sourceFile, string compressedFile)
        {
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); 
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }
        }

        public static void Decompress(string compressedFile, string targetFile)
        {
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(targetFile))
                {
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            string sourceFile = @"c:\boot.ini"; 
            string compressedFile = @"с:\boot.ini.gz"; 
            string targetFile = @"с:\boot.ini.gz"; 

            
            Compress(sourceFile, compressedFile);



            
            Decompress(compressedFile, targetFile);

            Console.ReadLine();
        }
    }
}
