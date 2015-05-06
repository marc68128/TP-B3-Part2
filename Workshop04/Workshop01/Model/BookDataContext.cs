using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop01.Model
{
    public class BookDataContext : DataContext
    {
        public static string DbConnectionString = "Data Source=isostore:/BookDb4.sdf"; 
        public BookDataContext(string fileOrConnection) : base(fileOrConnection)
        {
        }

        public Table<Book> Books; 
    }
}
