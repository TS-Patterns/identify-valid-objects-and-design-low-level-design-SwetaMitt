using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleDispatchProblemSoln
{
    public class A
    {
        public virtual void Test()
        {
            Console.WriteLine("A");
        }

        public void Accept(C obj)
        {
            obj.Fun(this);
        }
    }

    public class B : A
    {
        public override void Test()
        {
            Console.WriteLine("B");
        }
        public void Accept(D obj)
        {
            obj.Fun(this);
        }
    }

    public class C
    {
        public virtual void Fun(A obj)
        {
            obj.Test();
        }

        public virtual void Fun(B obj)
        {
            obj.Test();
        }
    }

    public class D : C
    {
        public override void Fun(A obj)
        {
            obj.Test();
        }

        public override void Fun(B obj)
        {
            obj.Test();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A obj = new B();         
            obj.Test();
            C cOBj = new D();
            cOBj.Fun(obj);
            obj.Accept(cOBj);
        }
    }
}
