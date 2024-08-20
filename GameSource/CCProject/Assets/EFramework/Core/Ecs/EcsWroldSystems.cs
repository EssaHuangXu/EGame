namespace EFramework.Core.Ecs
{
    public interface ISystem
    {
        
    }
    
    public interface IStartupSystem : ISystem
    {
        public void Startup();
    }
    
    public interface IUpdateSystem : ISystem
    {
        public void Update();
    }
}