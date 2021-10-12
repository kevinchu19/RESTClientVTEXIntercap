using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESTClientIntercapVTEX.Builder
{
    public class UsrDspemlBuilder: IBuilder<Usr_Dspeml>
    {
        private string Usr_Dspeml_Id { get; set; }
        private decimal? Usr_Dspeml_Amount { get; set; } //importe
        private decimal? Usr_Dspeml_Shicos { get; set; } //shipping cost
        private decimal? Usr_Dspeml_Paprov { get; set; }//monto de pago aprobado
        private string Usr_Dspeml_Paysta { get; set; } //estado del pago
        private string Usr_Dspeml_Delsta { get; set; } //Delivery status
        private string Usr_Dspeml_Payffs { get; set; } //payment fullfillment status
        private string Usr_Dspeml_Delffs { get; set; } //payment fullfillment status
        private string Usr_Dspeml_Delmet { get; set; } // delivery method
        private string Usr_Dspeml_Payter { get; set; } //payment term
        private string Usr_Dspeml_Curren { get; set; } // currency
        private DateTime? Usr_Dspeml_Fchmov { get; set; } // date
        private short? Usr_Dspeml_Channe { get; set; } // channel
        private string Usr_Dspeml_Isopen { get; set; } //is open
        private string Usr_Dspeml_Iscanc { get; set; } // is cancelled
        private string Usr_Dspeml_Wareho { get; set; } // deposito
        private string Usr_Dspeml_Nrocta { get; set; } // cliente
        private string Usr_Dspeml_Prcint { get; set; } // proceso interno
        private string Usr_Dspeml_Prceti { get; set; } // proceso etiqueta
        private string Usr_Dspeml_Origen { get; set; } // origen venta
        private decimal? Usr_Dspeml_Cenvin { get; set; } // costo envio intercap
        
        private readonly List<Usr_Dsship> ShippingData = new List<Usr_Dsship>();
        private readonly List<Usr_Dscont> Contacts = new List<Usr_Dscont>();
        private readonly List<Usr_Dspaym> Payments = new List<Usr_Dspaym>();

        public UsrDspemlBuilder()
        {
        }

        public UsrDspemlBuilder setHeader(OrderDTO orderHeader)
        {
            Usr_Dspeml_Id = orderHeader.orderId;
            Usr_Dspeml_Amount = orderHeader.totals.Where(c => c.id == "Items").FirstOrDefault().value;
            Usr_Dspeml_Shicos = orderHeader.totals.Where(c => c.id == "Shipping").FirstOrDefault().value;
            Usr_Dspeml_Paprov = 0;
            Usr_Dspeml_Fchmov = Convert.ToDateTime(orderHeader.creationDate);
            Usr_Dspeml_Nrocta = "004333";
            Usr_Dspeml_Prcint = "S";
            Usr_Dspeml_Prceti = "S";
            Usr_Dspeml_Cenvin = 0;
            return this;
        }

        public UsrDspemlBuilder addContacts (OrderClientProfileDataDTO orderClientProfile,OrderAddressDTO orderShippingData)
        {

            Contacts.Add(new Usr_Dscont()
            {
                Usr_Dscont_Id = orderClientProfile.userProfileId,
                Usr_Dscont_Person = orderClientProfile.lastName + ", " + orderClientProfile.firstName,
                Usr_Dscont_Mail = orderClientProfile.email,
                Usr_Dscont_Phonen = orderClientProfile.phone,
                Usr_Dscont_Stretn = orderShippingData.street,
                Usr_Dscont_Strenu = orderShippingData.number,
                Usr_Dscont_State = orderShippingData.state,
                Usr_Dscont_City = orderShippingData.city,
                Usr_Dscont_Zipcod = orderShippingData.postalCode,
                Usr_Dscont_Type = "Customer",
                Usr_Dscont_Tipdoc = orderClientProfile.documentType,
                Usr_Dscont_Nrodoc = orderClientProfile.document,
                Usr_Dscont_Cndiva = orderClientProfile.customerClass == null || orderClientProfile.document == null ? "C" : orderClientProfile.customerClass
            }) ;
           
            return this;
        }

        public UsrDspemlBuilder addPayments(List<OrderPaymentTransactionsDTO> orderPaymentTransactions)
        {
            foreach (OrderPaymentTransactionsDTO transaction in orderPaymentTransactions)
            {
                foreach (OrderPaymentDTO payment in transaction.payments)
                {
                    Payments.Add(new Usr_Dspaym()
                    {
                        Usr_Dspaym_Inteid = payment.id,
                        Usr_Dspaym_Amount = payment.value,
                        Usr_Dspaym_Status = "Approved",
                        Usr_Dspaym_Method =payment.paymentSystemName
                    });

                }
            }
            
            return this;
        }


        public Usr_Dspeml Build()
        {
            return new Usr_Dspeml(Usr_Dspeml_Id,
                                    Usr_Dspeml_Amount,
                                    Usr_Dspeml_Shicos,
                                    Usr_Dspeml_Paprov,
                                    Usr_Dspeml_Fchmov,
                                    Usr_Dspeml_Nrocta,
                                    Usr_Dspeml_Prcint,
                                    Usr_Dspeml_Prceti,
                                    Usr_Dspeml_Cenvin,
                                    Contacts,
                                    Payments,
                                    new List<Usr_Dsship>() { });
        }

    }
}
