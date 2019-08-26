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
            Assert.IsTrue(Path.HasExtension(projectPathLocation));

            string projectFileExtension = Path.GetExtension(projectPathLocation);

            Assert.IsTrue(projectFileExtension == ".dll"); //true
        }

        [TestMethod]
        [Priority(2)]
        public void Test_Path_Method_GetFileName_Wihout_Extension()
        {
            string fileName = Path.GetFileNameWithoutExtension(projectPathLocation);

            Assert.AreEqual(fileName, "Playing_With_File_IO_Csharp"); //true
        }

        [TestMethod]
        public void Test_Path_Method_GetFile_Then_Change_FileExtension()
        {
            string pattern = @"([^\\]+)\.{0}$"; //pattern to verify file extension

            string[] fileExtensions = new string[] { "txt", "docx" }; //file-type extension

            string fullPath = System.IO.Path.Combine(projectPathLocation, "Playing_With_File_IO_Csharp.txt");

            Assert.IsTrue(Regex.IsMatch(fullPath, string.Format(pattern, fileExtensions[0])));

            string changedPath = System.IO.Path.ChangeExtension(fullPath, ".docx");

            Assert.IsTrue(Regex.IsMatch(changedPath, string.Format(pattern, fileExtensions[1])));
        }

        [TestMethod]
        public void Test_Path_Method_GetTempFilePath_And_CreateTemporaryFile()
        {
            string temporaryPath = System.IO.Path.GetTempPath(); //gives you the location for the temporary folder

            Assert.IsTrue(Directory.Exists(temporaryPath)); //lets just check if the temporary path do exists

            string tempFileName = System.IO.Path.GetTempFileName(); //lets create a new (*.tmp) temporary file on disk

            Assert.IsTrue(File.Exists(tempFileName)); //lets check if the temporary file exists

        }
    }
}
