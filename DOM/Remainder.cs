using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class Remainder
    {
        private int idRemainder { get; set; }
        private int invoiceNumberSupplier { get; set; }
        private int invoiceNumberClient { get; set; }
        private string description { get; set; }
        private string userName { get; set; }
        private DateTime dateRemainder { get; set; }
        private string email { get; set; }

        public Remainder(int invoiceNumberSupplier, int invoiceNumberClient, string description, string userName,
                DateTime dateRemainder, string email)
        {
            this.invoiceNumberSupplier = invoiceNumberSupplier;
            this.invoiceNumberClient = invoiceNumberClient;
            this.description = description;
            this.userName = userName;
            this.dateRemainder = dateRemainder;
            this.email = email;
        }
    }
}
