using EFramework.Core.Ecs;

namespace CC.Core
{
    public class CCWorldModule
    {
        private EcsWorld _world;

        public CCWorldModule()
        {
            _world = new EcsWorld();
        }
    }
}