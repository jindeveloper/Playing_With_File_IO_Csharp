using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playing_With_File_IO_Csharp
{
    [TestClass]
    public class Explore_File_IO_Path
    {
        string projectPathLocation = string.Empty;

        [TestInitialize]
        public void Initialize()
        {
            projectPathLocation = AppConfig.ProjectPathLocation;
        }

        [TestMethod]
        [Priority(1)]
        public void Test_PathLocation_If_Has_FileExtension_And_CheckExtension()
        {
            //true because the path has a file extension
            Assert.IsTrue(Path.HasExtension(projectPathLocation));
            
            //gets the file extension
            string projectFileExtension = Path.GetExtension(projectPathLocation);
            
            //true because the file extension of the assembly is .dll
            Assert.IsTrue(projectFileExtension == ".dll"); 
        }

        [TestMethod]
        [Priority(2)]
        public void Test_Path_Method_GetFileName_Wihout_Extension()
        {
            //try to get the file-name only forget about the extension
            string fileName = Path.GetFileNameWithoutExtension(projectPathLocation);

            Assert.AreEqual(fileName, "Playing_With_File_IO_Csharp"); //true
        }

        [TestMethod]
        [Priority(3)]
        public void Test_Path_Method_GetFile_Then_Change_FileExtension()
        {
            string pattern = @"([^\\]+)\.{0}$"; //pattern to verify file extension

            string[] fileExtensions = new string[] { "txt", "docx" }; //file-type extension

            string fullPath = Path.Combine(projectPathLocation, "Playing_With_File_IO_Csharp.txt");

            Assert.IsTrue(Regex.IsMatch(fullPath, string.Format(pattern, fileExtensions[0]))); //true

            string changedPath = Path.ChangeExtension(fullPath, ".docx");

            Assert.IsTrue(Regex.IsMatch(changedPath, string.Format(pattern, fileExtensions[1]))); //true
        }

        [TestMethod]
        [Priority(4)]
        public void Test_Path_Method_GetTempFilePath_And_CreateTemporaryFile()
        {
            //gives you the location for the temporary folder
            string temporaryPath = System.IO.Path.GetTempPath();

            //lets just check if the temporary path do exists
            Assert.IsTrue(Directory.Exists(temporaryPath));

            //lets create a new (*.tmp) temporary file on disk
            string tempFileName = System.IO.Path.GetTempFileName();

            //lets check if the temporary file exists
            Assert.IsTrue(File.Exists(tempFileName)); 
        }
    }
}
