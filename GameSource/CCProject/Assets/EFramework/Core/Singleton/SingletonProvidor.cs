#nullable enable

namespace EFramework.Core.Singleton
{
    public static class SingletonProvidor<T> where T : new()
    {
        private static T? _instance;

        private static readonly object _lock = new();

        public static T Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                lock (_lock)
                {
                    _instance ??= new T();
                }

                return _instance;
            }
        }
    }
}