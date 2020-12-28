using System;
using System.Numerics;
using System.Collections.Generic;

namespace SD2_Main_Project_2020.SoftwareProj
{
    class Decrypt
    {
        public void RunRSADecryption()
        {
            int MenuOption = 0;
            BigInteger C = 0, n = 0, e = 0, phi = 0;
            long d = 0;
            // get 
            Console.Write("Enter C: ");
            C = BigInteger.Parse(Console.ReadLine());
            Console.Write("Enter n: ");
            n = BigInteger.Parse(Console.ReadLine());
            Console.Write("Enter e: ");
            e = BigInteger.Parse(Console.ReadLine());

            // find pq
            BigInteger[] pq = FindPQ(n);

            // find phi
            phi = Phi(pq[0], pq[1]);

            // find d
            Console.WriteLine("Chose input option:");
            Console.WriteLine("\t1 - You have a value for d.");
            Console.WriteLine("\t2 - You do not have a value for d and wish to generate it.");
            Console.Write("-> ");
            MenuOption = Convert.ToInt32(Console.ReadLine());
            if (MenuOption == 1)
            {
                Console.Write("Enter value for d: ");
                d = Convert.ToInt64(Console.ReadLine());
            }
            else
                d = findD(phi, e);

            Console.WriteLine("Plaintext={0}",RSADecrypt(C, d, n));
        }

        public static BigInteger RSADecrypt(BigInteger C, long d, BigInteger n)
        {
            return BigInteger.ModPow(C, d, n);
        }

        public static long findD(BigInteger phi, BigInteger e)
        {
            EEA ExtEucAlgo = new EEA();
            BigInteger[] findingD = ExtEucAlgo.ExtEucAlg(phi, e);
            return (long)(findingD[2] + phi);
        }
        public static BigInteger Phi(BigInteger p, BigInteger q)
        {
            return (p - 1) * (q - 1);
        }
        public static BigInteger GetN(BigInteger p, BigInteger q)
        {
            return p * q;
        }
        public static BigInteger[] FindPQ(BigInteger phi)
        {
            int i = 0;
            PF factors = new PF();
            BigInteger[] pq = new BigInteger[2];
            LinkedList<FactorInfo> factorInf = factors.PrimeFactors(phi);
            foreach (var factor in factorInf)
            {
                if (i < 2)
                    pq[i] = factor.Factor;
                i++;
            }
            return pq;
        }

        public Decrypt() { }
    }
}
