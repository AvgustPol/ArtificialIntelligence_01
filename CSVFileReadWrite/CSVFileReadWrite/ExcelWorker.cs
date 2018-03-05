using CsvHelper;
using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVFileReadWrite
{
    class ExcelWorker
    {
        public readonly int GENERATION_NUMBER_INDEX = 0;
        public readonly int BEST_RATING_INDEX = 1;
        public readonly int GRADE_AVERAGE_INDEX = 2;
        public readonly int WORST_RATING_INDEX = 3; 

        public ExcelWorker()
        {
            //create new xls file
            string file = "newdoc.xls";
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("First Sheet");
            worksheet.Cells[2, 0] = new Cell(9999999);
            worksheet.Cells[3, 3] = new Cell((decimal)3.45);
            worksheet.Cells[2, 2] = new Cell("Text string");
            worksheet.Cells[2, 4] = new Cell("Second string");
            worksheet.Cells[5, 5] = new Cell(5);
            workbook.Worksheets.Add(worksheet);
            workbook.Save(file);

            // open xls file
            Workbook book = Workbook.Load(file);
            Worksheet sheet = book.Worksheets[0];

            // traverse cells
            //foreach (Pair, Cell > cell in sheet.Cells)
            //{
            //    dgvCells[cell.Left.Right, cell.Left.Left].Value = cell.Right.Value;
            //}

            // traverse rows by Index
            for (int rowIndex = sheet.Cells.FirstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            {
                Row row = sheet.Cells.GetRow(rowIndex);
                for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
                {
                    Cell cell = row.GetCell(colIndex);
                }
            }
        }

        /// <summary>
        /// Add cell to worksheet
        /// </summary>
        /// <param name="x">row index</param>
        /// <param name="y">column index</param>
        /// <param name=""></param>
        public void AddCellToWorksheet<T>(int x, int y, T dataValue, Worksheet worksheet)
        {
            worksheet.Cells[x, y] = new Cell(dataValue);
        }

        public void Method()
        {

        }
    }
}
