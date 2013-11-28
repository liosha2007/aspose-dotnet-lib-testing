using Aspose.Pdf;
using Aspose.Pdf.Devices;
using Aspose.Words.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace aspose_dotnet_lib_testing.converters
{
    class PdfConvert : Converter
    {
        public override long convert(string inputFile, int width, int height, string outputDir, int pageToProcess)
        {
            outputDir = outputDir + "pdf/";
            dirClean(outputDir);
            createDir(outputDir);

            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(inputFile);
            int count = 1;
            for (; count < pdfDocument.Pages.Count && (count - 1) < pageToProcess; count++)
            {
                using (FileStream imageStream = new FileStream(outputDir + count + ".jpg", FileMode.Create))
                {
                    Resolution resolution = new Resolution(72);
                    PageSize pageSize = new PageSize(width, height);
                    JpegDevice jpegDevice = new JpegDevice(pageSize, resolution, 100);
                    jpegDevice.Process(pdfDocument.Pages[count], imageStream);
                    imageStream.Close();
                }
            }
            long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            return end - start;
        }
    }
}
