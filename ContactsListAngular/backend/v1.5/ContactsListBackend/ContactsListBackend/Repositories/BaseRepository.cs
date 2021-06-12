using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsListBackend.Repositories
{
    public class BaseRepository<T>
    {
        private FileStream dataFile;
        private StreamReader sr;
        private StreamWriter sw;
        public String fileName;

        public void SaveData(List<T> objects)
        {
            try
            {
                
                dataFile = new FileStream(fileName, FileMode.Create,FileAccess.ReadWrite);
                sw = new StreamWriter(dataFile);
                var outputJSON = JsonConvert.SerializeObject(objects);
                sw.Write(outputJSON);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }

                if (dataFile != null)
                {
                    dataFile.Close();
                    dataFile.Dispose();
                }
            }

        }

        public List<T> LoadData()
        {
            try
            {
                dataFile = new FileStream(fileName, FileMode.OpenOrCreate,FileAccess.ReadWrite);
                sr = new StreamReader(dataFile);
                var jsonText = sr.ReadToEnd();
                var result = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonText);

                return (List<T>)result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<T>();
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }

                if (dataFile != null)
                {
                    dataFile.Close();
                    dataFile.Dispose();
                }
            }

        }
    }
}
