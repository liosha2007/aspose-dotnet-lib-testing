using aspose_dotnet_lib_testing.converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace aspose_dotnet_lib_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //CONFIG
            int width = 960;
            int height = 1280;
            int pageToProcess = 5;
            int numOfCicles = 10;
            String pdfInputFile = Path.GetFullPath("input-pdf-file.pdf");
            String wordInputFile = Path.GetFullPath("input-doc-file.doc");
            String outputDir = "./directory-out/";
            long average;
            //END OF CONFIG
            /*
             * File convertion
             */
            //PDF CONVERTION
            PdfConvert pdf = new PdfConvert();
            Console.WriteLine("--------------- [ DETAILS ] ---------------");
            Console.WriteLine("File name: " + Path.GetFileName(pdfInputFile));
            Console.WriteLine("Image width: " + width + ", height: " + height);
            Console.WriteLine("--------------- [ RESULTS ] ---------------");
            for (int i = 1; i < pageToProcess; i++)
            {
                average = 0;
                for (int j = 0; j < numOfCicles; j++)
                {
                    long time = pdf.convert(pdfInputFile, width, height, outputDir, i);
                    if (time > 0)
                    {
                        average += time;
                    }
                }
                Console.WriteLine("Page count: " + i);
                Console.WriteLine("Time to extract images: " + average / numOfCicles + "ms");
                Console.WriteLine("-------------------------------------------");
            }

            //WORD CONVERTION
            WordConvert word = new WordConvert();
            Console.WriteLine("--------------- [ DETAILS ] ---------------");
            Console.WriteLine("File name: " + Path.GetFileName(wordInputFile));
            Console.WriteLine("Image width: " + width + ", height: " + height);
            Console.WriteLine("--------------- [ RESULTS ] ---------------");
            for (int i = 1; i < pageToProcess; i++)
            {
                average = 0;
                for (int j = 0; j < numOfCicles; j++)
                {
                    long time = word.convert(wordInputFile, width, height, outputDir, i);
                    if (time > 0)
                    {
                        average += time;
                    }
                }
                Console.WriteLine("Page count: " + i);
                Console.WriteLine("Time to extract images: " + average / numOfCicles + "ms");
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
