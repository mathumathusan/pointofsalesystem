using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_software.MODEL
{
    public class Customer
    {
       

        public int Id { get; set; }
        public string customer_name { get; set; }
        public string address { get; set; }

        public string telephone_no{ get; set; }

        public string created_at { get; set; }

        public string created_by { get; set; }

        public string updated_at { get; set; }
        public string updated_by { get; set; }
        public string deleted_at { get; set; }
        public string deleted_by { get; set; }
    }

    
}
