using System;
using System.Collections.Generic;
using System.Linq;

public class SparseSet
{
    private const int Invalid = -1;

    private const int Capacity = 100;

    private int _tail = 0;

    private int[] _sparse;

    private int[] _density;

    public SparseSet()
    {
        _sparse = Enumerable.Repeat(-1, Capacity).ToArray();
        _density = Enumerable.Repeat(-1, Capacity).ToArray();
    }
    
    public void Add(int value)
    {
        if (_tail >= _density.Length)
        {
            EnsureCapacity(ref _density);
        }

        _density[_tail] = value;


        if (value >= _sparse.Length)
        {
            EnsureCapacity(ref _sparse);
        }

        _sparse[value] = _tail;

        _tail++;
    }

    public void Remove(int value)
    {
        if (_tail <= 0 || value >= _sparse.Length)
        {
            throw new ArgumentOutOfRangeException($@"SparseSet doesn`t have a value {value}");
        }

        var mapIndex = _sparse[value];
        if (mapIndex == Invalid)
        {
            throw new ArgumentOutOfRangeException($@"SparseSet doesn`t have a value {value}");
        }
        
        var nowValue = _density[_tail - 1];
        _density[mapIndex] = nowValue;
        _density[_tail - 1] = Invalid;
        
        _sparse[value] = Invalid;
        _sparse[nowValue] = mapIndex;
        _tail--;
    }

    private static void EnsureCapacity(ref int[] array)
    {
        Array.Resize(ref array, array.Length * 2);
    }
}