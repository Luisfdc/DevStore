using System;
using System.Globalization;
using System.Reflection;

namespace DevStore.Application
{
    public class Singleton<TFactoryObject>
        where TFactoryObject : class 
    {
        /// <summary>
        ///     Gets the singleton instance of this class.
        /// </summary>
        public static TFactoryObject Instance
        {
            get
            {
                try
                {
                    return SingletonFactory.InternalInstance;
                }
                catch (Exception)
                {
                }
                return null;
            }
        }

        /// <summary>
        ///     The singleton class factory to create the singleton instance.
        /// </summary>
        public class SingletonFactory
        {
            // ReSharper disable StaticFieldInGenericType
            internal static readonly TFactoryObject InternalInstance = GetInstance();
            // ReSharper restore StaticFieldInGenericType

            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static SingletonFactory()
            {
            }

            // Prevent the compiler from generating a default constructor.
            private SingletonFactory()
            {
            }

            private static TFactoryObject GetInstance()
            {
                var theType = typeof(TFactoryObject);

                TFactoryObject inst;

                try
                {
                    inst =
                        (TFactoryObject)
                            theType.InvokeMember(theType.Name,
                                BindingFlags.CreateInstance | BindingFlags.Instance |
                                BindingFlags.NonPublic,
                                null,
                                null,
                                null,
                                CultureInfo.InvariantCulture);
                }
                catch (MissingMethodException ex)
                {
                    throw new TypeLoadException(
                        string.Format(CultureInfo.CurrentCulture,
                            "The type '{0}' must have a private constructor to " +
                            "be used in the Singleton pattern.",
                            theType.FullName),
                        ex);
                }
                return inst;
            }
        }
    }
}
