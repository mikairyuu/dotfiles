// Decompiled with JetBrains decompiler
// Type: System.Number
// Assembly: System.Private.CoreLib, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// MVID: 576BEC19-D8AC-4AB7-9D98-CD1623F32A17
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.7/System.Private.CoreLib.dll

using Internal.Runtime.CompilerServices;
using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace System
{
  internal static class Number
  {
    private static readonly string[] s_singleDigitStringCache = new string[10]
    {
      "0",
      "1",
      "2",
      "3",
      "4",
      "5",
      "6",
      "7",
      "8",
      "9"
    };
    private static readonly string[] s_posCurrencyFormats = new string[4]
    {
      "$#",
      "#$",
      "$ #",
      "# $"
    };
    private static readonly string[] s_negCurrencyFormats = new string[17]
    {
      "($#)",
      "-$#",
      "$-#",
      "$#-",
      "(#$)",
      "-#$",
      "#-$",
      "#$-",
      "-# $",
      "-$ #",
      "# $-",
      "$ #-",
      "$ -#",
      "#- $",
      "($ #)",
      "(# $)",
      "$- #"
    };
    private static readonly string[] s_posPercentFormats = new string[4]
    {
      "# %",
      "#%",
      "%#",
      "% #"
    };
    private static readonly string[] s_negPercentFormats = new string[12]
    {
      "-# %",
      "-#%",
      "-%#",
      "%-#",
      "%#-",
      "#-%",
      "#%-",
      "-% #",
      "# %-",
      "% #-",
      "% -#",
      "#- %"
    };
    private static readonly string[] s_negNumberFormats = new string[5]
    {
      "(#)",
      "-#",
      "- #",
      "#-",
      "# -"
    };
    private static readonly float[] s_Pow10SingleTable = new float[11]
    {
      1f,
      10f,
      100f,
      1000f,
      10000f,
      100000f,
      1000000f,
      10000000f,
      100000000f,
      1E+09f,
      1E+10f
    };
    private static readonly double[] s_Pow10DoubleTable = new double[23]
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
      1000000000000000.0,
      10000000000000000.0,
      1E+17,
      1E+18,
      1E+19,
      1E+20,
      1E+21,
      1E+22
    };

    public static void Dragon4Double(
      double value,
      int cutoffNumber,
      bool isSignificantDigits,
      ref Number.NumberBuffer number)
    {
      double num = double.IsNegative(value) ? -value : value;
      int exponent;
      ulong andBiasedExponent = Number.ExtractFractionAndBiasedExponent(value, out exponent);
      bool hasUnequalMargins = false;
      uint mantissaHighBitIdx;
      if (andBiasedExponent >> 52 != 0UL)
      {
        mantissaHighBitIdx = 52U;
        hasUnequalMargins = andBiasedExponent == 4503599627370496UL;
      }
      else
        mantissaHighBitIdx = (uint) BitOperations.Log2(andBiasedExponent);
      int decimalExponent;
      int index = (int) Number.Dragon4(andBiasedExponent, exponent, mantissaHighBitIdx, hasUnequalMargins, cutoffNumber, isSignificantDigits, number.Digits, out decimalExponent);
      number.Scale = decimalExponent + 1;
      number.Digits[index] = (byte) 0;
      number.DigitsCount = index;
    }

    public static void Dragon4Half(
      Half value,
      int cutoffNumber,
      bool isSignificantDigits,
      ref Number.NumberBuffer number)
    {
      Half half = Half.IsNegative(value) ? Half.Negate(value) : value;
      int exponent;
      ushort andBiasedExponent = Number.ExtractFractionAndBiasedExponent(value, out exponent);
      bool hasUnequalMargins = false;
      uint mantissaHighBitIdx;
      if ((int) andBiasedExponent >> 10 != 0)
      {
        mantissaHighBitIdx = 10U;
        hasUnequalMargins = andBiasedExponent == (ushort) 1024;
      }
      else
        mantissaHighBitIdx = (uint) BitOperations.Log2((uint) andBiasedExponent);
      int decimalExponent;
      int index = (int) Number.Dragon4((ulong) andBiasedExponent, exponent, mantissaHighBitIdx, hasUnequalMargins, cutoffNumber, isSignificantDigits, number.Digits, out decimalExponent);
      number.Scale = decimalExponent + 1;
      number.Digits[index] = (byte) 0;
      number.DigitsCount = index;
    }

    public static void Dragon4Single(
      float value,
      int cutoffNumber,
      bool isSignificantDigits,
      ref Number.NumberBuffer number)
    {
      float num = float.IsNegative(value) ? -value : value;
      int exponent;
      uint andBiasedExponent = Number.ExtractFractionAndBiasedExponent(value, out exponent);
      bool hasUnequalMargins = false;
      uint mantissaHighBitIdx;
      if (andBiasedExponent >> 23 != 0U)
      {
        mantissaHighBitIdx = 23U;
        hasUnequalMargins = andBiasedExponent == 8388608U;
      }
      else
        mantissaHighBitIdx = (uint) BitOperations.Log2(andBiasedExponent);
      int decimalExponent;
      int index = (int) Number.Dragon4((ulong) andBiasedExponent, exponent, mantissaHighBitIdx, hasUnequalMargins, cutoffNumber, isSignificantDigits, number.Digits, out decimalExponent);
      number.Scale = decimalExponent + 1;
      number.Digits[index] = (byte) 0;
      number.DigitsCount = index;
    }

    private static unsafe uint Dragon4(
      ulong mantissa,
      int exponent,
      uint mantissaHighBitIdx,
      bool hasUnequalMargins,
      int cutoffNumber,
      bool isSignificantDigits,
      Span<byte> buffer,
      out int decimalExponent)
    {
      int index = 0;
      Number.BigInteger result1;
      Number.BigInteger result2;
      Number.BigInteger result3;
      Number.BigInteger* bigIntegerPtr;
      if (hasUnequalMargins)
      {
        Number.BigInteger result4;
        if (exponent > 0)
        {
          Number.BigInteger.SetUInt64(out result1, 4UL * mantissa);
          result1.ShiftLeft((uint) exponent);
          Number.BigInteger.SetUInt32(out result2, 4U);
          Number.BigInteger.Pow2((uint) exponent, out result3);
          Number.BigInteger.Pow2((uint) (exponent + 1), out result4);
        }
        else
        {
          Number.BigInteger.SetUInt64(out result1, 4UL * mantissa);
          Number.BigInteger.Pow2((uint) (-exponent + 2), out result2);
          Number.BigInteger.SetUInt32(out result3, 1U);
          Number.BigInteger.SetUInt32(out result4, 2U);
        }
        bigIntegerPtr = &result4;
      }
      else
      {
        if (exponent > 0)
        {
          Number.BigInteger.SetUInt64(out result1, 2UL * mantissa);
          result1.ShiftLeft((uint) exponent);
          Number.BigInteger.SetUInt32(out result2, 2U);
          Number.BigInteger.Pow2((uint) exponent, out result3);
        }
        else
        {
          Number.BigInteger.SetUInt64(out result1, 2UL * mantissa);
          Number.BigInteger.Pow2((uint) (-exponent + 1), out result2);
          Number.BigInteger.SetUInt32(out result3, 1U);
        }
        bigIntegerPtr = &result3;
      }
      int num1 = (int) Math.Ceiling((double) ((int) mantissaHighBitIdx + exponent) * 0.3010299956639812 - 0.69);
      if (num1 > 0)
        result2.MultiplyPow10((uint) num1);
      else if (num1 < 0)
      {
        Number.BigInteger result4;
        Number.BigInteger.Pow10((uint) -num1, out result4);
        result1.Multiply(ref result4);
        result3.Multiply(ref result4);
        if (bigIntegerPtr != &result3)
          Number.BigInteger.Multiply(ref result3, 2U, out *bigIntegerPtr);
      }
      bool flag1 = mantissa % 2UL == 0UL;
      bool flag2;
      if (cutoffNumber == -1)
      {
        Number.BigInteger result4;
        Number.BigInteger.Add(ref result1, ref *bigIntegerPtr, out result4);
        int num2 = Number.BigInteger.Compare(ref result4, ref result2);
        flag2 = flag1 ? num2 >= 0 : num2 > 0;
      }
      else
        flag2 = Number.BigInteger.Compare(ref result1, ref result2) >= 0;
      if (flag2)
      {
        ++num1;
      }
      else
      {
        result1.Multiply10();
        result3.Multiply10();
        if (bigIntegerPtr != &result3)
          Number.BigInteger.Multiply(ref result3, 2U, out *bigIntegerPtr);
      }
      int num3 = num1 - buffer.Length;
      if (cutoffNumber != -1)
      {
        int num2 = !isSignificantDigits ? -cutoffNumber : num1 - cutoffNumber;
        if (num2 > num3)
          num3 = num2;
      }
      int num4;
      decimalExponent = num4 = num1 - 1;
      uint block = result2.GetBlock((uint) (result2.GetLength() - 1));
      if (block < 8U || block > 429496729U)
      {
        uint shift = (59U - (uint) BitOperations.Log2(block)) % 32U;
        result2.ShiftLeft(shift);
        result1.ShiftLeft(shift);
        result3.ShiftLeft(shift);
        if (bigIntegerPtr != &result3)
          Number.BigInteger.Multiply(ref result3, 2U, out *bigIntegerPtr);
      }
      uint num5;
      bool flag3;
      bool flag4;
      if (cutoffNumber == -1)
      {
        while (true)
        {
          num5 = Number.BigInteger.HeuristicDivide(ref result1, ref result2);
          Number.BigInteger result4;
          Number.BigInteger.Add(ref result1, ref *bigIntegerPtr, out result4);
          int num2 = Number.BigInteger.Compare(ref result1, ref result3);
          int num6 = Number.BigInteger.Compare(ref result4, ref result2);
          if (flag1)
          {
            flag3 = num2 <= 0;
            flag4 = num6 >= 0;
          }
          else
          {
            flag3 = num2 < 0;
            flag4 = num6 > 0;
          }
          if (!(flag3 | flag4) && num4 != num3)
          {
            buffer[index] = (byte) (48U + num5);
            ++index;
            result1.Multiply10();
            result3.Multiply10();
            if (bigIntegerPtr != &result3)
              Number.BigInteger.Multiply(ref result3, 2U, out *bigIntegerPtr);
            --num4;
          }
          else
            break;
        }
      }
      else if (num4 >= num3)
      {
        flag3 = false;
        flag4 = false;
        while (true)
        {
          num5 = Number.BigInteger.HeuristicDivide(ref result1, ref result2);
          if (!result1.IsZero() && num4 > num3)
          {
            buffer[index] = (byte) (48U + num5);
            ++index;
            result1.Multiply10();
            --num4;
          }
          else
            break;
        }
      }
      else
      {
        uint num2 = Number.BigInteger.HeuristicDivide(ref result1, ref result2);
        switch (num2)
        {
          case 0:
          case 1:
          case 2:
          case 3:
          case 4:
            buffer[index] = (byte) (48U + num2);
            return (uint) (index + 1);
          case 5:
            if (result1.IsZero())
              goto case 0;
            else
              goto default;
          default:
            ++decimalExponent;
            num2 = 1U;
            goto case 0;
        }
      }
      bool flag5 = flag3;
      if (flag3 == flag4)
      {
        result1.ShiftLeft(1U);
        int num2 = Number.BigInteger.Compare(ref result1, ref result2);
        flag5 = num2 < 0;
        if (num2 == 0)
          flag5 = ((int) num5 & 1) == 0;
      }
      int num7;
      if (flag5)
      {
        buffer[index] = (byte) (48U + num5);
        num7 = index + 1;
      }
      else if (num5 == 9U)
      {
        while (index != 0)
        {
          --index;
          if (buffer[index] != (byte) 57)
          {
            ++buffer[index];
            num7 = index + 1;
            goto label_54;
          }
        }
        buffer[index] = (byte) 49;
        num7 = index + 1;
        ++decimalExponent;
      }
      else
      {
        buffer[index] = (byte) (48 + (int) num5 + 1);
        num7 = index + 1;
      }
label_54:
      return (uint) num7;
    }

    public static unsafe string FormatDecimal(
      Decimal value,
      ReadOnlySpan<char> format,
      NumberFormatInfo info)
    {
      int digits1;
      char formatSpecifier = Number.ParseFormatSpecifier(format, out digits1);
      byte* digits2 = stackalloc byte[31];
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Decimal, digits2, 31);
      Number.DecimalToNumber(ref value, ref number);
      char* chPtr = stackalloc char[32];
      ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) chPtr, 32));
      if (formatSpecifier != char.MinValue)
        Number.NumberToString(ref sb, ref number, formatSpecifier, digits1, info);
      else
        Number.NumberToStringFormat(ref sb, ref number, format, info);
      return sb.ToString();
    }

    public static unsafe bool TryFormatDecimal(
      Decimal value,
      ReadOnlySpan<char> format,
      NumberFormatInfo info,
      Span<char> destination,
      out int charsWritten)
    {
      int digits1;
      char formatSpecifier = Number.ParseFormatSpecifier(format, out digits1);
      byte* digits2 = stackalloc byte[31];
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Decimal, digits2, 31);
      Number.DecimalToNumber(ref value, ref number);
      char* chPtr = stackalloc char[32];
      ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) chPtr, 32));
      if (formatSpecifier != char.MinValue)
        Number.NumberToString(ref sb, ref number, formatSpecifier, digits1, info);
      else
        Number.NumberToStringFormat(ref sb, ref number, format, info);
      return sb.TryCopyTo(destination, out charsWritten);
    }

    internal static unsafe void DecimalToNumber(ref Decimal d, ref Number.NumberBuffer number)
    {
      byte* digitsPointer1 = number.GetDigitsPointer();
      number.DigitsCount = 29;
      number.IsNegative = d.IsNegative;
      byte* bufferEnd = digitsPointer1 + 29;
      while (((int) d.Mid | (int) d.High) != 0)
        bufferEnd = Number.UInt32ToDecChars(bufferEnd, Decimal.DecDivMod1E9(ref d), 9);
      byte* decChars = Number.UInt32ToDecChars(bufferEnd, d.Low, 0);
      int num = (int) (digitsPointer1 + 29 - decChars);
      number.DigitsCount = num;
      number.Scale = num - d.Scale;
      byte* digitsPointer2 = number.GetDigitsPointer();
      while (--num >= 0)
        *digitsPointer2++ = *decChars++;
      *digitsPointer2 = (byte) 0;
    }

    public static unsafe string FormatDouble(double value, string format, NumberFormatInfo info)
    {
      // ISSUE: untyped stack allocation
      ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) __untypedstackalloc(new IntPtr(64)), 32));
      return Number.FormatDouble(ref sb, value, (ReadOnlySpan<char>) format, info) ?? sb.ToString();
    }

    public static unsafe bool TryFormatDouble(
      double value,
      ReadOnlySpan<char> format,
      NumberFormatInfo info,
      Span<char> destination,
      out int charsWritten)
    {
      // ISSUE: untyped stack allocation
      ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) __untypedstackalloc(new IntPtr(64)), 32));
      string source = Number.FormatDouble(ref sb, value, format, info);
      return source == null ? sb.TryCopyTo(destination, out charsWritten) : Number.TryCopyTo(source, destination, out charsWritten);
    }

    private static int GetFloatingPointMaxDigitsAndPrecision(
      char fmt,
      ref int precision,
      NumberFormatInfo info,
      out bool isSignificantDigits)
    {
      if (fmt == char.MinValue)
      {
        isSignificantDigits = true;
        return precision;
      }
      int num = precision;
      if (fmt <= 'R')
      {
        switch ((int) fmt - 67)
        {
          case 0:
            break;
          case 1:
            goto label_23;
          case 2:
            goto label_10;
          case 3:
            goto label_13;
          case 4:
            goto label_16;
          default:
            switch ((int) fmt - 78)
            {
              case 0:
                goto label_13;
              case 2:
                goto label_19;
              case 4:
                goto label_22;
              default:
                goto label_23;
            }
        }
      }
      else
      {
        switch ((int) fmt - 99)
        {
          case 0:
            break;
          case 1:
            goto label_23;
          case 2:
            goto label_10;
          case 3:
            goto label_13;
          case 4:
            goto label_16;
          default:
            switch ((int) fmt - 110)
            {
              case 0:
                goto label_13;
              case 2:
                goto label_19;
              case 4:
                goto label_22;
              default:
                goto label_23;
            }
        }
      }
      if (precision == -1)
        precision = info.CurrencyDecimalDigits;
      isSignificantDigits = false;
      goto label_24;
label_10:
      if (precision == -1)
        precision = 6;
      ++precision;
      isSignificantDigits = true;
      goto label_24;
label_13:
      if (precision == -1)
        precision = info.NumberDecimalDigits;
      isSignificantDigits = false;
      goto label_24;
label_16:
      if (precision == 0)
        precision = -1;
      isSignificantDigits = true;
      goto label_24;
label_19:
      if (precision == -1)
        precision = info.PercentDecimalDigits;
      precision += 2;
      isSignificantDigits = false;
      goto label_24;
label_22:
      precision = -1;
      isSignificantDigits = true;
      goto label_24;
label_23:
      throw new FormatException(SR.Argument_BadFormatSpecifier);
label_24:
      return num;
    }

    private static unsafe string FormatDouble(
      ref ValueStringBuilder sb,
      double value,
      ReadOnlySpan<char> format,
      NumberFormatInfo info)
    {
      if (!double.IsFinite(value))
      {
        if (double.IsNaN(value))
          return info.NaNSymbol;
        return !double.IsNegative(value) ? info.PositiveInfinitySymbol : info.NegativeInfinitySymbol;
      }
      int digits1;
      char formatSpecifier = Number.ParseFormatSpecifier(format, out digits1);
      byte* digits2 = stackalloc byte[769];
      if (formatSpecifier == char.MinValue)
        digits1 = 15;
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.FloatingPoint, digits2, 769);
      number.IsNegative = double.IsNegative(value);
      bool isSignificantDigits;
      int nMaxDigits = Number.GetFloatingPointMaxDigitsAndPrecision(formatSpecifier, ref digits1, info, out isSignificantDigits);
      if (value != 0.0 && (!isSignificantDigits || !Number.Grisu3.TryRunDouble(value, digits1, ref number)))
        Number.Dragon4Double(value, digits1, isSignificantDigits, ref number);
      if (formatSpecifier != char.MinValue)
      {
        if (digits1 == -1)
          nMaxDigits = Math.Max(number.DigitsCount, 17);
        Number.NumberToString(ref sb, ref number, formatSpecifier, nMaxDigits, info);
      }
      else
        Number.NumberToStringFormat(ref sb, ref number, format, info);
      return (string) null;
    }

    public static unsafe string FormatSingle(float value, string format, NumberFormatInfo info)
    {
      // ISSUE: untyped stack allocation
      ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) __untypedstackalloc(new IntPtr(64)), 32));
      return Number.FormatSingle(ref sb, value, (ReadOnlySpan<char>) format, info) ?? sb.ToString();
    }

    public static unsafe bool TryFormatSingle(
      float value,
      ReadOnlySpan<char> format,
      NumberFormatInfo info,
      Span<char> destination,
      out int charsWritten)
    {
      // ISSUE: untyped stack allocation
      ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) __untypedstackalloc(new IntPtr(64)), 32));
      string source = Number.FormatSingle(ref sb, value, format, info);
      return source == null ? sb.TryCopyTo(destination, out charsWritten) : Number.TryCopyTo(source, destination, out charsWritten);
    }

    private static unsafe string FormatSingle(
      ref ValueStringBuilder sb,
      float value,
      ReadOnlySpan<char> format,
      NumberFormatInfo info)
    {
      if (!float.IsFinite(value))
      {
        if (float.IsNaN(value))
          return info.NaNSymbol;
        return !float.IsNegative(value) ? info.PositiveInfinitySymbol : info.NegativeInfinitySymbol;
      }
      int digits1;
      char formatSpecifier = Number.ParseFormatSpecifier(format, out digits1);
      byte* digits2 = stackalloc byte[114];
      if (formatSpecifier == char.MinValue)
        digits1 = 7;
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.FloatingPoint, digits2, 114);
      number.IsNegative = float.IsNegative(value);
      bool isSignificantDigits;
      int nMaxDigits = Number.GetFloatingPointMaxDigitsAndPrecision(formatSpecifier, ref digits1, info, out isSignificantDigits);
      if ((double) value != 0.0 && (!isSignificantDigits || !Number.Grisu3.TryRunSingle(value, digits1, ref number)))
        Number.Dragon4Single(value, digits1, isSignificantDigits, ref number);
      if (formatSpecifier != char.MinValue)
      {
        if (digits1 == -1)
          nMaxDigits = Math.Max(number.DigitsCount, 9);
        Number.NumberToString(ref sb, ref number, formatSpecifier, nMaxDigits, info);
      }
      else
        Number.NumberToStringFormat(ref sb, ref number, format, info);
      return (string) null;
    }

    public static unsafe string FormatHalf(Half value, string format, NumberFormatInfo info)
    {
      // ISSUE: untyped stack allocation
      ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) __untypedstackalloc(new IntPtr(64)), 32));
      return Number.FormatHalf(ref sb, value, (ReadOnlySpan<char>) format, info) ?? sb.ToString();
    }

    private static unsafe string FormatHalf(
      ref ValueStringBuilder sb,
      Half value,
      ReadOnlySpan<char> format,
      NumberFormatInfo info)
    {
      if (!Half.IsFinite(value))
      {
        if (Half.IsNaN(value))
          return info.NaNSymbol;
        return !Half.IsNegative(value) ? info.PositiveInfinitySymbol : info.NegativeInfinitySymbol;
      }
      int digits1;
      char formatSpecifier = Number.ParseFormatSpecifier(format, out digits1);
      byte* digits2 = stackalloc byte[21];
      if (formatSpecifier == char.MinValue)
        digits1 = 5;
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.FloatingPoint, digits2, 21);
      number.IsNegative = Half.IsNegative(value);
      bool isSignificantDigits;
      int nMaxDigits = Number.GetFloatingPointMaxDigitsAndPrecision(formatSpecifier, ref digits1, info, out isSignificantDigits);
      if (value != new Half() && (!isSignificantDigits || !Number.Grisu3.TryRunHalf(value, digits1, ref number)))
        Number.Dragon4Half(value, digits1, isSignificantDigits, ref number);
      if (formatSpecifier != char.MinValue)
      {
        if (digits1 == -1)
          nMaxDigits = Math.Max(number.DigitsCount, 5);
        Number.NumberToString(ref sb, ref number, formatSpecifier, nMaxDigits, info);
      }
      else
        Number.NumberToStringFormat(ref sb, ref number, format, info);
      return (string) null;
    }

    public static unsafe bool TryFormatHalf(
      Half value,
      ReadOnlySpan<char> format,
      NumberFormatInfo info,
      Span<char> destination,
      out int charsWritten)
    {
      // ISSUE: untyped stack allocation
      ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) __untypedstackalloc(new IntPtr(64)), 32));
      string source = Number.FormatHalf(ref sb, value, format, info);
      return source == null ? sb.TryCopyTo(destination, out charsWritten) : Number.TryCopyTo(source, destination, out charsWritten);
    }

    private static bool TryCopyTo(string source, Span<char> destination, out int charsWritten)
    {
      if (source.AsSpan().TryCopyTo(destination))
      {
        charsWritten = source.Length;
        return true;
      }
      charsWritten = 0;
      return false;
    }

    private static char GetHexBase(char fmt) => (char) ((uint) fmt - 33U);

    public static unsafe string FormatInt32(
      int value,
      int hexMask,
      string format,
      IFormatProvider provider)
    {
      if (!string.IsNullOrEmpty(format))
        return FormatInt32Slow(value, hexMask, format, provider);
      return value < 0 ? Number.NegativeInt32ToDecStr(value, -1, NumberFormatInfo.GetInstance(provider).NegativeSign) : Number.UInt32ToDecStr((uint) value);

      static unsafe string FormatInt32Slow(
        int value,
        int hexMask,
        string format,
        IFormatProvider provider)
      {
        ReadOnlySpan<char> format1 = (ReadOnlySpan<char>) format;
        int digits1;
        char formatSpecifier = Number.ParseFormatSpecifier(format1, out digits1);
        char ch = (char) ((uint) formatSpecifier & 65503U);
        if ((ch == 'G' ? (digits1 < 1 ? 1 : 0) : (ch == 'D' ? 1 : 0)) != 0)
          return value < 0 ? Number.NegativeInt32ToDecStr(value, digits1, NumberFormatInfo.GetInstance(provider).NegativeSign) : Number.UInt32ToDecStr((uint) value, digits1);
        if (ch == 'X')
          return Number.Int32ToHexStr(value & hexMask, Number.GetHexBase(formatSpecifier), digits1);
        NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
        byte* digits2 = stackalloc byte[11];
        Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Integer, digits2, 11);
        Number.Int32ToNumber(value, ref number);
        char* chPtr = stackalloc char[32];
        ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) chPtr, 32));
        if (formatSpecifier != char.MinValue)
          Number.NumberToString(ref sb, ref number, formatSpecifier, digits1, instance);
        else
          Number.NumberToStringFormat(ref sb, ref number, format1, instance);
        return sb.ToString();
      }
    }

    public static unsafe bool TryFormatInt32(
      int value,
      int hexMask,
      ReadOnlySpan<char> format,
      IFormatProvider provider,
      Span<char> destination,
      out int charsWritten)
    {
      if (format.Length != 0)
        return TryFormatInt32Slow(value, hexMask, format, provider, destination, out charsWritten);
      return value < 0 ? Number.TryNegativeInt32ToDecStr(value, -1, NumberFormatInfo.GetInstance(provider).NegativeSign, destination, out charsWritten) : Number.TryUInt32ToDecStr((uint) value, -1, destination, out charsWritten);

      static unsafe bool TryFormatInt32Slow(
        int value,
        int hexMask,
        ReadOnlySpan<char> format,
        IFormatProvider provider,
        Span<char> destination,
        out int charsWritten)
      {
        int digits1;
        char formatSpecifier = Number.ParseFormatSpecifier(format, out digits1);
        char ch = (char) ((uint) formatSpecifier & 65503U);
        if ((ch == 'G' ? (digits1 < 1 ? 1 : 0) : (ch == 'D' ? 1 : 0)) != 0)
          return value < 0 ? Number.TryNegativeInt32ToDecStr(value, digits1, NumberFormatInfo.GetInstance(provider).NegativeSign, destination, out charsWritten) : Number.TryUInt32ToDecStr((uint) value, digits1, destination, out charsWritten);
        if (ch == 'X')
          return Number.TryInt32ToHexStr(value & hexMask, Number.GetHexBase(formatSpecifier), digits1, destination, out charsWritten);
        NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
        byte* digits2 = stackalloc byte[11];
        Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Integer, digits2, 11);
        Number.Int32ToNumber(value, ref number);
        char* chPtr = stackalloc char[32];
        ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) chPtr, 32));
        if (formatSpecifier != char.MinValue)
          Number.NumberToString(ref sb, ref number, formatSpecifier, digits1, instance);
        else
          Number.NumberToStringFormat(ref sb, ref number, format, instance);
        return sb.TryCopyTo(destination, out charsWritten);
      }
    }

    public static unsafe string FormatUInt32(uint value, string format, IFormatProvider provider)
    {
      return string.IsNullOrEmpty(format) ? Number.UInt32ToDecStr(value) : FormatUInt32Slow(value, format, provider);

      static unsafe string FormatUInt32Slow(uint value, string format, IFormatProvider provider)
      {
        ReadOnlySpan<char> format1 = (ReadOnlySpan<char>) format;
        int digits1;
        char formatSpecifier = Number.ParseFormatSpecifier(format1, out digits1);
        char ch = (char) ((uint) formatSpecifier & 65503U);
        if ((ch == 'G' ? (digits1 < 1 ? 1 : 0) : (ch == 'D' ? 1 : 0)) != 0)
          return Number.UInt32ToDecStr(value, digits1);
        if (ch == 'X')
          return Number.Int32ToHexStr((int) value, Number.GetHexBase(formatSpecifier), digits1);
        NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
        byte* digits2 = stackalloc byte[11];
        Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Integer, digits2, 11);
        Number.UInt32ToNumber(value, ref number);
        char* chPtr = stackalloc char[32];
        ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) chPtr, 32));
        if (formatSpecifier != char.MinValue)
          Number.NumberToString(ref sb, ref number, formatSpecifier, digits1, instance);
        else
          Number.NumberToStringFormat(ref sb, ref number, format1, instance);
        return sb.ToString();
      }
    }

    public static unsafe bool TryFormatUInt32(
      uint value,
      ReadOnlySpan<char> format,
      IFormatProvider provider,
      Span<char> destination,
      out int charsWritten)
    {
      return format.Length == 0 ? Number.TryUInt32ToDecStr(value, -1, destination, out charsWritten) : TryFormatUInt32Slow(value, format, provider, destination, out charsWritten);

      static unsafe bool TryFormatUInt32Slow(
        uint value,
        ReadOnlySpan<char> format,
        IFormatProvider provider,
        Span<char> destination,
        out int charsWritten)
      {
        int digits1;
        char formatSpecifier = Number.ParseFormatSpecifier(format, out digits1);
        char ch = (char) ((uint) formatSpecifier & 65503U);
        if ((ch == 'G' ? (digits1 < 1 ? 1 : 0) : (ch == 'D' ? 1 : 0)) != 0)
          return Number.TryUInt32ToDecStr(value, digits1, destination, out charsWritten);
        if (ch == 'X')
          return Number.TryInt32ToHexStr((int) value, Number.GetHexBase(formatSpecifier), digits1, destination, out charsWritten);
        NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
        byte* digits2 = stackalloc byte[11];
        Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Integer, digits2, 11);
        Number.UInt32ToNumber(value, ref number);
        char* chPtr = stackalloc char[32];
        ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) chPtr, 32));
        if (formatSpecifier != char.MinValue)
          Number.NumberToString(ref sb, ref number, formatSpecifier, digits1, instance);
        else
          Number.NumberToStringFormat(ref sb, ref number, format, instance);
        return sb.TryCopyTo(destination, out charsWritten);
      }
    }

    public static unsafe string FormatInt64(long value, string format, IFormatProvider provider)
    {
      if (!string.IsNullOrEmpty(format))
        return FormatInt64Slow(value, format, provider);
      return value < 0L ? Number.NegativeInt64ToDecStr(value, -1, NumberFormatInfo.GetInstance(provider).NegativeSign) : Number.UInt64ToDecStr((ulong) value, -1);

      static unsafe string FormatInt64Slow(long value, string format, IFormatProvider provider)
      {
        ReadOnlySpan<char> format1 = (ReadOnlySpan<char>) format;
        int digits1;
        char formatSpecifier = Number.ParseFormatSpecifier(format1, out digits1);
        char ch = (char) ((uint) formatSpecifier & 65503U);
        if ((ch == 'G' ? (digits1 < 1 ? 1 : 0) : (ch == 'D' ? 1 : 0)) != 0)
          return value < 0L ? Number.NegativeInt64ToDecStr(value, digits1, NumberFormatInfo.GetInstance(provider).NegativeSign) : Number.UInt64ToDecStr((ulong) value, digits1);
        if (ch == 'X')
          return Number.Int64ToHexStr(value, Number.GetHexBase(formatSpecifier), digits1);
        NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
        byte* digits2 = stackalloc byte[20];
        Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Integer, digits2, 20);
        Number.Int64ToNumber(value, ref number);
        char* chPtr = stackalloc char[32];
        ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) chPtr, 32));
        if (formatSpecifier != char.MinValue)
          Number.NumberToString(ref sb, ref number, formatSpecifier, digits1, instance);
        else
          Number.NumberToStringFormat(ref sb, ref number, format1, instance);
        return sb.ToString();
      }
    }

    public static unsafe bool TryFormatInt64(
      long value,
      ReadOnlySpan<char> format,
      IFormatProvider provider,
      Span<char> destination,
      out int charsWritten)
    {
      if (format.Length != 0)
        return TryFormatInt64Slow(value, format, provider, destination, out charsWritten);
      return value < 0L ? Number.TryNegativeInt64ToDecStr(value, -1, NumberFormatInfo.GetInstance(provider).NegativeSign, destination, out charsWritten) : Number.TryUInt64ToDecStr((ulong) value, -1, destination, out charsWritten);

      static unsafe bool TryFormatInt64Slow(
        long value,
        ReadOnlySpan<char> format,
        IFormatProvider provider,
        Span<char> destination,
        out int charsWritten)
      {
        int digits1;
        char formatSpecifier = Number.ParseFormatSpecifier(format, out digits1);
        char ch = (char) ((uint) formatSpecifier & 65503U);
        if ((ch == 'G' ? (digits1 < 1 ? 1 : 0) : (ch == 'D' ? 1 : 0)) != 0)
          return value < 0L ? Number.TryNegativeInt64ToDecStr(value, digits1, NumberFormatInfo.GetInstance(provider).NegativeSign, destination, out charsWritten) : Number.TryUInt64ToDecStr((ulong) value, digits1, destination, out charsWritten);
        if (ch == 'X')
          return Number.TryInt64ToHexStr(value, Number.GetHexBase(formatSpecifier), digits1, destination, out charsWritten);
        NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
        byte* digits2 = stackalloc byte[20];
        Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Integer, digits2, 20);
        Number.Int64ToNumber(value, ref number);
        char* chPtr = stackalloc char[32];
        ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) chPtr, 32));
        if (formatSpecifier != char.MinValue)
          Number.NumberToString(ref sb, ref number, formatSpecifier, digits1, instance);
        else
          Number.NumberToStringFormat(ref sb, ref number, format, instance);
        return sb.TryCopyTo(destination, out charsWritten);
      }
    }

    public static unsafe string FormatUInt64(ulong value, string format, IFormatProvider provider)
    {
      return string.IsNullOrEmpty(format) ? Number.UInt64ToDecStr(value, -1) : FormatUInt64Slow(value, format, provider);

      static unsafe string FormatUInt64Slow(ulong value, string format, IFormatProvider provider)
      {
        ReadOnlySpan<char> format1 = (ReadOnlySpan<char>) format;
        int digits1;
        char formatSpecifier = Number.ParseFormatSpecifier(format1, out digits1);
        char ch = (char) ((uint) formatSpecifier & 65503U);
        if ((ch == 'G' ? (digits1 < 1 ? 1 : 0) : (ch == 'D' ? 1 : 0)) != 0)
          return Number.UInt64ToDecStr(value, digits1);
        if (ch == 'X')
          return Number.Int64ToHexStr((long) value, Number.GetHexBase(formatSpecifier), digits1);
        NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
        byte* digits2 = stackalloc byte[21];
        Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Integer, digits2, 21);
        Number.UInt64ToNumber(value, ref number);
        char* chPtr = stackalloc char[32];
        ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) chPtr, 32));
        if (formatSpecifier != char.MinValue)
          Number.NumberToString(ref sb, ref number, formatSpecifier, digits1, instance);
        else
          Number.NumberToStringFormat(ref sb, ref number, format1, instance);
        return sb.ToString();
      }
    }

    public static unsafe bool TryFormatUInt64(
      ulong value,
      ReadOnlySpan<char> format,
      IFormatProvider provider,
      Span<char> destination,
      out int charsWritten)
    {
      return format.Length == 0 ? Number.TryUInt64ToDecStr(value, -1, destination, out charsWritten) : TryFormatUInt64Slow(value, format, provider, destination, out charsWritten);

      static unsafe bool TryFormatUInt64Slow(
        ulong value,
        ReadOnlySpan<char> format,
        IFormatProvider provider,
        Span<char> destination,
        out int charsWritten)
      {
        int digits1;
        char formatSpecifier = Number.ParseFormatSpecifier(format, out digits1);
        char ch = (char) ((uint) formatSpecifier & 65503U);
        if ((ch == 'G' ? (digits1 < 1 ? 1 : 0) : (ch == 'D' ? 1 : 0)) != 0)
          return Number.TryUInt64ToDecStr(value, digits1, destination, out charsWritten);
        if (ch == 'X')
          return Number.TryInt64ToHexStr((long) value, Number.GetHexBase(formatSpecifier), digits1, destination, out charsWritten);
        NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
        byte* digits2 = stackalloc byte[21];
        Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Integer, digits2, 21);
        Number.UInt64ToNumber(value, ref number);
        char* chPtr = stackalloc char[32];
        ValueStringBuilder sb = new ValueStringBuilder(new Span<char>((void*) chPtr, 32));
        if (formatSpecifier != char.MinValue)
          Number.NumberToString(ref sb, ref number, formatSpecifier, digits1, instance);
        else
          Number.NumberToStringFormat(ref sb, ref number, format, instance);
        return sb.TryCopyTo(destination, out charsWritten);
      }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe void Int32ToNumber(int value, ref Number.NumberBuffer number)
    {
      number.DigitsCount = 10;
      if (value >= 0)
      {
        number.IsNegative = false;
      }
      else
      {
        number.IsNegative = true;
        value = -value;
      }
      byte* digitsPointer1 = number.GetDigitsPointer();
      byte* decChars = Number.UInt32ToDecChars(digitsPointer1 + 10, (uint) value, 0);
      int num = (int) (digitsPointer1 + 10 - decChars);
      number.DigitsCount = num;
      number.Scale = num;
      byte* digitsPointer2 = number.GetDigitsPointer();
      while (--num >= 0)
        *digitsPointer2++ = *decChars++;
      *digitsPointer2 = (byte) 0;
    }

    public static string Int32ToDecStr(int value) => value < 0 ? Number.NegativeInt32ToDecStr(value, -1, NumberFormatInfo.CurrentInfo.NegativeSign) : Number.UInt32ToDecStr((uint) value);

    private static unsafe string NegativeInt32ToDecStr(int value, int digits, string sNegative)
    {
      if (digits < 1)
        digits = 1;
      int length = Math.Max(digits, FormattingHelpers.CountDigits((uint) -value)) + sNegative.Length;
      string str = string.FastAllocateString(length);
      IntPtr num;
      if (str == null)
      {
        num = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &str.GetPinnableReference())
          num = (IntPtr) chPtr;
      }
      char* decChars = Number.UInt32ToDecChars((char*) (num + (IntPtr) length * 2), (uint) -value, digits);
      for (int index = sNegative.Length - 1; index >= 0; --index)
        *--decChars = sNegative[index];
      // ISSUE: fixed variable is out of scope
      // ISSUE: __unpin statement
      __unpin(chPtr);
      return str;
    }

    private static unsafe bool TryNegativeInt32ToDecStr(
      int value,
      int digits,
      string sNegative,
      Span<char> destination,
      out int charsWritten)
    {
      if (digits < 1)
        digits = 1;
      int num = Math.Max(digits, FormattingHelpers.CountDigits((uint) -value)) + sNegative.Length;
      if (num > destination.Length)
      {
        charsWritten = 0;
        return false;
      }
      charsWritten = num;
      fixed (char* chPtr = &MemoryMarshal.GetReference<char>(destination))
      {
        char* decChars = Number.UInt32ToDecChars(chPtr + num, (uint) -value, digits);
        for (int index = sNegative.Length - 1; index >= 0; --index)
          *--decChars = sNegative[index];
      }
      return true;
    }

    private static unsafe string Int32ToHexStr(int value, char hexBase, int digits)
    {
      if (digits < 1)
        digits = 1;
      int length = Math.Max(digits, FormattingHelpers.CountHexDigits((ulong) (uint) value));
      string str = string.FastAllocateString(length);
      IntPtr num;
      if (str == null)
      {
        num = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &str.GetPinnableReference())
          num = (IntPtr) chPtr;
      }
      Number.Int32ToHexChars((char*) (num + (IntPtr) length * 2), (uint) value, (int) hexBase, digits);
      // ISSUE: fixed variable is out of scope
      // ISSUE: __unpin statement
      __unpin(chPtr);
      return str;
    }

    private static unsafe bool TryInt32ToHexStr(
      int value,
      char hexBase,
      int digits,
      Span<char> destination,
      out int charsWritten)
    {
      if (digits < 1)
        digits = 1;
      int num = Math.Max(digits, FormattingHelpers.CountHexDigits((ulong) (uint) value));
      if (num > destination.Length)
      {
        charsWritten = 0;
        return false;
      }
      charsWritten = num;
      fixed (char* chPtr = &MemoryMarshal.GetReference<char>(destination))
        Number.Int32ToHexChars(chPtr + num, (uint) value, (int) hexBase, digits);
      return true;
    }

    private static unsafe char* Int32ToHexChars(char* buffer, uint value, int hexBase, int digits)
    {
      for (; --digits >= 0 || value != 0U; value >>= 4)
      {
        byte num = (byte) (value & 15U);
        *--buffer = (char) ((int) num + (num < (byte) 10 ? 48 : hexBase));
      }
      return buffer;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe void UInt32ToNumber(uint value, ref Number.NumberBuffer number)
    {
      number.DigitsCount = 10;
      number.IsNegative = false;
      byte* digitsPointer1 = number.GetDigitsPointer();
      byte* decChars = Number.UInt32ToDecChars(digitsPointer1 + 10, value, 0);
      int num = (int) (digitsPointer1 + 10 - decChars);
      number.DigitsCount = num;
      number.Scale = num;
      byte* digitsPointer2 = number.GetDigitsPointer();
      while (--num >= 0)
        *digitsPointer2++ = *decChars++;
      *digitsPointer2 = (byte) 0;
    }

    internal static unsafe byte* UInt32ToDecChars(byte* bufferEnd, uint value, int digits)
    {
      while (--digits >= 0 || value != 0U)
      {
        uint result;
        value = Math.DivRem(value, 10U, out result);
        *--bufferEnd = (byte) (result + 48U);
      }
      return bufferEnd;
    }

    internal static unsafe char* UInt32ToDecChars(char* bufferEnd, uint value, int digits)
    {
      while (--digits >= 0 || value != 0U)
      {
        uint result;
        value = Math.DivRem(value, 10U, out result);
        *--bufferEnd = (char) (result + 48U);
      }
      return bufferEnd;
    }

    internal static unsafe string UInt32ToDecStr(uint value)
    {
      int length = FormattingHelpers.CountDigits(value);
      if (length == 1)
        return Number.s_singleDigitStringCache[(int) value];
      string str = string.FastAllocateString(length);
      IntPtr num;
      if (str == null)
      {
        num = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &str.GetPinnableReference())
          num = (IntPtr) chPtr;
      }
      char* chPtr1 = (char*) (num + (IntPtr) length * 2);
      do
      {
        uint result;
        value = Math.DivRem(value, 10U, out result);
        *--chPtr1 = (char) (result + 48U);
      }
      while (value != 0U);
      // ISSUE: fixed variable is out of scope
      // ISSUE: __unpin statement
      __unpin(chPtr);
      return str;
    }

    private static unsafe string UInt32ToDecStr(uint value, int digits)
    {
      if (digits <= 1)
        return Number.UInt32ToDecStr(value);
      int length = Math.Max(digits, FormattingHelpers.CountDigits(value));
      string str = string.FastAllocateString(length);
      IntPtr num;
      if (str == null)
      {
        num = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &str.GetPinnableReference())
          num = (IntPtr) chPtr;
      }
      Number.UInt32ToDecChars((char*) (num + (IntPtr) length * 2), value, digits);
      // ISSUE: fixed variable is out of scope
      // ISSUE: __unpin statement
      __unpin(chPtr);
      return str;
    }

    private static unsafe bool TryUInt32ToDecStr(
      uint value,
      int digits,
      Span<char> destination,
      out int charsWritten)
    {
      int num = Math.Max(digits, FormattingHelpers.CountDigits(value));
      if (num > destination.Length)
      {
        charsWritten = 0;
        return false;
      }
      charsWritten = num;
      fixed (char* chPtr = &MemoryMarshal.GetReference<char>(destination))
      {
        char* bufferEnd = chPtr + num;
        if (digits <= 1)
        {
          do
          {
            uint result;
            value = Math.DivRem(value, 10U, out result);
            *--bufferEnd = (char) (result + 48U);
          }
          while (value != 0U);
        }
        else
          Number.UInt32ToDecChars(bufferEnd, value, digits);
      }
      return true;
    }

    private static unsafe void Int64ToNumber(long input, ref Number.NumberBuffer number)
    {
      ulong num1 = (ulong) input;
      number.IsNegative = input < 0L;
      number.DigitsCount = 19;
      if (number.IsNegative)
        num1 = (ulong) -input;
      byte* digitsPointer1 = number.GetDigitsPointer();
      byte* bufferEnd = digitsPointer1 + 19;
      while (Number.High32(num1) != 0U)
        bufferEnd = Number.UInt32ToDecChars(bufferEnd, Number.Int64DivMod1E9(ref num1), 9);
      byte* decChars = Number.UInt32ToDecChars(bufferEnd, Number.Low32(num1), 0);
      int num2 = (int) (digitsPointer1 + 19 - decChars);
      number.DigitsCount = num2;
      number.Scale = num2;
      byte* digitsPointer2 = number.GetDigitsPointer();
      while (--num2 >= 0)
        *digitsPointer2++ = *decChars++;
      *digitsPointer2 = (byte) 0;
    }

    public static string Int64ToDecStr(long value) => value < 0L ? Number.NegativeInt64ToDecStr(value, -1, NumberFormatInfo.CurrentInfo.NegativeSign) : Number.UInt64ToDecStr((ulong) value, -1);

    private static unsafe string NegativeInt64ToDecStr(long input, int digits, string sNegative)
    {
      if (digits < 1)
        digits = 1;
      ulong num1 = (ulong) -input;
      int length = Math.Max(digits, FormattingHelpers.CountDigits(num1)) + sNegative.Length;
      string str = string.FastAllocateString(length);
      IntPtr num2;
      if (str == null)
      {
        num2 = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &str.GetPinnableReference())
          num2 = (IntPtr) chPtr;
      }
      char* bufferEnd = (char*) (num2 + (IntPtr) length * 2);
      while (Number.High32(num1) != 0U)
      {
        bufferEnd = Number.UInt32ToDecChars(bufferEnd, Number.Int64DivMod1E9(ref num1), 9);
        digits -= 9;
      }
      char* decChars = Number.UInt32ToDecChars(bufferEnd, Number.Low32(num1), digits);
      for (int index = sNegative.Length - 1; index >= 0; --index)
        *--decChars = sNegative[index];
      // ISSUE: fixed variable is out of scope
      // ISSUE: __unpin statement
      __unpin(chPtr);
      return str;
    }

    private static unsafe bool TryNegativeInt64ToDecStr(
      long input,
      int digits,
      string sNegative,
      Span<char> destination,
      out int charsWritten)
    {
      if (digits < 1)
        digits = 1;
      ulong num1 = (ulong) -input;
      int num2 = Math.Max(digits, FormattingHelpers.CountDigits((ulong) -input)) + sNegative.Length;
      if (num2 > destination.Length)
      {
        charsWritten = 0;
        return false;
      }
      charsWritten = num2;
      fixed (char* chPtr = &MemoryMarshal.GetReference<char>(destination))
      {
        char* bufferEnd = chPtr + num2;
        while (Number.High32(num1) != 0U)
        {
          bufferEnd = Number.UInt32ToDecChars(bufferEnd, Number.Int64DivMod1E9(ref num1), 9);
          digits -= 9;
        }
        char* decChars = Number.UInt32ToDecChars(bufferEnd, Number.Low32(num1), digits);
        for (int index = sNegative.Length - 1; index >= 0; --index)
          *--decChars = sNegative[index];
      }
      return true;
    }

    private static unsafe string Int64ToHexStr(long value, char hexBase, int digits)
    {
      int length = Math.Max(digits, FormattingHelpers.CountHexDigits((ulong) value));
      string str = string.FastAllocateString(length);
      IntPtr num;
      if (str == null)
      {
        num = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &str.GetPinnableReference())
          num = (IntPtr) chPtr;
      }
      char* buffer = (char*) (num + (IntPtr) length * 2);
      char* chPtr1 = Number.High32((ulong) value) == 0U ? Number.Int32ToHexChars(buffer, Number.Low32((ulong) value), (int) hexBase, Math.Max(digits, 1)) : Number.Int32ToHexChars(Number.Int32ToHexChars(buffer, Number.Low32((ulong) value), (int) hexBase, 8), Number.High32((ulong) value), (int) hexBase, digits - 8);
      // ISSUE: fixed variable is out of scope
      // ISSUE: __unpin statement
      __unpin(chPtr);
      return str;
    }

    private static unsafe bool TryInt64ToHexStr(
      long value,
      char hexBase,
      int digits,
      Span<char> destination,
      out int charsWritten)
    {
      int num = Math.Max(digits, FormattingHelpers.CountHexDigits((ulong) value));
      if (num > destination.Length)
      {
        charsWritten = 0;
        return false;
      }
      charsWritten = num;
      fixed (char* chPtr1 = &MemoryMarshal.GetReference<char>(destination))
      {
        char* buffer = chPtr1 + num;
        char* chPtr2 = Number.High32((ulong) value) == 0U ? Number.Int32ToHexChars(buffer, Number.Low32((ulong) value), (int) hexBase, Math.Max(digits, 1)) : Number.Int32ToHexChars(Number.Int32ToHexChars(buffer, Number.Low32((ulong) value), (int) hexBase, 8), Number.High32((ulong) value), (int) hexBase, digits - 8);
      }
      return true;
    }

    private static unsafe void UInt64ToNumber(ulong value, ref Number.NumberBuffer number)
    {
      number.DigitsCount = 20;
      number.IsNegative = false;
      byte* digitsPointer1 = number.GetDigitsPointer();
      byte* bufferEnd = digitsPointer1 + 20;
      while (Number.High32(value) != 0U)
        bufferEnd = Number.UInt32ToDecChars(bufferEnd, Number.Int64DivMod1E9(ref value), 9);
      byte* decChars = Number.UInt32ToDecChars(bufferEnd, Number.Low32(value), 0);
      int num = (int) (digitsPointer1 + 20 - decChars);
      number.DigitsCount = num;
      number.Scale = num;
      byte* digitsPointer2 = number.GetDigitsPointer();
      while (--num >= 0)
        *digitsPointer2++ = *decChars++;
      *digitsPointer2 = (byte) 0;
    }

    internal static unsafe string UInt64ToDecStr(ulong value, int digits)
    {
      if (digits < 1)
        digits = 1;
      int length = Math.Max(digits, FormattingHelpers.CountDigits(value));
      if (length == 1)
        return Number.s_singleDigitStringCache[value];
      string str = string.FastAllocateString(length);
      IntPtr num;
      if (str == null)
      {
        num = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &str.GetPinnableReference())
          num = (IntPtr) chPtr;
      }
      char* bufferEnd = (char*) (num + (IntPtr) length * 2);
      while (Number.High32(value) != 0U)
      {
        bufferEnd = Number.UInt32ToDecChars(bufferEnd, Number.Int64DivMod1E9(ref value), 9);
        digits -= 9;
      }
      Number.UInt32ToDecChars(bufferEnd, Number.Low32(value), digits);
      // ISSUE: fixed variable is out of scope
      // ISSUE: __unpin statement
      __unpin(chPtr);
      return str;
    }

    private static unsafe bool TryUInt64ToDecStr(
      ulong value,
      int digits,
      Span<char> destination,
      out int charsWritten)
    {
      if (digits < 1)
        digits = 1;
      int num = Math.Max(digits, FormattingHelpers.CountDigits(value));
      if (num > destination.Length)
      {
        charsWritten = 0;
        return false;
      }
      charsWritten = num;
      fixed (char* chPtr = &MemoryMarshal.GetReference<char>(destination))
      {
        char* bufferEnd = chPtr + num;
        while (Number.High32(value) != 0U)
        {
          bufferEnd = Number.UInt32ToDecChars(bufferEnd, Number.Int64DivMod1E9(ref value), 9);
          digits -= 9;
        }
        Number.UInt32ToDecChars(bufferEnd, Number.Low32(value), digits);
      }
      return true;
    }

    internal static char ParseFormatSpecifier(ReadOnlySpan<char> format, out int digits)
    {
      char ch = char.MinValue;
      if (format.Length > 0)
      {
        ch = format[0];
        if ((uint) ch - 65U <= 25U || (uint) ch - 97U <= 25U)
        {
          if (format.Length == 1)
          {
            digits = -1;
            return ch;
          }
          if (format.Length == 2)
          {
            int num = (int) format[1] - 48;
            if ((uint) num < 10U)
            {
              digits = num;
              return ch;
            }
          }
          else if (format.Length == 3)
          {
            int num1 = (int) format[1] - 48;
            int num2 = (int) format[2] - 48;
            if ((uint) num1 < 10U && (uint) num2 < 10U)
            {
              digits = num1 * 10 + num2;
              return ch;
            }
          }
          int num3 = 0;
          int index = 1;
          while (index < format.Length && (uint) format[index] - 48U < 10U && num3 < 10)
            num3 = num3 * 10 + (int) format[index++] - 48;
          if (index == format.Length || format[index] == char.MinValue)
          {
            digits = num3;
            return ch;
          }
        }
      }
      digits = -1;
      return format.Length != 0 && ch != char.MinValue ? char.MinValue : 'G';
    }

    internal static void NumberToString(
      ref ValueStringBuilder sb,
      ref Number.NumberBuffer number,
      char format,
      int nMaxDigits,
      NumberFormatInfo info)
    {
      bool isCorrectlyRounded = number.Kind == Number.NumberBufferKind.FloatingPoint;
      switch (format)
      {
        case 'C':
        case 'c':
          if (nMaxDigits < 0)
            nMaxDigits = info.CurrencyDecimalDigits;
          Number.RoundNumber(ref number, number.Scale + nMaxDigits, isCorrectlyRounded);
          Number.FormatCurrency(ref sb, ref number, nMaxDigits, info);
          return;
        case 'E':
        case 'e':
          if (nMaxDigits < 0)
            nMaxDigits = 6;
          ++nMaxDigits;
          Number.RoundNumber(ref number, nMaxDigits, isCorrectlyRounded);
          if (number.IsNegative)
            sb.Append(info.NegativeSign);
          Number.FormatScientific(ref sb, ref number, nMaxDigits, info, format);
          return;
        case 'F':
        case 'f':
          if (nMaxDigits < 0)
            nMaxDigits = info.NumberDecimalDigits;
          Number.RoundNumber(ref number, number.Scale + nMaxDigits, isCorrectlyRounded);
          if (number.IsNegative)
            sb.Append(info.NegativeSign);
          Number.FormatFixed(ref sb, ref number, nMaxDigits, (int[]) null, info.NumberDecimalSeparator, (string) null);
          return;
        case 'G':
        case 'g':
          bool bSuppressScientific = false;
          if (nMaxDigits < 1)
          {
            if (number.Kind == Number.NumberBufferKind.Decimal && nMaxDigits == -1)
            {
              bSuppressScientific = true;
              if (number.Digits[0] != (byte) 0)
                goto label_22;
              else
                goto label_24;
            }
            else
              nMaxDigits = number.DigitsCount;
          }
          Number.RoundNumber(ref number, nMaxDigits, isCorrectlyRounded);
label_22:
          if (number.IsNegative)
            sb.Append(info.NegativeSign);
label_24:
          Number.FormatGeneral(ref sb, ref number, nMaxDigits, info, (char) ((uint) format - 2U), bSuppressScientific);
          return;
        case 'N':
        case 'n':
          if (nMaxDigits < 0)
            nMaxDigits = info.NumberDecimalDigits;
          Number.RoundNumber(ref number, number.Scale + nMaxDigits, isCorrectlyRounded);
          Number.FormatNumber(ref sb, ref number, nMaxDigits, info);
          return;
        case 'P':
        case 'p':
          if (nMaxDigits < 0)
            nMaxDigits = info.PercentDecimalDigits;
          number.Scale += 2;
          Number.RoundNumber(ref number, number.Scale + nMaxDigits, isCorrectlyRounded);
          Number.FormatPercent(ref sb, ref number, nMaxDigits, info);
          return;
        case 'R':
        case 'r':
          if (number.Kind == Number.NumberBufferKind.FloatingPoint)
          {
            format -= '\v';
            goto case 'G';
          }
          else
            break;
      }
      throw new FormatException(SR.Argument_BadFormatSpecifier);
    }

    internal static unsafe void NumberToStringFormat(
      ref ValueStringBuilder sb,
      ref Number.NumberBuffer number,
      ReadOnlySpan<char> format,
      NumberFormatInfo info)
    {
      int num1 = 0;
      byte* digitsPointer = number.GetDigitsPointer();
      int num2 = Number.FindSection(format, *digitsPointer == (byte) 0 ? 2 : (number.IsNegative ? 1 : 0));
      int num3;
      int num4;
      int num5;
      int num6;
      bool flag1;
      bool flag2;
      while (true)
      {
        num3 = 0;
        num4 = -1;
        num5 = int.MaxValue;
        num6 = 0;
        flag1 = false;
        int num7 = -1;
        flag2 = false;
        int num8 = 0;
        int index = num2;
        fixed (char* chPtr1 = &MemoryMarshal.GetReference<char>(format))
        {
          while (index < format.Length)
          {
            char* chPtr2 = chPtr1;
            IntPtr num9 = (IntPtr) index++ * 2;
            char ch;
            if ((ch = (char) *(ushort*) ((IntPtr) chPtr2 + num9)) != char.MinValue)
            {
              switch (ch)
              {
                case '"':
                case '\'':
                  do
                    ;
                  while (index < format.Length && chPtr1[index] != char.MinValue && (int) chPtr1[index++] != (int) ch);
                  continue;
                case '#':
                  ++num3;
                  continue;
                case '%':
                  num8 += 2;
                  continue;
                case ',':
                  if (num3 > 0 && num4 < 0)
                  {
                    if (num7 >= 0)
                    {
                      if (num7 == num3)
                      {
                        ++num1;
                        continue;
                      }
                      flag2 = true;
                    }
                    num7 = num3;
                    num1 = 1;
                    continue;
                  }
                  continue;
                case '.':
                  if (num4 < 0)
                  {
                    num4 = num3;
                    continue;
                  }
                  continue;
                case '0':
                  if (num5 == int.MaxValue)
                    num5 = num3;
                  ++num3;
                  num6 = num3;
                  continue;
                case ';':
                  goto label_25;
                case 'E':
                case 'e':
                  if (index < format.Length && chPtr1[index] == '0' || index + 1 < format.Length && (chPtr1[index] == '+' || chPtr1[index] == '-') && chPtr1[index + 1] == '0')
                  {
                    do
                      ;
                    while (++index < format.Length && chPtr1[index] == '0');
                    flag1 = true;
                    continue;
                  }
                  continue;
                case '\\':
                  if (index < format.Length && chPtr1[index] != char.MinValue)
                  {
                    ++index;
                    continue;
                  }
                  continue;
                case '‰':
                  num8 += 3;
                  continue;
                default:
                  continue;
              }
            }
            else
              break;
          }
label_25:;
        }
        if (num4 < 0)
          num4 = num3;
        if (num7 >= 0)
        {
          if (num7 == num4)
            num8 -= num1 * 3;
          else
            flag2 = true;
        }
        if (*digitsPointer != (byte) 0)
        {
          number.Scale += num8;
          int pos = flag1 ? num3 : number.Scale + num3 - num4;
          Number.RoundNumber(ref number, pos, false);
          if (*digitsPointer == (byte) 0)
          {
            int section = Number.FindSection(format, 2);
            if (section != num2)
              num2 = section;
            else
              goto label_38;
          }
          else
            goto label_38;
        }
        else
          break;
      }
      if (number.Kind != Number.NumberBufferKind.FloatingPoint)
        number.IsNegative = false;
      number.Scale = 0;
label_38:
      int num10 = num5 < num4 ? num4 - num5 : 0;
      int num11 = num6 > num4 ? num4 - num6 : 0;
      int num12;
      int num13;
      if (flag1)
      {
        num12 = num4;
        num13 = 0;
      }
      else
      {
        num12 = number.Scale > num4 ? number.Scale : num4;
        num13 = number.Scale - num4;
      }
      int index1 = num2;
      // ISSUE: untyped stack allocation
      Span<int> span = new Span<int>((void*) __untypedstackalloc(new IntPtr(16)), 4);
      int index2 = -1;
      if (flag2 && info.NumberGroupSeparator.Length > 0)
      {
        int[] numberGroupSizes = info._numberGroupSizes;
        int index3 = 0;
        int num7 = 0;
        int length = numberGroupSizes.Length;
        if (length != 0)
          num7 = numberGroupSizes[index3];
        int num8 = num7;
        int num9 = num12 + (num13 < 0 ? num13 : 0);
        for (int index4 = num10 > num9 ? num10 : num9; index4 > num7 && num8 != 0; num7 += num8)
        {
          ++index2;
          if (index2 >= span.Length)
          {
            int[] numArray = new int[span.Length * 2];
            span.CopyTo((Span<int>) numArray);
            span = (Span<int>) numArray;
          }
          span[index2] = num7;
          if (index3 < length - 1)
          {
            ++index3;
            num8 = numberGroupSizes[index3];
          }
        }
      }
      if (number.IsNegative && num2 == 0 && number.Scale != 0)
        sb.Append(info.NegativeSign);
      bool flag3 = false;
      fixed (char* chPtr1 = &MemoryMarshal.GetReference<char>(format))
      {
        byte* numPtr = digitsPointer;
label_96:
        while (index1 < format.Length)
        {
          char* chPtr2 = chPtr1;
          IntPtr num7 = (IntPtr) index1++ * 2;
          char ch;
          if ((ch = (char) *(ushort*) ((IntPtr) chPtr2 + num7)) != char.MinValue && ch != ';')
          {
            if (num13 > 0 && (ch == '#' || ch == '.' || ch == '0'))
            {
              for (; num13 > 0; --num13)
              {
                sb.Append(*numPtr != (byte) 0 ? (char) *numPtr++ : '0');
                if (flag2 && num12 > 1 && (index2 >= 0 && num12 == span[index2] + 1))
                {
                  sb.Append(info.NumberGroupSeparator);
                  --index2;
                }
                --num12;
              }
            }
            switch (ch)
            {
              case '"':
              case '\'':
                while (index1 < format.Length && chPtr1[index1] != char.MinValue && (int) chPtr1[index1] != (int) ch)
                  sb.Append(chPtr1[index1++]);
                if (index1 < format.Length && chPtr1[index1] != char.MinValue)
                {
                  ++index1;
                  continue;
                }
                continue;
              case '#':
              case '0':
                char c;
                if (num13 < 0)
                {
                  ++num13;
                  c = num12 <= num10 ? '0' : char.MinValue;
                }
                else
                  c = *numPtr != (byte) 0 ? (char) *numPtr++ : (num12 > num11 ? '0' : char.MinValue);
                if (c != char.MinValue)
                {
                  sb.Append(c);
                  if (flag2 && num12 > 1 && (index2 >= 0 && num12 == span[index2] + 1))
                  {
                    sb.Append(info.NumberGroupSeparator);
                    --index2;
                  }
                }
                --num12;
                continue;
              case '%':
                sb.Append(info.PercentSymbol);
                continue;
              case ',':
                continue;
              case '.':
                if (!((uint) num12 > 0U | flag3) && (num11 < 0 || num4 < num3 && *numPtr != (byte) 0))
                {
                  sb.Append(info.NumberDecimalSeparator);
                  flag3 = true;
                  continue;
                }
                continue;
              case 'E':
              case 'e':
                bool positiveSign = false;
                int minDigits = 0;
                if (flag1)
                {
                  if (index1 < format.Length && chPtr1[index1] == '0')
                    ++minDigits;
                  else if (index1 + 1 < format.Length && chPtr1[index1] == '+' && chPtr1[index1 + 1] == '0')
                    positiveSign = true;
                  else if (index1 + 1 >= format.Length || chPtr1[index1] != '-' || chPtr1[index1 + 1] != '0')
                  {
                    sb.Append(ch);
                    continue;
                  }
                  while (++index1 < format.Length && chPtr1[index1] == '0')
                    ++minDigits;
                  if (minDigits > 10)
                    minDigits = 10;
                  int num8 = *digitsPointer == (byte) 0 ? 0 : number.Scale - num4;
                  Number.FormatExponent(ref sb, info, num8, ch, minDigits, positiveSign);
                  flag1 = false;
                  continue;
                }
                sb.Append(ch);
                if (index1 < format.Length)
                {
                  if (chPtr1[index1] == '+' || chPtr1[index1] == '-')
                    sb.Append(chPtr1[index1++]);
                  while (true)
                  {
                    if (index1 < format.Length && chPtr1[index1] == '0')
                      sb.Append(chPtr1[index1++]);
                    else
                      goto label_96;
                  }
                }
                else
                  continue;
              case '\\':
                if (index1 < format.Length && chPtr1[index1] != char.MinValue)
                {
                  sb.Append(chPtr1[index1++]);
                  continue;
                }
                continue;
              case '‰':
                sb.Append(info.PerMilleSymbol);
                continue;
              default:
                sb.Append(ch);
                continue;
            }
          }
          else
            break;
        }
      }
      if (!number.IsNegative || num2 != 0 || (number.Scale != 0 || sb.Length <= 0))
        return;
      sb.Insert(0, info.NegativeSign);
    }

    private static void FormatCurrency(
      ref ValueStringBuilder sb,
      ref Number.NumberBuffer number,
      int nMaxDigits,
      NumberFormatInfo info)
    {
      foreach (char c in number.IsNegative ? Number.s_negCurrencyFormats[info.CurrencyNegativePattern] : Number.s_posCurrencyFormats[info.CurrencyPositivePattern])
      {
        switch (c)
        {
          case '#':
            Number.FormatFixed(ref sb, ref number, nMaxDigits, info._currencyGroupSizes, info.CurrencyDecimalSeparator, info.CurrencyGroupSeparator);
            break;
          case '$':
            sb.Append(info.CurrencySymbol);
            break;
          case '-':
            sb.Append(info.NegativeSign);
            break;
          default:
            sb.Append(c);
            break;
        }
      }
    }

    private static unsafe void FormatFixed(
      ref ValueStringBuilder sb,
      ref Number.NumberBuffer number,
      int nMaxDigits,
      int[] groupDigits,
      string sDecimal,
      string sGroup)
    {
      int scale = number.Scale;
      byte* digitsPointer = number.GetDigitsPointer();
      if (scale > 0)
      {
        if (groupDigits != null)
        {
          int index1 = 0;
          int length = scale;
          int num1 = 0;
          if (groupDigits.Length != 0)
          {
            int groupDigit = groupDigits[index1];
            while (scale > groupDigit && groupDigits[index1] != 0)
            {
              length += sGroup.Length;
              if (index1 < groupDigits.Length - 1)
                ++index1;
              groupDigit += groupDigits[index1];
              if (groupDigit < 0 || length < 0)
                throw new ArgumentOutOfRangeException();
            }
            num1 = groupDigit == 0 ? 0 : groupDigits[0];
          }
          int index2 = 0;
          int num2 = 0;
          int digitsCount = number.DigitsCount;
          int num3 = scale < digitsCount ? scale : digitsCount;
          fixed (char* chPtr1 = &MemoryMarshal.GetReference<char>(sb.AppendSpan(length)))
          {
            char* chPtr2 = chPtr1 + length - 1;
            for (int index3 = scale - 1; index3 >= 0; --index3)
            {
              *chPtr2-- = index3 < num3 ? (char) digitsPointer[index3] : '0';
              if (num1 > 0)
              {
                ++num2;
                if (num2 == num1 && index3 != 0)
                {
                  for (int index4 = sGroup.Length - 1; index4 >= 0; --index4)
                    *chPtr2-- = sGroup[index4];
                  if (index2 < groupDigits.Length - 1)
                  {
                    ++index2;
                    num1 = groupDigits[index2];
                  }
                  num2 = 0;
                }
              }
            }
            digitsPointer += num3;
          }
        }
        else
        {
          do
          {
            sb.Append(*digitsPointer != (byte) 0 ? (char) *digitsPointer++ : '0');
          }
          while (--scale > 0);
        }
      }
      else
        sb.Append('0');
      if (nMaxDigits <= 0)
        return;
      sb.Append(sDecimal);
      if (scale < 0 && nMaxDigits > 0)
      {
        int count = Math.Min(-scale, nMaxDigits);
        sb.Append('0', count);
        int num = scale + count;
        nMaxDigits -= count;
      }
      for (; nMaxDigits > 0; --nMaxDigits)
        sb.Append(*digitsPointer != (byte) 0 ? (char) *digitsPointer++ : '0');
    }

    private static void FormatNumber(
      ref ValueStringBuilder sb,
      ref Number.NumberBuffer number,
      int nMaxDigits,
      NumberFormatInfo info)
    {
      foreach (char c in number.IsNegative ? Number.s_negNumberFormats[info.NumberNegativePattern] : "#")
      {
        switch (c)
        {
          case '#':
            Number.FormatFixed(ref sb, ref number, nMaxDigits, info._numberGroupSizes, info.NumberDecimalSeparator, info.NumberGroupSeparator);
            break;
          case '-':
            sb.Append(info.NegativeSign);
            break;
          default:
            sb.Append(c);
            break;
        }
      }
    }

    private static unsafe void FormatScientific(
      ref ValueStringBuilder sb,
      ref Number.NumberBuffer number,
      int nMaxDigits,
      NumberFormatInfo info,
      char expChar)
    {
      byte* digitsPointer = number.GetDigitsPointer();
      sb.Append(*digitsPointer != (byte) 0 ? (char) *digitsPointer++ : '0');
      if (nMaxDigits != 1)
        sb.Append(info.NumberDecimalSeparator);
      while (--nMaxDigits > 0)
        sb.Append(*digitsPointer != (byte) 0 ? (char) *digitsPointer++ : '0');
      int num = number.Digits[0] == (byte) 0 ? 0 : number.Scale - 1;
      Number.FormatExponent(ref sb, info, num, expChar, 3, true);
    }

    private static unsafe void FormatExponent(
      ref ValueStringBuilder sb,
      NumberFormatInfo info,
      int value,
      char expChar,
      int minDigits,
      bool positiveSign)
    {
      sb.Append(expChar);
      if (value < 0)
      {
        sb.Append(info.NegativeSign);
        value = -value;
      }
      else if (positiveSign)
        sb.Append(info.PositiveSign);
      char* chPtr = stackalloc char[10];
      char* decChars = Number.UInt32ToDecChars(chPtr + 10, (uint) value, minDigits);
      sb.Append(decChars, (int) (chPtr + 10 - decChars));
    }

    private static unsafe void FormatGeneral(
      ref ValueStringBuilder sb,
      ref Number.NumberBuffer number,
      int nMaxDigits,
      NumberFormatInfo info,
      char expChar,
      bool bSuppressScientific)
    {
      int num = number.Scale;
      bool flag = false;
      if (!bSuppressScientific && (num > nMaxDigits || num < -3))
      {
        num = 1;
        flag = true;
      }
      byte* digitsPointer = number.GetDigitsPointer();
      if (num > 0)
      {
        do
        {
          sb.Append(*digitsPointer != (byte) 0 ? (char) *digitsPointer++ : '0');
        }
        while (--num > 0);
      }
      else
        sb.Append('0');
      if (*digitsPointer != (byte) 0 || num < 0)
      {
        sb.Append(info.NumberDecimalSeparator);
        for (; num < 0; ++num)
          sb.Append('0');
        while (*digitsPointer != (byte) 0)
          sb.Append((char) *digitsPointer++);
      }
      if (!flag)
        return;
      Number.FormatExponent(ref sb, info, number.Scale - 1, expChar, 2, true);
    }

    private static void FormatPercent(
      ref ValueStringBuilder sb,
      ref Number.NumberBuffer number,
      int nMaxDigits,
      NumberFormatInfo info)
    {
      foreach (char c in number.IsNegative ? Number.s_negPercentFormats[info.PercentNegativePattern] : Number.s_posPercentFormats[info.PercentPositivePattern])
      {
        switch (c)
        {
          case '#':
            Number.FormatFixed(ref sb, ref number, nMaxDigits, info._percentGroupSizes, info.PercentDecimalSeparator, info.PercentGroupSeparator);
            break;
          case '%':
            sb.Append(info.PercentSymbol);
            break;
          case '-':
            sb.Append(info.NegativeSign);
            break;
          default:
            sb.Append(c);
            break;
        }
      }
    }

    internal static unsafe void RoundNumber(
      ref Number.NumberBuffer number,
      int pos,
      bool isCorrectlyRounded)
    {
      byte* digitsPointer = number.GetDigitsPointer();
      int i = 0;
      while (i < pos && digitsPointer[i] != (byte) 0)
        ++i;
      if (i == pos && ShouldRoundUp(digitsPointer, i, number.Kind, isCorrectlyRounded))
      {
        while (i > 0 && digitsPointer[i - 1] == (byte) 57)
          --i;
        if (i > 0)
        {
          byte* numPtr = digitsPointer + (i - 1);
          *numPtr = (byte) ((uint) *numPtr + 1U);
        }
        else
        {
          ++number.Scale;
          *digitsPointer = (byte) 49;
          i = 1;
        }
      }
      else
      {
        while (i > 0 && digitsPointer[i - 1] == (byte) 48)
          --i;
      }
      if (i == 0)
      {
        if (number.Kind != Number.NumberBufferKind.FloatingPoint)
          number.IsNegative = false;
        number.Scale = 0;
      }
      digitsPointer[i] = (byte) 0;
      number.DigitsCount = i;

      static unsafe bool ShouldRoundUp(
        byte* dig,
        int i,
        Number.NumberBufferKind numberKind,
        bool isCorrectlyRounded)
      {
        byte num = dig[i];
        return !(num == (byte) 0 | isCorrectlyRounded) && num >= (byte) 53;
      }
    }

    private static unsafe int FindSection(ReadOnlySpan<char> format, int section)
    {
      if (section == 0)
        return 0;
      fixed (char* chPtr1 = &MemoryMarshal.GetReference<char>(format))
      {
        int index = 0;
        while (index < format.Length)
        {
          char* chPtr2 = chPtr1;
          IntPtr num = (IntPtr) index++ * 2;
          char ch;
          switch (ch = (char) *(ushort*) ((IntPtr) chPtr2 + num))
          {
            case char.MinValue:
              return 0;
            case '"':
            case '\'':
              do
                ;
              while (index < format.Length && chPtr1[index] != char.MinValue && (int) chPtr1[index++] != (int) ch);
              continue;
            case ';':
              if (--section == 0)
              {
                if (index < format.Length && chPtr1[index] != char.MinValue && chPtr1[index] != ';')
                  return index;
                goto case char.MinValue;
              }
              else
                continue;
            case '\\':
              if (index < format.Length && chPtr1[index] != char.MinValue)
              {
                ++index;
                continue;
              }
              continue;
            default:
              continue;
          }
        }
        return 0;
      }
    }

    private static uint Low32(ulong value) => (uint) value;

    private static uint High32(ulong value) => (uint) ((value & 18446744069414584320UL) >> 32);

    private static uint Int64DivMod1E9(ref ulong value)
    {
      uint num = (uint) (value % 1000000000UL);
      value /= 1000000000UL;
      return num;
    }

    private static ulong ExtractFractionAndBiasedExponent(double value, out int exponent)
    {
      ulong int64Bits = (ulong) BitConverter.DoubleToInt64Bits(value);
      ulong num = int64Bits & 4503599627370495UL;
      exponent = (int) (int64Bits >> 52) & 2047;
      if (exponent != 0)
      {
        num |= 4503599627370496UL;
        exponent -= 1075;
      }
      else
        exponent = -1074;
      return num;
    }

    private static ushort ExtractFractionAndBiasedExponent(Half value, out int exponent)
    {
      ushort int16Bits = (ushort) BitConverter.HalfToInt16Bits(value);
      ushort num = (ushort) ((uint) int16Bits & 1023U);
      exponent = (int) int16Bits >> 10 & 31;
      if (exponent != 0)
      {
        num |= (ushort) 1024;
        exponent -= 25;
      }
      else
        exponent = -24;
      return num;
    }

    private static uint ExtractFractionAndBiasedExponent(float value, out int exponent)
    {
      uint int32Bits = (uint) BitConverter.SingleToInt32Bits(value);
      uint num = int32Bits & 8388607U;
      exponent = (int) (int32Bits >> 23) & (int) byte.MaxValue;
      if (exponent != 0)
      {
        num |= 8388608U;
        exponent -= 150;
      }
      else
        exponent = -149;
      return num;
    }

    private static unsafe void AccumulateDecimalDigitsIntoBigInteger(
      ref Number.NumberBuffer number,
      uint firstIndex,
      uint lastIndex,
      out Number.BigInteger result)
    {
      Number.BigInteger.SetZero(out result);
      byte* p = number.GetDigitsPointer() + firstIndex;
      uint exponent;
      for (uint val1 = lastIndex - firstIndex; val1 != 0U; val1 -= exponent)
      {
        exponent = Math.Min(val1, 9U);
        uint uint32 = Number.DigitsToUInt32(p, (int) exponent);
        result.MultiplyPow10(exponent);
        result.Add(uint32);
        p += exponent;
      }
    }

    private static ulong AssembleFloatingPointBits(
      in Number.FloatingPointInfo info,
      ulong initialMantissa,
      int initialExponent,
      bool hasZeroTail)
    {
      uint num1 = Number.BigInteger.CountSignificantBits(initialMantissa);
      int num2 = (int) info.NormalMantissaBits - (int) num1;
      int num3 = initialExponent - num2;
      ulong num4 = initialMantissa;
      int num5 = num3;
      if (num3 > info.MaxBinaryExponent)
        return info.InfinityBits;
      if (num3 < info.MinBinaryExponent)
      {
        int num6 = num2 + num3 + info.ExponentBias - 1;
        num5 = -info.ExponentBias;
        if (num6 < 0)
        {
          num4 = Number.RightShiftWithRounding(num4, -num6, hasZeroTail);
          if (num4 == 0UL)
            return info.ZeroBits;
          if (num4 > info.DenormalMantissaMask)
            num5 = initialExponent - (num6 + 1) - num2;
        }
        else
          num4 <<= num6;
      }
      else if (num2 < 0)
      {
        num4 = Number.RightShiftWithRounding(num4, -num2, hasZeroTail);
        if (num4 > info.NormalMantissaMask)
        {
          num4 >>= 1;
          ++num5;
          if (num5 > info.MaxBinaryExponent)
            return info.InfinityBits;
        }
      }
      else if (num2 > 0)
        num4 <<= num2;
      ulong num7 = num4 & info.DenormalMantissaMask;
      return (ulong) (num5 + info.ExponentBias) << (int) info.DenormalMantissaBits | num7;
    }

    private static ulong ConvertBigIntegerToFloatingPointBits(
      ref Number.BigInteger value,
      in Number.FloatingPointInfo info,
      uint integerBitsOfPrecision,
      bool hasNonZeroFractionalPart)
    {
      int denormalMantissaBits = (int) info.DenormalMantissaBits;
      if (integerBitsOfPrecision <= 64U)
        return Number.AssembleFloatingPointBits(in info, value.ToUInt64(), denormalMantissaBits, !hasNonZeroFractionalPart);
      uint result;
      uint index1 = Math.DivRem(integerBitsOfPrecision, 32U, out result);
      uint index2 = index1 - 1U;
      uint index3 = index2 - 1U;
      int initialExponent = denormalMantissaBits + (int) index3 * 32;
      bool hasZeroTail = !hasNonZeroFractionalPart;
      ulong initialMantissa;
      if (result == 0U)
      {
        initialMantissa = ((ulong) value.GetBlock(index2) << 32) + (ulong) value.GetBlock(index3);
      }
      else
      {
        int num1 = (int) result;
        int num2 = 64 - num1;
        int num3 = num2 - 32;
        initialExponent += (int) result;
        uint block = value.GetBlock(index3);
        uint num4 = block >> num1;
        ulong num5 = (ulong) value.GetBlock(index2) << num3;
        initialMantissa = ((ulong) value.GetBlock(index1) << num2) + num5 + (ulong) num4;
        uint num6 = (uint) ((1 << (int) result) - 1);
        hasZeroTail &= ((int) block & (int) num6) == 0;
      }
      for (uint index4 = 0; (int) index4 != (int) index3; ++index4)
        hasZeroTail &= value.GetBlock(index4) == 0U;
      return Number.AssembleFloatingPointBits(in info, initialMantissa, initialExponent, hasZeroTail);
    }

    private static unsafe uint DigitsToUInt32(byte* p, int count)
    {
      byte* numPtr = p + count;
      uint num = (uint) *p - 48U;
      for (++p; p < numPtr; ++p)
        num = (uint) (10 * (int) num + (int) *p - 48);
      return num;
    }

    private static unsafe ulong DigitsToUInt64(byte* p, int count)
    {
      byte* numPtr = p + count;
      ulong num = (ulong) ((int) *p - 48);
      for (++p; p < numPtr; ++p)
        num = 10UL * num + (ulong) *p - 48UL;
      return num;
    }

    private static unsafe ulong NumberToFloatingPointBits(
      ref Number.NumberBuffer number,
      in Number.FloatingPointInfo info)
    {
      uint digitsCount = (uint) number.DigitsCount;
      uint num1 = (uint) Math.Max(0, number.Scale);
      uint integerDigitsPresent = Math.Min(num1, digitsCount);
      uint fractionalDigitsPresent = digitsCount - integerDigitsPresent;
      uint num2 = (uint) Math.Abs((long) number.Scale - (long) integerDigitsPresent - (long) fractionalDigitsPresent);
      byte* digitsPointer = number.GetDigitsPointer();
      if (info.DenormalMantissaBits <= (ushort) 23 && digitsCount <= 7U && num2 <= 10U)
      {
        float uint32 = (float) Number.DigitsToUInt32(digitsPointer, (int) digitsCount);
        float num3 = Number.s_Pow10SingleTable[(int) num2];
        float num4 = fractionalDigitsPresent == 0U ? uint32 * num3 : uint32 / num3;
        return info.DenormalMantissaBits == (ushort) 10 ? (ulong) (ushort) BitConverter.HalfToInt16Bits((Half) num4) : (ulong) (uint) BitConverter.SingleToInt32Bits(num4);
      }
      if (digitsCount > 15U || num2 > 22U)
        return Number.NumberToFloatingPointBitsSlow(ref number, in info, num1, integerDigitsPresent, fractionalDigitsPresent);
      double uint64 = (double) Number.DigitsToUInt64(digitsPointer, (int) digitsCount);
      double num5 = Number.s_Pow10DoubleTable[(int) num2];
      double num6 = fractionalDigitsPresent == 0U ? uint64 * num5 : uint64 / num5;
      if (info.DenormalMantissaBits == (ushort) 52)
        return (ulong) BitConverter.DoubleToInt64Bits(num6);
      return info.DenormalMantissaBits == (ushort) 23 ? (ulong) (uint) BitConverter.SingleToInt32Bits((float) num6) : (ulong) (uint) BitConverter.HalfToInt16Bits((Half) num6);
    }

    private static ulong NumberToFloatingPointBitsSlow(
      ref Number.NumberBuffer number,
      in Number.FloatingPointInfo info,
      uint positiveExponent,
      uint integerDigitsPresent,
      uint fractionalDigitsPresent)
    {
      uint num1 = (uint) info.NormalMantissaBits + 1U;
      uint digitsCount = (uint) number.DigitsCount;
      uint exponent1 = positiveExponent - integerDigitsPresent;
      uint lastIndex1 = integerDigitsPresent;
      uint firstIndex = lastIndex1;
      uint lastIndex2 = digitsCount;
      Number.BigInteger result1;
      Number.AccumulateDecimalDigitsIntoBigInteger(ref number, 0U, lastIndex1, out result1);
      if (exponent1 > 0U)
      {
        if ((long) exponent1 > (long) info.OverflowDecimalExponent)
          return info.InfinityBits;
        result1.MultiplyPow10(exponent1);
      }
      uint integerBitsOfPrecision = Number.BigInteger.CountSignificantBits(ref result1);
      if (integerBitsOfPrecision >= num1 || fractionalDigitsPresent == 0U)
        return Number.ConvertBigIntegerToFloatingPointBits(ref result1, in info, integerBitsOfPrecision, fractionalDigitsPresent > 0U);
      uint exponent2 = fractionalDigitsPresent;
      if (number.Scale < 0)
        exponent2 += (uint) -number.Scale;
      if (integerBitsOfPrecision == 0U && (long) exponent2 - (long) (int) digitsCount > (long) info.OverflowDecimalExponent)
        return info.ZeroBits;
      Number.BigInteger result2;
      Number.AccumulateDecimalDigitsIntoBigInteger(ref number, firstIndex, lastIndex2, out result2);
      if (result2.IsZero())
        return Number.ConvertBigIntegerToFloatingPointBits(ref result1, in info, integerBitsOfPrecision, fractionalDigitsPresent > 0U);
      Number.BigInteger result3;
      Number.BigInteger.Pow10(exponent2, out result3);
      uint num2 = Number.BigInteger.CountSignificantBits(ref result2);
      uint num3 = Number.BigInteger.CountSignificantBits(ref result3);
      uint shift1 = 0;
      if (num3 > num2)
        shift1 = num3 - num2;
      if (shift1 > 0U)
        result2.ShiftLeft(shift1);
      uint num4 = num1 - integerBitsOfPrecision;
      uint shift2 = num4;
      if (integerBitsOfPrecision > 0U)
      {
        if (shift1 > shift2)
          return Number.ConvertBigIntegerToFloatingPointBits(ref result1, in info, integerBitsOfPrecision, fractionalDigitsPresent > 0U);
        shift2 -= shift1;
      }
      uint num5 = shift1;
      if (Number.BigInteger.Compare(ref result2, ref result3) < 0)
        ++num5;
      result2.ShiftLeft(shift2);
      Number.BigInteger quo;
      Number.BigInteger rem;
      Number.BigInteger.DivRem(ref result2, ref result3, out quo, out rem);
      ulong uint64 = quo.ToUInt64();
      bool hasZeroTail = !number.HasNonZeroTail && rem.IsZero();
      uint num6 = Number.BigInteger.CountSignificantBits(uint64);
      if (num6 > num4)
      {
        int num7 = (int) num6 - (int) num4;
        hasZeroTail = hasZeroTail && ((long) uint64 & (1L << num7) - 1L) == 0L;
        uint64 >>= num7;
      }
      ulong initialMantissa = (result1.ToUInt64() << (int) num4) + uint64;
      int initialExponent = integerBitsOfPrecision > 0U ? (int) integerBitsOfPrecision - 2 : -(int) num5 - 1;
      return Number.AssembleFloatingPointBits(in info, initialMantissa, initialExponent, hasZeroTail);
    }

    private static ulong RightShiftWithRounding(ulong value, int shift, bool hasZeroTail)
    {
      if (shift >= 64)
        return 0;
      ulong num1 = (ulong) (1L << shift - 1) - 1UL;
      ulong num2 = 1UL << shift - 1;
      ulong num3 = 1UL << shift;
      bool lsbBit = (value & num3) > 0UL;
      bool roundBit = (value & num2) > 0UL;
      bool hasTailBits = !hasZeroTail || (value & num1) > 0UL;
      return (value >> shift) + (Number.ShouldRoundUp(lsbBit, roundBit, hasTailBits) ? 1UL : 0UL);
    }

    private static bool ShouldRoundUp(bool lsbBit, bool roundBit, bool hasTailBits) => roundBit && hasTailBits | lsbBit;

    private static unsafe bool TryNumberToInt32(ref Number.NumberBuffer number, ref int value)
    {
      int scale = number.Scale;
      if (scale > 10 || scale < number.DigitsCount)
        return false;
      byte* digitsPointer = number.GetDigitsPointer();
      int num = 0;
      while (--scale >= 0)
      {
        if ((uint) num > 214748364U)
          return false;
        num *= 10;
        if (*digitsPointer != (byte) 0)
          num += (int) *digitsPointer++ - 48;
      }
      if (number.IsNegative)
      {
        num = -num;
        if (num > 0)
          return false;
      }
      else if (num < 0)
        return false;
      value = num;
      return true;
    }

    private static unsafe bool TryNumberToInt64(ref Number.NumberBuffer number, ref long value)
    {
      int scale = number.Scale;
      if (scale > 19 || scale < number.DigitsCount)
        return false;
      byte* digitsPointer = number.GetDigitsPointer();
      long num = 0;
      while (--scale >= 0)
      {
        if ((ulong) num > 922337203685477580UL)
          return false;
        num *= 10L;
        if (*digitsPointer != (byte) 0)
          num += (long) ((int) *digitsPointer++ - 48);
      }
      if (number.IsNegative)
      {
        num = -num;
        if (num > 0L)
          return false;
      }
      else if (num < 0L)
        return false;
      value = num;
      return true;
    }

    private static unsafe bool TryNumberToUInt32(ref Number.NumberBuffer number, ref uint value)
    {
      int scale = number.Scale;
      if (scale > 10 || scale < number.DigitsCount || number.IsNegative)
        return false;
      byte* digitsPointer = number.GetDigitsPointer();
      uint num1 = 0;
      while (--scale >= 0)
      {
        if (num1 > 429496729U)
          return false;
        num1 *= 10U;
        if (*digitsPointer != (byte) 0)
        {
          uint num2 = num1 + ((uint) *digitsPointer++ - 48U);
          if (num2 < num1)
            return false;
          num1 = num2;
        }
      }
      value = num1;
      return true;
    }

    private static unsafe bool TryNumberToUInt64(ref Number.NumberBuffer number, ref ulong value)
    {
      int scale = number.Scale;
      if (scale > 20 || scale < number.DigitsCount || number.IsNegative)
        return false;
      byte* digitsPointer = number.GetDigitsPointer();
      ulong num1 = 0;
      while (--scale >= 0)
      {
        if (num1 > 1844674407370955161UL)
          return false;
        num1 *= 10UL;
        if (*digitsPointer != (byte) 0)
        {
          ulong num2 = num1 + (ulong) ((int) *digitsPointer++ - 48);
          if (num2 < num1)
            return false;
          num1 = num2;
        }
      }
      value = num1;
      return true;
    }

    internal static int ParseInt32(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info)
    {
      int result;
      Number.ParsingStatus int32 = Number.TryParseInt32(value, styles, info, out result);
      if (int32 != Number.ParsingStatus.OK)
        Number.ThrowOverflowOrFormatException(int32, TypeCode.Int32);
      return result;
    }

    internal static long ParseInt64(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info)
    {
      long result;
      Number.ParsingStatus int64 = Number.TryParseInt64(value, styles, info, out result);
      if (int64 != Number.ParsingStatus.OK)
        Number.ThrowOverflowOrFormatException(int64, TypeCode.Int64);
      return result;
    }

    internal static uint ParseUInt32(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info)
    {
      uint result;
      Number.ParsingStatus uint32 = Number.TryParseUInt32(value, styles, info, out result);
      if (uint32 != Number.ParsingStatus.OK)
        Number.ThrowOverflowOrFormatException(uint32, TypeCode.UInt32);
      return result;
    }

    internal static ulong ParseUInt64(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info)
    {
      ulong result;
      Number.ParsingStatus uint64 = Number.TryParseUInt64(value, styles, info, out result);
      if (uint64 != Number.ParsingStatus.OK)
        Number.ThrowOverflowOrFormatException(uint64, TypeCode.UInt64);
      return result;
    }

    private static unsafe bool TryParseNumber(
      ref char* str,
      char* strEnd,
      NumberStyles styles,
      ref Number.NumberBuffer number,
      NumberFormatInfo info)
    {
      string str1 = (string) null;
      bool flag1 = false;
      string decimalSeparator;
      string str2;
      if ((styles & NumberStyles.AllowCurrencySymbol) != NumberStyles.None)
      {
        str1 = info.CurrencySymbol;
        decimalSeparator = info.CurrencyDecimalSeparator;
        str2 = info.CurrencyGroupSeparator;
        flag1 = true;
      }
      else
      {
        decimalSeparator = info.NumberDecimalSeparator;
        str2 = info.NumberGroupSeparator;
      }
      int num1 = 0;
      char* p = str;
      char ch = p < strEnd ? *p : char.MinValue;
      while (true)
      {
        if (!Number.IsWhite((int) ch) || (styles & NumberStyles.AllowLeadingWhite) == NumberStyles.None || (num1 & 1) != 0 && (num1 & 32) == 0 && info.NumberNegativePattern != 2)
        {
          char* chPtr1;
          if ((styles & NumberStyles.AllowLeadingSign) != NumberStyles.None && (num1 & 1) == 0 && ((IntPtr) (chPtr1 = Number.MatchChars(p, strEnd, info.PositiveSign)) != IntPtr.Zero || (IntPtr) (chPtr1 = Number.MatchChars(p, strEnd, info.NegativeSign)) != IntPtr.Zero && (number.IsNegative = true)))
          {
            num1 |= 1;
            p = chPtr1 - 1;
          }
          else if (ch == '(' && (styles & NumberStyles.AllowParentheses) != NumberStyles.None && (num1 & 1) == 0)
          {
            num1 |= 3;
            number.IsNegative = true;
          }
          else
          {
            char* chPtr2;
            if (str1 != null && (IntPtr) (chPtr2 = Number.MatchChars(p, strEnd, str1)) != IntPtr.Zero)
            {
              num1 |= 32;
              str1 = (string) null;
              p = chPtr2 - 1;
            }
            else
              break;
          }
        }
        ch = ++p < strEnd ? *p : char.MinValue;
      }
      int num2 = 0;
      int index = 0;
      int num3 = number.Digits.Length - 1;
      while (true)
      {
        if (Number.IsDigit((int) ch))
        {
          num1 |= 4;
          if (ch != '0' || (num1 & 8) != 0)
          {
            if (num2 < num3)
            {
              number.Digits[num2++] = (byte) ch;
              if (ch != '0' || number.Kind != Number.NumberBufferKind.Integer)
                index = num2;
            }
            else if (ch != '0')
              number.HasNonZeroTail = true;
            if ((num1 & 16) == 0)
              ++number.Scale;
            num1 |= 8;
          }
          else if ((num1 & 16) != 0)
            --number.Scale;
        }
        else
        {
          char* chPtr1;
          if ((styles & NumberStyles.AllowDecimalPoint) != NumberStyles.None && (num1 & 16) == 0 && ((IntPtr) (chPtr1 = Number.MatchChars(p, strEnd, decimalSeparator)) != IntPtr.Zero || flag1 && (num1 & 32) == 0 && (IntPtr) (chPtr1 = Number.MatchChars(p, strEnd, info.NumberDecimalSeparator)) != IntPtr.Zero))
          {
            num1 |= 16;
            p = chPtr1 - 1;
          }
          else
          {
            char* chPtr2;
            if ((styles & NumberStyles.AllowThousands) != NumberStyles.None && (num1 & 4) != 0 && (num1 & 16) == 0 && ((IntPtr) (chPtr2 = Number.MatchChars(p, strEnd, str2)) != IntPtr.Zero || flag1 && (num1 & 32) == 0 && (IntPtr) (chPtr2 = Number.MatchChars(p, strEnd, info.NumberGroupSeparator)) != IntPtr.Zero))
              p = chPtr2 - 1;
            else
              break;
          }
        }
        ch = ++p < strEnd ? *p : char.MinValue;
      }
      bool flag2 = false;
      number.DigitsCount = index;
      number.Digits[index] = (byte) 0;
      if ((num1 & 4) != 0)
      {
        if ((ch == 'E' || ch == 'e') && (styles & NumberStyles.AllowExponent) != NumberStyles.None)
        {
          char* chPtr1 = p;
          ch = ++p < strEnd ? *p : char.MinValue;
          char* chPtr2;
          if ((IntPtr) (chPtr2 = Number.MatchChars(p, strEnd, info._positiveSign)) != IntPtr.Zero)
          {
            ch = (p = chPtr2) < strEnd ? *p : char.MinValue;
          }
          else
          {
            char* chPtr3;
            if ((IntPtr) (chPtr3 = Number.MatchChars(p, strEnd, info._negativeSign)) != IntPtr.Zero)
            {
              ch = (p = chPtr3) < strEnd ? *p : char.MinValue;
              flag2 = true;
            }
          }
          if (Number.IsDigit((int) ch))
          {
            int num4 = 0;
            do
            {
              num4 = num4 * 10 + ((int) ch - 48);
              ch = ++p < strEnd ? *p : char.MinValue;
              if (num4 > 1000)
              {
                num4 = 9999;
                while (Number.IsDigit((int) ch))
                  ch = ++p < strEnd ? *p : char.MinValue;
              }
            }
            while (Number.IsDigit((int) ch));
            if (flag2)
              num4 = -num4;
            number.Scale += num4;
          }
          else
          {
            p = chPtr1;
            ch = p < strEnd ? *p : char.MinValue;
          }
        }
        while (true)
        {
          if (!Number.IsWhite((int) ch) || (styles & NumberStyles.AllowTrailingWhite) == NumberStyles.None)
          {
            char* chPtr1;
            if ((styles & NumberStyles.AllowTrailingSign) != NumberStyles.None && (num1 & 1) == 0 && ((IntPtr) (chPtr1 = Number.MatchChars(p, strEnd, info.PositiveSign)) != IntPtr.Zero || (IntPtr) (chPtr1 = Number.MatchChars(p, strEnd, info.NegativeSign)) != IntPtr.Zero && (number.IsNegative = true)))
            {
              num1 |= 1;
              p = chPtr1 - 1;
            }
            else if (ch == ')' && (num1 & 2) != 0)
            {
              num1 &= -3;
            }
            else
            {
              char* chPtr2;
              if (str1 != null && (IntPtr) (chPtr2 = Number.MatchChars(p, strEnd, str1)) != IntPtr.Zero)
              {
                str1 = (string) null;
                p = chPtr2 - 1;
              }
              else
                break;
            }
          }
          ch = ++p < strEnd ? *p : char.MinValue;
        }
        if ((num1 & 2) == 0)
        {
          if ((num1 & 8) == 0)
          {
            if (number.Kind != Number.NumberBufferKind.Decimal)
              number.Scale = 0;
            if (number.Kind == Number.NumberBufferKind.Integer && (num1 & 16) == 0)
              number.IsNegative = false;
          }
          str = p;
          return true;
        }
      }
      str = p;
      return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Number.ParsingStatus TryParseInt32(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out int result)
    {
      if ((styles & ~NumberStyles.Integer) == NumberStyles.None)
        return Number.TryParseInt32IntegerStyle(value, styles, info, out result);
      if ((styles & NumberStyles.AllowHexSpecifier) == NumberStyles.None)
        return Number.TryParseInt32Number(value, styles, info, out result);
      result = 0;
      return Number.TryParseUInt32HexNumberStyle(value, styles, out Unsafe.As<int, uint>(ref result));
    }

    private static unsafe Number.ParsingStatus TryParseInt32Number(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out int result)
    {
      result = 0;
      byte* digits = stackalloc byte[11];
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Integer, digits, 11);
      if (!Number.TryStringToNumber(value, styles, ref number, info))
        return Number.ParsingStatus.Failed;
      return !Number.TryNumberToInt32(ref number, ref result) ? Number.ParsingStatus.Overflow : Number.ParsingStatus.OK;
    }

    internal static Number.ParsingStatus TryParseInt32IntegerStyle(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out int result)
    {
      Number.ParsingStatus parsingStatus;
      if (!value.IsEmpty)
      {
        int num1 = 0;
        int ch = (int) value[0];
        if ((styles & NumberStyles.AllowLeadingWhite) != NumberStyles.None && Number.IsWhite(ch))
        {
          do
          {
            ++num1;
            if ((uint) num1 < (uint) value.Length)
              ch = (int) value[num1];
            else
              goto label_37;
          }
          while (Number.IsWhite(ch));
        }
        int num2 = 1;
        if ((styles & NumberStyles.AllowLeadingSign) != NumberStyles.None)
        {
          if (info.HasInvariantNumberSigns)
          {
            switch (ch)
            {
              case 43:
                ++num1;
                if ((uint) num1 < (uint) value.Length)
                {
                  ch = (int) value[num1];
                  break;
                }
                goto label_37;
              case 45:
                num2 = -1;
                ++num1;
                if ((uint) num1 < (uint) value.Length)
                {
                  ch = (int) value[num1];
                  break;
                }
                goto label_37;
            }
          }
          else
          {
            value = value.Slice(num1);
            num1 = 0;
            string positiveSign = info.PositiveSign;
            string negativeSign = info.NegativeSign;
            if (!string.IsNullOrEmpty(positiveSign) && value.StartsWith<char>((ReadOnlySpan<char>) positiveSign))
            {
              num1 += positiveSign.Length;
              if ((uint) num1 < (uint) value.Length)
                ch = (int) value[num1];
              else
                goto label_37;
            }
            else if (!string.IsNullOrEmpty(negativeSign) && value.StartsWith<char>((ReadOnlySpan<char>) negativeSign))
            {
              num2 = -1;
              num1 += negativeSign.Length;
              if ((uint) num1 < (uint) value.Length)
                ch = (int) value[num1];
              else
                goto label_37;
            }
          }
        }
        bool flag1 = false;
        int num3 = 0;
        if (Number.IsDigit(ch))
        {
          if (ch == 48)
          {
            do
            {
              ++num1;
              if ((uint) num1 < (uint) value.Length)
                ch = (int) value[num1];
              else
                goto label_35;
            }
            while (ch == 48);
            if (!Number.IsDigit(ch))
              goto label_39;
          }
          num3 = ch - 48;
          ++num1;
          for (int index = 0; index < 8; ++index)
          {
            if ((uint) num1 < (uint) value.Length)
            {
              ch = (int) value[num1];
              if (Number.IsDigit(ch))
              {
                ++num1;
                num3 = 10 * num3 + ch - 48;
              }
              else
                goto label_39;
            }
            else
              goto label_35;
          }
          if ((uint) num1 < (uint) value.Length)
          {
            ch = (int) value[num1];
            if (Number.IsDigit(ch))
            {
              ++num1;
              bool flag2 = num3 > 214748364;
              num3 = num3 * 10 + ch - 48;
              flag1 = flag2 | (uint) num3 > (uint) int.MaxValue + ((uint) num2 >> 31);
              if ((uint) num1 < (uint) value.Length)
              {
                for (ch = (int) value[num1]; Number.IsDigit(ch); ch = (int) value[num1])
                {
                  flag1 = true;
                  ++num1;
                  if ((uint) num1 >= (uint) value.Length)
                    goto label_38;
                }
                goto label_39;
              }
            }
            else
              goto label_39;
          }
          else
            goto label_35;
label_34:
          if (flag1)
            goto label_38;
label_35:
          result = num3 * num2;
          parsingStatus = Number.ParsingStatus.OK;
          goto label_36;
label_38:
          result = 0;
          parsingStatus = Number.ParsingStatus.Overflow;
          goto label_36;
label_39:
          if (Number.IsWhite(ch))
          {
            if ((styles & NumberStyles.AllowTrailingWhite) != NumberStyles.None)
            {
              ++num1;
              while (num1 < value.Length && Number.IsWhite((int) value[num1]))
                ++num1;
              if ((uint) num1 >= (uint) value.Length)
                goto label_34;
            }
            else
              goto label_37;
          }
          if (Number.TrailingZeros(value, num1))
            goto label_34;
          else
            goto label_37;
        }
        else
          goto label_37;
      }
      else
        goto label_37;
label_36:
      return parsingStatus;
label_37:
      result = 0;
      parsingStatus = Number.ParsingStatus.Failed;
      goto label_36;
    }

    internal static Number.ParsingStatus TryParseInt64IntegerStyle(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out long result)
    {
      Number.ParsingStatus parsingStatus;
      if (!value.IsEmpty)
      {
        int num1 = 0;
        int ch = (int) value[0];
        if ((styles & NumberStyles.AllowLeadingWhite) != NumberStyles.None && Number.IsWhite(ch))
        {
          do
          {
            ++num1;
            if ((uint) num1 < (uint) value.Length)
              ch = (int) value[num1];
            else
              goto label_37;
          }
          while (Number.IsWhite(ch));
        }
        int num2 = 1;
        if ((styles & NumberStyles.AllowLeadingSign) != NumberStyles.None)
        {
          if (info.HasInvariantNumberSigns)
          {
            switch (ch)
            {
              case 43:
                ++num1;
                if ((uint) num1 < (uint) value.Length)
                {
                  ch = (int) value[num1];
                  break;
                }
                goto label_37;
              case 45:
                num2 = -1;
                ++num1;
                if ((uint) num1 < (uint) value.Length)
                {
                  ch = (int) value[num1];
                  break;
                }
                goto label_37;
            }
          }
          else
          {
            value = value.Slice(num1);
            num1 = 0;
            string positiveSign = info.PositiveSign;
            string negativeSign = info.NegativeSign;
            if (!string.IsNullOrEmpty(positiveSign) && value.StartsWith<char>((ReadOnlySpan<char>) positiveSign))
            {
              num1 += positiveSign.Length;
              if ((uint) num1 < (uint) value.Length)
                ch = (int) value[num1];
              else
                goto label_37;
            }
            else if (!string.IsNullOrEmpty(negativeSign) && value.StartsWith<char>((ReadOnlySpan<char>) negativeSign))
            {
              num2 = -1;
              num1 += negativeSign.Length;
              if ((uint) num1 < (uint) value.Length)
                ch = (int) value[num1];
              else
                goto label_37;
            }
          }
        }
        bool flag1 = false;
        long num3 = 0;
        if (Number.IsDigit(ch))
        {
          if (ch == 48)
          {
            do
            {
              ++num1;
              if ((uint) num1 < (uint) value.Length)
                ch = (int) value[num1];
              else
                goto label_35;
            }
            while (ch == 48);
            if (!Number.IsDigit(ch))
              goto label_39;
          }
          num3 = (long) (ch - 48);
          ++num1;
          for (int index = 0; index < 17; ++index)
          {
            if ((uint) num1 < (uint) value.Length)
            {
              ch = (int) value[num1];
              if (Number.IsDigit(ch))
              {
                ++num1;
                num3 = 10L * num3 + (long) ch - 48L;
              }
              else
                goto label_39;
            }
            else
              goto label_35;
          }
          if ((uint) num1 < (uint) value.Length)
          {
            ch = (int) value[num1];
            if (Number.IsDigit(ch))
            {
              ++num1;
              bool flag2 = num3 > 922337203685477580L;
              num3 = num3 * 10L + (long) ch - 48L;
              flag1 = flag2 | (ulong) num3 > (ulong) long.MaxValue + (ulong) ((uint) num2 >> 31);
              if ((uint) num1 < (uint) value.Length)
              {
                for (ch = (int) value[num1]; Number.IsDigit(ch); ch = (int) value[num1])
                {
                  flag1 = true;
                  ++num1;
                  if ((uint) num1 >= (uint) value.Length)
                    goto label_38;
                }
                goto label_39;
              }
            }
            else
              goto label_39;
          }
          else
            goto label_35;
label_34:
          if (flag1)
            goto label_38;
label_35:
          result = num3 * (long) num2;
          parsingStatus = Number.ParsingStatus.OK;
          goto label_36;
label_38:
          result = 0L;
          parsingStatus = Number.ParsingStatus.Overflow;
          goto label_36;
label_39:
          if (Number.IsWhite(ch))
          {
            if ((styles & NumberStyles.AllowTrailingWhite) != NumberStyles.None)
            {
              ++num1;
              while (num1 < value.Length && Number.IsWhite((int) value[num1]))
                ++num1;
              if ((uint) num1 >= (uint) value.Length)
                goto label_34;
            }
            else
              goto label_37;
          }
          if (Number.TrailingZeros(value, num1))
            goto label_34;
          else
            goto label_37;
        }
        else
          goto label_37;
      }
      else
        goto label_37;
label_36:
      return parsingStatus;
label_37:
      result = 0L;
      parsingStatus = Number.ParsingStatus.Failed;
      goto label_36;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Number.ParsingStatus TryParseInt64(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out long result)
    {
      if ((styles & ~NumberStyles.Integer) == NumberStyles.None)
        return Number.TryParseInt64IntegerStyle(value, styles, info, out result);
      if ((styles & NumberStyles.AllowHexSpecifier) == NumberStyles.None)
        return Number.TryParseInt64Number(value, styles, info, out result);
      result = 0L;
      return Number.TryParseUInt64HexNumberStyle(value, styles, out Unsafe.As<long, ulong>(ref result));
    }

    private static unsafe Number.ParsingStatus TryParseInt64Number(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out long result)
    {
      result = 0L;
      byte* digits = stackalloc byte[20];
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Integer, digits, 20);
      if (!Number.TryStringToNumber(value, styles, ref number, info))
        return Number.ParsingStatus.Failed;
      return !Number.TryNumberToInt64(ref number, ref result) ? Number.ParsingStatus.Overflow : Number.ParsingStatus.OK;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Number.ParsingStatus TryParseUInt32(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out uint result)
    {
      if ((styles & ~NumberStyles.Integer) == NumberStyles.None)
        return Number.TryParseUInt32IntegerStyle(value, styles, info, out result);
      return (styles & NumberStyles.AllowHexSpecifier) != NumberStyles.None ? Number.TryParseUInt32HexNumberStyle(value, styles, out result) : Number.TryParseUInt32Number(value, styles, info, out result);
    }

    private static unsafe Number.ParsingStatus TryParseUInt32Number(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out uint result)
    {
      result = 0U;
      byte* digits = stackalloc byte[11];
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Integer, digits, 11);
      if (!Number.TryStringToNumber(value, styles, ref number, info))
        return Number.ParsingStatus.Failed;
      return !Number.TryNumberToUInt32(ref number, ref result) ? Number.ParsingStatus.Overflow : Number.ParsingStatus.OK;
    }

    internal static Number.ParsingStatus TryParseUInt32IntegerStyle(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out uint result)
    {
      Number.ParsingStatus parsingStatus;
      if (!value.IsEmpty)
      {
        int num1 = 0;
        int ch = (int) value[0];
        if ((styles & NumberStyles.AllowLeadingWhite) != NumberStyles.None && Number.IsWhite(ch))
        {
          do
          {
            ++num1;
            if ((uint) num1 < (uint) value.Length)
              ch = (int) value[num1];
            else
              goto label_37;
          }
          while (Number.IsWhite(ch));
        }
        bool flag = false;
        if ((styles & NumberStyles.AllowLeadingSign) != NumberStyles.None)
        {
          if (info.HasInvariantNumberSigns)
          {
            switch (ch)
            {
              case 43:
                ++num1;
                if ((uint) num1 < (uint) value.Length)
                {
                  ch = (int) value[num1];
                  break;
                }
                goto label_37;
              case 45:
                flag = true;
                ++num1;
                if ((uint) num1 < (uint) value.Length)
                {
                  ch = (int) value[num1];
                  break;
                }
                goto label_37;
            }
          }
          else
          {
            value = value.Slice(num1);
            num1 = 0;
            string positiveSign = info.PositiveSign;
            string negativeSign = info.NegativeSign;
            if (!string.IsNullOrEmpty(positiveSign) && value.StartsWith<char>((ReadOnlySpan<char>) positiveSign))
            {
              num1 += positiveSign.Length;
              if ((uint) num1 < (uint) value.Length)
                ch = (int) value[num1];
              else
                goto label_37;
            }
            else if (!string.IsNullOrEmpty(negativeSign) && value.StartsWith<char>((ReadOnlySpan<char>) negativeSign))
            {
              flag = true;
              num1 += negativeSign.Length;
              if ((uint) num1 < (uint) value.Length)
                ch = (int) value[num1];
              else
                goto label_37;
            }
          }
        }
        int num2 = 0;
        if (Number.IsDigit(ch))
        {
          if (ch == 48)
          {
            do
            {
              ++num1;
              if ((uint) num1 < (uint) value.Length)
                ch = (int) value[num1];
              else
                goto label_35;
            }
            while (ch == 48);
            if (!Number.IsDigit(ch))
            {
              flag = false;
              goto label_40;
            }
          }
          num2 = ch - 48;
          ++num1;
          for (int index = 0; index < 8; ++index)
          {
            if ((uint) num1 < (uint) value.Length)
            {
              ch = (int) value[num1];
              if (Number.IsDigit(ch))
              {
                ++num1;
                num2 = 10 * num2 + ch - 48;
              }
              else
                goto label_40;
            }
            else
              goto label_34;
          }
          if ((uint) num1 < (uint) value.Length)
          {
            ch = (int) value[num1];
            if (Number.IsDigit(ch))
            {
              ++num1;
              flag = ((flag ? 1 : 0) | ((uint) num2 > 429496729U ? 1 : (num2 != 429496729 ? 0 : (ch > 53 ? 1 : 0)))) != 0;
              num2 = num2 * 10 + ch - 48;
              if ((uint) num1 < (uint) value.Length)
              {
                for (ch = (int) value[num1]; Number.IsDigit(ch); ch = (int) value[num1])
                {
                  flag = true;
                  ++num1;
                  if ((uint) num1 >= (uint) value.Length)
                    goto label_38;
                }
                goto label_40;
              }
            }
            else
              goto label_40;
          }
label_34:
          if (flag)
            goto label_38;
label_35:
          result = (uint) num2;
          parsingStatus = Number.ParsingStatus.OK;
          goto label_36;
label_38:
          result = 0U;
          parsingStatus = Number.ParsingStatus.Overflow;
          goto label_36;
label_40:
          if (Number.IsWhite(ch))
          {
            if ((styles & NumberStyles.AllowTrailingWhite) != NumberStyles.None)
            {
              ++num1;
              while (num1 < value.Length && Number.IsWhite((int) value[num1]))
                ++num1;
              if ((uint) num1 >= (uint) value.Length)
                goto label_34;
            }
            else
              goto label_37;
          }
          if (Number.TrailingZeros(value, num1))
            goto label_34;
          else
            goto label_37;
        }
        else
          goto label_37;
      }
      else
        goto label_37;
label_36:
      return parsingStatus;
label_37:
      result = 0U;
      parsingStatus = Number.ParsingStatus.Failed;
      goto label_36;
    }

    private static Number.ParsingStatus TryParseUInt32HexNumberStyle(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      out uint result)
    {
      Number.ParsingStatus parsingStatus;
      if (!value.IsEmpty)
      {
        int index1 = 0;
        int num1 = (int) value[0];
        if ((styles & NumberStyles.AllowLeadingWhite) != NumberStyles.None && Number.IsWhite(num1))
        {
          do
          {
            ++index1;
            if ((uint) index1 < (uint) value.Length)
              num1 = (int) value[index1];
            else
              goto label_22;
          }
          while (Number.IsWhite(num1));
        }
        bool flag = false;
        uint num2 = 0;
        if (HexConverter.IsHexChar(num1))
        {
          if (num1 == 48)
          {
            do
            {
              ++index1;
              if ((uint) index1 < (uint) value.Length)
                num1 = (int) value[index1];
              else
                goto label_20;
            }
            while (num1 == 48);
            if (!HexConverter.IsHexChar(num1))
              goto label_24;
          }
          num2 = (uint) HexConverter.FromChar(num1);
          ++index1;
          for (int index2 = 0; index2 < 7; ++index2)
          {
            if ((uint) index1 < (uint) value.Length)
            {
              num1 = (int) value[index1];
              uint num3 = (uint) HexConverter.FromChar(num1);
              if (num3 != (uint) byte.MaxValue)
              {
                ++index1;
                num2 = 16U * num2 + num3;
              }
              else
                goto label_24;
            }
            else
              goto label_20;
          }
          if ((uint) index1 < (uint) value.Length)
          {
            num1 = (int) value[index1];
            if (HexConverter.IsHexChar(num1))
            {
              do
              {
                ++index1;
                if ((uint) index1 < (uint) value.Length)
                  num1 = (int) value[index1];
                else
                  goto label_23;
              }
              while (HexConverter.IsHexChar(num1));
              flag = true;
              goto label_24;
            }
            else
              goto label_24;
          }
label_20:
          result = num2;
          parsingStatus = Number.ParsingStatus.OK;
          goto label_21;
label_23:
          result = 0U;
          parsingStatus = Number.ParsingStatus.Overflow;
          goto label_21;
label_24:
          if (!Number.IsWhite(num1))
            goto label_30;
          else
            goto label_25;
label_19:
          if (flag)
            goto label_23;
          else
            goto label_20;
label_25:
          if ((styles & NumberStyles.AllowTrailingWhite) != NumberStyles.None)
          {
            ++index1;
            while (index1 < value.Length && Number.IsWhite((int) value[index1]))
              ++index1;
            if ((uint) index1 >= (uint) value.Length)
              goto label_19;
          }
          else
            goto label_22;
label_30:
          if (Number.TrailingZeros(value, index1))
            goto label_19;
          else
            goto label_22;
        }
        else
          goto label_22;
      }
      else
        goto label_22;
label_21:
      return parsingStatus;
label_22:
      result = 0U;
      parsingStatus = Number.ParsingStatus.Failed;
      goto label_21;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Number.ParsingStatus TryParseUInt64(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out ulong result)
    {
      if ((styles & ~NumberStyles.Integer) == NumberStyles.None)
        return Number.TryParseUInt64IntegerStyle(value, styles, info, out result);
      return (styles & NumberStyles.AllowHexSpecifier) != NumberStyles.None ? Number.TryParseUInt64HexNumberStyle(value, styles, out result) : Number.TryParseUInt64Number(value, styles, info, out result);
    }

    private static unsafe Number.ParsingStatus TryParseUInt64Number(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out ulong result)
    {
      result = 0UL;
      byte* digits = stackalloc byte[21];
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Integer, digits, 21);
      if (!Number.TryStringToNumber(value, styles, ref number, info))
        return Number.ParsingStatus.Failed;
      return !Number.TryNumberToUInt64(ref number, ref result) ? Number.ParsingStatus.Overflow : Number.ParsingStatus.OK;
    }

    internal static Number.ParsingStatus TryParseUInt64IntegerStyle(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out ulong result)
    {
      Number.ParsingStatus parsingStatus;
      if (!value.IsEmpty)
      {
        int num1 = 0;
        int ch = (int) value[0];
        if ((styles & NumberStyles.AllowLeadingWhite) != NumberStyles.None && Number.IsWhite(ch))
        {
          do
          {
            ++num1;
            if ((uint) num1 < (uint) value.Length)
              ch = (int) value[num1];
            else
              goto label_37;
          }
          while (Number.IsWhite(ch));
        }
        bool flag = false;
        if ((styles & NumberStyles.AllowLeadingSign) != NumberStyles.None)
        {
          if (info.HasInvariantNumberSigns)
          {
            switch (ch)
            {
              case 43:
                ++num1;
                if ((uint) num1 < (uint) value.Length)
                {
                  ch = (int) value[num1];
                  break;
                }
                goto label_37;
              case 45:
                flag = true;
                ++num1;
                if ((uint) num1 < (uint) value.Length)
                {
                  ch = (int) value[num1];
                  break;
                }
                goto label_37;
            }
          }
          else
          {
            value = value.Slice(num1);
            num1 = 0;
            string positiveSign = info.PositiveSign;
            string negativeSign = info.NegativeSign;
            if (!string.IsNullOrEmpty(positiveSign) && value.StartsWith<char>((ReadOnlySpan<char>) positiveSign))
            {
              num1 += positiveSign.Length;
              if ((uint) num1 < (uint) value.Length)
                ch = (int) value[num1];
              else
                goto label_37;
            }
            else if (!string.IsNullOrEmpty(negativeSign) && value.StartsWith<char>((ReadOnlySpan<char>) negativeSign))
            {
              flag = true;
              num1 += negativeSign.Length;
              if ((uint) num1 < (uint) value.Length)
                ch = (int) value[num1];
              else
                goto label_37;
            }
          }
        }
        long num2 = 0;
        if (Number.IsDigit(ch))
        {
          if (ch == 48)
          {
            do
            {
              ++num1;
              if ((uint) num1 < (uint) value.Length)
                ch = (int) value[num1];
              else
                goto label_35;
            }
            while (ch == 48);
            if (!Number.IsDigit(ch))
            {
              flag = false;
              goto label_40;
            }
          }
          num2 = (long) (ch - 48);
          ++num1;
          for (int index = 0; index < 18; ++index)
          {
            if ((uint) num1 < (uint) value.Length)
            {
              ch = (int) value[num1];
              if (Number.IsDigit(ch))
              {
                ++num1;
                num2 = 10L * num2 + (long) ch - 48L;
              }
              else
                goto label_40;
            }
            else
              goto label_34;
          }
          if ((uint) num1 < (uint) value.Length)
          {
            ch = (int) value[num1];
            if (Number.IsDigit(ch))
            {
              ++num1;
              flag = ((flag ? 1 : 0) | ((ulong) num2 > 1844674407370955161UL ? 1 : (num2 != 1844674407370955161L ? 0 : (ch > 53 ? 1 : 0)))) != 0;
              num2 = num2 * 10L + (long) ch - 48L;
              if ((uint) num1 < (uint) value.Length)
              {
                for (ch = (int) value[num1]; Number.IsDigit(ch); ch = (int) value[num1])
                {
                  flag = true;
                  ++num1;
                  if ((uint) num1 >= (uint) value.Length)
                    goto label_38;
                }
                goto label_40;
              }
            }
            else
              goto label_40;
          }
label_34:
          if (flag)
            goto label_38;
label_35:
          result = (ulong) num2;
          parsingStatus = Number.ParsingStatus.OK;
          goto label_36;
label_38:
          result = 0UL;
          parsingStatus = Number.ParsingStatus.Overflow;
          goto label_36;
label_40:
          if (Number.IsWhite(ch))
          {
            if ((styles & NumberStyles.AllowTrailingWhite) != NumberStyles.None)
            {
              ++num1;
              while (num1 < value.Length && Number.IsWhite((int) value[num1]))
                ++num1;
              if ((uint) num1 >= (uint) value.Length)
                goto label_34;
            }
            else
              goto label_37;
          }
          if (Number.TrailingZeros(value, num1))
            goto label_34;
          else
            goto label_37;
        }
        else
          goto label_37;
      }
      else
        goto label_37;
label_36:
      return parsingStatus;
label_37:
      result = 0UL;
      parsingStatus = Number.ParsingStatus.Failed;
      goto label_36;
    }

    private static Number.ParsingStatus TryParseUInt64HexNumberStyle(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      out ulong result)
    {
      Number.ParsingStatus parsingStatus;
      if (!value.IsEmpty)
      {
        int index1 = 0;
        int num1 = (int) value[0];
        if ((styles & NumberStyles.AllowLeadingWhite) != NumberStyles.None && Number.IsWhite(num1))
        {
          do
          {
            ++index1;
            if ((uint) index1 < (uint) value.Length)
              num1 = (int) value[index1];
            else
              goto label_22;
          }
          while (Number.IsWhite(num1));
        }
        bool flag = false;
        ulong num2 = 0;
        if (HexConverter.IsHexChar(num1))
        {
          if (num1 == 48)
          {
            do
            {
              ++index1;
              if ((uint) index1 < (uint) value.Length)
                num1 = (int) value[index1];
              else
                goto label_20;
            }
            while (num1 == 48);
            if (!HexConverter.IsHexChar(num1))
              goto label_24;
          }
          num2 = (ulong) (uint) HexConverter.FromChar(num1);
          ++index1;
          for (int index2 = 0; index2 < 15; ++index2)
          {
            if ((uint) index1 < (uint) value.Length)
            {
              num1 = (int) value[index1];
              uint num3 = (uint) HexConverter.FromChar(num1);
              if (num3 != (uint) byte.MaxValue)
              {
                ++index1;
                num2 = 16UL * num2 + (ulong) num3;
              }
              else
                goto label_24;
            }
            else
              goto label_20;
          }
          if ((uint) index1 < (uint) value.Length)
          {
            num1 = (int) value[index1];
            if (HexConverter.IsHexChar(num1))
            {
              do
              {
                ++index1;
                if ((uint) index1 < (uint) value.Length)
                  num1 = (int) value[index1];
                else
                  goto label_23;
              }
              while (HexConverter.IsHexChar(num1));
              flag = true;
              goto label_24;
            }
            else
              goto label_24;
          }
label_20:
          result = num2;
          parsingStatus = Number.ParsingStatus.OK;
          goto label_21;
label_23:
          result = 0UL;
          parsingStatus = Number.ParsingStatus.Overflow;
          goto label_21;
label_24:
          if (!Number.IsWhite(num1))
            goto label_30;
          else
            goto label_25;
label_19:
          if (flag)
            goto label_23;
          else
            goto label_20;
label_25:
          if ((styles & NumberStyles.AllowTrailingWhite) != NumberStyles.None)
          {
            ++index1;
            while (index1 < value.Length && Number.IsWhite((int) value[index1]))
              ++index1;
            if ((uint) index1 >= (uint) value.Length)
              goto label_19;
          }
          else
            goto label_22;
label_30:
          if (Number.TrailingZeros(value, index1))
            goto label_19;
          else
            goto label_22;
        }
        else
          goto label_22;
      }
      else
        goto label_22;
label_21:
      return parsingStatus;
label_22:
      result = 0UL;
      parsingStatus = Number.ParsingStatus.Failed;
      goto label_21;
    }

    internal static Decimal ParseDecimal(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info)
    {
      Decimal result;
      Number.ParsingStatus status = Number.TryParseDecimal(value, styles, info, out result);
      if (status != Number.ParsingStatus.OK)
        Number.ThrowOverflowOrFormatException(status, TypeCode.Decimal);
      return result;
    }

    internal static unsafe bool TryNumberToDecimal(
      ref Number.NumberBuffer number,
      ref Decimal value)
    {
      byte* digitsPointer = number.GetDigitsPointer();
      int scale = number.Scale;
      bool isNegative = number.IsNegative;
      uint num1 = (uint) *digitsPointer;
      if (num1 == 0U)
      {
        value = new Decimal(0, 0, 0, isNegative, (byte) Math.Clamp(-scale, 0, 28));
        return true;
      }
      if (scale > 29)
        return false;
      ulong num2 = 0;
      while (scale > -28)
      {
        --scale;
        num2 = num2 * 10UL + (ulong) (num1 - 48U);
        num1 = (uint) *++digitsPointer;
        if (num2 < 1844674407370955161UL)
        {
          if (num1 == 0U)
          {
            while (scale > 0)
            {
              --scale;
              num2 *= 10UL;
              if (num2 >= 1844674407370955161UL)
                break;
            }
            break;
          }
        }
        else
          break;
      }
      uint num3;
      for (num3 = 0U; (scale > 0 || num1 != 0U && scale > -28) && (num3 < 429496729U || num3 == 429496729U && (num2 < 11068046444225730969UL || num2 == 11068046444225730969UL && num1 <= 53U)); --scale)
      {
        ulong num4 = (ulong) (uint) num2 * 10UL;
        ulong num5 = (ulong) (uint) (num2 >> 32) * 10UL + (num4 >> 32);
        num2 = (ulong) (uint) num4 + (num5 << 32);
        num3 = (uint) (num5 >> 32) + num3 * 10U;
        if (num1 != 0U)
        {
          uint num6 = num1 - 48U;
          num2 += (ulong) num6;
          if (num2 < (ulong) num6)
            ++num3;
          num1 = (uint) *++digitsPointer;
        }
      }
      if (num1 >= 53U)
      {
        if (num1 == 53U && ((long) num2 & 1L) == 0L)
        {
          byte* numPtr;
          uint num4 = (uint) *(numPtr = digitsPointer + 1);
          bool flag;
          for (flag = !number.HasNonZeroTail; num4 > 0U & flag; num4 = (uint) *++numPtr)
            flag &= num4 == 48U;
          if (flag)
            goto label_25;
        }
        if (++num2 == 0UL && ++num3 == 0U)
        {
          num2 = 11068046444225730970UL;
          num3 = 429496729U;
          ++scale;
        }
      }
label_25:
      if (scale > 0)
        return false;
      value = scale > -29 ? new Decimal((int) num2, (int) (num2 >> 32), (int) num3, isNegative, (byte) -scale) : new Decimal(0, 0, 0, isNegative, (byte) 28);
      return true;
    }

    internal static double ParseDouble(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info)
    {
      double result;
      if (!Number.TryParseDouble(value, styles, info, out result))
        Number.ThrowOverflowOrFormatException(Number.ParsingStatus.Failed);
      return result;
    }

    internal static float ParseSingle(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info)
    {
      float result;
      if (!Number.TryParseSingle(value, styles, info, out result))
        Number.ThrowOverflowOrFormatException(Number.ParsingStatus.Failed);
      return result;
    }

    internal static Half ParseHalf(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info)
    {
      Half result;
      if (!Number.TryParseHalf(value, styles, info, out result))
        Number.ThrowOverflowOrFormatException(Number.ParsingStatus.Failed);
      return result;
    }

    internal static unsafe Number.ParsingStatus TryParseDecimal(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out Decimal result)
    {
      byte* digits = stackalloc byte[31];
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.Decimal, digits, 31);
      result = 0M;
      if (!Number.TryStringToNumber(value, styles, ref number, info))
        return Number.ParsingStatus.Failed;
      return !Number.TryNumberToDecimal(ref number, ref result) ? Number.ParsingStatus.Overflow : Number.ParsingStatus.OK;
    }

    internal static unsafe bool TryParseDouble(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out double result)
    {
      byte* digits = stackalloc byte[769];
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.FloatingPoint, digits, 769);
      if (!Number.TryStringToNumber(value, styles, ref number, info))
      {
        ReadOnlySpan<char> span1 = value.Trim();
        if (span1.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.PositiveInfinitySymbol))
          result = double.PositiveInfinity;
        else if (span1.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.NegativeInfinitySymbol))
          result = double.NegativeInfinity;
        else if (span1.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.NaNSymbol))
          result = double.NaN;
        else if (span1.StartsWith((ReadOnlySpan<char>) info.PositiveSign, StringComparison.OrdinalIgnoreCase))
        {
          ReadOnlySpan<char> span2 = span1.Slice(info.PositiveSign.Length);
          if (span2.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.PositiveInfinitySymbol))
            result = double.PositiveInfinity;
          else if (span2.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.NaNSymbol))
          {
            result = double.NaN;
          }
          else
          {
            result = 0.0;
            return false;
          }
        }
        else if (span1.StartsWith((ReadOnlySpan<char>) info.NegativeSign, StringComparison.OrdinalIgnoreCase) && span1.Slice(info.NegativeSign.Length).EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.NaNSymbol))
        {
          result = double.NaN;
        }
        else
        {
          result = 0.0;
          return false;
        }
      }
      else
        result = Number.NumberToDouble(ref number);
      return true;
    }

    internal static unsafe bool TryParseHalf(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out Half result)
    {
      byte* digits = stackalloc byte[21];
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.FloatingPoint, digits, 21);
      if (!Number.TryStringToNumber(value, styles, ref number, info))
      {
        ReadOnlySpan<char> span1 = value.Trim();
        if (span1.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.PositiveInfinitySymbol))
          result = Half.PositiveInfinity;
        else if (span1.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.NegativeInfinitySymbol))
          result = Half.NegativeInfinity;
        else if (span1.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.NaNSymbol))
          result = Half.NaN;
        else if (span1.StartsWith((ReadOnlySpan<char>) info.PositiveSign, StringComparison.OrdinalIgnoreCase))
        {
          ReadOnlySpan<char> span2 = span1.Slice(info.PositiveSign.Length);
          if (!info.PositiveInfinitySymbol.StartsWith(info.PositiveSign, StringComparison.OrdinalIgnoreCase) && span2.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.PositiveInfinitySymbol))
            result = Half.PositiveInfinity;
          else if (!info.NaNSymbol.StartsWith(info.PositiveSign, StringComparison.OrdinalIgnoreCase) && span2.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.NaNSymbol))
          {
            result = Half.NaN;
          }
          else
          {
            result = (Half) 0.0f;
            return false;
          }
        }
        else if (span1.StartsWith((ReadOnlySpan<char>) info.NegativeSign, StringComparison.OrdinalIgnoreCase) && !info.NaNSymbol.StartsWith(info.NegativeSign, StringComparison.OrdinalIgnoreCase) && span1.Slice(info.NegativeSign.Length).EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.NaNSymbol))
        {
          result = Half.NaN;
        }
        else
        {
          result = (Half) 0.0f;
          return false;
        }
      }
      else
        result = Number.NumberToHalf(ref number);
      return true;
    }

    internal static unsafe bool TryParseSingle(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      NumberFormatInfo info,
      out float result)
    {
      byte* digits = stackalloc byte[114];
      Number.NumberBuffer number = new Number.NumberBuffer(Number.NumberBufferKind.FloatingPoint, digits, 114);
      if (!Number.TryStringToNumber(value, styles, ref number, info))
      {
        ReadOnlySpan<char> span1 = value.Trim();
        if (span1.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.PositiveInfinitySymbol))
          result = float.PositiveInfinity;
        else if (span1.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.NegativeInfinitySymbol))
          result = float.NegativeInfinity;
        else if (span1.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.NaNSymbol))
          result = float.NaN;
        else if (span1.StartsWith((ReadOnlySpan<char>) info.PositiveSign, StringComparison.OrdinalIgnoreCase))
        {
          ReadOnlySpan<char> span2 = span1.Slice(info.PositiveSign.Length);
          if (!info.PositiveInfinitySymbol.StartsWith(info.PositiveSign, StringComparison.OrdinalIgnoreCase) && span2.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.PositiveInfinitySymbol))
            result = float.PositiveInfinity;
          else if (!info.NaNSymbol.StartsWith(info.PositiveSign, StringComparison.OrdinalIgnoreCase) && span2.EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.NaNSymbol))
          {
            result = float.NaN;
          }
          else
          {
            result = 0.0f;
            return false;
          }
        }
        else if (span1.StartsWith((ReadOnlySpan<char>) info.NegativeSign, StringComparison.OrdinalIgnoreCase) && !info.NaNSymbol.StartsWith(info.NegativeSign, StringComparison.OrdinalIgnoreCase) && span1.Slice(info.NegativeSign.Length).EqualsOrdinalIgnoreCase((ReadOnlySpan<char>) info.NaNSymbol))
        {
          result = float.NaN;
        }
        else
        {
          result = 0.0f;
          return false;
        }
      }
      else
        result = Number.NumberToSingle(ref number);
      return true;
    }

    internal static unsafe bool TryStringToNumber(
      ReadOnlySpan<char> value,
      NumberStyles styles,
      ref Number.NumberBuffer number,
      NumberFormatInfo info)
    {
      fixed (char* chPtr = &MemoryMarshal.GetReference<char>(value))
      {
        char* str = chPtr;
        if (!Number.TryParseNumber(ref str, str + value.Length, styles, ref number, info) || (int) (str - chPtr) < value.Length && !Number.TrailingZeros(value, (int) (str - chPtr)))
          return false;
      }
      return true;
    }

    private static bool TrailingZeros(ReadOnlySpan<char> value, int index)
    {
      for (int index1 = index; (uint) index1 < (uint) value.Length; ++index1)
      {
        if (value[index1] != char.MinValue)
          return false;
      }
      return true;
    }

    private static bool IsSpaceReplacingChar(char c) => c == ' ' || c == ' ';

    private static unsafe char* MatchChars(char* p, char* pEnd, string value)
    {
      IntPtr num;
      if (value == null)
      {
        num = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &value.GetPinnableReference())
          num = (IntPtr) chPtr;
      }
      char* chPtr1 = (char*) num;
      if (*chPtr1 != char.MinValue)
      {
        do
        {
          char ch = p < pEnd ? *p : char.MinValue;
          if ((int) ch == (int) *chPtr1 || Number.IsSpaceReplacingChar(*chPtr1) && ch == ' ')
          {
            ++p;
            ++chPtr1;
          }
          else
            goto label_7;
        }
        while (*chPtr1 != char.MinValue);
        return p;
      }
label_7:
      // ISSUE: fixed variable is out of scope
      // ISSUE: __unpin statement
      __unpin(chPtr);
      return (char*) null;
    }

    private static bool IsWhite(int ch)
    {
      switch (ch)
      {
        case 9:
        case 10:
        case 11:
        case 12:
        case 13:
        case 32:
          return true;
        default:
          return false;
      }
    }

    private static bool IsDigit(int ch) => (uint) (ch - 48) <= 9U;

    [DoesNotReturn]
    internal static void ThrowOverflowOrFormatException(Number.ParsingStatus status, TypeCode type = TypeCode.Empty) => throw Number.GetException(status, type);

    [DoesNotReturn]
    internal static void ThrowOverflowException(TypeCode type) => throw Number.GetException(Number.ParsingStatus.Overflow, type);

    private static Exception GetException(Number.ParsingStatus status, TypeCode type)
    {
      if (status == Number.ParsingStatus.Failed)
        return (Exception) new FormatException(SR.Format_InvalidString);
      string message;
      switch (type)
      {
        case TypeCode.SByte:
          message = SR.Overflow_SByte;
          break;
        case TypeCode.Byte:
          message = SR.Overflow_Byte;
          break;
        case TypeCode.Int16:
          message = SR.Overflow_Int16;
          break;
        case TypeCode.UInt16:
          message = SR.Overflow_UInt16;
          break;
        case TypeCode.Int32:
          message = SR.Overflow_Int32;
          break;
        case TypeCode.UInt32:
          message = SR.Overflow_UInt32;
          break;
        case TypeCode.Int64:
          message = SR.Overflow_Int64;
          break;
        case TypeCode.UInt64:
          message = SR.Overflow_UInt64;
          break;
        default:
          message = SR.Overflow_Decimal;
          break;
      }
      return (Exception) new OverflowException(message);
    }

    internal static double NumberToDouble(ref Number.NumberBuffer number)
    {
      double num = number.DigitsCount == 0 || number.Scale < -324 ? 0.0 : (number.Scale <= 309 ? BitConverter.Int64BitsToDouble((long) Number.NumberToFloatingPointBits(ref number, in Number.FloatingPointInfo.Double)) : double.PositiveInfinity);
      return !number.IsNegative ? num : -num;
    }

    internal static Half NumberToHalf(ref Number.NumberBuffer number)
    {
      Half half = number.DigitsCount == 0 || number.Scale < -8 ? new Half() : (number.Scale <= 5 ? new Half((ushort) Number.NumberToFloatingPointBits(ref number, in Number.FloatingPointInfo.Half)) : Half.PositiveInfinity);
      return !number.IsNegative ? half : Half.Negate(half);
    }

    internal static float NumberToSingle(ref Number.NumberBuffer number)
    {
      float num = number.DigitsCount == 0 || number.Scale < -45 ? 0.0f : (number.Scale <= 39 ? BitConverter.Int32BitsToSingle((int) (uint) Number.NumberToFloatingPointBits(ref number, in Number.FloatingPointInfo.Single)) : float.PositiveInfinity);
      return !number.IsNegative ? num : -num;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal ref struct BigInteger
    {
      private static readonly uint[] s_Pow10UInt32Table = new uint[10]
      {
        1U,
        10U,
        100U,
        1000U,
        10000U,
        100000U,
        1000000U,
        10000000U,
        100000000U,
        1000000000U
      };
      private static readonly int[] s_Pow10BigNumTableIndices = new int[8]
      {
        0,
        2,
        5,
        10,
        18,
        33,
        61,
        116
      };
      private static readonly uint[] s_Pow10BigNumTable = new uint[233]
      {
        1U,
        100000000U,
        2U,
        1874919424U,
        2328306U,
        4U,
        0U,
        2242703233U,
        762134875U,
        1262U,
        7U,
        0U,
        0U,
        3211403009U,
        1849224548U,
        3668416493U,
        3913284084U,
        1593091U,
        14U,
        0U,
        0U,
        0U,
        0U,
        781532673U,
        64985353U,
        253049085U,
        594863151U,
        3553621484U,
        3288652808U,
        3167596762U,
        2788392729U,
        3911132675U,
        590U,
        27U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        2553183233U,
        3201533787U,
        3638140786U,
        303378311U,
        1809731782U,
        3477761648U,
        3583367183U,
        649228654U,
        2915460784U,
        487929380U,
        1011012442U,
        1677677582U,
        3428152256U,
        1710878487U,
        1438394610U,
        2161952759U,
        4100910556U,
        1608314830U,
        349175U,
        54U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        4234999809U,
        2012377703U,
        2408924892U,
        1570150255U,
        3090844311U,
        3273530073U,
        1187251475U,
        2498123591U,
        3364452033U,
        1148564857U,
        687371067U,
        2854068671U,
        1883165473U,
        505794538U,
        2988060450U,
        3159489326U,
        2531348317U,
        3215191468U,
        849106862U,
        3892080979U,
        3288073877U,
        2242451748U,
        4183778142U,
        2995818208U,
        2477501924U,
        325481258U,
        2487842652U,
        1774082830U,
        1933815724U,
        2962865281U,
        1168579910U,
        2724829000U,
        2360374019U,
        2315984659U,
        2360052375U,
        3251779801U,
        1664357844U,
        28U,
        107U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        689565697U,
        4116392818U,
        1853628763U,
        516071302U,
        2568769159U,
        365238920U,
        336250165U,
        1283268122U,
        3425490969U,
        248595470U,
        2305176814U,
        2111925499U,
        507770399U,
        2681111421U,
        589114268U,
        591287751U,
        1708941527U,
        4098957707U,
        475844916U,
        3378731398U,
        2452339615U,
        2817037361U,
        2678008327U,
        1656645978U,
        2383430340U,
        73103988U,
        448667107U,
        2329420453U,
        3124020241U,
        3625235717U,
        3208634035U,
        2412059158U,
        2981664444U,
        4117622508U,
        838560765U,
        3069470027U,
        270153238U,
        1802868219U,
        3692709886U,
        2161737865U,
        2159912357U,
        2585798786U,
        837488486U,
        4237238160U,
        2540319504U,
        3798629246U,
        3748148874U,
        1021550776U,
        2386715342U,
        1973637538U,
        1823520457U,
        1146713475U,
        833971519U,
        3277251466U,
        905620390U,
        26278816U,
        2680483154U,
        2294040859U,
        373297482U,
        5996609U,
        4109575006U,
        512575049U,
        917036550U,
        1942311753U,
        2816916778U,
        3248920332U,
        1192784020U,
        3537586671U,
        2456567643U,
        2925660628U,
        759380297U,
        888447942U,
        3559939476U,
        3654687237U,
        805U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U,
        0U
      };
      private int _length;
      private unsafe fixed uint _blocks[115];

      public static unsafe void Add(
        ref Number.BigInteger lhs,
        ref Number.BigInteger rhs,
        out Number.BigInteger result)
      {
        ref Number.BigInteger local1 = ref (lhs._length < rhs._length ? ref rhs : ref lhs);
        ref Number.BigInteger local2 = ref (lhs._length < rhs._length ? ref lhs : ref rhs);
        int length1 = local1._length;
        int length2 = local2._length;
        result._length = length1;
        ulong num1 = 0;
        int index1 = 0;
        int index2 = 0;
        int index3 = 0;
        while (index2 < length2)
        {
          ulong num2 = num1 + (ulong) local1._blocks[index1] + (ulong) local2._blocks[index2];
          num1 = num2 >> 32;
          result._blocks[index3] = (uint) num2;
          ++index1;
          ++index2;
          ++index3;
        }
        while (index1 < length1)
        {
          ulong num2 = num1 + (ulong) local1._blocks[index1];
          num1 = num2 >> 32;
          result._blocks[index3] = (uint) num2;
          ++index1;
          ++index3;
        }
        if (num1 == 0UL)
          return;
        result._blocks[index3] = 1U;
        ++result._length;
      }

      public static unsafe int Compare(ref Number.BigInteger lhs, ref Number.BigInteger rhs)
      {
        int length1 = lhs._length;
        int length2 = rhs._length;
        int num1 = length1 - length2;
        if (num1 != 0)
          return num1;
        if (length1 == 0)
          return 0;
        for (int index = length1 - 1; index >= 0; --index)
        {
          long num2 = (long) lhs._blocks[index] - (long) rhs._blocks[index];
          if (num2 != 0L)
            return num2 <= 0L ? -1 : 1;
        }
        return 0;
      }

      public static uint CountSignificantBits(uint value) => (uint) (32 - BitOperations.LeadingZeroCount(value));

      public static uint CountSignificantBits(ulong value) => (uint) (64 - BitOperations.LeadingZeroCount(value));

      public static unsafe uint CountSignificantBits(ref Number.BigInteger value)
      {
        if (value.IsZero())
          return 0;
        uint num = (uint) (value._length - 1);
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        return num * 32U + Number.BigInteger.CountSignificantBits(^(uint&) ((IntPtr) value._blocks + (IntPtr) ((long) num * 4L)));
      }

      public static unsafe void DivRem(
        ref Number.BigInteger lhs,
        ref Number.BigInteger rhs,
        out Number.BigInteger quo,
        out Number.BigInteger rem)
      {
        if (lhs.IsZero())
        {
          Number.BigInteger.SetZero(out quo);
          Number.BigInteger.SetZero(out rem);
        }
        else
        {
          int length1 = lhs._length;
          int length2 = rhs._length;
          if (length1 == 1 && length2 == 1)
          {
            uint result;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            uint num = Math.DivRem(lhs._blocks.FixedElementField, rhs._blocks.FixedElementField, out result);
            Number.BigInteger.SetUInt32(out quo, num);
            Number.BigInteger.SetUInt32(out rem, result);
          }
          else if (length2 == 1)
          {
            int num1 = length1;
            // ISSUE: reference to a compiler-generated field
            ulong fixedElementField = (ulong) rhs._blocks.FixedElementField;
            ulong result = 0;
            for (int index = num1 - 1; index >= 0; --index)
            {
              ulong num2 = Math.DivRem(result << 32 | (ulong) lhs._blocks[index], fixedElementField, out result);
              if (num2 == 0UL && index == num1 - 1)
                --num1;
              else
                quo._blocks[index] = (uint) num2;
            }
            quo._length = num1;
            Number.BigInteger.SetUInt32(out rem, (uint) result);
          }
          else if (length2 > length1)
          {
            Number.BigInteger.SetZero(out quo);
            Number.BigInteger.SetValue(out rem, ref lhs);
          }
          else
          {
            int num1 = length1 - length2 + 1;
            Number.BigInteger.SetValue(out rem, ref lhs);
            int num2 = length1;
            uint divHi = rhs._blocks[length2 - 1];
            uint divLo = rhs._blocks[length2 - 2];
            int num3 = BitOperations.LeadingZeroCount(divHi);
            int num4 = 32 - num3;
            if (num3 > 0)
            {
              divHi = divHi << num3 | divLo >> num4;
              divLo <<= num3;
              if (length2 > 2)
                divLo |= rhs._blocks[length2 - 3] >> num4;
            }
            for (int index = length1; index >= length2; --index)
            {
              int lhsStartIndex = index - length2;
              uint num5 = index < length1 ? rem._blocks[index] : 0U;
              ulong valHi = (ulong) num5 << 32 | (ulong) rem._blocks[index - 1];
              uint valLo = index > 1 ? rem._blocks[index - 2] : 0U;
              if (num3 > 0)
              {
                valHi = valHi << num3 | (ulong) (valLo >> num4);
                valLo <<= num3;
                if (index > 2)
                  valLo |= rem._blocks[index - 3] >> num4;
              }
              ulong q = valHi / (ulong) divHi;
              if (q > (ulong) uint.MaxValue)
                q = (ulong) uint.MaxValue;
              while (Number.BigInteger.DivideGuessTooBig(q, valHi, valLo, divHi, divLo))
                --q;
              if (q > 0UL && (int) Number.BigInteger.SubtractDivisor(ref rem, lhsStartIndex, ref rhs, q) != (int) num5)
              {
                Number.BigInteger.AddDivisor(ref rem, lhsStartIndex, ref rhs);
                --q;
              }
              if (num1 != 0)
              {
                if (q == 0UL && lhsStartIndex == num1 - 1)
                  --num1;
                else
                  quo._blocks[lhsStartIndex] = (uint) q;
              }
              if (index < num2)
                --num2;
            }
            quo._length = num1;
            for (int index = num2 - 1; index >= 0; --index)
            {
              if (rem._blocks[index] == 0U)
                --num2;
            }
            rem._length = num2;
          }
        }
      }

      public static unsafe uint HeuristicDivide(
        ref Number.BigInteger dividend,
        ref Number.BigInteger divisor)
      {
        int length = divisor._length;
        if (dividend._length < length)
          return 0;
        int index1 = length - 1;
        uint num1 = dividend._blocks[index1] / (divisor._blocks[index1] + 1U);
        if (num1 != 0U)
        {
          int index2 = 0;
          ulong num2 = 0;
          ulong num3 = 0;
          do
          {
            ulong num4 = (ulong) divisor._blocks[index2] * (ulong) num1 + num3;
            num3 = num4 >> 32;
            ulong num5 = (ulong) dividend._blocks[index2] - (ulong) (uint) num4 - num2;
            num2 = num5 >> 32 & 1UL;
            dividend._blocks[index2] = (uint) num5;
            ++index2;
          }
          while (index2 < length);
          while (length > 0 && dividend._blocks[length - 1] == 0U)
            --length;
          dividend._length = length;
        }
        if (Number.BigInteger.Compare(ref dividend, ref divisor) >= 0)
        {
          ++num1;
          int index2 = 0;
          ulong num2 = 0;
          do
          {
            ulong num3 = (ulong) dividend._blocks[index2] - (ulong) divisor._blocks[index2] - num2;
            num2 = num3 >> 32 & 1UL;
            dividend._blocks[index2] = (uint) num3;
            ++index2;
          }
          while (index2 < length);
          while (length > 0 && dividend._blocks[length - 1] == 0U)
            --length;
          dividend._length = length;
        }
        return num1;
      }

      public static unsafe void Multiply(
        ref Number.BigInteger lhs,
        uint value,
        out Number.BigInteger result)
      {
        if (lhs._length <= 1)
        {
          Number.BigInteger.SetUInt64(out result, (ulong) lhs.ToUInt32() * (ulong) value);
        }
        else
        {
          switch (value)
          {
            case 0:
              Number.BigInteger.SetZero(out result);
              break;
            case 1:
              Number.BigInteger.SetValue(out result, ref lhs);
              break;
            default:
              int length = lhs._length;
              int index = 0;
              uint num1 = 0;
              for (; index < length; ++index)
              {
                ulong num2 = (ulong) lhs._blocks[index] * (ulong) value + (ulong) num1;
                result._blocks[index] = (uint) num2;
                num1 = (uint) (num2 >> 32);
              }
              if (num1 != 0U)
              {
                result._blocks[index] = num1;
                result._length = length + 1;
                break;
              }
              result._length = length;
              break;
          }
        }
      }

      public static unsafe void Multiply(
        ref Number.BigInteger lhs,
        ref Number.BigInteger rhs,
        out Number.BigInteger result)
      {
        if (lhs._length <= 1)
          Number.BigInteger.Multiply(ref rhs, lhs.ToUInt32(), out result);
        else if (rhs._length <= 1)
        {
          Number.BigInteger.Multiply(ref lhs, rhs.ToUInt32(), out result);
        }
        else
        {
          ref Number.BigInteger local1 = ref lhs;
          int length1 = lhs._length;
          ref Number.BigInteger local2 = ref rhs;
          int length2 = rhs._length;
          if (length1 < length2)
          {
            local1 = ref rhs;
            length1 = rhs._length;
            local2 = ref lhs;
            length2 = lhs._length;
          }
          int num1 = length2 + length1;
          result._length = num1;
          Buffer.ZeroMemory((byte*) result.GetBlocksPointer(), (UIntPtr) (uint) (num1 * 4));
          int index1 = 0;
          int num2 = 0;
          while (index1 < length2)
          {
            if (local2._blocks[index1] != 0U)
            {
              int index2 = 0;
              int index3 = num2;
              ulong num3 = 0;
              do
              {
                ulong num4 = (ulong) result._blocks[index3] + (ulong) local2._blocks[index1] * (ulong) local1._blocks[index2] + num3;
                num3 = num4 >> 32;
                result._blocks[index3] = (uint) num4;
                ++index3;
                ++index2;
              }
              while (index2 < length1);
              result._blocks[index3] = (uint) num3;
            }
            ++index1;
            ++num2;
          }
          if (num1 <= 0 || result._blocks[num1 - 1] != 0U)
            return;
          --result._length;
        }
      }

      public static unsafe void Pow2(uint exponent, out Number.BigInteger result)
      {
        uint remainder;
        uint num = Number.BigInteger.DivRem32(exponent, out remainder);
        result._length = (int) num + 1;
        if (num > 0U)
          Buffer.ZeroMemory((byte*) result.GetBlocksPointer(), (UIntPtr) (num * 4U));
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        ^(int&) ((IntPtr) result._blocks + (IntPtr) ((long) num * 4L)) = 1 << (int) remainder;
      }

      public static unsafe void Pow10(uint exponent, out Number.BigInteger result)
      {
        Number.BigInteger result1;
        Number.BigInteger.SetUInt32(out result1, Number.BigInteger.s_Pow10UInt32Table[(int) exponent & 7]);
        ref Number.BigInteger local1 = ref result1;
        Number.BigInteger result2;
        Number.BigInteger.SetZero(out result2);
        ref Number.BigInteger local2 = ref result2;
        exponent >>= 3;
        uint num = 0;
        for (; exponent != 0U; exponent >>= 1)
        {
          if (((int) exponent & 1) != 0)
          {
            fixed (uint* numPtr = &Number.BigInteger.s_Pow10BigNumTable[Number.BigInteger.s_Pow10BigNumTableIndices[(int) num]])
            {
              // ISSUE: cast to a reference type
              Number.BigInteger.Multiply(ref local1, (Number.BigInteger&) numPtr, out local2);
            }
            ref Number.BigInteger local3 = ref local2;
            local2 = ref local1;
            local1 = ref local3;
          }
          ++num;
        }
        Number.BigInteger.SetValue(out result, ref local1);
      }

      private static unsafe uint AddDivisor(
        ref Number.BigInteger lhs,
        int lhsStartIndex,
        ref Number.BigInteger rhs)
      {
        int length1 = lhs._length;
        int length2 = rhs._length;
        ulong num1 = 0;
        for (int index = 0; index < length2; ++index)
        {
          // ISSUE: explicit reference operation
          ref uint local = @lhs._blocks[lhsStartIndex + index];
          ulong num2 = (ulong) local + num1 + (ulong) rhs._blocks[index];
          local = (uint) num2;
          num1 = num2 >> 32;
        }
        return (uint) num1;
      }

      private static bool DivideGuessTooBig(
        ulong q,
        ulong valHi,
        uint valLo,
        uint divHi,
        uint divLo)
      {
        ulong num1 = (ulong) divHi * q;
        ulong num2 = (ulong) divLo * q;
        ulong num3 = num1 + (num2 >> 32);
        ulong num4 = num2 & (ulong) uint.MaxValue;
        return num3 >= valHi && (num3 > valHi || num4 >= (ulong) valLo && num4 > (ulong) valLo);
      }

      private static unsafe uint SubtractDivisor(
        ref Number.BigInteger lhs,
        int lhsStartIndex,
        ref Number.BigInteger rhs,
        ulong q)
      {
        int num1 = lhs._length - lhsStartIndex;
        int length = rhs._length;
        ulong num2 = 0;
        for (int index = 0; index < length; ++index)
        {
          ulong num3 = num2 + (ulong) rhs._blocks[index] * q;
          uint num4 = (uint) num3;
          num2 = num3 >> 32;
          // ISSUE: explicit reference operation
          ref uint local = @lhs._blocks[lhsStartIndex + index];
          if (local < num4)
            ++num2;
          local -= num4;
        }
        return (uint) num2;
      }

      public unsafe void Add(uint value)
      {
        int length = this._length;
        if (length == 0)
        {
          Number.BigInteger.SetUInt32(out this, value);
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          this._blocks.FixedElementField += value;
          // ISSUE: reference to a compiler-generated field
          if (this._blocks.FixedElementField >= value)
            return;
          for (int index = 1; index < length; ++index)
          {
            ++this._blocks[index];
            if (this._blocks[index] > 0U)
              return;
          }
          this._blocks[length] = 1U;
          this._length = length + 1;
        }
      }

      public unsafe uint GetBlock(uint index) => ^(uint&) ((IntPtr) this._blocks + (IntPtr) ((long) index * 4L));

      public int GetLength() => this._length;

      public bool IsZero() => this._length == 0;

      public void Multiply(uint value) => Number.BigInteger.Multiply(ref this, value, out this);

      public void Multiply(ref Number.BigInteger value)
      {
        if (value._length <= 1)
        {
          Number.BigInteger.Multiply(ref this, value.ToUInt32(), out this);
        }
        else
        {
          Number.BigInteger result;
          Number.BigInteger.SetValue(out result, ref this);
          Number.BigInteger.Multiply(ref result, ref value, out this);
        }
      }

      public unsafe void Multiply10()
      {
        if (this.IsZero())
          return;
        int index = 0;
        int length = this._length;
        ulong num1 = 0;
        do
        {
          ulong num2 = (ulong) this._blocks[index];
          ulong num3 = (ulong) (((long) num2 << 3) + ((long) num2 << 1)) + num1;
          num1 = num3 >> 32;
          this._blocks[index] = (uint) num3;
          ++index;
        }
        while (index < length);
        if (num1 == 0UL)
          return;
        this._blocks[index] = (uint) num1;
        ++this._length;
      }

      public void MultiplyPow10(uint exponent)
      {
        if (exponent <= 9U)
        {
          this.Multiply(Number.BigInteger.s_Pow10UInt32Table[(int) exponent]);
        }
        else
        {
          if (this.IsZero())
            return;
          Number.BigInteger result;
          Number.BigInteger.Pow10(exponent, out result);
          this.Multiply(ref result);
        }
      }

      public static unsafe void SetUInt32(out Number.BigInteger result, uint value)
      {
        if (value == 0U)
        {
          Number.BigInteger.SetZero(out result);
        }
        else
        {
          result._blocks[0] = value;
          result._length = 1;
        }
      }

      public static unsafe void SetUInt64(out Number.BigInteger result, ulong value)
      {
        if (value <= (ulong) uint.MaxValue)
        {
          Number.BigInteger.SetUInt32(out result, (uint) value);
        }
        else
        {
          result._blocks[0] = (uint) value;
          result._blocks[1] = (uint) (value >> 32);
          result._length = 2;
        }
      }

      public static unsafe void SetValue(out Number.BigInteger result, ref Number.BigInteger value)
      {
        int length = value._length;
        result._length = length;
        Buffer.Memcpy((byte*) result.GetBlocksPointer(), (byte*) value.GetBlocksPointer(), length * 4);
      }

      public static void SetZero(out Number.BigInteger result) => result._length = 0;

      public unsafe void ShiftLeft(uint shift)
      {
        int length = this._length;
        if (length == 0 || shift == 0U)
          return;
        uint remainder;
        uint num1 = Number.BigInteger.DivRem32(shift, out remainder);
        int index1 = length - 1;
        int index2 = index1 + (int) num1;
        if (remainder == 0U)
        {
          while (index1 >= 0)
          {
            this._blocks[index2] = this._blocks[index1];
            --index1;
            --index2;
          }
          this._length += (int) num1;
          Buffer.ZeroMemory((byte*) this.GetBlocksPointer(), (UIntPtr) (num1 * 4U));
        }
        else
        {
          int index3 = index2 + 1;
          this._length = index3 + 1;
          uint num2 = 32U - remainder;
          uint num3 = 0;
          uint num4 = this._blocks[index1];
          uint num5 = num4 >> (int) num2;
          while (index1 > 0)
          {
            this._blocks[index3] = num3 | num5;
            num3 = num4 << (int) remainder;
            --index1;
            --index3;
            num4 = this._blocks[index1];
            num5 = num4 >> (int) num2;
          }
          this._blocks[index3] = num3 | num5;
          this._blocks[index3 - 1] = num4 << (int) remainder;
          Buffer.ZeroMemory((byte*) this.GetBlocksPointer(), (UIntPtr) (num1 * 4U));
          if (this._blocks[this._length - 1] != 0U)
            return;
          --this._length;
        }
      }

      public unsafe uint ToUInt32() => this._length > 0 ? this._blocks.FixedElementField : 0U;

      public unsafe ulong ToUInt64()
      {
        if (this._length > 1)
        {
          // ISSUE: reference to a compiler-generated field
          return ((ulong) this._blocks[1] << 32) + (ulong) this._blocks.FixedElementField;
        }
        // ISSUE: reference to a compiler-generated field
        return this._length > 0 ? (ulong) this._blocks.FixedElementField : 0UL;
      }

      private unsafe uint* GetBlocksPointer() => (uint*) Unsafe.AsPointer<uint>(ref this._blocks.FixedElementField);

      private static uint DivRem32(uint value, out uint remainder)
      {
        remainder = value & 31U;
        return value >> 5;
      }
    }

    internal readonly ref struct DiyFp
    {
      public readonly ulong f;
      public readonly int e;

      public static Number.DiyFp CreateAndGetBoundaries(
        double value,
        out Number.DiyFp mMinus,
        out Number.DiyFp mPlus)
      {
        Number.DiyFp diyFp = new Number.DiyFp(value);
        diyFp.GetBoundaries(52, out mMinus, out mPlus);
        return diyFp;
      }

      public static Number.DiyFp CreateAndGetBoundaries(
        float value,
        out Number.DiyFp mMinus,
        out Number.DiyFp mPlus)
      {
        Number.DiyFp diyFp = new Number.DiyFp(value);
        diyFp.GetBoundaries(23, out mMinus, out mPlus);
        return diyFp;
      }

      public static Number.DiyFp CreateAndGetBoundaries(
        Half value,
        out Number.DiyFp mMinus,
        out Number.DiyFp mPlus)
      {
        Number.DiyFp diyFp = new Number.DiyFp(value);
        diyFp.GetBoundaries(10, out mMinus, out mPlus);
        return diyFp;
      }

      public DiyFp(double value) => this.f = Number.ExtractFractionAndBiasedExponent(value, out this.e);

      public DiyFp(float value) => this.f = (ulong) Number.ExtractFractionAndBiasedExponent(value, out this.e);

      public DiyFp(Half value) => this.f = (ulong) Number.ExtractFractionAndBiasedExponent(value, out this.e);

      public DiyFp(ulong f, int e)
      {
        this.f = f;
        this.e = e;
      }

      public Number.DiyFp Multiply(in Number.DiyFp other)
      {
        uint num1 = (uint) (this.f >> 32);
        uint f1 = (uint) this.f;
        uint num2 = (uint) (other.f >> 32);
        uint f2 = (uint) other.f;
        ulong num3 = (ulong) num1 * (ulong) num2;
        ulong num4 = (ulong) f1 * (ulong) num2;
        ulong num5 = (ulong) num1 * (ulong) f2;
        ulong num6 = ((ulong) f1 * (ulong) f2 >> 32) + (ulong) (uint) num5 + (ulong) (uint) num4 + 2147483648UL;
        return new Number.DiyFp(num3 + (num5 >> 32) + (num4 >> 32) + (num6 >> 32), this.e + other.e + 64);
      }

      public Number.DiyFp Normalize()
      {
        int num = BitOperations.LeadingZeroCount(this.f);
        return new Number.DiyFp(this.f << num, this.e - num);
      }

      public Number.DiyFp Subtract(in Number.DiyFp other) => new Number.DiyFp(this.f - other.f, this.e);

      private void GetBoundaries(
        int implicitBitIndex,
        out Number.DiyFp mMinus,
        out Number.DiyFp mPlus)
      {
        mPlus = new Number.DiyFp((this.f << 1) + 1UL, this.e - 1).Normalize();
        mMinus = (long) this.f != 1L << implicitBitIndex ? new Number.DiyFp((this.f << 1) - 1UL, this.e - 1) : new Number.DiyFp((this.f << 2) - 1UL, this.e - 2);
        mMinus = new Number.DiyFp(mMinus.f << mMinus.e - mPlus.e, mPlus.e);
      }
    }

    internal static class Grisu3
    {
      private static readonly short[] s_CachedPowersBinaryExponent = new short[87]
      {
        (short) -1220,
        (short) -1193,
        (short) -1166,
        (short) -1140,
        (short) -1113,
        (short) -1087,
        (short) -1060,
        (short) -1034,
        (short) -1007,
        (short) -980,
        (short) -954,
        (short) -927,
        (short) -901,
        (short) -874,
        (short) -847,
        (short) -821,
        (short) -794,
        (short) -768,
        (short) -741,
        (short) -715,
        (short) -688,
        (short) -661,
        (short) -635,
        (short) -608,
        (short) -582,
        (short) -555,
        (short) -529,
        (short) -502,
        (short) -475,
        (short) -449,
        (short) -422,
        (short) -396,
        (short) -369,
        (short) -343,
        (short) -316,
        (short) -289,
        (short) -263,
        (short) -236,
        (short) -210,
        (short) -183,
        (short) -157,
        (short) -130,
        (short) -103,
        (short) -77,
        (short) -50,
        (short) -24,
        (short) 3,
        (short) 30,
        (short) 56,
        (short) 83,
        (short) 109,
        (short) 136,
        (short) 162,
        (short) 189,
        (short) 216,
        (short) 242,
        (short) 269,
        (short) 295,
        (short) 322,
        (short) 348,
        (short) 375,
        (short) 402,
        (short) 428,
        (short) 455,
        (short) 481,
        (short) 508,
        (short) 534,
        (short) 561,
        (short) 588,
        (short) 614,
        (short) 641,
        (short) 667,
        (short) 694,
        (short) 720,
        (short) 747,
        (short) 774,
        (short) 800,
        (short) 827,
        (short) 853,
        (short) 880,
        (short) 907,
        (short) 933,
        (short) 960,
        (short) 986,
        (short) 1013,
        (short) 1039,
        (short) 1066
      };
      private static readonly short[] s_CachedPowersDecimalExponent = new short[87]
      {
        (short) -348,
        (short) -340,
        (short) -332,
        (short) -324,
        (short) -316,
        (short) -308,
        (short) -300,
        (short) -292,
        (short) -284,
        (short) -276,
        (short) -268,
        (short) -260,
        (short) -252,
        (short) -244,
        (short) -236,
        (short) -228,
        (short) -220,
        (short) -212,
        (short) -204,
        (short) -196,
        (short) -188,
        (short) -180,
        (short) -172,
        (short) -164,
        (short) -156,
        (short) -148,
        (short) -140,
        (short) -132,
        (short) -124,
        (short) -116,
        (short) -108,
        (short) -100,
        (short) -92,
        (short) -84,
        (short) -76,
        (short) -68,
        (short) -60,
        (short) -52,
        (short) -44,
        (short) -36,
        (short) -28,
        (short) -20,
        (short) -12,
        (short) -4,
        (short) 4,
        (short) 12,
        (short) 20,
        (short) 28,
        (short) 36,
        (short) 44,
        (short) 52,
        (short) 60,
        (short) 68,
        (short) 76,
        (short) 84,
        (short) 92,
        (short) 100,
        (short) 108,
        (short) 116,
        (short) 124,
        (short) 132,
        (short) 140,
        (short) 148,
        (short) 156,
        (short) 164,
        (short) 172,
        (short) 180,
        (short) 188,
        (short) 196,
        (short) 204,
        (short) 212,
        (short) 220,
        (short) 228,
        (short) 236,
        (short) 244,
        (short) 252,
        (short) 260,
        (short) 268,
        (short) 276,
        (short) 284,
        (short) 292,
        (short) 300,
        (short) 308,
        (short) 316,
        (short) 324,
        (short) 332,
        (short) 340
      };
      private static readonly ulong[] s_CachedPowersSignificand = new ulong[87]
      {
        18054884314459144840UL,
        13451937075301367670UL,
        10022474136428063862UL,
        14934650266808366570UL,
        11127181549972568877UL,
        16580792590934885855UL,
        12353653155963782858UL,
        18408377700990114895UL,
        13715310171984221708UL,
        10218702384817765436UL,
        15227053142812498563UL,
        11345038669416679861UL,
        16905424996341287883UL,
        12595523146049147757UL,
        9384396036005875287UL,
        13983839803942852151UL,
        10418772551374772303UL,
        15525180923007089351UL,
        11567161174868858868UL,
        17236413322193710309UL,
        12842128665889583758UL,
        9568131466127621947UL,
        14257626930069360058UL,
        10622759856335341974UL,
        15829145694278690180UL,
        11793632577567316726UL,
        17573882009934360870UL,
        13093562431584567480UL,
        9755464219737475723UL,
        14536774485912137811UL,
        10830740992659433045UL,
        16139061738043178685UL,
        12024538023802026127UL,
        17917957937422433684UL,
        13349918974505688015UL,
        9946464728195732843UL,
        14821387422376473014UL,
        11042794154864902060UL,
        16455045573212060422UL,
        12259964326927110867UL,
        18268770466636286478UL,
        13611294676837538539UL,
        10141204801825835212UL,
        15111572745182864684UL,
        11258999068426240000UL,
        16777216000000000000UL,
        12500000000000000000UL,
        9313225746154785156UL,
        13877787807814456755UL,
        10339757656912845936UL,
        15407439555097886824UL,
        11479437019748901445UL,
        17105694144590052135UL,
        12744735289059618216UL,
        9495567745759798747UL,
        14149498560666738074UL,
        10542197943230523224UL,
        15709099088952724970UL,
        11704190886730495818UL,
        17440603504673385349UL,
        12994262207056124023UL,
        9681479787123295682UL,
        14426529090290212157UL,
        10748601772107342003UL,
        16016664761464807395UL,
        11933345169920330789UL,
        17782069995880619868UL,
        13248674568444952270UL,
        9871031767461413346UL,
        14708983551653345445UL,
        10959046745042015199UL,
        16330252207878254650UL,
        12166986024289022870UL,
        18130221999122236476UL,
        13508068024458167312UL,
        10064294952495520794UL,
        14996968138956309548UL,
        11173611982879273257UL,
        16649979327439178909UL,
        12405201291620119593UL,
        9242595204427927429UL,
        13772540099066387757UL,
        10261342003245940623UL,
        15290591125556738113UL,
        11392378155556871081UL,
        16975966327722178521UL,
        12648080533535911531UL
      };
      private static readonly uint[] s_SmallPowersOfTen = new uint[10]
      {
        1U,
        10U,
        100U,
        1000U,
        10000U,
        100000U,
        1000000U,
        10000000U,
        100000000U,
        1000000000U
      };

      public static bool TryRunDouble(
        double value,
        int requestedDigits,
        ref Number.NumberBuffer number)
      {
        double num = double.IsNegative(value) ? -value : value;
        int length;
        int decimalExponent;
        bool flag;
        if (requestedDigits == -1)
        {
          Number.DiyFp boundaryMinus;
          Number.DiyFp boundaryPlus;
          Number.DiyFp w = Number.DiyFp.CreateAndGetBoundaries(num, out boundaryMinus, out boundaryPlus).Normalize();
          flag = Number.Grisu3.TryRunShortest(in boundaryMinus, in w, in boundaryPlus, number.Digits, out length, out decimalExponent);
        }
        else
        {
          Number.DiyFp w = new Number.DiyFp(num).Normalize();
          flag = Number.Grisu3.TryRunCounted(in w, requestedDigits, number.Digits, out length, out decimalExponent);
        }
        if (flag)
        {
          number.Scale = length + decimalExponent;
          number.Digits[length] = (byte) 0;
          number.DigitsCount = length;
        }
        return flag;
      }

      public static bool TryRunHalf(
        Half value,
        int requestedDigits,
        ref Number.NumberBuffer number)
      {
        Half half = Half.IsNegative(value) ? Half.Negate(value) : value;
        int length;
        int decimalExponent;
        bool flag;
        if (requestedDigits == -1)
        {
          Number.DiyFp boundaryMinus;
          Number.DiyFp boundaryPlus;
          Number.DiyFp w = Number.DiyFp.CreateAndGetBoundaries(half, out boundaryMinus, out boundaryPlus).Normalize();
          flag = Number.Grisu3.TryRunShortest(in boundaryMinus, in w, in boundaryPlus, number.Digits, out length, out decimalExponent);
        }
        else
        {
          Number.DiyFp w = new Number.DiyFp(half).Normalize();
          flag = Number.Grisu3.TryRunCounted(in w, requestedDigits, number.Digits, out length, out decimalExponent);
        }
        if (flag)
        {
          number.Scale = length + decimalExponent;
          number.Digits[length] = (byte) 0;
          number.DigitsCount = length;
        }
        return flag;
      }

      public static bool TryRunSingle(
        float value,
        int requestedDigits,
        ref Number.NumberBuffer number)
      {
        float num = float.IsNegative(value) ? -value : value;
        int length;
        int decimalExponent;
        bool flag;
        if (requestedDigits == -1)
        {
          Number.DiyFp boundaryMinus;
          Number.DiyFp boundaryPlus;
          Number.DiyFp w = Number.DiyFp.CreateAndGetBoundaries(num, out boundaryMinus, out boundaryPlus).Normalize();
          flag = Number.Grisu3.TryRunShortest(in boundaryMinus, in w, in boundaryPlus, number.Digits, out length, out decimalExponent);
        }
        else
        {
          Number.DiyFp w = new Number.DiyFp(num).Normalize();
          flag = Number.Grisu3.TryRunCounted(in w, requestedDigits, number.Digits, out length, out decimalExponent);
        }
        if (flag)
        {
          number.Scale = length + decimalExponent;
          number.Digits[length] = (byte) 0;
          number.DigitsCount = length;
        }
        return flag;
      }

      private static bool TryRunCounted(
        in Number.DiyFp w,
        int requestedDigits,
        Span<byte> buffer,
        out int length,
        out int decimalExponent)
      {
        int decimalExponent1;
        Number.DiyFp other = Number.Grisu3.GetCachedPowerForBinaryExponentRange(-60 - (w.e + 64), -32 - (w.e + 64), out decimalExponent1);
        Number.DiyFp w1 = w.Multiply(in other);
        int kappa;
        bool flag = Number.Grisu3.TryDigitGenCounted(in w1, requestedDigits, buffer, out length, out kappa);
        decimalExponent = -decimalExponent1 + kappa;
        return flag;
      }

      private static bool TryRunShortest(
        in Number.DiyFp boundaryMinus,
        in Number.DiyFp w,
        in Number.DiyFp boundaryPlus,
        Span<byte> buffer,
        out int length,
        out int decimalExponent)
      {
        int decimalExponent1;
        Number.DiyFp other = Number.Grisu3.GetCachedPowerForBinaryExponentRange(-60 - (w.e + 64), -32 - (w.e + 64), out decimalExponent1);
        Number.DiyFp w1 = w.Multiply(in other);
        Number.DiyFp low = boundaryMinus.Multiply(in other);
        Number.DiyFp high = boundaryPlus.Multiply(in other);
        int kappa;
        bool flag = Number.Grisu3.TryDigitGenShortest(in low, in w1, in high, buffer, out length, out kappa);
        decimalExponent = -decimalExponent1 + kappa;
        return flag;
      }

      private static uint BiggestPowerTen(uint number, int numberBits, out int exponentPlusOne)
      {
        int index = (numberBits + 1) * 1233 >> 12;
        uint num = Number.Grisu3.s_SmallPowersOfTen[index];
        if (number < num)
        {
          --index;
          num = Number.Grisu3.s_SmallPowersOfTen[index];
        }
        exponentPlusOne = index + 1;
        return num;
      }

      private static bool TryDigitGenCounted(
        in Number.DiyFp w,
        int requestedDigits,
        Span<byte> buffer,
        out int length,
        out int kappa)
      {
        ulong unit = 1;
        Number.DiyFp diyFp = new Number.DiyFp(1UL << -w.e, w.e);
        uint result = (uint) (w.f >> -diyFp.e);
        ulong rest1 = w.f & diyFp.f - 1UL;
        if (rest1 == 0UL && (requestedDigits >= 11 || result < Number.Grisu3.s_SmallPowersOfTen[requestedDigits - 1]))
        {
          length = 0;
          kappa = 0;
          return false;
        }
        uint b = Number.Grisu3.BiggestPowerTen(result, 64 - -diyFp.e, out kappa);
        length = 0;
        while (kappa > 0)
        {
          uint num = Math.DivRem(result, b, out result);
          buffer[length] = (byte) (48U + num);
          ++length;
          --requestedDigits;
          --kappa;
          if (requestedDigits != 0)
            b /= 10U;
          else
            break;
        }
        if (requestedDigits == 0)
        {
          ulong rest2 = ((ulong) result << -diyFp.e) + rest1;
          return Number.Grisu3.TryRoundWeedCounted(buffer, length, rest2, (ulong) b << -diyFp.e, unit, ref kappa);
        }
        ulong num1;
        for (; requestedDigits > 0 && rest1 > unit; rest1 = num1 & diyFp.f - 1UL)
        {
          num1 = rest1 * 10UL;
          unit *= 10UL;
          uint num2 = (uint) (num1 >> -diyFp.e);
          buffer[length] = (byte) (48U + num2);
          ++length;
          --requestedDigits;
          --kappa;
        }
        if (requestedDigits == 0)
          return Number.Grisu3.TryRoundWeedCounted(buffer, length, rest1, diyFp.f, unit, ref kappa);
        buffer[0] = (byte) 0;
        length = 0;
        kappa = 0;
        return false;
      }

      private static bool TryDigitGenShortest(
        in Number.DiyFp low,
        in Number.DiyFp w,
        in Number.DiyFp high,
        Span<byte> buffer,
        out int length,
        out int kappa)
      {
        ulong unit = 1;
        Number.DiyFp other = new Number.DiyFp(low.f - unit, low.e);
        Number.DiyFp diyFp1 = new Number.DiyFp(high.f + unit, high.e);
        Number.DiyFp diyFp2 = diyFp1.Subtract(in other);
        Number.DiyFp diyFp3 = new Number.DiyFp(1UL << -w.e, w.e);
        uint result = (uint) (diyFp1.f >> -diyFp3.e);
        ulong rest1 = diyFp1.f & diyFp3.f - 1UL;
        uint b = Number.Grisu3.BiggestPowerTen(result, 64 - -diyFp3.e, out kappa);
        length = 0;
        while (kappa > 0)
        {
          uint num = Math.DivRem(result, b, out result);
          buffer[length] = (byte) (48U + num);
          ++length;
          --kappa;
          ulong rest2 = ((ulong) result << -diyFp3.e) + rest1;
          if (rest2 < diyFp2.f)
            return Number.Grisu3.TryRoundWeedShortest(buffer, length, diyFp1.Subtract(in w).f, diyFp2.f, rest2, (ulong) b << -diyFp3.e, unit);
          b /= 10U;
        }
        do
        {
          ulong num1 = rest1 * 10UL;
          unit *= 10UL;
          diyFp2 = new Number.DiyFp(diyFp2.f * 10UL, diyFp2.e);
          uint num2 = (uint) (num1 >> -diyFp3.e);
          buffer[length] = (byte) (48U + num2);
          ++length;
          --kappa;
          rest1 = num1 & diyFp3.f - 1UL;
        }
        while (rest1 >= diyFp2.f);
        return Number.Grisu3.TryRoundWeedShortest(buffer, length, diyFp1.Subtract(in w).f * unit, diyFp2.f, rest1, diyFp3.f, unit);
      }

      private static Number.DiyFp GetCachedPowerForBinaryExponentRange(
        int minExponent,
        int maxExponent,
        out int decimalExponent)
      {
        int index = (348 + (int) Math.Ceiling((double) (minExponent + 64 - 1) * 0.3010299956639812) - 1) / 8 + 1;
        decimalExponent = (int) Number.Grisu3.s_CachedPowersDecimalExponent[index];
        return new Number.DiyFp(Number.Grisu3.s_CachedPowersSignificand[index], (int) Number.Grisu3.s_CachedPowersBinaryExponent[index]);
      }

      private static bool TryRoundWeedCounted(
        Span<byte> buffer,
        int length,
        ulong rest,
        ulong tenKappa,
        ulong unit,
        ref int kappa)
      {
        if (unit >= tenKappa || tenKappa - unit <= unit)
          return false;
        if (tenKappa - rest > rest && tenKappa - 2UL * rest >= 2UL * unit)
          return true;
        if (rest <= unit || tenKappa > rest - unit && tenKappa - (rest - unit) > rest - unit)
          return false;
        ++buffer[length - 1];
        for (int index = length - 1; index > 0 && buffer[index] == (byte) 58; --index)
        {
          buffer[index] = (byte) 48;
          ++buffer[index - 1];
        }
        if (buffer[0] == (byte) 58)
        {
          buffer[0] = (byte) 49;
          ++kappa;
        }
        return true;
      }

      private static bool TryRoundWeedShortest(
        Span<byte> buffer,
        int length,
        ulong distanceTooHighW,
        ulong unsafeInterval,
        ulong rest,
        ulong tenKappa,
        ulong unit)
      {
        ulong num1 = distanceTooHighW - unit;
        ulong num2 = distanceTooHighW + unit;
        for (; rest < num1 && unsafeInterval - rest >= tenKappa && (rest + tenKappa < num1 || num1 - rest >= rest + tenKappa - num1); rest += tenKappa)
          --buffer[length - 1];
        return (rest >= num2 || unsafeInterval - rest < tenKappa || rest + tenKappa >= num2 && num2 - rest <= rest + tenKappa - num2) && 2UL * unit <= rest && rest <= unsafeInterval - 4UL * unit;
      }
    }

    internal ref struct NumberBuffer
    {
      public int DigitsCount;
      public int Scale;
      public bool IsNegative;
      public bool HasNonZeroTail;
      public Number.NumberBufferKind Kind;
      public Span<byte> Digits;

      public unsafe NumberBuffer(Number.NumberBufferKind kind, byte* digits, int digitsLength)
      {
        this.DigitsCount = 0;
        this.Scale = 0;
        this.IsNegative = false;
        this.HasNonZeroTail = false;
        this.Kind = kind;
        this.Digits = new Span<byte>((void*) digits, digitsLength);
        this.Digits[0] = (byte) 0;
      }

      public unsafe byte* GetDigitsPointer() => (byte*) Unsafe.AsPointer<byte>(ref this.Digits[0]);

      public override string ToString()
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append('[');
        stringBuilder.Append('"');
        for (int index = 0; index < this.Digits.Length; ++index)
        {
          byte num = this.Digits[index];
          if (num != (byte) 0)
            stringBuilder.Append((char) num);
          else
            break;
        }
        stringBuilder.Append('"');
        stringBuilder.Append(", Length = ").Append(this.DigitsCount);
        stringBuilder.Append(", Scale = ").Append(this.Scale);
        stringBuilder.Append(", IsNegative = ").Append(this.IsNegative);
        stringBuilder.Append(", HasNonZeroTail = ").Append(this.HasNonZeroTail);
        stringBuilder.Append(", Kind = ").Append((object) this.Kind);
        stringBuilder.Append(']');
        return stringBuilder.ToString();
      }
    }

    internal enum NumberBufferKind : byte
    {
      Unknown,
      Integer,
      Decimal,
      FloatingPoint,
    }

    public readonly struct FloatingPointInfo
    {
      public static readonly Number.FloatingPointInfo Double = new Number.FloatingPointInfo((ushort) 52, (ushort) 11, 1023, 1023, 9218868437227405312UL);
      public static readonly Number.FloatingPointInfo Single = new Number.FloatingPointInfo((ushort) 23, (ushort) 8, (int) sbyte.MaxValue, (int) sbyte.MaxValue, 2139095040UL);
      public static readonly Number.FloatingPointInfo Half = new Number.FloatingPointInfo((ushort) 10, (ushort) 5, 15, 15, 31744UL);

      public ulong ZeroBits { get; }

      public ulong InfinityBits { get; }

      public ulong NormalMantissaMask { get; }

      public ulong DenormalMantissaMask { get; }

      public int MinBinaryExponent { get; }

      public int MaxBinaryExponent { get; }

      public int ExponentBias { get; }

      public int OverflowDecimalExponent { get; }

      public ushort NormalMantissaBits { get; }

      public ushort DenormalMantissaBits { get; }

      public FloatingPointInfo(
        ushort denormalMantissaBits,
        ushort exponentBits,
        int maxBinaryExponent,
        int exponentBias,
        ulong infinityBits)
      {
        // ISSUE: reference to a compiler-generated field
        this.\u003CExponentBits\u003Ek__BackingField = exponentBits;
        this.DenormalMantissaBits = denormalMantissaBits;
        this.NormalMantissaBits = (ushort) ((uint) denormalMantissaBits + 1U);
        this.OverflowDecimalExponent = (maxBinaryExponent + 2 * (int) this.NormalMantissaBits) / 3;
        this.ExponentBias = exponentBias;
        this.MaxBinaryExponent = maxBinaryExponent;
        this.MinBinaryExponent = 1 - maxBinaryExponent;
        this.DenormalMantissaMask = (ulong) (1L << (int) denormalMantissaBits) - 1UL;
        this.NormalMantissaMask = (ulong) (1L << (int) this.NormalMantissaBits) - 1UL;
        this.InfinityBits = infinityBits;
        this.ZeroBits = 0UL;
      }
    }

    internal enum ParsingStatus
    {
      OK,
      Failed,
      Overflow,
    }
  }
}
