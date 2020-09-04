using Dapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace Training_1.TestDataAccess
{
    public class DataAccess
    {
        public static string TestDataFileConnection()
        {
            var fileName = ConfigurationManager.AppSettings["ExcelPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static UserData GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("Select * from [DataSet$] where key='{0}'", keyName);
                var value = connection.Query<UserData>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }

        public static List<UserData> GetTestDatasJson()
        {
            using (StreamReader sr = File.OpenText(@"Training_1\TestDataAccess\Data.json"))
            {
                var obj = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<UserData>>(obj);
            }
        }
    }
}
