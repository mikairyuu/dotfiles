// Decompiled with JetBrains decompiler
// Type: System.Linq.EnumerableSorter`2
// Assembly: System.Linq, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: C0D398D0-8333-42D8-AE84-364936C038FA
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.7/System.Linq.dll

using System.Collections.Generic;

namespace System.Linq
{
  internal sealed class EnumerableSorter<TElement, TKey> : EnumerableSorter<TElement>
  {
    private readonly Func<TElement, TKey> _keySelector;
    private readonly IComparer<TKey> _comparer;
    private readonly bool _descending;
    private readonly EnumerableSorter<TElement> _next;
    private TKey[] _keys;

    internal EnumerableSorter(
      Func<TElement, TKey> keySelector,
      IComparer<TKey> comparer,
      bool descending,
      EnumerableSorter<TElement> next)
    {
      this._keySelector = keySelector;
      this._comparer = comparer;
      this._descending = descending;
      this._next = next;
    }

    internal override void ComputeKeys(TElement[] elements, int count)
    {
      this._keys = new TKey[count];
      for (int index = 0; index < count; ++index)
        this._keys[index] = this._keySelector(elements[index]);
      this._next?.ComputeKeys(elements, count);
    }

    internal override int CompareAnyKeys(int index1, int index2)
    {
      int num = this._comparer.Compare(this._keys[index1], this._keys[index2]);
      return num == 0 ? (this._next == null ? index1 - index2 : this._next.CompareAnyKeys(index1, index2)) : (this._descending == num > 0 ? -1 : 1);
    }

    private int CompareKeys(int index1, int index2) => index1 != index2 ? this.CompareAnyKeys(index1, index2) : 0;

    protected override void QuickSort(int[] keys, int lo, int hi) => new Span<int>(keys, lo, hi - lo + 1).Sort<int>(new Comparison<int>(((EnumerableSorter<TElement>) this).CompareAnyKeys));

    protected override void PartialQuickSort(
      int[] map,
      int left,
      int right,
      int minIdx,
      int maxIdx)
    {
      do
      {
        int left1 = left;
        int right1 = right;
        int index1 = map[left1 + (right1 - left1 >> 1)];
        while (true)
        {
          do
          {
            if (left1 >= map.Length || this.CompareKeys(index1, map[left1]) <= 0)
            {
              while (right1 >= 0 && this.CompareKeys(index1, map[right1]) < 0)
                --right1;
              if (left1 <= right1)
              {
                if (left1 < right1)
                {
                  int num = map[left1];
                  map[left1] = map[right1];
                  map[right1] = num;
                }
                ++left1;
                --right1;
              }
              else
                break;
            }
            else
              goto label_1;
          }
          while (left1 <= right1);
          break;
label_1:
          ++left1;
        }
        if (minIdx >= left1)
          left = left1 + 1;
        else if (maxIdx <= right1)
          right = right1 - 1;
        if (right1 - left <= right - left1)
        {
          if (left < right1)
            this.PartialQuickSort(map, left, right1, minIdx, maxIdx);
          left = left1;
        }
        else
        {
          if (left1 < right)
            this.PartialQuickSort(map, left1, right, minIdx, maxIdx);
          right = right1;
        }
      }
      while (left < right);
    }

    protected override int QuickSelect(int[] map, int right, int idx)
    {
      int num1 = 0;
      do
      {
        int index1 = num1;
        int index2 = right;
        int index1_1 = map[index1 + (index2 - index1 >> 1)];
        while (true)
        {
          do
          {
            if (index1 >= map.Length || this.CompareKeys(index1_1, map[index1]) <= 0)
            {
              while (index2 >= 0 && this.CompareKeys(index1_1, map[index2]) < 0)
                --index2;
              if (index1 <= index2)
              {
                if (index1 < index2)
                {
                  int num2 = map[index1];
                  map[index1] = map[index2];
                  map[index2] = num2;
                }
                ++index1;
                --index2;
              }
              else
                break;
            }
            else
              goto label_2;
          }
          while (index1 <= index2);
          break;
label_2:
          ++index1;
        }
        if (index1 <= idx)
          num1 = index1 + 1;
        else
          right = index2 - 1;
        if (index2 - num1 <= right - index1)
        {
          if (num1 < index2)
            right = index2;
          num1 = index1;
        }
        else
        {
          if (index1 < right)
            num1 = index1;
          right = index2;
        }
      }
      while (num1 < right);
      return map[idx];
    }

    protected override int Min(int[] map, int count)
    {
      int index1 = 0;
      for (int index2 = 1; index2 < count; ++index2)
      {
        if (this.CompareKeys(map[index2], map[index1]) < 0)
          index1 = index2;
      }
      return map[index1];
    }
  }
}
