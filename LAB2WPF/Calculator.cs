using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2WPF
{
    class Calculator
    {
        ArithmeticUnit unit;
        ControlUnit controlUnit;
        Stack<double> undo;
        public Calculator()
        {
            unit = new ArithmeticUnit();
            controlUnit = new ControlUnit();
            undo = new Stack<double>();
        }

        public double GetValue
        {
            get { return unit.Register; }
        }

        double Run(Command command)
        {
            undo.Push(unit.Register);
            controlUnit.StoreCommand(command);
            controlUnit.ExecuteCommand();
            return unit.Register;
        }

        public double Add(double operand)
        {
            return Run(new Add(unit, operand));
        }
        public double Sub(double operand)
        {
            return Run(new Sub(unit, operand));
        }
        public double Mul(double operand)
        {
            return Run(new Mul(unit, operand));
        }
        public double Div(double operand)
        {
            return Run(new Div(unit, operand));
        }

        public double Power(double operand)
        {
            return Run(new Power(unit, operand));
        }

        public double Ln(double operand)
        {
            return Run(new Ln(unit, operand));
        }

        public double Sqrt(double operand)
        {
            return Run(new Sqrt(unit, operand));
        }
        public void Redo()
        {
            /* controlUnit.Redo();
             undo.Push(unit.Register);*/
            undo.Push(unit.Register);
            controlUnit.StoreCommand(controlUnit.GetLastCommand);
            controlUnit.ExecuteCommand();
        }

        public double Undo()
        {
            unit.Register = controlUnit.Undo(undo);
            return unit.Register;
            //return controlUnit.Undo(undo);
        }
    }
}
