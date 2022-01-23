using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    class LineReader
    {
        private string _line;
        private List<int> _range;

        // Returns the magnitude of numbers read in by LineReader.
        public int Length
        {
            get { return _range.Count; }
        }

        // Initializes private fields to essentially empty values.
        public LineReader()
        {
            _line = "";
            _range = new List<int>();
        }

        // Reads in a single line from the console in the specified format by the homework.
        public void ReadLine()
        {
            _line = Console.ReadLine();
        }

        // Splits _line around delimeter ' ' and stores as an integer value in _range
        public void Split()
        {
            string[] subs = _line.Split(' ');
            foreach (string s in subs) {
                _range.Add(Convert.ToInt32(s));
            }
        }

        // indexer based off https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/
        public int this[int i]
        {
            get { return _range[i]; }
        }
    }
}
