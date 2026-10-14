using System;
using System.IO;

namespace MunicipalServicesApp
{
    public static class DataPathHelper
    {
        public static string GetDataFilePath(string fileName)
        {
            // Application runs from:
            // bin\Debug\
            //
            // Move back to the project directory.
            string projectDirectory =
                Path.GetFullPath(
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        @"..\.."));

            // Project Data folder
            string dataDirectory =
                Path.Combine(projectDirectory, "Data");

            // Create Data folder if it does not exist
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            return Path.Combine(
                dataDirectory,
                fileName);
        }
    }
}