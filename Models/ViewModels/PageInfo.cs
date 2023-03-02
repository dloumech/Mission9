using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BPerPage { get; set; }
        public int CurrentPage { get; set; }

        //calc pages needed 
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BPerPage);

    }
}
