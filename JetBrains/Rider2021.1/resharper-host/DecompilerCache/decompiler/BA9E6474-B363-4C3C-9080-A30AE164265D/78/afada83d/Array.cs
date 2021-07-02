// Decompiled with JetBrains decompiler
// Type: System.Array
// Assembly: System.Private.CoreLib, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// MVID: BA9E6474-B363-4C3C-9080-A30AE164265D
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.6/System.Private.CoreLib.dll

using Internal.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


#nullable enable
namespace System
{
  [TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
  [Serializable]
  public abstract class Array : 
    ICloneable,
    IList,
    ICollection,
    IEnumerable,
    IStructuralComparable,
    IStructuralEquatable
  {
    public static unsafe Array CreateInstance(Type elementType, int length)
    {
      if ((object) elementType == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.elementType);
      if (length < 0)
        ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
      RuntimeType underlyingSystemType = elementType.UnderlyingSystemType as RuntimeType;
      if ((Type) underlyingSystemType == (Type) null)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_MustBeType, ExceptionArgument.elementType);
      return Array.InternalCreate((void*) underlyingSystemType.TypeHandle.Value, 1, &length, (int*) null);
    }

    public static unsafe Array CreateInstance(Type elementType, int length1, int length2)
    {
      if ((object) elementType == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.elementType);
      if (length1 < 0)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length1, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
      if (length2 < 0)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length2, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
      RuntimeType underlyingSystemType = elementType.UnderlyingSystemType as RuntimeType;
      if ((Type) underlyingSystemType == (Type) null)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_MustBeType, ExceptionArgument.elementType);
      int* pLengths = stackalloc int[2];
      pLengths[0] = length1;
      pLengths[1] = length2;
      return Array.InternalCreate((void*) underlyingSystemType.TypeHandle.Value, 2, pLengths, (int*) null);
    }

    public static unsafe Array CreateInstance(
      Type elementType,
      int length1,
      int length2,
      int length3)
    {
      if ((object) elementType == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.elementType);
      if (length1 < 0)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length1, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
      if (length2 < 0)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length2, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
      if (length3 < 0)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length3, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
      RuntimeType underlyingSystemType = elementType.UnderlyingSystemType as RuntimeType;
      if ((Type) underlyingSystemType == (Type) null)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_MustBeType, ExceptionArgument.elementType);
      int* pLengths = stackalloc int[3];
      pLengths[0] = length1;
      pLengths[1] = length2;
      pLengths[2] = length3;
      return Array.InternalCreate((void*) underlyingSystemType.TypeHandle.Value, 3, pLengths, (int*) null);
    }

    public static unsafe Array CreateInstance(Type elementType, params int[] lengths)
    {
      if ((object) elementType == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.elementType);
      if (lengths == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.lengths);
      if (lengths.Length == 0)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NeedAtLeast1Rank);
      RuntimeType underlyingSystemType = elementType.UnderlyingSystemType as RuntimeType;
      if ((Type) underlyingSystemType == (Type) null)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_MustBeType, ExceptionArgument.elementType);
      for (int paramNumber = 0; paramNumber < lengths.Length; ++paramNumber)
      {
        if (lengths[paramNumber] < 0)
          ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.lengths, paramNumber, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
      }
      fixed (int* pLengths = &lengths[0])
        return Array.InternalCreate((void*) underlyingSystemType.TypeHandle.Value, lengths.Length, pLengths, (int*) null);
    }

    public static unsafe Array CreateInstance(
      Type elementType,
      int[] lengths,
      int[] lowerBounds)
    {
      if (elementType == (Type) null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.elementType);
      if (lengths == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.lengths);
      if (lowerBounds == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.lowerBounds);
      if (lengths.Length != lowerBounds.Length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RanksAndBounds);
      if (lengths.Length == 0)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NeedAtLeast1Rank);
      RuntimeType underlyingSystemType = elementType.UnderlyingSystemType as RuntimeType;
      if ((Type) underlyingSystemType == (Type) null)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_MustBeType, ExceptionArgument.elementType);
      for (int paramNumber = 0; paramNumber < lengths.Length; ++paramNumber)
      {
        if (lengths[paramNumber] < 0)
          ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.lengths, paramNumber, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
      }
      fixed (int* pLengths = &lengths[0])
        fixed (int* pLowerBounds = &lowerBounds[0])
          return Array.InternalCreate((void*) underlyingSystemType.TypeHandle.Value, lengths.Length, pLengths, pLowerBounds);
    }


    #nullable disable
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern unsafe Array InternalCreate(
      void* elementType,
      int rank,
      int* pLengths,
      int* pLowerBounds);


    #nullable enable
    public static unsafe void Copy(Array sourceArray, Array destinationArray, int length)
    {
      if (sourceArray == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.sourceArray);
      if (destinationArray == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.destinationArray);
      MethodTable* methodTable = RuntimeHelpers.GetMethodTable((object) sourceArray);
      if (methodTable == RuntimeHelpers.GetMethodTable((object) destinationArray) && !methodTable->IsMultiDimensionalArray && ((UIntPtr) (uint) length <= (UIntPtr) (ulong) sourceArray.LongLength && (UIntPtr) (uint) length <= (UIntPtr) (ulong) destinationArray.LongLength))
      {
        UIntPtr num = (UIntPtr) (uint) length * (UIntPtr) methodTable->ComponentSize;
        ref byte local1 = ref Unsafe.As<RawArrayData>((object) sourceArray).Data;
        ref byte local2 = ref Unsafe.As<RawArrayData>((object) destinationArray).Data;
        if (methodTable->ContainsGCPointers)
          Buffer.BulkMoveWithWriteBarrier(ref local2, ref local1, num);
        else
          Buffer.Memmove<byte>(ref local2, ref local1, num);
      }
      else
        Array.Copy(sourceArray, sourceArray.GetLowerBound(0), destinationArray, destinationArray.GetLowerBound(0), length, false);
    }

    public static unsafe void Copy(
      Array sourceArray,
      int sourceIndex,
      Array destinationArray,
      int destinationIndex,
      int length)
    {
      if (sourceArray != null && destinationArray != null)
      {
        MethodTable* methodTable = RuntimeHelpers.GetMethodTable((object) sourceArray);
        if (methodTable == RuntimeHelpers.GetMethodTable((object) destinationArray) && !methodTable->IsMultiDimensionalArray && (length >= 0 && sourceIndex >= 0) && (destinationIndex >= 0 && (UIntPtr) (uint) (sourceIndex + length) <= (UIntPtr) (ulong) sourceArray.LongLength && (UIntPtr) (uint) (destinationIndex + length) <= (UIntPtr) (ulong) destinationArray.LongLength))
        {
          UIntPtr componentSize = (UIntPtr) methodTable->ComponentSize;
          UIntPtr num = (UIntPtr) (uint) length * componentSize;
          ref byte local1 = ref Unsafe.AddByteOffset<byte>(ref Unsafe.As<RawArrayData>((object) sourceArray).Data, (UIntPtr) (uint) sourceIndex * componentSize);
          ref byte local2 = ref Unsafe.AddByteOffset<byte>(ref Unsafe.As<RawArrayData>((object) destinationArray).Data, (UIntPtr) (uint) destinationIndex * componentSize);
          if (methodTable->ContainsGCPointers)
          {
            Buffer.BulkMoveWithWriteBarrier(ref local2, ref local1, num);
            return;
          }
          Buffer.Memmove<byte>(ref local2, ref local1, num);
          return;
        }
      }
      Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length, false);
    }


    #nullable disable
    private static unsafe void Copy(
      Array sourceArray,
      int sourceIndex,
      Array destinationArray,
      int destinationIndex,
      int length,
      bool reliable)
    {
      if (sourceArray == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.sourceArray);
      if (destinationArray == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.destinationArray);
      if (sourceArray.GetType() != destinationArray.GetType() && sourceArray.Rank != destinationArray.Rank)
        throw new RankException(SR.Rank_MustMatch);
      if (length < 0)
        throw new ArgumentOutOfRangeException(nameof (length), SR.ArgumentOutOfRange_NeedNonNegNum);
      int lowerBound1 = sourceArray.GetLowerBound(0);
      if (sourceIndex < lowerBound1 || sourceIndex - lowerBound1 < 0)
        throw new ArgumentOutOfRangeException(nameof (sourceIndex), SR.ArgumentOutOfRange_ArrayLB);
      sourceIndex -= lowerBound1;
      int lowerBound2 = destinationArray.GetLowerBound(0);
      if (destinationIndex < lowerBound2 || destinationIndex - lowerBound2 < 0)
        throw new ArgumentOutOfRangeException(nameof (destinationIndex), SR.ArgumentOutOfRange_ArrayLB);
      destinationIndex -= lowerBound2;
      if ((UIntPtr) (uint) (sourceIndex + length) > (UIntPtr) (ulong) sourceArray.LongLength)
        throw new ArgumentException(SR.Arg_LongerThanSrcArray, nameof (sourceArray));
      if ((UIntPtr) (uint) (destinationIndex + length) > (UIntPtr) (ulong) destinationArray.LongLength)
        throw new ArgumentException(SR.Arg_LongerThanDestArray, nameof (destinationArray));
      if (sourceArray.GetType() == destinationArray.GetType() || Array.IsSimpleCopy(sourceArray, destinationArray))
      {
        MethodTable* methodTable = RuntimeHelpers.GetMethodTable((object) sourceArray);
        UIntPtr componentSize = (UIntPtr) methodTable->ComponentSize;
        UIntPtr num = (UIntPtr) (uint) length * componentSize;
        ref byte local1 = ref Unsafe.AddByteOffset<byte>(ref sourceArray.GetRawArrayData(), (UIntPtr) (uint) sourceIndex * componentSize);
        ref byte local2 = ref Unsafe.AddByteOffset<byte>(ref destinationArray.GetRawArrayData(), (UIntPtr) (uint) destinationIndex * componentSize);
        if (methodTable->ContainsGCPointers)
          Buffer.BulkMoveWithWriteBarrier(ref local2, ref local1, num);
        else
          Buffer.Memmove<byte>(ref local2, ref local1, num);
      }
      else
      {
        if (reliable)
          throw new ArrayTypeMismatchException(SR.ArrayTypeMismatch_ConstrainedCopy);
        Array.CopySlow(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool IsSimpleCopy(Array sourceArray, Array destinationArray);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void CopySlow(
      Array sourceArray,
      int sourceIndex,
      Array destinationArray,
      int destinationIndex,
      int length);


    #nullable enable
    public static void ConstrainedCopy(
      Array sourceArray,
      int sourceIndex,
      Array destinationArray,
      int destinationIndex,
      int length)
    {
      Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length, true);
    }

    public static unsafe void Clear(Array array, int index, int length)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      ref byte local1 = ref Unsafe.As<RawArrayData>((object) array).Data;
      int num1 = 0;
      MethodTable* methodTable = RuntimeHelpers.GetMethodTable((object) array);
      if (methodTable->IsMultiDimensionalArray)
      {
        int dimensionalArrayRank = methodTable->MultiDimensionalArrayRank;
        num1 = Unsafe.Add<int>(ref Unsafe.As<byte, int>(ref local1), dimensionalArrayRank);
        local1 = ref Unsafe.Add<byte>(ref local1, 8 * dimensionalArrayRank);
      }
      int num2 = index - num1;
      if (index < num1 || num2 < 0 || (length < 0 || (UIntPtr) (uint) (num2 + length) > (UIntPtr) (ulong) array.LongLength))
        ThrowHelper.ThrowIndexOutOfRangeException();
      UIntPtr componentSize = (UIntPtr) methodTable->ComponentSize;
      ref byte local2 = ref Unsafe.AddByteOffset<byte>(ref local1, (UIntPtr) (uint) num2 * componentSize);
      UIntPtr byteLength = (UIntPtr) (uint) length * componentSize;
      if (methodTable->ContainsGCPointers)
        SpanHelpers.ClearWithReferences(ref Unsafe.As<byte, IntPtr>(ref local2), byteLength / (UIntPtr) (uint) sizeof (IntPtr));
      else
        SpanHelpers.ClearWithoutReferences(ref local2, byteLength);
    }

    public unsafe object? GetValue(params int[] indices)
    {
      if (indices == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.indices);
      if (this.Rank != indices.Length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankIndices);
      TypedReference typedReference = new TypedReference();
      fixed (int* pIndices = &indices[0])
        this.InternalGetReference((void*) &typedReference, indices.Length, pIndices);
      return TypedReference.InternalToObject((void*) &typedReference);
    }

    public unsafe object? GetValue(int index)
    {
      if (this.Rank != 1)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_Need1DArray);
      TypedReference typedReference = new TypedReference();
      this.InternalGetReference((void*) &typedReference, 1, &index);
      return TypedReference.InternalToObject((void*) &typedReference);
    }

    public unsafe object? GetValue(int index1, int index2)
    {
      if (this.Rank != 2)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_Need2DArray);
      int* pIndices = stackalloc int[2];
      pIndices[0] = index1;
      pIndices[1] = index2;
      TypedReference typedReference = new TypedReference();
      this.InternalGetReference((void*) &typedReference, 2, pIndices);
      return TypedReference.InternalToObject((void*) &typedReference);
    }

    public unsafe object? GetValue(int index1, int index2, int index3)
    {
      if (this.Rank != 3)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_Need3DArray);
      int* pIndices = stackalloc int[3];
      pIndices[0] = index1;
      pIndices[1] = index2;
      pIndices[2] = index3;
      TypedReference typedReference = new TypedReference();
      this.InternalGetReference((void*) &typedReference, 3, pIndices);
      return TypedReference.InternalToObject((void*) &typedReference);
    }

    public unsafe void SetValue(object? value, int index)
    {
      if (this.Rank != 1)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_Need1DArray);
      TypedReference typedReference = new TypedReference();
      this.InternalGetReference((void*) &typedReference, 1, &index);
      Array.InternalSetValue((void*) &typedReference, value);
    }

    public unsafe void SetValue(object? value, int index1, int index2)
    {
      if (this.Rank != 2)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_Need2DArray);
      int* pIndices = stackalloc int[2];
      pIndices[0] = index1;
      pIndices[1] = index2;
      TypedReference typedReference = new TypedReference();
      this.InternalGetReference((void*) &typedReference, 2, pIndices);
      Array.InternalSetValue((void*) &typedReference, value);
    }

    public unsafe void SetValue(object? value, int index1, int index2, int index3)
    {
      if (this.Rank != 3)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_Need3DArray);
      int* pIndices = stackalloc int[3];
      pIndices[0] = index1;
      pIndices[1] = index2;
      pIndices[2] = index3;
      TypedReference typedReference = new TypedReference();
      this.InternalGetReference((void*) &typedReference, 3, pIndices);
      Array.InternalSetValue((void*) &typedReference, value);
    }

    public unsafe void SetValue(object? value, params int[] indices)
    {
      if (indices == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.indices);
      if (this.Rank != indices.Length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankIndices);
      TypedReference typedReference = new TypedReference();
      fixed (int* pIndices = &indices[0])
        this.InternalGetReference((void*) &typedReference, indices.Length, pIndices);
      Array.InternalSetValue((void*) &typedReference, value);
    }


    #nullable disable
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern unsafe void InternalGetReference(void* elemRef, int rank, int* pIndices);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern unsafe void InternalSetValue(void* target, object value);

    public int Length => checked ((int) Unsafe.As<RawArrayData>((object) this).Length);

    public long LongLength => (long) Unsafe.As<RawArrayData>((object) this).Length;

    public int Rank
    {
      get
      {
        int dimensionalArrayRank = RuntimeHelpers.GetMultiDimensionalArrayRank(this);
        return dimensionalArrayRank == 0 ? 1 : dimensionalArrayRank;
      }
    }

    public int GetLength(int dimension)
    {
      int dimensionalArrayRank = RuntimeHelpers.GetMultiDimensionalArrayRank(this);
      if (dimensionalArrayRank == 0 && dimension == 0)
        return this.Length;
      if ((uint) dimension >= (uint) dimensionalArrayRank)
        throw new IndexOutOfRangeException(SR.IndexOutOfRange_ArrayRankIndex);
      return Unsafe.Add<int>(ref RuntimeHelpers.GetMultiDimensionalArrayBounds(this), dimension);
    }

    public int GetUpperBound(int dimension)
    {
      int dimensionalArrayRank = RuntimeHelpers.GetMultiDimensionalArrayRank(this);
      if (dimensionalArrayRank == 0 && dimension == 0)
        return this.Length - 1;
      if ((uint) dimension >= (uint) dimensionalArrayRank)
        throw new IndexOutOfRangeException(SR.IndexOutOfRange_ArrayRankIndex);
      ref int local = ref RuntimeHelpers.GetMultiDimensionalArrayBounds(this);
      return Unsafe.Add<int>(ref local, dimension) + Unsafe.Add<int>(ref local, dimensionalArrayRank + dimension) - 1;
    }

    public int GetLowerBound(int dimension)
    {
      int dimensionalArrayRank = RuntimeHelpers.GetMultiDimensionalArrayRank(this);
      if (dimensionalArrayRank == 0 && dimension == 0)
        return 0;
      if ((uint) dimension >= (uint) dimensionalArrayRank)
        throw new IndexOutOfRangeException(SR.IndexOutOfRange_ArrayRankIndex);
      return Unsafe.Add<int>(ref RuntimeHelpers.GetMultiDimensionalArrayBounds(this), dimensionalArrayRank + dimension);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern CorElementType GetCorElementTypeOfElementType();

    private unsafe bool IsValueOfElementType(object value) => (IntPtr) RuntimeHelpers.GetMethodTable((object) this)->ElementType == (IntPtr) (void*) RuntimeHelpers.GetMethodTable(value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Initialize();

    private protected Array()
    {
    }


    #nullable enable
    public static ReadOnlyCollection<T> AsReadOnly<T>(T[] array)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return new ReadOnlyCollection<T>((IList<T>) array);
    }

    public static void Resize<T>([NotNull] ref T[]? array, int newSize)
    {
      if (newSize < 0)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.newSize, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
      T[] array1 = array;
      if (array1 == null)
      {
        array = new T[newSize];
      }
      else
      {
        if (array1.Length == newSize)
          return;
        T[] array2 = new T[newSize];
        Buffer.Memmove<T>(ref MemoryMarshal.GetArrayDataReference<T>(array2), ref MemoryMarshal.GetArrayDataReference<T>(array1), (UIntPtr) (uint) Math.Min(newSize, array1.Length));
        array = array2;
      }
    }

    public static Array CreateInstance(Type elementType, params long[] lengths)
    {
      if (lengths == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.lengths);
      if (lengths.Length == 0)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_NeedAtLeast1Rank);
      int[] numArray = new int[lengths.Length];
      for (int index = 0; index < lengths.Length; ++index)
      {
        long length = lengths[index];
        int num = (int) length;
        if (length != (long) num)
          ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.len, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
        numArray[index] = num;
      }
      return Array.CreateInstance(elementType, numArray);
    }

    public static void Copy(Array sourceArray, Array destinationArray, long length)
    {
      int length1 = (int) length;
      if (length != (long) length1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      Array.Copy(sourceArray, destinationArray, length1);
    }

    public static void Copy(
      Array sourceArray,
      long sourceIndex,
      Array destinationArray,
      long destinationIndex,
      long length)
    {
      int sourceIndex1 = (int) sourceIndex;
      int destinationIndex1 = (int) destinationIndex;
      int length1 = (int) length;
      if (sourceIndex != (long) sourceIndex1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.sourceIndex, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      if (destinationIndex != (long) destinationIndex1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.destinationIndex, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      if (length != (long) length1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      Array.Copy(sourceArray, sourceIndex1, destinationArray, destinationIndex1, length1);
    }

    public object? GetValue(long index)
    {
      int index1 = (int) index;
      if (index != (long) index1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      return this.GetValue(index1);
    }

    public object? GetValue(long index1, long index2)
    {
      int index1_1 = (int) index1;
      int index2_1 = (int) index2;
      if (index1 != (long) index1_1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index1, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      if (index2 != (long) index2_1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index2, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      return this.GetValue(index1_1, index2_1);
    }

    public object? GetValue(long index1, long index2, long index3)
    {
      int index1_1 = (int) index1;
      int index2_1 = (int) index2;
      int index3_1 = (int) index3;
      if (index1 != (long) index1_1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index1, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      if (index2 != (long) index2_1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index2, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      if (index3 != (long) index3_1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index3, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      return this.GetValue(index1_1, index2_1, index3_1);
    }

    public object? GetValue(params long[] indices)
    {
      if (indices == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.indices);
      if (this.Rank != indices.Length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankIndices);
      int[] numArray = new int[indices.Length];
      for (int index1 = 0; index1 < indices.Length; ++index1)
      {
        long index2 = indices[index1];
        int num = (int) index2;
        if (index2 != (long) num)
          ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
        numArray[index1] = num;
      }
      return this.GetValue(numArray);
    }

    public void SetValue(object? value, long index)
    {
      int index1 = (int) index;
      if (index != (long) index1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      this.SetValue(value, index1);
    }

    public void SetValue(object? value, long index1, long index2)
    {
      int index1_1 = (int) index1;
      int index2_1 = (int) index2;
      if (index1 != (long) index1_1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index1, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      if (index2 != (long) index2_1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index2, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      this.SetValue(value, index1_1, index2_1);
    }

    public void SetValue(object? value, long index1, long index2, long index3)
    {
      int index1_1 = (int) index1;
      int index2_1 = (int) index2;
      int index3_1 = (int) index3;
      if (index1 != (long) index1_1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index1, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      if (index2 != (long) index2_1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index2, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      if (index3 != (long) index3_1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index3, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      this.SetValue(value, index1_1, index2_1, index3_1);
    }

    public void SetValue(object? value, params long[] indices)
    {
      if (indices == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.indices);
      if (this.Rank != indices.Length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankIndices);
      int[] numArray = new int[indices.Length];
      for (int index1 = 0; index1 < indices.Length; ++index1)
      {
        long index2 = indices[index1];
        int num = (int) index2;
        if (index2 != (long) num)
          ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
        numArray[index1] = num;
      }
      this.SetValue(value, numArray);
    }

    private static int GetMedian(int low, int hi) => low + (hi - low >> 1);

    public long GetLongLength(int dimension) => (long) this.GetLength(dimension);

    int ICollection.Count => this.Length;

    public object SyncRoot => (object) this;

    public bool IsReadOnly => false;

    public bool IsFixedSize => true;

    public bool IsSynchronized => false;

    object? IList.this[int index]
    {
      get => this.GetValue(index);
      set => this.SetValue(value, index);
    }


    #nullable disable
    int IList.Add(object value)
    {
      ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_FixedSizeCollection);
      return 0;
    }

    bool IList.Contains(object value) => Array.IndexOf(this, value) >= this.GetLowerBound(0);

    void IList.Clear() => Array.Clear(this, this.GetLowerBound(0), this.Length);

    int IList.IndexOf(object value) => Array.IndexOf(this, value);

    void IList.Insert(int index, object value) => ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_FixedSizeCollection);

    void IList.Remove(object value) => ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_FixedSizeCollection);

    void IList.RemoveAt(int index) => ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_FixedSizeCollection);


    #nullable enable
    public object Clone() => this.MemberwiseClone();


    #nullable disable
    int IStructuralComparable.CompareTo(object other, IComparer comparer)
    {
      if (other == null)
        return 1;
      if (!(other is Array array) || this.Length != array.Length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.ArgumentException_OtherNotArrayOfCorrectLength, ExceptionArgument.other);
      int index = 0;
      int num;
      for (num = 0; index < array.Length && num == 0; ++index)
      {
        object x = this.GetValue(index);
        object y = array.GetValue(index);
        num = comparer.Compare(x, y);
      }
      return num;
    }

    bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
    {
      if (other == null)
        return false;
      if (this == other)
        return true;
      if (!(other is Array array) || array.Length != this.Length)
        return false;
      for (int index = 0; index < array.Length; ++index)
      {
        object x = this.GetValue(index);
        object y = array.GetValue(index);
        if (!comparer.Equals(x, y))
          return false;
      }
      return true;
    }

    int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
      if (comparer == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.comparer);
      HashCode hashCode = new HashCode();
      for (int index = this.Length >= 8 ? this.Length - 8 : 0; index < this.Length; ++index)
        hashCode.Add<int>(comparer.GetHashCode(this.GetValue(index)));
      return hashCode.ToHashCode();
    }


    #nullable enable
    public static int BinarySearch(Array array, object? value)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.BinarySearch(array, array.GetLowerBound(0), array.Length, value, (IComparer) null);
    }

    public static int BinarySearch(Array array, int index, int length, object? value) => Array.BinarySearch(array, index, length, value, (IComparer) null);

    public static int BinarySearch(Array array, object? value, IComparer? comparer)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.BinarySearch(array, array.GetLowerBound(0), array.Length, value, comparer);
    }

    public static int BinarySearch(
      Array array,
      int index,
      int length,
      object? value,
      IComparer? comparer)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      int lowerBound = array.GetLowerBound(0);
      if (index < lowerBound)
        ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
      if (length < 0)
        ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
      if (array.Length - (index - lowerBound) < length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
      if (array.Rank != 1)
        ThrowHelper.ThrowRankException(ExceptionResource.Rank_MultiDimNotSupported);
      if (comparer == null)
        comparer = (IComparer) Comparer.Default;
      int low = index;
      int hi = index + length - 1;
      if (array is object[] objArray)
      {
        while (low <= hi)
        {
          int median = Array.GetMedian(low, hi);
          int num;
          try
          {
            num = comparer.Compare(objArray[median], value);
          }
          catch (Exception ex)
          {
            ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_IComparerFailed, ex);
            return 0;
          }
          if (num == 0)
            return median;
          if (num < 0)
            low = median + 1;
          else
            hi = median - 1;
        }
        return ~low;
      }
      if (comparer == Comparer.Default)
      {
        CorElementType typeOfElementType = array.GetCorElementTypeOfElementType();
        if (typeOfElementType.IsPrimitiveType())
        {
          if (value == null)
            return ~index;
          if (array.IsValueOfElementType(value))
          {
            int adjustedIndex = index - lowerBound;
            int num = -1;
            switch (typeOfElementType)
            {
              case CorElementType.ELEMENT_TYPE_BOOLEAN:
              case CorElementType.ELEMENT_TYPE_U1:
                num = GenericBinarySearch<byte>(array, adjustedIndex, length, value);
                break;
              case CorElementType.ELEMENT_TYPE_CHAR:
              case CorElementType.ELEMENT_TYPE_U2:
                num = GenericBinarySearch<ushort>(array, adjustedIndex, length, value);
                break;
              case CorElementType.ELEMENT_TYPE_I1:
                num = GenericBinarySearch<sbyte>(array, adjustedIndex, length, value);
                break;
              case CorElementType.ELEMENT_TYPE_I2:
                num = GenericBinarySearch<short>(array, adjustedIndex, length, value);
                break;
              case CorElementType.ELEMENT_TYPE_I4:
                num = GenericBinarySearch<int>(array, adjustedIndex, length, value);
                break;
              case CorElementType.ELEMENT_TYPE_U4:
                num = GenericBinarySearch<uint>(array, adjustedIndex, length, value);
                break;
              case CorElementType.ELEMENT_TYPE_I8:
              case CorElementType.ELEMENT_TYPE_I:
                num = GenericBinarySearch<long>(array, adjustedIndex, length, value);
                break;
              case CorElementType.ELEMENT_TYPE_U8:
              case CorElementType.ELEMENT_TYPE_U:
                num = GenericBinarySearch<ulong>(array, adjustedIndex, length, value);
                break;
              case CorElementType.ELEMENT_TYPE_R4:
                num = GenericBinarySearch<float>(array, adjustedIndex, length, value);
                break;
              case CorElementType.ELEMENT_TYPE_R8:
                num = GenericBinarySearch<double>(array, adjustedIndex, length, value);
                break;
            }
            return num < 0 ? ~(index + ~num) : index + num;
          }
        }
      }
      while (low <= hi)
      {
        int median = Array.GetMedian(low, hi);
        int num;
        try
        {
          num = comparer.Compare(array.GetValue(median), value);
        }
        catch (Exception ex)
        {
          ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_IComparerFailed, ex);
          return 0;
        }
        if (num == 0)
          return median;
        if (num < 0)
          low = median + 1;
        else
          hi = median - 1;
      }
      return ~low;


      #nullable disable
      static int GenericBinarySearch<T>(Array array, int adjustedIndex, int length, object value) where T : struct, IComparable<T> => Array.UnsafeArrayAsSpan<T>(array, adjustedIndex, length).BinarySearch<T, T>(Unsafe.As<byte, T>(ref value.GetRawData()));
    }


    #nullable enable
    public static int BinarySearch<T>(T[] array, T value)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.BinarySearch<T>(array, 0, array.Length, value, (IComparer<T>) null);
    }

    public static int BinarySearch<T>(T[] array, T value, IComparer<T>? comparer)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.BinarySearch<T>(array, 0, array.Length, value, comparer);
    }

    public static int BinarySearch<T>(T[] array, int index, int length, T value) => Array.BinarySearch<T>(array, index, length, value, (IComparer<T>) null);

    public static int BinarySearch<T>(
      T[] array,
      int index,
      int length,
      T value,
      IComparer<T>? comparer)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (index < 0)
        ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
      if (length < 0)
        ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
      if (array.Length - index < length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
      return ArraySortHelper<T>.Default.BinarySearch(array, index, length, value, comparer);
    }

    public static TOutput[] ConvertAll<TInput, TOutput>(
      TInput[] array,
      Converter<TInput, TOutput> converter)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (converter == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.converter);
      TOutput[] outputArray = new TOutput[array.Length];
      for (int index = 0; index < array.Length; ++index)
        outputArray[index] = converter(array[index]);
      return outputArray;
    }

    public void CopyTo(Array array, int index)
    {
      if (array != null && array.Rank != 1)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
      Array.Copy(this, this.GetLowerBound(0), array, index, this.Length);
    }

    public void CopyTo(Array array, long index)
    {
      int index1 = (int) index;
      if (index != (long) index1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);
      this.CopyTo(array, index1);
    }

    public static T[] Empty<T>() => Array.EmptyArray<T>.Value;

    public static bool Exists<T>(T[] array, Predicate<T> match) => Array.FindIndex<T>(array, match) != -1;

    public static void Fill<T>(T[] array, T value)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      for (int index = 0; index < array.Length; ++index)
        array[index] = value;
    }

    public static void Fill<T>(T[] array, T value, int startIndex, int count)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (startIndex < 0 || startIndex > array.Length)
        ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index();
      if (count < 0 || startIndex > array.Length - count)
        ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
      for (int index = startIndex; index < startIndex + count; ++index)
        array[index] = value;
    }

    public static T? Find<T>(T[] array, Predicate<T> match)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (match == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
      for (int index = 0; index < array.Length; ++index)
      {
        if (match(array[index]))
          return array[index];
      }
      return default (T);
    }

    public static T[] FindAll<T>(T[] array, Predicate<T> match)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (match == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
      List<T> objList = new List<T>();
      for (int index = 0; index < array.Length; ++index)
      {
        if (match(array[index]))
          objList.Add(array[index]);
      }
      return objList.ToArray();
    }

    public static int FindIndex<T>(T[] array, Predicate<T> match)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.FindIndex<T>(array, 0, array.Length, match);
    }

    public static int FindIndex<T>(T[] array, int startIndex, Predicate<T> match)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.FindIndex<T>(array, startIndex, array.Length - startIndex, match);
    }

    public static int FindIndex<T>(T[] array, int startIndex, int count, Predicate<T> match)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (startIndex < 0 || startIndex > array.Length)
        ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index();
      if (count < 0 || startIndex > array.Length - count)
        ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
      if (match == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
      int num = startIndex + count;
      for (int index = startIndex; index < num; ++index)
      {
        if (match(array[index]))
          return index;
      }
      return -1;
    }

    public static T? FindLast<T>(T[] array, Predicate<T> match)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (match == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
      for (int index = array.Length - 1; index >= 0; --index)
      {
        if (match(array[index]))
          return array[index];
      }
      return default (T);
    }

    public static int FindLastIndex<T>(T[] array, Predicate<T> match)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.FindLastIndex<T>(array, array.Length - 1, array.Length, match);
    }

    public static int FindLastIndex<T>(T[] array, int startIndex, Predicate<T> match)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.FindLastIndex<T>(array, startIndex, startIndex + 1, match);
    }

    public static int FindLastIndex<T>(T[] array, int startIndex, int count, Predicate<T> match)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (match == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
      if (array.Length == 0)
      {
        if (startIndex != -1)
          ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index();
      }
      else if (startIndex < 0 || startIndex >= array.Length)
        ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index();
      if (count < 0 || startIndex - count + 1 < 0)
        ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
      int num = startIndex - count;
      for (int index = startIndex; index > num; --index)
      {
        if (match(array[index]))
          return index;
      }
      return -1;
    }

    public static void ForEach<T>(T[] array, Action<T> action)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (action == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.action);
      for (int index = 0; index < array.Length; ++index)
        action(array[index]);
    }

    public static int IndexOf(Array array, object? value)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.IndexOf(array, value, array.GetLowerBound(0), array.Length);
    }

    public static int IndexOf(Array array, object? value, int startIndex)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      int lowerBound = array.GetLowerBound(0);
      return Array.IndexOf(array, value, startIndex, array.Length - startIndex + lowerBound);
    }

    public static int IndexOf(Array array, object? value, int startIndex, int count)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (array.Rank != 1)
        ThrowHelper.ThrowRankException(ExceptionResource.Rank_MultiDimNotSupported);
      int lowerBound = array.GetLowerBound(0);
      if (startIndex < lowerBound || startIndex > array.Length + lowerBound)
        ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index();
      if (count < 0 || count > array.Length - startIndex + lowerBound)
        ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
      int num1 = startIndex + count;
      if (array is object[] objArray)
      {
        if (value == null)
        {
          for (int index = startIndex; index < num1; ++index)
          {
            if (objArray[index] == null)
              return index;
          }
        }
        else
        {
          for (int index = startIndex; index < num1; ++index)
          {
            object obj = objArray[index];
            if (obj != null && obj.Equals(value))
              return index;
          }
        }
        return -1;
      }
      CorElementType typeOfElementType = array.GetCorElementTypeOfElementType();
      if (typeOfElementType.IsPrimitiveType())
      {
        if (value == null)
          return lowerBound - 1;
        if (array.IsValueOfElementType(value))
        {
          int adjustedIndex = startIndex - lowerBound;
          int num2 = -1;
          switch (typeOfElementType)
          {
            case CorElementType.ELEMENT_TYPE_BOOLEAN:
            case CorElementType.ELEMENT_TYPE_I1:
            case CorElementType.ELEMENT_TYPE_U1:
              num2 = GenericIndexOf<byte>(array, value, adjustedIndex, count);
              break;
            case CorElementType.ELEMENT_TYPE_CHAR:
            case CorElementType.ELEMENT_TYPE_I2:
            case CorElementType.ELEMENT_TYPE_U2:
              num2 = GenericIndexOf<char>(array, value, adjustedIndex, count);
              break;
            case CorElementType.ELEMENT_TYPE_I4:
            case CorElementType.ELEMENT_TYPE_U4:
              num2 = GenericIndexOf<int>(array, value, adjustedIndex, count);
              break;
            case CorElementType.ELEMENT_TYPE_I8:
            case CorElementType.ELEMENT_TYPE_U8:
            case CorElementType.ELEMENT_TYPE_I:
            case CorElementType.ELEMENT_TYPE_U:
              num2 = GenericIndexOf<long>(array, value, adjustedIndex, count);
              break;
            case CorElementType.ELEMENT_TYPE_R4:
              num2 = GenericIndexOf<float>(array, value, adjustedIndex, count);
              break;
            case CorElementType.ELEMENT_TYPE_R8:
              num2 = GenericIndexOf<double>(array, value, adjustedIndex, count);
              break;
          }
          return (num2 >= 0 ? startIndex : lowerBound) + num2;
        }
      }
      for (int index = startIndex; index < num1; ++index)
      {
        object obj = array.GetValue(index);
        if (obj == null)
        {
          if (value == null)
            return index;
        }
        else if (obj.Equals(value))
          return index;
      }
      return lowerBound - 1;


      #nullable disable
      static int GenericIndexOf<T>(Array array, object value, int adjustedIndex, int length) where T : struct, IEquatable<T> => Array.UnsafeArrayAsSpan<T>(array, adjustedIndex, length).IndexOf<T>(Unsafe.As<byte, T>(ref value.GetRawData()));
    }


    #nullable enable
    public static int IndexOf<T>(T[] array, T value)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.IndexOf<T>(array, value, 0, array.Length);
    }

    public static int IndexOf<T>(T[] array, T value, int startIndex)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.IndexOf<T>(array, value, startIndex, array.Length - startIndex);
    }

    public static int IndexOf<T>(T[] array, T value, int startIndex, int count)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if ((uint) startIndex > (uint) array.Length)
        ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index();
      if ((uint) count > (uint) (array.Length - startIndex))
        ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
      if (RuntimeHelpers.IsBitwiseEquatable<T>())
      {
        if (Unsafe.SizeOf<T>() == 1)
        {
          int num = SpanHelpers.IndexOf(ref Unsafe.Add<byte>(ref MemoryMarshal.GetArrayDataReference<byte>(Unsafe.As<byte[]>((object) array)), startIndex), Unsafe.As<T, byte>(ref value), count);
          return (num >= 0 ? startIndex : 0) + num;
        }
        if (Unsafe.SizeOf<T>() == 2)
        {
          int num = SpanHelpers.IndexOf(ref Unsafe.Add<char>(ref MemoryMarshal.GetArrayDataReference<char>(Unsafe.As<char[]>((object) array)), startIndex), Unsafe.As<T, char>(ref value), count);
          return (num >= 0 ? startIndex : 0) + num;
        }
        if (Unsafe.SizeOf<T>() == 4)
        {
          int num = SpanHelpers.IndexOf<int>(ref Unsafe.Add<int>(ref MemoryMarshal.GetArrayDataReference<int>(Unsafe.As<int[]>((object) array)), startIndex), Unsafe.As<T, int>(ref value), count);
          return (num >= 0 ? startIndex : 0) + num;
        }
        if (Unsafe.SizeOf<T>() == 8)
        {
          int num = SpanHelpers.IndexOf<long>(ref Unsafe.Add<long>(ref MemoryMarshal.GetArrayDataReference<long>(Unsafe.As<long[]>((object) array)), startIndex), Unsafe.As<T, long>(ref value), count);
          return (num >= 0 ? startIndex : 0) + num;
        }
      }
      return EqualityComparer<T>.Default.IndexOf(array, value, startIndex, count);
    }

    public static int LastIndexOf(Array array, object? value)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      int lowerBound = array.GetLowerBound(0);
      return Array.LastIndexOf(array, value, array.Length - 1 + lowerBound, array.Length);
    }

    public static int LastIndexOf(Array array, object? value, int startIndex)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      int lowerBound = array.GetLowerBound(0);
      return Array.LastIndexOf(array, value, startIndex, startIndex + 1 - lowerBound);
    }

    public static int LastIndexOf(Array array, object? value, int startIndex, int count)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      int lowerBound = array.GetLowerBound(0);
      if (array.Length == 0)
        return lowerBound - 1;
      if (startIndex < lowerBound || startIndex >= array.Length + lowerBound)
        ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index();
      if (count < 0)
        ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
      if (count > startIndex - lowerBound + 1)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.endIndex, ExceptionResource.ArgumentOutOfRange_EndIndexStartIndex);
      if (array.Rank != 1)
        ThrowHelper.ThrowRankException(ExceptionResource.Rank_MultiDimNotSupported);
      int num1 = startIndex - count + 1;
      if (array is object[] objArray)
      {
        if (value == null)
        {
          for (int index = startIndex; index >= num1; --index)
          {
            if (objArray[index] == null)
              return index;
          }
        }
        else
        {
          for (int index = startIndex; index >= num1; --index)
          {
            object obj = objArray[index];
            if (obj != null && obj.Equals(value))
              return index;
          }
        }
        return -1;
      }
      CorElementType typeOfElementType = array.GetCorElementTypeOfElementType();
      if (typeOfElementType.IsPrimitiveType())
      {
        if (value == null)
          return lowerBound - 1;
        if (array.IsValueOfElementType(value))
        {
          int adjustedIndex = num1 - lowerBound;
          int num2 = -1;
          switch (typeOfElementType)
          {
            case CorElementType.ELEMENT_TYPE_BOOLEAN:
            case CorElementType.ELEMENT_TYPE_I1:
            case CorElementType.ELEMENT_TYPE_U1:
              num2 = GenericLastIndexOf<byte>(array, value, adjustedIndex, count);
              break;
            case CorElementType.ELEMENT_TYPE_CHAR:
            case CorElementType.ELEMENT_TYPE_I2:
            case CorElementType.ELEMENT_TYPE_U2:
              num2 = GenericLastIndexOf<char>(array, value, adjustedIndex, count);
              break;
            case CorElementType.ELEMENT_TYPE_I4:
            case CorElementType.ELEMENT_TYPE_U4:
              num2 = GenericLastIndexOf<int>(array, value, adjustedIndex, count);
              break;
            case CorElementType.ELEMENT_TYPE_I8:
            case CorElementType.ELEMENT_TYPE_U8:
            case CorElementType.ELEMENT_TYPE_I:
            case CorElementType.ELEMENT_TYPE_U:
              num2 = GenericLastIndexOf<long>(array, value, adjustedIndex, count);
              break;
            case CorElementType.ELEMENT_TYPE_R4:
              num2 = GenericLastIndexOf<float>(array, value, adjustedIndex, count);
              break;
            case CorElementType.ELEMENT_TYPE_R8:
              num2 = GenericLastIndexOf<double>(array, value, adjustedIndex, count);
              break;
          }
          return (num2 >= 0 ? num1 : lowerBound) + num2;
        }
      }
      for (int index = startIndex; index >= num1; --index)
      {
        object obj = array.GetValue(index);
        if (obj == null)
        {
          if (value == null)
            return index;
        }
        else if (obj.Equals(value))
          return index;
      }
      return lowerBound - 1;


      #nullable disable
      static int GenericLastIndexOf<T>(Array array, object value, int adjustedIndex, int length) where T : struct, IEquatable<T> => Array.UnsafeArrayAsSpan<T>(array, adjustedIndex, length).LastIndexOf<T>(Unsafe.As<byte, T>(ref value.GetRawData()));
    }


    #nullable enable
    public static int LastIndexOf<T>(T[] array, T value)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.LastIndexOf<T>(array, value, array.Length - 1, array.Length);
    }

    public static int LastIndexOf<T>(T[] array, T value, int startIndex)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      return Array.LastIndexOf<T>(array, value, startIndex, array.Length == 0 ? 0 : startIndex + 1);
    }

    public static int LastIndexOf<T>(T[] array, T value, int startIndex, int count)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (array.Length == 0)
      {
        if (startIndex != -1 && startIndex != 0)
          ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index();
        if (count != 0)
          ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
        return -1;
      }
      if ((uint) startIndex >= (uint) array.Length)
        ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index();
      if (count < 0 || startIndex - count + 1 < 0)
        ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
      if (RuntimeHelpers.IsBitwiseEquatable<T>())
      {
        if (Unsafe.SizeOf<T>() == 1)
        {
          int elementOffset = startIndex - count + 1;
          int num = SpanHelpers.LastIndexOf(ref Unsafe.Add<byte>(ref MemoryMarshal.GetArrayDataReference<byte>(Unsafe.As<byte[]>((object) array)), elementOffset), Unsafe.As<T, byte>(ref value), count);
          return (num >= 0 ? elementOffset : 0) + num;
        }
        if (Unsafe.SizeOf<T>() == 2)
        {
          int elementOffset = startIndex - count + 1;
          int num = SpanHelpers.LastIndexOf(ref Unsafe.Add<char>(ref MemoryMarshal.GetArrayDataReference<char>(Unsafe.As<char[]>((object) array)), elementOffset), Unsafe.As<T, char>(ref value), count);
          return (num >= 0 ? elementOffset : 0) + num;
        }
        if (Unsafe.SizeOf<T>() == 4)
        {
          int elementOffset = startIndex - count + 1;
          int num = SpanHelpers.LastIndexOf<int>(ref Unsafe.Add<int>(ref MemoryMarshal.GetArrayDataReference<int>(Unsafe.As<int[]>((object) array)), elementOffset), Unsafe.As<T, int>(ref value), count);
          return (num >= 0 ? elementOffset : 0) + num;
        }
        if (Unsafe.SizeOf<T>() == 8)
        {
          int elementOffset = startIndex - count + 1;
          int num = SpanHelpers.LastIndexOf<long>(ref Unsafe.Add<long>(ref MemoryMarshal.GetArrayDataReference<long>(Unsafe.As<long[]>((object) array)), elementOffset), Unsafe.As<T, long>(ref value), count);
          return (num >= 0 ? elementOffset : 0) + num;
        }
      }
      return EqualityComparer<T>.Default.LastIndexOf(array, value, startIndex, count);
    }

    public static void Reverse(Array array)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      Array.Reverse(array, array.GetLowerBound(0), array.Length);
    }

    public static void Reverse(Array array, int index, int length)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      int lowerBound = array.GetLowerBound(0);
      if (index < lowerBound)
        ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
      if (length < 0)
        ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
      if (array.Length - (index - lowerBound) < length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
      if (array.Rank != 1)
        ThrowHelper.ThrowRankException(ExceptionResource.Rank_MultiDimNotSupported);
      if (length <= 1)
        return;
      int adjustedIndex = index - lowerBound;
      switch (array.GetCorElementTypeOfElementType())
      {
        case CorElementType.ELEMENT_TYPE_BOOLEAN:
        case CorElementType.ELEMENT_TYPE_I1:
        case CorElementType.ELEMENT_TYPE_U1:
          Array.UnsafeArrayAsSpan<byte>(array, adjustedIndex, length).Reverse<byte>();
          break;
        case CorElementType.ELEMENT_TYPE_CHAR:
        case CorElementType.ELEMENT_TYPE_I2:
        case CorElementType.ELEMENT_TYPE_U2:
          Array.UnsafeArrayAsSpan<short>(array, adjustedIndex, length).Reverse<short>();
          break;
        case CorElementType.ELEMENT_TYPE_I4:
        case CorElementType.ELEMENT_TYPE_U4:
        case CorElementType.ELEMENT_TYPE_R4:
          Array.UnsafeArrayAsSpan<int>(array, adjustedIndex, length).Reverse<int>();
          break;
        case CorElementType.ELEMENT_TYPE_I8:
        case CorElementType.ELEMENT_TYPE_U8:
        case CorElementType.ELEMENT_TYPE_R8:
        case CorElementType.ELEMENT_TYPE_I:
        case CorElementType.ELEMENT_TYPE_U:
          Array.UnsafeArrayAsSpan<long>(array, adjustedIndex, length).Reverse<long>();
          break;
        case CorElementType.ELEMENT_TYPE_ARRAY:
        case CorElementType.ELEMENT_TYPE_OBJECT:
        case CorElementType.ELEMENT_TYPE_SZARRAY:
          Array.UnsafeArrayAsSpan<object>(array, adjustedIndex, length).Reverse<object>();
          break;
        default:
          int index1 = index;
          for (int index2 = index + length - 1; index1 < index2; --index2)
          {
            object obj = array.GetValue(index1);
            array.SetValue(array.GetValue(index2), index1);
            array.SetValue(obj, index2);
            ++index1;
          }
          break;
      }
    }

    public static void Reverse<T>(T[] array)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      Array.Reverse<T>(array, 0, array.Length);
    }

    public static void Reverse<T>(T[] array, int index, int length)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (index < 0)
        ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
      if (length < 0)
        ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
      if (array.Length - index < length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
      if (length <= 1)
        return;
      ref T local1 = ref Unsafe.Add<T>(ref MemoryMarshal.GetArrayDataReference<T>(array), index);
      ref T local2 = ref Unsafe.Add<T>(ref Unsafe.Add<T>(ref local1, length), -1);
      do
      {
        T obj = local1;
        local1 = local2;
        local2 = obj;
        local1 = ref Unsafe.Add<T>(ref local1, 1);
        local2 = ref Unsafe.Add<T>(ref local2, -1);
      }
      while (Unsafe.IsAddressLessThan<T>(ref local1, ref local2));
    }

    public static void Sort(Array array)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      Array.Sort(array, (Array) null, array.GetLowerBound(0), array.Length, (IComparer) null);
    }

    public static void Sort(Array keys, Array? items)
    {
      if (keys == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keys);
      Array.Sort(keys, items, keys.GetLowerBound(0), keys.Length, (IComparer) null);
    }

    public static void Sort(Array array, int index, int length) => Array.Sort(array, (Array) null, index, length, (IComparer) null);

    public static void Sort(Array keys, Array? items, int index, int length) => Array.Sort(keys, items, index, length, (IComparer) null);

    public static void Sort(Array array, IComparer? comparer)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      Array.Sort(array, (Array) null, array.GetLowerBound(0), array.Length, comparer);
    }

    public static void Sort(Array keys, Array? items, IComparer? comparer)
    {
      if (keys == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keys);
      Array.Sort(keys, items, keys.GetLowerBound(0), keys.Length, comparer);
    }

    public static void Sort(Array array, int index, int length, IComparer? comparer) => Array.Sort(array, (Array) null, index, length, comparer);

    public static void Sort(Array keys, Array? items, int index, int length, IComparer? comparer)
    {
      if (keys == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keys);
      if (keys.Rank != 1 || items != null && items.Rank != 1)
        ThrowHelper.ThrowRankException(ExceptionResource.Rank_MultiDimNotSupported);
      int lowerBound = keys.GetLowerBound(0);
      if (items != null && lowerBound != items.GetLowerBound(0))
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_LowerBoundsMustMatch);
      if (index < lowerBound)
        ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
      if (length < 0)
        ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
      if (keys.Length - (index - lowerBound) < length || items != null && index - lowerBound > items.Length - length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
      if (length <= 1)
        return;
      if (comparer == null)
        comparer = (IComparer) Comparer.Default;
      if (keys is object[] keys1)
      {
        object[] items1 = items as object[];
        if (items == null || items1 != null)
        {
          new Array.SorterObjectArray(keys1, items1, comparer).Sort(index, length);
          return;
        }
      }
      if (comparer == Comparer.Default)
      {
        CorElementType typeOfElementType = keys.GetCorElementTypeOfElementType();
        if (items == null || items.GetCorElementTypeOfElementType() == typeOfElementType)
        {
          int adjustedIndex = index - lowerBound;
          switch (typeOfElementType)
          {
            case CorElementType.ELEMENT_TYPE_BOOLEAN:
            case CorElementType.ELEMENT_TYPE_U1:
              GenericSort<byte>(keys, items, adjustedIndex, length);
              return;
            case CorElementType.ELEMENT_TYPE_CHAR:
            case CorElementType.ELEMENT_TYPE_U2:
              GenericSort<ushort>(keys, items, adjustedIndex, length);
              return;
            case CorElementType.ELEMENT_TYPE_I1:
              GenericSort<sbyte>(keys, items, adjustedIndex, length);
              return;
            case CorElementType.ELEMENT_TYPE_I2:
              GenericSort<short>(keys, items, adjustedIndex, length);
              return;
            case CorElementType.ELEMENT_TYPE_I4:
              GenericSort<int>(keys, items, adjustedIndex, length);
              return;
            case CorElementType.ELEMENT_TYPE_U4:
              GenericSort<uint>(keys, items, adjustedIndex, length);
              return;
            case CorElementType.ELEMENT_TYPE_I8:
            case CorElementType.ELEMENT_TYPE_I:
              GenericSort<long>(keys, items, adjustedIndex, length);
              return;
            case CorElementType.ELEMENT_TYPE_U8:
            case CorElementType.ELEMENT_TYPE_U:
              GenericSort<ulong>(keys, items, adjustedIndex, length);
              return;
            case CorElementType.ELEMENT_TYPE_R4:
              GenericSort<float>(keys, items, adjustedIndex, length);
              return;
            case CorElementType.ELEMENT_TYPE_R8:
              GenericSort<double>(keys, items, adjustedIndex, length);
              return;
          }
        }
      }
      new Array.SorterGenericArray(keys, items, comparer).Sort(index, length);


      #nullable disable
      static void GenericSort<T>(Array keys, Array items, int adjustedIndex, int length) where T : struct
      {
        Span<T> span = Array.UnsafeArrayAsSpan<T>(keys, adjustedIndex, length);
        if (items != null)
          span.Sort<T, T>(Array.UnsafeArrayAsSpan<T>(items, adjustedIndex, length));
        else
          span.Sort<T>();
      }
    }


    #nullable enable
    public static void Sort<T>(T[] array)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (array.Length <= 1)
        return;
      ArraySortHelper<T>.Default.Sort(new Span<T>(ref MemoryMarshal.GetArrayDataReference<T>(array), array.Length), (IComparer<T>) null);
    }

    public static void Sort<TKey, TValue>(TKey[] keys, TValue[]? items)
    {
      if (keys == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keys);
      Array.Sort<TKey, TValue>(keys, items, 0, keys.Length, (IComparer<TKey>) null);
    }

    public static void Sort<T>(T[] array, int index, int length) => Array.Sort<T>(array, index, length, (IComparer<T>) null);

    public static void Sort<TKey, TValue>(TKey[] keys, TValue[]? items, int index, int length) => Array.Sort<TKey, TValue>(keys, items, index, length, (IComparer<TKey>) null);

    public static void Sort<T>(T[] array, IComparer<T>? comparer)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      Array.Sort<T>(array, 0, array.Length, comparer);
    }

    public static void Sort<TKey, TValue>(TKey[] keys, TValue[]? items, IComparer<TKey>? comparer)
    {
      if (keys == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keys);
      Array.Sort<TKey, TValue>(keys, items, 0, keys.Length, comparer);
    }

    public static void Sort<T>(T[] array, int index, int length, IComparer<T>? comparer)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (index < 0)
        ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
      if (length < 0)
        ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
      if (array.Length - index < length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
      if (length <= 1)
        return;
      ArraySortHelper<T>.Default.Sort(new Span<T>(ref Unsafe.Add<T>(ref MemoryMarshal.GetArrayDataReference<T>(array), index), length), comparer);
    }

    public static void Sort<TKey, TValue>(
      TKey[] keys,
      TValue[]? items,
      int index,
      int length,
      IComparer<TKey>? comparer)
    {
      if (keys == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keys);
      if (index < 0)
        ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
      if (length < 0)
        ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
      if (keys.Length - index < length || items != null && index > items.Length - length)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
      if (length <= 1)
        return;
      if (items == null)
        Array.Sort<TKey>(keys, index, length, comparer);
      else
        ArraySortHelper<TKey, TValue>.Default.Sort(new Span<TKey>(ref Unsafe.Add<TKey>(ref MemoryMarshal.GetArrayDataReference<TKey>(keys), index), length), new Span<TValue>(ref Unsafe.Add<TValue>(ref MemoryMarshal.GetArrayDataReference<TValue>(items), index), length), comparer);
    }

    public static void Sort<T>(T[] array, Comparison<T> comparison)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (comparison == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.comparison);
      ArraySortHelper<T>.Sort(new Span<T>(ref MemoryMarshal.GetArrayDataReference<T>(array), array.Length), comparison);
    }

    public static bool TrueForAll<T>(T[] array, Predicate<T> match)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (match == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
      for (int index = 0; index < array.Length; ++index)
      {
        if (!match(array[index]))
          return false;
      }
      return true;
    }


    #nullable disable
    private static Span<T> UnsafeArrayAsSpan<T>(Array array, int adjustedIndex, int length) => new Span<T>(ref Unsafe.As<byte, T>(ref array.GetRawArrayData()), array.Length).Slice(adjustedIndex, length);


    #nullable enable
    public IEnumerator GetEnumerator()
    {
      int lowerBound = this.GetLowerBound(0);
      return this.Rank == 1 && lowerBound == 0 ? (IEnumerator) new SZArrayEnumerator(this) : (IEnumerator) new ArrayEnumerator(this, lowerBound, this.Length);
    }


    #nullable disable
    private static class EmptyArray<T>
    {
      internal static readonly T[] Value = new T[0];
    }

    private readonly struct SorterObjectArray
    {
      private readonly object[] keys;
      private readonly object[] items;
      private readonly IComparer comparer;

      internal SorterObjectArray(object[] keys, object[] items, IComparer comparer)
      {
        this.keys = keys;
        this.items = items;
        this.comparer = comparer;
      }

      internal void SwapIfGreater(int a, int b)
      {
        if (a == b || this.comparer.Compare(this.keys[a], this.keys[b]) <= 0)
          return;
        object key = this.keys[a];
        this.keys[a] = this.keys[b];
        this.keys[b] = key;
        if (this.items == null)
          return;
        object obj = this.items[a];
        this.items[a] = this.items[b];
        this.items[b] = obj;
      }

      private void Swap(int i, int j)
      {
        object key = this.keys[i];
        this.keys[i] = this.keys[j];
        this.keys[j] = key;
        if (this.items == null)
          return;
        object obj = this.items[i];
        this.items[i] = this.items[j];
        this.items[j] = obj;
      }

      internal void Sort(int left, int length) => this.IntrospectiveSort(left, length);

      private void IntrospectiveSort(int left, int length)
      {
        if (length < 2)
          return;
        try
        {
          this.IntroSort(left, length + left - 1, 2 * (BitOperations.Log2((uint) length) + 1));
        }
        catch (IndexOutOfRangeException ex)
        {
          ThrowHelper.ThrowArgumentException_BadComparer((object) this.comparer);
        }
        catch (Exception ex)
        {
          ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_IComparerFailed, ex);
        }
      }

      private void IntroSort(int lo, int hi, int depthLimit)
      {
        int num1;
        for (; hi > lo; hi = num1 - 1)
        {
          int num2 = hi - lo + 1;
          if (num2 <= 16)
          {
            if (num2 == 2)
            {
              this.SwapIfGreater(lo, hi);
              break;
            }
            if (num2 == 3)
            {
              this.SwapIfGreater(lo, hi - 1);
              this.SwapIfGreater(lo, hi);
              this.SwapIfGreater(hi - 1, hi);
              break;
            }
            this.InsertionSort(lo, hi);
            break;
          }
          if (depthLimit == 0)
          {
            this.Heapsort(lo, hi);
            break;
          }
          --depthLimit;
          num1 = this.PickPivotAndPartition(lo, hi);
          this.IntroSort(num1 + 1, hi, depthLimit);
        }
      }

      private int PickPivotAndPartition(int lo, int hi)
      {
        int index = lo + (hi - lo) / 2;
        this.SwapIfGreater(lo, index);
        this.SwapIfGreater(lo, hi);
        this.SwapIfGreater(index, hi);
        object key = this.keys[index];
        this.Swap(index, hi - 1);
        int i = lo;
        int j = hi - 1;
        while (i < j)
        {
          do
            ;
          while (this.comparer.Compare(this.keys[++i], key) < 0);
          do
            ;
          while (this.comparer.Compare(key, this.keys[--j]) < 0);
          if (i < j)
            this.Swap(i, j);
          else
            break;
        }
        if (i != hi - 1)
          this.Swap(i, hi - 1);
        return i;
      }

      private void Heapsort(int lo, int hi)
      {
        int n = hi - lo + 1;
        for (int i = n / 2; i >= 1; --i)
          this.DownHeap(i, n, lo);
        for (int index = n; index > 1; --index)
        {
          this.Swap(lo, lo + index - 1);
          this.DownHeap(1, index - 1, lo);
        }
      }

      private void DownHeap(int i, int n, int lo)
      {
        object key = this.keys[lo + i - 1];
        object obj = this.items?[lo + i - 1];
        int num;
        for (; i <= n / 2; i = num)
        {
          num = 2 * i;
          if (num < n && this.comparer.Compare(this.keys[lo + num - 1], this.keys[lo + num]) < 0)
            ++num;
          if (this.comparer.Compare(key, this.keys[lo + num - 1]) < 0)
          {
            this.keys[lo + i - 1] = this.keys[lo + num - 1];
            if (this.items != null)
              this.items[lo + i - 1] = this.items[lo + num - 1];
          }
          else
            break;
        }
        this.keys[lo + i - 1] = key;
        if (this.items == null)
          return;
        this.items[lo + i - 1] = obj;
      }

      private void InsertionSort(int lo, int hi)
      {
        for (int index1 = lo; index1 < hi; ++index1)
        {
          int index2 = index1;
          object key = this.keys[index1 + 1];
          object obj = this.items?[index1 + 1];
          for (; index2 >= lo && this.comparer.Compare(key, this.keys[index2]) < 0; --index2)
          {
            this.keys[index2 + 1] = this.keys[index2];
            if (this.items != null)
              this.items[index2 + 1] = this.items[index2];
          }
          this.keys[index2 + 1] = key;
          if (this.items != null)
            this.items[index2 + 1] = obj;
        }
      }
    }

    private readonly struct SorterGenericArray
    {
      private readonly Array keys;
      private readonly Array items;
      private readonly IComparer comparer;

      internal SorterGenericArray(Array keys, Array items, IComparer comparer)
      {
        this.keys = keys;
        this.items = items;
        this.comparer = comparer;
      }

      internal void SwapIfGreater(int a, int b)
      {
        if (a == b || this.comparer.Compare(this.keys.GetValue(a), this.keys.GetValue(b)) <= 0)
          return;
        object obj1 = this.keys.GetValue(a);
        this.keys.SetValue(this.keys.GetValue(b), a);
        this.keys.SetValue(obj1, b);
        if (this.items == null)
          return;
        object obj2 = this.items.GetValue(a);
        this.items.SetValue(this.items.GetValue(b), a);
        this.items.SetValue(obj2, b);
      }

      private void Swap(int i, int j)
      {
        object obj1 = this.keys.GetValue(i);
        this.keys.SetValue(this.keys.GetValue(j), i);
        this.keys.SetValue(obj1, j);
        if (this.items == null)
          return;
        object obj2 = this.items.GetValue(i);
        this.items.SetValue(this.items.GetValue(j), i);
        this.items.SetValue(obj2, j);
      }

      internal void Sort(int left, int length) => this.IntrospectiveSort(left, length);

      private void IntrospectiveSort(int left, int length)
      {
        if (length < 2)
          return;
        try
        {
          this.IntroSort(left, length + left - 1, 2 * (BitOperations.Log2((uint) length) + 1));
        }
        catch (IndexOutOfRangeException ex)
        {
          ThrowHelper.ThrowArgumentException_BadComparer((object) this.comparer);
        }
        catch (Exception ex)
        {
          ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_IComparerFailed, ex);
        }
      }

      private void IntroSort(int lo, int hi, int depthLimit)
      {
        int num1;
        for (; hi > lo; hi = num1 - 1)
        {
          int num2 = hi - lo + 1;
          if (num2 <= 16)
          {
            if (num2 == 2)
            {
              this.SwapIfGreater(lo, hi);
              break;
            }
            if (num2 == 3)
            {
              this.SwapIfGreater(lo, hi - 1);
              this.SwapIfGreater(lo, hi);
              this.SwapIfGreater(hi - 1, hi);
              break;
            }
            this.InsertionSort(lo, hi);
            break;
          }
          if (depthLimit == 0)
          {
            this.Heapsort(lo, hi);
            break;
          }
          --depthLimit;
          num1 = this.PickPivotAndPartition(lo, hi);
          this.IntroSort(num1 + 1, hi, depthLimit);
        }
      }

      private int PickPivotAndPartition(int lo, int hi)
      {
        int num = lo + (hi - lo) / 2;
        this.SwapIfGreater(lo, num);
        this.SwapIfGreater(lo, hi);
        this.SwapIfGreater(num, hi);
        object obj = this.keys.GetValue(num);
        this.Swap(num, hi - 1);
        int i = lo;
        int j = hi - 1;
        while (i < j)
        {
          do
            ;
          while (this.comparer.Compare(this.keys.GetValue(++i), obj) < 0);
          do
            ;
          while (this.comparer.Compare(obj, this.keys.GetValue(--j)) < 0);
          if (i < j)
            this.Swap(i, j);
          else
            break;
        }
        if (i != hi - 1)
          this.Swap(i, hi - 1);
        return i;
      }

      private void Heapsort(int lo, int hi)
      {
        int n = hi - lo + 1;
        for (int i = n / 2; i >= 1; --i)
          this.DownHeap(i, n, lo);
        for (int index = n; index > 1; --index)
        {
          this.Swap(lo, lo + index - 1);
          this.DownHeap(1, index - 1, lo);
        }
      }

      private void DownHeap(int i, int n, int lo)
      {
        object x = this.keys.GetValue(lo + i - 1);
        object obj = this.items?.GetValue(lo + i - 1);
        int num;
        for (; i <= n / 2; i = num)
        {
          num = 2 * i;
          if (num < n && this.comparer.Compare(this.keys.GetValue(lo + num - 1), this.keys.GetValue(lo + num)) < 0)
            ++num;
          if (this.comparer.Compare(x, this.keys.GetValue(lo + num - 1)) < 0)
          {
            this.keys.SetValue(this.keys.GetValue(lo + num - 1), lo + i - 1);
            if (this.items != null)
              this.items.SetValue(this.items.GetValue(lo + num - 1), lo + i - 1);
          }
          else
            break;
        }
        this.keys.SetValue(x, lo + i - 1);
        if (this.items == null)
          return;
        this.items.SetValue(obj, lo + i - 1);
      }

      private void InsertionSort(int lo, int hi)
      {
        for (int index1 = lo; index1 < hi; ++index1)
        {
          int index2 = index1;
          object x = this.keys.GetValue(index1 + 1);
          object obj = this.items?.GetValue(index1 + 1);
          for (; index2 >= lo && this.comparer.Compare(x, this.keys.GetValue(index2)) < 0; --index2)
          {
            this.keys.SetValue(this.keys.GetValue(index2), index2 + 1);
            if (this.items != null)
              this.items.SetValue(this.items.GetValue(index2), index2 + 1);
          }
          this.keys.SetValue(x, index2 + 1);
          if (this.items != null)
            this.items.SetValue(obj, index2 + 1);
        }
      }
    }
  }
}
