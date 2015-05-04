using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1ContactGestion.Model
{
    public class ContactContext :DataContext
    {
        public static string DbConnectionString = "Data Source=isostore:/ContactDb2.sdf"; 
        public ContactContext(string fileOrConnection) : base(fileOrConnection)
        {
        }

        public Table<Contact> Contacts; 
    }
}
