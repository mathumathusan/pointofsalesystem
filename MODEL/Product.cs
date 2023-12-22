using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_software.MODEL
{
    public class Product
    {
       
        public int Id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }

        public string catogary_id { get; set; }

        public string created_at { get; set; }

        public string created_by { get; set; }

        public string updated_at { get; set; }
        public string updated_by { get; set; }
        public string deleted_at { get; set; }
        public string deleted_by { get; set; }
    }
}
