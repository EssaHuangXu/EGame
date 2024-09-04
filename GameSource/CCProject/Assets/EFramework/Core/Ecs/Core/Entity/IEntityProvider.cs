namespace EFramework.Core.Ecs
{
    public interface IEntityProvider
    {
        EntityKey CreateEntity();

        bool DestroyEntity(EntityKey key);
        
        bool IsEntityValid(EntityKey key);
    }
}