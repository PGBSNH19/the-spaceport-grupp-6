using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Spaceport.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceID { get; set; }
        public bool Paid { get; set; }
        public int AmountPaid { get; set; }
        public int PersonID { get; set; }
        public Person Person  { get; set; }
        public DateTime RegistrationTime { get; set; }

        private const int COST_PER_HOUR = 100;

        public void Pay()
        {
            TimeSpan timeDifference = DateTime.Now - RegistrationTime;
            int amountToPay = timeDifference.Hours * COST_PER_HOUR;
            AmountPaid = amountToPay;
            Paid = true;
            Console.WriteLine("\nInvoice Paid");
            UpdateEntityInDatabase();
        }

        internal void UpdateEntityInDatabase()
        {
            using var context = new SpacePortDBContext();
            var invoiceContext = context.Set<Invoice>();
            invoiceContext.Update(this);
            context.SaveChanges();
        }

        public void AddEntityToDatabase()
        {
            using var context = new SpacePortDBContext();
            var invoiceContext = context.Set<Invoice>();
            invoiceContext.Add(this);
            context.SaveChanges();
        }

        public static Invoice UnpaidInvoiceFromPerson(Person person)
        {
            var context = new SpacePortDBContext();
            return context.Invoices.FirstOrDefault(x => !x.Paid && x.PersonID == person.PersonID);
        }
    }
}
