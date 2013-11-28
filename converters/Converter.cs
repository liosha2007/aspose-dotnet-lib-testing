using System;
using System.Collections.Generic;
using System.Text;

namespace aspose_dotnet_lib_testing.converters
{
    abstract class Converter
    {
        public abstract long convert(String inputFile, int width, int height, String outputDir, int pageToProcess);

        public void dirClean(String outputDir)
        {
            Thread.Sleep(100);
            if (Directory.Exists(outputDir))
            {
                Directory.Delete(outputDir, true);
            }
        }

        protected void createDir(String path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
