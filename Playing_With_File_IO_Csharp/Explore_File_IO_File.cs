using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playing_With_File_IO_Csharp
{
    [TestClass]
    public class Explore_File_IO_File
    {
        string projectPathLocation = string.Empty;

        string projectFile_FullPath = string.Empty;

        [TestInitialize]
        public void Initialize()
        {
            projectPathLocation = AppConfig.ProjectPathLocation;

            projectFile_FullPath = Path.Combine(Path.GetDirectoryName(projectPathLocation), "project-files");
        }

        [TestMethod]
        public void Test_File_WriteAllText_And_ReadContent_Then_Compare_If_Equal()
        {

            //let's create a simple content
            StringBuilder content = new StringBuilder();

            content.AppendLine("Hello System.IO.File");

            content.AppendLine("File class");

            //convert the StringBuilder to String
            string fullContent = content.ToString();

            //get the filename
            string fullPathToFile = Path.Combine(projectFile_FullPath, "Playing_With_File_IO_Csharp_1.txt");

            //set to empty first the file
            File.WriteAllText(fullPathToFile, string.Empty, Encoding.UTF8);

            //put the content on the file
            File.WriteAllText(fullPathToFile, fullContent, Encoding.UTF8);

            //let us read the content the file
            string[] fileContent = File.ReadAllLines(fullPathToFile, Encoding.UTF8);

            //compare the file content to the one we declared
            Assert.AreEqual(string.Compare(fullContent, string.Format("{0}{1}", string.Join(Environment.NewLine, fileContent), Environment.NewLine)), 0);

        }

        [TestMethod]
        public void Test_File_WriteAllLines_And_ReadContent_Then_Compare_If_Equal_Using_Array()
        {
            string[] fileContents = new string[] { "Hello", "World", "File", "Class", "Welcome", "To", "The", "World", "Of", "System.IO" };

            string fullPathToFile = Path.Combine(projectFile_FullPath, "Playing_With_File_IO_Csharp_2.txt");

            File.WriteAllText(fullPathToFile, string.Empty, Encoding.UTF8);

            File.WriteAllLines(fullPathToFile, fileContents, Encoding.UTF8);

            //let us read the content the file
            string[] readFileContents = File.ReadAllLines(fullPathToFile, Encoding.UTF8);

            //compare the file content to the one we declared
            var result = Enumerable.SequenceEqual(fileContents, readFileContents);
            
            //true
            Assert.IsTrue(result);
        }
    }
}
