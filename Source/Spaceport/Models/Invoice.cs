using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spaceport.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceID { get; set; }
        public bool Paid { get; set; }
        public int AmountPaid { get; set; }

        private const int costPerHour = 100;

        public void Pay(DateTime registrationTime)
        {
            TimeSpan timeDifference = DateTime.Now - registrationTime;
            int amountToPay = timeDifference.Hours * costPerHour;
            AmountPaid = amountToPay;
            Paid = true;
            Console.WriteLine("\nInvoice Paid");
            //UpdateEntityInDatabase();
        }

        //internal void UpdateEntityInDatabase()
        //{
        //    using var context = new SpacePortDBContext();
        //    var invoiceContext = context.Set<Invoice>();
        //    invoiceContext.Update(this);
        //    context.SaveChanges();
        //}

        public void AddEntityToDatabase()
        {
            using var context = new SpacePortDBContext();
            var invoiceContext = context.Set<Invoice>();
            invoiceContext.Add(this);
            context.SaveChanges();
        }
    }
}
