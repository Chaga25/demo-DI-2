using System;

namespace demo_DI
{
    public interface IoContainer
    {
        void Register<T>()
            where T : class;

        void Register<T, R>()
            where R : class, T;

        void Register<T>(Func<T> factory);

        /// <summary>
        /// Resolve function T type can be class or interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();
    }
}
