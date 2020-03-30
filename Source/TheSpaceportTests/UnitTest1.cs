using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spaceport;
using Spaceport.Models;
using System;

namespace TheSpaceportTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInvoiceHasCorrectPay()
        {
            //Arrange
            DateTime registrationTime = DateTime.Now;
            int minutes = 10;
            DateTime payTime = registrationTime.AddMinutes(minutes);
            int expectedPayAmount = (minutes * Invoice.BASE_COST_PER_MINUTE) + Invoice.BASE_COST_PER_MINUTE;
            Person person = new Person
            {
                Name = "Test Testsson2",
                SSN = Guid.NewGuid().ToString()
            };
            Invoice invoice = new Invoice {
                RegistrationTime = registrationTime,
                Paid = false,
                Person = person
            };

            //Act
            invoice.AddEntityToDatabase();
            invoice.Pay(payTime);

            //Assert
            Assert.AreEqual(expectedPayAmount, invoice.AmountPaid);
            using SpacePortDBContext context = new SpacePortDBContext();
            context.Persons.Remove(person);
            context.Invoices.Remove(invoice);
            context.SaveChanges();
        }
    }
}
