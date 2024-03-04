using System.Threading.Channels;

namespace customEX
{


    class invalidPinException : Exception
    {
        public invalidPinException(string message) : base(message) 
        {

        }
    }

    class ATM
    {
        private  int MaxAttempts = 3;
        private  int password = 564636;
        

        public void acceptPin()
        {
            int attempts = 0;

            while (attempts < MaxAttempts)
            {
                Console.WriteLine("Enter your ATM PIN number:");
                int pin = int.Parse(Console.ReadLine());

                if (pin == password)
                {
                    Console.WriteLine("Login successful.");
                    return;
                }
                else
                {
                    attempts++;
                    if (attempts < MaxAttempts)
                    {
                        Console.WriteLine($"Invalid PIN. You have {MaxAttempts - attempts} attempts remaining. Please try again.");
                    }
                    else
                    {
                        throw new invalidPinException("ATM card blocked. Too many unsuccessful attempts.");
                    }
                }
            }
        }
        

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();

            try
            {
                atm.acceptPin();
            }
            catch (invalidPinException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        
    }
}
