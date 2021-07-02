// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBB8F175-B56D-4AFF-92C9-EF6B0DC55089
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

    .field public valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] pairs
  } // end of class '<>c__DisplayClass0_0'

  .method private hidebysig static void
    Main() cil managed
  {
    .entrypoint
    .maxstack 7
    .locals init (
      [0] valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0' 'CS$<>8__locals0',
      [1] string[0...,0...] 'field',
      [2] string[] input
    )

    // [9 9 - 9 10]
    IL_0000: nop

    // [11 13 - 15 15]
    IL_0001: ldloca.s     'CS$<>8__locals0'
    IL_0003: ldc.i4.s     10 // 0x0a
    IL_0005: newarr       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_000a: dup
    IL_000b: ldc.i4.0
    IL_000c: ldc.i4.s     10 // 0x0a
    IL_000e: ldc.i4.s     10 // 0x0a
    IL_0010: ldc.i4.s     48 // 0x30
    IL_0012: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0017: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_001c: dup
    IL_001d: ldc.i4.1
    IL_001e: ldc.i4.s     10 // 0x0a
    IL_0020: ldc.i4.s     10 // 0x0a
    IL_0022: ldc.i4.s     49 // 0x31
    IL_0024: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0029: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_002e: dup
    IL_002f: ldc.i4.2
    IL_0030: ldc.i4.s     10 // 0x0a
    IL_0032: ldc.i4.s     10 // 0x0a
    IL_0034: ldc.i4.s     50 // 0x32
    IL_0036: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_003b: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0040: dup
    IL_0041: ldc.i4.3
    IL_0042: ldc.i4.s     10 // 0x0a
    IL_0044: ldc.i4.s     10 // 0x0a
    IL_0046: ldc.i4.s     51 // 0x33
    IL_0048: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_004d: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0052: dup
    IL_0053: ldc.i4.4
    IL_0054: ldc.i4.s     10 // 0x0a
    IL_0056: ldc.i4.s     10 // 0x0a
    IL_0058: ldc.i4.s     52 // 0x34
    IL_005a: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_005f: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0064: dup
    IL_0065: ldc.i4.5
    IL_0066: ldc.i4.s     10 // 0x0a
    IL_0068: ldc.i4.s     10 // 0x0a
    IL_006a: ldc.i4.s     53 // 0x35
    IL_006c: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0071: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0076: dup
    IL_0077: ldc.i4.6
    IL_0078: ldc.i4.s     10 // 0x0a
    IL_007a: ldc.i4.s     10 // 0x0a
    IL_007c: ldc.i4.s     54 // 0x36
    IL_007e: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0083: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0088: dup
    IL_0089: ldc.i4.7
    IL_008a: ldc.i4.s     10 // 0x0a
    IL_008c: ldc.i4.s     10 // 0x0a
    IL_008e: ldc.i4.s     55 // 0x37
    IL_0090: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0095: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_009a: dup
    IL_009b: ldc.i4.8
    IL_009c: ldc.i4.s     10 // 0x0a
    IL_009e: ldc.i4.s     10 // 0x0a
    IL_00a0: ldc.i4.s     56 // 0x38
    IL_00a2: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_00a7: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_00ac: dup
    IL_00ad: ldc.i4.s     9 // 0x09
    IL_00af: ldc.i4.s     10 // 0x0a
    IL_00b1: ldc.i4.s     10 // 0x0a
    IL_00b3: ldc.i4.s     57 // 0x39
    IL_00b5: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_00ba: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_00bf: stfld        valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] ConsoleApp1.Program/'<>c__DisplayClass0_0'::pairs
    IL_00c4: nop

    // [30 13 - 30 55]
    IL_00c5: call         string [System.Console]System.Console::ReadLine()
    IL_00ca: ldc.i4.s     32 // 0x20
    IL_00cc: ldc.i4.0
    IL_00cd: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_00d2: stloc.2      // input

    // [31 13 - 31 37]
    IL_00d3: ldloca.s     'CS$<>8__locals0'
    IL_00d5: ldloc.2      // input
    IL_00d6: ldc.i4.0
    IL_00d7: ldelem.ref
    IL_00d8: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_00dd: stfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m

    // [32 13 - 32 37]
    IL_00e2: ldloca.s     'CS$<>8__locals0'
    IL_00e4: ldloc.2      // input
    IL_00e5: ldc.i4.1
    IL_00e6: ldelem.ref
    IL_00e7: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_00ec: stfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k

    // [33 13 - 33 38]
    IL_00f1: ldloc.0      // 'CS$<>8__locals0'
    IL_00f2: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::m
    IL_00f7: ldloc.0      // 'CS$<>8__locals0'
    IL_00f8: ldfld        int32 ConsoleApp1.Program/'<>c__DisplayClass0_0'::k
    IL_00fd: newobj       instance void string[0...,0...]::.ctor(int32, int32)
    IL_0102: stloc.1      // 'field'

    // [34 13 - 34 49]
    IL_0103: ldc.i4.0
    IL_0104: ldc.i4.0
    IL_0105: newobj       instance void [System.Runtime]System.Text.StringBuilder::.ctor()
    IL_010a: ldloca.s     'CS$<>8__locals0'
    IL_010c: call         void ConsoleApp1.Program::'<Main>g__move_rec|0_0'(int32, int32, class [System.Runtime]System.Text.StringBuilder, valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'&)
    IL_0111: nop

    // [35 9 - 35 10]
    IL_0112: ret

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
      [1] valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] V_1,
      [2] int32 V_2,
      [3] int32 key,
      [4] int32 'value',
      [5] char num
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
    IL_001b: brfalse.s    IL_001f

    // [21 21 - 21 28]
    IL_001d: br.s         IL_007d

    // [22 17 - 22 31]
    IL_001f: ldarg.2      // s
    IL_0020: ldc.i4.s     32 // 0x20
    IL_0022: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Append(char)
    IL_0027: pop

    // [23 17 - 23 24]
    IL_0028: nop

    // [23 51 - 23 56]
    IL_0029: ldarg.3      // obj3
    IL_002a: ldfld        valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] ConsoleApp1.Program/'<>c__DisplayClass0_0'::pairs
    IL_002f: stloc.1      // V_1
    IL_0030: ldc.i4.0
    IL_0031: stloc.2      // V_2

    IL_0032: br.s         IL_0077
    // start of loop, entry point: IL_0077

      // [23 26 - 23 47]
      IL_0034: ldloc.1      // V_1
      IL_0035: ldloc.2      // V_2
      IL_0036: ldelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
      IL_003b: dup
      IL_003c: ldfld        !0/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::Item1
      IL_0041: stloc.3      // key
      IL_0042: dup
      IL_0043: ldfld        !1/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::Item2
      IL_0048: stloc.s      'value'
      IL_004a: ldfld        !2/*char*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::Item3
      IL_004f: stloc.s      num

      // [24 17 - 24 18]
      IL_0051: nop

      // [25 21 - 25 45]
      IL_0052: ldarg.2      // s
      IL_0053: ldarg.2      // s
      IL_0054: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Capacity()
      IL_0059: ldc.i4.1
      IL_005a: sub
      IL_005b: ldloc.s      num
      IL_005d: callvirt     instance void [System.Runtime]System.Text.StringBuilder::set_Chars(int32, char)
      IL_0062: nop

      // [26 21 - 26 53]
      IL_0063: ldarg.0      // x
      IL_0064: ldloc.3      // key
      IL_0065: add
      IL_0066: ldarg.1      // y
      IL_0067: ldloc.s      'value'
      IL_0069: add
      IL_006a: ldarg.2      // s
      IL_006b: ldarg.3      // obj3
      IL_006c: call         void ConsoleApp1.Program::'<Main>g__move_rec|0_0'(int32, int32, class [System.Runtime]System.Text.StringBuilder, valuetype ConsoleApp1.Program/'<>c__DisplayClass0_0'&)
      IL_0071: nop

      // [27 17 - 27 18]
      IL_0072: nop

      IL_0073: ldloc.2      // V_2
      IL_0074: ldc.i4.1
      IL_0075: add
      IL_0076: stloc.2      // V_2

      // [23 48 - 23 50]
      IL_0077: ldloc.2      // V_2
      IL_0078: ldloc.1      // V_1
      IL_0079: ldlen
      IL_007a: conv.i4
      IL_007b: blt.s        IL_0034
    // end of loop

    // [28 13 - 28 14]
    IL_007d: ret

  } // end of method Program::'<Main>g__move_rec|0_0'
} // end of class ConsoleApp1.Program
