using System;

namespace SD2_Main_Project_2020.SoftwareProj
{
    class ManageSystem
    {
        private PF programOne;
        private EEA programTwo;
        private Encrypt programThree;
        private Decrypt programFour;

        public void RunPF()
        {
            programOne.RunPF();
        }
        public void RunEEA()
        {
            programTwo.RunExtEucAlg();
        }
        public void RunEncrypt()
        {
            programThree.RunRsaEncryption();
        }
        public void RunDecrypt()
        {
            programFour.RunRSADecryption();
        }

        public ManageSystem() 
        {
            programOne = new PF();
            programTwo = new EEA();
            programThree = new Encrypt();
            programFour = new Decrypt();
        }
    }
}
