using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelDataExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> extractValueList = new List<string>() { };

            string originalDir = "C:\\dev\\2016.11\\Windows\\Original";
            string testDir = "C:\\dev\\2016.11\\Windows\\Work\\test.xlsx";
            string[] OriginalFileArray = new string[500];


            FileManager fileManager = new FileManager();
            ExcelManager excelManager = new ExcelManager();

            OriginalFileArray = fileManager.CollectOriginalFile(originalDir);

            foreach (string OriginalFilePath in OriginalFileArray)
            {
                //fileManager.CreateWorkDirctory(OriginalFilePath);
                excelManager.ReadExcel(OriginalFilePath);
            }

            //excelManager.WriteExcel(testDir);
            Console.Write("Press any key....");
            Console.ReadKey(true);
        }
        
    }
}
