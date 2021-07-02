// Decompiled with JetBrains decompiler
// Type: System.ThrowHelper
// Assembly: System.Private.CoreLib, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// MVID: 2D484BAC-CE45-466C-A280-6ADFAD00567C
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.5/System.Private.CoreLib.dll

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System
{
  [StackTraceHidden]
  internal static class ThrowHelper
  {
    [DoesNotReturn]
    internal static void ThrowArrayTypeMismatchException() => throw new ArrayTypeMismatchException();

    [DoesNotReturn]
    internal static void ThrowInvalidTypeWithPointersNotSupported(Type targetType) => throw new ArgumentException(SR.Format(SR.Argument_InvalidTypeWithPointersNotSupported, (object) targetType));

    [DoesNotReturn]
    internal static void ThrowIndexOutOfRangeException() => throw new IndexOutOfRangeException();

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRangeException() => throw new ArgumentOutOfRangeException();

    [DoesNotReturn]
    internal static void ThrowArgumentException_DestinationTooShort() => throw new ArgumentException(SR.Argument_DestinationTooShort, "destination");

    [DoesNotReturn]
    internal static void ThrowArgumentException_OverlapAlignmentMismatch() => throw new ArgumentException(SR.Argument_OverlapAlignmentMismatch);

    [DoesNotReturn]
    internal static void ThrowArgumentException_CannotExtractScalar(ExceptionArgument argument) => throw ThrowHelper.GetArgumentException(ExceptionResource.Argument_CannotExtractScalar, argument);

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRange_IndexException() => throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);

    [DoesNotReturn]
    internal static void ThrowArgumentException_BadComparer(object comparer) => throw new ArgumentException(SR.Format(SR.Arg_BogusIComparer, comparer));

    [DoesNotReturn]
    internal static void ThrowIndexArgumentOutOfRange_NeedNonNegNumException() => throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);

    [DoesNotReturn]
    internal static void ThrowValueArgumentOutOfRange_NeedNonNegNumException() => throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.value, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);

    [DoesNotReturn]
    internal static void ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum() => throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.length, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);

    [DoesNotReturn]
    internal static void ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index() => throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_Index);

    [DoesNotReturn]
    internal static void ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count() => throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRange_Year() => throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.year, ExceptionResource.ArgumentOutOfRange_Year);

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRange_BadYearMonthDay() => throw new ArgumentOutOfRangeException((string) null, SR.ArgumentOutOfRange_BadYearMonthDay);

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRange_BadHourMinuteSecond() => throw new ArgumentOutOfRangeException((string) null, SR.ArgumentOutOfRange_BadHourMinuteSecond);

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRange_TimeSpanTooLong() => throw new ArgumentOutOfRangeException((string) null, SR.Overflow_TimeSpanTooLong);

    [DoesNotReturn]
    internal static void ThrowWrongKeyTypeArgumentException<T>(T key, Type targetType) => throw ThrowHelper.GetWrongKeyTypeArgumentException((object) key, targetType);

    [DoesNotReturn]
    internal static void ThrowWrongValueTypeArgumentException<T>(T value, Type targetType) => throw ThrowHelper.GetWrongValueTypeArgumentException((object) value, targetType);

    private static ArgumentException GetAddingDuplicateWithKeyArgumentException(
      object key)
    {
      return new ArgumentException(SR.Format(SR.Argument_AddingDuplicateWithKey, key));
    }

    [DoesNotReturn]
    internal static void ThrowAddingDuplicateWithKeyArgumentException<T>(T key) => throw ThrowHelper.GetAddingDuplicateWithKeyArgumentException((object) key);

    [DoesNotReturn]
    internal static void ThrowKeyNotFoundException<T>(T key) => throw ThrowHelper.GetKeyNotFoundException((object) key);

    [DoesNotReturn]
    internal static void ThrowArgumentException(ExceptionResource resource) => throw ThrowHelper.GetArgumentException(resource);

    [DoesNotReturn]
    internal static void ThrowArgumentException(
      ExceptionResource resource,
      ExceptionArgument argument)
    {
      throw ThrowHelper.GetArgumentException(resource, argument);
    }

    private static ArgumentNullException GetArgumentNullException(
      ExceptionArgument argument)
    {
      return new ArgumentNullException(ThrowHelper.GetArgumentName(argument));
    }

    [DoesNotReturn]
    internal static void ThrowArgumentNullException(ExceptionArgument argument) => throw ThrowHelper.GetArgumentNullException(argument);

    [DoesNotReturn]
    internal static void ThrowArgumentNullException(
      ExceptionArgument argument,
      ExceptionResource resource)
    {
      throw new ArgumentNullException(ThrowHelper.GetArgumentName(argument), ThrowHelper.GetResourceString(resource));
    }

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument) => throw new ArgumentOutOfRangeException(ThrowHelper.GetArgumentName(argument));

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRangeException(
      ExceptionArgument argument,
      ExceptionResource resource)
    {
      throw ThrowHelper.GetArgumentOutOfRangeException(argument, resource);
    }

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRangeException(
      ExceptionArgument argument,
      int paramNumber,
      ExceptionResource resource)
    {
      throw ThrowHelper.GetArgumentOutOfRangeException(argument, paramNumber, resource);
    }

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException() => throw new InvalidOperationException();

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException(ExceptionResource resource) => throw ThrowHelper.GetInvalidOperationException(resource);

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException(ExceptionResource resource, Exception e) => throw new InvalidOperationException(ThrowHelper.GetResourceString(resource), e);

    [DoesNotReturn]
    internal static void ThrowSerializationException(ExceptionResource resource) => throw new SerializationException(ThrowHelper.GetResourceString(resource));

    [DoesNotReturn]
    internal static void ThrowRankException(ExceptionResource resource) => throw new RankException(ThrowHelper.GetResourceString(resource));

    [DoesNotReturn]
    internal static void ThrowNotSupportedException(ExceptionResource resource) => throw new NotSupportedException(ThrowHelper.GetResourceString(resource));

    [DoesNotReturn]
    internal static void ThrowObjectDisposedException(ExceptionResource resource) => throw new ObjectDisposedException((string) null, ThrowHelper.GetResourceString(resource));

    [DoesNotReturn]
    internal static void ThrowNotSupportedException() => throw new NotSupportedException();

    [DoesNotReturn]
    internal static void ThrowAggregateException(List<Exception> exceptions) => throw new AggregateException((IEnumerable<Exception>) exceptions);

    [DoesNotReturn]
    internal static void ThrowArgumentException_Argument_InvalidArrayType() => throw new ArgumentException(SR.Argument_InvalidArrayType);

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_InvalidOperation_EnumNotStarted() => throw new InvalidOperationException(SR.InvalidOperation_EnumNotStarted);

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_InvalidOperation_EnumEnded() => throw new InvalidOperationException(SR.InvalidOperation_EnumEnded);

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_EnumCurrent(int index) => throw ThrowHelper.GetInvalidOperationException_EnumCurrent(index);

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion() => throw new InvalidOperationException(SR.InvalidOperation_EnumFailedVersion);

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen() => throw new InvalidOperationException(SR.InvalidOperation_EnumOpCantHappen);

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_InvalidOperation_NoValue() => throw new InvalidOperationException(SR.InvalidOperation_NoValue);

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_ConcurrentOperationsNotSupported() => throw new InvalidOperationException(SR.InvalidOperation_ConcurrentOperationsNotSupported);

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_HandleIsNotInitialized() => throw new InvalidOperationException(SR.InvalidOperation_HandleIsNotInitialized);

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_HandleIsNotPinned() => throw new InvalidOperationException(SR.InvalidOperation_HandleIsNotPinned);

    [DoesNotReturn]
    internal static void ThrowArraySegmentCtorValidationFailedExceptions(
      Array array,
      int offset,
      int count)
    {
      throw ThrowHelper.GetArraySegmentCtorValidationFailedException(array, offset, count);
    }

    [DoesNotReturn]
    internal static void ThrowFormatException_BadFormatSpecifier() => throw new FormatException(SR.Argument_BadFormatSpecifier);

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRangeException_PrecisionTooLarge() => throw new ArgumentOutOfRangeException("precision", SR.Format(SR.Argument_PrecisionTooLarge, (object) (byte) 99));

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRangeException_SymbolDoesNotFit() => throw new ArgumentOutOfRangeException("symbol", SR.Argument_BadFormatSpecifier);

    private static Exception GetArraySegmentCtorValidationFailedException(
      Array array,
      int offset,
      int count)
    {
      if (array == null)
        return (Exception) new ArgumentNullException(nameof (array));
      if (offset < 0)
        return (Exception) new ArgumentOutOfRangeException(nameof (offset), SR.ArgumentOutOfRange_NeedNonNegNum);
      return count < 0 ? (Exception) new ArgumentOutOfRangeException(nameof (count), SR.ArgumentOutOfRange_NeedNonNegNum) : (Exception) new ArgumentException(SR.Argument_InvalidOffLen);
    }

    private static ArgumentException GetArgumentException(
      ExceptionResource resource)
    {
      return new ArgumentException(ThrowHelper.GetResourceString(resource));
    }

    private static InvalidOperationException GetInvalidOperationException(
      ExceptionResource resource)
    {
      return new InvalidOperationException(ThrowHelper.GetResourceString(resource));
    }

    private static ArgumentException GetWrongKeyTypeArgumentException(
      object key,
      Type targetType)
    {
      return new ArgumentException(SR.Format(SR.Arg_WrongType, key, (object) targetType), nameof (key));
    }

    private static ArgumentException GetWrongValueTypeArgumentException(
      object value,
      Type targetType)
    {
      return new ArgumentException(SR.Format(SR.Arg_WrongType, value, (object) targetType), nameof (value));
    }

    private static KeyNotFoundException GetKeyNotFoundException(object key) => new KeyNotFoundException(SR.Format(SR.Arg_KeyNotFoundWithKey, key));

    private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(
      ExceptionArgument argument,
      ExceptionResource resource)
    {
      return new ArgumentOutOfRangeException(ThrowHelper.GetArgumentName(argument), ThrowHelper.GetResourceString(resource));
    }

    private static ArgumentException GetArgumentException(
      ExceptionResource resource,
      ExceptionArgument argument)
    {
      return new ArgumentException(ThrowHelper.GetResourceString(resource), ThrowHelper.GetArgumentName(argument));
    }

    private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(
      ExceptionArgument argument,
      int paramNumber,
      ExceptionResource resource)
    {
      return new ArgumentOutOfRangeException(ThrowHelper.GetArgumentName(argument) + "[" + paramNumber.ToString() + "]", ThrowHelper.GetResourceString(resource));
    }

    private static InvalidOperationException GetInvalidOperationException_EnumCurrent(
      int index)
    {
      return new InvalidOperationException(index < 0 ? SR.InvalidOperation_EnumNotStarted : SR.InvalidOperation_EnumEnded);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void IfNullAndNullsAreIllegalThenThrow<T>(
      object value,
      ExceptionArgument argName)
    {
      if ((object) default (T) == null || value != null)
        return;
      ThrowHelper.ThrowArgumentNullException(argName);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowForUnsupportedVectorBaseType<T>() where T : struct
    {
      if (!(typeof (T) != typeof (byte)) || !(typeof (T) != typeof (sbyte)) || (!(typeof (T) != typeof (short)) || !(typeof (T) != typeof (ushort))) || (!(typeof (T) != typeof (int)) || !(typeof (T) != typeof (uint)) || (!(typeof (T) != typeof (long)) || !(typeof (T) != typeof (ulong)))) || (!(typeof (T) != typeof (float)) || !(typeof (T) != typeof (double))))
        return;
      ThrowHelper.ThrowNotSupportedException(ExceptionResource.Arg_TypeNotSupported);
    }

    private static string GetArgumentName(ExceptionArgument argument)
    {
      switch (argument)
      {
        case ExceptionArgument.obj:
          return "obj";
        case ExceptionArgument.dictionary:
          return "dictionary";
        case ExceptionArgument.array:
          return "array";
        case ExceptionArgument.info:
          return "info";
        case ExceptionArgument.key:
          return "key";
        case ExceptionArgument.text:
          return "text";
        case ExceptionArgument.values:
          return "values";
        case ExceptionArgument.value:
          return "value";
        case ExceptionArgument.startIndex:
          return "startIndex";
        case ExceptionArgument.task:
          return "task";
        case ExceptionArgument.bytes:
          return "bytes";
        case ExceptionArgument.byteIndex:
          return "byteIndex";
        case ExceptionArgument.byteCount:
          return "byteCount";
        case ExceptionArgument.ch:
          return "ch";
        case ExceptionArgument.chars:
          return "chars";
        case ExceptionArgument.charIndex:
          return "charIndex";
        case ExceptionArgument.charCount:
          return "charCount";
        case ExceptionArgument.s:
          return "s";
        case ExceptionArgument.input:
          return "input";
        case ExceptionArgument.ownedMemory:
          return "ownedMemory";
        case ExceptionArgument.list:
          return "list";
        case ExceptionArgument.index:
          return "index";
        case ExceptionArgument.capacity:
          return "capacity";
        case ExceptionArgument.collection:
          return "collection";
        case ExceptionArgument.item:
          return "item";
        case ExceptionArgument.converter:
          return "converter";
        case ExceptionArgument.match:
          return "match";
        case ExceptionArgument.count:
          return "count";
        case ExceptionArgument.action:
          return "action";
        case ExceptionArgument.comparison:
          return "comparison";
        case ExceptionArgument.exceptions:
          return "exceptions";
        case ExceptionArgument.exception:
          return "exception";
        case ExceptionArgument.pointer:
          return "pointer";
        case ExceptionArgument.start:
          return "start";
        case ExceptionArgument.format:
          return "format";
        case ExceptionArgument.culture:
          return "culture";
        case ExceptionArgument.comparer:
          return "comparer";
        case ExceptionArgument.comparable:
          return "comparable";
        case ExceptionArgument.source:
          return "source";
        case ExceptionArgument.state:
          return "state";
        case ExceptionArgument.length:
          return "length";
        case ExceptionArgument.comparisonType:
          return "comparisonType";
        case ExceptionArgument.manager:
          return "manager";
        case ExceptionArgument.sourceBytesToCopy:
          return "sourceBytesToCopy";
        case ExceptionArgument.callBack:
          return "callBack";
        case ExceptionArgument.creationOptions:
          return "creationOptions";
        case ExceptionArgument.function:
          return "function";
        case ExceptionArgument.scheduler:
          return "scheduler";
        case ExceptionArgument.continuationAction:
          return "continuationAction";
        case ExceptionArgument.continuationFunction:
          return "continuationFunction";
        case ExceptionArgument.tasks:
          return "tasks";
        case ExceptionArgument.asyncResult:
          return "asyncResult";
        case ExceptionArgument.beginMethod:
          return "beginMethod";
        case ExceptionArgument.endMethod:
          return "endMethod";
        case ExceptionArgument.endFunction:
          return "endFunction";
        case ExceptionArgument.cancellationToken:
          return "cancellationToken";
        case ExceptionArgument.continuationOptions:
          return "continuationOptions";
        case ExceptionArgument.delay:
          return "delay";
        case ExceptionArgument.millisecondsDelay:
          return "millisecondsDelay";
        case ExceptionArgument.millisecondsTimeout:
          return "millisecondsTimeout";
        case ExceptionArgument.stateMachine:
          return "stateMachine";
        case ExceptionArgument.timeout:
          return "timeout";
        case ExceptionArgument.type:
          return "type";
        case ExceptionArgument.sourceIndex:
          return "sourceIndex";
        case ExceptionArgument.sourceArray:
          return "sourceArray";
        case ExceptionArgument.destinationIndex:
          return "destinationIndex";
        case ExceptionArgument.destinationArray:
          return "destinationArray";
        case ExceptionArgument.pHandle:
          return "pHandle";
        case ExceptionArgument.other:
          return "other";
        case ExceptionArgument.newSize:
          return "newSize";
        case ExceptionArgument.lowerBounds:
          return "lowerBounds";
        case ExceptionArgument.lengths:
          return "lengths";
        case ExceptionArgument.len:
          return "len";
        case ExceptionArgument.keys:
          return "keys";
        case ExceptionArgument.indices:
          return "indices";
        case ExceptionArgument.index1:
          return "index1";
        case ExceptionArgument.index2:
          return "index2";
        case ExceptionArgument.index3:
          return "index3";
        case ExceptionArgument.length1:
          return "length1";
        case ExceptionArgument.length2:
          return "length2";
        case ExceptionArgument.length3:
          return "length3";
        case ExceptionArgument.endIndex:
          return "endIndex";
        case ExceptionArgument.elementType:
          return "elementType";
        case ExceptionArgument.arrayIndex:
          return "arrayIndex";
        case ExceptionArgument.year:
          return "year";
        case ExceptionArgument.codePoint:
          return "codePoint";
        case ExceptionArgument.str:
          return "str";
        case ExceptionArgument.options:
          return "options";
        case ExceptionArgument.prefix:
          return "prefix";
        case ExceptionArgument.suffix:
          return "suffix";
        default:
          return "";
      }
    }

    private static string GetResourceString(ExceptionResource resource)
    {
      switch (resource)
      {
        case ExceptionResource.ArgumentOutOfRange_Index:
          return SR.ArgumentOutOfRange_Index;
        case ExceptionResource.ArgumentOutOfRange_IndexCount:
          return SR.ArgumentOutOfRange_IndexCount;
        case ExceptionResource.ArgumentOutOfRange_IndexCountBuffer:
          return SR.ArgumentOutOfRange_IndexCountBuffer;
        case ExceptionResource.ArgumentOutOfRange_Count:
          return SR.ArgumentOutOfRange_Count;
        case ExceptionResource.ArgumentOutOfRange_Year:
          return SR.ArgumentOutOfRange_Year;
        case ExceptionResource.Arg_ArrayPlusOffTooSmall:
          return SR.Arg_ArrayPlusOffTooSmall;
        case ExceptionResource.NotSupported_ReadOnlyCollection:
          return SR.NotSupported_ReadOnlyCollection;
        case ExceptionResource.Arg_RankMultiDimNotSupported:
          return SR.Arg_RankMultiDimNotSupported;
        case ExceptionResource.Arg_NonZeroLowerBound:
          return SR.Arg_NonZeroLowerBound;
        case ExceptionResource.ArgumentOutOfRange_GetCharCountOverflow:
          return SR.ArgumentOutOfRange_GetCharCountOverflow;
        case ExceptionResource.ArgumentOutOfRange_ListInsert:
          return SR.ArgumentOutOfRange_ListInsert;
        case ExceptionResource.ArgumentOutOfRange_NeedNonNegNum:
          return SR.ArgumentOutOfRange_NeedNonNegNum;
        case ExceptionResource.ArgumentOutOfRange_SmallCapacity:
          return SR.ArgumentOutOfRange_SmallCapacity;
        case ExceptionResource.Argument_InvalidOffLen:
          return SR.Argument_InvalidOffLen;
        case ExceptionResource.Argument_CannotExtractScalar:
          return SR.Argument_CannotExtractScalar;
        case ExceptionResource.ArgumentOutOfRange_BiggerThanCollection:
          return SR.ArgumentOutOfRange_BiggerThanCollection;
        case ExceptionResource.Serialization_MissingKeys:
          return SR.Serialization_MissingKeys;
        case ExceptionResource.Serialization_NullKey:
          return SR.Serialization_NullKey;
        case ExceptionResource.NotSupported_KeyCollectionSet:
          return SR.NotSupported_KeyCollectionSet;
        case ExceptionResource.NotSupported_ValueCollectionSet:
          return SR.NotSupported_ValueCollectionSet;
        case ExceptionResource.InvalidOperation_NullArray:
          return SR.InvalidOperation_NullArray;
        case ExceptionResource.TaskT_TransitionToFinal_AlreadyCompleted:
          return SR.TaskT_TransitionToFinal_AlreadyCompleted;
        case ExceptionResource.TaskCompletionSourceT_TrySetException_NullException:
          return SR.TaskCompletionSourceT_TrySetException_NullException;
        case ExceptionResource.TaskCompletionSourceT_TrySetException_NoExceptions:
          return SR.TaskCompletionSourceT_TrySetException_NoExceptions;
        case ExceptionResource.NotSupported_StringComparison:
          return SR.NotSupported_StringComparison;
        case ExceptionResource.ConcurrentCollection_SyncRoot_NotSupported:
          return SR.ConcurrentCollection_SyncRoot_NotSupported;
        case ExceptionResource.Task_MultiTaskContinuation_NullTask:
          return SR.Task_MultiTaskContinuation_NullTask;
        case ExceptionResource.InvalidOperation_WrongAsyncResultOrEndCalledMultiple:
          return SR.InvalidOperation_WrongAsyncResultOrEndCalledMultiple;
        case ExceptionResource.Task_MultiTaskContinuation_EmptyTaskList:
          return SR.Task_MultiTaskContinuation_EmptyTaskList;
        case ExceptionResource.Task_Start_TaskCompleted:
          return SR.Task_Start_TaskCompleted;
        case ExceptionResource.Task_Start_Promise:
          return SR.Task_Start_Promise;
        case ExceptionResource.Task_Start_ContinuationTask:
          return SR.Task_Start_ContinuationTask;
        case ExceptionResource.Task_Start_AlreadyStarted:
          return SR.Task_Start_AlreadyStarted;
        case ExceptionResource.Task_RunSynchronously_Continuation:
          return SR.Task_RunSynchronously_Continuation;
        case ExceptionResource.Task_RunSynchronously_Promise:
          return SR.Task_RunSynchronously_Promise;
        case ExceptionResource.Task_RunSynchronously_TaskCompleted:
          return SR.Task_RunSynchronously_TaskCompleted;
        case ExceptionResource.Task_RunSynchronously_AlreadyStarted:
          return SR.Task_RunSynchronously_AlreadyStarted;
        case ExceptionResource.AsyncMethodBuilder_InstanceNotInitialized:
          return SR.AsyncMethodBuilder_InstanceNotInitialized;
        case ExceptionResource.Task_ContinueWith_ESandLR:
          return SR.Task_ContinueWith_ESandLR;
        case ExceptionResource.Task_ContinueWith_NotOnAnything:
          return SR.Task_ContinueWith_NotOnAnything;
        case ExceptionResource.Task_Delay_InvalidDelay:
          return SR.Task_Delay_InvalidDelay;
        case ExceptionResource.Task_Delay_InvalidMillisecondsDelay:
          return SR.Task_Delay_InvalidMillisecondsDelay;
        case ExceptionResource.Task_Dispose_NotCompleted:
          return SR.Task_Dispose_NotCompleted;
        case ExceptionResource.Task_ThrowIfDisposed:
          return SR.Task_ThrowIfDisposed;
        case ExceptionResource.Task_WaitMulti_NullTask:
          return SR.Task_WaitMulti_NullTask;
        case ExceptionResource.ArgumentException_OtherNotArrayOfCorrectLength:
          return SR.ArgumentException_OtherNotArrayOfCorrectLength;
        case ExceptionResource.ArgumentNull_Array:
          return SR.ArgumentNull_Array;
        case ExceptionResource.ArgumentNull_SafeHandle:
          return SR.ArgumentNull_SafeHandle;
        case ExceptionResource.ArgumentOutOfRange_EndIndexStartIndex:
          return SR.ArgumentOutOfRange_EndIndexStartIndex;
        case ExceptionResource.ArgumentOutOfRange_Enum:
          return SR.ArgumentOutOfRange_Enum;
        case ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported:
          return SR.ArgumentOutOfRange_HugeArrayNotSupported;
        case ExceptionResource.Argument_AddingDuplicate:
          return SR.Argument_AddingDuplicate;
        case ExceptionResource.Argument_InvalidArgumentForComparison:
          return SR.Argument_InvalidArgumentForComparison;
        case ExceptionResource.Arg_LowerBoundsMustMatch:
          return SR.Arg_LowerBoundsMustMatch;
        case ExceptionResource.Arg_MustBeType:
          return SR.Arg_MustBeType;
        case ExceptionResource.Arg_Need1DArray:
          return SR.Arg_Need1DArray;
        case ExceptionResource.Arg_Need2DArray:
          return SR.Arg_Need2DArray;
        case ExceptionResource.Arg_Need3DArray:
          return SR.Arg_Need3DArray;
        case ExceptionResource.Arg_NeedAtLeast1Rank:
          return SR.Arg_NeedAtLeast1Rank;
        case ExceptionResource.Arg_RankIndices:
          return SR.Arg_RankIndices;
        case ExceptionResource.Arg_RanksAndBounds:
          return SR.Arg_RanksAndBounds;
        case ExceptionResource.InvalidOperation_IComparerFailed:
          return SR.InvalidOperation_IComparerFailed;
        case ExceptionResource.NotSupported_FixedSizeCollection:
          return SR.NotSupported_FixedSizeCollection;
        case ExceptionResource.Rank_MultiDimNotSupported:
          return SR.Rank_MultiDimNotSupported;
        case ExceptionResource.Arg_TypeNotSupported:
          return SR.Arg_TypeNotSupported;
        case ExceptionResource.Argument_SpansMustHaveSameLength:
          return SR.Argument_SpansMustHaveSameLength;
        case ExceptionResource.Argument_InvalidFlag:
          return SR.Argument_InvalidFlag;
        default:
          return "";
      }
    }
  }
}
