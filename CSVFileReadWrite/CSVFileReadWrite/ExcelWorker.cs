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

        public readonly int FIRST_INDEX_IN_EXCEL_COLUMN = 0;
        public readonly int COLUMN_A_INDEX = 0;
        public readonly int COLUMN_B_INDEX = 1;
        public readonly int COLUMN_C_INDEX = 2;

        public readonly String DEFAULT_FILE_NAME = "newdoc.xls";
        public readonly String DEFAULT_WORKSHEET_NAME = "First Sheet";

        int rowCounterA;
        int rowCounterB;
        int rowCounterC;

        //we will work only with one workbook and worksheet
        Workbook workbook;
        Worksheet worksheet;

        String nameOfFile;

        public ExcelWorker(string fileName)
        {
            //create new xls file
            nameOfFile = $"{fileName}.xls";
            SameConstructorActions(nameOfFile);
        }

        public ExcelWorker()
        {
            //create new xls file
            nameOfFile = DEFAULT_FILE_NAME;
            SameConstructorActions(nameOfFile);
        }

        private void SameConstructorActions(string fileName)
        {
            workbook = new Workbook();
            worksheet = new Worksheet(DEFAULT_WORKSHEET_NAME);

            workbook.Worksheets.Add(worksheet);
            Save();

            rowCounterA = FIRST_INDEX_IN_EXCEL_COLUMN;
            rowCounterB = FIRST_INDEX_IN_EXCEL_COLUMN;
            rowCounterC = FIRST_INDEX_IN_EXCEL_COLUMN;
        }

        /// <summary>
        /// Add cell to worksheet
        /// </summary>
        /// <param name="x">row index</param>
        /// <param name="y">column index</param>
        /// <param name=""></param>
        public void AddCellToWorksheet<T>(int x, int y, T dataValue)
        {
            worksheet.Cells[x, y] = new Cell(dataValue);
        }

        /// <summary>
        /// Add Cell To Worksheet into Columns A, B
        /// </summary>
        public void AddCellToWorksheetIntoColumnsAB(int generationNumber, int bestCost)
        {
            AddCellToWorksheet(rowCounterA++, COLUMN_A_INDEX, generationNumber);
            AddCellToWorksheet(rowCounterB++, COLUMN_B_INDEX, bestCost);
            Save();
        }

        private void Save()
        {
            workbook.Save(nameOfFile);
        }
    }
}
