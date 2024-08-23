namespace EFramework.Core.Ecs
{
    internal interface ISparseCollection<T>
    {
        void Add(T value);

        void Remove(T value);

        void Clear();
    }
}