using System;

namespace AIE_37_BrainFInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Interpreter interpreter = new Interpreter();
            interpreter.Run("--[----->+-<]>.");
        }
    }
}
