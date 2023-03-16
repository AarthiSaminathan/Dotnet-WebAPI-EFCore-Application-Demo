using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBooks.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       public int Rate { get; set; }

        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }

        public List<Book_Author> Book_Authors { get; set; }




    }
}
