using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_software.MODEL
{
    public class User
    {
        

        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string user_type { get; set; }

        public string is_login { get; set; }

        public string last_login_datetime { get; set; }

        public string last_logout_datetime { get; set; }
        
    }
}
