// Decompiled with JetBrains decompiler
// Type: System.Linq.Enumerable
// Assembly: System.Linq, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: 9A9B426E-FADE-4AFF-AF75-5F6F30F915CC
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.4/System.Linq.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;


#nullable enable
namespace System.Linq
{
  public static class Enumerable
  {
    public static IEnumerable<TResult> Empty<TResult>() => (IEnumerable<TResult>) EmptyPartition<TResult>.Instance;

    private static 
    #nullable disable
    IEnumerable<TSource> SkipIterator<TSource>(IEnumerable<TSource> source, int count) => !(source is IList<TSource> source1) ? (IEnumerable<TSource>) new Enumerable.EnumerablePartition<TSource>(source, count, -1) : (IEnumerable<TSource>) new Enumerable.ListPartition<TSource>(source1, count, int.MaxValue);

    private static IEnumerable<TSource> SkipLastEnumerableFactory<TSource>(
      IEnumerable<TSource> source,
      int count)
    {
      switch (source)
      {
        case IPartition<TSource> partition:
          int count1 = partition.GetCount(true);
          if (count1 >= 0)
            return count1 - count <= 0 ? (IEnumerable<TSource>) EmptyPartition<TSource>.Instance : (IEnumerable<TSource>) partition.Take(count1 - count);
          break;
        case IList<TSource> source1:
          int count2 = source1.Count;
          return count2 <= count ? (IEnumerable<TSource>) EmptyPartition<TSource>.Instance : (IEnumerable<TSource>) new Enumerable.ListPartition<TSource>(source1, 0, count2 - count - 1);
      }
      return Enumerable.SkipLastIterator<TSource>(source, count);
    }

    private static IEnumerable<TSource> TakeIterator<TSource>(
      IEnumerable<TSource> source,
      int count)
    {
      switch (source)
      {
        case IPartition<TSource> partition:
          return (IEnumerable<TSource>) partition.Take(count);
        case IList<TSource> source1:
          return (IEnumerable<TSource>) new Enumerable.ListPartition<TSource>(source1, 0, count - 1);
        default:
          return (IEnumerable<TSource>) new Enumerable.EnumerablePartition<TSource>(source, 0, count - 1);
      }
    }

    private static IEnumerable<TSource> TakeLastEnumerableFactory<TSource>(
      IEnumerable<TSource> source,
      int count)
    {
      switch (source)
      {
        case IPartition<TSource> partition:
          int count1 = partition.GetCount(true);
          if (count1 >= 0)
            return count1 - count <= 0 ? (IEnumerable<TSource>) partition : (IEnumerable<TSource>) partition.Skip(count1 - count);
          break;
        case IList<TSource> source1:
          int count2 = source1.Count;
          return count2 > count ? (IEnumerable<TSource>) new Enumerable.ListPartition<TSource>(source1, count2 - count, count2) : (IEnumerable<TSource>) new Enumerable.ListPartition<TSource>(source1, 0, count2);
      }
      return Enumerable.TakeLastIterator<TSource>(source, count);
    }

    public static 
    #nullable enable
    TSource Aggregate<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, TSource, TSource> func)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (func == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.func);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        TSource source1 = enumerator.Current;
        while (enumerator.MoveNext())
          source1 = func(source1, enumerator.Current);
        return source1;
      }
    }

    public static TAccumulate Aggregate<TSource, TAccumulate>(
      this IEnumerable<TSource> source,
      TAccumulate seed,
      Func<TAccumulate, TSource, TAccumulate> func)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (func == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.func);
      TAccumulate accumulate = seed;
      foreach (TSource source1 in source)
        accumulate = func(accumulate, source1);
      return accumulate;
    }

    public static TResult Aggregate<TSource, TAccumulate, TResult>(
      this IEnumerable<TSource> source,
      TAccumulate seed,
      Func<TAccumulate, TSource, TAccumulate> func,
      Func<TAccumulate, TResult> resultSelector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (func == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.func);
      if (resultSelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.resultSelector);
      TAccumulate accumulate = seed;
      foreach (TSource source1 in source)
        accumulate = func(accumulate, source1);
      return resultSelector(accumulate);
    }

    public static bool Any<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (source is ICollection<TSource> sources)
        return (uint) sources.Count > 0U;
      if (source is IIListProvider<TSource> ilistProvider)
      {
        int count = ilistProvider.GetCount(true);
        if (count >= 0)
          return (uint) count > 0U;
      }
      else if (source is ICollection collection)
        return (uint) collection.Count > 0U;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        return enumerator.MoveNext();
    }

    public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          return true;
      }
      return false;
    }

    public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      foreach (TSource source1 in source)
      {
        if (!predicate(source1))
          return false;
      }
      return true;
    }

    public static IEnumerable<TSource> Append<TSource>(
      this IEnumerable<TSource> source,
      TSource element)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return !(source is Enumerable.AppendPrependIterator<TSource> appendPrependIterator) ? (IEnumerable<TSource>) new Enumerable.AppendPrepend1Iterator<TSource>(source, element, true) : (IEnumerable<TSource>) appendPrependIterator.Append(element);
    }

    public static IEnumerable<TSource> Prepend<TSource>(
      this IEnumerable<TSource> source,
      TSource element)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return !(source is Enumerable.AppendPrependIterator<TSource> appendPrependIterator) ? (IEnumerable<TSource>) new Enumerable.AppendPrepend1Iterator<TSource>(source, element, false) : (IEnumerable<TSource>) appendPrependIterator.Prepend(element);
    }

    public static double Average(this IEnumerable<int> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      using (IEnumerator<int> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        long current = (long) enumerator.Current;
        long num = 1;
        while (enumerator.MoveNext())
        {
          checked { current += (long) enumerator.Current; }
          checked { ++num; }
        }
        return (double) current / (double) num;
      }
    }

    public static double? Average(this IEnumerable<int?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      using (IEnumerator<int?> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          int? current = enumerator.Current;
          if (current.HasValue)
          {
            long valueOrDefault = (long) current.GetValueOrDefault();
            long num = 1;
            while (enumerator.MoveNext())
            {
              current = enumerator.Current;
              if (current.HasValue)
              {
                checked { valueOrDefault += (long) current.GetValueOrDefault(); }
                checked { ++num; }
              }
            }
            return new double?((double) valueOrDefault / (double) num);
          }
        }
      }
      return new double?();
    }

    public static double Average(this IEnumerable<long> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      using (IEnumerator<long> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        long current = enumerator.Current;
        long num = 1;
        while (enumerator.MoveNext())
        {
          checked { current += enumerator.Current; }
          checked { ++num; }
        }
        return (double) current / (double) num;
      }
    }

    public static double? Average(this IEnumerable<long?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      using (IEnumerator<long?> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          long? current = enumerator.Current;
          if (current.HasValue)
          {
            long valueOrDefault = current.GetValueOrDefault();
            long num = 1;
            while (enumerator.MoveNext())
            {
              current = enumerator.Current;
              if (current.HasValue)
              {
                checked { valueOrDefault += current.GetValueOrDefault(); }
                checked { ++num; }
              }
            }
            return new double?((double) valueOrDefault / (double) num);
          }
        }
      }
      return new double?();
    }

    public static float Average(this IEnumerable<float> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      using (IEnumerator<float> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        double current = (double) enumerator.Current;
        long num = 1;
        while (enumerator.MoveNext())
        {
          current += (double) enumerator.Current;
          ++num;
        }
        return (float) current / (float) num;
      }
    }

    public static float? Average(this IEnumerable<float?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      using (IEnumerator<float?> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          float? current = enumerator.Current;
          if (current.HasValue)
          {
            double valueOrDefault = (double) current.GetValueOrDefault();
            long num = 1;
            while (enumerator.MoveNext())
            {
              current = enumerator.Current;
              if (current.HasValue)
              {
                valueOrDefault += (double) current.GetValueOrDefault();
                checked { ++num; }
              }
            }
            return new float?((float) valueOrDefault / (float) num);
          }
        }
      }
      return new float?();
    }

    public static double Average(this IEnumerable<double> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      using (IEnumerator<double> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        double current = enumerator.Current;
        long num = 1;
        while (enumerator.MoveNext())
        {
          current += enumerator.Current;
          ++num;
        }
        return current / (double) num;
      }
    }

    public static double? Average(this IEnumerable<double?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      using (IEnumerator<double?> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          double? current = enumerator.Current;
          if (current.HasValue)
          {
            double valueOrDefault = current.GetValueOrDefault();
            long num = 1;
            while (enumerator.MoveNext())
            {
              current = enumerator.Current;
              if (current.HasValue)
              {
                valueOrDefault += current.GetValueOrDefault();
                checked { ++num; }
              }
            }
            return new double?(valueOrDefault / (double) num);
          }
        }
      }
      return new double?();
    }

    public static Decimal Average(this IEnumerable<Decimal> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      using (IEnumerator<Decimal> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        Decimal current = enumerator.Current;
        long num = 1;
        while (enumerator.MoveNext())
        {
          current += enumerator.Current;
          ++num;
        }
        return current / (Decimal) num;
      }
    }

    public static Decimal? Average(this IEnumerable<Decimal?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      using (IEnumerator<Decimal?> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          Decimal? current = enumerator.Current;
          if (current.HasValue)
          {
            Decimal valueOrDefault = current.GetValueOrDefault();
            long num = 1;
            while (enumerator.MoveNext())
            {
              current = enumerator.Current;
              if (current.HasValue)
              {
                valueOrDefault += current.GetValueOrDefault();
                ++num;
              }
            }
            return new Decimal?(valueOrDefault / (Decimal) num);
          }
        }
      }
      return new Decimal?();
    }

    public static double Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, int> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        long num1 = (long) selector(enumerator.Current);
        long num2 = 1;
        while (enumerator.MoveNext())
        {
          checked { num1 += (long) selector(enumerator.Current); }
          checked { ++num2; }
        }
        return (double) num1 / (double) num2;
      }
    }

    public static double? Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, int?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          int? nullable = selector(enumerator.Current);
          if (nullable.HasValue)
          {
            long valueOrDefault = (long) nullable.GetValueOrDefault();
            long num = 1;
            while (enumerator.MoveNext())
            {
              nullable = selector(enumerator.Current);
              if (nullable.HasValue)
              {
                checked { valueOrDefault += (long) nullable.GetValueOrDefault(); }
                checked { ++num; }
              }
            }
            return new double?((double) valueOrDefault / (double) num);
          }
        }
      }
      return new double?();
    }

    public static double Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, long> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        long num1 = selector(enumerator.Current);
        long num2 = 1;
        while (enumerator.MoveNext())
        {
          checked { num1 += selector(enumerator.Current); }
          checked { ++num2; }
        }
        return (double) num1 / (double) num2;
      }
    }

    public static double? Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, long?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          long? nullable = selector(enumerator.Current);
          if (nullable.HasValue)
          {
            long valueOrDefault = nullable.GetValueOrDefault();
            long num = 1;
            while (enumerator.MoveNext())
            {
              nullable = selector(enumerator.Current);
              if (nullable.HasValue)
              {
                checked { valueOrDefault += nullable.GetValueOrDefault(); }
                checked { ++num; }
              }
            }
            return new double?((double) valueOrDefault / (double) num);
          }
        }
      }
      return new double?();
    }

    public static float Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        double num1 = (double) selector(enumerator.Current);
        long num2 = 1;
        while (enumerator.MoveNext())
        {
          num1 += (double) selector(enumerator.Current);
          ++num2;
        }
        return (float) num1 / (float) num2;
      }
    }

    public static float? Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          float? nullable = selector(enumerator.Current);
          if (nullable.HasValue)
          {
            double valueOrDefault = (double) nullable.GetValueOrDefault();
            long num = 1;
            while (enumerator.MoveNext())
            {
              nullable = selector(enumerator.Current);
              if (nullable.HasValue)
              {
                valueOrDefault += (double) nullable.GetValueOrDefault();
                checked { ++num; }
              }
            }
            return new float?((float) valueOrDefault / (float) num);
          }
        }
      }
      return new float?();
    }

    public static double Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        double num1 = selector(enumerator.Current);
        long num2 = 1;
        while (enumerator.MoveNext())
        {
          num1 += selector(enumerator.Current);
          ++num2;
        }
        return num1 / (double) num2;
      }
    }

    public static double? Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          double? nullable = selector(enumerator.Current);
          if (nullable.HasValue)
          {
            double valueOrDefault = nullable.GetValueOrDefault();
            long num = 1;
            while (enumerator.MoveNext())
            {
              nullable = selector(enumerator.Current);
              if (nullable.HasValue)
              {
                valueOrDefault += nullable.GetValueOrDefault();
                checked { ++num; }
              }
            }
            return new double?(valueOrDefault / (double) num);
          }
        }
      }
      return new double?();
    }

    public static Decimal Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        Decimal num1 = selector(enumerator.Current);
        long num2 = 1;
        while (enumerator.MoveNext())
        {
          num1 += selector(enumerator.Current);
          ++num2;
        }
        return num1 / (Decimal) num2;
      }
    }

    public static Decimal? Average<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          Decimal? nullable = selector(enumerator.Current);
          if (nullable.HasValue)
          {
            Decimal valueOrDefault = nullable.GetValueOrDefault();
            long num = 1;
            while (enumerator.MoveNext())
            {
              nullable = selector(enumerator.Current);
              if (nullable.HasValue)
              {
                valueOrDefault += nullable.GetValueOrDefault();
                ++num;
              }
            }
            return new Decimal?(valueOrDefault / (Decimal) num);
          }
        }
      }
      return new Decimal?();
    }

    public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return Enumerable.OfTypeIterator<TResult>(source);
    }

    private static 
    #nullable disable
    IEnumerable<TResult> OfTypeIterator<TResult>(IEnumerable source)
    {
      foreach (object obj in source)
      {
        if (obj is TResult result)
          yield return result;
      }
    }

    public static 
    #nullable enable
    IEnumerable<
    #nullable disable
    TResult> Cast<TResult>(this 
    #nullable enable
    IEnumerable source)
    {
      if (source is IEnumerable<TResult> results)
        return results;
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return Enumerable.CastIterator<TResult>(source);
    }

    private static 
    #nullable disable
    IEnumerable<TResult> CastIterator<TResult>(IEnumerable source)
    {
      foreach (TResult result in source)
        yield return result;
    }

    public static 
    #nullable enable
    IEnumerable<TSource> Concat<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second)
    {
      if (first == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
      if (second == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
      return !(first is Enumerable.ConcatIterator<TSource> concatIterator) ? (IEnumerable<TSource>) new Enumerable.Concat2Iterator<TSource>(first, second) : (IEnumerable<TSource>) concatIterator.Concat(second);
    }

    public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value) => !(source is ICollection<TSource> sources) ? source.Contains<TSource>(value, (IEqualityComparer<TSource>) null) : sources.Contains(value);

    public static bool Contains<TSource>(
      this IEnumerable<TSource> source,
      TSource value,
      IEqualityComparer<TSource>? comparer)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (comparer == null)
      {
        foreach (TSource x in source)
        {
          if (EqualityComparer<TSource>.Default.Equals(x, value))
            return true;
        }
      }
      else
      {
        foreach (TSource x in source)
        {
          if (comparer.Equals(x, value))
            return true;
        }
      }
      return false;
    }

    public static int Count<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (source is ICollection<TSource> sources)
        return sources.Count;
      if (source is IIListProvider<TSource> ilistProvider)
        return ilistProvider.GetCount(false);
      if (source is ICollection collection)
        return collection.Count;
      int num = 0;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
          checked { ++num; }
      }
      return num;
    }

    public static int Count<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      int num = 0;
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          checked { ++num; }
      }
      return num;
    }

    public static long LongCount<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      long num = 0;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
          checked { ++num; }
      }
      return num;
    }

    public static long LongCount<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      long num = 0;
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          checked { ++num; }
      }
      return num;
    }

    public static IEnumerable<TSource?> DefaultIfEmpty<TSource>(
      this IEnumerable<TSource> source)
    {
      return source.DefaultIfEmpty<TSource>(default (TSource));
    }

    public static IEnumerable<TSource> DefaultIfEmpty<TSource>(
      this IEnumerable<TSource> source,
      TSource defaultValue)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return (IEnumerable<TSource>) new Enumerable.DefaultIfEmptyIterator<TSource>(source, defaultValue);
    }

    public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source) => source.Distinct<TSource>((IEqualityComparer<TSource>) null);

    public static IEnumerable<TSource> Distinct<TSource>(
      this IEnumerable<TSource> source,
      IEqualityComparer<TSource>? comparer)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return (IEnumerable<TSource>) new Enumerable.DistinctIterator<TSource>(source, comparer);
    }

    public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (source is IPartition<TSource> partition)
      {
        bool found;
        TSource elementAt = partition.TryGetElementAt(index, out found);
        if (found)
          return elementAt;
      }
      else
      {
        if (source is IList<TSource> sourceList)
          return sourceList[index];
        if (index >= 0)
        {
          foreach (TSource source1 in source)
          {
            if (index == 0)
              return source1;
            --index;
          }
        }
      }
      ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index);
      return default (TSource);
    }

    public static TSource? ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (source is IPartition<TSource> partition)
        return partition.TryGetElementAt(index, out bool _);
      if (index >= 0)
      {
        if (source is IList<TSource> sourceList)
        {
          if (index < sourceList.Count)
            return sourceList[index];
        }
        else
        {
          foreach (TSource source1 in source)
          {
            if (index == 0)
              return source1;
            --index;
          }
        }
      }
      return default (TSource);
    }

    public static IEnumerable<TSource> AsEnumerable<TSource>(
      this IEnumerable<TSource> source)
    {
      return source;
    }

    public static IEnumerable<TSource> Except<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second)
    {
      if (first == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
      if (second == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
      return Enumerable.ExceptIterator<TSource>(first, second, (IEqualityComparer<TSource>) null);
    }

    public static IEnumerable<TSource> Except<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource>? comparer)
    {
      if (first == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
      if (second == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
      return Enumerable.ExceptIterator<TSource>(first, second, comparer);
    }

    private static 
    #nullable disable
    IEnumerable<TSource> ExceptIterator<TSource>(
      IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource> comparer)
    {
      Set<TSource> set = new Set<TSource>(comparer);
      set.UnionWith(second);
      foreach (TSource source in first)
      {
        if (set.Add(source))
          yield return source;
      }
    }

    public static 
    #nullable enable
    TSource First<TSource>(this IEnumerable<TSource> source)
    {
      bool found;
      TSource first = source.TryGetFirst<TSource>(out found);
      if (!found)
        ThrowHelper.ThrowNoElementsException();
      return first;
    }

    public static TSource First<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      bool found;
      TSource first = source.TryGetFirst<TSource>(predicate, out found);
      if (!found)
        ThrowHelper.ThrowNoMatchException();
      return first;
    }

    public static TSource? FirstOrDefault<TSource>(this IEnumerable<TSource> source) => source.TryGetFirst<TSource>(out bool _);

    public static TSource? FirstOrDefault<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      return source.TryGetFirst<TSource>(predicate, out bool _);
    }

    private static 
    #nullable disable
    TSource TryGetFirst<TSource>(this IEnumerable<TSource> source, out bool found)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (source is IPartition<TSource> partition)
        return partition.TryGetFirst(out found);
      if (source is IList<TSource> sourceList)
      {
        if (sourceList.Count > 0)
        {
          found = true;
          return sourceList[0];
        }
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (enumerator.MoveNext())
          {
            found = true;
            return enumerator.Current;
          }
        }
      }
      found = false;
      return default (TSource);
    }

    private static TSource TryGetFirst<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate,
      out bool found)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
        {
          found = true;
          return source1;
        }
      }
      found = false;
      return default (TSource);
    }

    public static 
    #nullable enable
    IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      return (IEnumerable<IGrouping<TKey, TSource>>) new GroupedEnumerable<TSource, TKey>(source, keySelector, (IEqualityComparer<TKey>) null);
    }

    public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IEqualityComparer<TKey>? comparer)
    {
      return (IEnumerable<IGrouping<TKey, TSource>>) new GroupedEnumerable<TSource, TKey>(source, keySelector, comparer);
    }

    public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector)
    {
      return (IEnumerable<IGrouping<TKey, TElement>>) new GroupedEnumerable<TSource, TKey, TElement>(source, keySelector, elementSelector, (IEqualityComparer<TKey>) null);
    }

    public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey>? comparer)
    {
      return (IEnumerable<IGrouping<TKey, TElement>>) new GroupedEnumerable<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer);
    }

    public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
    {
      return (IEnumerable<TResult>) new GroupedResultEnumerable<TSource, TKey, TResult>(source, keySelector, resultSelector, (IEqualityComparer<TKey>) null);
    }

    public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
    {
      return (IEnumerable<TResult>) new GroupedResultEnumerable<TSource, TKey, TElement, TResult>(source, keySelector, elementSelector, resultSelector, (IEqualityComparer<TKey>) null);
    }

    public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
      IEqualityComparer<TKey>? comparer)
    {
      return (IEnumerable<TResult>) new GroupedResultEnumerable<TSource, TKey, TResult>(source, keySelector, resultSelector, comparer);
    }

    public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
      IEqualityComparer<TKey>? comparer)
    {
      return (IEnumerable<TResult>) new GroupedResultEnumerable<TSource, TKey, TElement, TResult>(source, keySelector, elementSelector, resultSelector, comparer);
    }

    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
      this IEnumerable<TOuter> outer,
      IEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
    {
      if (outer == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.outer);
      if (inner == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.inner);
      if (outerKeySelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.outerKeySelector);
      if (innerKeySelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.innerKeySelector);
      if (resultSelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.resultSelector);
      return Enumerable.GroupJoinIterator<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, (IEqualityComparer<TKey>) null);
    }

    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
      this IEnumerable<TOuter> outer,
      IEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
      IEqualityComparer<TKey>? comparer)
    {
      if (outer == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.outer);
      if (inner == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.inner);
      if (outerKeySelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.outerKeySelector);
      if (innerKeySelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.innerKeySelector);
      if (resultSelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.resultSelector);
      return Enumerable.GroupJoinIterator<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
    }

    private static 
    #nullable disable
    IEnumerable<TResult> GroupJoinIterator<TOuter, TInner, TKey, TResult>(
      IEnumerable<TOuter> outer,
      IEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      using (IEnumerator<TOuter> e = outer.GetEnumerator())
      {
        if (e.MoveNext())
        {
          Lookup<TKey, TInner> lookup = Lookup<TKey, TInner>.CreateForJoin(inner, innerKeySelector, comparer);
          do
          {
            TOuter current = e.Current;
            yield return resultSelector(current, lookup[outerKeySelector(current)]);
          }
          while (e.MoveNext());
          lookup = (Lookup<TKey, TInner>) null;
        }
      }
    }

    public static 
    #nullable enable
    IEnumerable<TSource> Intersect<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second)
    {
      if (first == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
      if (second == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
      return Enumerable.IntersectIterator<TSource>(first, second, (IEqualityComparer<TSource>) null);
    }

    public static IEnumerable<TSource> Intersect<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource>? comparer)
    {
      if (first == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
      if (second == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
      return Enumerable.IntersectIterator<TSource>(first, second, comparer);
    }

    private static 
    #nullable disable
    IEnumerable<TSource> IntersectIterator<TSource>(
      IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource> comparer)
    {
      Set<TSource> set = new Set<TSource>(comparer);
      set.UnionWith(second);
      foreach (TSource source in first)
      {
        if (set.Remove(source))
          yield return source;
      }
    }

    public static 
    #nullable enable
    IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
      this IEnumerable<TOuter> outer,
      IEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, TInner, TResult> resultSelector)
    {
      if (outer == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.outer);
      if (inner == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.inner);
      if (outerKeySelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.outerKeySelector);
      if (innerKeySelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.innerKeySelector);
      if (resultSelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.resultSelector);
      return Enumerable.JoinIterator<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, (IEqualityComparer<TKey>) null);
    }

    public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
      this IEnumerable<TOuter> outer,
      IEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, TInner, TResult> resultSelector,
      IEqualityComparer<TKey>? comparer)
    {
      if (outer == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.outer);
      if (inner == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.inner);
      if (outerKeySelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.outerKeySelector);
      if (innerKeySelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.innerKeySelector);
      if (resultSelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.resultSelector);
      return Enumerable.JoinIterator<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
    }

    private static 
    #nullable disable
    IEnumerable<TResult> JoinIterator<TOuter, TInner, TKey, TResult>(
      IEnumerable<TOuter> outer,
      IEnumerable<TInner> inner,
      Func<TOuter, TKey> outerKeySelector,
      Func<TInner, TKey> innerKeySelector,
      Func<TOuter, TInner, TResult> resultSelector,
      IEqualityComparer<TKey> comparer)
    {
      using (IEnumerator<TOuter> e = outer.GetEnumerator())
      {
        if (e.MoveNext())
        {
          Lookup<TKey, TInner> lookup = Lookup<TKey, TInner>.CreateForJoin(inner, innerKeySelector, comparer);
          if (lookup.Count != 0)
          {
            do
            {
              TOuter item = e.Current;
              Grouping<TKey, TInner> grouping = lookup.GetGrouping(outerKeySelector(item), false);
              if (grouping != null)
              {
                int count = grouping._count;
                TInner[] elements = grouping._elements;
                for (int i = 0; i != count; ++i)
                  yield return resultSelector(item, elements[i]);
                elements = (TInner[]) null;
              }
              item = default (TOuter);
            }
            while (e.MoveNext());
          }
          lookup = (Lookup<TKey, TInner>) null;
        }
      }
    }

    public static 
    #nullable enable
    TSource Last<TSource>(this IEnumerable<TSource> source)
    {
      bool found;
      TSource last = source.TryGetLast<TSource>(out found);
      if (!found)
        ThrowHelper.ThrowNoElementsException();
      return last;
    }

    public static TSource Last<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      bool found;
      TSource last = source.TryGetLast<TSource>(predicate, out found);
      if (!found)
        ThrowHelper.ThrowNoMatchException();
      return last;
    }

    public static TSource? LastOrDefault<TSource>(this IEnumerable<TSource> source) => source.TryGetLast<TSource>(out bool _);

    public static TSource? LastOrDefault<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      return source.TryGetLast<TSource>(predicate, out bool _);
    }

    private static 
    #nullable disable
    TSource TryGetLast<TSource>(this IEnumerable<TSource> source, out bool found)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (source is IPartition<TSource> partition)
        return partition.TryGetLast(out found);
      if (source is IList<TSource> sourceList)
      {
        int count = sourceList.Count;
        if (count > 0)
        {
          found = true;
          return sourceList[count - 1];
        }
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (enumerator.MoveNext())
          {
            TSource current;
            do
            {
              current = enumerator.Current;
            }
            while (enumerator.MoveNext());
            found = true;
            return current;
          }
        }
      }
      found = false;
      return default (TSource);
    }

    private static TSource TryGetLast<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate,
      out bool found)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      switch (source)
      {
        case OrderedEnumerable<TSource> orderedEnumerable:
          return orderedEnumerable.TryGetLast(predicate, out found);
        case IList<TSource> sourceList:
          for (int index = sourceList.Count - 1; index >= 0; --index)
          {
            TSource source1 = sourceList[index];
            if (predicate(source1))
            {
              found = true;
              return source1;
            }
          }
          break;
        default:
          using (IEnumerator<TSource> enumerator = source.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              TSource source1 = enumerator.Current;
              if (predicate(source1))
              {
                while (enumerator.MoveNext())
                {
                  TSource current = enumerator.Current;
                  if (predicate(current))
                    source1 = current;
                }
                found = true;
                return source1;
              }
            }
            break;
          }
      }
      found = false;
      return default (TSource);
    }

    public static 
    #nullable enable
    ILookup<TKey, TSource> ToLookup<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      return source.ToLookup<TSource, TKey>(keySelector, (IEqualityComparer<TKey>) null);
    }

    public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IEqualityComparer<TKey>? comparer)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (keySelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
      return (ILookup<TKey, TSource>) Lookup<TKey, TSource>.Create(source, keySelector, comparer);
    }

    public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector)
    {
      return source.ToLookup<TSource, TKey, TElement>(keySelector, elementSelector, (IEqualityComparer<TKey>) null);
    }

    public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey>? comparer)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (keySelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
      if (elementSelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.elementSelector);
      return (ILookup<TKey, TElement>) Lookup<TKey, TElement>.Create<TSource>(source, keySelector, elementSelector, comparer);
    }

    public static int Max(this IEnumerable<int> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      int num;
      using (IEnumerator<int> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        num = enumerator.Current;
        while (enumerator.MoveNext())
        {
          int current = enumerator.Current;
          if (current > num)
            num = current;
        }
      }
      return num;
    }

    public static int? Max(this IEnumerable<int?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      int? nullable = new int?();
      using (IEnumerator<int?> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable;
          nullable = enumerator.Current;
        }
        while (!nullable.HasValue);
        int num = nullable.GetValueOrDefault();
        if (num >= 0)
        {
          while (enumerator.MoveNext())
          {
            int? current = enumerator.Current;
            int valueOrDefault = current.GetValueOrDefault();
            if (valueOrDefault > num)
            {
              num = valueOrDefault;
              nullable = current;
            }
          }
        }
        else
        {
          while (enumerator.MoveNext())
          {
            int? current = enumerator.Current;
            int valueOrDefault = current.GetValueOrDefault();
            if (current.HasValue & valueOrDefault > num)
            {
              num = valueOrDefault;
              nullable = current;
            }
          }
        }
      }
      return nullable;
    }

    public static long Max(this IEnumerable<long> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      long num;
      using (IEnumerator<long> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        num = enumerator.Current;
        while (enumerator.MoveNext())
        {
          long current = enumerator.Current;
          if (current > num)
            num = current;
        }
      }
      return num;
    }

    public static long? Max(this IEnumerable<long?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      long? nullable = new long?();
      using (IEnumerator<long?> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable;
          nullable = enumerator.Current;
        }
        while (!nullable.HasValue);
        long num = nullable.GetValueOrDefault();
        if (num >= 0L)
        {
          while (enumerator.MoveNext())
          {
            long? current = enumerator.Current;
            long valueOrDefault = current.GetValueOrDefault();
            if (valueOrDefault > num)
            {
              num = valueOrDefault;
              nullable = current;
            }
          }
        }
        else
        {
          while (enumerator.MoveNext())
          {
            long? current = enumerator.Current;
            long valueOrDefault = current.GetValueOrDefault();
            if (current.HasValue & valueOrDefault > num)
            {
              num = valueOrDefault;
              nullable = current;
            }
          }
        }
      }
      return nullable;
    }

    public static double Max(this IEnumerable<double> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      double d;
      using (IEnumerator<double> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        for (d = enumerator.Current; double.IsNaN(d); d = enumerator.Current)
        {
          if (!enumerator.MoveNext())
            return d;
        }
        while (enumerator.MoveNext())
        {
          double current = enumerator.Current;
          if (current > d)
            d = current;
        }
      }
      return d;
    }

    public static double? Max(this IEnumerable<double?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      double? nullable = new double?();
      using (IEnumerator<double?> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable;
          nullable = enumerator.Current;
        }
        while (!nullable.HasValue);
        double d = nullable.GetValueOrDefault();
        while (double.IsNaN(d))
        {
          if (!enumerator.MoveNext())
            return nullable;
          double? current = enumerator.Current;
          if (current.HasValue)
            d = (nullable = current).GetValueOrDefault();
        }
        while (enumerator.MoveNext())
        {
          double? current = enumerator.Current;
          double valueOrDefault = current.GetValueOrDefault();
          if (current.HasValue & valueOrDefault > d)
          {
            d = valueOrDefault;
            nullable = current;
          }
        }
      }
      return nullable;
    }

    public static float Max(this IEnumerable<float> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      float f;
      using (IEnumerator<float> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        for (f = enumerator.Current; float.IsNaN(f); f = enumerator.Current)
        {
          if (!enumerator.MoveNext())
            return f;
        }
        while (enumerator.MoveNext())
        {
          float current = enumerator.Current;
          if ((double) current > (double) f)
            f = current;
        }
      }
      return f;
    }

    public static float? Max(this IEnumerable<float?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      float? nullable = new float?();
      using (IEnumerator<float?> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable;
          nullable = enumerator.Current;
        }
        while (!nullable.HasValue);
        float f = nullable.GetValueOrDefault();
        while (float.IsNaN(f))
        {
          if (!enumerator.MoveNext())
            return nullable;
          float? current = enumerator.Current;
          if (current.HasValue)
            f = (nullable = current).GetValueOrDefault();
        }
        while (enumerator.MoveNext())
        {
          float? current = enumerator.Current;
          float valueOrDefault = current.GetValueOrDefault();
          if (current.HasValue & (double) valueOrDefault > (double) f)
          {
            f = valueOrDefault;
            nullable = current;
          }
        }
      }
      return nullable;
    }

    public static Decimal Max(this IEnumerable<Decimal> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      Decimal num;
      using (IEnumerator<Decimal> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        num = enumerator.Current;
        while (enumerator.MoveNext())
        {
          Decimal current = enumerator.Current;
          if (current > num)
            num = current;
        }
      }
      return num;
    }

    public static Decimal? Max(this IEnumerable<Decimal?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      Decimal? nullable = new Decimal?();
      using (IEnumerator<Decimal?> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable;
          nullable = enumerator.Current;
        }
        while (!nullable.HasValue);
        Decimal num = nullable.GetValueOrDefault();
        while (enumerator.MoveNext())
        {
          Decimal? current = enumerator.Current;
          Decimal valueOrDefault = current.GetValueOrDefault();
          if (current.HasValue && valueOrDefault > num)
          {
            num = valueOrDefault;
            nullable = current;
          }
        }
      }
      return nullable;
    }

    public static TSource? Max<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      Comparer<TSource> comparer = Comparer<TSource>.Default;
      TSource y = default (TSource);
      if ((object) y == null)
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            y = enumerator.Current;
            if ((object) y != null)
            {
              while (enumerator.MoveNext())
              {
                TSource current = enumerator.Current;
                if ((object) current != null && comparer.Compare(current, y) > 0)
                  y = current;
              }
              goto label_23;
            }
          }
          return y;
        }
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (!enumerator.MoveNext())
            ThrowHelper.ThrowNoElementsException();
          y = enumerator.Current;
          while (enumerator.MoveNext())
          {
            TSource current = enumerator.Current;
            if (comparer.Compare(current, y) > 0)
              y = current;
          }
        }
      }
label_23:
      return y;
    }

    public static int Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      int num1;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        num1 = selector(enumerator.Current);
        while (enumerator.MoveNext())
        {
          int num2 = selector(enumerator.Current);
          if (num2 > num1)
            num1 = num2;
        }
      }
      return num1;
    }

    public static int? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      int? nullable1 = new int?();
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable1;
          nullable1 = selector(enumerator.Current);
        }
        while (!nullable1.HasValue);
        int num = nullable1.GetValueOrDefault();
        if (num >= 0)
        {
          while (enumerator.MoveNext())
          {
            int? nullable2 = selector(enumerator.Current);
            int valueOrDefault = nullable2.GetValueOrDefault();
            if (valueOrDefault > num)
            {
              num = valueOrDefault;
              nullable1 = nullable2;
            }
          }
        }
        else
        {
          while (enumerator.MoveNext())
          {
            int? nullable2 = selector(enumerator.Current);
            int valueOrDefault = nullable2.GetValueOrDefault();
            if (nullable2.HasValue & valueOrDefault > num)
            {
              num = valueOrDefault;
              nullable1 = nullable2;
            }
          }
        }
      }
      return nullable1;
    }

    public static long Max<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      long num1;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        num1 = selector(enumerator.Current);
        while (enumerator.MoveNext())
        {
          long num2 = selector(enumerator.Current);
          if (num2 > num1)
            num1 = num2;
        }
      }
      return num1;
    }

    public static long? Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, long?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      long? nullable1 = new long?();
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable1;
          nullable1 = selector(enumerator.Current);
        }
        while (!nullable1.HasValue);
        long num = nullable1.GetValueOrDefault();
        if (num >= 0L)
        {
          while (enumerator.MoveNext())
          {
            long? nullable2 = selector(enumerator.Current);
            long valueOrDefault = nullable2.GetValueOrDefault();
            if (valueOrDefault > num)
            {
              num = valueOrDefault;
              nullable1 = nullable2;
            }
          }
        }
        else
        {
          while (enumerator.MoveNext())
          {
            long? nullable2 = selector(enumerator.Current);
            long valueOrDefault = nullable2.GetValueOrDefault();
            if (nullable2.HasValue & valueOrDefault > num)
            {
              num = valueOrDefault;
              nullable1 = nullable2;
            }
          }
        }
      }
      return nullable1;
    }

    public static float Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      float f;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        for (f = selector(enumerator.Current); float.IsNaN(f); f = selector(enumerator.Current))
        {
          if (!enumerator.MoveNext())
            return f;
        }
        while (enumerator.MoveNext())
        {
          float num = selector(enumerator.Current);
          if ((double) num > (double) f)
            f = num;
        }
      }
      return f;
    }

    public static float? Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      float? nullable1 = new float?();
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable1;
          nullable1 = selector(enumerator.Current);
        }
        while (!nullable1.HasValue);
        float f = nullable1.GetValueOrDefault();
        while (float.IsNaN(f))
        {
          if (!enumerator.MoveNext())
            return nullable1;
          float? nullable2 = selector(enumerator.Current);
          if (nullable2.HasValue)
            f = (nullable1 = nullable2).GetValueOrDefault();
        }
        while (enumerator.MoveNext())
        {
          float? nullable2 = selector(enumerator.Current);
          float valueOrDefault = nullable2.GetValueOrDefault();
          if (nullable2.HasValue & (double) valueOrDefault > (double) f)
          {
            f = valueOrDefault;
            nullable1 = nullable2;
          }
        }
      }
      return nullable1;
    }

    public static double Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      double d;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        for (d = selector(enumerator.Current); double.IsNaN(d); d = selector(enumerator.Current))
        {
          if (!enumerator.MoveNext())
            return d;
        }
        while (enumerator.MoveNext())
        {
          double num = selector(enumerator.Current);
          if (num > d)
            d = num;
        }
      }
      return d;
    }

    public static double? Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      double? nullable1 = new double?();
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable1;
          nullable1 = selector(enumerator.Current);
        }
        while (!nullable1.HasValue);
        double d = nullable1.GetValueOrDefault();
        while (double.IsNaN(d))
        {
          if (!enumerator.MoveNext())
            return nullable1;
          double? nullable2 = selector(enumerator.Current);
          if (nullable2.HasValue)
            d = (nullable1 = nullable2).GetValueOrDefault();
        }
        while (enumerator.MoveNext())
        {
          double? nullable2 = selector(enumerator.Current);
          double valueOrDefault = nullable2.GetValueOrDefault();
          if (nullable2.HasValue & valueOrDefault > d)
          {
            d = valueOrDefault;
            nullable1 = nullable2;
          }
        }
      }
      return nullable1;
    }

    public static Decimal Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      Decimal num1;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        num1 = selector(enumerator.Current);
        while (enumerator.MoveNext())
        {
          Decimal num2 = selector(enumerator.Current);
          if (num2 > num1)
            num1 = num2;
        }
      }
      return num1;
    }

    public static Decimal? Max<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      Decimal? nullable1 = new Decimal?();
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable1;
          nullable1 = selector(enumerator.Current);
        }
        while (!nullable1.HasValue);
        Decimal num = nullable1.GetValueOrDefault();
        while (enumerator.MoveNext())
        {
          Decimal? nullable2 = selector(enumerator.Current);
          Decimal valueOrDefault = nullable2.GetValueOrDefault();
          if (nullable2.HasValue && valueOrDefault > num)
          {
            num = valueOrDefault;
            nullable1 = nullable2;
          }
        }
      }
      return nullable1;
    }

    public static TResult? Max<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TResult> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      Comparer<TResult> comparer = Comparer<TResult>.Default;
      TResult y = default (TResult);
      if ((object) y == null)
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            y = selector(enumerator.Current);
            if ((object) y != null)
            {
              while (enumerator.MoveNext())
              {
                TResult x = selector(enumerator.Current);
                if ((object) x != null && comparer.Compare(x, y) > 0)
                  y = x;
              }
              goto label_25;
            }
          }
          return y;
        }
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (!enumerator.MoveNext())
            ThrowHelper.ThrowNoElementsException();
          y = selector(enumerator.Current);
          while (enumerator.MoveNext())
          {
            TResult x = selector(enumerator.Current);
            if (comparer.Compare(x, y) > 0)
              y = x;
          }
        }
      }
label_25:
      return y;
    }

    public static int Min(this IEnumerable<int> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      int num;
      using (IEnumerator<int> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        num = enumerator.Current;
        while (enumerator.MoveNext())
        {
          int current = enumerator.Current;
          if (current < num)
            num = current;
        }
      }
      return num;
    }

    public static int? Min(this IEnumerable<int?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      int? nullable = new int?();
      using (IEnumerator<int?> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable;
          nullable = enumerator.Current;
        }
        while (!nullable.HasValue);
        int num = nullable.GetValueOrDefault();
        while (enumerator.MoveNext())
        {
          int? current = enumerator.Current;
          int valueOrDefault = current.GetValueOrDefault();
          if (current.HasValue & valueOrDefault < num)
          {
            num = valueOrDefault;
            nullable = current;
          }
        }
      }
      return nullable;
    }

    public static long Min(this IEnumerable<long> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      long num;
      using (IEnumerator<long> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        num = enumerator.Current;
        while (enumerator.MoveNext())
        {
          long current = enumerator.Current;
          if (current < num)
            num = current;
        }
      }
      return num;
    }

    public static long? Min(this IEnumerable<long?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      long? nullable = new long?();
      using (IEnumerator<long?> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable;
          nullable = enumerator.Current;
        }
        while (!nullable.HasValue);
        long num = nullable.GetValueOrDefault();
        while (enumerator.MoveNext())
        {
          long? current = enumerator.Current;
          long valueOrDefault = current.GetValueOrDefault();
          if (current.HasValue & valueOrDefault < num)
          {
            num = valueOrDefault;
            nullable = current;
          }
        }
      }
      return nullable;
    }

    public static float Min(this IEnumerable<float> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      float f;
      using (IEnumerator<float> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        f = enumerator.Current;
        if (float.IsNaN(f))
          return f;
        while (enumerator.MoveNext())
        {
          float current = enumerator.Current;
          if ((double) current < (double) f)
            f = current;
          else if (float.IsNaN(current))
            return current;
        }
      }
      return f;
    }

    public static float? Min(this IEnumerable<float?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      float? nullable = new float?();
      using (IEnumerator<float?> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable;
          nullable = enumerator.Current;
        }
        while (!nullable.HasValue);
        float f = nullable.GetValueOrDefault();
        if (float.IsNaN(f))
          return nullable;
        while (enumerator.MoveNext())
        {
          float? current = enumerator.Current;
          if (current.HasValue)
          {
            float valueOrDefault = current.GetValueOrDefault();
            if ((double) valueOrDefault < (double) f)
            {
              f = valueOrDefault;
              nullable = current;
            }
            else if (float.IsNaN(valueOrDefault))
              return current;
          }
        }
      }
      return nullable;
    }

    public static double Min(this IEnumerable<double> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      double d;
      using (IEnumerator<double> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        d = enumerator.Current;
        if (double.IsNaN(d))
          return d;
        while (enumerator.MoveNext())
        {
          double current = enumerator.Current;
          if (current < d)
            d = current;
          else if (double.IsNaN(current))
            return current;
        }
      }
      return d;
    }

    public static double? Min(this IEnumerable<double?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      double? nullable = new double?();
      using (IEnumerator<double?> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable;
          nullable = enumerator.Current;
        }
        while (!nullable.HasValue);
        double d = nullable.GetValueOrDefault();
        if (double.IsNaN(d))
          return nullable;
        while (enumerator.MoveNext())
        {
          double? current = enumerator.Current;
          if (current.HasValue)
          {
            double valueOrDefault = current.GetValueOrDefault();
            if (valueOrDefault < d)
            {
              d = valueOrDefault;
              nullable = current;
            }
            else if (double.IsNaN(valueOrDefault))
              return current;
          }
        }
      }
      return nullable;
    }

    public static Decimal Min(this IEnumerable<Decimal> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      Decimal num;
      using (IEnumerator<Decimal> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        num = enumerator.Current;
        while (enumerator.MoveNext())
        {
          Decimal current = enumerator.Current;
          if (current < num)
            num = current;
        }
      }
      return num;
    }

    public static Decimal? Min(this IEnumerable<Decimal?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      Decimal? nullable = new Decimal?();
      using (IEnumerator<Decimal?> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable;
          nullable = enumerator.Current;
        }
        while (!nullable.HasValue);
        Decimal num = nullable.GetValueOrDefault();
        while (enumerator.MoveNext())
        {
          Decimal? current = enumerator.Current;
          Decimal valueOrDefault = current.GetValueOrDefault();
          if (current.HasValue && valueOrDefault < num)
          {
            num = valueOrDefault;
            nullable = current;
          }
        }
      }
      return nullable;
    }

    public static TSource? Min<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      Comparer<TSource> comparer = Comparer<TSource>.Default;
      TSource y = default (TSource);
      if ((object) y == null)
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            y = enumerator.Current;
            if ((object) y != null)
            {
              while (enumerator.MoveNext())
              {
                TSource current = enumerator.Current;
                if ((object) current != null && comparer.Compare(current, y) < 0)
                  y = current;
              }
              goto label_23;
            }
          }
          return y;
        }
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (!enumerator.MoveNext())
            ThrowHelper.ThrowNoElementsException();
          y = enumerator.Current;
          while (enumerator.MoveNext())
          {
            TSource current = enumerator.Current;
            if (comparer.Compare(current, y) < 0)
              y = current;
          }
        }
      }
label_23:
      return y;
    }

    public static int Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      int num1;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        num1 = selector(enumerator.Current);
        while (enumerator.MoveNext())
        {
          int num2 = selector(enumerator.Current);
          if (num2 < num1)
            num1 = num2;
        }
      }
      return num1;
    }

    public static int? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      int? nullable1 = new int?();
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable1;
          nullable1 = selector(enumerator.Current);
        }
        while (!nullable1.HasValue);
        int num = nullable1.GetValueOrDefault();
        while (enumerator.MoveNext())
        {
          int? nullable2 = selector(enumerator.Current);
          int valueOrDefault = nullable2.GetValueOrDefault();
          if (nullable2.HasValue & valueOrDefault < num)
          {
            num = valueOrDefault;
            nullable1 = nullable2;
          }
        }
      }
      return nullable1;
    }

    public static long Min<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      long num1;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        num1 = selector(enumerator.Current);
        while (enumerator.MoveNext())
        {
          long num2 = selector(enumerator.Current);
          if (num2 < num1)
            num1 = num2;
        }
      }
      return num1;
    }

    public static long? Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, long?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      long? nullable1 = new long?();
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable1;
          nullable1 = selector(enumerator.Current);
        }
        while (!nullable1.HasValue);
        long num = nullable1.GetValueOrDefault();
        while (enumerator.MoveNext())
        {
          long? nullable2 = selector(enumerator.Current);
          long valueOrDefault = nullable2.GetValueOrDefault();
          if (nullable2.HasValue & valueOrDefault < num)
          {
            num = valueOrDefault;
            nullable1 = nullable2;
          }
        }
      }
      return nullable1;
    }

    public static float Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      float f1;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        f1 = selector(enumerator.Current);
        if (float.IsNaN(f1))
          return f1;
        while (enumerator.MoveNext())
        {
          float f2 = selector(enumerator.Current);
          if ((double) f2 < (double) f1)
            f1 = f2;
          else if (float.IsNaN(f2))
            return f2;
        }
      }
      return f1;
    }

    public static float? Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      float? nullable1 = new float?();
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable1;
          nullable1 = selector(enumerator.Current);
        }
        while (!nullable1.HasValue);
        float f = nullable1.GetValueOrDefault();
        if (float.IsNaN(f))
          return nullable1;
        while (enumerator.MoveNext())
        {
          float? nullable2 = selector(enumerator.Current);
          if (nullable2.HasValue)
          {
            float valueOrDefault = nullable2.GetValueOrDefault();
            if ((double) valueOrDefault < (double) f)
            {
              f = valueOrDefault;
              nullable1 = nullable2;
            }
            else if (float.IsNaN(valueOrDefault))
              return nullable2;
          }
        }
      }
      return nullable1;
    }

    public static double Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      double d1;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        d1 = selector(enumerator.Current);
        if (double.IsNaN(d1))
          return d1;
        while (enumerator.MoveNext())
        {
          double d2 = selector(enumerator.Current);
          if (d2 < d1)
            d1 = d2;
          else if (double.IsNaN(d2))
            return d2;
        }
      }
      return d1;
    }

    public static double? Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      double? nullable1 = new double?();
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable1;
          nullable1 = selector(enumerator.Current);
        }
        while (!nullable1.HasValue);
        double d = nullable1.GetValueOrDefault();
        if (double.IsNaN(d))
          return nullable1;
        while (enumerator.MoveNext())
        {
          double? nullable2 = selector(enumerator.Current);
          if (nullable2.HasValue)
          {
            double valueOrDefault = nullable2.GetValueOrDefault();
            if (valueOrDefault < d)
            {
              d = valueOrDefault;
              nullable1 = nullable2;
            }
            else if (double.IsNaN(valueOrDefault))
              return nullable2;
          }
        }
      }
      return nullable1;
    }

    public static Decimal Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      Decimal num1;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          ThrowHelper.ThrowNoElementsException();
        num1 = selector(enumerator.Current);
        while (enumerator.MoveNext())
        {
          Decimal num2 = selector(enumerator.Current);
          if (num2 < num1)
            num1 = num2;
        }
      }
      return num1;
    }

    public static Decimal? Min<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      Decimal? nullable1 = new Decimal?();
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        do
        {
          if (!enumerator.MoveNext())
            return nullable1;
          nullable1 = selector(enumerator.Current);
        }
        while (!nullable1.HasValue);
        Decimal num = nullable1.GetValueOrDefault();
        while (enumerator.MoveNext())
        {
          Decimal? nullable2 = selector(enumerator.Current);
          Decimal valueOrDefault = nullable2.GetValueOrDefault();
          if (nullable2.HasValue && valueOrDefault < num)
          {
            num = valueOrDefault;
            nullable1 = nullable2;
          }
        }
      }
      return nullable1;
    }

    public static TResult? Min<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TResult> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      Comparer<TResult> comparer = Comparer<TResult>.Default;
      TResult y = default (TResult);
      if ((object) y == null)
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            y = selector(enumerator.Current);
            if ((object) y != null)
            {
              while (enumerator.MoveNext())
              {
                TResult x = selector(enumerator.Current);
                if ((object) x != null && comparer.Compare(x, y) < 0)
                  y = x;
              }
              goto label_25;
            }
          }
          return y;
        }
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (!enumerator.MoveNext())
            ThrowHelper.ThrowNoElementsException();
          y = selector(enumerator.Current);
          while (enumerator.MoveNext())
          {
            TResult x = selector(enumerator.Current);
            if (comparer.Compare(x, y) < 0)
              y = x;
          }
        }
      }
label_25:
      return y;
    }

    public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      return (IOrderedEnumerable<TSource>) new OrderedEnumerable<TSource, TKey>(source, keySelector, (IComparer<TKey>) null, false, (OrderedEnumerable<TSource>) null);
    }

    public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IComparer<TKey>? comparer)
    {
      return (IOrderedEnumerable<TSource>) new OrderedEnumerable<TSource, TKey>(source, keySelector, comparer, false, (OrderedEnumerable<TSource>) null);
    }

    public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      return (IOrderedEnumerable<TSource>) new OrderedEnumerable<TSource, TKey>(source, keySelector, (IComparer<TKey>) null, true, (OrderedEnumerable<TSource>) null);
    }

    public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IComparer<TKey>? comparer)
    {
      return (IOrderedEnumerable<TSource>) new OrderedEnumerable<TSource, TKey>(source, keySelector, comparer, true, (OrderedEnumerable<TSource>) null);
    }

    public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
      this IOrderedEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return source.CreateOrderedEnumerable<TKey>(keySelector, (IComparer<TKey>) null, false);
    }

    public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
      this IOrderedEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IComparer<TKey>? comparer)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return source.CreateOrderedEnumerable<TKey>(keySelector, comparer, false);
    }

    public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(
      this IOrderedEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return source.CreateOrderedEnumerable<TKey>(keySelector, (IComparer<TKey>) null, true);
    }

    public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(
      this IOrderedEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IComparer<TKey>? comparer)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return source.CreateOrderedEnumerable<TKey>(keySelector, comparer, true);
    }

    public static IEnumerable<int> Range(int start, int count)
    {
      long num = (long) start + (long) count - 1L;
      if (count < 0 || num > (long) int.MaxValue)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count);
      return count == 0 ? Enumerable.Empty<int>() : (IEnumerable<int>) new Enumerable.RangeIterator(start, count);
    }

    public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
    {
      if (count < 0)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count);
      return count == 0 ? Enumerable.Empty<TResult>() : (IEnumerable<TResult>) new Enumerable.RepeatIterator<TResult>(element, count);
    }

    public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return (IEnumerable<TSource>) new Enumerable.ReverseIterator<TSource>(source);
    }

    public static IEnumerable<TResult> Select<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TResult> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      switch (source)
      {
        case Enumerable.Iterator<TSource> iterator:
          return iterator.Select<TResult>(selector);
        case IList<TSource> source1:
          switch (source)
          {
            case TSource[] source1:
              return source1.Length != 0 ? (IEnumerable<TResult>) new Enumerable.SelectArrayIterator<TSource, TResult>(source1, selector) : Enumerable.Empty<TResult>();
            case List<TSource> source1:
              return (IEnumerable<TResult>) new Enumerable.SelectListIterator<TSource, TResult>(source1, selector);
            default:
              return (IEnumerable<TResult>) new Enumerable.SelectIListIterator<TSource, TResult>(source1, selector);
          }
        case IPartition<TSource> partition:
          IEnumerable<TResult> result = (IEnumerable<TResult>) null;
          Enumerable.CreateSelectIPartitionIterator<TResult, TSource>(selector, partition, ref result);
          if (result != null)
            return result;
          break;
      }
      return (IEnumerable<TResult>) new Enumerable.SelectEnumerableIterator<TSource, TResult>(source, selector);
    }

    private static void CreateSelectIPartitionIterator<TResult, TSource>(

      #nullable disable
      Func<TSource, TResult> selector,
      IPartition<TSource> partition,
      [NotNull] ref IEnumerable<TResult> result)
    {
      result = partition is EmptyPartition<TSource> ? (IEnumerable<TResult>) EmptyPartition<TResult>.Instance : (IEnumerable<TResult>) new Enumerable.SelectIPartitionIterator<TSource, TResult>(partition, selector);
    }

    public static 
    #nullable enable
    IEnumerable<TResult> Select<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, int, TResult> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      return Enumerable.SelectIterator<TSource, TResult>(source, selector);
    }

    private static 
    #nullable disable
    IEnumerable<TResult> SelectIterator<TSource, TResult>(
      IEnumerable<TSource> source,
      Func<TSource, int, TResult> selector)
    {
      int index = -1;
      foreach (TSource source1 in source)
      {
        checked { ++index; }
        yield return selector(source1, index);
      }
    }

    public static 
    #nullable enable
    IEnumerable<TResult> SelectMany<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, IEnumerable<TResult>> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      return (IEnumerable<TResult>) new Enumerable.SelectManySingleSelectorIterator<TSource, TResult>(source, selector);
    }

    public static IEnumerable<TResult> SelectMany<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, int, IEnumerable<TResult>> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      return Enumerable.SelectManyIterator<TSource, TResult>(source, selector);
    }

    private static 
    #nullable disable
    IEnumerable<TResult> SelectManyIterator<TSource, TResult>(
      IEnumerable<TSource> source,
      Func<TSource, int, IEnumerable<TResult>> selector)
    {
      int index = -1;
      foreach (TSource source1 in source)
      {
        checked { ++index; }
        foreach (TResult result in selector(source1, index))
          yield return result;
      }
    }

    public static 
    #nullable enable
    IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, TResult> resultSelector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (collectionSelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collectionSelector);
      if (resultSelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.resultSelector);
      return Enumerable.SelectManyIterator<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
    }

    private static 
    #nullable disable
    IEnumerable<TResult> SelectManyIterator<TSource, TCollection, TResult>(
      IEnumerable<TSource> source,
      Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, TResult> resultSelector)
    {
      int index = -1;
      foreach (TSource source1 in source)
      {
        TSource element = source1;
        checked { ++index; }
        foreach (TCollection collection in collectionSelector(element, index))
          yield return resultSelector(element, collection);
        element = default (TSource);
      }
    }

    public static 
    #nullable enable
    IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, IEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, TResult> resultSelector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (collectionSelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collectionSelector);
      if (resultSelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.resultSelector);
      return Enumerable.SelectManyIterator<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
    }

    private static 
    #nullable disable
    IEnumerable<TResult> SelectManyIterator<TSource, TCollection, TResult>(
      IEnumerable<TSource> source,
      Func<TSource, IEnumerable<TCollection>> collectionSelector,
      Func<TSource, TCollection, TResult> resultSelector)
    {
      foreach (TSource source1 in source)
      {
        TSource element = source1;
        foreach (TCollection collection in collectionSelector(element))
          yield return resultSelector(element, collection);
        element = default (TSource);
      }
    }

    public static bool SequenceEqual<TSource>(
      this 
      #nullable enable
      IEnumerable<TSource> first,
      IEnumerable<TSource> second)
    {
      return first.SequenceEqual<TSource>(second, (IEqualityComparer<TSource>) null);
    }

    public static bool SequenceEqual<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource>? comparer)
    {
      if (comparer == null)
        comparer = (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default;
      if (first == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
      if (second == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
      if (first is ICollection<TSource> sources && second is ICollection<TSource> sources)
      {
        if (sources.Count != sources.Count)
          return false;
        if (sources is IList<TSource> sourceList && sources is IList<TSource> sourceList)
        {
          int count = sources.Count;
          for (int index = 0; index < count; ++index)
          {
            if (!comparer.Equals(sourceList[index], sourceList[index]))
              return false;
          }
          return true;
        }
      }
      using (IEnumerator<TSource> enumerator1 = first.GetEnumerator())
      {
        using (IEnumerator<TSource> enumerator2 = second.GetEnumerator())
        {
          while (enumerator1.MoveNext())
          {
            if (!enumerator2.MoveNext() || !comparer.Equals(enumerator1.Current, enumerator2.Current))
              return false;
          }
          return !enumerator2.MoveNext();
        }
      }
    }

    public static TSource Single<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (source is IList<TSource> sourceList)
      {
        switch (sourceList.Count)
        {
          case 0:
            ThrowHelper.ThrowNoElementsException();
            return default (TSource);
          case 1:
            return sourceList[0];
        }
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (!enumerator.MoveNext())
            ThrowHelper.ThrowNoElementsException();
          TSource current = enumerator.Current;
          if (!enumerator.MoveNext())
            return current;
        }
      }
      ThrowHelper.ThrowMoreThanOneElementException();
      return default (TSource);
    }

    public static TSource Single<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          TSource current = enumerator.Current;
          if (predicate(current))
          {
            while (enumerator.MoveNext())
            {
              if (predicate(enumerator.Current))
                ThrowHelper.ThrowMoreThanOneMatchException();
            }
            return current;
          }
        }
      }
      ThrowHelper.ThrowNoMatchException();
      return default (TSource);
    }

    public static TSource? SingleOrDefault<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (source is IList<TSource> sourceList)
      {
        switch (sourceList.Count)
        {
          case 0:
            return default (TSource);
          case 1:
            return sourceList[0];
        }
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (!enumerator.MoveNext())
            return default (TSource);
          TSource current = enumerator.Current;
          if (!enumerator.MoveNext())
            return current;
        }
      }
      ThrowHelper.ThrowMoreThanOneElementException();
      return default (TSource);
    }

    public static TSource? SingleOrDefault<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          TSource current = enumerator.Current;
          if (predicate(current))
          {
            while (enumerator.MoveNext())
            {
              if (predicate(enumerator.Current))
                ThrowHelper.ThrowMoreThanOneMatchException();
            }
            return current;
          }
        }
      }
      return default (TSource);
    }

    public static IEnumerable<TSource> Skip<TSource>(
      this IEnumerable<TSource> source,
      int count)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (count <= 0)
      {
        switch (source)
        {
          case Enumerable.Iterator<TSource> _:
          case IPartition<TSource> _:
            return source;
          default:
            count = 0;
            break;
        }
      }
      else if (source is IPartition<TSource> partition)
        return (IEnumerable<TSource>) partition.Skip(count);
      return Enumerable.SkipIterator<TSource>(source, count);
    }

    public static IEnumerable<TSource> SkipWhile<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      return Enumerable.SkipWhileIterator<TSource>(source, predicate);
    }

    private static 
    #nullable disable
    IEnumerable<TSource> SkipWhileIterator<TSource>(
      IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      using (IEnumerator<TSource> e = source.GetEnumerator())
      {
        while (e.MoveNext())
        {
          TSource current = e.Current;
          if (!predicate(current))
          {
            yield return current;
            while (e.MoveNext())
              yield return e.Current;
            break;
          }
        }
      }
    }

    public static 
    #nullable enable
    IEnumerable<TSource> SkipWhile<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      return Enumerable.SkipWhileIterator<TSource>(source, predicate);
    }

    private static 
    #nullable disable
    IEnumerable<TSource> SkipWhileIterator<TSource>(
      IEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      using (IEnumerator<TSource> e = source.GetEnumerator())
      {
        int num = -1;
        while (e.MoveNext())
        {
          checked { ++num; }
          TSource current = e.Current;
          if (!predicate(current, num))
          {
            yield return current;
            while (e.MoveNext())
              yield return e.Current;
            break;
          }
        }
      }
    }

    public static 
    #nullable enable
    IEnumerable<TSource> SkipLast<TSource>(this IEnumerable<TSource> source, int count)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return count > 0 ? Enumerable.SkipLastEnumerableFactory<TSource>(source, count) : source.Skip<TSource>(0);
    }

    private static 
    #nullable disable
    IEnumerable<TSource> SkipLastIterator<TSource>(
      IEnumerable<TSource> source,
      int count)
    {
      Queue<TSource> queue = new Queue<TSource>();
      using (IEnumerator<TSource> e = source.GetEnumerator())
      {
        while (e.MoveNext())
        {
          if (queue.Count == count)
          {
            do
            {
              yield return queue.Dequeue();
              queue.Enqueue(e.Current);
            }
            while (e.MoveNext());
            break;
          }
          queue.Enqueue(e.Current);
        }
      }
    }

    public static int Sum(this 
    #nullable enable
    IEnumerable<int> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      int num1 = 0;
      foreach (int num2 in source)
        checked { num1 += num2; }
      return num1;
    }

    public static int? Sum(this IEnumerable<int?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      int num = 0;
      foreach (int? nullable in source)
      {
        if (nullable.HasValue)
          checked { num += nullable.GetValueOrDefault(); }
      }
      return new int?(num);
    }

    public static long Sum(this IEnumerable<long> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      long num1 = 0;
      foreach (long num2 in source)
        checked { num1 += num2; }
      return num1;
    }

    public static long? Sum(this IEnumerable<long?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      long num = 0;
      foreach (long? nullable in source)
      {
        if (nullable.HasValue)
          checked { num += nullable.GetValueOrDefault(); }
      }
      return new long?(num);
    }

    public static float Sum(this IEnumerable<float> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      double num1 = 0.0;
      foreach (float num2 in source)
        num1 += (double) num2;
      return (float) num1;
    }

    public static float? Sum(this IEnumerable<float?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      double num = 0.0;
      foreach (float? nullable in source)
      {
        if (nullable.HasValue)
          num += (double) nullable.GetValueOrDefault();
      }
      return new float?((float) num);
    }

    public static double Sum(this IEnumerable<double> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      double num1 = 0.0;
      foreach (double num2 in source)
        num1 += num2;
      return num1;
    }

    public static double? Sum(this IEnumerable<double?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      double num = 0.0;
      foreach (double? nullable in source)
      {
        if (nullable.HasValue)
          num += nullable.GetValueOrDefault();
      }
      return new double?(num);
    }

    public static Decimal Sum(this IEnumerable<Decimal> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      Decimal num1 = 0M;
      foreach (Decimal num2 in source)
        num1 += num2;
      return num1;
    }

    public static Decimal? Sum(this IEnumerable<Decimal?> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      Decimal num = 0M;
      foreach (Decimal? nullable in source)
      {
        if (nullable.HasValue)
          num += nullable.GetValueOrDefault();
      }
      return new Decimal?(num);
    }

    public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      int num = 0;
      foreach (TSource source1 in source)
        checked { num += selector(source1); }
      return num;
    }

    public static int? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      int num = 0;
      foreach (TSource source1 in source)
      {
        int? nullable = selector(source1);
        if (nullable.HasValue)
          checked { num += nullable.GetValueOrDefault(); }
      }
      return new int?(num);
    }

    public static long Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
    {
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      long num = 0;
      foreach (TSource source1 in source)
        checked { num += selector(source1); }
      return num;
    }

    public static long? Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, long?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      long num = 0;
      foreach (TSource source1 in source)
      {
        long? nullable = selector(source1);
        if (nullable.HasValue)
          checked { num += nullable.GetValueOrDefault(); }
      }
      return new long?(num);
    }

    public static float Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      double num = 0.0;
      foreach (TSource source1 in source)
        num += (double) selector(source1);
      return (float) num;
    }

    public static float? Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, float?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      double num = 0.0;
      foreach (TSource source1 in source)
      {
        float? nullable = selector(source1);
        if (nullable.HasValue)
          num += (double) nullable.GetValueOrDefault();
      }
      return new float?((float) num);
    }

    public static double Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      double num = 0.0;
      foreach (TSource source1 in source)
        num += selector(source1);
      return num;
    }

    public static double? Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, double?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      double num = 0.0;
      foreach (TSource source1 in source)
      {
        double? nullable = selector(source1);
        if (nullable.HasValue)
          num += nullable.GetValueOrDefault();
      }
      return new double?(num);
    }

    public static Decimal Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      Decimal num = 0M;
      foreach (TSource source1 in source)
        num += selector(source1);
      return num;
    }

    public static Decimal? Sum<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, Decimal?> selector)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (selector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.selector);
      Decimal num = 0M;
      foreach (TSource source1 in source)
      {
        Decimal? nullable = selector(source1);
        if (nullable.HasValue)
          num += nullable.GetValueOrDefault();
      }
      return new Decimal?(num);
    }

    public static IEnumerable<TSource> Take<TSource>(
      this IEnumerable<TSource> source,
      int count)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return count > 0 ? Enumerable.TakeIterator<TSource>(source, count) : Enumerable.Empty<TSource>();
    }

    public static IEnumerable<TSource> TakeWhile<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      return Enumerable.TakeWhileIterator<TSource>(source, predicate);
    }

    private static 
    #nullable disable
    IEnumerable<TSource> TakeWhileIterator<TSource>(
      IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          yield return source1;
        else
          break;
      }
    }

    public static 
    #nullable enable
    IEnumerable<TSource> TakeWhile<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      return Enumerable.TakeWhileIterator<TSource>(source, predicate);
    }

    private static 
    #nullable disable
    IEnumerable<TSource> TakeWhileIterator<TSource>(
      IEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      int index = -1;
      foreach (TSource source1 in source)
      {
        checked { ++index; }
        if (predicate(source1, index))
          yield return source1;
        else
          break;
      }
    }

    public static 
    #nullable enable
    IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> source, int count)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return count > 0 ? Enumerable.TakeLastEnumerableFactory<TSource>(source, count) : Enumerable.Empty<TSource>();
    }

    private static 
    #nullable disable
    IEnumerable<TSource> TakeLastIterator<TSource>(
      IEnumerable<TSource> source,
      int count)
    {
      Queue<TSource> queue;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
        {
          yield break;
        }
        else
        {
          queue = new Queue<TSource>();
          queue.Enqueue(enumerator.Current);
          while (enumerator.MoveNext())
          {
            if (queue.Count < count)
            {
              queue.Enqueue(enumerator.Current);
            }
            else
            {
              do
              {
                queue.Dequeue();
                queue.Enqueue(enumerator.Current);
              }
              while (enumerator.MoveNext());
              break;
            }
          }
        }
      }
      do
      {
        yield return queue.Dequeue();
      }
      while (queue.Count > 0);
    }

    public static 
    #nullable enable
    TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return !(source is IIListProvider<TSource> ilistProvider) ? EnumerableHelpers.ToArray<TSource>(source) : ilistProvider.ToArray();
    }

    public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return !(source is IIListProvider<TSource> ilistProvider) ? new List<TSource>(source) : ilistProvider.ToList();
    }

    public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector)
      where TKey : notnull
    {
      return source.ToDictionary<TSource, TKey>(keySelector, (IEqualityComparer<TKey>) null);
    }

    public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      IEqualityComparer<TKey>? comparer)
      where TKey : notnull
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (keySelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
      int capacity = 0;
      if (source is ICollection<TSource> sources)
      {
        capacity = sources.Count;
        if (capacity == 0)
          return new Dictionary<TKey, TSource>(comparer);
        switch (sources)
        {
          case TSource[] source1:
            return Enumerable.ToDictionary<TSource, TKey>(source1, keySelector, comparer);
          case List<TSource> source1:
            return Enumerable.ToDictionary<TSource, TKey>(source1, keySelector, comparer);
        }
      }
      Dictionary<TKey, TSource> dictionary = new Dictionary<TKey, TSource>(capacity, comparer);
      foreach (TSource source1 in source)
        dictionary.Add(keySelector(source1), source1);
      return dictionary;
    }

    private static 
    #nullable disable
    Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
      TSource[] source,
      Func<TSource, TKey> keySelector,
      IEqualityComparer<TKey> comparer)
    {
      Dictionary<TKey, TSource> dictionary = new Dictionary<TKey, TSource>(source.Length, comparer);
      for (int index = 0; index < source.Length; ++index)
        dictionary.Add(keySelector(source[index]), source[index]);
      return dictionary;
    }

    private static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
      List<TSource> source,
      Func<TSource, TKey> keySelector,
      IEqualityComparer<TKey> comparer)
    {
      Dictionary<TKey, TSource> dictionary = new Dictionary<TKey, TSource>(source.Count, comparer);
      foreach (TSource source1 in source)
        dictionary.Add(keySelector(source1), source1);
      return dictionary;
    }

    public static 
    #nullable enable
    Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector)
      where TKey : notnull
    {
      return source.ToDictionary<TSource, TKey, TElement>(keySelector, elementSelector, (IEqualityComparer<TKey>) null);
    }

    public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
      this IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey>? comparer)
      where TKey : notnull
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (keySelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keySelector);
      if (elementSelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.elementSelector);
      int capacity = 0;
      if (source is ICollection<TSource> sources)
      {
        capacity = sources.Count;
        if (capacity == 0)
          return new Dictionary<TKey, TElement>(comparer);
        switch (sources)
        {
          case TSource[] source1:
            return Enumerable.ToDictionary<TSource, TKey, TElement>(source1, keySelector, elementSelector, comparer);
          case List<TSource> source1:
            return Enumerable.ToDictionary<TSource, TKey, TElement>(source1, keySelector, elementSelector, comparer);
        }
      }
      Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>(capacity, comparer);
      foreach (TSource source1 in source)
        dictionary.Add(keySelector(source1), elementSelector(source1));
      return dictionary;
    }

    private static 
    #nullable disable
    Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
      TSource[] source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>(source.Length, comparer);
      for (int index = 0; index < source.Length; ++index)
        dictionary.Add(keySelector(source[index]), elementSelector(source[index]));
      return dictionary;
    }

    private static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
      List<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>(source.Count, comparer);
      foreach (TSource source1 in source)
        dictionary.Add(keySelector(source1), elementSelector(source1));
      return dictionary;
    }

    public static 
    #nullable enable
    HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source) => source.ToHashSet<TSource>((IEqualityComparer<TSource>) null);

    public static HashSet<TSource> ToHashSet<TSource>(
      this IEnumerable<TSource> source,
      IEqualityComparer<TSource>? comparer)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      return new HashSet<TSource>(source, comparer);
    }

    public static IEnumerable<TSource> Union<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second)
    {
      return first.Union<TSource>(second, (IEqualityComparer<TSource>) null);
    }

    public static IEnumerable<TSource> Union<TSource>(
      this IEnumerable<TSource> first,
      IEnumerable<TSource> second,
      IEqualityComparer<TSource>? comparer)
    {
      if (first == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
      if (second == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
      return !(first is Enumerable.UnionIterator<TSource> unionIterator) || !Utilities.AreEqualityComparersEqual<TSource>(comparer, unionIterator._comparer) ? (IEnumerable<TSource>) new Enumerable.UnionIterator2<TSource>(first, second, comparer) : (IEnumerable<TSource>) unionIterator.Union(second);
    }

    public static IEnumerable<TSource> Where<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      switch (source)
      {
        case Enumerable.Iterator<TSource> iterator:
          return iterator.Where(predicate);
        case TSource[] source1:
          return source1.Length != 0 ? (IEnumerable<TSource>) new Enumerable.WhereArrayIterator<TSource>(source1, predicate) : Enumerable.Empty<TSource>();
        case List<TSource> source1:
          return (IEnumerable<TSource>) new Enumerable.WhereListIterator<TSource>(source1, predicate);
        default:
          return (IEnumerable<TSource>) new Enumerable.WhereEnumerableIterator<TSource>(source, predicate);
      }
    }

    public static IEnumerable<TSource> Where<TSource>(
      this IEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      if (source == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
      if (predicate == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
      return Enumerable.WhereIterator<TSource>(source, predicate);
    }

    private static 
    #nullable disable
    IEnumerable<TSource> WhereIterator<TSource>(
      IEnumerable<TSource> source,
      Func<TSource, int, bool> predicate)
    {
      int index = -1;
      foreach (TSource source1 in source)
      {
        checked { ++index; }
        if (predicate(source1, index))
          yield return source1;
      }
    }

    public static 
    #nullable enable
    IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
      this IEnumerable<TFirst> first,
      IEnumerable<TSecond> second,
      Func<TFirst, TSecond, TResult> resultSelector)
    {
      if (first == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
      if (second == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
      if (resultSelector == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.resultSelector);
      return Enumerable.ZipIterator<TFirst, TSecond, TResult>(first, second, resultSelector);
    }

    public static IEnumerable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(
      this IEnumerable<TFirst> first,
      IEnumerable<TSecond> second)
    {
      if (first == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.first);
      if (second == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.second);
      return Enumerable.ZipIterator<TFirst, TSecond>(first, second);
    }

    private static 
    #nullable disable
    IEnumerable<(TFirst First, TSecond Second)> ZipIterator<TFirst, TSecond>(
      IEnumerable<TFirst> first,
      IEnumerable<TSecond> second)
    {
      using (IEnumerator<TFirst> e1 = first.GetEnumerator())
      {
        using (IEnumerator<TSecond> e2 = second.GetEnumerator())
        {
          while (e1.MoveNext() && e2.MoveNext())
            yield return (e1.Current, e2.Current);
        }
      }
    }

    private static IEnumerable<TResult> ZipIterator<TFirst, TSecond, TResult>(
      IEnumerable<TFirst> first,
      IEnumerable<TSecond> second,
      Func<TFirst, TSecond, TResult> resultSelector)
    {
      using (IEnumerator<TFirst> e1 = first.GetEnumerator())
      {
        using (IEnumerator<TSecond> e2 = second.GetEnumerator())
        {
          while (e1.MoveNext() && e2.MoveNext())
            yield return resultSelector(e1.Current, e2.Current);
        }
      }
    }

    private abstract class AppendPrependIterator<TSource> : 
      Enumerable.Iterator<TSource>,
      IIListProvider<TSource>,
      IEnumerable<TSource>,
      IEnumerable
    {
      protected readonly IEnumerable<TSource> _source;
      protected IEnumerator<TSource> _enumerator;

      public abstract TSource[] ToArray();

      public abstract List<TSource> ToList();

      public abstract int GetCount(bool onlyIfCheap);

      protected AppendPrependIterator(IEnumerable<TSource> source) => this._source = source;

      protected void GetSourceEnumerator() => this._enumerator = this._source.GetEnumerator();

      public abstract Enumerable.AppendPrependIterator<TSource> Append(TSource item);

      public abstract Enumerable.AppendPrependIterator<TSource> Prepend(TSource item);

      protected bool LoadFromEnumerator()
      {
        if (this._enumerator.MoveNext())
        {
          this._current = this._enumerator.Current;
          return true;
        }
        this.Dispose();
        return false;
      }

      public override void Dispose()
      {
        if (this._enumerator != null)
        {
          this._enumerator.Dispose();
          this._enumerator = (IEnumerator<TSource>) null;
        }
        base.Dispose();
      }
    }

    private class AppendPrepend1Iterator<TSource> : Enumerable.AppendPrependIterator<TSource>
    {
      private readonly TSource _item;
      private readonly bool _appending;

      private TSource[] LazyToArray()
      {
        LargeArrayBuilder<TSource> largeArrayBuilder = new LargeArrayBuilder<TSource>(true);
        if (!this._appending)
          largeArrayBuilder.SlowAdd(this._item);
        largeArrayBuilder.AddRange(this._source);
        if (this._appending)
          largeArrayBuilder.SlowAdd(this._item);
        return largeArrayBuilder.ToArray();
      }

      public override TSource[] ToArray()
      {
        int count = this.GetCount(true);
        if (count == -1)
          return this.LazyToArray();
        TSource[] array = new TSource[count];
        int arrayIndex;
        if (this._appending)
        {
          arrayIndex = 0;
        }
        else
        {
          array[0] = this._item;
          arrayIndex = 1;
        }
        EnumerableHelpers.Copy<TSource>(this._source, array, arrayIndex, count - 1);
        if (this._appending)
          array[array.Length - 1] = this._item;
        return array;
      }

      public override List<TSource> ToList()
      {
        int count = this.GetCount(true);
        List<TSource> sourceList = count == -1 ? new List<TSource>() : new List<TSource>(count);
        if (!this._appending)
          sourceList.Add(this._item);
        sourceList.AddRange(this._source);
        if (this._appending)
          sourceList.Add(this._item);
        return sourceList;
      }

      public override int GetCount(bool onlyIfCheap)
      {
        if (this._source is IIListProvider<TSource> source)
        {
          int count = source.GetCount(onlyIfCheap);
          return count != -1 ? count + 1 : -1;
        }
        return onlyIfCheap && !(this._source is ICollection<TSource>) ? -1 : this._source.Count<TSource>() + 1;
      }

      public AppendPrepend1Iterator(IEnumerable<TSource> source, TSource item, bool appending)
        : base(source)
      {
        this._item = item;
        this._appending = appending;
      }

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.AppendPrepend1Iterator<TSource>(this._source, this._item, this._appending);

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._state = 2;
            if (!this._appending)
            {
              this._current = this._item;
              return true;
            }
            goto case 2;
          case 2:
            this.GetSourceEnumerator();
            this._state = 3;
            goto case 3;
          case 3:
            if (this.LoadFromEnumerator())
              return true;
            if (this._appending)
            {
              this._current = this._item;
              return true;
            }
            break;
        }
        this.Dispose();
        return false;
      }

      public override Enumerable.AppendPrependIterator<TSource> Append(TSource item) => this._appending ? (Enumerable.AppendPrependIterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, (SingleLinkedNode<TSource>) null, new SingleLinkedNode<TSource>(this._item).Add(item), 0, 2) : (Enumerable.AppendPrependIterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, new SingleLinkedNode<TSource>(this._item), new SingleLinkedNode<TSource>(item), 1, 1);

      public override Enumerable.AppendPrependIterator<TSource> Prepend(TSource item) => this._appending ? (Enumerable.AppendPrependIterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, new SingleLinkedNode<TSource>(item), new SingleLinkedNode<TSource>(this._item), 1, 1) : (Enumerable.AppendPrependIterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, new SingleLinkedNode<TSource>(this._item).Add(item), (SingleLinkedNode<TSource>) null, 2, 0);
    }

    private class AppendPrependN<TSource> : Enumerable.AppendPrependIterator<TSource>
    {
      private readonly SingleLinkedNode<TSource> _prepended;
      private readonly SingleLinkedNode<TSource> _appended;
      private readonly int _prependCount;
      private readonly int _appendCount;
      private SingleLinkedNode<TSource> _node;

      private TSource[] LazyToArray()
      {
        SparseArrayBuilder<TSource> sparseArrayBuilder = new SparseArrayBuilder<TSource>(true);
        if (this._prepended != null)
          sparseArrayBuilder.Reserve(this._prependCount);
        sparseArrayBuilder.AddRange(this._source);
        if (this._appended != null)
          sparseArrayBuilder.Reserve(this._appendCount);
        TSource[] array = sparseArrayBuilder.ToArray();
        int num1 = 0;
        for (SingleLinkedNode<TSource> singleLinkedNode = this._prepended; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
          array[num1++] = singleLinkedNode.Item;
        int num2 = array.Length - 1;
        for (SingleLinkedNode<TSource> singleLinkedNode = this._appended; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
          array[num2--] = singleLinkedNode.Item;
        return array;
      }

      public override TSource[] ToArray()
      {
        int count = this.GetCount(true);
        if (count == -1)
          return this.LazyToArray();
        TSource[] array = new TSource[count];
        int arrayIndex = 0;
        for (SingleLinkedNode<TSource> singleLinkedNode = this._prepended; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
        {
          array[arrayIndex] = singleLinkedNode.Item;
          ++arrayIndex;
        }
        if (this._source is ICollection<TSource> source)
        {
          source.CopyTo(array, arrayIndex);
        }
        else
        {
          foreach (TSource source in this._source)
          {
            array[arrayIndex] = source;
            ++arrayIndex;
          }
        }
        int length = array.Length;
        for (SingleLinkedNode<TSource> singleLinkedNode = this._appended; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
        {
          --length;
          array[length] = singleLinkedNode.Item;
        }
        return array;
      }

      public override List<TSource> ToList()
      {
        int count = this.GetCount(true);
        List<TSource> sourceList = count == -1 ? new List<TSource>() : new List<TSource>(count);
        for (SingleLinkedNode<TSource> singleLinkedNode = this._prepended; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
          sourceList.Add(singleLinkedNode.Item);
        sourceList.AddRange(this._source);
        if (this._appended != null)
          sourceList.AddRange((IEnumerable<TSource>) this._appended.ToArray(this._appendCount));
        return sourceList;
      }

      public override int GetCount(bool onlyIfCheap)
      {
        if (this._source is IIListProvider<TSource> source)
        {
          int count = source.GetCount(onlyIfCheap);
          return count != -1 ? count + this._appendCount + this._prependCount : -1;
        }
        return onlyIfCheap && !(this._source is ICollection<TSource>) ? -1 : this._source.Count<TSource>() + this._appendCount + this._prependCount;
      }

      public AppendPrependN(
        IEnumerable<TSource> source,
        SingleLinkedNode<TSource> prepended,
        SingleLinkedNode<TSource> appended,
        int prependCount,
        int appendCount)
        : base(source)
      {
        this._prepended = prepended;
        this._appended = appended;
        this._prependCount = prependCount;
        this._appendCount = appendCount;
      }

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, this._prepended, this._appended, this._prependCount, this._appendCount);

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._node = this._prepended;
            this._state = 2;
            goto case 2;
          case 2:
            if (this._node != null)
            {
              this._current = this._node.Item;
              this._node = this._node.Linked;
              return true;
            }
            this.GetSourceEnumerator();
            this._state = 3;
            goto case 3;
          case 3:
            if (this.LoadFromEnumerator())
              return true;
            if (this._appended == null)
              return false;
            this._enumerator = ((IEnumerable<TSource>) this._appended.ToArray(this._appendCount)).GetEnumerator();
            this._state = 4;
            goto case 4;
          case 4:
            return this.LoadFromEnumerator();
          default:
            this.Dispose();
            return false;
        }
      }

      public override Enumerable.AppendPrependIterator<TSource> Append(TSource item) => (Enumerable.AppendPrependIterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, this._prepended, this._appended != null ? this._appended.Add(item) : new SingleLinkedNode<TSource>(item), this._prependCount, this._appendCount + 1);

      public override Enumerable.AppendPrependIterator<TSource> Prepend(TSource item) => (Enumerable.AppendPrependIterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, this._prepended != null ? this._prepended.Add(item) : new SingleLinkedNode<TSource>(item), this._appended, this._prependCount + 1, this._appendCount);
    }

    private sealed class Concat2Iterator<TSource> : Enumerable.ConcatIterator<TSource>
    {
      internal readonly IEnumerable<TSource> _first;
      internal readonly IEnumerable<TSource> _second;

      public override int GetCount(bool onlyIfCheap)
      {
        int count1;
        if (!EnumerableHelpers.TryGetCount<TSource>(this._first, out count1))
        {
          if (onlyIfCheap)
            return -1;
          count1 = this._first.Count<TSource>();
        }
        int count2;
        if (!EnumerableHelpers.TryGetCount<TSource>(this._second, out count2))
        {
          if (onlyIfCheap)
            return -1;
          count2 = this._second.Count<TSource>();
        }
        return checked (count1 + count2);
      }

      public override TSource[] ToArray()
      {
        SparseArrayBuilder<TSource> sparseArrayBuilder = new SparseArrayBuilder<TSource>(true);
        bool flag1 = sparseArrayBuilder.ReserveOrAdd(this._first);
        bool flag2 = sparseArrayBuilder.ReserveOrAdd(this._second);
        TSource[] array = sparseArrayBuilder.ToArray();
        if (flag1)
        {
          Marker marker = sparseArrayBuilder.Markers.First();
          EnumerableHelpers.Copy<TSource>(this._first, array, 0, marker.Count);
        }
        if (flag2)
        {
          Marker marker = sparseArrayBuilder.Markers.Last();
          EnumerableHelpers.Copy<TSource>(this._second, array, marker.Index, marker.Count);
        }
        return array;
      }

      internal Concat2Iterator(IEnumerable<TSource> first, IEnumerable<TSource> second)
      {
        this._first = first;
        this._second = second;
      }

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.Concat2Iterator<TSource>(this._first, this._second);

      internal override Enumerable.ConcatIterator<TSource> Concat(
        IEnumerable<TSource> next)
      {
        bool hasOnlyCollections = next is ICollection<TSource> && this._first is ICollection<TSource> && this._second is ICollection<TSource>;
        return (Enumerable.ConcatIterator<TSource>) new Enumerable.ConcatNIterator<TSource>((Enumerable.ConcatIterator<TSource>) this, next, 2, hasOnlyCollections);
      }

      internal override IEnumerable<TSource> GetEnumerable(int index)
      {
        IEnumerable<TSource> sources;
        switch (index)
        {
          case 0:
            sources = this._first;
            break;
          case 1:
            sources = this._second;
            break;
          default:
            sources = (IEnumerable<TSource>) null;
            break;
        }
        return sources;
      }
    }

    private sealed class ConcatNIterator<TSource> : Enumerable.ConcatIterator<TSource>
    {
      private readonly Enumerable.ConcatIterator<TSource> _tail;
      private readonly IEnumerable<TSource> _head;
      private readonly int _headIndex;
      private readonly bool _hasOnlyCollections;

      public override int GetCount(bool onlyIfCheap)
      {
        if (onlyIfCheap && !this._hasOnlyCollections)
          return -1;
        int num1 = 0;
        Enumerable.ConcatNIterator<TSource> concatNiterator1 = this;
        Enumerable.ConcatNIterator<TSource> concatNiterator2;
        do
        {
          concatNiterator2 = concatNiterator1;
          IEnumerable<TSource> head = concatNiterator2._head;
          int num2 = head is ICollection<TSource> sources ? sources.Count : head.Count<TSource>();
          checked { num1 += num2; }
        }
        while ((concatNiterator1 = concatNiterator2.PreviousN) != null);
        return checked (num1 + concatNiterator2._tail.GetCount(onlyIfCheap));
      }

      public override TSource[] ToArray() => !this._hasOnlyCollections ? this.LazyToArray() : this.PreallocatingToArray();

      private TSource[] LazyToArray()
      {
        SparseArrayBuilder<TSource> sparseArrayBuilder = new SparseArrayBuilder<TSource>(true);
        ArrayBuilder<int> arrayBuilder = new ArrayBuilder<int>();
        int index1 = 0;
        while (true)
        {
          IEnumerable<TSource> enumerable = this.GetEnumerable(index1);
          if (enumerable != null)
          {
            if (sparseArrayBuilder.ReserveOrAdd(enumerable))
              arrayBuilder.Add(index1);
            ++index1;
          }
          else
            break;
        }
        TSource[] array = sparseArrayBuilder.ToArray();
        ArrayBuilder<Marker> markers = sparseArrayBuilder.Markers;
        for (int index2 = 0; index2 < markers.Count; ++index2)
        {
          Marker marker = markers[index2];
          EnumerableHelpers.Copy<TSource>(this.GetEnumerable(arrayBuilder[index2]), array, marker.Index, marker.Count);
        }
        return array;
      }

      private TSource[] PreallocatingToArray()
      {
        int count1 = this.GetCount(true);
        if (count1 == 0)
          return Array.Empty<TSource>();
        TSource[] array = new TSource[count1];
        int length = array.Length;
        Enumerable.ConcatNIterator<TSource> concatNiterator1 = this;
        Enumerable.ConcatNIterator<TSource> concatNiterator2;
        do
        {
          concatNiterator2 = concatNiterator1;
          ICollection<TSource> head = (ICollection<TSource>) concatNiterator2._head;
          int count2 = head.Count;
          if (count2 > 0)
          {
            checked { length -= count2; }
            head.CopyTo(array, length);
          }
        }
        while ((concatNiterator1 = concatNiterator2.PreviousN) != null);
        Enumerable.Concat2Iterator<TSource> tail = (Enumerable.Concat2Iterator<TSource>) concatNiterator2._tail;
        ICollection<TSource> second = (ICollection<TSource>) tail._second;
        int count3 = second.Count;
        if (count3 > 0)
          second.CopyTo(array, checked (length - count3));
        if (length > count3)
          ((ICollection<TSource>) tail._first).CopyTo(array, 0);
        return array;
      }

      internal ConcatNIterator(
        Enumerable.ConcatIterator<TSource> tail,
        IEnumerable<TSource> head,
        int headIndex,
        bool hasOnlyCollections)
      {
        this._tail = tail;
        this._head = head;
        this._headIndex = headIndex;
        this._hasOnlyCollections = hasOnlyCollections;
      }

      private Enumerable.ConcatNIterator<TSource> PreviousN => this._tail as Enumerable.ConcatNIterator<TSource>;

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.ConcatNIterator<TSource>(this._tail, this._head, this._headIndex, this._hasOnlyCollections);

      internal override Enumerable.ConcatIterator<TSource> Concat(
        IEnumerable<TSource> next)
      {
        if (this._headIndex == 2147483645)
          return (Enumerable.ConcatIterator<TSource>) new Enumerable.Concat2Iterator<TSource>((IEnumerable<TSource>) this, next);
        bool hasOnlyCollections = this._hasOnlyCollections && next is ICollection<TSource>;
        return (Enumerable.ConcatIterator<TSource>) new Enumerable.ConcatNIterator<TSource>((Enumerable.ConcatIterator<TSource>) this, next, this._headIndex + 1, hasOnlyCollections);
      }

      internal override IEnumerable<TSource> GetEnumerable(int index)
      {
        if (index > this._headIndex)
          return (IEnumerable<TSource>) null;
        Enumerable.ConcatNIterator<TSource> concatNiterator1 = this;
        Enumerable.ConcatNIterator<TSource> concatNiterator2;
        do
        {
          concatNiterator2 = concatNiterator1;
          if (index == concatNiterator2._headIndex)
            return concatNiterator2._head;
        }
        while ((concatNiterator1 = concatNiterator2.PreviousN) != null);
        return concatNiterator2._tail.GetEnumerable(index);
      }
    }

    private abstract class ConcatIterator<TSource> : 
      Enumerable.Iterator<TSource>,
      IIListProvider<TSource>,
      IEnumerable<TSource>,
      IEnumerable
    {
      private IEnumerator<TSource> _enumerator;

      public abstract int GetCount(bool onlyIfCheap);

      public abstract TSource[] ToArray();

      public List<TSource> ToList()
      {
        int count = this.GetCount(true);
        List<TSource> sourceList = count != -1 ? new List<TSource>(count) : new List<TSource>();
        int index = 0;
        while (true)
        {
          IEnumerable<TSource> enumerable = this.GetEnumerable(index);
          if (enumerable != null)
          {
            sourceList.AddRange(enumerable);
            ++index;
          }
          else
            break;
        }
        return sourceList;
      }

      public override void Dispose()
      {
        if (this._enumerator != null)
        {
          this._enumerator.Dispose();
          this._enumerator = (IEnumerator<TSource>) null;
        }
        base.Dispose();
      }

      internal abstract IEnumerable<TSource> GetEnumerable(int index);

      internal abstract Enumerable.ConcatIterator<TSource> Concat(
        IEnumerable<TSource> next);

      public override bool MoveNext()
      {
        if (this._state == 1)
        {
          this._enumerator = this.GetEnumerable(0).GetEnumerator();
          this._state = 2;
        }
        if (this._state > 1)
        {
          IEnumerable<TSource> enumerable;
          for (; !this._enumerator.MoveNext(); this._enumerator = enumerable.GetEnumerator())
          {
            enumerable = this.GetEnumerable(this._state++ - 1);
            if (enumerable != null)
            {
              this._enumerator.Dispose();
            }
            else
            {
              this.Dispose();
              goto label_8;
            }
          }
          this._current = this._enumerator.Current;
          return true;
        }
label_8:
        return false;
      }
    }

    private sealed class DefaultIfEmptyIterator<TSource> : 
      Enumerable.Iterator<TSource>,
      IIListProvider<TSource>,
      IEnumerable<TSource>,
      IEnumerable
    {
      private readonly IEnumerable<TSource> _source;
      private readonly TSource _default;
      private IEnumerator<TSource> _enumerator;

      public TSource[] ToArray()
      {
        TSource[] array = this._source.ToArray<TSource>();
        if (array.Length != 0)
          return array;
        return new TSource[1]{ this._default };
      }

      public List<TSource> ToList()
      {
        List<TSource> list = this._source.ToList<TSource>();
        if (list.Count == 0)
          list.Add(this._default);
        return list;
      }

      public int GetCount(bool onlyIfCheap)
      {
        int num = !onlyIfCheap || this._source is ICollection<TSource> || this._source is ICollection ? this._source.Count<TSource>() : (this._source is IIListProvider<TSource> source ? source.GetCount(true) : -1);
        return num != 0 ? num : 1;
      }

      public DefaultIfEmptyIterator(IEnumerable<TSource> source, TSource defaultValue)
      {
        this._source = source;
        this._default = defaultValue;
      }

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.DefaultIfEmptyIterator<TSource>(this._source, this._default);

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._enumerator = this._source.GetEnumerator();
            if (this._enumerator.MoveNext())
            {
              this._current = this._enumerator.Current;
              this._state = 2;
            }
            else
            {
              this._current = this._default;
              this._state = -1;
            }
            return true;
          case 2:
            if (this._enumerator.MoveNext())
            {
              this._current = this._enumerator.Current;
              return true;
            }
            break;
        }
        this.Dispose();
        return false;
      }

      public override void Dispose()
      {
        if (this._enumerator != null)
        {
          this._enumerator.Dispose();
          this._enumerator = (IEnumerator<TSource>) null;
        }
        base.Dispose();
      }
    }

    private sealed class DistinctIterator<TSource> : 
      Enumerable.Iterator<TSource>,
      IIListProvider<TSource>,
      IEnumerable<TSource>,
      IEnumerable
    {
      private readonly IEnumerable<TSource> _source;
      private readonly IEqualityComparer<TSource> _comparer;
      private Set<TSource> _set;
      private IEnumerator<TSource> _enumerator;

      private Set<TSource> FillSet()
      {
        Set<TSource> set = new Set<TSource>(this._comparer);
        set.UnionWith(this._source);
        return set;
      }

      public TSource[] ToArray() => this.FillSet().ToArray();

      public List<TSource> ToList() => this.FillSet().ToList();

      public int GetCount(bool onlyIfCheap) => !onlyIfCheap ? this.FillSet().Count : -1;

      public DistinctIterator(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
      {
        this._source = source;
        this._comparer = comparer;
      }

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.DistinctIterator<TSource>(this._source, this._comparer);

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._enumerator = this._source.GetEnumerator();
            if (!this._enumerator.MoveNext())
            {
              this.Dispose();
              return false;
            }
            TSource current1 = this._enumerator.Current;
            this._set = new Set<TSource>(this._comparer);
            this._set.Add(current1);
            this._current = current1;
            this._state = 2;
            return true;
          case 2:
            while (this._enumerator.MoveNext())
            {
              TSource current2 = this._enumerator.Current;
              if (this._set.Add(current2))
              {
                this._current = current2;
                return true;
              }
            }
            break;
        }
        this.Dispose();
        return false;
      }

      public override void Dispose()
      {
        if (this._enumerator != null)
        {
          this._enumerator.Dispose();
          this._enumerator = (IEnumerator<TSource>) null;
          this._set = (Set<TSource>) null;
        }
        base.Dispose();
      }
    }

    [DebuggerDisplay("Count = {Count}")]
    private sealed class ListPartition<TSource> : 
      Enumerable.Iterator<TSource>,
      IPartition<TSource>,
      IIListProvider<TSource>,
      IEnumerable<TSource>,
      IEnumerable
    {
      private readonly IList<TSource> _source;
      private readonly int _minIndexInclusive;
      private readonly int _maxIndexInclusive;

      public ListPartition(IList<TSource> source, int minIndexInclusive, int maxIndexInclusive)
      {
        this._source = source;
        this._minIndexInclusive = minIndexInclusive;
        this._maxIndexInclusive = maxIndexInclusive;
      }

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.ListPartition<TSource>(this._source, this._minIndexInclusive, this._maxIndexInclusive);

      public override bool MoveNext()
      {
        int num = this._state - 1;
        if ((uint) num <= (uint) (this._maxIndexInclusive - this._minIndexInclusive) && num < this._source.Count - this._minIndexInclusive)
        {
          this._current = this._source[this._minIndexInclusive + num];
          ++this._state;
          return true;
        }
        this.Dispose();
        return false;
      }

      public override IEnumerable<TResult> Select<TResult>(
        Func<TSource, TResult> selector)
      {
        return (IEnumerable<TResult>) new Enumerable.SelectListPartitionIterator<TSource, TResult>(this._source, selector, this._minIndexInclusive, this._maxIndexInclusive);
      }

      public IPartition<TSource> Skip(int count)
      {
        int minIndexInclusive = this._minIndexInclusive + count;
        return (uint) minIndexInclusive <= (uint) this._maxIndexInclusive ? (IPartition<TSource>) new Enumerable.ListPartition<TSource>(this._source, minIndexInclusive, this._maxIndexInclusive) : EmptyPartition<TSource>.Instance;
      }

      public IPartition<TSource> Take(int count)
      {
        int maxIndexInclusive = this._minIndexInclusive + count - 1;
        return (uint) maxIndexInclusive < (uint) this._maxIndexInclusive ? (IPartition<TSource>) new Enumerable.ListPartition<TSource>(this._source, this._minIndexInclusive, maxIndexInclusive) : (IPartition<TSource>) this;
      }

      public TSource TryGetElementAt(int index, out bool found)
      {
        if ((uint) index <= (uint) (this._maxIndexInclusive - this._minIndexInclusive) && index < this._source.Count - this._minIndexInclusive)
        {
          found = true;
          return this._source[this._minIndexInclusive + index];
        }
        found = false;
        return default (TSource);
      }

      public TSource TryGetFirst(out bool found)
      {
        if (this._source.Count > this._minIndexInclusive)
        {
          found = true;
          return this._source[this._minIndexInclusive];
        }
        found = false;
        return default (TSource);
      }

      public TSource TryGetLast(out bool found)
      {
        int val1 = this._source.Count - 1;
        if (val1 >= this._minIndexInclusive)
        {
          found = true;
          return this._source[Math.Min(val1, this._maxIndexInclusive)];
        }
        found = false;
        return default (TSource);
      }

      private int Count
      {
        get
        {
          int count = this._source.Count;
          return count <= this._minIndexInclusive ? 0 : Math.Min(count - 1, this._maxIndexInclusive) - this._minIndexInclusive + 1;
        }
      }

      public TSource[] ToArray()
      {
        int count = this.Count;
        if (count == 0)
          return Array.Empty<TSource>();
        TSource[] sourceArray = new TSource[count];
        int index = 0;
        int minIndexInclusive = this._minIndexInclusive;
        while (index != sourceArray.Length)
        {
          sourceArray[index] = this._source[minIndexInclusive];
          ++index;
          ++minIndexInclusive;
        }
        return sourceArray;
      }

      public List<TSource> ToList()
      {
        int count = this.Count;
        if (count == 0)
          return new List<TSource>();
        List<TSource> sourceList = new List<TSource>(count);
        int num = this._minIndexInclusive + count;
        for (int minIndexInclusive = this._minIndexInclusive; minIndexInclusive != num; ++minIndexInclusive)
          sourceList.Add(this._source[minIndexInclusive]);
        return sourceList;
      }

      public int GetCount(bool onlyIfCheap) => this.Count;
    }

    private sealed class EnumerablePartition<TSource> : 
      Enumerable.Iterator<TSource>,
      IPartition<TSource>,
      IIListProvider<TSource>,
      IEnumerable<TSource>,
      IEnumerable
    {
      private readonly IEnumerable<TSource> _source;
      private readonly int _minIndexInclusive;
      private readonly int _maxIndexInclusive;
      private IEnumerator<TSource> _enumerator;

      internal EnumerablePartition(
        IEnumerable<TSource> source,
        int minIndexInclusive,
        int maxIndexInclusive)
      {
        this._source = source;
        this._minIndexInclusive = minIndexInclusive;
        this._maxIndexInclusive = maxIndexInclusive;
      }

      private bool HasLimit => this._maxIndexInclusive != -1;

      private int Limit => this._maxIndexInclusive + 1 - this._minIndexInclusive;

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.EnumerablePartition<TSource>(this._source, this._minIndexInclusive, this._maxIndexInclusive);

      public override void Dispose()
      {
        if (this._enumerator != null)
        {
          this._enumerator.Dispose();
          this._enumerator = (IEnumerator<TSource>) null;
        }
        base.Dispose();
      }

      public int GetCount(bool onlyIfCheap)
      {
        if (onlyIfCheap)
          return -1;
        if (!this.HasLimit)
          return Math.Max(this._source.Count<TSource>() - this._minIndexInclusive, 0);
        using (IEnumerator<TSource> enumerator = this._source.GetEnumerator())
          return Math.Max((int) Enumerable.EnumerablePartition<TSource>.SkipAndCount((uint) (this._maxIndexInclusive + 1), enumerator) - this._minIndexInclusive, 0);
      }

      public override bool MoveNext()
      {
        int num = this._state - 3;
        if (num < -2)
        {
          this.Dispose();
          return false;
        }
        switch (this._state)
        {
          case 1:
            this._enumerator = this._source.GetEnumerator();
            this._state = 2;
            goto case 2;
          case 2:
            if (this.SkipBeforeFirst(this._enumerator))
            {
              this._state = 3;
              goto default;
            }
            else
              break;
          default:
            if ((!this.HasLimit || num < this.Limit) && this._enumerator.MoveNext())
            {
              if (this.HasLimit)
                ++this._state;
              this._current = this._enumerator.Current;
              return true;
            }
            break;
        }
        this.Dispose();
        return false;
      }

      public override IEnumerable<TResult> Select<TResult>(
        Func<TSource, TResult> selector)
      {
        return (IEnumerable<TResult>) new Enumerable.SelectIPartitionIterator<TSource, TResult>((IPartition<TSource>) this, selector);
      }

      public IPartition<TSource> Skip(int count)
      {
        int minIndexInclusive = this._minIndexInclusive + count;
        if (!this.HasLimit)
        {
          if (minIndexInclusive < 0)
            return (IPartition<TSource>) new Enumerable.EnumerablePartition<TSource>((IEnumerable<TSource>) this, count, -1);
        }
        else if ((uint) minIndexInclusive > (uint) this._maxIndexInclusive)
          return EmptyPartition<TSource>.Instance;
        return (IPartition<TSource>) new Enumerable.EnumerablePartition<TSource>(this._source, minIndexInclusive, this._maxIndexInclusive);
      }

      public IPartition<TSource> Take(int count)
      {
        int maxIndexInclusive = this._minIndexInclusive + count - 1;
        if (!this.HasLimit)
        {
          if (maxIndexInclusive < 0)
            return (IPartition<TSource>) new Enumerable.EnumerablePartition<TSource>((IEnumerable<TSource>) this, 0, count - 1);
        }
        else if ((uint) maxIndexInclusive >= (uint) this._maxIndexInclusive)
          return (IPartition<TSource>) this;
        return (IPartition<TSource>) new Enumerable.EnumerablePartition<TSource>(this._source, this._minIndexInclusive, maxIndexInclusive);
      }

      public TSource TryGetElementAt(int index, out bool found)
      {
        if (index >= 0 && (!this.HasLimit || index < this.Limit))
        {
          using (IEnumerator<TSource> enumerator = this._source.GetEnumerator())
          {
            if (Enumerable.EnumerablePartition<TSource>.SkipBefore(this._minIndexInclusive + index, enumerator))
            {
              if (enumerator.MoveNext())
              {
                found = true;
                return enumerator.Current;
              }
            }
          }
        }
        found = false;
        return default (TSource);
      }

      public TSource TryGetFirst(out bool found)
      {
        using (IEnumerator<TSource> enumerator = this._source.GetEnumerator())
        {
          if (this.SkipBeforeFirst(enumerator))
          {
            if (enumerator.MoveNext())
            {
              found = true;
              return enumerator.Current;
            }
          }
        }
        found = false;
        return default (TSource);
      }

      public TSource TryGetLast(out bool found)
      {
        using (IEnumerator<TSource> enumerator = this._source.GetEnumerator())
        {
          if (this.SkipBeforeFirst(enumerator))
          {
            if (enumerator.MoveNext())
            {
              int num1 = this.Limit - 1;
              int num2 = this.HasLimit ? 0 : int.MinValue;
              TSource current;
              do
              {
                --num1;
                current = enumerator.Current;
              }
              while (num1 >= num2 && enumerator.MoveNext());
              found = true;
              return current;
            }
          }
        }
        found = false;
        return default (TSource);
      }

      public TSource[] ToArray()
      {
        using (IEnumerator<TSource> enumerator = this._source.GetEnumerator())
        {
          if (this.SkipBeforeFirst(enumerator))
          {
            if (enumerator.MoveNext())
            {
              int num1 = this.Limit - 1;
              int num2 = this.HasLimit ? 0 : int.MinValue;
              LargeArrayBuilder<TSource> largeArrayBuilder = new LargeArrayBuilder<TSource>(this.HasLimit ? this.Limit : int.MaxValue);
              do
              {
                --num1;
                largeArrayBuilder.Add(enumerator.Current);
              }
              while (num1 >= num2 && enumerator.MoveNext());
              return largeArrayBuilder.ToArray();
            }
          }
        }
        return Array.Empty<TSource>();
      }

      public List<TSource> ToList()
      {
        List<TSource> sourceList = new List<TSource>();
        using (IEnumerator<TSource> enumerator = this._source.GetEnumerator())
        {
          if (this.SkipBeforeFirst(enumerator))
          {
            if (enumerator.MoveNext())
            {
              int num1 = this.Limit - 1;
              int num2 = this.HasLimit ? 0 : int.MinValue;
              do
              {
                --num1;
                sourceList.Add(enumerator.Current);
                if (num1 < num2)
                  break;
              }
              while (enumerator.MoveNext());
            }
          }
        }
        return sourceList;
      }

      private bool SkipBeforeFirst(IEnumerator<TSource> en) => Enumerable.EnumerablePartition<TSource>.SkipBefore(this._minIndexInclusive, en);

      private static bool SkipBefore(int index, IEnumerator<TSource> en) => Enumerable.EnumerablePartition<TSource>.SkipAndCount(index, en) == index;

      private static int SkipAndCount(int index, IEnumerator<TSource> en) => (int) Enumerable.EnumerablePartition<TSource>.SkipAndCount((uint) index, en);

      private static uint SkipAndCount(uint index, IEnumerator<TSource> en)
      {
        for (uint index1 = 0; index1 < index; ++index1)
        {
          if (!en.MoveNext())
            return index1;
        }
        return index;
      }
    }

    [DebuggerDisplay("Count = {CountForDebugger}")]
    private sealed class RangeIterator : 
      Enumerable.Iterator<int>,
      IPartition<int>,
      IIListProvider<int>,
      IEnumerable<int>,
      IEnumerable
    {
      private readonly int _start;
      private readonly int _end;

      public override IEnumerable<TResult> Select<TResult>(Func<int, TResult> selector) => (IEnumerable<TResult>) new Enumerable.SelectRangeIterator<TResult>(this._start, this._end, selector);

      public int[] ToArray()
      {
        int[] numArray = new int[this._end - this._start];
        int start = this._start;
        for (int index = 0; index != numArray.Length; ++index)
        {
          numArray[index] = start;
          ++start;
        }
        return numArray;
      }

      public List<int> ToList()
      {
        List<int> intList = new List<int>(this._end - this._start);
        for (int start = this._start; start != this._end; ++start)
          intList.Add(start);
        return intList;
      }

      public int GetCount(bool onlyIfCheap) => this._end - this._start;

      public IPartition<int> Skip(int count) => count >= this._end - this._start ? EmptyPartition<int>.Instance : (IPartition<int>) new Enumerable.RangeIterator(this._start + count, this._end - this._start - count);

      public IPartition<int> Take(int count)
      {
        int num = this._end - this._start;
        return count >= num ? (IPartition<int>) this : (IPartition<int>) new Enumerable.RangeIterator(this._start, count);
      }

      public int TryGetElementAt(int index, out bool found)
      {
        if ((uint) index < (uint) (this._end - this._start))
        {
          found = true;
          return this._start + index;
        }
        found = false;
        return 0;
      }

      public int TryGetFirst(out bool found)
      {
        found = true;
        return this._start;
      }

      public int TryGetLast(out bool found)
      {
        found = true;
        return this._end - 1;
      }

      public RangeIterator(int start, int count)
      {
        this._start = start;
        this._end = start + count;
      }

      private int CountForDebugger => this._end - this._start;

      public override Enumerable.Iterator<int> Clone() => (Enumerable.Iterator<int>) new Enumerable.RangeIterator(this._start, this._end - this._start);

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._current = this._start;
            this._state = 2;
            return true;
          case 2:
            if (++this._current != this._end)
              return true;
            break;
        }
        this._state = -1;
        return false;
      }

      public override void Dispose() => this._state = -1;
    }

    [DebuggerDisplay("Count = {_count}")]
    private sealed class RepeatIterator<TResult> : 
      Enumerable.Iterator<TResult>,
      IPartition<TResult>,
      IIListProvider<TResult>,
      IEnumerable<TResult>,
      IEnumerable
    {
      private readonly int _count;

      public override IEnumerable<TResult2> Select<TResult2>(
        Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.SelectIPartitionIterator<TResult, TResult2>((IPartition<TResult>) this, selector);
      }

      public TResult[] ToArray()
      {
        TResult[] array = new TResult[this._count];
        if ((object) this._current != null)
          Array.Fill<TResult>(array, this._current);
        return array;
      }

      public List<TResult> ToList()
      {
        List<TResult> resultList = new List<TResult>(this._count);
        for (int index = 0; index != this._count; ++index)
          resultList.Add(this._current);
        return resultList;
      }

      public int GetCount(bool onlyIfCheap) => this._count;

      public IPartition<TResult> Skip(int count) => count >= this._count ? EmptyPartition<TResult>.Instance : (IPartition<TResult>) new Enumerable.RepeatIterator<TResult>(this._current, this._count - count);

      public IPartition<TResult> Take(int count) => count >= this._count ? (IPartition<TResult>) this : (IPartition<TResult>) new Enumerable.RepeatIterator<TResult>(this._current, count);

      public TResult TryGetElementAt(int index, out bool found)
      {
        if ((uint) index < (uint) this._count)
        {
          found = true;
          return this._current;
        }
        found = false;
        return default (TResult);
      }

      public TResult TryGetFirst(out bool found)
      {
        found = true;
        return this._current;
      }

      public TResult TryGetLast(out bool found)
      {
        found = true;
        return this._current;
      }

      public RepeatIterator(TResult element, int count)
      {
        this._current = element;
        this._count = count;
      }

      public override Enumerable.Iterator<TResult> Clone() => (Enumerable.Iterator<TResult>) new Enumerable.RepeatIterator<TResult>(this._current, this._count);

      public override void Dispose() => this._state = -1;

      public override bool MoveNext()
      {
        int num = this._state - 1;
        if (num >= 0 && num != this._count)
        {
          ++this._state;
          return true;
        }
        this.Dispose();
        return false;
      }
    }

    private sealed class ReverseIterator<TSource> : 
      Enumerable.Iterator<TSource>,
      IIListProvider<TSource>,
      IEnumerable<TSource>,
      IEnumerable
    {
      private readonly IEnumerable<TSource> _source;
      private TSource[] _buffer;

      public TSource[] ToArray()
      {
        TSource[] array = this._source.ToArray<TSource>();
        Array.Reverse<TSource>(array);
        return array;
      }

      public List<TSource> ToList()
      {
        List<TSource> list = this._source.ToList<TSource>();
        list.Reverse();
        return list;
      }

      public int GetCount(bool onlyIfCheap)
      {
        if (!onlyIfCheap)
          return this._source.Count<TSource>();
        int num;
        switch (this._source)
        {
          case IIListProvider<TSource> ilistProvider:
            num = ilistProvider.GetCount(true);
            break;
          case ICollection<TSource> sources:
            num = sources.Count;
            break;
          case ICollection collection:
            num = collection.Count;
            break;
          default:
            num = -1;
            break;
        }
        return num;
      }

      public ReverseIterator(IEnumerable<TSource> source) => this._source = source;

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.ReverseIterator<TSource>(this._source);

      public override bool MoveNext()
      {
        if (this._state - 2 <= -2)
        {
          this.Dispose();
          return false;
        }
        if (this._state == 1)
        {
          Buffer<TSource> buffer = new Buffer<TSource>(this._source);
          this._buffer = buffer._items;
          this._state = buffer._count + 2;
        }
        int index = this._state - 3;
        if (index != -1)
        {
          this._current = this._buffer[index];
          --this._state;
          return true;
        }
        this.Dispose();
        return false;
      }

      public override void Dispose()
      {
        this._buffer = (TSource[]) null;
        base.Dispose();
      }
    }

    private sealed class SelectEnumerableIterator<TSource, TResult> : 
      Enumerable.Iterator<TResult>,
      IIListProvider<TResult>,
      IEnumerable<TResult>,
      IEnumerable
    {
      private readonly IEnumerable<TSource> _source;
      private readonly Func<TSource, TResult> _selector;
      private IEnumerator<TSource> _enumerator;

      public TResult[] ToArray()
      {
        LargeArrayBuilder<TResult> largeArrayBuilder = new LargeArrayBuilder<TResult>(true);
        foreach (TSource source in this._source)
          largeArrayBuilder.Add(this._selector(source));
        return largeArrayBuilder.ToArray();
      }

      public List<TResult> ToList()
      {
        List<TResult> resultList = new List<TResult>();
        foreach (TSource source in this._source)
          resultList.Add(this._selector(source));
        return resultList;
      }

      public int GetCount(bool onlyIfCheap)
      {
        if (onlyIfCheap)
          return -1;
        int num = 0;
        foreach (TSource source in this._source)
        {
          TResult result = this._selector(source);
          checked { ++num; }
        }
        return num;
      }

      public SelectEnumerableIterator(IEnumerable<TSource> source, Func<TSource, TResult> selector)
      {
        this._source = source;
        this._selector = selector;
      }

      public override Enumerable.Iterator<TResult> Clone() => (Enumerable.Iterator<TResult>) new Enumerable.SelectEnumerableIterator<TSource, TResult>(this._source, this._selector);

      public override void Dispose()
      {
        if (this._enumerator != null)
        {
          this._enumerator.Dispose();
          this._enumerator = (IEnumerator<TSource>) null;
        }
        base.Dispose();
      }

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._enumerator = this._source.GetEnumerator();
            this._state = 2;
            goto case 2;
          case 2:
            if (this._enumerator.MoveNext())
            {
              this._current = this._selector(this._enumerator.Current);
              return true;
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override IEnumerable<TResult2> Select<TResult2>(
        Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.SelectEnumerableIterator<TSource, TResult2>(this._source, Utilities.CombineSelectors<TSource, TResult, TResult2>(this._selector, selector));
      }
    }

    [DebuggerDisplay("Count = {CountForDebugger}")]
    private sealed class SelectArrayIterator<TSource, TResult> : 
      Enumerable.Iterator<TResult>,
      IPartition<TResult>,
      IIListProvider<TResult>,
      IEnumerable<TResult>,
      IEnumerable
    {
      private readonly TSource[] _source;
      private readonly Func<TSource, TResult> _selector;

      public TResult[] ToArray()
      {
        TResult[] resultArray = new TResult[this._source.Length];
        for (int index = 0; index < resultArray.Length; ++index)
          resultArray[index] = this._selector(this._source[index]);
        return resultArray;
      }

      public List<TResult> ToList()
      {
        TSource[] source = this._source;
        List<TResult> resultList = new List<TResult>(source.Length);
        for (int index = 0; index < source.Length; ++index)
          resultList.Add(this._selector(source[index]));
        return resultList;
      }

      public int GetCount(bool onlyIfCheap)
      {
        if (!onlyIfCheap)
        {
          foreach (TSource source in this._source)
          {
            TResult result = this._selector(source);
          }
        }
        return this._source.Length;
      }

      public IPartition<TResult> Skip(int count) => count >= this._source.Length ? EmptyPartition<TResult>.Instance : (IPartition<TResult>) new Enumerable.SelectListPartitionIterator<TSource, TResult>((IList<TSource>) this._source, this._selector, count, int.MaxValue);

      public IPartition<TResult> Take(int count) => count < this._source.Length ? (IPartition<TResult>) new Enumerable.SelectListPartitionIterator<TSource, TResult>((IList<TSource>) this._source, this._selector, 0, count - 1) : (IPartition<TResult>) this;

      public TResult TryGetElementAt(int index, out bool found)
      {
        if ((uint) index < (uint) this._source.Length)
        {
          found = true;
          return this._selector(this._source[index]);
        }
        found = false;
        return default (TResult);
      }

      public TResult TryGetFirst(out bool found)
      {
        found = true;
        return this._selector(this._source[0]);
      }

      public TResult TryGetLast(out bool found)
      {
        found = true;
        return this._selector(this._source[this._source.Length - 1]);
      }

      public SelectArrayIterator(TSource[] source, Func<TSource, TResult> selector)
      {
        this._source = source;
        this._selector = selector;
      }

      private int CountForDebugger => this._source.Length;

      public override Enumerable.Iterator<TResult> Clone() => (Enumerable.Iterator<TResult>) new Enumerable.SelectArrayIterator<TSource, TResult>(this._source, this._selector);

      public override bool MoveNext()
      {
        if (this._state < 1 | this._state == this._source.Length + 1)
        {
          this.Dispose();
          return false;
        }
        this._current = this._selector(this._source[this._state++ - 1]);
        return true;
      }

      public override IEnumerable<TResult2> Select<TResult2>(
        Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.SelectArrayIterator<TSource, TResult2>(this._source, Utilities.CombineSelectors<TSource, TResult, TResult2>(this._selector, selector));
      }
    }

    private sealed class SelectRangeIterator<TResult> : 
      Enumerable.Iterator<TResult>,
      IPartition<TResult>,
      IIListProvider<TResult>,
      IEnumerable<TResult>,
      IEnumerable
    {
      private readonly int _start;
      private readonly int _end;
      private readonly Func<int, TResult> _selector;

      public SelectRangeIterator(int start, int end, Func<int, TResult> selector)
      {
        this._start = start;
        this._end = end;
        this._selector = selector;
      }

      public override Enumerable.Iterator<TResult> Clone() => (Enumerable.Iterator<TResult>) new Enumerable.SelectRangeIterator<TResult>(this._start, this._end, this._selector);

      public override bool MoveNext()
      {
        if (this._state < 1 || this._state == this._end - this._start + 1)
        {
          this.Dispose();
          return false;
        }
        this._current = this._selector(this._start + (this._state++ - 1));
        return true;
      }

      public override IEnumerable<TResult2> Select<TResult2>(
        Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.SelectRangeIterator<TResult2>(this._start, this._end, Utilities.CombineSelectors<int, TResult, TResult2>(this._selector, selector));
      }

      public TResult[] ToArray()
      {
        TResult[] resultArray = new TResult[this._end - this._start];
        int start = this._start;
        for (int index = 0; index < resultArray.Length; ++index)
          resultArray[index] = this._selector(start++);
        return resultArray;
      }

      public List<TResult> ToList()
      {
        List<TResult> resultList = new List<TResult>(this._end - this._start);
        for (int start = this._start; start != this._end; ++start)
          resultList.Add(this._selector(start));
        return resultList;
      }

      public int GetCount(bool onlyIfCheap)
      {
        if (!onlyIfCheap)
        {
          for (int start = this._start; start != this._end; ++start)
          {
            TResult result = this._selector(start);
          }
        }
        return this._end - this._start;
      }

      public IPartition<TResult> Skip(int count) => count >= this._end - this._start ? EmptyPartition<TResult>.Instance : (IPartition<TResult>) new Enumerable.SelectRangeIterator<TResult>(this._start + count, this._end, this._selector);

      public IPartition<TResult> Take(int count) => count >= this._end - this._start ? (IPartition<TResult>) this : (IPartition<TResult>) new Enumerable.SelectRangeIterator<TResult>(this._start, this._start + count, this._selector);

      public TResult TryGetElementAt(int index, out bool found)
      {
        if ((uint) index < (uint) (this._end - this._start))
        {
          found = true;
          return this._selector(this._start + index);
        }
        found = false;
        return default (TResult);
      }

      public TResult TryGetFirst(out bool found)
      {
        found = true;
        return this._selector(this._start);
      }

      public TResult TryGetLast(out bool found)
      {
        found = true;
        return this._selector(this._end - 1);
      }
    }

    [DebuggerDisplay("Count = {CountForDebugger}")]
    private sealed class SelectListIterator<TSource, TResult> : 
      Enumerable.Iterator<TResult>,
      IPartition<TResult>,
      IIListProvider<TResult>,
      IEnumerable<TResult>,
      IEnumerable
    {
      private readonly List<TSource> _source;
      private readonly Func<TSource, TResult> _selector;
      private List<TSource>.Enumerator _enumerator;

      public TResult[] ToArray()
      {
        int count = this._source.Count;
        if (count == 0)
          return Array.Empty<TResult>();
        TResult[] resultArray = new TResult[count];
        for (int index = 0; index < resultArray.Length; ++index)
          resultArray[index] = this._selector(this._source[index]);
        return resultArray;
      }

      public List<TResult> ToList()
      {
        int count = this._source.Count;
        List<TResult> resultList = new List<TResult>(count);
        for (int index = 0; index < count; ++index)
          resultList.Add(this._selector(this._source[index]));
        return resultList;
      }

      public int GetCount(bool onlyIfCheap)
      {
        int count = this._source.Count;
        if (!onlyIfCheap)
        {
          for (int index = 0; index < count; ++index)
          {
            TResult result = this._selector(this._source[index]);
          }
        }
        return count;
      }

      public IPartition<TResult> Skip(int count) => (IPartition<TResult>) new Enumerable.SelectListPartitionIterator<TSource, TResult>((IList<TSource>) this._source, this._selector, count, int.MaxValue);

      public IPartition<TResult> Take(int count) => (IPartition<TResult>) new Enumerable.SelectListPartitionIterator<TSource, TResult>((IList<TSource>) this._source, this._selector, 0, count - 1);

      public TResult TryGetElementAt(int index, out bool found)
      {
        if ((uint) index < (uint) this._source.Count)
        {
          found = true;
          return this._selector(this._source[index]);
        }
        found = false;
        return default (TResult);
      }

      public TResult TryGetFirst(out bool found)
      {
        if (this._source.Count != 0)
        {
          found = true;
          return this._selector(this._source[0]);
        }
        found = false;
        return default (TResult);
      }

      public TResult TryGetLast(out bool found)
      {
        int count = this._source.Count;
        if (count != 0)
        {
          found = true;
          return this._selector(this._source[count - 1]);
        }
        found = false;
        return default (TResult);
      }

      public SelectListIterator(List<TSource> source, Func<TSource, TResult> selector)
      {
        this._source = source;
        this._selector = selector;
      }

      private int CountForDebugger => this._source.Count;

      public override Enumerable.Iterator<TResult> Clone() => (Enumerable.Iterator<TResult>) new Enumerable.SelectListIterator<TSource, TResult>(this._source, this._selector);

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._enumerator = this._source.GetEnumerator();
            this._state = 2;
            goto case 2;
          case 2:
            if (this._enumerator.MoveNext())
            {
              this._current = this._selector(this._enumerator.Current);
              return true;
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override IEnumerable<TResult2> Select<TResult2>(
        Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.SelectListIterator<TSource, TResult2>(this._source, Utilities.CombineSelectors<TSource, TResult, TResult2>(this._selector, selector));
      }
    }

    [DebuggerDisplay("Count = {CountForDebugger}")]
    private sealed class SelectIListIterator<TSource, TResult> : 
      Enumerable.Iterator<TResult>,
      IPartition<TResult>,
      IIListProvider<TResult>,
      IEnumerable<TResult>,
      IEnumerable
    {
      private readonly IList<TSource> _source;
      private readonly Func<TSource, TResult> _selector;
      private IEnumerator<TSource> _enumerator;

      public TResult[] ToArray()
      {
        int count = this._source.Count;
        if (count == 0)
          return Array.Empty<TResult>();
        TResult[] resultArray = new TResult[count];
        for (int index = 0; index < resultArray.Length; ++index)
          resultArray[index] = this._selector(this._source[index]);
        return resultArray;
      }

      public List<TResult> ToList()
      {
        int count = this._source.Count;
        List<TResult> resultList = new List<TResult>(count);
        for (int index = 0; index < count; ++index)
          resultList.Add(this._selector(this._source[index]));
        return resultList;
      }

      public int GetCount(bool onlyIfCheap)
      {
        int count = this._source.Count;
        if (!onlyIfCheap)
        {
          for (int index = 0; index < count; ++index)
          {
            TResult result = this._selector(this._source[index]);
          }
        }
        return count;
      }

      public IPartition<TResult> Skip(int count) => (IPartition<TResult>) new Enumerable.SelectListPartitionIterator<TSource, TResult>(this._source, this._selector, count, int.MaxValue);

      public IPartition<TResult> Take(int count) => (IPartition<TResult>) new Enumerable.SelectListPartitionIterator<TSource, TResult>(this._source, this._selector, 0, count - 1);

      public TResult TryGetElementAt(int index, out bool found)
      {
        if ((uint) index < (uint) this._source.Count)
        {
          found = true;
          return this._selector(this._source[index]);
        }
        found = false;
        return default (TResult);
      }

      public TResult TryGetFirst(out bool found)
      {
        if (this._source.Count != 0)
        {
          found = true;
          return this._selector(this._source[0]);
        }
        found = false;
        return default (TResult);
      }

      public TResult TryGetLast(out bool found)
      {
        int count = this._source.Count;
        if (count != 0)
        {
          found = true;
          return this._selector(this._source[count - 1]);
        }
        found = false;
        return default (TResult);
      }

      public SelectIListIterator(IList<TSource> source, Func<TSource, TResult> selector)
      {
        this._source = source;
        this._selector = selector;
      }

      private int CountForDebugger => this._source.Count;

      public override Enumerable.Iterator<TResult> Clone() => (Enumerable.Iterator<TResult>) new Enumerable.SelectIListIterator<TSource, TResult>(this._source, this._selector);

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._enumerator = this._source.GetEnumerator();
            this._state = 2;
            goto case 2;
          case 2:
            if (this._enumerator.MoveNext())
            {
              this._current = this._selector(this._enumerator.Current);
              return true;
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override void Dispose()
      {
        if (this._enumerator != null)
        {
          this._enumerator.Dispose();
          this._enumerator = (IEnumerator<TSource>) null;
        }
        base.Dispose();
      }

      public override IEnumerable<TResult2> Select<TResult2>(
        Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.SelectIListIterator<TSource, TResult2>(this._source, Utilities.CombineSelectors<TSource, TResult, TResult2>(this._selector, selector));
      }
    }

    private sealed class SelectIPartitionIterator<TSource, TResult> : 
      Enumerable.Iterator<TResult>,
      IPartition<TResult>,
      IIListProvider<TResult>,
      IEnumerable<TResult>,
      IEnumerable
    {
      private readonly IPartition<TSource> _source;
      private readonly Func<TSource, TResult> _selector;
      private IEnumerator<TSource> _enumerator;

      public SelectIPartitionIterator(IPartition<TSource> source, Func<TSource, TResult> selector)
      {
        this._source = source;
        this._selector = selector;
      }

      public override Enumerable.Iterator<TResult> Clone() => (Enumerable.Iterator<TResult>) new Enumerable.SelectIPartitionIterator<TSource, TResult>(this._source, this._selector);

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._enumerator = this._source.GetEnumerator();
            this._state = 2;
            goto case 2;
          case 2:
            if (this._enumerator.MoveNext())
            {
              this._current = this._selector(this._enumerator.Current);
              return true;
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override void Dispose()
      {
        if (this._enumerator != null)
        {
          this._enumerator.Dispose();
          this._enumerator = (IEnumerator<TSource>) null;
        }
        base.Dispose();
      }

      public override IEnumerable<TResult2> Select<TResult2>(
        Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.SelectIPartitionIterator<TSource, TResult2>(this._source, Utilities.CombineSelectors<TSource, TResult, TResult2>(this._selector, selector));
      }

      public IPartition<TResult> Skip(int count) => (IPartition<TResult>) new Enumerable.SelectIPartitionIterator<TSource, TResult>(this._source.Skip(count), this._selector);

      public IPartition<TResult> Take(int count) => (IPartition<TResult>) new Enumerable.SelectIPartitionIterator<TSource, TResult>(this._source.Take(count), this._selector);

      public TResult TryGetElementAt(int index, out bool found)
      {
        bool found1;
        TSource elementAt = this._source.TryGetElementAt(index, out found1);
        found = found1;
        return !found1 ? default (TResult) : this._selector(elementAt);
      }

      public TResult TryGetFirst(out bool found)
      {
        bool found1;
        TSource first = this._source.TryGetFirst(out found1);
        found = found1;
        return !found1 ? default (TResult) : this._selector(first);
      }

      public TResult TryGetLast(out bool found)
      {
        bool found1;
        TSource last = this._source.TryGetLast(out found1);
        found = found1;
        return !found1 ? default (TResult) : this._selector(last);
      }

      private TResult[] LazyToArray()
      {
        LargeArrayBuilder<TResult> largeArrayBuilder = new LargeArrayBuilder<TResult>(true);
        foreach (TSource source in (IEnumerable<TSource>) this._source)
          largeArrayBuilder.Add(this._selector(source));
        return largeArrayBuilder.ToArray();
      }

      private TResult[] PreallocatingToArray(int count)
      {
        TResult[] resultArray = new TResult[count];
        int index = 0;
        foreach (TSource source in (IEnumerable<TSource>) this._source)
        {
          resultArray[index] = this._selector(source);
          ++index;
        }
        return resultArray;
      }

      public TResult[] ToArray()
      {
        int count = this._source.GetCount(true);
        TResult[] resultArray;
        switch (count)
        {
          case -1:
            resultArray = this.LazyToArray();
            break;
          case 0:
            resultArray = Array.Empty<TResult>();
            break;
          default:
            resultArray = this.PreallocatingToArray(count);
            break;
        }
        return resultArray;
      }

      public List<TResult> ToList()
      {
        int count = this._source.GetCount(true);
        List<TResult> resultList;
        switch (count)
        {
          case -1:
            resultList = new List<TResult>();
            break;
          case 0:
            return new List<TResult>();
          default:
            resultList = new List<TResult>(count);
            break;
        }
        foreach (TSource source in (IEnumerable<TSource>) this._source)
          resultList.Add(this._selector(source));
        return resultList;
      }

      public int GetCount(bool onlyIfCheap)
      {
        if (onlyIfCheap)
          return this._source.GetCount(onlyIfCheap);
        int num = 0;
        foreach (TSource source in (IEnumerable<TSource>) this._source)
        {
          TResult result = this._selector(source);
          checked { ++num; }
        }
        return num;
      }
    }

    [DebuggerDisplay("Count = {Count}")]
    private sealed class SelectListPartitionIterator<TSource, TResult> : 
      Enumerable.Iterator<TResult>,
      IPartition<TResult>,
      IIListProvider<TResult>,
      IEnumerable<TResult>,
      IEnumerable
    {
      private readonly IList<TSource> _source;
      private readonly Func<TSource, TResult> _selector;
      private readonly int _minIndexInclusive;
      private readonly int _maxIndexInclusive;

      public SelectListPartitionIterator(
        IList<TSource> source,
        Func<TSource, TResult> selector,
        int minIndexInclusive,
        int maxIndexInclusive)
      {
        this._source = source;
        this._selector = selector;
        this._minIndexInclusive = minIndexInclusive;
        this._maxIndexInclusive = maxIndexInclusive;
      }

      public override Enumerable.Iterator<TResult> Clone() => (Enumerable.Iterator<TResult>) new Enumerable.SelectListPartitionIterator<TSource, TResult>(this._source, this._selector, this._minIndexInclusive, this._maxIndexInclusive);

      public override bool MoveNext()
      {
        int num = this._state - 1;
        if ((uint) num <= (uint) (this._maxIndexInclusive - this._minIndexInclusive) && num < this._source.Count - this._minIndexInclusive)
        {
          this._current = this._selector(this._source[this._minIndexInclusive + num]);
          ++this._state;
          return true;
        }
        this.Dispose();
        return false;
      }

      public override IEnumerable<TResult2> Select<TResult2>(
        Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.SelectListPartitionIterator<TSource, TResult2>(this._source, Utilities.CombineSelectors<TSource, TResult, TResult2>(this._selector, selector), this._minIndexInclusive, this._maxIndexInclusive);
      }

      public IPartition<TResult> Skip(int count)
      {
        int minIndexInclusive = this._minIndexInclusive + count;
        return (uint) minIndexInclusive <= (uint) this._maxIndexInclusive ? (IPartition<TResult>) new Enumerable.SelectListPartitionIterator<TSource, TResult>(this._source, this._selector, minIndexInclusive, this._maxIndexInclusive) : EmptyPartition<TResult>.Instance;
      }

      public IPartition<TResult> Take(int count)
      {
        int maxIndexInclusive = this._minIndexInclusive + count - 1;
        return (uint) maxIndexInclusive < (uint) this._maxIndexInclusive ? (IPartition<TResult>) new Enumerable.SelectListPartitionIterator<TSource, TResult>(this._source, this._selector, this._minIndexInclusive, maxIndexInclusive) : (IPartition<TResult>) this;
      }

      public TResult TryGetElementAt(int index, out bool found)
      {
        if ((uint) index <= (uint) (this._maxIndexInclusive - this._minIndexInclusive) && index < this._source.Count - this._minIndexInclusive)
        {
          found = true;
          return this._selector(this._source[this._minIndexInclusive + index]);
        }
        found = false;
        return default (TResult);
      }

      public TResult TryGetFirst(out bool found)
      {
        if (this._source.Count > this._minIndexInclusive)
        {
          found = true;
          return this._selector(this._source[this._minIndexInclusive]);
        }
        found = false;
        return default (TResult);
      }

      public TResult TryGetLast(out bool found)
      {
        int val1 = this._source.Count - 1;
        if (val1 >= this._minIndexInclusive)
        {
          found = true;
          return this._selector(this._source[Math.Min(val1, this._maxIndexInclusive)]);
        }
        found = false;
        return default (TResult);
      }

      private int Count
      {
        get
        {
          int count = this._source.Count;
          return count <= this._minIndexInclusive ? 0 : Math.Min(count - 1, this._maxIndexInclusive) - this._minIndexInclusive + 1;
        }
      }

      public TResult[] ToArray()
      {
        int count = this.Count;
        if (count == 0)
          return Array.Empty<TResult>();
        TResult[] resultArray = new TResult[count];
        int index = 0;
        int minIndexInclusive = this._minIndexInclusive;
        while (index != resultArray.Length)
        {
          resultArray[index] = this._selector(this._source[minIndexInclusive]);
          ++index;
          ++minIndexInclusive;
        }
        return resultArray;
      }

      public List<TResult> ToList()
      {
        int count = this.Count;
        if (count == 0)
          return new List<TResult>();
        List<TResult> resultList = new List<TResult>(count);
        int num = this._minIndexInclusive + count;
        for (int minIndexInclusive = this._minIndexInclusive; minIndexInclusive != num; ++minIndexInclusive)
          resultList.Add(this._selector(this._source[minIndexInclusive]));
        return resultList;
      }

      public int GetCount(bool onlyIfCheap)
      {
        int count = this.Count;
        if (!onlyIfCheap)
        {
          int num = this._minIndexInclusive + count;
          for (int minIndexInclusive = this._minIndexInclusive; minIndexInclusive != num; ++minIndexInclusive)
          {
            TResult result = this._selector(this._source[minIndexInclusive]);
          }
        }
        return count;
      }
    }

    private sealed class SelectManySingleSelectorIterator<TSource, TResult> : 
      Enumerable.Iterator<TResult>,
      IIListProvider<TResult>,
      IEnumerable<TResult>,
      IEnumerable
    {
      private readonly IEnumerable<TSource> _source;
      private readonly Func<TSource, IEnumerable<TResult>> _selector;
      private IEnumerator<TSource> _sourceEnumerator;
      private IEnumerator<TResult> _subEnumerator;

      public int GetCount(bool onlyIfCheap)
      {
        if (onlyIfCheap)
          return -1;
        int num = 0;
        foreach (TSource source in this._source)
          checked { num += this._selector(source).Count<TResult>(); }
        return num;
      }

      public TResult[] ToArray()
      {
        SparseArrayBuilder<TResult> sparseArrayBuilder = new SparseArrayBuilder<TResult>(true);
        ArrayBuilder<IEnumerable<TResult>> arrayBuilder = new ArrayBuilder<IEnumerable<TResult>>();
        foreach (TSource source in this._source)
        {
          IEnumerable<TResult> items = this._selector(source);
          if (sparseArrayBuilder.ReserveOrAdd(items))
            arrayBuilder.Add(items);
        }
        TResult[] array = sparseArrayBuilder.ToArray();
        ArrayBuilder<Marker> markers = sparseArrayBuilder.Markers;
        for (int index = 0; index < markers.Count; ++index)
        {
          Marker marker = markers[index];
          EnumerableHelpers.Copy<TResult>(arrayBuilder[index], array, marker.Index, marker.Count);
        }
        return array;
      }

      public List<TResult> ToList()
      {
        List<TResult> resultList = new List<TResult>();
        foreach (TSource source in this._source)
          resultList.AddRange(this._selector(source));
        return resultList;
      }

      internal SelectManySingleSelectorIterator(
        IEnumerable<TSource> source,
        Func<TSource, IEnumerable<TResult>> selector)
      {
        this._source = source;
        this._selector = selector;
      }

      public override Enumerable.Iterator<TResult> Clone() => (Enumerable.Iterator<TResult>) new Enumerable.SelectManySingleSelectorIterator<TSource, TResult>(this._source, this._selector);

      public override void Dispose()
      {
        if (this._subEnumerator != null)
        {
          this._subEnumerator.Dispose();
          this._subEnumerator = (IEnumerator<TResult>) null;
        }
        if (this._sourceEnumerator != null)
        {
          this._sourceEnumerator.Dispose();
          this._sourceEnumerator = (IEnumerator<TSource>) null;
        }
        base.Dispose();
      }

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._sourceEnumerator = this._source.GetEnumerator();
            this._state = 2;
            goto case 2;
          case 2:
            if (this._sourceEnumerator.MoveNext())
            {
              this._subEnumerator = this._selector(this._sourceEnumerator.Current).GetEnumerator();
              this._state = 3;
              goto case 3;
            }
            else
              break;
          case 3:
            if (!this._subEnumerator.MoveNext())
            {
              this._subEnumerator.Dispose();
              this._subEnumerator = (IEnumerator<TResult>) null;
              this._state = 2;
              goto case 2;
            }
            else
            {
              this._current = this._subEnumerator.Current;
              return true;
            }
        }
        this.Dispose();
        return false;
      }
    }

    private abstract class UnionIterator<TSource> : 
      Enumerable.Iterator<TSource>,
      IIListProvider<TSource>,
      IEnumerable<TSource>,
      IEnumerable
    {
      internal readonly IEqualityComparer<TSource> _comparer;
      private IEnumerator<TSource> _enumerator;
      private Set<TSource> _set;

      private Set<TSource> FillSet()
      {
        Set<TSource> set = new Set<TSource>(this._comparer);
        int index = 0;
        while (true)
        {
          IEnumerable<TSource> enumerable = this.GetEnumerable(index);
          if (enumerable != null)
          {
            set.UnionWith(enumerable);
            ++index;
          }
          else
            break;
        }
        return set;
      }

      public TSource[] ToArray() => this.FillSet().ToArray();

      public List<TSource> ToList() => this.FillSet().ToList();

      public int GetCount(bool onlyIfCheap) => !onlyIfCheap ? this.FillSet().Count : -1;

      protected UnionIterator(IEqualityComparer<TSource> comparer) => this._comparer = comparer;

      public override sealed void Dispose()
      {
        if (this._enumerator != null)
        {
          this._enumerator.Dispose();
          this._enumerator = (IEnumerator<TSource>) null;
          this._set = (Set<TSource>) null;
        }
        base.Dispose();
      }

      internal abstract IEnumerable<TSource> GetEnumerable(int index);

      internal abstract Enumerable.UnionIterator<TSource> Union(IEnumerable<TSource> next);

      private void SetEnumerator(IEnumerator<TSource> enumerator)
      {
        this._enumerator?.Dispose();
        this._enumerator = enumerator;
      }

      private void StoreFirst()
      {
        Set<TSource> set = new Set<TSource>(this._comparer);
        TSource current = this._enumerator.Current;
        set.Add(current);
        this._current = current;
        this._set = set;
      }

      private bool GetNext()
      {
        Set<TSource> set = this._set;
        while (this._enumerator.MoveNext())
        {
          TSource current = this._enumerator.Current;
          if (set.Add(current))
          {
            this._current = current;
            return true;
          }
        }
        return false;
      }

      public override sealed bool MoveNext()
      {
        if (this._state == 1)
        {
          for (IEnumerable<TSource> enumerable = this.GetEnumerable(0); enumerable != null; enumerable = this.GetEnumerable(this._state - 1))
          {
            IEnumerator<TSource> enumerator = enumerable.GetEnumerator();
            this.SetEnumerator(enumerator);
            ++this._state;
            if (enumerator.MoveNext())
            {
              this.StoreFirst();
              return true;
            }
          }
        }
        else if (this._state > 0)
        {
          while (!this.GetNext())
          {
            IEnumerable<TSource> enumerable = this.GetEnumerable(this._state - 1);
            if (enumerable != null)
            {
              this.SetEnumerator(enumerable.GetEnumerator());
              ++this._state;
            }
            else
              goto label_11;
          }
          return true;
        }
label_11:
        this.Dispose();
        return false;
      }
    }

    private sealed class WhereEnumerableIterator<TSource> : 
      Enumerable.Iterator<TSource>,
      IIListProvider<TSource>,
      IEnumerable<TSource>,
      IEnumerable
    {
      private readonly IEnumerable<TSource> _source;
      private readonly Func<TSource, bool> _predicate;
      private IEnumerator<TSource> _enumerator;

      public int GetCount(bool onlyIfCheap)
      {
        if (onlyIfCheap)
          return -1;
        int num = 0;
        foreach (TSource source in this._source)
        {
          if (this._predicate(source))
            checked { ++num; }
        }
        return num;
      }

      public TSource[] ToArray()
      {
        LargeArrayBuilder<TSource> largeArrayBuilder = new LargeArrayBuilder<TSource>(true);
        foreach (TSource source in this._source)
        {
          if (this._predicate(source))
            largeArrayBuilder.Add(source);
        }
        return largeArrayBuilder.ToArray();
      }

      public List<TSource> ToList()
      {
        List<TSource> sourceList = new List<TSource>();
        foreach (TSource source in this._source)
        {
          if (this._predicate(source))
            sourceList.Add(source);
        }
        return sourceList;
      }

      public WhereEnumerableIterator(IEnumerable<TSource> source, Func<TSource, bool> predicate)
      {
        this._source = source;
        this._predicate = predicate;
      }

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.WhereEnumerableIterator<TSource>(this._source, this._predicate);

      public override void Dispose()
      {
        if (this._enumerator != null)
        {
          this._enumerator.Dispose();
          this._enumerator = (IEnumerator<TSource>) null;
        }
        base.Dispose();
      }

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._enumerator = this._source.GetEnumerator();
            this._state = 2;
            goto case 2;
          case 2:
            while (this._enumerator.MoveNext())
            {
              TSource current = this._enumerator.Current;
              if (this._predicate(current))
              {
                this._current = current;
                return true;
              }
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override IEnumerable<TResult> Select<TResult>(
        Func<TSource, TResult> selector)
      {
        return (IEnumerable<TResult>) new Enumerable.WhereSelectEnumerableIterator<TSource, TResult>(this._source, this._predicate, selector);
      }

      public override IEnumerable<TSource> Where(Func<TSource, bool> predicate) => (IEnumerable<TSource>) new Enumerable.WhereEnumerableIterator<TSource>(this._source, Utilities.CombinePredicates<TSource>(this._predicate, predicate));
    }

    internal sealed class WhereArrayIterator<TSource> : 
      Enumerable.Iterator<TSource>,
      IIListProvider<TSource>,
      IEnumerable<TSource>,
      IEnumerable
    {
      private readonly TSource[] _source;
      private readonly Func<TSource, bool> _predicate;

      public int GetCount(bool onlyIfCheap)
      {
        if (onlyIfCheap)
          return -1;
        int num = 0;
        foreach (TSource source in this._source)
        {
          if (this._predicate(source))
            checked { ++num; }
        }
        return num;
      }

      public TSource[] ToArray()
      {
        LargeArrayBuilder<TSource> largeArrayBuilder = new LargeArrayBuilder<TSource>(this._source.Length);
        foreach (TSource source in this._source)
        {
          if (this._predicate(source))
            largeArrayBuilder.Add(source);
        }
        return largeArrayBuilder.ToArray();
      }

      public List<TSource> ToList()
      {
        List<TSource> sourceList = new List<TSource>();
        foreach (TSource source in this._source)
        {
          if (this._predicate(source))
            sourceList.Add(source);
        }
        return sourceList;
      }

      public WhereArrayIterator(TSource[] source, Func<TSource, bool> predicate)
      {
        this._source = source;
        this._predicate = predicate;
      }

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.WhereArrayIterator<TSource>(this._source, this._predicate);

      public override bool MoveNext()
      {
        int index = this._state - 1;
        TSource[] source1 = this._source;
        while ((uint) index < (uint) source1.Length)
        {
          TSource source2 = source1[index];
          index = this._state++;
          if (this._predicate(source2))
          {
            this._current = source2;
            return true;
          }
        }
        this.Dispose();
        return false;
      }

      public override IEnumerable<TResult> Select<TResult>(
        Func<TSource, TResult> selector)
      {
        return (IEnumerable<TResult>) new Enumerable.WhereSelectArrayIterator<TSource, TResult>(this._source, this._predicate, selector);
      }

      public override IEnumerable<TSource> Where(Func<TSource, bool> predicate) => (IEnumerable<TSource>) new Enumerable.WhereArrayIterator<TSource>(this._source, Utilities.CombinePredicates<TSource>(this._predicate, predicate));
    }

    private sealed class WhereListIterator<TSource> : 
      Enumerable.Iterator<TSource>,
      IIListProvider<TSource>,
      IEnumerable<TSource>,
      IEnumerable
    {
      private readonly List<TSource> _source;
      private readonly Func<TSource, bool> _predicate;
      private List<TSource>.Enumerator _enumerator;

      public int GetCount(bool onlyIfCheap)
      {
        if (onlyIfCheap)
          return -1;
        int num = 0;
        for (int index = 0; index < this._source.Count; ++index)
        {
          if (this._predicate(this._source[index]))
            checked { ++num; }
        }
        return num;
      }

      public TSource[] ToArray()
      {
        LargeArrayBuilder<TSource> largeArrayBuilder = new LargeArrayBuilder<TSource>(this._source.Count);
        for (int index = 0; index < this._source.Count; ++index)
        {
          TSource source = this._source[index];
          if (this._predicate(source))
            largeArrayBuilder.Add(source);
        }
        return largeArrayBuilder.ToArray();
      }

      public List<TSource> ToList()
      {
        List<TSource> sourceList = new List<TSource>();
        for (int index = 0; index < this._source.Count; ++index)
        {
          TSource source = this._source[index];
          if (this._predicate(source))
            sourceList.Add(source);
        }
        return sourceList;
      }

      public WhereListIterator(List<TSource> source, Func<TSource, bool> predicate)
      {
        this._source = source;
        this._predicate = predicate;
      }

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.WhereListIterator<TSource>(this._source, this._predicate);

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._enumerator = this._source.GetEnumerator();
            this._state = 2;
            goto case 2;
          case 2:
            while (this._enumerator.MoveNext())
            {
              TSource current = this._enumerator.Current;
              if (this._predicate(current))
              {
                this._current = current;
                return true;
              }
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override IEnumerable<TResult> Select<TResult>(
        Func<TSource, TResult> selector)
      {
        return (IEnumerable<TResult>) new Enumerable.WhereSelectListIterator<TSource, TResult>(this._source, this._predicate, selector);
      }

      public override IEnumerable<TSource> Where(Func<TSource, bool> predicate) => (IEnumerable<TSource>) new Enumerable.WhereListIterator<TSource>(this._source, Utilities.CombinePredicates<TSource>(this._predicate, predicate));
    }

    private sealed class WhereSelectArrayIterator<TSource, TResult> : 
      Enumerable.Iterator<TResult>,
      IIListProvider<TResult>,
      IEnumerable<TResult>,
      IEnumerable
    {
      private readonly TSource[] _source;
      private readonly Func<TSource, bool> _predicate;
      private readonly Func<TSource, TResult> _selector;

      public int GetCount(bool onlyIfCheap)
      {
        if (onlyIfCheap)
          return -1;
        int num = 0;
        foreach (TSource source in this._source)
        {
          if (this._predicate(source))
          {
            TResult result = this._selector(source);
            checked { ++num; }
          }
        }
        return num;
      }

      public TResult[] ToArray()
      {
        LargeArrayBuilder<TResult> largeArrayBuilder = new LargeArrayBuilder<TResult>(this._source.Length);
        foreach (TSource source in this._source)
        {
          if (this._predicate(source))
            largeArrayBuilder.Add(this._selector(source));
        }
        return largeArrayBuilder.ToArray();
      }

      public List<TResult> ToList()
      {
        List<TResult> resultList = new List<TResult>();
        foreach (TSource source in this._source)
        {
          if (this._predicate(source))
            resultList.Add(this._selector(source));
        }
        return resultList;
      }

      public WhereSelectArrayIterator(
        TSource[] source,
        Func<TSource, bool> predicate,
        Func<TSource, TResult> selector)
      {
        this._source = source;
        this._predicate = predicate;
        this._selector = selector;
      }

      public override Enumerable.Iterator<TResult> Clone() => (Enumerable.Iterator<TResult>) new Enumerable.WhereSelectArrayIterator<TSource, TResult>(this._source, this._predicate, this._selector);

      public override bool MoveNext()
      {
        int index = this._state - 1;
        TSource[] source1 = this._source;
        while ((uint) index < (uint) source1.Length)
        {
          TSource source2 = source1[index];
          index = this._state++;
          if (this._predicate(source2))
          {
            this._current = this._selector(source2);
            return true;
          }
        }
        this.Dispose();
        return false;
      }

      public override IEnumerable<TResult2> Select<TResult2>(
        Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.WhereSelectArrayIterator<TSource, TResult2>(this._source, this._predicate, Utilities.CombineSelectors<TSource, TResult, TResult2>(this._selector, selector));
      }
    }

    private sealed class WhereSelectListIterator<TSource, TResult> : 
      Enumerable.Iterator<TResult>,
      IIListProvider<TResult>,
      IEnumerable<TResult>,
      IEnumerable
    {
      private readonly List<TSource> _source;
      private readonly Func<TSource, bool> _predicate;
      private readonly Func<TSource, TResult> _selector;
      private List<TSource>.Enumerator _enumerator;

      public int GetCount(bool onlyIfCheap)
      {
        if (onlyIfCheap)
          return -1;
        int num = 0;
        for (int index = 0; index < this._source.Count; ++index)
        {
          TSource source = this._source[index];
          if (this._predicate(source))
          {
            TResult result = this._selector(source);
            checked { ++num; }
          }
        }
        return num;
      }

      public TResult[] ToArray()
      {
        LargeArrayBuilder<TResult> largeArrayBuilder = new LargeArrayBuilder<TResult>(this._source.Count);
        for (int index = 0; index < this._source.Count; ++index)
        {
          TSource source = this._source[index];
          if (this._predicate(source))
            largeArrayBuilder.Add(this._selector(source));
        }
        return largeArrayBuilder.ToArray();
      }

      public List<TResult> ToList()
      {
        List<TResult> resultList = new List<TResult>();
        for (int index = 0; index < this._source.Count; ++index)
        {
          TSource source = this._source[index];
          if (this._predicate(source))
            resultList.Add(this._selector(source));
        }
        return resultList;
      }

      public WhereSelectListIterator(
        List<TSource> source,
        Func<TSource, bool> predicate,
        Func<TSource, TResult> selector)
      {
        this._source = source;
        this._predicate = predicate;
        this._selector = selector;
      }

      public override Enumerable.Iterator<TResult> Clone() => (Enumerable.Iterator<TResult>) new Enumerable.WhereSelectListIterator<TSource, TResult>(this._source, this._predicate, this._selector);

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._enumerator = this._source.GetEnumerator();
            this._state = 2;
            goto case 2;
          case 2:
            while (this._enumerator.MoveNext())
            {
              TSource current = this._enumerator.Current;
              if (this._predicate(current))
              {
                this._current = this._selector(current);
                return true;
              }
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override IEnumerable<TResult2> Select<TResult2>(
        Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.WhereSelectListIterator<TSource, TResult2>(this._source, this._predicate, Utilities.CombineSelectors<TSource, TResult, TResult2>(this._selector, selector));
      }
    }

    private sealed class WhereSelectEnumerableIterator<TSource, TResult> : 
      Enumerable.Iterator<TResult>,
      IIListProvider<TResult>,
      IEnumerable<TResult>,
      IEnumerable
    {
      private readonly IEnumerable<TSource> _source;
      private readonly Func<TSource, bool> _predicate;
      private readonly Func<TSource, TResult> _selector;
      private IEnumerator<TSource> _enumerator;

      public int GetCount(bool onlyIfCheap)
      {
        if (onlyIfCheap)
          return -1;
        int num = 0;
        foreach (TSource source in this._source)
        {
          if (this._predicate(source))
          {
            TResult result = this._selector(source);
            checked { ++num; }
          }
        }
        return num;
      }

      public TResult[] ToArray()
      {
        LargeArrayBuilder<TResult> largeArrayBuilder = new LargeArrayBuilder<TResult>(true);
        foreach (TSource source in this._source)
        {
          if (this._predicate(source))
            largeArrayBuilder.Add(this._selector(source));
        }
        return largeArrayBuilder.ToArray();
      }

      public List<TResult> ToList()
      {
        List<TResult> resultList = new List<TResult>();
        foreach (TSource source in this._source)
        {
          if (this._predicate(source))
            resultList.Add(this._selector(source));
        }
        return resultList;
      }

      public WhereSelectEnumerableIterator(
        IEnumerable<TSource> source,
        Func<TSource, bool> predicate,
        Func<TSource, TResult> selector)
      {
        this._source = source;
        this._predicate = predicate;
        this._selector = selector;
      }

      public override Enumerable.Iterator<TResult> Clone() => (Enumerable.Iterator<TResult>) new Enumerable.WhereSelectEnumerableIterator<TSource, TResult>(this._source, this._predicate, this._selector);

      public override void Dispose()
      {
        if (this._enumerator != null)
        {
          this._enumerator.Dispose();
          this._enumerator = (IEnumerator<TSource>) null;
        }
        base.Dispose();
      }

      public override bool MoveNext()
      {
        switch (this._state)
        {
          case 1:
            this._enumerator = this._source.GetEnumerator();
            this._state = 2;
            goto case 2;
          case 2:
            while (this._enumerator.MoveNext())
            {
              TSource current = this._enumerator.Current;
              if (this._predicate(current))
              {
                this._current = this._selector(current);
                return true;
              }
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override IEnumerable<TResult2> Select<TResult2>(
        Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.WhereSelectEnumerableIterator<TSource, TResult2>(this._source, this._predicate, Utilities.CombineSelectors<TSource, TResult, TResult2>(this._selector, selector));
      }
    }

    internal abstract class Iterator<TSource> : 
      IEnumerable<TSource>,
      IEnumerable,
      IEnumerator<TSource>,
      IEnumerator,
      IDisposable
    {
      private readonly int _threadId;
      internal int _state;
      internal TSource _current;

      protected Iterator() => this._threadId = Environment.CurrentManagedThreadId;

      public TSource Current => this._current;

      public abstract Enumerable.Iterator<TSource> Clone();

      public virtual void Dispose()
      {
        this._current = default (TSource);
        this._state = -1;
      }

      public IEnumerator<TSource> GetEnumerator()
      {
        Enumerable.Iterator<TSource> iterator = this._state != 0 || this._threadId != Environment.CurrentManagedThreadId ? this.Clone() : this;
        iterator._state = 1;
        return (IEnumerator<TSource>) iterator;
      }

      public abstract bool MoveNext();

      public virtual IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector) => (IEnumerable<TResult>) new Enumerable.SelectEnumerableIterator<TSource, TResult>((IEnumerable<TSource>) this, selector);

      public virtual IEnumerable<TSource> Where(Func<TSource, bool> predicate) => (IEnumerable<TSource>) new Enumerable.WhereEnumerableIterator<TSource>((IEnumerable<TSource>) this, predicate);

      object IEnumerator.Current => (object) this.Current;

      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

      void IEnumerator.Reset() => ThrowHelper.ThrowNotSupportedException();
    }

    private sealed class UnionIterator2<TSource> : Enumerable.UnionIterator<TSource>
    {
      private readonly IEnumerable<TSource> _first;
      private readonly IEnumerable<TSource> _second;

      public UnionIterator2(
        IEnumerable<TSource> first,
        IEnumerable<TSource> second,
        IEqualityComparer<TSource> comparer)
        : base(comparer)
      {
        this._first = first;
        this._second = second;
      }

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.UnionIterator2<TSource>(this._first, this._second, this._comparer);

      internal override IEnumerable<TSource> GetEnumerable(int index)
      {
        IEnumerable<TSource> sources;
        switch (index)
        {
          case 0:
            sources = this._first;
            break;
          case 1:
            sources = this._second;
            break;
          default:
            sources = (IEnumerable<TSource>) null;
            break;
        }
        return sources;
      }

      internal override Enumerable.UnionIterator<TSource> Union(IEnumerable<TSource> next) => (Enumerable.UnionIterator<TSource>) new Enumerable.UnionIteratorN<TSource>(new SingleLinkedNode<IEnumerable<TSource>>(this._first).Add(this._second).Add(next), 2, this._comparer);
    }

    private sealed class UnionIteratorN<TSource> : Enumerable.UnionIterator<TSource>
    {
      private readonly SingleLinkedNode<IEnumerable<TSource>> _sources;
      private readonly int _headIndex;

      public UnionIteratorN(
        SingleLinkedNode<IEnumerable<TSource>> sources,
        int headIndex,
        IEqualityComparer<TSource> comparer)
        : base(comparer)
      {
        this._sources = sources;
        this._headIndex = headIndex;
      }

      public override Enumerable.Iterator<TSource> Clone() => (Enumerable.Iterator<TSource>) new Enumerable.UnionIteratorN<TSource>(this._sources, this._headIndex, this._comparer);

      internal override IEnumerable<TSource> GetEnumerable(int index) => index <= this._headIndex ? this._sources.GetNode(this._headIndex - index).Item : (IEnumerable<TSource>) null;

      internal override Enumerable.UnionIterator<TSource> Union(IEnumerable<TSource> next) => this._headIndex == 2147483645 ? (Enumerable.UnionIterator<TSource>) new Enumerable.UnionIterator2<TSource>((IEnumerable<TSource>) this, next, this._comparer) : (Enumerable.UnionIterator<TSource>) new Enumerable.UnionIteratorN<TSource>(this._sources.Add(next), this._headIndex + 1, this._comparer);
    }
  }
}
