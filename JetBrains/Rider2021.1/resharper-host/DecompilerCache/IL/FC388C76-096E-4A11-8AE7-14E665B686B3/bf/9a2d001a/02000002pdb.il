// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC388C76-096E-4A11-8AE7-14E665B686B3
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
      string s,
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

    // [18 9 - 18 10]
    IL_0000: nop

    // [19 13 - 19 35]
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

    // [20 17 - 20 24]
    IL_001b: br           IL_014a

    // [21 13 - 21 37]
    IL_0020: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0025: ldarg.0      // x
    IL_0026: ldarg.1      // y
    IL_0027: call         instance string string[0...,0...]::Get(int32, int32)
    IL_002c: ldnull
    IL_002d: cgt.un
    IL_002f: stloc.1      // V_1

    IL_0030: ldloc.1      // V_1
    IL_0031: brfalse.s    IL_00b1

    // [22 13 - 22 14]
    IL_0033: nop

    // [23 17 - 23 51]
    IL_0034: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0039: ldarg.0      // x
    IL_003a: ldarg.1      // y
    IL_003b: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0040: callvirt     instance int32 [System.Runtime]System.String::get_Length()
    IL_0045: ldarg.2      // s
    IL_0046: callvirt     instance int32 [System.Runtime]System.String::get_Length()
    IL_004b: cgt
    IL_004d: stloc.2      // V_2

    IL_004e: ldloc.2      // V_2
    IL_004f: brfalse.s    IL_0062

    // [24 17 - 24 18]
    IL_0051: nop

    // [25 21 - 25 37]
    IL_0052: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0057: ldarg.0      // x
    IL_0058: ldarg.1      // y
    IL_0059: ldarg.2      // s
    IL_005a: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [26 17 - 26 18]
    IL_005f: nop

    IL_0060: br.s         IL_00ae

    // [27 22 - 27 57]
    IL_0062: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0067: ldarg.0      // x
    IL_0068: ldarg.1      // y
    IL_0069: call         instance string string[0...,0...]::Get(int32, int32)
    IL_006e: callvirt     instance int32 [System.Runtime]System.String::get_Length()
    IL_0073: ldarg.2      // s
    IL_0074: callvirt     instance int32 [System.Runtime]System.String::get_Length()
    IL_0079: ceq
    IL_007b: stloc.3      // V_3

    IL_007c: ldloc.3      // V_3
    IL_007d: brfalse.s    IL_00ae

    // [28 17 - 28 18]
    IL_007f: nop

    // [29 21 - 29 68]
    IL_0080: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0085: ldarg.0      // x
    IL_0086: ldarg.1      // y
    IL_0087: call         instance string string[0...,0...]::Get(int32, int32)
    IL_008c: ldarg.2      // s
    IL_008d: call         int32 [System.Runtime]System.String::CompareOrdinal(string, string)
    IL_0092: ldc.i4.0
    IL_0093: clt
    IL_0095: ldc.i4.0
    IL_0096: ceq
    IL_0098: stloc.s      V_4

    IL_009a: ldloc.s      V_4
    IL_009c: brfalse.s    IL_00ad

    // [30 21 - 30 22]
    IL_009e: nop

    // [31 25 - 31 41]
    IL_009f: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_00a4: ldarg.0      // x
    IL_00a5: ldarg.1      // y
    IL_00a6: ldarg.2      // s
    IL_00a7: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [32 21 - 32 22]
    IL_00ac: nop

    // [33 17 - 33 18]
    IL_00ad: nop

    // [34 13 - 34 14]
    IL_00ae: nop

    IL_00af: br.s         IL_00c0

    // [36 13 - 36 14]
    IL_00b1: nop

    // [37 17 - 37 33]
    IL_00b2: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_00b7: ldarg.0      // x
    IL_00b8: ldarg.1      // y
    IL_00b9: ldarg.2      // s
    IL_00ba: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [38 13 - 38 14]
    IL_00bf: nop

    // [40 13 - 40 84]
    IL_00c0: ldsfld       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] ConsoleApp1.Program::triples
    IL_00c5: ldc.i4.0
    IL_00c6: ldarg.3      // isFirst
    IL_00c7: brtrue.s     IL_00d7
    IL_00c9: ldc.i4.6
    IL_00ca: ldc.i4.0
    IL_00cb: ldstr        "0"
    IL_00d0: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_00d5: br.s         IL_00eb
    IL_00d7: ldc.i4       2147483647 // 0x7fffffff
    IL_00dc: ldc.i4       2147483647 // 0x7fffffff
    IL_00e1: ldstr        "0"
    IL_00e6: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_00eb: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>

    // [41 13 - 41 20]
    IL_00f0: nop

    // [41 47 - 41 54]
    IL_00f1: ldsfld       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] ConsoleApp1.Program::triples
    IL_00f6: stloc.s      V_5
    IL_00f8: ldc.i4.0
    IL_00f9: stloc.s      V_6

    IL_00fb: br.s         IL_0142
    // start of loop, entry point: IL_0142

      // [41 22 - 41 43]
      IL_00fd: ldloc.s      V_5
      IL_00ff: ldloc.s      V_6
      IL_0101: ldelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
      IL_0106: dup
      IL_0107: ldfld        !0/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item1
      IL_010c: stloc.s      key
      IL_010e: dup
      IL_010f: ldfld        !1/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item2
      IL_0114: stloc.s      'value'
      IL_0116: ldfld        !2/*string*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item3
      IL_011b: stloc.s      num

      // [42 13 - 42 14]
      IL_011d: nop

      // [43 17 - 43 78]
      IL_011e: ldarg.0      // x
      IL_011f: ldloc.s      key
      IL_0121: add
      IL_0122: ldarg.1      // y
      IL_0123: ldloc.s      'value'
      IL_0125: add
      IL_0126: ldarg.2      // s
      IL_0127: ldarg.2      // s
      IL_0128: callvirt     instance int32 [System.Runtime]System.String::get_Length()
      IL_012d: ldloc.s      num
      IL_012f: callvirt     instance string [System.Runtime]System.String::Insert(int32, string)
      IL_0134: ldc.i4.0
      IL_0135: call         void ConsoleApp1.Program::move_rec(int32, int32, string, bool)
      IL_013a: nop

      // [44 13 - 44 14]
      IL_013b: nop

      IL_013c: ldloc.s      V_6
      IL_013e: ldc.i4.1
      IL_013f: add
      IL_0140: stloc.s      V_6

      // [41 44 - 41 46]
      IL_0142: ldloc.s      V_6
      IL_0144: ldloc.s      V_5
      IL_0146: ldlen
      IL_0147: conv.i4
      IL_0148: blt.s        IL_00fd
    // end of loop

    // [45 9 - 45 10]
    IL_014a: ret

  } // end of method Program::move_rec

  .method private hidebysig static void
    Main() cil managed
  {
    .entrypoint
    .maxstack 4
    .locals init (
      [0] string[] input
    )

    // [48 9 - 48 10]
    IL_0000: nop

    // [49 13 - 49 55]
    IL_0001: call         string [System.Console]System.Console::ReadLine()
    IL_0006: ldc.i4.s     32 // 0x20
    IL_0008: ldc.i4.0
    IL_0009: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_000e: stloc.0      // input

    // [50 13 - 50 41]
    IL_000f: ldloc.0      // input
    IL_0010: ldc.i4.0
    IL_0011: ldelem.ref
    IL_0012: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0017: ldc.i4.1
    IL_0018: add
    IL_0019: stsfld       int32 ConsoleApp1.Program::m

    // [51 13 - 51 41]
    IL_001e: ldloc.0      // input
    IL_001f: ldc.i4.1
    IL_0020: ldelem.ref
    IL_0021: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0026: ldc.i4.1
    IL_0027: add
    IL_0028: stsfld       int32 ConsoleApp1.Program::k

    // [52 13 - 52 38]
    IL_002d: ldsfld       int32 ConsoleApp1.Program::m
    IL_0032: ldsfld       int32 ConsoleApp1.Program::k
    IL_0037: newobj       instance void string[0...,0...]::.ctor(int32, int32)
    IL_003c: stsfld       string[0...,0...] ConsoleApp1.Program::'field'

    // [53 13 - 53 38]
    IL_0041: ldc.i4.0
    IL_0042: ldc.i4.0
    IL_0043: ldstr        ""
    IL_0048: ldc.i4.1
    IL_0049: call         void ConsoleApp1.Program::move_rec(int32, int32, string, bool)
    IL_004e: nop

    // [54 13 - 54 92]
    IL_004f: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0054: ldsfld       int32 ConsoleApp1.Program::m
    IL_0059: ldc.i4.1
    IL_005a: sub
    IL_005b: ldsfld       int32 ConsoleApp1.Program::k
    IL_0060: ldc.i4.1
    IL_0061: sub
    IL_0062: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0067: brfalse.s    IL_0083
    IL_0069: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_006e: ldsfld       int32 ConsoleApp1.Program::m
    IL_0073: ldc.i4.1
    IL_0074: sub
    IL_0075: ldsfld       int32 ConsoleApp1.Program::k
    IL_007a: ldc.i4.1
    IL_007b: sub
    IL_007c: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0081: br.s         IL_0088
    IL_0083: ldstr        "Wrong"
    IL_0088: call         void [System.Console]System.Console::WriteLine(string)
    IL_008d: nop

    // [55 9 - 55 10]
    IL_008e: ret

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

    // [10 9 - 13 11]
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
