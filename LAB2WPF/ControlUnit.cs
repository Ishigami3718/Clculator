using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2WPF
{
    class ControlUnit
    {
        private Stack<Command> commands = new Stack<Command>();
        private int current = 0;

        public Command GetLastCommand
        {
            get { return commands.Peek(); }
        }
        public void StoreCommand(Command command)
        {
            commands.Push(command);
        }

        public void ExecuteCommand()
        {
            commands.Peek().Execute();
            //current++;
        }

       /* public void Redo()
        {
            commands.Peek().Execute();
            commands.Push(commands.Peek());
        }*/

        public double Undo(Stack<double> undo)
        {
            //if(current>0) current--;
            commands.Pop();
            return undo.Pop();
        }
    }
}
