// Decompiled with JetBrains decompiler
// Type: System.Math
// Assembly: System.Private.CoreLib, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// MVID: 576BEC19-D8AC-4AB7-9D98-CD1623F32A17
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.7/System.Private.CoreLib.dll

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Versioning;

namespace System
{
  public static class Math
  {
    public const double E = 2.718281828459045;
    public const double PI = 3.141592653589793;
    public const double Tau = 6.283185307179586;
    private static readonly double[] roundPower10Double = new double[16]
    {
      1.0,
      10.0,
      100.0,
      1000.0,
      10000.0,
      100000.0,
      1000000.0,
      10000000.0,
      100000000.0,
      1000000000.0,
      10000000000.0,
      100000000000.0,
      1000000000000.0,
      10000000000000.0,
      100000000000000.0,
      1000000000000000.0
    };

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Abs(double value);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern float Abs(float value);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Acos(double d);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Acosh(double d);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Asin(double d);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Asinh(double d);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Atan(double d);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Atan2(double y, double x);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Atanh(double d);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Cbrt(double d);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Ceiling(double a);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Cos(double d);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Cosh(double value);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Exp(double d);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Floor(double d);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double FusedMultiplyAdd(double x, double y, double z);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int ILogB(double x);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Log(double d);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Log2(double x);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Log10(double d);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Pow(double x, double y);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double ScaleB(double x, int n);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Sin(double a);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Sinh(double value);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Sqrt(double d);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Tan(double a);

    [Intrinsic]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern double Tanh(double value);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern unsafe double ModF(double x, double* intptr);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short Abs(short value)
    {
      if (value < (short) 0)
      {
        value = -value;
        if (value < (short) 0)
          Math.ThrowAbsOverflow();
      }
      return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Abs(int value)
    {
      if (value < 0)
      {
        value = -value;
        if (value < 0)
          Math.ThrowAbsOverflow();
      }
      return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long Abs(long value)
    {
      if (value < 0L)
      {
        value = -value;
        if (value < 0L)
          Math.ThrowAbsOverflow();
      }
      return value;
    }

    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte Abs(sbyte value)
    {
      if (value < (sbyte) 0)
      {
        value = -value;
        if (value < (sbyte) 0)
          Math.ThrowAbsOverflow();
      }
      return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Decimal Abs(Decimal value) => Decimal.Abs(in value);

    [DoesNotReturn]
    [StackTraceHidden]
    private static void ThrowAbsOverflow() => throw new OverflowException(SR.Overflow_NegateTwosCompNum);

    public static long BigMul(int a, int b) => (long) a * (long) b;

    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ulong BigMul(ulong a, ulong b, out ulong low)
    {
      if (!Bmi2.X64.IsSupported)
        return SoftwareFallback(a, b, out low);
      ulong num1;
      ulong num2 = Bmi2.X64.MultiplyNoFlags(a, b, &num1);
      low = num1;
      return num2;

      static ulong SoftwareFallback(ulong a, ulong b, out ulong low)
      {
        uint num1 = (uint) a;
        uint num2 = (uint) (a >> 32);
        uint num3 = (uint) b;
        uint num4 = (uint) (b >> 32);
        ulong num5 = (ulong) num1 * (ulong) num3;
        ulong num6 = (ulong) num2 * (ulong) num3 + (num5 >> 32);
        ulong num7 = (ulong) num1 * (ulong) num4 + (ulong) (uint) num6;
        low = num7 << 32 | (ulong) (uint) num5;
        return (ulong) num2 * (ulong) num4 + (num6 >> 32) + (num7 >> 32);
      }
    }

    public static long BigMul(long a, long b, out long low)
    {
      ulong low1;
      ulong num = Math.BigMul((ulong) a, (ulong) b, out low1);
      low = (long) low1;
      return (long) num - (a >> 63 & b) - (b >> 63 & a);
    }

    public static double BitDecrement(double x)
    {
      long int64Bits = BitConverter.DoubleToInt64Bits(x);
      return (int64Bits >> 32 & 2146435072L) >= 2146435072L ? (int64Bits != 9218868437227405312L ? x : double.MaxValue) : (int64Bits == 0L ? -5E-324 : BitConverter.Int64BitsToDouble(int64Bits + (int64Bits < 0L ? 1L : -1L)));
    }

    public static double BitIncrement(double x)
    {
      long int64Bits = BitConverter.DoubleToInt64Bits(x);
      return (int64Bits >> 32 & 2146435072L) >= 2146435072L ? (int64Bits != -4503599627370496L ? x : double.MinValue) : (int64Bits == long.MinValue ? double.Epsilon : BitConverter.Int64BitsToDouble(int64Bits + (int64Bits < 0L ? -1L : 1L)));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double CopySign(double x, double y)
    {
      return Sse2.IsSupported || AdvSimd.IsSupported ? VectorMath.ConditionalSelectBitwise(Vector128.CreateScalarUnsafe(-0.0), Vector128.CreateScalarUnsafe(y), Vector128.CreateScalarUnsafe(x)).ToScalar<double>() : SoftwareFallback(x, y);

      static double SoftwareFallback(double x, double y) => BitConverter.Int64BitsToDouble(BitConverter.DoubleToInt64Bits(x) & long.MaxValue | BitConverter.DoubleToInt64Bits(y) & long.MinValue);
    }

    public static int DivRem(int a, int b, out int result)
    {
      int num = a / b;
      result = a - num * b;
      return num;
    }

    public static long DivRem(long a, long b, out long result)
    {
      long num = a / b;
      result = a - num * b;
      return num;
    }

    internal static uint DivRem(uint a, uint b, out uint result)
    {
      uint num = a / b;
      result = a - num * b;
      return num;
    }

    internal static ulong DivRem(ulong a, ulong b, out ulong result)
    {
      ulong num = a / b;
      result = a - num * b;
      return num;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Decimal Ceiling(Decimal d) => Decimal.Ceiling(d);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte Clamp(byte value, byte min, byte max)
    {
      if ((int) min > (int) max)
        Math.ThrowMinMaxException<byte>(min, max);
      if ((int) value < (int) min)
        return min;
      return (int) value > (int) max ? max : value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Decimal Clamp(Decimal value, Decimal min, Decimal max)
    {
      if (min > max)
        Math.ThrowMinMaxException<Decimal>(min, max);
      if (value < min)
        return min;
      return value > max ? max : value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Clamp(double value, double min, double max)
    {
      if (min > max)
        Math.ThrowMinMaxException<double>(min, max);
      if (value < min)
        return min;
      return value > max ? max : value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short Clamp(short value, short min, short max)
    {
      if ((int) min > (int) max)
        Math.ThrowMinMaxException<short>(min, max);
      if ((int) value < (int) min)
        return min;
      return (int) value > (int) max ? max : value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Clamp(int value, int min, int max)
    {
      if (min > max)
        Math.ThrowMinMaxException<int>(min, max);
      if (value < min)
        return min;
      return value > max ? max : value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long Clamp(long value, long min, long max)
    {
      if (min > max)
        Math.ThrowMinMaxException<long>(min, max);
      if (value < min)
        return min;
      return value > max ? max : value;
    }

    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static sbyte Clamp(sbyte value, sbyte min, sbyte max)
    {
      if ((int) min > (int) max)
        Math.ThrowMinMaxException<sbyte>(min, max);
      if ((int) value < (int) min)
        return min;
      return (int) value > (int) max ? max : value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Clamp(float value, float min, float max)
    {
      if ((double) min > (double) max)
        Math.ThrowMinMaxException<float>(min, max);
      if ((double) value < (double) min)
        return min;
      return (double) value > (double) max ? max : value;
    }

    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort Clamp(ushort value, ushort min, ushort max)
    {
      if ((int) min > (int) max)
        Math.ThrowMinMaxException<ushort>(min, max);
      if ((int) value < (int) min)
        return min;
      return (int) value > (int) max ? max : value;
    }

    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Clamp(uint value, uint min, uint max)
    {
      if (min > max)
        Math.ThrowMinMaxException<uint>(min, max);
      if (value < min)
        return min;
      return value > max ? max : value;
    }

    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Clamp(ulong value, ulong min, ulong max)
    {
      if (min > max)
        Math.ThrowMinMaxException<ulong>(min, max);
      if (value < min)
        return min;
      return value > max ? max : value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Decimal Floor(Decimal d) => Decimal.Floor(d);

    public static double IEEERemainder(double x, double y)
    {
      if (double.IsNaN(x))
        return x;
      if (double.IsNaN(y))
        return y;
      double d = x % y;
      if (double.IsNaN(d))
        return double.NaN;
      if (d == 0.0 && double.IsNegative(x))
        return -0.0;
      double num = d - Math.Abs(y) * (double) Math.Sign(x);
      if (Math.Abs(num) == Math.Abs(d))
      {
        double a = x / y;
        return Math.Abs(Math.Round(a)) > Math.Abs(a) ? num : d;
      }
      return Math.Abs(num) < Math.Abs(d) ? num : d;
    }

    public static double Log(double a, double newBase)
    {
      if (double.IsNaN(a))
        return a;
      if (double.IsNaN(newBase))
        return newBase;
      return newBase == 1.0 || a != 1.0 && (newBase == 0.0 || double.IsPositiveInfinity(newBase)) ? double.NaN : Math.Log(a) / Math.Log(newBase);
    }

    [NonVersionable]
    public static byte Max(byte val1, byte val2) => (int) val1 < (int) val2 ? val2 : val1;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Decimal Max(Decimal val1, Decimal val2) => Decimal.Max(in val1, in val2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Max(double val1, double val2) => val1 != val2 ? (!double.IsNaN(val1) && val2 >= val1 ? val2 : val1) : (!double.IsNegative(val2) ? val2 : val1);

    [NonVersionable]
    public static short Max(short val1, short val2) => (int) val1 < (int) val2 ? val2 : val1;

    [NonVersionable]
    public static int Max(int val1, int val2) => val1 < val2 ? val2 : val1;

    [NonVersionable]
    public static long Max(long val1, long val2) => val1 < val2 ? val2 : val1;

    [CLSCompliant(false)]
    [NonVersionable]
    public static sbyte Max(sbyte val1, sbyte val2) => (int) val1 < (int) val2 ? val2 : val1;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Max(float val1, float val2) => (double) val1 != (double) val2 ? (!float.IsNaN(val1) && (double) val2 >= (double) val1 ? val2 : val1) : (!float.IsNegative(val2) ? val2 : val1);

    [CLSCompliant(false)]
    [NonVersionable]
    public static ushort Max(ushort val1, ushort val2) => (int) val1 < (int) val2 ? val2 : val1;

    [CLSCompliant(false)]
    [NonVersionable]
    public static uint Max(uint val1, uint val2) => val1 < val2 ? val2 : val1;

    [CLSCompliant(false)]
    [NonVersionable]
    public static ulong Max(ulong val1, ulong val2) => val1 < val2 ? val2 : val1;

    public static double MaxMagnitude(double x, double y)
    {
      double d = Math.Abs(x);
      double num = Math.Abs(y);
      return d > num || double.IsNaN(d) || d == num && !double.IsNegative(x) ? x : y;
    }

    [NonVersionable]
    public static byte Min(byte val1, byte val2) => (int) val1 > (int) val2 ? val2 : val1;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Decimal Min(Decimal val1, Decimal val2) => Decimal.Min(in val1, in val2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Min(double val1, double val2) => val1 != val2 && !double.IsNaN(val1) ? (val1 >= val2 ? val2 : val1) : (!double.IsNegative(val1) ? val2 : val1);

    [NonVersionable]
    public static short Min(short val1, short val2) => (int) val1 > (int) val2 ? val2 : val1;

    [NonVersionable]
    public static int Min(int val1, int val2) => val1 > val2 ? val2 : val1;

    [NonVersionable]
    public static long Min(long val1, long val2) => val1 > val2 ? val2 : val1;

    [CLSCompliant(false)]
    [NonVersionable]
    public static sbyte Min(sbyte val1, sbyte val2) => (int) val1 > (int) val2 ? val2 : val1;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Min(float val1, float val2) => (double) val1 != (double) val2 && !float.IsNaN(val1) ? ((double) val1 >= (double) val2 ? val2 : val1) : (!float.IsNegative(val1) ? val2 : val1);

    [CLSCompliant(false)]
    [NonVersionable]
    public static ushort Min(ushort val1, ushort val2) => (int) val1 > (int) val2 ? val2 : val1;

    [CLSCompliant(false)]
    [NonVersionable]
    public static uint Min(uint val1, uint val2) => val1 > val2 ? val2 : val1;

    [CLSCompliant(false)]
    [NonVersionable]
    public static ulong Min(ulong val1, ulong val2) => val1 > val2 ? val2 : val1;

    public static double MinMagnitude(double x, double y)
    {
      double d = Math.Abs(x);
      double num = Math.Abs(y);
      return d < num || double.IsNaN(d) || d == num && double.IsNegative(x) ? x : y;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Decimal Round(Decimal d) => Decimal.Round(d, 0);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Decimal Round(Decimal d, int decimals) => Decimal.Round(d, decimals);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Decimal Round(Decimal d, MidpointRounding mode) => Decimal.Round(d, 0, mode);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Decimal Round(Decimal d, int decimals, MidpointRounding mode) => Decimal.Round(d, decimals, mode);

    [Intrinsic]
    public static double Round(double a)
    {
      ulong int64Bits = (ulong) BitConverter.DoubleToInt64Bits(a);
      int exponentFromBits = double.ExtractExponentFromBits(int64Bits);
      if (exponentFromBits <= 1022)
        return (long) int64Bits << 1 == 0L ? a : Math.CopySign(exponentFromBits != 1022 || double.ExtractSignificandFromBits(int64Bits) == 0UL ? 0.0 : 1.0, a);
      if (exponentFromBits >= 1075)
        return a;
      ulong num1 = 1UL << 1075 - exponentFromBits;
      ulong num2 = num1 - 1UL;
      ulong num3 = int64Bits + (num1 >> 1);
      return BitConverter.Int64BitsToDouble(((long) num3 & (long) num2) != 0L ? (long) (num3 & ~num2) : (long) (num3 & ~num1));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Round(double value, int digits) => Math.Round(value, digits, MidpointRounding.ToEven);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Round(double value, MidpointRounding mode) => Math.Round(value, 0, mode);

    public static unsafe double Round(double value, int digits, MidpointRounding mode)
    {
      if (digits < 0 || digits > 15)
        throw new ArgumentOutOfRangeException(nameof (digits), SR.ArgumentOutOfRange_RoundingDigits);
      if (mode < MidpointRounding.ToEven || mode > MidpointRounding.ToPositiveInfinity)
        throw new ArgumentException(SR.Format(SR.Argument_InvalidEnumValue, (object) mode, (object) "MidpointRounding"), nameof (mode));
      if (Math.Abs(value) < 10000000000000000.0)
      {
        double num1 = Math.roundPower10Double[digits];
        value *= num1;
        switch (mode)
        {
          case MidpointRounding.ToEven:
            value = Math.Round(value);
            break;
          case MidpointRounding.AwayFromZero:
            double num2 = Math.ModF(value, &value);
            if (Math.Abs(num2) >= 0.5)
            {
              value += (double) Math.Sign(num2);
              break;
            }
            break;
          case MidpointRounding.ToZero:
            value = Math.Truncate(value);
            break;
          case MidpointRounding.ToNegativeInfinity:
            value = Math.Floor(value);
            break;
          case MidpointRounding.ToPositiveInfinity:
            value = Math.Ceiling(value);
            break;
          default:
            throw new ArgumentException(SR.Format(SR.Argument_InvalidEnumValue, (object) mode, (object) "MidpointRounding"), nameof (mode));
        }
        value /= num1;
      }
      return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Sign(Decimal value) => Decimal.Sign(in value);

    public static int Sign(double value)
    {
      if (value < 0.0)
        return -1;
      if (value > 0.0)
        return 1;
      if (value == 0.0)
        return 0;
      throw new ArithmeticException(SR.Arithmetic_NaN);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Sign(short value) => Math.Sign((int) value);

    public static int Sign(int value) => value >> 31 | (int) ((uint) -value >> 31);

    public static int Sign(long value) => (int) (value >> 63 | (long) ((ulong) -value >> 63));

    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Sign(sbyte value) => Math.Sign((int) value);

    public static int Sign(float value)
    {
      if ((double) value < 0.0)
        return -1;
      if ((double) value > 0.0)
        return 1;
      if ((double) value == 0.0)
        return 0;
      throw new ArithmeticException(SR.Arithmetic_NaN);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Decimal Truncate(Decimal d) => Decimal.Truncate(d);

    public static unsafe double Truncate(double d)
    {
      Math.ModF(d, &d);
      return d;
    }

    [DoesNotReturn]
    private static void ThrowMinMaxException<T>(T min, T max) => throw new ArgumentException(SR.Format(SR.Argument_MinMaxValue, (object) min, (object) max));
  }
}
