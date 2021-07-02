// Decompiled with JetBrains decompiler
// Type: System.Collections.Generic.Stack`1
// Assembly: System.Collections, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: 68A820DD-E51F-4EB1-9A88-2D5B67486907
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.6/System.Collections.dll

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;


#nullable enable
namespace System.Collections.Generic
{
  [DebuggerTypeProxy(typeof (StackDebugView<>))]
  [DebuggerDisplay("Count = {Count}")]
  [TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
  [Serializable]
  public class Stack<T> : IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>
  {

    #nullable disable
    private T[] _array;
    private int _size;
    private int _version;

    public Stack() => this._array = Array.Empty<T>();

    public Stack(int capacity) => this._array = capacity >= 0 ? new T[capacity] : throw new ArgumentOutOfRangeException(nameof (capacity), (object) capacity, SR.ArgumentOutOfRange_NeedNonNegNum);


    #nullable enable
    public Stack(IEnumerable<T> collection) => this._array = collection != null ? EnumerableHelpers.ToArray<T>(collection, out this._size) : throw new ArgumentNullException(nameof (collection));

    public int Count => this._size;

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => (object) this;

    public void Clear()
    {
      if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
        Array.Clear((Array) this._array, 0, this._size);
      this._size = 0;
      ++this._version;
    }

    public bool Contains(T item) => this._size != 0 && Array.LastIndexOf<T>(this._array, item, this._size - 1) != -1;

    public void CopyTo(T[] array, int arrayIndex)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (arrayIndex < 0 || arrayIndex > array.Length)
        throw new ArgumentOutOfRangeException(nameof (arrayIndex), (object) arrayIndex, SR.ArgumentOutOfRange_Index);
      if (array.Length - arrayIndex < this._size)
        throw new ArgumentException(SR.Argument_InvalidOffLen);
      int num1 = 0;
      int num2 = arrayIndex + this._size;
      while (num1 < this._size)
        array[--num2] = this._array[num1++];
    }


    #nullable disable
    void ICollection.CopyTo(Array array, int arrayIndex)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (array.Rank != 1)
        throw new ArgumentException(SR.Arg_RankMultiDimNotSupported, nameof (array));
      if (array.GetLowerBound(0) != 0)
        throw new ArgumentException(SR.Arg_NonZeroLowerBound, nameof (array));
      if (arrayIndex < 0 || arrayIndex > array.Length)
        throw new ArgumentOutOfRangeException(nameof (arrayIndex), (object) arrayIndex, SR.ArgumentOutOfRange_Index);
      if (array.Length - arrayIndex < this._size)
        throw new ArgumentException(SR.Argument_InvalidOffLen);
      try
      {
        Array.Copy((Array) this._array, 0, array, arrayIndex, this._size);
        Array.Reverse(array, arrayIndex, this._size);
      }
      catch (ArrayTypeMismatchException ex)
      {
        throw new ArgumentException(SR.Argument_InvalidArrayType, nameof (array));
      }
    }


    #nullable enable
    public Stack<
    #nullable disable
    T>.Enumerator GetEnumerator() => new Stack<T>.Enumerator(this);

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => (IEnumerator<T>) new Stack<T>.Enumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new Stack<T>.Enumerator(this);

    public void TrimExcess()
    {
      if (this._size >= (int) ((double) this._array.Length * 0.9))
        return;
      Array.Resize<T>(ref this._array, this._size);
      ++this._version;
    }


    #nullable enable
    public T Peek()
    {
      int index = this._size - 1;
      T[] array = this._array;
      if ((uint) index >= (uint) array.Length)
        this.ThrowForEmptyStack();
      return array[index];
    }

    public bool TryPeek([MaybeNullWhen(false)] out T result)
    {
      int index = this._size - 1;
      T[] array = this._array;
      if ((uint) index >= (uint) array.Length)
      {
        result = default (T);
        return false;
      }
      result = array[index];
      return true;
    }

    public T Pop()
    {
      int index = this._size - 1;
      T[] array = this._array;
      if ((uint) index >= (uint) array.Length)
        this.ThrowForEmptyStack();
      ++this._version;
      this._size = index;
      T obj = array[index];
      if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
        array[index] = default (T);
      return obj;
    }

    public bool TryPop([MaybeNullWhen(false)] out T result)
    {
      int index = this._size - 1;
      T[] array = this._array;
      if ((uint) index >= (uint) array.Length)
      {
        result = default (T);
        return false;
      }
      ++this._version;
      this._size = index;
      result = array[index];
      if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
        array[index] = default (T);
      return true;
    }

    public void Push(T item)
    {
      int size = this._size;
      T[] array = this._array;
      if ((uint) size < (uint) array.Length)
      {
        array[size] = item;
        ++this._version;
        this._size = size + 1;
      }
      else
        this.PushWithResize(item);
    }


    #nullable disable
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void PushWithResize(T item)
    {
      Array.Resize<T>(ref this._array, this._array.Length == 0 ? 4 : 2 * this._array.Length);
      this._array[this._size] = item;
      ++this._version;
      ++this._size;
    }


    #nullable enable
    public T[] ToArray()
    {
      if (this._size == 0)
        return Array.Empty<T>();
      T[] objArray = new T[this._size];
      for (int index = 0; index < this._size; ++index)
        objArray[index] = this._array[this._size - index - 1];
      return objArray;
    }

    private void ThrowForEmptyStack() => throw new InvalidOperationException(SR.InvalidOperation_EmptyStack);

    public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
    {

      #nullable disable
      private readonly Stack<T> _stack;
      private readonly int _version;
      private int _index;
      private T _currentElement;

      internal Enumerator(Stack<T> stack)
      {
        this._stack = stack;
        this._version = stack._version;
        this._index = -2;
        this._currentElement = default (T);
      }

      public void Dispose() => this._index = -1;

      public bool MoveNext()
      {
        if (this._version != this._stack._version)
          throw new InvalidOperationException(SR.InvalidOperation_EnumFailedVersion);
        if (this._index == -2)
        {
          this._index = this._stack._size - 1;
          bool flag = this._index >= 0;
          if (flag)
            this._currentElement = this._stack._array[this._index];
          return flag;
        }
        if (this._index == -1)
          return false;
        bool flag1 = --this._index >= 0;
        this._currentElement = !flag1 ? default (T) : this._stack._array[this._index];
        return flag1;
      }


      #nullable enable
      public T Current
      {
        get
        {
          if (this._index < 0)
            this.ThrowEnumerationNotStartedOrEnded();
          return this._currentElement;
        }
      }

      private void ThrowEnumerationNotStartedOrEnded() => throw new InvalidOperationException(this._index == -2 ? SR.InvalidOperation_EnumNotStarted : SR.InvalidOperation_EnumEnded);

      object? IEnumerator.Current => (object) this.Current;

      void IEnumerator.Reset()
      {
        if (this._version != this._stack._version)
          throw new InvalidOperationException(SR.InvalidOperation_EnumFailedVersion);
        this._index = -2;
        this._currentElement = default (T);
      }
    }
  }
}
