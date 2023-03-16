using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBooks.Data.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
        public int Rate { get; set; }

        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
    }

    public class BookWithAuthorsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int Rate { get; set; }

        public string PublisherName { get; set; }
        public List<string> Authornames { get; set; }
    }
}
