// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2000E681-2477-4C17-9111-13FD1CD86836
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

    .field public valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] pairs
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
    IL_0005: newarr       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_000a: dup
    IL_000b: ldc.i4.0
    IL_000c: ldc.i4.6
    IL_000d: ldc.i4.0
    IL_000e: ldc.i4.s     48 // 0x30
    IL_0010: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0015: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_001a: dup
    IL_001b: ldc.i4.1
    IL_001c: ldc.i4.2
    IL_001d: ldc.i4.1
    IL_001e: ldc.i4.s     49 // 0x31
    IL_0020: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0025: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_002a: dup
    IL_002b: ldc.i4.2
    IL_002c: ldc.i4.3
    IL_002d: ldc.i4.1
    IL_002e: ldc.i4.s     50 // 0x32
    IL_0030: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0035: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_003a: dup
    IL_003b: ldc.i4.3
    IL_003c: ldc.i4.2
    IL_003d: ldc.i4.2
    IL_003e: ldc.i4.s     51 // 0x33
    IL_0040: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0045: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_004a: dup
    IL_004b: ldc.i4.4
    IL_004c: ldc.i4.4
    IL_004d: ldc.i4.0
    IL_004e: ldc.i4.s     52 // 0x34
    IL_0050: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0055: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_005a: dup
    IL_005b: ldc.i4.5
    IL_005c: ldc.i4.5
    IL_005d: ldc.i4.0
    IL_005e: ldc.i4.s     53 // 0x35
    IL_0060: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0065: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_006a: dup
    IL_006b: ldc.i4.6
    IL_006c: ldc.i4.4
    IL_006d: ldc.i4.1
    IL_006e: ldc.i4.s     54 // 0x36
    IL_0070: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0075: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_007a: dup
    IL_007b: ldc.i4.7
    IL_007c: ldc.i4.2
    IL_007d: ldc.i4.1
    IL_007e: ldc.i4.s     55 // 0x37
    IL_0080: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0085: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_008a: dup
    IL_008b: ldc.i4.8
    IL_008c: ldc.i4.7
    IL_008d: ldc.i4.0
    IL_008e: ldc.i4.s     56 // 0x38
    IL_0090: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0095: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_009a: dup
    IL_009b: ldc.i4.s     9 // 0x09
    IL_009d: ldc.i4.4
    IL_009e: ldc.i4.1
    IL_009f: ldc.i4.s     57 // 0x39
    IL_00a1: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_00a6: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_00ab: stfld        valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] ConsoleApp1.Program/'<>c__DisplayClass0_0'::pairs
    IL_00b0: nop

    // [49 13 - 49 55]
    IL_00b1: call         string [System.Console]System.Console::ReadLine()
    IL_00b6: ldc.i4.s     32 // 0x20
    IL_00b8: ldc.i4.0
    IL_00b9: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_00be: stloc.1      // input

    // [50 13 - 50 37]
    IL_00bf: ldloca.s     'CS$<>8__locals0'
    IL_00c1: ldloc.1      // input
    IL_00c2: ldc.i4.0
    IL_00c3: ldelem.ref
    IL_00c4: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_00c9: stfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m

    // [51 13 - 51 37]
    IL_00ce: ldloca.s     'CS$<>8__locals0'
    IL_00d0: ldloc.1      // input
    IL_00d1: ldc.i4.1
    IL_00d2: ldelem.ref
    IL_00d3: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_00d8: stfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k

    // [52 13 - 52 38]
    IL_00dd: ldloca.s     'CS$<>8__locals0'
    IL_00df: ldloc.0      // 'CS$<>8__locals0'
    IL_00e0: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_00e5: ldloc.0      // 'CS$<>8__locals0'
    IL_00e6: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_00eb: newobj       instance void string[0...,0...]::.ctor(int32, int32)
    IL_00f0: stfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'

    // [53 13 - 53 49]
    IL_00f5: ldc.i4.0
    IL_00f6: ldc.i4.0
    IL_00f7: newobj       instance void [System.Runtime]System.Text.StringBuilder::.ctor()
    IL_00fc: ldloca.s     'CS$<>8__locals0'
    IL_00fe: call         void ConsoleApp1.Program::'<Main>g__move_rec|0_0'(int32, int32, class [System.Runtime]System.Text.StringBuilder, valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'&)
    IL_0103: nop

    // [54 13 - 54 92]
    IL_0104: ldloc.0      // 'CS$<>8__locals0'
    IL_0105: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_010a: ldloc.0      // 'CS$<>8__locals0'
    IL_010b: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_0110: ldc.i4.1
    IL_0111: sub
    IL_0112: ldloc.0      // 'CS$<>8__locals0'
    IL_0113: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_0118: ldc.i4.1
    IL_0119: sub
    IL_011a: call         instance string string[0...,0...]::Get(int32, int32)
    IL_011f: brfalse.s    IL_013e
    IL_0121: ldloc.0      // 'CS$<>8__locals0'
    IL_0122: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0127: ldloc.0      // 'CS$<>8__locals0'
    IL_0128: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_012d: ldc.i4.1
    IL_012e: sub
    IL_012f: ldloc.0      // 'CS$<>8__locals0'
    IL_0130: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_0135: ldc.i4.1
    IL_0136: sub
    IL_0137: call         instance string string[0...,0...]::Get(int32, int32)
    IL_013c: br.s         IL_0143
    IL_013e: ldstr        "Wrong"
    IL_0143: call         void [System.Console]System.Console::WriteLine(string)
    IL_0148: nop

    // [55 9 - 55 10]
    IL_0149: ret

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
      class [System.Runtime]System.Text.StringBuilder s,
      [in] valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'& obj3
    ) cil managed
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )
    .maxstack 4
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
      [10] valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] V_10,
      [11] int32 V_11,
      [12] int32 key,
      [13] int32 'value',
      [14] char num
    )

    // [19 13 - 19 14]
    IL_0000: nop

    // [20 17 - 20 39]
    IL_0001: ldarg.0      // x
    IL_0002: ldarg.3      // obj3
    IL_0003: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_0008: bge.s        IL_0018
    IL_000a: ldarg.0      // x
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
    IL_001d: br           IL_0162

    // [22 17 - 22 31]
    IL_0022: ldarg.2      // s
    IL_0023: ldc.i4.s     32 // 0x20
    IL_0025: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Append(char)
    IL_002a: pop

    // [23 17 - 23 41]
    IL_002b: ldarg.3      // obj3
    IL_002c: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0031: ldarg.0      // x
    IL_0032: ldarg.1      // y
    IL_0033: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0038: ldnull
    IL_0039: cgt.un
    IL_003b: stloc.1      // V_1

    IL_003c: ldloc.1      // V_1
    IL_003d: brfalse.s    IL_007d

    // [24 17 - 24 18]
    IL_003f: nop

    // [25 21 - 25 79]
    IL_0040: ldarg.3      // obj3
    IL_0041: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0046: ldarg.0      // x
    IL_0047: ldarg.1      // y
    IL_0048: call         instance string string[0...,0...]::Get(int32, int32)
    IL_004d: ldarg.2      // s
    IL_004e: callvirt     instance string [System.Runtime]System.Object::ToString()
    IL_0053: call         int32 [System.Runtime]System.String::CompareOrdinal(string, string)
    IL_0058: ldc.i4.0
    IL_0059: clt
    IL_005b: ldc.i4.0
    IL_005c: ceq
    IL_005e: stloc.2      // V_2

    IL_005f: ldloc.2      // V_2
    IL_0060: brfalse.s    IL_0077

    // [26 21 - 26 22]
    IL_0062: nop

    // [27 25 - 27 52]
    IL_0063: ldarg.3      // obj3
    IL_0064: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0069: ldarg.0      // x
    IL_006a: ldarg.1      // y
    IL_006b: ldarg.2      // s
    IL_006c: callvirt     instance string [System.Runtime]System.Object::ToString()
    IL_0071: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [28 21 - 28 22]
    IL_0076: nop

    // [29 17 - 29 18]
    IL_0077: nop

    IL_0078: br           IL_0103

    // [31 17 - 31 18]
    IL_007d: nop

    // [32 21 - 32 48]
    IL_007e: ldarg.3      // obj3
    IL_007f: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0084: ldarg.0      // x
    IL_0085: ldarg.1      // y
    IL_0086: ldarg.2      // s
    IL_0087: callvirt     instance string [System.Runtime]System.Object::ToString()
    IL_008c: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [33 21 - 33 28]
    IL_0091: nop

    // [33 41 - 33 46]
    IL_0092: ldarg.3      // obj3
    IL_0093: ldfld        string[0...,0...] ConsoleApp1.Program/'<>c__DisplayClass0_0'::'field'
    IL_0098: stloc.3      // V_3
    IL_0099: ldloc.3      // V_3
    IL_009a: ldc.i4.0
    IL_009b: callvirt     instance int32 [System.Runtime]System.Array::GetUpperBound(int32)
    IL_00a0: stloc.s      V_4
    IL_00a2: ldloc.3      // V_3
    IL_00a3: ldc.i4.1
    IL_00a4: callvirt     instance int32 [System.Runtime]System.Array::GetUpperBound(int32)
    IL_00a9: stloc.s      V_5
    IL_00ab: ldloc.3      // V_3
    IL_00ac: ldc.i4.0
    IL_00ad: callvirt     instance int32 [System.Runtime]System.Array::GetLowerBound(int32)
    IL_00b2: stloc.s      V_6

    IL_00b4: br.s         IL_00fc
    // start of loop, entry point: IL_00fc
      IL_00b6: ldloc.3      // V_3
      IL_00b7: ldc.i4.1
      IL_00b8: callvirt     instance int32 [System.Runtime]System.Array::GetLowerBound(int32)
      IL_00bd: stloc.s      V_7

      IL_00bf: br.s         IL_00f0
      // start of loop, entry point: IL_00f0

        // [33 29 - 33 37]
        IL_00c1: ldloc.3      // V_3
        IL_00c2: ldloc.s      V_6
        IL_00c4: ldloc.s      V_7
        IL_00c6: call         instance string string[0...,0...]::Get(int32, int32)
        IL_00cb: stloc.s      item

        // [34 21 - 34 22]
        IL_00cd: nop

        // [35 25 - 35 42]
        IL_00ce: ldloc.s      item
        IL_00d0: ldnull
        IL_00d1: ceq
        IL_00d3: stloc.s      V_9

        IL_00d5: ldloc.s      V_9
        IL_00d7: brfalse.s    IL_00dc

        // [36 25 - 36 26]
        IL_00d9: nop

        // [37 29 - 37 38]
        IL_00da: br.s         IL_00ea

        // [39 25 - 39 60]
        IL_00dc: ldloc.s      item
        IL_00de: callvirt     instance string [System.Runtime]System.Object::ToString()
        IL_00e3: call         void [System.Console]System.Console::WriteLine(string)
        IL_00e8: nop

        // [40 21 - 40 22]
        IL_00e9: nop

        IL_00ea: ldloc.s      V_7
        IL_00ec: ldc.i4.1
        IL_00ed: add
        IL_00ee: stloc.s      V_7

        // [33 38 - 33 40]
        IL_00f0: ldloc.s      V_7
        IL_00f2: ldloc.s      V_5
        IL_00f4: ble.s        IL_00c1
      // end of loop

      IL_00f6: ldloc.s      V_6
      IL_00f8: ldc.i4.1
      IL_00f9: add
      IL_00fa: stloc.s      V_6

      // [33 38 - 33 40]
      IL_00fc: ldloc.s      V_6
      IL_00fe: ldloc.s      V_4
      IL_0100: ble.s        IL_00b6
    // end of loop

    // [41 17 - 41 18]
    IL_0102: nop

    // [42 17 - 42 24]
    IL_0103: nop

    // [42 51 - 42 56]
    IL_0104: ldarg.3      // obj3
    IL_0105: ldfld        valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] ConsoleApp1.Program/'<>c__DisplayClass0_0'::pairs
    IL_010a: stloc.s      V_10
    IL_010c: ldc.i4.0
    IL_010d: stloc.s      V_11

    IL_010f: br.s         IL_015a
    // start of loop, entry point: IL_015a

      // [42 26 - 42 47]
      IL_0111: ldloc.s      V_10
      IL_0113: ldloc.s      V_11
      IL_0115: ldelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
      IL_011a: dup
      IL_011b: ldfld        !0/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::Item1
      IL_0120: stloc.s      key
      IL_0122: dup
      IL_0123: ldfld        !1/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::Item2
      IL_0128: stloc.s      'value'
      IL_012a: ldfld        !2/*char*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::Item3
      IL_012f: stloc.s      num

      // [43 17 - 43 18]
      IL_0131: nop

      // [44 21 - 44 43]
      IL_0132: ldarg.2      // s
      IL_0133: ldarg.2      // s
      IL_0134: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
      IL_0139: ldc.i4.1
      IL_013a: sub
      IL_013b: ldloc.s      num
      IL_013d: callvirt     instance void [System.Runtime]System.Text.StringBuilder::set_Chars(int32, char)
      IL_0142: nop

      // [45 21 - 45 53]
      IL_0143: ldarg.0      // x
      IL_0144: ldloc.s      key
      IL_0146: add
      IL_0147: ldarg.1      // y
      IL_0148: ldloc.s      'value'
      IL_014a: add
      IL_014b: ldarg.2      // s
      IL_014c: ldarg.3      // obj3
      IL_014d: call         void ConsoleApp1.Program::'<Main>g__move_rec|0_0'(int32, int32, class [System.Runtime]System.Text.StringBuilder, valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'&)
      IL_0152: nop

      // [46 17 - 46 18]
      IL_0153: nop

      IL_0154: ldloc.s      V_11
      IL_0156: ldc.i4.1
      IL_0157: add
      IL_0158: stloc.s      V_11

      // [42 48 - 42 50]
      IL_015a: ldloc.s      V_11
      IL_015c: ldloc.s      V_10
      IL_015e: ldlen
      IL_015f: conv.i4
      IL_0160: blt.s        IL_0111
    // end of loop

    // [47 13 - 47 14]
    IL_0162: ret

  } // end of method Program::'<Main>g__move_rec|0_0'
} // end of class ConsoleApp1.Program
