using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_software.MODEL
{
    public class Sale
    {
       

        public int Id { get; set; }
        public string sale_date { get; set; }
        public string no_of_product { get; set; }

        public string no_of_qty { get; set; }

        public string sub_total { get; set; }

        public string discount { get; set; }

        public string total { get; set; }
        public string customer_id { get; set; }
        public string created_at { get; set; }
        public string created_by { get; set; }

        public string updated_at { get; set; }
        public string updated_by { get; set; }
        public string deleted_at { get; set; }

        public string deleted_by { get; set; }
    }
}
