using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTests
  {
    [TestMethod]
    public void TestMethod1()
    {
      var student = new Student("Luiz Fernando", "de Abreu Azevedo", "38103842168", "lfaazevedo@hotmail.com");
    }
  }
}
