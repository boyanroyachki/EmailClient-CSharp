using System.Security;

namespace EmailClient.Common
{
    public static class Methods
    {
        public static string GemEmailType(string email)
        {
            return email.Split('@')[1];
        }

        public static SecureString GetPassword()
        {
            var password = new SecureString();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true); // Do not display the pressed key

                // Break the loop if Enter key is pressed
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }

                if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");  // \b is a backspace character
                    password.RemoveAt(password.Length - 1);
                }
                else if (keyInfo.Key != ConsoleKey.Backspace)
                {
                    password.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
            }

            return password;
        }
        public static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException(nameof(securePassword));

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public static bool IsNullOrWhiteSpaceOrEmpty(string input, string? errorMessage)
        {
            if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ResetColor();
                return true;
            }
            return false;
        }

      
    }
}
