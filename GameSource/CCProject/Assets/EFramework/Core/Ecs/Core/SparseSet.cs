using System;
using System.Collections.Generic;
using System.Linq;
using EFramework.Core.Ecs;

public class SparseSet : ISparseCollection<int>
{
    private const int Invalid = -1;

    private const int Capacity = 100;

    private int _current = 0;

    private int[] _sparse;

    private int[] _density;

    public SparseSet(int capacity = Capacity)
    {
        _sparse = Enumerable.Repeat(-1, capacity).ToArray();
        _density = Enumerable.Repeat(-1, capacity).ToArray();
    }
    
    public void Add(int value)
    {
        if (_current >= _density.Length)
        {
            EnsureCapacity(ref _density);
        }

        _density[_current] = value;


        if (value >= _sparse.Length)
        {
            EnsureCapacity(ref _sparse);
        }

        _sparse[value] = _current;

        _current++;
    }

    public void Remove(int value)
    {
        if (_current <= 0 || value >= _sparse.Length)
        {
            throw new ArgumentOutOfRangeException($@"SparseSet doesn`t have a value {value}");
        }

        var mapIndex = _sparse[value];
        if (mapIndex == Invalid)
        {
            throw new ArgumentOutOfRangeException($@"SparseSet doesn`t have a value {value}");
        }
        
        var nowValue = _density[_current - 1];
        _density[mapIndex] = nowValue;
        _density[_current - 1] = Invalid;
        
        _sparse[value] = Invalid;
        _sparse[nowValue] = mapIndex;
        _current--;
    }

    public void Clear()
    {
        _current = 0;
        for (var i = 0; i < _sparse.Length; i++)
        {
            _sparse[i] = Invalid;
        }

        for (var j = 0; j < _density.Length; j++)
        {
            _density[j] = Invalid;
        }
    }
    
    private static void EnsureCapacity(ref int[] array)
    {
        Array.Resize(ref array, array.Length * 2);
    }
}