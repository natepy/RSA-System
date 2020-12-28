using System;
using System.Numerics;

namespace SD2_Main_Project_2020.SoftwareProj
{
    class EEA
    {
        private BigInteger a;
        private BigInteger b;

        public void RunExtEucAlg()
        {
            BigInteger[] ExtEucAlgResult = new BigInteger[3];
            GetAB();
            ExtEucAlgResult = ExtEucAlg(a,b);
            Console.WriteLine("d: {0}",ExtEucAlgResult[0]);
            Console.WriteLine("x: {0}",ExtEucAlgResult[1]);
            Console.WriteLine("y: {0}",ExtEucAlgResult[2]);
        }

        private void GetAB()
        {
            Console.Write("Enter value for a: ");
            a = BigInteger.Parse(Console.ReadLine());
            Console.Write("Enter value for b: ");
            b = BigInteger.Parse(Console.ReadLine());
        }
        public BigInteger[] ExtEucAlg(BigInteger a, BigInteger b)
        {
            BigInteger q = 0, r = 0,
                x = 0, x1 = 0, x2 = 1,
                y = 0, y1 = 1, y2 = 0,
                d = 0;
            BigInteger[] result = new BigInteger[3];
            if (b == 0)
                result = FillResult(a);
            else
            {
                while (b > 0)
                {
                    q = a / b;
                    r = a - q * b;
                    x = x2 - q * x1;
                    y = y2 - q * y1;
                    a = b;
                    b = r;
                    x2 = x1;
                    x1 = x;
                    y2 = y1;
                    y1 = y;
                }
                d = a;
                x = x2;
                y = y2;
                result[0] = d;
                result[1] = x;
                result[2] = y;
            }
            return result;
        }
        private static BigInteger[] FillResult(BigInteger a)
        {
            BigInteger[] result = { a, 1, 0 };
            return result;
        }

        public EEA() { }
    }
}
