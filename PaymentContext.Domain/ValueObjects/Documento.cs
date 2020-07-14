using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
  public class Document : ValueObject
  {

    public Document(string number, EDocumentType type)
    {
      Number = number;
      Type = type;

      AddNotifications(new Contract()
          .Requires()
          .IsTrue(Validate(), "Document.Number", "Documento inválido."));

    }
    public string Number { get; private set; }

    public EDocumentType Type { get; private set; }

    private bool Validate()
    {
      switch (Type)
      {
        case EDocumentType.CNPJ:
          if (Number.Length == 14)
            return true;
          break;

        case EDocumentType.CPF:
          if (Number.Length == 11)
            return true;
          break;
      }

      return false;
    }

  }
}