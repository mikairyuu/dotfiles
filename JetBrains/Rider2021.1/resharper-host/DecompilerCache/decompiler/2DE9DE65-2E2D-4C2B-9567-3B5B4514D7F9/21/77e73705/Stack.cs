// Decompiled with JetBrains decompiler
// Type: System.Collections.Stack
// Assembly: System.Collections.NonGeneric, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: 2DE9DE65-2E2D-4C2B-9567-3B5B4514D7F9
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.7/System.Collections.NonGeneric.dll

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;


#nullable enable
namespace System.Collections
{
  [DebuggerDisplay("Count = {Count}")]
  [DebuggerTypeProxy(typeof (Stack.StackDebugView))]
  [TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
  [Serializable]
  public class Stack : ICollection, IEnumerable, ICloneable
  {

    #nullable disable
    private object[] _array;
    private int _size;
    private int _version;

    public Stack()
    {
      this._array = new object[10];
      this._size = 0;
      this._version = 0;
    }

    public Stack(int initialCapacity)
    {
      if (initialCapacity < 0)
        throw new ArgumentOutOfRangeException(nameof (initialCapacity), SR.ArgumentOutOfRange_NeedNonNegNum);
      if (initialCapacity < 10)
        initialCapacity = 10;
      this._array = new object[initialCapacity];
      this._size = 0;
      this._version = 0;
    }


    #nullable enable
    public Stack(ICollection col)
      : this(col == null ? 32 : col.Count)
    {
      if (col == null)
        throw new ArgumentNullException(nameof (col));
      foreach (object obj in (IEnumerable) col)
        this.Push(obj);
    }

    public virtual int Count => this._size;

    public virtual bool IsSynchronized => false;

    public virtual object SyncRoot => (object) this;

    public virtual void Clear()
    {
      Array.Clear((Array) this._array, 0, this._size);
      this._size = 0;
      ++this._version;
    }

    public virtual object Clone()
    {
      Stack stack = new Stack(this._size);
      stack._size = this._size;
      Array.Copy((Array) this._array, (Array) stack._array, this._size);
      stack._version = this._version;
      return (object) stack;
    }

    public virtual bool Contains(object? obj)
    {
      int size = this._size;
      while (size-- > 0)
      {
        if (obj == null)
        {
          if (this._array[size] == null)
            return true;
        }
        else if (this._array[size] != null && this._array[size].Equals(obj))
          return true;
      }
      return false;
    }

    public virtual void CopyTo(Array array, int index)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (array.Rank != 1)
        throw new ArgumentException(SR.Arg_RankMultiDimNotSupported, nameof (array));
      if (index < 0)
        throw new ArgumentOutOfRangeException(nameof (index), SR.ArgumentOutOfRange_NeedNonNegNum);
      if (array.Length - index < this._size)
        throw new ArgumentException(SR.Argument_InvalidOffLen);
      int num = 0;
      if (array is object[] objArray)
      {
        for (; num < this._size; ++num)
          objArray[num + index] = this._array[this._size - num - 1];
      }
      else
      {
        for (; num < this._size; ++num)
          array.SetValue(this._array[this._size - num - 1], num + index);
      }
    }

    public virtual IEnumerator GetEnumerator() => (IEnumerator) new Stack.StackEnumerator(this);

    public virtual object? Peek() => this._size != 0 ? this._array[this._size - 1] : throw new InvalidOperationException(SR.InvalidOperation_EmptyStack);

    public virtual object? Pop()
    {
      if (this._size == 0)
        throw new InvalidOperationException(SR.InvalidOperation_EmptyStack);
      ++this._version;
      object obj = this._array[--this._size];
      this._array[this._size] = (object) null;
      return obj;
    }

    public virtual void Push(object? obj)
    {
      if (this._size == this._array.Length)
      {
        object[] objArray = new object[2 * this._array.Length];
        Array.Copy((Array) this._array, (Array) objArray, this._size);
        this._array = objArray;
      }
      this._array[this._size++] = obj;
      ++this._version;
    }

    public static Stack Synchronized(Stack stack) => stack != null ? (Stack) new Stack.SyncStack(stack) : throw new ArgumentNullException(nameof (stack));

    public virtual object?[] ToArray()
    {
      if (this._size == 0)
        return Array.Empty<object>();
      object[] objArray = new object[this._size];
      for (int index = 0; index < this._size; ++index)
        objArray[index] = this._array[this._size - index - 1];
      return objArray;
    }


    #nullable disable
    private class SyncStack : Stack
    {
      private readonly Stack _s;
      private readonly object _root;

      internal SyncStack(Stack stack)
      {
        this._s = stack;
        this._root = stack.SyncRoot;
      }

      public override bool IsSynchronized => true;

      public override object SyncRoot => this._root;

      public override int Count
      {
        get
        {
          object root = this._root;
          bool lockTaken = false;
          try
          {
            Monitor.Enter(root, ref lockTaken);
            return this._s.Count;
          }
          finally
          {
            if (lockTaken)
              Monitor.Exit(root);
          }
        }
      }

      public override bool Contains(object obj)
      {
        object root = this._root;
        bool lockTaken = false;
        try
        {
          Monitor.Enter(root, ref lockTaken);
          return this._s.Contains(obj);
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(root);
        }
      }

      public override object Clone()
      {
        object root = this._root;
        bool lockTaken = false;
        try
        {
          Monitor.Enter(root, ref lockTaken);
          return (object) new Stack.SyncStack((Stack) this._s.Clone());
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(root);
        }
      }

      public override void Clear()
      {
        object root = this._root;
        bool lockTaken = false;
        try
        {
          Monitor.Enter(root, ref lockTaken);
          this._s.Clear();
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(root);
        }
      }

      public override void CopyTo(Array array, int arrayIndex)
      {
        object root = this._root;
        bool lockTaken = false;
        try
        {
          Monitor.Enter(root, ref lockTaken);
          this._s.CopyTo(array, arrayIndex);
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(root);
        }
      }

      public override void Push(object value)
      {
        object root = this._root;
        bool lockTaken = false;
        try
        {
          Monitor.Enter(root, ref lockTaken);
          this._s.Push(value);
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(root);
        }
      }

      public override object Pop()
      {
        object root = this._root;
        bool lockTaken = false;
        try
        {
          Monitor.Enter(root, ref lockTaken);
          return this._s.Pop();
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(root);
        }
      }

      public override IEnumerator GetEnumerator()
      {
        object root = this._root;
        bool lockTaken = false;
        try
        {
          Monitor.Enter(root, ref lockTaken);
          return this._s.GetEnumerator();
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(root);
        }
      }

      public override object Peek()
      {
        object root = this._root;
        bool lockTaken = false;
        try
        {
          Monitor.Enter(root, ref lockTaken);
          return this._s.Peek();
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(root);
        }
      }

      public override object[] ToArray()
      {
        object root = this._root;
        bool lockTaken = false;
        try
        {
          Monitor.Enter(root, ref lockTaken);
          return this._s.ToArray();
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(root);
        }
      }
    }

    private class StackEnumerator : IEnumerator, ICloneable
    {
      private readonly Stack _stack;
      private int _index;
      private readonly int _version;
      private object _currentElement;

      internal StackEnumerator(Stack stack)
      {
        this._stack = stack;
        this._version = this._stack._version;
        this._index = -2;
        this._currentElement = (object) null;
      }

      public object Clone() => this.MemberwiseClone();

      public virtual bool MoveNext()
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
        this._currentElement = !flag1 ? (object) null : this._stack._array[this._index];
        return flag1;
      }

      public virtual object Current
      {
        get
        {
          if (this._index == -2)
            throw new InvalidOperationException(SR.InvalidOperation_EnumNotStarted);
          if (this._index == -1)
            throw new InvalidOperationException(SR.InvalidOperation_EnumEnded);
          return this._currentElement;
        }
      }

      public virtual void Reset()
      {
        if (this._version != this._stack._version)
          throw new InvalidOperationException(SR.InvalidOperation_EnumFailedVersion);
        this._index = -2;
        this._currentElement = (object) null;
      }
    }

    internal class StackDebugView
    {
      private readonly Stack _stack;

      public StackDebugView(Stack stack) => this._stack = stack != null ? stack : throw new ArgumentNullException(nameof (stack));

      [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
      public object[] Items => this._stack.ToArray();
    }
  }
}
