using System;
using System.IO;

namespace CSVFileReadWrite
{
    class DataFileReader
    {
        public string Path { get; set; }
        public MyObject myObject;

        public DataFileReader(string path)
        {
            Path = @path;
            myObject = null;
            ReadIntDataFromFile();
            CreateObject();
        }

        /// <summary>
        /// Read txt file and returns all Integers as array int[]
        /// </summary>
        /// <returns>list of all ints in file</returns>
        public int[] ReadIntDataFromFile()
        {
            string fileContent = File.ReadAllText(Path);
            string[] integerStrings = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int[] integers = new int[integerStrings.Length];
            for (int n = 0; n < integerStrings.Length; n++)
                integers[n] = int.Parse(integerStrings[n]);

            return integers;
        }

        public void CreateObject()
        {
            int theFirstIntIndex = 0;

            int[] integers = ReadIntDataFromFile();

            int dimension = integers[theFirstIntIndex];
            
            myObject = new MyObject(dimension, integers);
        }
        
    }
}
