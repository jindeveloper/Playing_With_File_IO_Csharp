using System.Collections.Generic;
using System.Reflection;

namespace Playing_With_File_IO_Csharp
{
    public static class AppConfig
    {
        public const string ProjectFiles = "project-files";

        public static string[] ProjectDirectories = new string[]
        {
            "App-Data-1",
            "App-Data-2",
            "App-Data-3"
        };

        public static Dictionary<string, string[]> projectDirectoriesWithChild = new Dictionary<string, string[]>
        {
            { "Directory-1", new string[] { "A", "B", "C", "D", "E" }},
            { "Directory-2", new string[] { "A", "B", "C", "D", "E",  }},
            { "Directory-3", new string[] { "A", "B", "C", "D", "E",  }},
            { "Directory-4", new string[] { "A", "B", "C", "D", "E",  }}
        };
        public static string ProjectPathLocation
        {
            get { return Assembly.GetExecutingAssembly().Location; }
        }
    }
}
