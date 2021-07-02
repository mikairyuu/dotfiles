// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5B727D96-3CB2-4AFE-A31B-D6B401C3E13E
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

    // [49 13 - 49 55]
    IL_00cf: call         string [System.Console]System.Console::ReadLine()
    IL_00d4: ldc.i4.s     32 // 0x20
    IL_00d6: ldc.i4.0
    IL_00d7: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_00dc: stloc.1      // input

    // [50 13 - 50 41]
    IL_00dd: ldloca.s     'CS$<>8__locals0'
    IL_00df: ldloc.1      // input
    IL_00e0: ldc.i4.0
    IL_00e1: ldelem.ref
    IL_00e2: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_00e7: ldc.i4.1
    IL_00e8: add
    IL_00e9: stfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m

    // [51 13 - 51 41]
    IL_00ee: ldloca.s     'CS$<>8__locals0'
    IL_00f0: ldloc.1      // input
    IL_00f1: ldc.i4.1
    IL_00f2: ldelem.ref
    IL_00f3: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_00f8: ldc.i4.1
    IL_00f9: add
    IL_00fa: stfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k

    // [52 13 - 52 38]
    IL_00ff: ldloca.s     'CS$<>8__locals0'
    IL_0101: ldloc.0      // 'CS$<>8__locals0'
    IL_0102: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_0107: ldloc.0      // 'CS$<>8__locals0'
    IL_0108: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_010d: newobj       instance void string[0...,0...]::.ctor(int32, int32)
    IL_0112: stfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'

    // [53 13 - 53 32]
    IL_0117: ldc.i4.0
    IL_0118: ldc.i4.0
    IL_0119: ldstr        ""
    IL_011e: ldloca.s     'CS$<>8__locals0'
    IL_0120: call         void ConsoleApp1.Program::'<Main>g__move_rec|0_0'(int32, int32, string, valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'&)
    IL_0125: nop

    // [54 13 - 54 92]
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

    // [55 9 - 55 10]
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
      [3] string[0...,0...] V_3,
      [4] int32 V_4,
      [5] int32 V_5,
      [6] int32 V_6,
      [7] int32 V_7,
      [8] string item,
      [9] bool V_9,
      [10] valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] V_10,
      [11] int32 V_11,
      [12] int32 key,
      [13] int32 'value',
      [14] string num
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
    IL_001d: br           IL_0157

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
    IL_0034: brfalse.s    IL_0074

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

    IL_006f: br           IL_00fa

    // [30 17 - 30 18]
    IL_0074: nop

    // [31 21 - 31 48]
    IL_0075: ldarg.3      // obj3
    IL_0076: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_007b: ldarg.0      // x
    IL_007c: ldarg.1      // y
    IL_007d: ldarg.2      // s
    IL_007e: callvirt     instance string [System.Runtime]System.Object::ToString()
    IL_0083: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [32 21 - 32 28]
    IL_0088: nop

    // [32 42 - 32 47]
    IL_0089: ldarg.3      // obj3
    IL_008a: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_008f: stloc.3      // V_3
    IL_0090: ldloc.3      // V_3
    IL_0091: ldc.i4.0
    IL_0092: callvirt     instance int32 [System.Runtime]System.Array::GetUpperBound(int32)
    IL_0097: stloc.s      V_4
    IL_0099: ldloc.3      // V_3
    IL_009a: ldc.i4.1
    IL_009b: callvirt     instance int32 [System.Runtime]System.Array::GetUpperBound(int32)
    IL_00a0: stloc.s      V_5
    IL_00a2: ldloc.3      // V_3
    IL_00a3: ldc.i4.0
    IL_00a4: callvirt     instance int32 [System.Runtime]System.Array::GetLowerBound(int32)
    IL_00a9: stloc.s      V_6

    IL_00ab: br.s         IL_00f3
    // start of loop, entry point: IL_00f3
      IL_00ad: ldloc.3      // V_3
      IL_00ae: ldc.i4.1
      IL_00af: callvirt     instance int32 [System.Runtime]System.Array::GetLowerBound(int32)
      IL_00b4: stloc.s      V_7

      IL_00b6: br.s         IL_00e7
      // start of loop, entry point: IL_00e7

        // [32 30 - 32 38]
        IL_00b8: ldloc.3      // V_3
        IL_00b9: ldloc.s      V_6
        IL_00bb: ldloc.s      V_7
        IL_00bd: call         instance string string[0...,0...]::Get(int32, int32)
        IL_00c2: stloc.s      item

        // [33 21 - 33 22]
        IL_00c4: nop

        // [34 25 - 34 42]
        IL_00c5: ldloc.s      item
        IL_00c7: ldnull
        IL_00c8: ceq
        IL_00ca: stloc.s      V_9

        IL_00cc: ldloc.s      V_9
        IL_00ce: brfalse.s    IL_00d3

        // [35 25 - 35 26]
        IL_00d0: nop

        // [36 29 - 36 38]
        IL_00d1: br.s         IL_00e1

        // [39 25 - 39 60]
        IL_00d3: ldloc.s      item
        IL_00d5: callvirt     instance string [System.Runtime]System.Object::ToString()
        IL_00da: call         void [System.Console]System.Console::WriteLine(string)
        IL_00df: nop

        // [40 21 - 40 22]
        IL_00e0: nop

        IL_00e1: ldloc.s      V_7
        IL_00e3: ldc.i4.1
        IL_00e4: add
        IL_00e5: stloc.s      V_7

        // [32 39 - 32 41]
        IL_00e7: ldloc.s      V_7
        IL_00e9: ldloc.s      V_5
        IL_00eb: ble.s        IL_00b8
      // end of loop

      IL_00ed: ldloc.s      V_6
      IL_00ef: ldc.i4.1
      IL_00f0: add
      IL_00f1: stloc.s      V_6

      // [32 39 - 32 41]
      IL_00f3: ldloc.s      V_6
      IL_00f5: ldloc.s      V_4
      IL_00f7: ble.s        IL_00ad
    // end of loop

    // [41 17 - 41 18]
    IL_00f9: nop

    // [43 17 - 43 24]
    IL_00fa: nop

    // [43 51 - 43 56]
    IL_00fb: ldarg.3      // obj3
    IL_00fc: ldfld        valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>[] ConsoleApp1.Program/'<>c__DisplayClass0_0'::pairs
    IL_0101: stloc.s      V_10
    IL_0103: ldc.i4.0
    IL_0104: stloc.s      V_11

    IL_0106: br.s         IL_014f
    // start of loop, entry point: IL_014f

      // [43 26 - 43 47]
      IL_0108: ldloc.s      V_10
      IL_010a: ldloc.s      V_11
      IL_010c: ldelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>
      IL_0111: dup
      IL_0112: ldfld        !0/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item1
      IL_0117: stloc.s      key
      IL_0119: dup
      IL_011a: ldfld        !1/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item2
      IL_011f: stloc.s      'value'
      IL_0121: ldfld        !2/*string*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, string>::Item3
      IL_0126: stloc.s      num

      // [44 17 - 44 18]
      IL_0128: nop

      // [45 21 - 45 79]
      IL_0129: ldarg.0      // x
      IL_012a: ldloc.s      key
      IL_012c: add
      IL_012d: ldarg.1      // y
      IL_012e: ldloc.s      'value'
      IL_0130: add
      IL_0131: ldarg.2      // s
      IL_0132: ldarg.2      // s
      IL_0133: callvirt     instance int32 [System.Runtime]System.String::get_Length()
      IL_0138: ldc.i4.1
      IL_0139: sub
      IL_013a: ldloc.s      num
      IL_013c: callvirt     instance string [System.Runtime]System.String::Insert(int32, string)
      IL_0141: ldarg.3      // obj3
      IL_0142: call         void ConsoleApp1.Program::'<Main>g__move_rec|0_0'(int32, int32, string, valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'&)
      IL_0147: nop

      // [46 17 - 46 18]
      IL_0148: nop

      IL_0149: ldloc.s      V_11
      IL_014b: ldc.i4.1
      IL_014c: add
      IL_014d: stloc.s      V_11

      // [43 48 - 43 50]
      IL_014f: ldloc.s      V_11
      IL_0151: ldloc.s      V_10
      IL_0153: ldlen
      IL_0154: conv.i4
      IL_0155: blt.s        IL_0108
    // end of loop

    // [47 13 - 47 14]
    IL_0157: ret

  } // end of method Program::'<Main>g__move_rec|0_0'
} // end of class ConsoleApp1.Program
