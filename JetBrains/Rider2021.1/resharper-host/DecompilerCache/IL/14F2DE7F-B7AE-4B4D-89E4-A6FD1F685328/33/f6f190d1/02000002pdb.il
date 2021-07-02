// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 14F2DE7F-B7AE-4B4D-89E4-A6FD1F685328
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

    .field public valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] pairs
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
    IL_00c9: stfld        valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] ConsoleApp1.Program/'<>c__DisplayClass0_0'::pairs
    IL_00ce: nop

    // [40 13 - 40 55]
    IL_00cf: call         string [System.Console]System.Console::ReadLine()
    IL_00d4: ldc.i4.s     32 // 0x20
    IL_00d6: ldc.i4.0
    IL_00d7: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_00dc: stloc.1      // input

    // [41 13 - 41 41]
    IL_00dd: ldloca.s     'CS$<>8__locals0'
    IL_00df: ldloc.1      // input
    IL_00e0: ldc.i4.0
    IL_00e1: ldelem.ref
    IL_00e2: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_00e7: ldc.i4.1
    IL_00e8: add
    IL_00e9: stfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m

    // [42 13 - 42 41]
    IL_00ee: ldloca.s     'CS$<>8__locals0'
    IL_00f0: ldloc.1      // input
    IL_00f1: ldc.i4.1
    IL_00f2: ldelem.ref
    IL_00f3: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_00f8: ldc.i4.1
    IL_00f9: add
    IL_00fa: stfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k

    // [43 13 - 43 38]
    IL_00ff: ldloca.s     'CS$<>8__locals0'
    IL_0101: ldloc.0      // 'CS$<>8__locals0'
    IL_0102: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_0107: ldloc.0      // 'CS$<>8__locals0'
    IL_0108: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_010d: newobj       instance void string[0...,0...]::.ctor(int32, int32)
    IL_0112: stfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'

    // [44 13 - 44 32]
    IL_0117: ldc.i4.0
    IL_0118: ldc.i4.0
    IL_0119: ldstr        ""
    IL_011e: ldloca.s     'CS$<>8__locals0'
    IL_0120: call         void ConsoleApp1.Program::'<Main>g__move_rec|0_0'(int32, int32, string, valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'&)
    IL_0125: nop

    // [45 13 - 45 92]
    IL_0126: ldloc.0      // 'CS$<>8__locals0'
    IL_0127: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_012c: ldloc.0      // 'CS$<>8__locals0'
    IL_012d: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_0132: ldc.i4.1
    IL_0133: sub
    IL_0134: ldloc.0      // 'CS$<>8__locals0'
    IL_0135: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_013a: ldc.i4.1
    IL_013b: sub
    IL_013c: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0141: brfalse.s    IL_0160
    IL_0143: ldloc.0      // 'CS$<>8__locals0'
    IL_0144: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0149: ldloc.0      // 'CS$<>8__locals0'
    IL_014a: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_014f: ldc.i4.1
    IL_0150: sub
    IL_0151: ldloc.0      // 'CS$<>8__locals0'
    IL_0152: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_0157: ldc.i4.1
    IL_0158: sub
    IL_0159: call         instance string string[0...,0...]::Get(int32, int32)
    IL_015e: br.s         IL_0165
    IL_0160: ldstr        "Wrong"
    IL_0165: call         void [System.Console]System.Console::WriteLine(string)
    IL_016a: nop

    // [46 9 - 46 10]
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

  .method assembly hidebysig static void
    '<Main>g__move_rec|0_0'(
      int32 x,
      int32 y,
      string s,
      [in] valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'& obj3
    ) cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )
    .maxstack 5
    .locals init (
      [0] bool V_0,
      [1] bool V_1,
      [2] bool V_2,
      [3] valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] V_3,
      [4] int32 V_4,
      [5] int32 key,
      [6] int32 'value',
      [7] string num
    )

    // [19 13 - 19 14]
    IL_0000: nop

    // [20 17 - 20 39]
    IL_0001: ldarg.0      // x
    IL_0002: ldarg.3      // obj3
    IL_0003: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_0008: bge.s        IL_0018
    IL_000a: ldarg.1      // y
    IL_000b: ldarg.3      // obj3
    IL_000c: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_0011: clt
    IL_0013: ldc.i4.0
    IL_0014: ceq
    IL_0016: br.s         IL_0019
    IL_0018: ldc.i4.1
    IL_0019: stloc.0      // V_0

    IL_001a: ldloc.0      // V_0
    IL_001b: brfalse.s    IL_0022

    // [21 21 - 21 28]
    IL_001d: br           IL_00de

    // [22 17 - 22 41]
    IL_0022: ldarg.3      // obj3
    IL_0023: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0028: ldarg.0      // x
    IL_0029: ldarg.1      // y
    IL_002a: call         instance string string[0...,0...]::Get(int32, int32)
    IL_002f: ldnull
    IL_0030: cgt.un
    IL_0032: stloc.1      // V_1

    IL_0033: ldloc.1      // V_1
    IL_0034: brfalse.s    IL_0071

    // [23 17 - 23 18]
    IL_0036: nop

    // [24 21 - 24 79]
    IL_0037: ldarg.3      // obj3
    IL_0038: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_003d: ldarg.0      // x
    IL_003e: ldarg.1      // y
    IL_003f: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0044: ldarg.2      // s
    IL_0045: callvirt     instance string [System.Runtime]System.Object::ToString()
    IL_004a: call         int32 [System.Runtime]System.String::CompareOrdinal(string, string)
    IL_004f: ldc.i4.0
    IL_0050: clt
    IL_0052: ldc.i4.0
    IL_0053: ceq
    IL_0055: stloc.2      // V_2

    IL_0056: ldloc.2      // V_2
    IL_0057: brfalse.s    IL_006e

    // [25 21 - 25 22]
    IL_0059: nop

    // [26 25 - 26 52]
    IL_005a: ldarg.3      // obj3
    IL_005b: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0060: ldarg.0      // x
    IL_0061: ldarg.1      // y
    IL_0062: ldarg.2      // s
    IL_0063: callvirt     instance string [System.Runtime]System.Object::ToString()
    IL_0068: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [27 21 - 27 22]
    IL_006d: nop

    // [28 17 - 28 18]
    IL_006e: nop

    IL_006f: br.s         IL_0086

    // [30 17 - 30 18]
    IL_0071: nop

    // [31 21 - 31 48]
    IL_0072: ldarg.3      // obj3
    IL_0073: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0078: ldarg.0      // x
    IL_0079: ldarg.1      // y
    IL_007a: ldarg.2      // s
    IL_007b: callvirt     instance string [System.Runtime]System.Object::ToString()
    IL_0080: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [32 17 - 32 18]
    IL_0085: nop

    // [34 17 - 34 24]
    IL_0086: nop

    // [34 51 - 34 56]
    IL_0087: ldarg.3      // obj3
    IL_0088: ldfld        valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] ConsoleApp1.Program/'<>c__DisplayClass0_0'::pairs
    IL_008d: stloc.3      // V_3
    IL_008e: ldc.i4.0
    IL_008f: stloc.s      V_4

    IL_0091: br.s         IL_00d7
    // start of loop, entry point: IL_00d7

      // [34 26 - 34 47]
      IL_0093: ldloc.3      // V_3
      IL_0094: ldloc.s      V_4
      IL_0096: ldelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
      IL_009b: dup
      IL_009c: ldfld        !0/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item1
      IL_00a1: stloc.s      key
      IL_00a3: dup
      IL_00a4: ldfld        !1/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item2
      IL_00a9: stloc.s      'value'
      IL_00ab: ldfld        !2/*string*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item3
      IL_00b0: stloc.s      num

      // [35 17 - 35 18]
      IL_00b2: nop

      // [36 21 - 36 75]
      IL_00b3: ldarg.0      // x
      IL_00b4: ldloc.s      key
      IL_00b6: add
      IL_00b7: ldarg.1      // y
      IL_00b8: ldloc.s      'value'
      IL_00ba: add
      IL_00bb: ldarg.2      // s
      IL_00bc: ldarg.2      // s
      IL_00bd: callvirt     instance int32 [System.Runtime]System.String::get_Length()
      IL_00c2: ldloc.s      num
      IL_00c4: callvirt     instance string [System.Runtime]System.String::Insert(int32, string)
      IL_00c9: ldarg.3      // obj3
      IL_00ca: call         void ConsoleApp1.Program::'<Main>g__move_rec|0_0'(int32, int32, string, valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'&)
      IL_00cf: nop

      // [37 17 - 37 18]
      IL_00d0: nop

      IL_00d1: ldloc.s      V_4
      IL_00d3: ldc.i4.1
      IL_00d4: add
      IL_00d5: stloc.s      V_4

      // [34 48 - 34 50]
      IL_00d7: ldloc.s      V_4
      IL_00d9: ldloc.3      // V_3
      IL_00da: ldlen
      IL_00db: conv.i4
      IL_00dc: blt.s        IL_0093
    // end of loop

    // [38 13 - 38 14]
    IL_00de: ret

  } // end of method Program::'<Main>g__move_rec|0_0'
} // end of class ConsoleApp1.Program
