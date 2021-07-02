// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0937DB1F-6025-41D7-A9F3-5BD5E06D478A
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
        valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32> pair
      ) cil managed
    {
      .maxstack 8

      // [28 42 - 28 61]
      IL_0000: ldarg.1      // pair
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
      [11] class [System.Runtime]System.Func`2<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>, bool> V_11,
      [12] bool V_12,
      [13] bool V_13,
      [14] bool V_14,
      [15] bool[] V_15,
      [16] int32 V_16,
      [17] bool a
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

    IL_0089: br.s         IL_0105
    // start of loop, entry point: IL_0105

      // [25 13 - 25 14]
      IL_008b: nop

      // [26 22 - 26 35]
      IL_008c: ldloc.s      q
      IL_008e: ldc.i4.1
      IL_008f: sub
      IL_0090: stloc.s      j

      IL_0092: br.s         IL_00f6
      // start of loop, entry point: IL_00f6

        // [27 17 - 27 18]
        IL_0094: nop

        // [28 21 - 28 63]
        IL_0095: ldloc.s      list
        IL_0097: ldloc.0      // 'CS$<>8__locals0'
        IL_0098: ldfld        class [System.Runtime]System.Func`2<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>, bool> ConsoleApp1.Program/'<>c__DisplayClass1_0'::'<>9__0'
        IL_009d: dup
        IL_009e: brtrue.s     IL_00b8
        IL_00a0: pop
        IL_00a1: ldloc.0      // 'CS$<>8__locals0'
        IL_00a2: ldloc.0      // 'CS$<>8__locals0'
        IL_00a3: ldftn        instance bool ConsoleApp1.Program/'<>c__DisplayClass1_0'::'<Main>b__0'(valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>)
        IL_00a9: newobj       instance void class [System.Runtime]System.Func`2<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>, bool>::.ctor(object, native int)
        IL_00ae: dup
        IL_00af: stloc.s      V_11
        IL_00b1: stfld        class [System.Runtime]System.Func`2<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>, bool> ConsoleApp1.Program/'<>c__DisplayClass1_0'::'<>9__0'
        IL_00b6: ldloc.s      V_11
        IL_00b8: call         bool [System.Linq]System.Linq.Enumerable::All<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>*/>, class [System.Runtime]System.Func`2<!!0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>*/, bool>)
        IL_00bd: stloc.s      V_10

        IL_00bf: ldloc.s      V_10
        IL_00c1: brfalse.s    IL_00c5

        // [29 25 - 29 38]
        IL_00c3: br.s         IL_010a

        // [31 21 - 31 33]
        IL_00c5: ldloc.0      // 'CS$<>8__locals0'
        IL_00c6: ldfld        bool[] ConsoleApp1.Program/'<>c__DisplayClass1_0'::test
        IL_00cb: ldloc.s      j
        IL_00cd: ldelem.u1
        IL_00ce: stloc.s      V_12

        IL_00d0: ldloc.s      V_12
        IL_00d2: brfalse.s    IL_00e2

        // [32 21 - 32 22]
        IL_00d4: nop

        // [33 25 - 33 41]
        IL_00d5: ldloc.0      // 'CS$<>8__locals0'
        IL_00d6: ldfld        bool[] ConsoleApp1.Program/'<>c__DisplayClass1_0'::test
        IL_00db: ldloc.s      j
        IL_00dd: ldc.i4.0
        IL_00de: stelem.i1

        // [34 21 - 34 22]
        IL_00df: nop

        IL_00e0: br.s         IL_00ef

        // [36 21 - 36 22]
        IL_00e2: nop

        // [37 25 - 37 40]
        IL_00e3: ldloc.0      // 'CS$<>8__locals0'
        IL_00e4: ldfld        bool[] ConsoleApp1.Program/'<>c__DisplayClass1_0'::test
        IL_00e9: ldloc.s      j
        IL_00eb: ldc.i4.1
        IL_00ec: stelem.i1

        // [38 25 - 38 31]
        IL_00ed: br.s         IL_0104

        // [40 17 - 40 18]
        IL_00ef: nop

        // [26 45 - 26 48]
        IL_00f0: ldloc.s      j
        IL_00f2: ldc.i4.1
        IL_00f3: sub
        IL_00f4: stloc.s      j

        // [26 37 - 26 43]
        IL_00f6: ldloc.s      j
        IL_00f8: ldc.i4.0
        IL_00f9: clt
        IL_00fb: ldc.i4.0
        IL_00fc: ceq
        IL_00fe: stloc.s      V_13

        IL_0100: ldloc.s      V_13
        IL_0102: brtrue.s     IL_0094
      // end of loop

      // [41 13 - 41 14]
      IL_0104: nop

      // [24 13 - 24 25]
      IL_0105: ldc.i4.1
      IL_0106: stloc.s      V_14
      IL_0108: br.s         IL_008b
    // end of loop

    // [43 13 - 43 21]
    IL_010a: nop

    // [44 13 - 44 20]
    IL_010b: nop

    // [44 31 - 44 35]
    IL_010c: ldloc.0      // 'CS$<>8__locals0'
    IL_010d: ldfld        bool[] ConsoleApp1.Program/'<>c__DisplayClass1_0'::test
    IL_0112: stloc.s      V_15
    IL_0114: ldc.i4.0
    IL_0115: stloc.s      V_16

    IL_0117: br.s         IL_0137
    // start of loop, entry point: IL_0137

      // [44 22 - 44 27]
      IL_0119: ldloc.s      V_15
      IL_011b: ldloc.s      V_16
      IL_011d: ldelem.u1
      IL_011e: stloc.s      a

      // [45 17 - 45 41]
      IL_0120: ldloc.2      // sw
      IL_0121: ldloc.s      a
      IL_0123: brtrue.s     IL_0129
      IL_0125: ldc.i4.s     45 // 0x2d
      IL_0127: br.s         IL_012b
      IL_0129: ldc.i4.s     43 // 0x2b
      IL_012b: callvirt     instance void [System.Runtime]System.IO.TextWriter::Write(char)
      IL_0130: nop

      IL_0131: ldloc.s      V_16
      IL_0133: ldc.i4.1
      IL_0134: add
      IL_0135: stloc.s      V_16

      // [44 28 - 44 30]
      IL_0137: ldloc.s      V_16
      IL_0139: ldloc.s      V_15
      IL_013b: ldlen
      IL_013c: conv.i4
      IL_013d: blt.s        IL_0119
    // end of loop

    // [46 13 - 46 24]
    IL_013f: ldloc.2      // sw
    IL_0140: callvirt     instance void [System.Runtime]System.IO.TextWriter::Flush()
    IL_0145: nop

    // [47 9 - 47 10]
    IL_0146: ret

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
