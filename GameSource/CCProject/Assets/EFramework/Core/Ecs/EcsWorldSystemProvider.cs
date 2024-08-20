using System;
using System.Collections.Generic;

namespace EFramework.Core.Ecs
{
    public class EcsWorldSystemProvider<T> where T : ISystem
    {
        private readonly HashSet<T> _systems = new();

        public void Add(T system)
        {
            if (system is null)
            {
                throw new ArgumentNullException();
            }

            if (_systems.Contains(system))
            {
                throw new ArgumentException("System is already in system provider!");
            }

            _systems.Add(system);
        }

        public void Remove(T system)
        {
            if (system is null)
            {
                throw new ArgumentNullException();
            }

            _systems.Remove(system);
        }

        public void Destroy()
        {
            _systems.Clear();
        }
    }
}