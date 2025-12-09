using System.Collections;
using System.ComponentModel;

namespace AoC25.Day3.Lobby.Part2;

public class AscSortedList<T> : IList<T>
{
    private readonly List<T> _internalList = [];

    public AscSortedList(IEnumerable<T>? initial = null, Comparer<T>? comparer = null)
    {
        Comparer = comparer ?? Comparer<T>.Default;

        if (initial == null) return;
        
        foreach (var i in initial)
            Add(i);
    }

    public Comparer<T> Comparer { get; }

    public IEnumerator<T> GetEnumerator()
        => _internalList.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => _internalList.GetEnumerator();

    public void Add(T item)
    {
        foreach (var x in _internalList.Index())
        {
            if (Comparer.Compare(x.Item, item) <= 0) 
                continue;
            _internalList.Insert(x.Index, item);
            return;
        }
        _internalList.Add(item);
    }

    public void Clear()
        => _internalList.Clear();

    public bool Contains(T item)
        => _internalList.Contains(item);

    public void CopyTo(T[] array, int arrayIndex)
        => _internalList.CopyTo(array, arrayIndex);

    public bool Remove(T item)
        => _internalList.Remove(item);

    public int Count => _internalList.Count;
    public bool IsReadOnly => false;

    public int IndexOf(T item)
        => _internalList.IndexOf(item);

    public void Insert(int index, T item)
        => _internalList.Insert(index, item);

    public void RemoveAt(int index)
        => _internalList.RemoveAt(index);

    public T this[int index]
    {
        get => _internalList[index];
        set => throw new InvalidOperationException();
    }
}