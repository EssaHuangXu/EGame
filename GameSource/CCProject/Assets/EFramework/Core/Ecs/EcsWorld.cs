using System;
using System.Collections.Generic;

namespace EFramework.Core.Ecs
{
    public class EcsWorld
    {
        private readonly EcsWorldSystemProvider<IStartupSystem> _startupProvider = new();

        private readonly EcsWorldSystemProvider<IUpdateSystem> _updateProvider = new();

        public EcsWorld()
        {
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
    }
}