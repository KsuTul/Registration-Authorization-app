namespace WPF_APP.Helpers
{
    using System.Collections.Generic;

    public static class Messages
    {
        public static string EmailPattern = @"^([a-zA-Z0-9])*(\.|[a-zA-Z0-9])*\@{1}([a-zA-Z])*(\.[a-z]+)";

        public static string PhonePattern = @"[+7|8]\(\d{3}\)\d{3}-\d{2}-\d{2}";

        public static string PasswordPattern = @"([a-zA-Z0-9\&|\!|\@])";

        public static string ErrorMessageForDate = "This data is not valid";

        public static string ErrorMessageEmptyValue = "You enter is not valid";

        public static string ErrorMessageEnterData = "Please enter a data!";

        public static string ErrorMessageIncorrectPhone = "This phone is not valid";

        public static string ErrorMessageIncorrectEmail = "The incorrect format of email";

        public static string ErrorMessageIncorrectPassword = "The incorrect format of password";

        public static string MessageAboutExistingUser = "This user exist";

        public static string MessageAboutRegistration = "Please, registrate";

        public static string MessageAboutSuccessRegistration = "You are with us!";

        public static string MessageAboutUnSuccessRegistration = "Sorry, something go wrong. Please check data";

        public static string MessageAboutHavingAccount = "You have already registrated";

        public static List<string> Cities = new List<string>()
        {
            "Nizhniy Novgorod",
            "Moscow",
            "Saint-Petersburg",
            "Kaliningrad",
            "Petrozavodsk",
            "Sochi"
        };
    }
}
