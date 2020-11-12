using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    class InvoiceClient
    {
        private int numberInvoice { get; set; }
        private string idClient { get; set; }
        private DateTime paymentDate { get; set; }
        private int idPayMethod { get; set; }
        private string payMethod { get; set; }
        private double money { get; set; }
        private Boolean condition { get; set; }
        private string paymentCondition { get; set; }

        public InvoiceClient(int numberInvoice, string idClient, DateTime paymentDate, int idPayMethod, string payMethod,
            double money, Boolean condition, string paymentCondition)
        {
            this.numberInvoice = numberInvoice;
            this.idClient = idClient;
            this.paymentDate = paymentDate;
            this.idPayMethod = idPayMethod;
            this.payMethod = payMethod;
            this.money = money;
            this.condition = condition;
            this.paymentCondition = paymentCondition;
        }
        
    }
}
