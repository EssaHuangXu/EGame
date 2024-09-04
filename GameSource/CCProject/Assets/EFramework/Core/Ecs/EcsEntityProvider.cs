using System;
using System.Collections.Generic;

namespace EFramework.Core.Ecs
{
    //every entity id is unique
    public class EcsEntityProvider : IEntityProvider
    {
        private const int Capcity = 2;
        
        private EntityKey[] _cache;

        private int _current = 0;

        private readonly Stack<int> _freeList = new();

        public EcsEntityProvider()
        {
            _cache = new EntityKey[Capcity];
        }   

        public EntityKey CreateEntity()
        {
            if (_freeList.Count > 0)
            {
                var index = _freeList.Pop();
                return _cache[index];
            }

            if (_current >= _cache.Length)
            {
                Array.Resize(ref _cache, 2 * Capcity);
            }

            _cache[_current] = EntityKey.Create((uint)_current);
            _current++;
            return _cache[_current - 1];
        }

        public bool DestroyEntity(EntityKey key)
        {
            if (key.Valid == false)
            {
                throw new InvalidOperationException("Destroy Entity Twice!");
            }

            var index = (int)key.Id;
            ref var inner = ref _cache[index];
            inner.Resign();
            _freeList.Push((int)key.Id);
            return true;
        }

        public bool IsEntityValid(EntityKey key)
        {
            var index = (int)key.Id;
            return key.Generation == _cache[index].Generation;
        }
    }
}