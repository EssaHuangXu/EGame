namespace EFramework.Core.Ecs
{
    internal interface ISparseCollection<T>
    {
        void Add(T value);

        bool Remove(T value);

        void Clear();
    }
}