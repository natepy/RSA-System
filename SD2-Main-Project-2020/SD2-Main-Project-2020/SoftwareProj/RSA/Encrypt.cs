using System;
using System.Numerics;

namespace SD2_Main_Project_2020.SoftwareProj
{
    class Encrypt
    {
        public string Message { get; set; }
        private int[] NumberMessage;

        public void RunRsaEncryption()
        {
            int e, inputOption;
            BigInteger n, P = 0;
            Console.WriteLine("Enter input option: ");
            Console.WriteLine("1 - Integer.");
            Console.WriteLine("2 - text.");
            Console.Write("-> ");
            inputOption = Convert.ToInt16(Console.ReadLine());
            if (inputOption == 1)
            {
                Console.Write("Enter P: ");
                P = BigInteger.Parse(Console.ReadLine());
            }
            else if (inputOption == 2)
            {
                GetMessage();
                SetNumberMessage();
                P = GetCombinedMessage();
            }
            
            Console.Write("Enter n: ");
            n = BigInteger.Parse(Console.ReadLine());
            Console.Write("Enter e: ");
            e = Convert.ToInt32(Console.ReadLine());
            if (inputOption == 2)
                PrintEachEncryptedLetter(e, n);

            Console.WriteLine("Ciphertext={0}",EncryptMessage(P, e, n));
        }
        public BigInteger EncryptMessage(BigInteger P, int e, BigInteger n)
        {
            return BigInteger.ModPow(P, e, n);
        }
        public void PrintEachEncryptedLetter(int e, BigInteger n)
        {
            Console.WriteLine("Individual letters:");
            foreach (var number in NumberMessage)
            {
                if (number > 9)
                    Console.WriteLine("\t{0}={1}={2}", GetNumChar(number), number, EncryptMessage(number, e, n));
                else if (number == 0)
                    Console.WriteLine();
                else
                    Console.WriteLine("\t{0}=0{1}={2}", GetNumChar(number), number, EncryptMessage(number, e, n));
            }
        }
        public BigInteger GetCombinedMessage()
        {
            string combinedMessage = "";
            for (int i = 0; i < Message.Length; i++)
            {
                if (GetCharNum(Message[i]) > 9)
                    combinedMessage += GetCharNum(Message[i]);
                else
                    combinedMessage += "0" + Convert.ToString(GetCharNum(Message[i]));
            }
            if (combinedMessage.Length > 0)
                return BigInteger.Parse(combinedMessage);
            return 0;
        }
        public void GetMessage()
        {
            Console.Write("Enter message (max 4 characters): ");
            Message = Console.ReadLine();
        }
        public void SetNumberMessage()
        {
            NumberMessage = MessageNumber(Message);
        }
        public int[] MessageNumber(string Message)
        {
            int[] messageNumbers = new int[4];
            for (int i = 0; i < Message.Length; i++)
                messageNumbers[i] = GetCharNum(Message[i]);
            return messageNumbers;
        }
        private int GetCharNum(char letter)
        {
            int result = 0;
            letter = Char.ToUpper(letter);
            if (letter != ' ')
                result = (int)letter - 64;
            return result;
        }
        public char GetNumChar(int number)
        {
            char result = ' ';
            if (number > 0)
                result = (char)(number + 64);
            return result;
        }

        public Encrypt() : base() { }
    }
}
