using System;
using Google.Authenticator;

namespace FA_Demo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var twoFactorAuthenticator = new TwoFactorAuthenticator();
            var result = VerifyTwoFactorCode(twoFactorAuthenticator);

            Console.WriteLine(result);
        }

        public static string VerifyTwoFactorCode(TwoFactorAuthenticator authenticator)
        {
            Console.WriteLine("Entrez la clé secrète :");
            var secretKey = Console.ReadLine();

            Console.WriteLine("Entrez le code 2FA généré par l'application :");
            var userCode = Console.ReadLine();

            bool isCodeValid = authenticator.ValidateTwoFactorPIN(secretKey, userCode);

            return isCodeValid ? "Code 2FA valide !" : "Code 2FA invalide !";
        }
    }
}
