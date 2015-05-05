using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop01.Model
{
    [Table]
    public class Book
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string Author { get; set; }

        [Column]
        public string Title { get; set; }

    }
}
