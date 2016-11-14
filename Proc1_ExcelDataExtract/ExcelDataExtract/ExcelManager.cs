using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel; // 엑셀
using System.Runtime.InteropServices;

namespace ExcelDataExtract
{
    class ExcelManager
    {
        const int REG = 1;
        const int Dir_D = 2;
        const int Dir_Program_Files = 3;
        const int Dir_Program_Files_x86 = 4;
        int[] sheetArray = new int[4] { REG, Dir_D, Dir_Program_Files, Dir_Program_Files_x86 };


        public void ReadExcel(string readPath)
        {
            string fileName = Path.GetFileName(readPath);
            string workingDir = Path.GetDirectoryName(readPath);

            FileManager fileManager = new FileManager();
            List<string> extractValueList = new List<string>() { };
            List<string> columnData = new List<string>();

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook originalWorkbook = excelApp.Workbooks.Open(readPath);

            foreach (int sheetNumber in sheetArray)
            {
                Excel.Worksheet originalWorksheet = (Excel.Worksheet)originalWorkbook.Worksheets.get_Item(sheetNumber);
                Excel.Range dataRange = originalWorksheet.UsedRange;

                object[,] sheetData = dataRange.Value;
                string cellData = "";

                if (sheetNumber == REG)
                {
                    for (int column = 3; column <= sheetData.GetLength(1); column++)
                    {
                        columnData.Clear();
                        for (int row = 4; row <= sheetData.GetLength(0); row++)
                        {
                            try
                            {
                                cellData = sheetData[row, column].ToString();
                            }
                            catch
                            {
                                cellData = " ";
                            }
                            columnData.Add(cellData);
                        }
                        if (column > 7) continue;
                        fileManager.WriteData(fileName, sheetNumber, column, columnData);
                    }

                }
                else
                {
                    columnData.Clear();
                    try
                    {
                        sheetData.GetLength(0);
                    }
                    catch
                    {
                        Console.WriteLine(readPath);
                        continue;
                    }
                    
                    for (int row = 4; row <= sheetData.GetLength(0); row++)
                    {
                        try
                        {
                            cellData = sheetData[row, 3].ToString();
                        }
                        catch
                        {
                            continue;
                        }
                        columnData.Add(cellData);
                    }
                    fileManager.WriteData(fileName, sheetNumber, 3, columnData);
                }
                ReleaseExcelObject(originalWorksheet);
            }
            originalWorkbook.Close(true);
            excelApp.Quit();
            
            ReleaseExcelObject(originalWorkbook);
            ReleaseExcelObject(excelApp);
        }

        public void WriteExcel(string savePath)
        {
            List<string> testData = new List<string>() { "Test1", "Test2", "Test3", "Test4" };

            Excel.Application excelApp = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;

            try
            {
                //첫번째 워크 시트 가져오기
                excelApp = new Excel.Application();

                excelApp.Visible = true; //엑셀 작업과정 보이기
                excelApp.Interactive = false; //사용자의 조작에 방해 받지 않기

                wb = excelApp.Workbooks.Add();
                ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;

                //데이터 넣기
                int r = 1;
                foreach (var d in testData)
                {
                    ws.Cells[r, 1] = d;
                    r++;
                }

                //엑셀 저장
                //wb.SaveAs(savePath, Excel.XlFileFormat.xlWorkbookNormal);
                //wb.Close(true);
                //excelApp.Quit();
            }
            finally
            {
                excelApp.Interactive = true;
                ReleaseExcelObject(ws);
                ReleaseExcelObject(wb);
                ReleaseExcelObject(excelApp);
            }
        }

        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
