using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
  [TestClass]
  public class DocumentTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
      var doc = new Document("0538178700010", EDocumentType.CNPJ);
      Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsValid()
    {
      var doc = new Document("05381787000100", EDocumentType.CNPJ);
      Assert.IsTrue(doc.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
      var doc = new Document("3810384216", EDocumentType.CPF);
      Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("38103842168")]
    [DataRow("38103842167")]
    [DataRow("38103842164")]
    [DataRow("38103842163")]
    public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
    {
      var doc = new Document(cpf, EDocumentType.CPF);
      Assert.IsTrue(doc.Valid);
    }
  }
}
