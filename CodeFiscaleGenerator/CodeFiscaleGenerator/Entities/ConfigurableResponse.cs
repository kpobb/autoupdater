using System.Xml.Serialization;

namespace CodeFiscaleGenerator.Entities
{
    [XmlRoot(ElementName = "ConfigurableResponse", Namespace = "")]
    public class ConfigurableResponse
    {
        public ConfigurableResponse()
        {
            AccountCodeMigrationResponseCode = -1;
            IdentificationDocumentUpdateResponseCode = -1;
            SubregistrationResponseCode = 1024;
            CheckAccountStatusResponseDescription = 4;
            CheckAccountStatusResponseStatus = 2;
            CheckAccountStatusResponseCode = 1024;
            EditAccountProvinceOfResidenceResponseCode = 1024;
            ChangeAccountStatusResponseCode = 1024;
            BonusEWalletTransactionResponseCode = 1024;
            EWalletTransactionResponseCode = 1024;
            LegalAccountOpeningResponseCode = 1024;
            NotifyAccountBalanceResponseCode = 1024;
            IndividualAccountOpeningResponseCode = 1300;
            FiscalCode = "SSNGD00000000001";
        }

        [XmlAttribute(AttributeName = "accountCodeMigrationResponseCode")]
        public int AccountCodeMigrationResponseCode { get; set; }

        [XmlAttribute(AttributeName = "identificationDocumentUpdateResponseCode")]
        public int IdentificationDocumentUpdateResponseCode { get; set; }

        [XmlAttribute(AttributeName = "subregistrationResponseCode")]
        public int SubregistrationResponseCode { get; set; }

        [XmlAttribute(AttributeName = "checkAccountStatusResponseDescription")]
        public int CheckAccountStatusResponseDescription { get; set; }

        [XmlAttribute(AttributeName = "checkAccountStatusResponseStatus")]
        public int CheckAccountStatusResponseStatus { get; set; }

        [XmlAttribute(AttributeName = "checkAccountStatusResponseCode")]
        public int CheckAccountStatusResponseCode { get; set; }

        [XmlAttribute(AttributeName = "editAccountProvinceOfResidenceResponseCode")]
        public int EditAccountProvinceOfResidenceResponseCode { get; set; }

        [XmlAttribute(AttributeName = "changeAccountStatusResponseCode")]
        public int ChangeAccountStatusResponseCode { get; set; }

        [XmlAttribute(AttributeName = "bonusEWalletTransactionResponseCode")]
        public int BonusEWalletTransactionResponseCode { get; set; }

        [XmlAttribute(AttributeName = "eWalletTransactionResponseCode")]
        public int EWalletTransactionResponseCode { get; set; }

        [XmlAttribute(AttributeName = "legalAccountOpeningResponseCode")]
        public int LegalAccountOpeningResponseCode { get; set; }

        [XmlAttribute(AttributeName = "notifyAccountBalanceResponseCode")]
        public int NotifyAccountBalanceResponseCode { get; set; }

        [XmlAttribute(AttributeName = "individualAccountOpeningResponseCode")]
        public int IndividualAccountOpeningResponseCode { get; set; }

        [XmlAttribute(AttributeName = "fiscalCode")]
        public string FiscalCode { get; set; }
    }
}