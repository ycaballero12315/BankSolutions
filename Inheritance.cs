using System;
using System.Collections.Generic;
using System.Text;

namespace BankSolutions
{
    public abstract class A
    {
        private int _number = 34;


        public abstract void Element();
        public abstract class B : A
        {
            public int PrintNumber()
            {
                return _number;
            }

            public override void Element()
            {
                Console.WriteLine("Yo si heredo, soy abstracto.");
            }
        }
    }
    public class C : A
    {
        public override void Element()
        {
            Console.WriteLine("Yo si heredo, soy abstracto. Pero desde C");
        }
    }

    public record Person(string Name, int Age);
}
