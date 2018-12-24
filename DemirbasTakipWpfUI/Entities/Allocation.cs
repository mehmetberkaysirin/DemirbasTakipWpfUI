using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemirbasTakipWpfUI.Entities
{
    public class Allocation
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PersonelId { get; set; }
        public int IslemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Boolean Status { get; set; }
        public string Description { get; set; }


    }
}
