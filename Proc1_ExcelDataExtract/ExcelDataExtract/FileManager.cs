using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelDataExtract
{
    class FileManager
    {
        const string BaseDir = "C:\\dev\\2016.11\\Windows\\Work\\";
        const string REG = "\\01_REG";
        const string Dir_D = "\\02_Dir_D";
        const string Dir_Program_Files = "\\03_Dir_Program Files";
        const string Dir_Program_Files_x86 = "\\04_Dir_Program Files(x86)";

        const string REG_Reg_Name = "Reg_Name";
        const string REG_Name = "Name";
        const string REG_Publisher = "Publisher";
        const string REG_PATH = "PATH";
        const string REG_Version = "Version";

        public string[] CollectOriginalFile (string originalDir)
        {
            string[] fileNameArray = Directory.GetFiles(originalDir);
            return fileNameArray;
        }

        public void CreateWorkDirctory (string fileName)
        {

            string workingDir = BaseDir + "\\" + Path.GetFileName(fileName);
            DirectoryInfo workingDirChecker = new DirectoryInfo(workingDir);
            if (workingDirChecker.Exists == false)
            {
                workingDirChecker.Create();
                CreateDataDirectory(workingDir);
            }
        }

        private void CreateDataDirectory (string workingDir)
        {
            workingDir = Path.GetFileName(workingDir);

            DirectoryInfo REG_DirCreater = new DirectoryInfo(workingDir + REG);
            DirectoryInfo Dir_D_DirCreater = new DirectoryInfo(workingDir + Dir_D);
            DirectoryInfo ProgramFiles_DirCreater = new DirectoryInfo(workingDir + Dir_Program_Files);
            DirectoryInfo ProgramFiles_x86_DirCreater = new DirectoryInfo(workingDir + Dir_Program_Files_x86);

            REG_DirCreater.Create();
            Dir_D_DirCreater.Create();
            ProgramFiles_DirCreater.Create();
            ProgramFiles_x86_DirCreater.Create();
        }

        public void WriteData(string fileName, int sheetNumber, int category, List<string> columnData)
        {
            string sheetDir = "";
            string categoryName = "PATH&NAME";

            switch (sheetNumber)
            {
                case 1:
                    sheetDir = REG;
                    switch (category)
                    {
                        case 3:
                            categoryName = REG_Reg_Name;
                            break;
                        case 4:
                            categoryName = REG_Name;
                            break;
                        case 5:
                            categoryName = REG_Publisher;
                            break;
                        case 6:
                            categoryName = REG_PATH;
                            break;
                        case 7:
                            categoryName = REG_Version;
                            break;
                    }
                    break;
                case 2:
                    sheetDir = Dir_D;
                    break;
                case 3:
                    sheetDir = Dir_Program_Files;
                    break;
                case 4:
                    sheetDir = Dir_Program_Files_x86;
                    break;
            }

            string writePath = BaseDir + "Total" + sheetDir + "\\" + categoryName + ".txt";
            /* foreach로 기입하기
            StreamWriter columnDataWriter = new StreamWriter(writePath, true);
            
            foreach (string line in columnData)
            {
                columnDataWriter.WriteLine(line);
                Console.WriteLine(line);
            }
            */
            /* 텍스트로 넣기
            string writeData = string.Join("\n", columnData);
            File.WriteAllText(writePath, writeData);
            */
            /* 자동으로 라인 별 쓰기
            File.WriteAllLines(writePath, columnData);
            */
            File.AppendAllLines(writePath, columnData);

        }

        public void ReadData()
        {

        }
    }
}
