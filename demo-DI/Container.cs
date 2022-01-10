using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace demo_DI
{
    class Container : IoContainer
    {
        private Type classType;
        private Dictionary<Type, Type> typeDictionary = new Dictionary<Type, Type>();
        public void Register<T>() where T : class
        {
            if (typeof(T).IsClass)
            {
                Type typeOfClass = typeof(T);
                Type[] myInterfaces = typeOfClass.GetInterfaces();

                foreach (var item in myInterfaces)
                    typeDictionary.Add(item,typeOfClass);

                Console.WriteLine("type of class saved");
            }
            else
            {
                Console.WriteLine("type of class did not save");
            }
        }

        public void Register<T, R>() where R : class, T
        {
            Type t1 = typeof(T);
            Type t = typeof(R);
            if (t1.IsAssignableFrom(t))
            {
                typeDictionary.Add(t1, t);
                Console.WriteLine("type of class saved");
            }
            else
            {
                Console.WriteLine("type of class did not save");
            }
        }


        public void Register<T>(Func<T> factory)
        {
            Type t = typeof(T);
            if (t.IsInterface)
            {
                foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (Type t1 in a.GetTypes())
                    {
                        if (t.IsAssignableFrom(t1) && t1.IsClass)
                        {
                            typeDictionary.Add(t, t1);
                           
                            Console.WriteLine("type of class saved");
                        }
                    }
                }
            }else if (t.IsClass)
            {
                Type[] myInterfaces = t.GetInterfaces();

                foreach (var item in myInterfaces)
                    typeDictionary.Add(item, t);
                Console.WriteLine("type of class saved");
            }
        }

        public T Resolve<T>()
        {
            Type t = typeof(T);
            if (t.IsClass)
            {
                var finalInstance = (T)Activator.CreateInstance(t);
                return finalInstance;

            }else if (t.IsInterface)
            {

                classType = typeDictionary[t];

                var finalInstance = (T)Activator.CreateInstance(classType);

                return finalInstance;
            }
            throw new NotImplementedException();
        }
    }
}
