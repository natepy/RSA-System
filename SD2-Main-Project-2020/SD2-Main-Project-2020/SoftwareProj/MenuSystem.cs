using System;

namespace SD2_Main_Project_2020.SoftwareProj
{
    class MenuSystem
    {
        private ManageSystem SD2System;
        public int MenuOption { get; set; }

        public void Run()
        {
            while (MenuOption != 0)
            {
                DisplayMenu();
                TakeMenuOption();
                RunMenuOption();
                if (MenuOption > 0)
                    Console.WriteLine("Press Enter to return to the main menu ...");
                else
                    Console.WriteLine("Press Enter to return to close the program ...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void DisplayMenu()
        {
            Console.WriteLine("{0}SD2 Software Project{1}", "".PadLeft(15, '-'), "".PadLeft(15, '-'));
            Console.WriteLine("1 - Prime Factorization.");
            Console.WriteLine("2 - Extended Euclidean Algorithm.");
            Console.WriteLine("3 - RSA Encryption.");
            Console.WriteLine("4 - RSA Decryption.");
            Console.WriteLine("0 - Exit Program.");
        }
        private void RunMenuOption()
        {
            switch (MenuOption)
            {
                case 1:
                    SD2System.RunPF();
                    break;
                case 2:
                    SD2System.RunEEA();
                    break;
                case 3:
                    SD2System.RunEncrypt();
                    break;
                case 4:
                    SD2System.RunDecrypt();
                    break;
                default:
                    break;
            }
        }
        private void TakeMenuOption()
        {
            Console.Write("-> ");
            MenuOption = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("".PadLeft(50, '-'));
            Console.WriteLine();
        }
        
        public MenuSystem() 
        {
            MenuOption = -1;
            SD2System = new ManageSystem();
        }
    }
}
