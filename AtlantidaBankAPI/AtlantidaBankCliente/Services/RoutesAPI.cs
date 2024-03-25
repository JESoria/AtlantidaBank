namespace AtlantidaBankCliente.Services
{
    public class RoutesAPI
    {
        //Local
        public static string API_PATH = "https://localhost:7147/api/";
        //Get Token
        public static string GET_TOKEN = "Token/GetToken";

        //Route CreditCard GetAccountStatementDatail
        public static string GET_ACCOUNT_STATEMENT_DETAIL = "CreditCard/GetAccount";
        //Route CreditCard GetTotalPurchases
        public static string GET_TOTAL_PURCHASES = "CreditCard/GetTotalPurchases";
        //Route CreditCard GetBonifiableInterest 
        public static string GET_BONIFIABLE_INTEREST = "CreditCard/GetBonifiableInterest";
        //Route CreditCard GetCalculateMinimumPayment
        public static string GET_MINIMUN_PAYMENT = "CreditCard/GetCalculateMinimumPayment";
        //Route CreditCard GetTotalAmountToPay 
        public static string GET_TOTAL_AMOUNT_TO_PAY = "CreditCard/GetTotalAmountToPay";
        //Route CreditCard GetTotalCashAmountToPayWithInterest
        public static string GET_TOTAL_AMOUNT_TO_PAY_WITH_INTEREST = "CreditCard/GetTotalCashAmountToPayWithInterest";
        //Route CreditCard GetCurrentPurchases 
        public static string GET_CURRENT_PURCHASES = "CreditCard/GetCurrentPurchases";
        //Route CreditCard GetAllTransactionsForCreditCard 
        public static string GET_ALL_TRANSACTIONS = "CreditCard/GetAllTransactionsForCreditCard";

        //Route Shooping AddPurchase
        public static string ADD_PURCHASE = "Shopping/AddPurchase";
        //Route Shooping MakePayment
        public static string MAKE_PAYMENT = "Shopping/MakePayment";
    }
}
