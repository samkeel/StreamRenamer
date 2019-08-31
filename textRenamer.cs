using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renamer
{
    class textRenamer
    {
        public static void TextImport(String staticValue, String countValue, String FPath, bool sorted)
        {
            var dictionary = new Dictionary<string, string>();
            var newValues = new Dictionary<string, string>();

            int cValue = Convert.ToInt32(countValue);

            string key = "";
            string val = "";

            using (StreamReader sr = new StreamReader(FPath))
            {
                string str = null;
                while (!sr.EndOfStream)
                {
                    string[] line = str.Split('|');
                    dictionary.Add(line[0], line[1]);
                }
            }

            if (sorted == true)
            {
                //sort the dictionary using linq
                var sortedValue = from ele in dictionary
                                  orderby ele.Value ascending
                                  select ele;

                //update values to new sorted list
                foreach (KeyValuePair<string, string> ele in sortedValue)
                {
                    key = ele.Key.ToString();
                    val = staticValue + cValue.ToString("0000");
                    //add values to new dictionary
                    newValues.Add(key, val);
                    cValue++;
                }
            }
            else
            {
                //change old values to new values without sorting
                foreach (KeyValuePair<string, string> keyValuePair in dictionary)
                {
                    key = keyValuePair.Key.ToString();
                    val = staticValue + cValue.ToString("0000");
                    //add values to new dictionary
                    newValues.Add(key, val);
                    cValue++;
                }
            }
            WriteText(FPath, newValues);
        }

        public static void WriteText(string FilePath, Dictionary<string, string> writeValues)
        {
            using (StreamWriter sw = new StreamWriter(FilePath, false))
            {
                foreach (KeyValuePair<string, string> keyValuePair in writeValues)
                {
                    sw.WriteLine(keyValuePair.Key.ToString() + "|" + keyValuePair.Value.ToString());
                }
            }
        }
    }
}
