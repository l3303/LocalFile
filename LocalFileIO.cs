using System;
using System.IO;
using System.Text;

namespace Com.Ken.File
{
    public static class LocalFileIO
    {
        public static string ReadFile(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);

            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sb.Append(line + "\n");
                }
            }
            return sb.ToString();
        }

        public static void WriteFile(string name, string content, bool rewrite = true)
        {
            FileStream file;
            if (!rewrite)
            {
                try
                {
                    file = new FileStream(name, FileMode.Append);
                }
                catch (FileNotFoundException exp)
                {
                    file = new FileStream(name, FileMode.OpenOrCreate);
                }
            }
            else
            {
                file = new FileStream(name, FileMode.OpenOrCreate);
                file.SetLength(0);
            }

            using (StreamWriter writer = new StreamWriter(file))
            {
                StringReader reader = new StringReader(content);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }

                writer.Close();
                reader.Close();
                reader.Dispose();
            }
        }
    }
}
