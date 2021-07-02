// Decompiled with JetBrains decompiler
// Type: Microsoft.JSInterop.JSRuntimeExtensions
// Assembly: Microsoft.JSInterop, Version=5.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 5D3F0A0E-3EEA-4992-A878-D01EEDFB20EC
// Assembly location: /usr/share/dotnet/shared/Microsoft.AspNetCore.App/5.0.6/Microsoft.JSInterop.dll

using System;
using System.Threading;
using System.Threading.Tasks;


#nullable enable
namespace Microsoft.JSInterop
{
  public static class JSRuntimeExtensions
  {
    public static async ValueTask InvokeVoidAsync(
      this IJSRuntime jsRuntime,
      string identifier,
      params object[] args)
    {
      if (jsRuntime == null)
        throw new ArgumentNullException(nameof (jsRuntime));
      object obj = await jsRuntime.InvokeAsync<object>(identifier, args);
    }

    public static ValueTask<TValue> InvokeAsync<TValue>(
      this IJSRuntime jsRuntime,
      string identifier,
      params object?[]? args)
    {
      if (jsRuntime == null)
        throw new ArgumentNullException(nameof (jsRuntime));
      return jsRuntime.InvokeAsync<TValue>(identifier, args);
    }

    public static ValueTask<TValue> InvokeAsync<TValue>(
      this IJSRuntime jsRuntime,
      string identifier,
      CancellationToken cancellationToken,
      params object?[]? args)
    {
      if (jsRuntime == null)
        throw new ArgumentNullException(nameof (jsRuntime));
      return jsRuntime.InvokeAsync<TValue>(identifier, cancellationToken, args);
    }

    public static async ValueTask InvokeVoidAsync(
      this IJSRuntime jsRuntime,
      string identifier,
      CancellationToken cancellationToken,
      params object[] args)
    {
      if (jsRuntime == null)
        throw new ArgumentNullException(nameof (jsRuntime));
      object obj = await jsRuntime.InvokeAsync<object>(identifier, cancellationToken, args);
    }

    public static async ValueTask<TValue> InvokeAsync<TValue>(
      this IJSRuntime jsRuntime,
      string identifier,
      TimeSpan timeout,
      params object?[]? args)
    {
      if (jsRuntime == null)
        throw new ArgumentNullException(nameof (jsRuntime));
      TValue obj;
      using (CancellationTokenSource cancellationTokenSource1 = timeout == Timeout.InfiniteTimeSpan ? (CancellationTokenSource) null : new CancellationTokenSource(timeout))
      {
        CancellationTokenSource cancellationTokenSource2 = cancellationTokenSource1;
        obj = await jsRuntime.InvokeAsync<TValue>(identifier, cancellationTokenSource2 != null ? cancellationTokenSource2.Token : CancellationToken.None, args);
      }
      return obj;
    }

    public static async ValueTask InvokeVoidAsync(
      this IJSRuntime jsRuntime,
      string identifier,
      TimeSpan timeout,
      params object[] args)
    {
      if (jsRuntime == null)
        throw new ArgumentNullException(nameof (jsRuntime));
      using (CancellationTokenSource cancellationTokenSource1 = timeout == Timeout.InfiniteTimeSpan ? (CancellationTokenSource) null : new CancellationTokenSource(timeout))
      {
        CancellationTokenSource cancellationTokenSource2 = cancellationTokenSource1;
        object obj = await jsRuntime.InvokeAsync<object>(identifier, cancellationTokenSource2 != null ? cancellationTokenSource2.Token : CancellationToken.None, args);
      }
    }
  }
}
