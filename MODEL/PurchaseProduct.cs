using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_software.MODEL
{
    public class PurchaseProduct
    {
       

        public int Id { get; set; }
        public string purchase_id { get; set; }
        public string qty { get; set; }

        public string cost_price { get; set; }

        public string sale_price { get; set; }

        public string on_hold { get; set; }

        public string on_sale { get; set; }
        public string sub_total { get; set; }
        public string discount { get; set; }
        public string total { get; set; }

        public string created_at { get; set; }
        public string created_by { get; set; }
    }
}
