using System;
using System.Collections.Generic;
using System.Text;

namespace big_sister_base
{
    public class EventProduct: EventArgs
    {
        public Product Product { get; set; }
    }
}
