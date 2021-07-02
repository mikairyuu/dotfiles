// Decompiled with JetBrains decompiler
// Type: System.Threading.Tasks.ValueTask`1
// Assembly: System.Private.CoreLib, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// MVID: BA9E6474-B363-4C3C-9080-A30AE164265D
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.6/System.Private.CoreLib.dll

using Internal.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Sources;


#nullable enable
namespace System.Threading.Tasks
{
  [AsyncMethodBuilder(typeof (AsyncValueTaskMethodBuilder<>))]
  [StructLayout(LayoutKind.Auto)]
  public readonly struct ValueTask<TResult> : IEquatable<ValueTask<TResult>>
  {

    #nullable disable
    private static Task<TResult> s_canceledTask;
    internal readonly object _obj;
    internal readonly TResult _result;
    internal readonly short _token;
    internal readonly bool _continueOnCapturedContext;


    #nullable enable
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask(TResult result)
    {
      this._result = result;
      this._obj = (object) null;
      this._continueOnCapturedContext = true;
      this._token = (short) 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask(Task<TResult> task)
    {
      if (task == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.task);
      this._obj = (object) task;
      this._result = default (TResult);
      this._continueOnCapturedContext = true;
      this._token = (short) 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask(IValueTaskSource<TResult> source, short token)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      this._obj = (object) source;
      this._token = token;
      this._result = default (TResult);
      this._continueOnCapturedContext = true;
    }


    #nullable disable
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask(object obj, TResult result, short token, bool continueOnCapturedContext)
    {
      this._obj = obj;
      this._result = result;
      this._token = token;
      this._continueOnCapturedContext = continueOnCapturedContext;
    }

    public override int GetHashCode()
    {
      if (this._obj != null)
        return this._obj.GetHashCode();
      return (object) this._result == null ? 0 : this._result.GetHashCode();
    }


    #nullable enable
    public override bool Equals(object? obj) => obj is ValueTask<TResult> other && this.Equals(other);

    public bool Equals(ValueTask<TResult> other)
    {
      if (this._obj == null && other._obj == null)
        return EqualityComparer<TResult>.Default.Equals(this._result, other._result);
      return this._obj == other._obj && (int) this._token == (int) other._token;
    }

    public static bool operator ==(ValueTask<TResult> left, ValueTask<TResult> right) => left.Equals(right);

    public static bool operator !=(ValueTask<TResult> left, ValueTask<TResult> right) => !left.Equals(right);

    public Task<TResult> AsTask()
    {
      object obj = this._obj;
      if (obj == null)
        return AsyncTaskMethodBuilder<TResult>.GetTaskForResult(this._result);
      return obj is Task<TResult> task ? task : this.GetTaskForValueTaskSource(Unsafe.As<IValueTaskSource<TResult>>(obj));
    }

    public ValueTask<TResult> Preserve() => this._obj != null ? new ValueTask<TResult>(this.AsTask()) : this;


    #nullable disable
    private Task<TResult> GetTaskForValueTaskSource(IValueTaskSource<TResult> t)
    {
      ValueTaskSourceStatus status = t.GetStatus(this._token);
      if (status == ValueTaskSourceStatus.Pending)
        return (Task<TResult>) new ValueTask<TResult>.ValueTaskSourceAsTask(t, this._token);
      try
      {
        return AsyncTaskMethodBuilder<TResult>.GetTaskForResult(t.GetResult(this._token));
      }
      catch (Exception ex)
      {
        if (status != ValueTaskSourceStatus.Canceled)
          return Task.FromException<TResult>(ex);
        if (ex is OperationCanceledException canceledException1)
        {
          Task<TResult> task = new Task<TResult>();
          task.TrySetCanceled(canceledException1.CancellationToken, (object) canceledException1);
          return task;
        }
        Task<TResult> task1 = ValueTask<TResult>.s_canceledTask;
        if (task1 == null)
          ValueTask<TResult>.s_canceledTask = task1 = Task.FromCanceled<TResult>(new CancellationToken(true));
        return task1;
      }
    }

    public bool IsCompleted
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)] get
      {
        object obj = this._obj;
        if (obj == null)
          return true;
        return obj is Task<TResult> task ? task.IsCompleted : (uint) Unsafe.As<IValueTaskSource<TResult>>(obj).GetStatus(this._token) > 0U;
      }
    }

    public bool IsCompletedSuccessfully
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)] get
      {
        object obj = this._obj;
        if (obj == null)
          return true;
        return obj is Task<TResult> task ? task.IsCompletedSuccessfully : Unsafe.As<IValueTaskSource<TResult>>(obj).GetStatus(this._token) == ValueTaskSourceStatus.Succeeded;
      }
    }

    public bool IsFaulted
    {
      get
      {
        object obj = this._obj;
        if (obj == null)
          return false;
        return obj is Task<TResult> task ? task.IsFaulted : Unsafe.As<IValueTaskSource<TResult>>(obj).GetStatus(this._token) == ValueTaskSourceStatus.Faulted;
      }
    }

    public bool IsCanceled
    {
      get
      {
        object obj = this._obj;
        if (obj == null)
          return false;
        return obj is Task<TResult> task ? task.IsCanceled : Unsafe.As<IValueTaskSource<TResult>>(obj).GetStatus(this._token) == ValueTaskSourceStatus.Canceled;
      }
    }


    #nullable enable
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public TResult Result
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)] get
      {
        object obj = this._obj;
        if (obj == null)
          return this._result;
        if (!(obj is Task<TResult> task))
          return Unsafe.As<IValueTaskSource<TResult>>(obj).GetResult(this._token);
        TaskAwaiter.ValidateEnd((Task) task);
        return task.ResultOnSuccess;
      }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTaskAwaiter<TResult> GetAwaiter() => new ValueTaskAwaiter<TResult>(in this);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ConfiguredValueTaskAwaitable<TResult> ConfigureAwait(
      bool continueOnCapturedContext)
    {
      ValueTask<TResult> valueTask = new ValueTask<TResult>(this._obj, this._result, this._token, continueOnCapturedContext);
      return new ConfiguredValueTaskAwaitable<TResult>(in valueTask);
    }

    public override string? ToString()
    {
      if (this.IsCompletedSuccessfully)
      {
        Debugger.NotifyOfCrossThreadDependency();
        TResult result = this.Result;
        if ((object) result != null)
          return result.ToString();
      }
      return string.Empty;
    }


    #nullable disable
    private sealed class ValueTaskSourceAsTask : Task<TResult>
    {
      private static readonly Action<object> s_completionAction = (Action<object>) (state =>
      {
        if (state is ValueTask<TResult>.ValueTaskSourceAsTask taskSourceAsTask2)
        {
          IValueTaskSource<TResult> source = taskSourceAsTask2._source;
          if (source != null)
          {
            taskSourceAsTask2._source = (IValueTaskSource<TResult>) null;
            ValueTaskSourceStatus status = source.GetStatus(taskSourceAsTask2._token);
            try
            {
              taskSourceAsTask2.TrySetResult(source.GetResult(taskSourceAsTask2._token));
              return;
            }
            catch (Exception ex)
            {
              if (status == ValueTaskSourceStatus.Canceled)
              {
                if (ex is OperationCanceledException canceledException9)
                {
                  taskSourceAsTask2.TrySetCanceled(canceledException9.CancellationToken, (object) canceledException9);
                  return;
                }
                taskSourceAsTask2.TrySetCanceled(new CancellationToken(true));
                return;
              }
              taskSourceAsTask2.TrySetException((object) ex);
              return;
            }
          }
        }
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.state);
      });
      private IValueTaskSource<TResult> _source;
      private readonly short _token;

      public ValueTaskSourceAsTask(IValueTaskSource<TResult> source, short token)
      {
        this._source = source;
        this._token = token;
        source.OnCompleted(ValueTask<TResult>.ValueTaskSourceAsTask.s_completionAction, (object) this, token, ValueTaskSourceOnCompletedFlags.None);
      }
    }
  }
}
