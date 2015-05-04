using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1ContactGestion.Model
{
    [Table]
    public class Contact
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string FirstName { get; set; }

        [Column]
        public string LastName { get; set; }

        [Column]
        public DateTime? BirthDate { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + BirthDate.Value.ToString("d");
        }
    }
}
