using System;

namespace DesignPatterns
{
    class DecoratorPattern
    {
        interface IComponent
        {
            string Operation();
        }
        class Component : IComponent
        {
            public string Operation()
            {
                return "I'm walking";
            }
        }

        class DecoratorA : IComponent
        {
            IComponent component;

            public DecoratorA (IComponent c)
            {
                component = c;
            }

            public string Operation()
            {
                string str = component.Operation();
                str += " and listening to Classic FM";
                return str;
            }
        }

        class DecoratorB : IComponent
        {
            IComponent component;
            public string addedState = "past the Coffee Shop ";
            public DecoratorB(IComponent c)
            {
                component = c;
            }

            public string Operation()
            {
                string str = component.Operation();
                str += " to school";
                return str;
            }

            public string AddedBehavior()
            {
                return " and I bought a cappuccino";
            }
        }

        class Client
        {
            static void Display(string str, IComponent c)
            {
                Console.WriteLine(str + c.Operation());
            }
            static void Main(string[] args)
            {
                Console.WriteLine("Decorator Pattern\n!");
                IComponent component = new Component();
                Display("1. Basic component: ", component);
                Display("2. A-decorated : ", new DecoratorA(component));
                Display("3. B-decorated : ", new DecoratorB(component));
                Display("4. B-A-decorated : ", new DecoratorB(new DecoratorA(component)));
                DecoratorB decoratorB = new DecoratorB(new Component());
                Display("5. A-B-decorated : ", new DecoratorA(decoratorB));
                Console.WriteLine("\t\t\t" + decoratorB.addedState + decoratorB.AddedBehavior());
                Console.ReadKey();
            }
        }

    }

}
