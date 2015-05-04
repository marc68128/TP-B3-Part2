using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoIsolatedStorageDb.Model
{
    class SchoolContext : DataContext
    {
        public static string DBConnectionString = "Data Source=isostore:/SchoolDb2.sdf";
        public SchoolContext(string fileOrConnection) : base(fileOrConnection)
        {
        }

        public Table<Student> Students;


    }
}
