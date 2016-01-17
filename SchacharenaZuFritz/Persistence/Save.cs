using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SchacharenaZuFritz.Persistence
{
    class Save
    {
        public static void SaveToFile(string path, string text)
        {
            File.WriteAllText(path, text, Encoding.Default);
        }
    }
}
