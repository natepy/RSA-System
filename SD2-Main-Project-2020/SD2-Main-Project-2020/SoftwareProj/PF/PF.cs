using System;
using System.Numerics;
using System.Collections.Generic;

namespace SD2_Main_Project_2020.SoftwareProj
{
    public struct FactorInfo
    {
        public BigInteger Factor;
        public int Multiplicity;
        public FactorInfo(BigInteger Factor, int Multiplicity)
        {
            this.Factor = Factor;
            this.Multiplicity = Multiplicity;
        }
    }
    public class PF
    {
        private BigInteger Number;

        public void RunPF()
        {
            LinkedList<FactorInfo> Factors;
            GetNumber();
            Factors = PrimeFactors(Number);
            DisplayFactors(Factors);
        }

        private void DisplayFactors(LinkedList<FactorInfo> Factors)
        {
            foreach (var Factor in Factors)
                Console.WriteLine("{0}^{1}", Factor.Factor, Factor.Multiplicity);
        }
        private void GetNumber()
        {
            Console.Write("Enter Number: ");
            Number = BigInteger.Parse(Console.ReadLine());
        }
        public LinkedList<FactorInfo> PrimeFactors(BigInteger Number)
        {
            int multiplicity;
            LinkedList<FactorInfo> factors = new LinkedList<FactorInfo>();
            for (BigInteger i = 2; Number > 1; i++)
                if (Number % i == 0)
                {
                    multiplicity = 0;
                    while (Number % i == 0)
                    {
                        Number /= i;
                        multiplicity++;
                    }
                    factors.AddLast(new FactorInfo(i, multiplicity));
                }
            return factors;
        }

        public PF() { }
    }
}
