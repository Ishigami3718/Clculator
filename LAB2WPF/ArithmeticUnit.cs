using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2WPF
{
    class ArithmeticUnit
    {
        public double Register { get; set; }

        public void Run(char opertion,double operand)
        {
            switch (opertion)
            {
                case '+': Register += operand; break;
                case '-': Register -= operand; break;
                case '*': Register *= operand; break;
                case '/': Register /= operand; break;
                case '^': Register = Math.Pow(Register,operand); break;
                case 'l': Register = Math.Log(operand); break;
                case 's': Register = Math.Sqrt(operand);break;
            }
        }
    }
}
