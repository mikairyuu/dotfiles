// Decompiled with JetBrains decompiler
// Type: System.Collections.Generic.KeyValuePair`2
// Assembly: System.Private.CoreLib, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// MVID: FE09258F-EA79-4DCF-AC23-6315CF2A4178
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.3/System.Private.CoreLib.dll

using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;


#nullable enable
namespace System.Collections.Generic
{
  [TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
  [Serializable]
  public readonly struct KeyValuePair<TKey, TValue>
  {
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly 
    #nullable disable
    TKey key;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly TValue value;

    public KeyValuePair(
    #nullable enable
    TKey key, TValue value)
    {
      this.key = key;
      this.value = value;
    }

    public TKey Key => this.key;

    public TValue Value => this.value;

    public override string ToString() => KeyValuePair.PairToString((object) this.Key, (object) this.Value);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Deconstruct(out TKey key, out TValue value)
    {
      key = this.Key;
      value = this.Value;
    }
  }
}
