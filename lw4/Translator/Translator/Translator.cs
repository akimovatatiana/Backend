using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Translator
{
    public class Translator
    {
        public Dictionary<string, string> dictionary;
        public Translator(string path)
        {
            dictionary = InitDictionary(path);
        }
         Dictionary<string, string> InitDictionary(string fileName)
         {
             Dictionary<string, string> dictionary = new Dictionary<string, string> { };
             StreamReader dictionaryFile = new StreamReader(fileName);
             string line;
             while ((line = dictionaryFile.ReadLine()) != null)
             {
                 string[] words = line.Split(' ');
                 dictionary.Add(words[0] , words[1]);
             }
             dictionaryFile.Close();
             return dictionary;
         }
        public string Translate(string word)
        {
            foreach (KeyValuePair<string, string> pair in dictionary)
	        {
                if (pair.Key == word)
                {
                    return pair.Value;
                }
                if (pair.Value == word)
                {
                    return pair.Key;
                }
            }
            return null;
        }
    }
}
