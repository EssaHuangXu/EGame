namespace EFramework.Core.Ecs
{
    public interface IPool<T>
    {
        T Create();
        bool Reverse(T value);
    }
}