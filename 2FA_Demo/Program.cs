using System;
using Google.Authenticator;

namespace FA_Demo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var twoFactorAuthenticator = new TwoFactorAuthenticator();
            var result = GenerateTwoFactorKey(twoFactorAuthenticator);

            Console.WriteLine(result);
        }

        public static string GenerateTwoFactorKey(TwoFactorAuthenticator authenticator)
        {
            Console.WriteLine("Entrez le nom de l'application :");
            var applicationName = Console.ReadLine();

            Console.WriteLine("Entrez le nom de l'utilisateur :");
            var username = Console.ReadLine();

            Console.WriteLine("Entrez la clé secrète :");
            var secretKey = Console.ReadLine();

            var setupCode = authenticator.GenerateSetupCode(applicationName, username, secretKey, false, 4);

            var qrCodeImageUrl = setupCode.QrCodeSetupImageUrl;
            var manualEntryKey = setupCode.ManualEntryKey;

            Console.WriteLine("Veuillez scanner le code QR suivant dans une application d'authentification 2FA :");
            Console.WriteLine(qrCodeImageUrl);
            Console.WriteLine("ou entrez manuellement la clé suivante :");
            Console.WriteLine(manualEntryKey);

            Console.WriteLine("Entrez le code 2FA généré par l'application :");
            var userCode = Console.ReadLine();

            bool isCodeValid = authenticator.ValidateTwoFactorPIN(secretKey, userCode);

            return isCodeValid ? "Clé 2FA valide !" : "Clé 2FA invalide !";
        }
    }
}
