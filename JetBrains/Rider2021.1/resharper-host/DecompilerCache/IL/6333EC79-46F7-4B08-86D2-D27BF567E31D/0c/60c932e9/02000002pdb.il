// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6333EC79-46F7-4B08-86D2-D27BF567E31D
// Location: /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.dll
// Sequence point data from /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.pdb

.class private auto ansi beforefieldinit
  ConsoleApp1.Program
    extends [System.Runtime]System.Object
{

  .field private static string[0...,0...] 'field'

  .field private static valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] triples

  .field private static int32 m

  .field private static int32 k

  .method private hidebysig static void
    move_rec(
      int32 x,
      int32 y,
      class [System.Runtime]System.Text.StringBuilder s,
      bool isFirst
    ) cil managed
  {
    .maxstack 5
    .locals init (
      [0] bool V_0,
      [1] bool V_1,
      [2] bool V_2,
      [3] bool V_3,
      [4] bool V_4,
      [5] valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] V_5,
      [6] int32 V_6,
      [7] int32 key,
      [8] int32 'value',
      [9] string num
    )

    // [19 9 - 19 10]
    IL_0000: nop

    // [20 13 - 20 35]
    IL_0001: ldarg.0      // x
    IL_0002: ldsfld       int32 ConsoleApp1.Program::m
    IL_0007: bge.s        IL_0016
    IL_0009: ldarg.1      // y
    IL_000a: ldsfld       int32 ConsoleApp1.Program::k
    IL_000f: clt
    IL_0011: ldc.i4.0
    IL_0012: ceq
    IL_0014: br.s         IL_0017
    IL_0016: ldc.i4.1
    IL_0017: stloc.0      // V_0

    IL_0018: ldloc.0      // V_0
    IL_0019: brfalse.s    IL_0020

    // [21 17 - 21 24]
    IL_001b: br           IL_0171

    // [22 13 - 22 37]
    IL_0020: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0025: ldarg.0      // x
    IL_0026: ldarg.1      // y
    IL_0027: call         instance string string[0...,0...]::Get(int32, int32)
    IL_002c: ldnull
    IL_002d: cgt.un
    IL_002f: stloc.1      // V_1

    IL_0030: ldloc.1      // V_1
    IL_0031: brfalse      IL_00c3

    // [23 13 - 23 14]
    IL_0036: nop

    // [24 17 - 24 51]
    IL_0037: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_003c: ldarg.0      // x
    IL_003d: ldarg.1      // y
    IL_003e: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0043: callvirt     instance int32 [System.Runtime]System.String::get_Length()
    IL_0048: ldarg.2      // s
    IL_0049: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
    IL_004e: cgt
    IL_0050: stloc.2      // V_2

    IL_0051: ldloc.2      // V_2
    IL_0052: brfalse.s    IL_006a

    // [25 17 - 25 18]
    IL_0054: nop

    // [26 21 - 26 48]
    IL_0055: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_005a: ldarg.0      // x
    IL_005b: ldarg.1      // y
    IL_005c: ldarg.2      // s
    IL_005d: callvirt     instance string [System.Runtime]System.Object::ToString()
    IL_0062: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [27 17 - 27 18]
    IL_0067: nop

    IL_0068: br.s         IL_00c0

    // [28 22 - 28 57]
    IL_006a: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_006f: ldarg.0      // x
    IL_0070: ldarg.1      // y
    IL_0071: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0076: callvirt     instance int32 [System.Runtime]System.String::get_Length()
    IL_007b: ldarg.2      // s
    IL_007c: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
    IL_0081: ceq
    IL_0083: stloc.3      // V_3

    IL_0084: ldloc.3      // V_3
    IL_0085: brfalse.s    IL_00c0

    // [29 17 - 29 18]
    IL_0087: nop

    // [30 21 - 30 79]
    IL_0088: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_008d: ldarg.0      // x
    IL_008e: ldarg.1      // y
    IL_008f: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0094: ldarg.2      // s
    IL_0095: callvirt     instance string [System.Runtime]System.Object::ToString()
    IL_009a: call         int32 [System.Runtime]System.String::CompareOrdinal(string, string)
    IL_009f: ldc.i4.0
    IL_00a0: clt
    IL_00a2: ldc.i4.0
    IL_00a3: ceq
    IL_00a5: stloc.s      V_4

    IL_00a7: ldloc.s      V_4
    IL_00a9: brfalse.s    IL_00bf

    // [31 21 - 31 22]
    IL_00ab: nop

    // [32 25 - 32 52]
    IL_00ac: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_00b1: ldarg.0      // x
    IL_00b2: ldarg.1      // y
    IL_00b3: ldarg.2      // s
    IL_00b4: callvirt     instance string [System.Runtime]System.Object::ToString()
    IL_00b9: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [33 21 - 33 22]
    IL_00be: nop

    // [34 17 - 34 18]
    IL_00bf: nop

    // [35 13 - 35 14]
    IL_00c0: nop

    IL_00c1: br.s         IL_00d7

    // [37 13 - 37 14]
    IL_00c3: nop

    // [38 17 - 38 44]
    IL_00c4: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_00c9: ldarg.0      // x
    IL_00ca: ldarg.1      // y
    IL_00cb: ldarg.2      // s
    IL_00cc: callvirt     instance string [System.Runtime]System.Object::ToString()
    IL_00d1: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [39 13 - 39 14]
    IL_00d6: nop

    // [41 13 - 41 84]
    IL_00d7: ldsfld       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] ConsoleApp1.Program::triples
    IL_00dc: ldc.i4.0
    IL_00dd: ldarg.3      // isFirst
    IL_00de: brtrue.s     IL_00ee
    IL_00e0: ldc.i4.6
    IL_00e1: ldc.i4.0
    IL_00e2: ldstr        "0"
    IL_00e7: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_00ec: br.s         IL_0102
    IL_00ee: ldc.i4       2147483647 // 0x7fffffff
    IL_00f3: ldc.i4       2147483647 // 0x7fffffff
    IL_00f8: ldstr        "0"
    IL_00fd: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_0102: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>

    // [42 13 - 42 20]
    IL_0107: nop

    // [42 47 - 42 54]
    IL_0108: ldsfld       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] ConsoleApp1.Program::triples
    IL_010d: stloc.s      V_5
    IL_010f: ldc.i4.0
    IL_0110: stloc.s      V_6

    IL_0112: br.s         IL_0169
    // start of loop, entry point: IL_0169

      // [42 22 - 42 43]
      IL_0114: ldloc.s      V_5
      IL_0116: ldloc.s      V_6
      IL_0118: ldelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
      IL_011d: dup
      IL_011e: ldfld        !0/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item1
      IL_0123: stloc.s      key
      IL_0125: dup
      IL_0126: ldfld        !1/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item2
      IL_012b: stloc.s      'value'
      IL_012d: ldfld        !2/*string*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item3
      IL_0132: stloc.s      num

      // [43 13 - 43 14]
      IL_0134: nop

      // [44 17 - 44 78]
      IL_0135: ldarg.0      // x
      IL_0136: ldloc.s      key
      IL_0138: add
      IL_0139: ldarg.1      // y
      IL_013a: ldloc.s      'value'
      IL_013c: add
      IL_013d: ldarg.2      // s
      IL_013e: ldarg.2      // s
      IL_013f: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
      IL_0144: ldloc.s      num
      IL_0146: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Insert(int32, string)
      IL_014b: ldc.i4.0
      IL_014c: call         void ConsoleApp1.Program::move_rec(int32, int32, class [System.Runtime]System.Text.StringBuilder, bool)
      IL_0151: nop

      // [45 17 - 45 43]
      IL_0152: ldarg.2      // s
      IL_0153: ldarg.2      // s
      IL_0154: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
      IL_0159: ldc.i4.1
      IL_015a: sub
      IL_015b: ldc.i4.1
      IL_015c: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Remove(int32, int32)
      IL_0161: pop

      // [46 13 - 46 14]
      IL_0162: nop

      IL_0163: ldloc.s      V_6
      IL_0165: ldc.i4.1
      IL_0166: add
      IL_0167: stloc.s      V_6

      // [42 44 - 42 46]
      IL_0169: ldloc.s      V_6
      IL_016b: ldloc.s      V_5
      IL_016d: ldlen
      IL_016e: conv.i4
      IL_016f: blt.s        IL_0114
    // end of loop

    // [47 9 - 47 10]
    IL_0171: ret

  } // end of method Program::move_rec

  .method private hidebysig static void
    Main() cil managed
  {
    .entrypoint
    .maxstack 4
    .locals init (
      [0] string[] input
    )

    // [50 9 - 50 10]
    IL_0000: nop

    // [51 13 - 51 55]
    IL_0001: call         string [System.Console]System.Console::ReadLine()
    IL_0006: ldc.i4.s     32 // 0x20
    IL_0008: ldc.i4.0
    IL_0009: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_000e: stloc.0      // input

    // [52 13 - 52 41]
    IL_000f: ldloc.0      // input
    IL_0010: ldc.i4.0
    IL_0011: ldelem.ref
    IL_0012: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0017: ldc.i4.1
    IL_0018: add
    IL_0019: stsfld       int32 ConsoleApp1.Program::m

    // [53 13 - 53 41]
    IL_001e: ldloc.0      // input
    IL_001f: ldc.i4.1
    IL_0020: ldelem.ref
    IL_0021: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0026: ldc.i4.1
    IL_0027: add
    IL_0028: stsfld       int32 ConsoleApp1.Program::k

    // [54 13 - 54 38]
    IL_002d: ldsfld       int32 ConsoleApp1.Program::m
    IL_0032: ldsfld       int32 ConsoleApp1.Program::k
    IL_0037: newobj       instance void string[0...,0...]::.ctor(int32, int32)
    IL_003c: stsfld       string[0...,0...] ConsoleApp1.Program::'field'

    // [55 13 - 55 57]
    IL_0041: ldc.i4.0
    IL_0042: ldc.i4.0
    IL_0043: ldstr        ""
    IL_0048: newobj       instance void [System.Runtime]System.Text.StringBuilder::.ctor(string)
    IL_004d: ldc.i4.1
    IL_004e: call         void ConsoleApp1.Program::move_rec(int32, int32, class [System.Runtime]System.Text.StringBuilder, bool)
    IL_0053: nop

    // [56 13 - 56 92]
    IL_0054: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0059: ldsfld       int32 ConsoleApp1.Program::m
    IL_005e: ldc.i4.1
    IL_005f: sub
    IL_0060: ldsfld       int32 ConsoleApp1.Program::k
    IL_0065: ldc.i4.1
    IL_0066: sub
    IL_0067: call         instance string string[0...,0...]::Get(int32, int32)
    IL_006c: brfalse.s    IL_0088
    IL_006e: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0073: ldsfld       int32 ConsoleApp1.Program::m
    IL_0078: ldc.i4.1
    IL_0079: sub
    IL_007a: ldsfld       int32 ConsoleApp1.Program::k
    IL_007f: ldc.i4.1
    IL_0080: sub
    IL_0081: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0086: br.s         IL_008d
    IL_0088: ldstr        "Wrong"
    IL_008d: call         void [System.Console]System.Console::WriteLine(string)
    IL_0092: nop

    // [57 9 - 57 10]
    IL_0093: ret

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

  .method private hidebysig static specialname rtspecialname void
    .cctor() cil managed
  {
    .maxstack 6

    // [10 9 - 14 11]
    IL_0000: ldc.i4.s     10 // 0x0a
    IL_0002: newarr       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_0007: dup
    IL_0008: ldc.i4.0
    IL_0009: ldc.i4.6
    IL_000a: ldc.i4.0
    IL_000b: ldstr        "0"
    IL_0010: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_0015: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_001a: dup
    IL_001b: ldc.i4.1
    IL_001c: ldc.i4.2
    IL_001d: ldc.i4.1
    IL_001e: ldstr        "1"
    IL_0023: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_0028: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_002d: dup
    IL_002e: ldc.i4.2
    IL_002f: ldc.i4.3
    IL_0030: ldc.i4.1
    IL_0031: ldstr        "2"
    IL_0036: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_003b: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_0040: dup
    IL_0041: ldc.i4.3
    IL_0042: ldc.i4.2
    IL_0043: ldc.i4.2
    IL_0044: ldstr        "3"
    IL_0049: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_004e: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_0053: dup
    IL_0054: ldc.i4.4
    IL_0055: ldc.i4.4
    IL_0056: ldc.i4.0
    IL_0057: ldstr        "4"
    IL_005c: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_0061: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_0066: dup
    IL_0067: ldc.i4.5
    IL_0068: ldc.i4.5
    IL_0069: ldc.i4.0
    IL_006a: ldstr        "5"
    IL_006f: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_0074: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_0079: dup
    IL_007a: ldc.i4.6
    IL_007b: ldc.i4.4
    IL_007c: ldc.i4.1
    IL_007d: ldstr        "6"
    IL_0082: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_0087: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_008c: dup
    IL_008d: ldc.i4.7
    IL_008e: ldc.i4.2
    IL_008f: ldc.i4.1
    IL_0090: ldstr        "7"
    IL_0095: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_009a: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_009f: dup
    IL_00a0: ldc.i4.8
    IL_00a1: ldc.i4.7
    IL_00a2: ldc.i4.0
    IL_00a3: ldstr        "8"
    IL_00a8: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_00ad: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_00b2: dup
    IL_00b3: ldc.i4.s     9 // 0x09
    IL_00b5: ldc.i4.4
    IL_00b6: ldc.i4.1
    IL_00b7: ldstr        "9"
    IL_00bc: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_00c1: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_00c6: stsfld       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] ConsoleApp1.Program::triples
    IL_00cb: ret

  } // end of method Program::.cctor
} // end of class ConsoleApp1.Program
