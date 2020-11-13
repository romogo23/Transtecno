using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class InvoiceSupplier
    {
        private int numberInvoice { get; set; }
        private string idClient { get; set; }
        private DateTime paymentDate { get; set; }
        private int idPayMethod { get; set; }
        private string payMethod { get; set; }
        private double money { get; set; }
        private Boolean condition { get; set; }

        public InvoiceSupplier(int numberInvoice, string idClient, DateTime paymentDate, int idPayMethod, string payMethod,
            double money, Boolean condition)
        {
            this.numberInvoice = numberInvoice;
            this.idClient = idClient;
            this.paymentDate = paymentDate;
            this.idPayMethod = idPayMethod;
            this.payMethod = payMethod;
            this.money = money;
            this.condition = condition;
        }
    }
}
