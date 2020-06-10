using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
  [TestClass]
  public class StudentTests
  {
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;
    private readonly Student _student;

    public StudentTests()
    {
      _name = new Name("Luiz", "Fernando");
      _document = new Document("38103842168", EDocumentType.CPF);
      _email = new Email("lfaazevedo@hotmail.com");
      _address = new Address("Rua 2", "333", "Bairro", "Cidade", "SP", "Brasil", "09664000");
      _student = new Student(_name, _document, _email);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscrition()
    {
      var payment = new PayPalPayment("123", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Teste", _document, _address, _email);
      var subscription = new Subscription(null);
      subscription.AddPayment(payment);

      _student.AddSubscription(subscription);
      _student.AddSubscription(subscription);

      Assert.IsTrue(_student.Invalid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenSubscritionHasNoPayment()
    {
      var subscription = new Subscription(null);

      _student.AddSubscription(subscription);

      Assert.IsTrue(_student.Invalid);
    }


    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscrition()
    {
      var payment = new PayPalPayment("123", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Teste", _document, _address, _email);
      var subscription = new Subscription(null);
      subscription.AddPayment(payment);

      _student.AddSubscription(subscription);

      Assert.IsTrue(_student.Valid);
    }
  }
}
