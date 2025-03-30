using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2WPF
{
    class Add : Command
    {

        public Add(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }

        public override void Execute()
        {
            unit.Run('+', operand);
        }
    }
    class Sub : Command
    {
        public Sub(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }

        public override void Execute()
        {
            unit.Run('-', operand);
        }
    }
    class Mul:Command
    {
        public Mul(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }

        public override void Execute()
        {
            unit.Run('*', operand);
        }
    }

    class Div:Command
    {
        public Div(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute()
        {
            unit.Run('/',operand);
        }
    }

    class Power : Command
    {
        public Power(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }

        public override void Execute()
        {
            unit.Run('^', operand);
        }
    }

    class Ln : Command
    {
        public Ln(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }

        public override void Execute()
        {
            unit.Run('l', operand);
        }
    }

    class Sqrt : Command
    {
        public Sqrt(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }

        public override void Execute()
        {
            unit.Run('s', operand);
        }
    }

    abstract class Command
    {
        protected ArithmeticUnit unit;
        protected double operand;

        public abstract void Execute();
    }
}
