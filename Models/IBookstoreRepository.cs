using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public interface IBookstoreRepository //interface is template for class
    {
        IQueryable<Book> Books { get; }
    }
}
