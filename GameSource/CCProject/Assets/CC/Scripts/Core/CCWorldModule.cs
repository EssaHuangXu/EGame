using EFramework.Core.Ecs;
using UnityEngine;

namespace CC.Core
{
    public class CCWorldModule
    {
        private EcsWorld _world;

        public CCWorldModule()
        {
            _world = new EcsWorld(new EcsEntityProvider());
            var entity1 = _world.CreateEntity();
            var entity2 = _world.CreateEntity();
            var entity3 = _world.CreateEntity();

            _world.DestroyEntity(entity2);

            var entity4 = _world.CreateEntity();

            Debug.Log($"Entity {entity1.ToString()} valid {_world.IsEntityValid(entity1)}");
            Debug.Log($"Entity {entity2.ToString()} valid {_world.IsEntityValid(entity2)}");
            Debug.Log($"Entity {entity3.ToString()} valid {_world.IsEntityValid(entity3)}");
            Debug.Log($"Entity {entity4.ToString()} valid {_world.IsEntityValid(entity4)}");
        }
    }
}