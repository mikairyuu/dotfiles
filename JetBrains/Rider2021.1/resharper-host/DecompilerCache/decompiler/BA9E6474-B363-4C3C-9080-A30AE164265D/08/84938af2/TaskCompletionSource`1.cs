// Decompiled with JetBrains decompiler
// Type: System.Threading.Tasks.TaskCompletionSource`1
// Assembly: System.Private.CoreLib, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// MVID: BA9E6474-B363-4C3C-9080-A30AE164265D
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.6/System.Private.CoreLib.dll

using System.Collections.Generic;


#nullable enable
namespace System.Threading.Tasks
{
  public class TaskCompletionSource<TResult>
  {

    #nullable disable
    private readonly System.Threading.Tasks.Task<TResult> _task;

    public TaskCompletionSource() => this._task = new System.Threading.Tasks.Task<TResult>();

    public TaskCompletionSource(TaskCreationOptions creationOptions)
      : this((object) null, creationOptions)
    {
    }


    #nullable enable
    public TaskCompletionSource(object? state)
      : this(state, TaskCreationOptions.None)
    {
    }

    public TaskCompletionSource(object? state, TaskCreationOptions creationOptions) => this._task = new System.Threading.Tasks.Task<TResult>(state, creationOptions);

    public System.Threading.Tasks.Task<TResult> Task => this._task;

    public void SetException(Exception exception)
    {
      if (this.TrySetException(exception))
        return;
      ThrowHelper.ThrowInvalidOperationException(ExceptionResource.TaskT_TransitionToFinal_AlreadyCompleted);
    }

    public void SetException(IEnumerable<Exception> exceptions)
    {
      if (this.TrySetException(exceptions))
        return;
      ThrowHelper.ThrowInvalidOperationException(ExceptionResource.TaskT_TransitionToFinal_AlreadyCompleted);
    }

    public bool TrySetException(Exception exception)
    {
      if (exception == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.exception);
      bool flag = this._task.TrySetException((object) exception);
      if (!flag && !this._task.IsCompleted)
        this._task.SpinUntilCompleted();
      return flag;
    }

    public bool TrySetException(IEnumerable<Exception> exceptions)
    {
      if (exceptions == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.exceptions);
      List<Exception> exceptionList = new List<Exception>();
      foreach (Exception exception in exceptions)
      {
        if (exception == null)
          ThrowHelper.ThrowArgumentException(ExceptionResource.TaskCompletionSourceT_TrySetException_NullException, ExceptionArgument.exceptions);
        exceptionList.Add(exception);
      }
      if (exceptionList.Count == 0)
        ThrowHelper.ThrowArgumentException(ExceptionResource.TaskCompletionSourceT_TrySetException_NoExceptions, ExceptionArgument.exceptions);
      bool flag = this._task.TrySetException((object) exceptionList);
      if (!flag && !this._task.IsCompleted)
        this._task.SpinUntilCompleted();
      return flag;
    }

    public void SetResult(TResult result)
    {
      if (this.TrySetResult(result))
        return;
      ThrowHelper.ThrowInvalidOperationException(ExceptionResource.TaskT_TransitionToFinal_AlreadyCompleted);
    }

    public bool TrySetResult(TResult result)
    {
      bool flag = this._task.TrySetResult(result);
      if (!flag)
        this._task.SpinUntilCompleted();
      return flag;
    }

    public void SetCanceled() => this.SetCanceled(new CancellationToken());

    public void SetCanceled(CancellationToken cancellationToken)
    {
      if (this.TrySetCanceled(cancellationToken))
        return;
      ThrowHelper.ThrowInvalidOperationException(ExceptionResource.TaskT_TransitionToFinal_AlreadyCompleted);
    }

    public bool TrySetCanceled() => this.TrySetCanceled(new CancellationToken());

    public bool TrySetCanceled(CancellationToken cancellationToken)
    {
      bool flag = this._task.TrySetCanceled(cancellationToken);
      if (!flag && !this._task.IsCompleted)
        this._task.SpinUntilCompleted();
      return flag;
    }
  }
}
