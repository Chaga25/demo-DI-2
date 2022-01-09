using demo_DI.Abstractions;
using System;
using System.Reflection;

namespace demo_DI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container();

            Init(container);
            Test1(container);
            Test2(container);
            Test3(container);
            Test4(container);

            Console.ReadKey();
        }

        static void Init(IoContainer container)
        {
            container.Register<Test>();
            container.Register<User>();
            container.Register<IDirectLink, DirectLink>();
            container.Register<IForDelegate>(() =>
            {
                return new ForDelegate();
            });

            //can be many...
        }

        static void Test1(IoContainer container)
        {
            var userEntity = container.Resolve<IUserEntity>();
            Console.WriteLine(userEntity.Ping());
        }

        static void Test2(IoContainer container)
        {
            var test = container.Resolve<Test>();
            Console.WriteLine(test.Log());
        }

        static void Test3(IoContainer container)
        {
            var test = container.Resolve<IDirectLink>();
            Console.WriteLine(test.Ping());
        }

        static void Test4(IoContainer container)
        {
            var test = container.Resolve<IForDelegate>();
            Console.WriteLine(test.SomeMethod());
        }
    }
}
