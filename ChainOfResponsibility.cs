using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class ChainOfResponsibilityProg
    {
        //Abstract class
        abstract class Component
        {
            protected Component successor;
            public void SetSuccessor(Component successor)
            {
                this.successor = successor;
            }
            public abstract void HandleRequest();
        }

        class ConcreteComponent1 : Component
        {
            public override void HandleRequest()
            {
                Console.WriteLine("{0} handled request",
                    this.GetType().Name);
                successor?.HandleRequest();
            }
        }

        class ConcreteComponent2 : Component
        {
            public override void HandleRequest()
            {
                Console.WriteLine("{0} handled request",
                    this.GetType().Name);

                successor?.HandleRequest();
            }
        }

        class ConcreteComponent3 : Component
        {
            public override void HandleRequest()
            {
                Console.WriteLine("{0} handled request",
                    this.GetType().Name);
                successor?.HandleRequest();
            }
        }

        static void Main(string[] args)
        {
            // Setup Chain of Responsibility

            Component h1 = new ConcreteComponent1();
            Component h2 = new ConcreteComponent2();
            Component h3 = new ConcreteComponent3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            h1.HandleRequest();

        }
    }
}
