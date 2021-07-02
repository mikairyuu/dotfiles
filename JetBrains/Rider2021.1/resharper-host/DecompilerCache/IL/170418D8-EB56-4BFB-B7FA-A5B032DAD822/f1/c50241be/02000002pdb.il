// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 170418D8-EB56-4BFB-B7FA-A5B032DAD822
// Location: /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.dll
// Sequence point data from /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.pdb

.class private auto ansi beforefieldinit
  ConsoleApp1.Program
    extends [System.Runtime]System.Object
{

  .class nested private sealed auto ansi beforefieldinit
    '<>c__DisplayClass0_0'
      extends [System.Runtime]System.ValueType
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )

    .field public int32 m

    .field public int32 k

    .field public string[0...,0...] 'field'

    .field public valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] triples
  } // end of class '<>c__DisplayClass0_0'

  .method private hidebysig static void
    Main() cil managed
  {
    .entrypoint
    .maxstack 7
    .locals init (
      [0] valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0' 'CS$<>8__locals0',
      [1] string[] input
    )

    // [9 9 - 9 10]
    IL_0000: nop

    // [11 13 - 15 15]
    IL_0001: ldloca.s     'CS$<>8__locals0'
    IL_0003: ldc.i4.s     10 // 0x0a
    IL_0005: newarr       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_000a: dup
    IL_000b: ldc.i4.0
    IL_000c: ldc.i4.6
    IL_000d: ldc.i4.0
    IL_000e: ldstr        "0"
    IL_0013: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_0018: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_001d: dup
    IL_001e: ldc.i4.1
    IL_001f: ldc.i4.2
    IL_0020: ldc.i4.1
    IL_0021: ldstr        "1"
    IL_0026: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_002b: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_0030: dup
    IL_0031: ldc.i4.2
    IL_0032: ldc.i4.3
    IL_0033: ldc.i4.1
    IL_0034: ldstr        "2"
    IL_0039: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_003e: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_0043: dup
    IL_0044: ldc.i4.3
    IL_0045: ldc.i4.2
    IL_0046: ldc.i4.2
    IL_0047: ldstr        "3"
    IL_004c: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_0051: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_0056: dup
    IL_0057: ldc.i4.4
    IL_0058: ldc.i4.4
    IL_0059: ldc.i4.0
    IL_005a: ldstr        "4"
    IL_005f: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_0064: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_0069: dup
    IL_006a: ldc.i4.5
    IL_006b: ldc.i4.5
    IL_006c: ldc.i4.0
    IL_006d: ldstr        "5"
    IL_0072: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_0077: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_007c: dup
    IL_007d: ldc.i4.6
    IL_007e: ldc.i4.4
    IL_007f: ldc.i4.1
    IL_0080: ldstr        "6"
    IL_0085: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_008a: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_008f: dup
    IL_0090: ldc.i4.7
    IL_0091: ldc.i4.2
    IL_0092: ldc.i4.1
    IL_0093: ldstr        "7"
    IL_0098: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_009d: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_00a2: dup
    IL_00a3: ldc.i4.8
    IL_00a4: ldc.i4.7
    IL_00a5: ldc.i4.0
    IL_00a6: ldstr        "8"
    IL_00ab: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_00b0: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_00b5: dup
    IL_00b6: ldc.i4.s     9 // 0x09
    IL_00b8: ldc.i4.4
    IL_00b9: ldc.i4.1
    IL_00ba: ldstr        "9"
    IL_00bf: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_00c4: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
    IL_00c9: stfld        valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] ConsoleApp1.Program/'<>c__DisplayClass0_0'::triples
    IL_00ce: nop

    // [48 13 - 48 55]
    IL_00cf: call         string [System.Console]System.Console::ReadLine()
    IL_00d4: ldc.i4.s     32 // 0x20
    IL_00d6: ldc.i4.0
    IL_00d7: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_00dc: stloc.1      // input

    // [49 13 - 49 41]
    IL_00dd: ldloca.s     'CS$<>8__locals0'
    IL_00df: ldloc.1      // input
    IL_00e0: ldc.i4.0
    IL_00e1: ldelem.ref
    IL_00e2: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_00e7: ldc.i4.1
    IL_00e8: add
    IL_00e9: stfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m

    // [50 13 - 50 41]
    IL_00ee: ldloca.s     'CS$<>8__locals0'
    IL_00f0: ldloc.1      // input
    IL_00f1: ldc.i4.1
    IL_00f2: ldelem.ref
    IL_00f3: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_00f8: ldc.i4.1
    IL_00f9: add
    IL_00fa: stfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k

    // [51 13 - 51 38]
    IL_00ff: ldloca.s     'CS$<>8__locals0'
    IL_0101: ldloc.0      // 'CS$<>8__locals0'
    IL_0102: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_0107: ldloc.0      // 'CS$<>8__locals0'
    IL_0108: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_010d: newobj       instance void string[0...,0...]::.ctor(int32, int32)
    IL_0112: stfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'

    // [52 13 - 52 38]
    IL_0117: ldc.i4.0
    IL_0118: ldc.i4.0
    IL_0119: ldstr        ""
    IL_011e: ldc.i4.1
    IL_011f: ldloca.s     'CS$<>8__locals0'
    IL_0121: call         void ConsoleApp1.Program::'<Main>g__move_rec|0_0'(int32, int32, string, bool, valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'&)
    IL_0126: nop

    // [53 13 - 53 92]
    IL_0127: ldloc.0      // 'CS$<>8__locals0'
    IL_0128: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_012d: ldloc.0      // 'CS$<>8__locals0'
    IL_012e: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_0133: ldc.i4.1
    IL_0134: sub
    IL_0135: ldloc.0      // 'CS$<>8__locals0'
    IL_0136: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_013b: ldc.i4.1
    IL_013c: sub
    IL_013d: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0142: brfalse.s    IL_0161
    IL_0144: ldloc.0      // 'CS$<>8__locals0'
    IL_0145: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_014a: ldloc.0      // 'CS$<>8__locals0'
    IL_014b: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_0150: ldc.i4.1
    IL_0151: sub
    IL_0152: ldloc.0      // 'CS$<>8__locals0'
    IL_0153: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_0158: ldc.i4.1
    IL_0159: sub
    IL_015a: call         instance string string[0...,0...]::Get(int32, int32)
    IL_015f: br.s         IL_0166
    IL_0161: ldstr        "Wrong"
    IL_0166: call         void [System.Console]System.Console::WriteLine(string)
    IL_016b: nop

    // [54 9 - 54 10]
    IL_016c: ret

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

  .method assembly hidebysig static void
    '<Main>g__move_rec|0_0'(
      int32 x,
      int32 y,
      string s,
      bool isFirst,
      [in] valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'& obj4
    ) cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )
    .maxstack 5
    .locals init (
      [0] bool V_0,
      [1] bool V_1,
      [2] bool V_2,
      [3] bool V_3,
      [4] valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] V_4,
      [5] int32 V_5,
      [6] int32 key,
      [7] int32 'value',
      [8] string num
    )

    // [19 13 - 19 14]
    IL_0000: nop

    // [20 17 - 20 39]
    IL_0001: ldarg.0      // x
    IL_0002: ldarg.s      obj4
    IL_0004: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_0009: bge.s        IL_001a
    IL_000b: ldarg.1      // y
    IL_000c: ldarg.s      obj4
    IL_000e: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_0013: clt
    IL_0015: ldc.i4.0
    IL_0016: ceq
    IL_0018: br.s         IL_001b
    IL_001a: ldc.i4.1
    IL_001b: stloc.0      // V_0

    IL_001c: ldloc.0      // V_0
    IL_001d: brfalse.s    IL_0024

    // [21 21 - 21 28]
    IL_001f: br           IL_0146

    // [22 17 - 22 41]
    IL_0024: ldarg.s      obj4
    IL_0026: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_002b: ldarg.0      // x
    IL_002c: ldarg.1      // y
    IL_002d: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0032: ldnull
    IL_0033: cgt.un
    IL_0035: stloc.1      // V_1

    IL_0036: ldloc.1      // V_1
    IL_0037: brfalse.s    IL_00a5

    // [23 17 - 23 18]
    IL_0039: nop

    // [24 21 - 24 55]
    IL_003a: ldarg.s      obj4
    IL_003c: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0041: ldarg.0      // x
    IL_0042: ldarg.1      // y
    IL_0043: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0048: callvirt     instance int32 [System.Runtime]System.String::get_Length()
    IL_004d: ldarg.2      // s
    IL_004e: callvirt     instance int32 [System.Runtime]System.String::get_Length()
    IL_0053: cgt
    IL_0055: stloc.2      // V_2

    IL_0056: ldloc.2      // V_2
    IL_0057: brfalse.s    IL_006c

    // [25 21 - 25 22]
    IL_0059: nop

    // [26 25 - 26 41]
    IL_005a: ldarg.s      obj4
    IL_005c: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0061: ldarg.0      // x
    IL_0062: ldarg.1      // y
    IL_0063: ldarg.2      // s
    IL_0064: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [27 21 - 27 22]
    IL_0069: nop

    IL_006a: br.s         IL_00a2

    // [29 21 - 29 22]
    IL_006c: nop

    // [30 25 - 30 83]
    IL_006d: ldarg.s      obj4
    IL_006f: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0074: ldarg.0      // x
    IL_0075: ldarg.1      // y
    IL_0076: call         instance string string[0...,0...]::Get(int32, int32)
    IL_007b: ldarg.2      // s
    IL_007c: callvirt     instance string [System.Runtime]System.Object::ToString()
    IL_0081: call         int32 [System.Runtime]System.String::CompareOrdinal(string, string)
    IL_0086: ldc.i4.0
    IL_0087: clt
    IL_0089: ldc.i4.0
    IL_008a: ceq
    IL_008c: stloc.3      // V_3

    IL_008d: ldloc.3      // V_3
    IL_008e: brfalse.s    IL_00a1

    // [31 25 - 31 26]
    IL_0090: nop

    // [32 29 - 32 45]
    IL_0091: ldarg.s      obj4
    IL_0093: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0098: ldarg.0      // x
    IL_0099: ldarg.1      // y
    IL_009a: ldarg.2      // s
    IL_009b: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [33 25 - 33 26]
    IL_00a0: nop

    // [34 21 - 34 22]
    IL_00a1: nop

    // [35 17 - 35 18]
    IL_00a2: nop

    IL_00a3: br.s         IL_00b6

    // [37 17 - 37 18]
    IL_00a5: nop

    // [38 21 - 38 37]
    IL_00a6: ldarg.s      obj4
    IL_00a8: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_00ad: ldarg.0      // x
    IL_00ae: ldarg.1      // y
    IL_00af: ldarg.2      // s
    IL_00b0: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [39 17 - 39 18]
    IL_00b5: nop

    // [41 17 - 41 88]
    IL_00b6: ldarg.s      obj4
    IL_00b8: ldfld        valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] ConsoleApp1.Program/'<>c__DisplayClass0_0'::triples
    IL_00bd: ldc.i4.0
    IL_00be: ldarg.3      // isFirst
    IL_00bf: brtrue.s     IL_00cf
    IL_00c1: ldc.i4.6
    IL_00c2: ldc.i4.0
    IL_00c3: ldstr        "0"
    IL_00c8: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_00cd: br.s         IL_00e3
    IL_00cf: ldc.i4       2147483647 // 0x7fffffff
    IL_00d4: ldc.i4       2147483647 // 0x7fffffff
    IL_00d9: ldstr        "0"
    IL_00de: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::.ctor(!0/*int32*/, !1/*int32*/, !2/*string*/)
    IL_00e3: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>

    // [42 17 - 42 24]
    IL_00e8: nop

    // [42 51 - 42 58]
    IL_00e9: ldarg.s      obj4
    IL_00eb: ldfld        valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] ConsoleApp1.Program/'<>c__DisplayClass0_0'::triples
    IL_00f0: stloc.s      V_4
    IL_00f2: ldc.i4.0
    IL_00f3: stloc.s      V_5

    IL_00f5: br.s         IL_013e
    // start of loop, entry point: IL_013e

      // [42 26 - 42 47]
      IL_00f7: ldloc.s      V_4
      IL_00f9: ldloc.s      V_5
      IL_00fb: ldelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
      IL_0100: dup
      IL_0101: ldfld        !0/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item1
      IL_0106: stloc.s      key
      IL_0108: dup
      IL_0109: ldfld        !1/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item2
      IL_010e: stloc.s      'value'
      IL_0110: ldfld        !2/*string*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item3
      IL_0115: stloc.s      num

      // [43 17 - 43 18]
      IL_0117: nop

      // [44 21 - 44 82]
      IL_0118: ldarg.0      // x
      IL_0119: ldloc.s      key
      IL_011b: add
      IL_011c: ldarg.1      // y
      IL_011d: ldloc.s      'value'
      IL_011f: add
      IL_0120: ldarg.2      // s
      IL_0121: ldarg.2      // s
      IL_0122: callvirt     instance int32 [System.Runtime]System.String::get_Length()
      IL_0127: ldloc.s      num
      IL_0129: callvirt     instance string [System.Runtime]System.String::Insert(int32, string)
      IL_012e: ldc.i4.0
      IL_012f: ldarg.s      obj4
      IL_0131: call         void ConsoleApp1.Program::'<Main>g__move_rec|0_0'(int32, int32, string, bool, valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'&)
      IL_0136: nop

      // [45 17 - 45 18]
      IL_0137: nop

      IL_0138: ldloc.s      V_5
      IL_013a: ldc.i4.1
      IL_013b: add
      IL_013c: stloc.s      V_5

      // [42 48 - 42 50]
      IL_013e: ldloc.s      V_5
      IL_0140: ldloc.s      V_4
      IL_0142: ldlen
      IL_0143: conv.i4
      IL_0144: blt.s        IL_00f7
    // end of loop

    // [46 13 - 46 14]
    IL_0146: ret

  } // end of method Program::'<Main>g__move_rec|0_0'
} // end of class ConsoleApp1.Program
