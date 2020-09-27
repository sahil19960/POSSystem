namespace PosSystem.Constants
{
    /// <summary>
    /// DatabaseConstant is an entity which represents database constants.
    /// </summary>
    public static class DatabaseConstant
    {
        #region User Table Constants

        public const string USER_ID = "UserId";
        public const string USER_NAME = "UserName";
        public const int MAX_LENGTH = 50;
        public const string USER_EMAIL_ID = "UserEmailId";
        public const string PASSWORD = "Password";
        public const string INVALID_EMAIL_MESSAGE = "E-mail is not valid";

        #endregion

        #region Product Table Constants

        public const string PRODUCT_ID = "UserId";
        public const string PRODUCT_NAME = "UserName";
        public const string UNIT_PRICE = "UnitPrice";
        public const string AVAILABLE_QUANTITY = "AvailableQuantity";
        public const string IMAGE_URL = "ImageUrl";
        public const string CATEGORY = "Category";

        #endregion

        public const string INVOICE_NUMBER = "InvoiceNumber";
        public const string DATE_OF_SALE = "DateOfSale";
        public const string DISCOUNT = "Discount";
        public const string VAT = "VAT";

        public const string TRANSACTION_ID = "TransactionId";
        public const string TOTAL_PRICE = "TotalPrice";
        public const string CONSUMED_QUANTITY = "ConsumedQuantity";
    }
}
