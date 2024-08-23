using System;
using System.Collections.Generic;

namespace EFramework.Core.Ecs
{
    public class SparseListItem<T>
    {
        public SparseListItem(T value, int id)
        {
            Value = value;
            Id = id;
        }

        public int Id { get; set; }

        public T Value { get; set; }
    }

    public class SparseList<TValue> : ISparseCollection<SparseListItem<TValue>>
    {
        private const int Invalid = -1;
        
        private readonly SparseListItem<TValue>[] _density;

        private readonly int[] _sparse;

        private int _current;

        public TValue this[int index]
        {
            get => Get(index);

            set => Add(value);
        }

        public TValue Get(int index)
        {
            if (index < 0 || index >= _sparse.Length)
            {
                throw new IndexOutOfRangeException($"Key {index} is out of range 0..{_sparse.Length}");
            }

            if (!TryGetIndex(index, out var mapIndex))
            {
                throw new KeyNotFoundException($"Key {index} is not found");
            }

            return _density[index].Value!;
        }

        public bool TryGetValue(int key, out TValue value)
        {
            if (key < 0 || key >= _sparse.Length || !TryGetIndex(key, out var index))
            {
                value = default;
                return false;
            }

            value = _density[index].Value!;
            return true;
        }

        public int Add(TValue value)
        {
            var id = _current;
            if (id < 0 || id >= _sparse.Length)
            {
                //TODO Ensure List
            }

            var entry = new SparseListItem<TValue>(value, id);
            ((ISparseCollection<SparseListItem<TValue>>)this).Add(entry);
            return id;
        }

        public void Remove(int id)
        {
            if (TryGetValue(id, out var value) == false)
            {
                return;
            }

            var index = _sparse[id];
            var last = _density[_current - 1];
            
            _density[index] = _density[_current - 1];
            _sparse[last.Id] = index;
            _current--;
        }

        public void Clear()
        {
            _current = 0;
            for (var i = 0; i < _sparse.Length; i++)
            {
                _sparse[i] = Invalid;
            }
            
            //release value reference
            for (var i = 0; i < _density.Length; i++)
            {
                _density[i] = null;
            }
        }

        void ISparseCollection<SparseListItem<TValue>>.Add(SparseListItem<TValue> entry)
        {
            throw new Exception("Don't call with interface");
        }

        void ISparseCollection<SparseListItem<TValue>>.Remove(SparseListItem<TValue> entry)
        {
            _sparse[entry.Id] = _current;
            _density[_current] = entry;
            _current++;
        }

        private bool TryGetIndex(int id, out int index)
        {
            index = _sparse[id];
            return index < _current && _density[index].Id == id;
        }

        private bool Constains(int index)
        {
            return index >= 0 && index < +_sparse.Length && TryGetIndex(index, out var _);
        }
    }
}