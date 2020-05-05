using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public interface IPizza
    {
        void Prepare();
    }

    public class Exotica : IPizza
    {
        public void Prepare()
        {
            Console.WriteLine("Exotica");
        }
    }

    public class Veggie : IPizza
    {
        public void Prepare()
        {
            Console.WriteLine("Veggie");
        }
    }

    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza pizza;

        public PizzaDecorator(IPizza obj)
        {
            pizza = obj;
            Console.WriteLine("PizzaDecorator");

        }

        public virtual void Prepare()
        {
            Console.WriteLine(" Prepare PizzaDecorator");
            pizza.Prepare();
        }
    }

    public class Exotica1 : PizzaDecorator
    {
        public Exotica1(IPizza obj) : base(obj)
        {
            Console.WriteLine("Exotica1 ctor");
        }

        public override void Prepare()
        {
            Console.WriteLine("Prepare Exotica1");
            pizza.Prepare();
            AddExtraChesse();
        }

        private void AddExtraChesse()
        {
            Console.WriteLine("AddExtraChesse");
        }
    }

    public class Exotica2 : PizzaDecorator
    {
        public Exotica2(IPizza obj) : base(obj)
        {
            Console.WriteLine("Exotica2 ctor");
        }

        public override void Prepare()
        {
            Console.WriteLine("Prepare Exotica2");
            pizza.Prepare();
            Console.WriteLine("AddSpice");
        }
    }

    public class PizzaProblem
    {
        static void Main(string[] args)
        {
            IPizza pizzaObj = new Exotica();
            IPizza Exotica1 = new Exotica1(pizzaObj);
            Exotica1.Prepare(); //Chessey

            IPizza Exotica2 = new Exotica2(pizzaObj);
            Exotica2.Prepare(); //Spicy

            var obj = new Exotica2( new Exotica1( new Exotica()));
            obj.Prepare();

            Console.WriteLine();

            IPizza Veggie = new Veggie();
            Veggie.Prepare();

        }
    }
}
