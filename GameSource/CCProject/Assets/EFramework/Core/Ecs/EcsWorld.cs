using System;
using System.Collections.Generic;

namespace EFramework.Core.Ecs
{
    public class EcsWorld
    {
        private readonly EcsWorldSystemProvider<IStartupSystem> _startupProvider = new();

        private readonly EcsWorldSystemProvider<IUpdateSystem> _updateProvider = new();

        private IEntityProvider _provider;

        public EcsWorld(IEntityProvider provider)
        {
            _provider = provider;
        }

        public void Destroy()
        {
            _startupProvider.Destroy();
            _updateProvider.Destroy();
        }

        public void AddStartupSystem(IStartupSystem system)
        {
            _startupProvider.Add(system);
        }

        public void AddUpdateSystem(IUpdateSystem system)
        {
            _updateProvider.Add(system);
        }

        public EntityKey CreateEntity()
        {
            return _provider.CreateEntity();
        }

        public bool DestroyEntity(EntityKey key)
        {
            return _provider.DestroyEntity(key);
        }

        public bool IsEntityValid(EntityKey key)
        {
            return _provider.IsEntityValid(key);
        }
    }
}