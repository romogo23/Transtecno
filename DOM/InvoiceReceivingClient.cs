using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class InvoiceReceivingClient
    {
        private string idClient { get; set; }
        private string email { get; set; }
        private string nameClient { get; set; }

        public InvoiceReceivingClient(string idClient, string email, string nameClient)
        {
            this.idClient = idClient;
            this.email = email;
            this.nameClient = nameClient;
        }
    }
}
