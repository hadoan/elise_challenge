using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations
{
    public class Manager : IManager
    {
        private readonly IType _type;
        public Manager(IType type)
        {
            _type = type;
        }
        public void Test()
        {
            Console.WriteLine("This is test function from Manager class");

            Console.WriteLine("Call test function from IType");
            _type.Test();
        }
    }
}
