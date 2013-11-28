using Aspose.Words;
using Aspose.Words.Saving;
using System;
using System.Collections.Generic;
using System.Text;

namespace aspose_dotnet_lib_testing.converters
{
    class WordConvert : Converter
    {
        public override long convert(string inputFile, int width, int height, string outputDir, int pageToProcess)
        {
            outputDir = outputDir + "/word/";
            dirClean(outputDir);
            createDir(outputDir);

            Document doc = new Document(inputFile);
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            ImageSaveOptions options = new ImageSaveOptions(SaveFormat.Jpeg);
            // px per inch
            options.Resolution = 72;
            options.JpegQuality = 100;
            options.PageCount = pageToProcess;
            for (int count = 0; count < pageToProcess; count++)
            {
                string outputFileName = outputDir + "/" + count + ".jpg";
                options.PageIndex = count;
                doc.Save(outputFileName, options);
            }
            long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            return end - start;
        }
    }
}
