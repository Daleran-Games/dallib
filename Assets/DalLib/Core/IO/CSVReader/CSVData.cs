using System.Collections.Generic;
using System.IO;

namespace DaleranGames.IO
{
    public class CSVData
    {
        public readonly string Name;

        List<string[]> rawData;
        public List<string[]> RawData { get { return rawData; } }

        Dictionary<string, CSVEntry> data;
        public CSVEntry this[string id]
        {
            get
            {
                CSVEntry output;

                if (data.TryGetValue(id , out output))
                    return output;
                else
                    throw new KeyNotFoundException(id + " not a valid if for this CSV Data set.");
            }
        }
        public int Count { get { return data.Count; } }
        public List<CSVEntry> Entries { get { return new List<CSVEntry>(data.Values); } }

        public CSVData (string name, string filepath)
        {
            Name = name;
            rawData = CSVUtility.ParseCSVToArray(File.ReadAllText(filepath));
            data = ParseOneHeader(rawData);
        }

        public CSVData(string name, string filepath, List<string> multipleHeaders)
        {
            Name = name;
            rawData = CSVUtility.ParseCSVToArray(File.ReadAllText(filepath));
            data = ParseMultipleHeaders(rawData, multipleHeaders);
        }
        
        Dictionary<string, CSVEntry> ParseOneHeader (List<string[]> csvArray)
        {
            string[] header = csvArray[0];
            Dictionary<string, CSVEntry> newEntries = new Dictionary<string, CSVEntry>();


            for (int i=1;i<csvArray.Count;i++)
            {
                newEntries.Add(csvArray[i][0],new CSVEntry(PadJAggedStringArray(header,csvArray[i]),header));
            }
            return newEntries;
        }

        Dictionary<string, CSVEntry> ParseMultipleHeaders(List<string[]> csvArray, List<string> multipleHeaders)
        {
            string[] header = csvArray[1];
            bool headerNext = false;

            Dictionary<string, CSVEntry> newEntries = new Dictionary<string, CSVEntry>();

            for (int i = 0; i < csvArray.Count; i++)
            {
                if (multipleHeaders.Contains(csvArray[i][0]))
                {
                    headerNext = true;
                } else if (headerNext == true)
                {
                    header = csvArray[i];
                    headerNext = false;
                } else
                {
                    newEntries.Add(csvArray[i][0],new CSVEntry(PadJAggedStringArray(header, csvArray[i]), header));
                }
            }
            return newEntries;
        }

        string[] PadJAggedStringArray(string[] header, string[] entry)
        {
            if (header.Length == entry.Length)
                return entry;

            string[] newEntry = new string[header.Length];
            entry.CopyTo(newEntry, 0);
            return newEntry;
        }
    }
}