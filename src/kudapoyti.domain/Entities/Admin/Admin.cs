using kudapoyti.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Domain.Entities.Admin
{
    public class Admin:BaseEntity
    {

        public string Email { get; set; }=String.Empty;

        public string Telegram_contact { get; set; }= String.Empty; 

        public string Password { get; set; }=String.Empty;

        public string Salt { get; set; }=String.Empty;

    }
}
