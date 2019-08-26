using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.AccessControl;

namespace Playing_With_File_IO_Csharp
{
    [TestClass]
    public class Explore_File_IO_Directory
    {
        string projectPathLocation = string.Empty;

        [TestInitialize]
        public void Initialize()
        {
            projectPathLocation = AppConfig.ProjectPathLocation;
        }

        [TestMethod]
        [Priority(1)]
        public void Test_ProjectPath_Create_Directory()
        {
            //get the directory-name
            string directoryName = Path.GetDirectoryName(projectPathLocation);

            //App-Data-1 as our directory-name
            string directoryToCreate = AppConfig.ProjectDirectories[0];

            //uses the Path class to combine the two string to create a full path
            string fullPath = Path.Combine(directoryName, directoryToCreate);

            //check whether is exists
            bool exists = Directory.Exists(fullPath);

            if (!exists)
            {
                //Create a new directory
                var result = Directory.CreateDirectory(fullPath);

                //verifies if not null 
                Assert.IsNotNull(result);

                //verifies if the instance type is DirectoryInfo
                Assert.IsInstanceOfType(result, typeof(DirectoryInfo));
            }
        }

        [TestMethod]
        [Priority(2)]
        public void Test_ProjectPath_Delete_Directory()
        {
            string directoryName = Path.GetDirectoryName(projectPathLocation);

            string directoryToCreate = AppConfig.ProjectDirectories[0];

            string fullPath = Path.Combine(directoryName, directoryToCreate);

            bool exists = Directory.Exists(fullPath);

            if (exists)
            {
                Directory.Delete(fullPath);

                Assert.IsFalse(Directory.Exists(fullPath));
            }
        }

        [TestMethod]
        [Priority(3)]
        public void Test_ProjectPath_Create_Multiple_Directories_With_SubDirectories()
        {
            string directoryName = Path.GetDirectoryName(projectPathLocation);

            foreach (var item in AppConfig.projectDirectoriesWithChild)
            {
                foreach (var child in item.Value)
                {
                    string fullPath = Path.Combine(directoryName, item.Key, child);

                    var result = Directory.CreateDirectory(fullPath);

                    Assert.IsNotNull(result);
                    Assert.IsInstanceOfType(result, typeof(DirectoryInfo));
                }
            }
        }

        [TestMethod]
        [Priority(4)]
        public void Test_Project_Delete_Directory_Including_SubDirectories()
        {
            string directoryName = Path.GetDirectoryName(projectPathLocation);

            foreach (var item in AppConfig.projectDirectoriesWithChild)
            {
                string fullPath = Path.Combine(directoryName, item.Key);

                var childDirectories = Directory.GetDirectories(fullPath);

                Assert.IsTrue(childDirectories.Length > 0);

                if (childDirectories.Length > 0)
                {
                    Directory.Delete(fullPath, true);
                }

                Assert.IsFalse(Directory.Exists(fullPath));
            }
        }

        [TestMethod]
        [Priority(5)]
        public void Test_Create_Directory_With_Directory_Security()
        {
            string directoryName = Path.GetDirectoryName(projectPathLocation);

            foreach (var item in AppConfig.projectDirectoriesWithChild)
            {
                foreach (var child in item.Value)
                {
                    string fullPath = Path.Combine(directoryName, item.Key, child);

                    if (!Directory.Exists(fullPath))
                    {
                        DirectoryInfo directoryInfo = Directory.CreateDirectory(fullPath);

                        Assert.IsNotNull(directoryInfo);
                        Assert.IsInstanceOfType(directoryInfo, typeof(DirectoryInfo));

                        DirectorySecurity directorySecurity = new DirectorySecurity();

                        directorySecurity.AddAccessRule(new FileSystemAccessRule("Power Users", FileSystemRights.FullControl, AccessControlType.Allow));
                        directorySecurity.AddAccessRule(new FileSystemAccessRule("Guests", FileSystemRights.Delete, AccessControlType.Deny));

                        directoryInfo.SetAccessControl(directorySecurity);
                    }
                }
            }
        }
    }
}
