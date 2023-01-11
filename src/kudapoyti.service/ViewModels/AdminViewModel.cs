using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.ViewModels
{
    public class AdminViewModel
    {
        public long Id { get; set; }

        public string FullName { get; set; }=String.Empty;

        public string Email { get; set; } = String.Empty;

        public string PhoneNumber { get; set; } = String.Empty;

        public string TelegramLink { get; set; } = String.Empty;

    }
}
