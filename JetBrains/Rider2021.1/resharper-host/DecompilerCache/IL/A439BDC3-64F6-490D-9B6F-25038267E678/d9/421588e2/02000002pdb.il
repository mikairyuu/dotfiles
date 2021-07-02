// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A439BDC3-64F6-490D-9B6F-25038267E678
// Location: /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.dll
// Sequence point data from /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.pdb

.class private auto ansi beforefieldinit
  ConsoleApp1.Program
    extends [System.Runtime]System.Object
{

  .class nested private sealed auto ansi serializable beforefieldinit
    '<>c'
      extends [System.Runtime]System.Object
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )

    .field public static initonly class ConsoleApp1.Program/'<>c' '<>9'

    .field public static class [System.Runtime]System.Func`3<char, bool, bool> '<>9__0_0'

    .field public static class [System.Runtime]System.Func`2<bool, bool> '<>9__0_1'

    .method private hidebysig static specialname rtspecialname void
      .cctor() cil managed
    {
      .maxstack 8

      IL_0000: newobj       instance void ConsoleApp1.Program/'<>c'::.ctor()
      IL_0005: stsfld       class ConsoleApp1.Program/'<>c' ConsoleApp1.Program/'<>c'::'<>9'
      IL_000a: ret

    } // end of method '<>c'::.cctor

    .method public hidebysig specialname rtspecialname instance void
      .ctor() cil managed
    {
      .maxstack 8

      IL_0000: ldarg.0      // this
      IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
      IL_0006: nop
      IL_0007: ret

    } // end of method '<>c'::.ctor

    .method assembly hidebysig instance bool
      '<compare>b__0_0'(
        char x,
        bool y
      ) cil managed
    {
      .maxstack 8

      // [11 50 - 11 69]
      IL_0000: ldarg.1      // x
      IL_0001: ldc.i4.s     43 // 0x2b
      IL_0003: beq.s        IL_000b
      IL_0005: ldarg.2      // y
      IL_0006: ldc.i4.0
      IL_0007: ceq
      IL_0009: br.s         IL_000c
      IL_000b: ldarg.2      // y
      IL_000c: ret

    } // end of method '<>c'::'<compare>b__0_0'

    .method assembly hidebysig instance bool
      '<compare>b__0_1'(
        bool x
      ) cil managed
    {
      .maxstack 8

      // [11 82 - 11 84]
      IL_0000: ldarg.1      // x
      IL_0001: ldc.i4.0
      IL_0002: ceq
      IL_0004: ret

    } // end of method '<>c'::'<compare>b__0_1'
  } // end of class '<>c'

  .class nested private sealed auto ansi beforefieldinit
    '<>c__DisplayClass1_0'
      extends [System.Runtime]System.Object
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )

    .field public bool[] test

    .field public class [System.Runtime]System.Func`2<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>, bool> '<>9__0'

    .method public hidebysig specialname rtspecialname instance void
      .ctor() cil managed
    {
      .maxstack 8

      IL_0000: ldarg.0      // this
      IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
      IL_0006: nop
      IL_0007: ret

    } // end of method '<>c__DisplayClass1_0'::.ctor

    .method assembly hidebysig instance bool
      '<Main>b__0'(
        valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32> entry
      ) cil managed
    {
      .maxstack 8

      // [39 59 - 39 79]
      IL_0000: ldarg.1      // entry
      IL_0001: ldarg.0      // this
      IL_0002: ldfld        bool[] ConsoleApp1.Program/'<>c__DisplayClass1_0'::test
      IL_0007: call         bool ConsoleApp1.Program::compare(valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>, class [System.Runtime]System.Collections.Generic.IEnumerable`1<bool>)
      IL_000c: ret

    } // end of method '<>c__DisplayClass1_0'::'<Main>b__0'
  } // end of class '<>c__DisplayClass1_0'

  .method private hidebysig static bool
    compare(
      valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32> entry,
      class [System.Runtime]System.Collections.Generic.IEnumerable`1<bool> test
    ) cil managed
  {
    .maxstack 4
    .locals init (
      [0] bool V_0
    )

    // [10 9 - 10 10]
    IL_0000: nop

    // [11 13 - 11 101]
    IL_0001: ldarga.s     entry
    IL_0003: call         instance !0/*string*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>::get_Key()
    IL_0008: ldarg.1      // test
    IL_0009: ldsfld       class [System.Runtime]System.Func`3<char, bool, bool> ConsoleApp1.Program/'<>c'::'<>9__0_0'
    IL_000e: dup
    IL_000f: brtrue.s     IL_0028
    IL_0011: pop
    IL_0012: ldsfld       class ConsoleApp1.Program/'<>c' ConsoleApp1.Program/'<>c'::'<>9'
    IL_0017: ldftn        instance bool ConsoleApp1.Program/'<>c'::'<compare>b__0_0'(char, bool)
    IL_001d: newobj       instance void class [System.Runtime]System.Func`3<char, bool, bool>::.ctor(object, native int)
    IL_0022: dup
    IL_0023: stsfld       class [System.Runtime]System.Func`3<char, bool, bool> ConsoleApp1.Program/'<>c'::'<>9__0_0'
    IL_0028: call         class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!2/*bool*/> [System.Linq]System.Linq.Enumerable::Zip<char, bool, bool>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0/*char*/>, class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!1/*bool*/>, class [System.Runtime]System.Func`3<!!0/*char*/, !!1/*bool*/, !!2/*bool*/>)
    IL_002d: ldsfld       class [System.Runtime]System.Func`2<bool, bool> ConsoleApp1.Program/'<>c'::'<>9__0_1'
    IL_0032: dup
    IL_0033: brtrue.s     IL_004c
    IL_0035: pop
    IL_0036: ldsfld       class ConsoleApp1.Program/'<>c' ConsoleApp1.Program/'<>c'::'<>9'
    IL_003b: ldftn        instance bool ConsoleApp1.Program/'<>c'::'<compare>b__0_1'(bool)
    IL_0041: newobj       instance void class [System.Runtime]System.Func`2<bool, bool>::.ctor(object, native int)
    IL_0046: dup
    IL_0047: stsfld       class [System.Runtime]System.Func`2<bool, bool> ConsoleApp1.Program/'<>c'::'<>9__0_1'
    IL_004c: call         int32 [System.Linq]System.Linq.Enumerable::Count<bool>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0/*bool*/>, class [System.Runtime]System.Func`2<!!0/*bool*/, bool>)
    IL_0051: ldarga.s     entry
    IL_0053: call         instance !1/*int32*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>::get_Value()
    IL_0058: ceq
    IL_005a: stloc.0      // V_0
    IL_005b: br.s         IL_005d

    // [12 9 - 12 10]
    IL_005d: ldloc.0      // V_0
    IL_005e: ret

  } // end of method Program::compare

  .method private hidebysig static void
    Main(
      string[] args
    ) cil managed
  {
    .entrypoint
    .maxstack 4
    .locals init (
      [0] class ConsoleApp1.Program/'<>c__DisplayClass1_0' 'CS$<>8__locals0',
      [1] class [System.Runtime]System.IO.StreamReader sr,
      [2] class [System.Runtime]System.IO.StreamWriter sw,
      [3] string[] buf,
      [4] int32 p,
      [5] int32 q,
      [6] class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>> list,
      [7] int32 i,
      [8] bool V_8,
      [9] int32 j,
      [10] bool V_10,
      [11] bool V_11,
      [12] class [System.Runtime]System.Collections.Generic.IEnumerator`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>> V_12,
      [13] class [System.Runtime]System.Func`2<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>, bool> V_13,
      [14] valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32> entry,
      [15] bool V_15,
      [16] bool[] V_16,
      [17] int32 V_17,
      [18] bool a
    )

    IL_0000: newobj       instance void ConsoleApp1.Program/'<>c__DisplayClass1_0'::.ctor()
    IL_0005: stloc.0      // 'CS$<>8__locals0'

    // [15 9 - 15 10]
    IL_0006: nop

    // [16 13 - 16 52]
    IL_0007: ldstr        "input.txt"
    IL_000c: newobj       instance void [System.Runtime]System.IO.StreamReader::.ctor(string)
    IL_0011: stloc.1      // sr

    // [17 13 - 17 53]
    IL_0012: ldstr        "output.txt"
    IL_0017: newobj       instance void [System.Runtime]System.IO.StreamWriter::.ctor(string)
    IL_001c: stloc.2      // sw

    // [18 13 - 18 48]
    IL_001d: ldloc.1      // sr
    IL_001e: callvirt     instance string [System.Runtime]System.IO.TextReader::ReadLine()
    IL_0023: ldc.i4.s     32 // 0x20
    IL_0025: ldc.i4.0
    IL_0026: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_002b: stloc.3      // buf

    // [19 13 - 19 38]
    IL_002c: ldloc.3      // buf
    IL_002d: ldc.i4.0
    IL_002e: ldelem.ref
    IL_002f: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0034: stloc.s      p

    // [19 40 - 19 61]
    IL_0036: ldloc.3      // buf
    IL_0037: ldc.i4.1
    IL_0038: ldelem.ref
    IL_0039: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_003e: stloc.s      q

    // [20 13 - 20 62]
    IL_0040: newobj       instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>>::.ctor()
    IL_0045: stloc.s      list

    // [21 18 - 21 27]
    IL_0047: ldc.i4.0
    IL_0048: stloc.s      i

    IL_004a: br.s         IL_0070
    // start of loop, entry point: IL_0070

      // [22 17 - 22 98]
      IL_004c: ldloc.s      list
      IL_004e: ldloc.1      // sr
      IL_004f: callvirt     instance string [System.Runtime]System.IO.TextReader::ReadLine()
      IL_0054: ldloc.1      // sr
      IL_0055: callvirt     instance string [System.Runtime]System.IO.TextReader::ReadLine()
      IL_005a: call         int32 [System.Runtime]System.Int32::Parse(string)
      IL_005f: newobj       instance void valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>::.ctor(!0/*string*/, !1/*int32*/)
      IL_0064: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>>::Add(!0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>*/)
      IL_0069: nop

      // [21 36 - 21 39]
      IL_006a: ldloc.s      i
      IL_006c: ldc.i4.1
      IL_006d: add
      IL_006e: stloc.s      i

      // [21 29 - 21 34]
      IL_0070: ldloc.s      i
      IL_0072: ldloc.s      p
      IL_0074: clt
      IL_0076: stloc.s      V_8

      IL_0078: ldloc.s      V_8
      IL_007a: brtrue.s     IL_004c
    // end of loop

    // [23 13 - 23 36]
    IL_007c: ldloc.0      // 'CS$<>8__locals0'
    IL_007d: ldloc.s      q
    IL_007f: newarr       [System.Runtime]System.Boolean
    IL_0084: stfld        bool[] ConsoleApp1.Program/'<>c__DisplayClass1_0'::test

    IL_0089: br           IL_012e
    // start of loop, entry point: IL_012e

      // [25 13 - 25 14]
      IL_008e: nop

      // [26 22 - 26 35]
      IL_008f: ldloc.s      q
      IL_0091: ldc.i4.1
      IL_0092: sub
      IL_0093: stloc.s      j

      IL_0095: br.s         IL_00c9
      // start of loop, entry point: IL_00c9

        // [27 17 - 27 18]
        IL_0097: nop

        // [28 21 - 28 33]
        IL_0098: ldloc.0      // 'CS$<>8__locals0'
        IL_0099: ldfld        bool[] ConsoleApp1.Program/'<>c__DisplayClass1_0'::test
        IL_009e: ldloc.s      j
        IL_00a0: ldelem.u1
        IL_00a1: stloc.s      V_10

        IL_00a3: ldloc.s      V_10
        IL_00a5: brfalse.s    IL_00b5

        // [29 21 - 29 22]
        IL_00a7: nop

        // [30 25 - 30 41]
        IL_00a8: ldloc.0      // 'CS$<>8__locals0'
        IL_00a9: ldfld        bool[] ConsoleApp1.Program/'<>c__DisplayClass1_0'::test
        IL_00ae: ldloc.s      j
        IL_00b0: ldc.i4.0
        IL_00b1: stelem.i1

        // [31 21 - 31 22]
        IL_00b2: nop

        IL_00b3: br.s         IL_00c2

        // [33 21 - 33 22]
        IL_00b5: nop

        // [34 25 - 34 40]
        IL_00b6: ldloc.0      // 'CS$<>8__locals0'
        IL_00b7: ldfld        bool[] ConsoleApp1.Program/'<>c__DisplayClass1_0'::test
        IL_00bc: ldloc.s      j
        IL_00be: ldc.i4.1
        IL_00bf: stelem.i1

        // [35 25 - 35 31]
        IL_00c0: br.s         IL_00d7

        // [37 17 - 37 18]
        IL_00c2: nop

        // [26 45 - 26 48]
        IL_00c3: ldloc.s      q
        IL_00c5: ldc.i4.1
        IL_00c6: sub
        IL_00c7: stloc.s      q

        // [26 37 - 26 43]
        IL_00c9: ldloc.s      q
        IL_00cb: ldc.i4.0
        IL_00cc: clt
        IL_00ce: ldc.i4.0
        IL_00cf: ceq
        IL_00d1: stloc.s      V_11

        IL_00d3: ldloc.s      V_11
        IL_00d5: brtrue.s     IL_0097
      // end of loop

      // [39 17 - 39 24]
      IL_00d7: nop

      // [39 39 - 39 80]
      IL_00d8: ldloc.s      list
      IL_00da: ldloc.0      // 'CS$<>8__locals0'
      IL_00db: ldfld        class [System.Runtime]System.Func`2<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>, bool> ConsoleApp1.Program/'<>c__DisplayClass1_0'::'<>9__0'
      IL_00e0: dup
      IL_00e1: brtrue.s     IL_00fb
      IL_00e3: pop
      IL_00e4: ldloc.0      // 'CS$<>8__locals0'
      IL_00e5: ldloc.0      // 'CS$<>8__locals0'
      IL_00e6: ldftn        instance bool ConsoleApp1.Program/'<>c__DisplayClass1_0'::'<Main>b__0'(valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>)
      IL_00ec: newobj       instance void class [System.Runtime]System.Func`2<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>, bool>::.ctor(object, native int)
      IL_00f1: dup
      IL_00f2: stloc.s      V_13
      IL_00f4: stfld        class [System.Runtime]System.Func`2<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>, bool> ConsoleApp1.Program/'<>c__DisplayClass1_0'::'<>9__0'
      IL_00f9: ldloc.s      V_13
      IL_00fb: call         class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>*/> [System.Linq]System.Linq.Enumerable::Where<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>*/>, class [System.Runtime]System.Func`2<!!0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>*/, bool>)
      IL_0100: callvirt     instance class [System.Runtime]System.Collections.Generic.IEnumerator`1<!0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>*/> class [System.Runtime]System.Collections.Generic.IEnumerable`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>>::GetEnumerator()
      IL_0105: stloc.s      V_12
      .try
      {

        IL_0107: br.s         IL_0115
        // start of loop, entry point: IL_0115

          // [39 26 - 39 35]
          IL_0109: ldloc.s      V_12
          IL_010b: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>*/ class [System.Runtime]System.Collections.Generic.IEnumerator`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>>::get_Current()
          IL_0110: stloc.s      entry

          // [40 17 - 40 18]
          IL_0112: nop

          // [41 21 - 41 34]
          IL_0113: leave.s      IL_0136

          // [39 36 - 39 38]
          IL_0115: ldloc.s      V_12
          IL_0117: callvirt     instance bool [System.Runtime]System.Collections.IEnumerator::MoveNext()
          IL_011c: brtrue.s     IL_0109
        // end of loop
        IL_011e: leave.s      IL_012d
      } // end of .try
      finally
      {

        IL_0120: ldloc.s      V_12
        IL_0122: brfalse.s    IL_012c
        IL_0124: ldloc.s      V_12
        IL_0126: callvirt     instance void [System.Runtime]System.IDisposable::Dispose()
        IL_012b: nop

        IL_012c: endfinally
      } // end of finally

      // [43 13 - 43 14]
      IL_012d: nop

      // [24 13 - 24 25]
      IL_012e: ldc.i4.1
      IL_012f: stloc.s      V_15
      IL_0131: br           IL_008e
    // end of loop

    // [45 13 - 45 21]
    IL_0136: nop

    // [46 13 - 46 20]
    IL_0137: nop

    // [46 31 - 46 35]
    IL_0138: ldloc.0      // 'CS$<>8__locals0'
    IL_0139: ldfld        bool[] ConsoleApp1.Program/'<>c__DisplayClass1_0'::test
    IL_013e: stloc.s      V_16
    IL_0140: ldc.i4.0
    IL_0141: stloc.s      V_17

    IL_0143: br.s         IL_0163
    // start of loop, entry point: IL_0163

      // [46 22 - 46 27]
      IL_0145: ldloc.s      V_16
      IL_0147: ldloc.s      V_17
      IL_0149: ldelem.u1
      IL_014a: stloc.s      a

      // [47 17 - 47 41]
      IL_014c: ldloc.2      // sw
      IL_014d: ldloc.s      a
      IL_014f: brtrue.s     IL_0155
      IL_0151: ldc.i4.s     45 // 0x2d
      IL_0153: br.s         IL_0157
      IL_0155: ldc.i4.s     43 // 0x2b
      IL_0157: callvirt     instance void [System.Runtime]System.IO.TextWriter::Write(char)
      IL_015c: nop

      IL_015d: ldloc.s      V_17
      IL_015f: ldc.i4.1
      IL_0160: add
      IL_0161: stloc.s      V_17

      // [46 28 - 46 30]
      IL_0163: ldloc.s      V_17
      IL_0165: ldloc.s      V_16
      IL_0167: ldlen
      IL_0168: conv.i4
      IL_0169: blt.s        IL_0145
    // end of loop

    // [48 9 - 48 10]
    IL_016b: ret

  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    IL_0000: ldarg.0      // this
    IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
    IL_0006: nop
    IL_0007: ret

  } // end of method Program::.ctor
} // end of class ConsoleApp1.Program
