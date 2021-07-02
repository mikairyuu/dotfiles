// Decompiled with JetBrains decompiler
// Type: System.Collections.Generic.KeyValuePair
// Assembly: System.Private.CoreLib, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// MVID: BA9E6474-B363-4C3C-9080-A30AE164265D
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.6/System.Private.CoreLib.dll

using System.Text;


#nullable enable
namespace System.Collections.Generic
{
  public static class KeyValuePair
  {
    public static KeyValuePair<TKey, TValue> Create<TKey, TValue>(
      TKey key,
      TValue value)
    {
      return new KeyValuePair<TKey, TValue>(key, value);
    }


    #nullable disable
    internal static unsafe string PairToString(object key, object value)
    {
      // ISSUE: untyped stack allocation
      ValueStringBuilder valueStringBuilder = new ValueStringBuilder(new Span<char>((void*) __untypedstackalloc(new IntPtr(128)), 64));
      valueStringBuilder.Append('[');
      if (key != null)
        valueStringBuilder.Append(key.ToString());
      valueStringBuilder.Append(", ");
      if (value != null)
        valueStringBuilder.Append(value.ToString());
      valueStringBuilder.Append(']');
      return valueStringBuilder.ToString();
    }
  }
}
