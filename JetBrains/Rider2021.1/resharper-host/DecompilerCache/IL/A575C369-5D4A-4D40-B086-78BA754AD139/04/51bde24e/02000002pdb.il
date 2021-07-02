// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A575C369-5D4A-4D40-B086-78BA754AD139
// Location: /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.dll
// Sequence point data from /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.pdb

.class private auto ansi beforefieldinit
  ConsoleApp1.Program
    extends [System.Runtime]System.Object
{

  .field private static string[0...,0...] 'field'

  .field private static valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] triples

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
      [5] valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] V_5,
      [6] int32 V_6,
      [7] int32 key,
      [8] int32 'value',
      [9] char num
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
    IL_001b: br           IL_0178

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
    IL_00d7: ldsfld       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] ConsoleApp1.Program::triples
    IL_00dc: ldc.i4.0
    IL_00dd: ldarg.3      // isFirst
    IL_00de: brtrue.s     IL_00eb
    IL_00e0: ldc.i4.6
    IL_00e1: ldc.i4.0
    IL_00e2: ldc.i4.s     48 // 0x30
    IL_00e4: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_00e9: br.s         IL_00fc
    IL_00eb: ldc.i4       2147483647 // 0x7fffffff
    IL_00f0: ldc.i4       2147483647 // 0x7fffffff
    IL_00f5: ldc.i4.s     48 // 0x30
    IL_00f7: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_00fc: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>

    // [42 13 - 42 27]
    IL_0101: ldarg.2      // s
    IL_0102: ldc.i4.s     32 // 0x20
    IL_0104: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Append(char)
    IL_0109: pop

    // [43 13 - 43 20]
    IL_010a: nop

    // [43 47 - 43 54]
    IL_010b: ldsfld       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] ConsoleApp1.Program::triples
    IL_0110: stloc.s      V_5
    IL_0112: ldc.i4.0
    IL_0113: stloc.s      V_6

    IL_0115: br.s         IL_0160
    // start of loop, entry point: IL_0160

      // [43 22 - 43 43]
      IL_0117: ldloc.s      V_5
      IL_0119: ldloc.s      V_6
      IL_011b: ldelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
      IL_0120: dup
      IL_0121: ldfld        !0/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::Item1
      IL_0126: stloc.s      key
      IL_0128: dup
      IL_0129: ldfld        !1/*int32*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::Item2
      IL_012e: stloc.s      'value'
      IL_0130: ldfld        !2/*char*/ valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::Item3
      IL_0135: stloc.s      num

      // [44 13 - 44 14]
      IL_0137: nop

      // [45 17 - 45 39]
      IL_0138: ldarg.2      // s
      IL_0139: ldarg.2      // s
      IL_013a: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
      IL_013f: ldc.i4.1
      IL_0140: sub
      IL_0141: ldloc.s      num
      IL_0143: callvirt     instance void [System.Runtime]System.Text.StringBuilder::set_Chars(int32, char)
      IL_0148: nop

      // [46 17 - 46 56]
      IL_0149: ldarg.0      // x
      IL_014a: ldloc.s      key
      IL_014c: add
      IL_014d: ldarg.1      // y
      IL_014e: ldloc.s      'value'
      IL_0150: add
      IL_0151: ldarg.2      // s
      IL_0152: ldc.i4.0
      IL_0153: call         void ConsoleApp1.Program::move_rec(int32, int32, class [System.Runtime]System.Text.StringBuilder, bool)
      IL_0158: nop

      // [47 13 - 47 14]
      IL_0159: nop

      IL_015a: ldloc.s      V_6
      IL_015c: ldc.i4.1
      IL_015d: add
      IL_015e: stloc.s      V_6

      // [43 44 - 43 46]
      IL_0160: ldloc.s      V_6
      IL_0162: ldloc.s      V_5
      IL_0164: ldlen
      IL_0165: conv.i4
      IL_0166: blt.s        IL_0117
    // end of loop

    // [48 13 - 48 39]
    IL_0168: ldarg.2      // s
    IL_0169: ldarg.2      // s
    IL_016a: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
    IL_016f: ldc.i4.1
    IL_0170: sub
    IL_0171: ldc.i4.1
    IL_0172: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Remove(int32, int32)
    IL_0177: pop

    // [49 9 - 49 10]
    IL_0178: ret

  } // end of method Program::move_rec

  .method private hidebysig static void
    Main() cil managed
  {
    .entrypoint
    .maxstack 4
    .locals init (
      [0] string[] input
    )

    // [52 9 - 52 10]
    IL_0000: nop

    // [53 13 - 53 55]
    IL_0001: call         string [System.Console]System.Console::ReadLine()
    IL_0006: ldc.i4.s     32 // 0x20
    IL_0008: ldc.i4.0
    IL_0009: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_000e: stloc.0      // input

    // [54 13 - 54 41]
    IL_000f: ldloc.0      // input
    IL_0010: ldc.i4.0
    IL_0011: ldelem.ref
    IL_0012: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0017: ldc.i4.1
    IL_0018: add
    IL_0019: stsfld       int32 ConsoleApp1.Program::m

    // [55 13 - 55 41]
    IL_001e: ldloc.0      // input
    IL_001f: ldc.i4.1
    IL_0020: ldelem.ref
    IL_0021: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0026: ldc.i4.1
    IL_0027: add
    IL_0028: stsfld       int32 ConsoleApp1.Program::k

    // [56 13 - 56 38]
    IL_002d: ldsfld       int32 ConsoleApp1.Program::m
    IL_0032: ldsfld       int32 ConsoleApp1.Program::k
    IL_0037: newobj       instance void string[0...,0...]::.ctor(int32, int32)
    IL_003c: stsfld       string[0...,0...] ConsoleApp1.Program::'field'

    // [57 13 - 57 57]
    IL_0041: ldc.i4.0
    IL_0042: ldc.i4.0
    IL_0043: ldstr        ""
    IL_0048: newobj       instance void [System.Runtime]System.Text.StringBuilder::.ctor(string)
    IL_004d: ldc.i4.1
    IL_004e: call         void ConsoleApp1.Program::move_rec(int32, int32, class [System.Runtime]System.Text.StringBuilder, bool)
    IL_0053: nop

    // [58 13 - 58 92]
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

    // [59 9 - 59 10]
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
    IL_0002: newarr       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0007: dup
    IL_0008: ldc.i4.0
    IL_0009: ldc.i4.6
    IL_000a: ldc.i4.0
    IL_000b: ldc.i4.s     48 // 0x30
    IL_000d: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0012: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0017: dup
    IL_0018: ldc.i4.1
    IL_0019: ldc.i4.2
    IL_001a: ldc.i4.1
    IL_001b: ldc.i4.s     49 // 0x31
    IL_001d: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0022: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0027: dup
    IL_0028: ldc.i4.2
    IL_0029: ldc.i4.3
    IL_002a: ldc.i4.1
    IL_002b: ldc.i4.s     50 // 0x32
    IL_002d: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0032: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0037: dup
    IL_0038: ldc.i4.3
    IL_0039: ldc.i4.2
    IL_003a: ldc.i4.2
    IL_003b: ldc.i4.s     51 // 0x33
    IL_003d: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0042: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0047: dup
    IL_0048: ldc.i4.4
    IL_0049: ldc.i4.4
    IL_004a: ldc.i4.0
    IL_004b: ldc.i4.s     52 // 0x34
    IL_004d: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0052: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0057: dup
    IL_0058: ldc.i4.5
    IL_0059: ldc.i4.5
    IL_005a: ldc.i4.0
    IL_005b: ldc.i4.s     53 // 0x35
    IL_005d: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0062: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0067: dup
    IL_0068: ldc.i4.6
    IL_0069: ldc.i4.4
    IL_006a: ldc.i4.1
    IL_006b: ldc.i4.s     54 // 0x36
    IL_006d: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0072: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0077: dup
    IL_0078: ldc.i4.7
    IL_0079: ldc.i4.2
    IL_007a: ldc.i4.1
    IL_007b: ldc.i4.s     55 // 0x37
    IL_007d: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0082: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0087: dup
    IL_0088: ldc.i4.8
    IL_0089: ldc.i4.7
    IL_008a: ldc.i4.0
    IL_008b: ldc.i4.s     56 // 0x38
    IL_008d: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_0092: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_0097: dup
    IL_0098: ldc.i4.s     9 // 0x09
    IL_009a: ldc.i4.4
    IL_009b: ldc.i4.1
    IL_009c: ldc.i4.s     57 // 0x39
    IL_009e: newobj       instance void valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>::.ctor(!0/*int32*/, !1/*int32*/, !2/*char*/)
    IL_00a3: stelem       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>
    IL_00a8: stsfld       valuetype [System.Runtime]System.ValueTuple`3<int32, int32, char>[] ConsoleApp1.Program::triples
    IL_00ad: ret

  } // end of method Program::.cctor
} // end of class ConsoleApp1.Program
