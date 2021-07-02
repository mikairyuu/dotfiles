// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B8CBAE33-260B-4862-8192-394B933CCA8F
// Location: /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.dll
// Sequence point data from /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.pdb

.class private auto ansi beforefieldinit
  ConsoleApp1.Program
    extends [System.Runtime]System.Object
{

  .field private static string[0...,0...] 'field'

  .field private static class ConsoleApp1.Triple[] triples

  .field private static int32 m

  .field private static int32 k

  .method private hidebysig static void
    Main() cil managed
  {
    .entrypoint
    .maxstack 4
    .locals init (
      [0] string[] input,
      [1] bool isFirst,
      [2] class [System.Runtime]System.Text.StringBuilder s,
      [3] int32 i,
      [4] int32 j,
      [5] bool V_5,
      [6] int32 l,
      [7] int32 x,
      [8] int32 y,
      [9] bool V_9,
      [10] bool V_10,
      [11] bool V_11,
      [12] bool V_12,
      [13] bool V_13,
      [14] bool V_14,
      [15] bool V_15,
      [16] bool V_16
    )

    // [35 9 - 35 10]
    IL_0000: nop

    // [36 13 - 36 55]
    IL_0001: call         string [System.Console]System.Console::ReadLine()
    IL_0006: ldc.i4.s     32 // 0x20
    IL_0008: ldc.i4.0
    IL_0009: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_000e: stloc.0      // input

    // [37 13 - 37 41]
    IL_000f: ldloc.0      // input
    IL_0010: ldc.i4.0
    IL_0011: ldelem.ref
    IL_0012: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0017: ldc.i4.1
    IL_0018: add
    IL_0019: stsfld       int32 ConsoleApp1.Program::m

    // [38 13 - 38 41]
    IL_001e: ldloc.0      // input
    IL_001f: ldc.i4.1
    IL_0020: ldelem.ref
    IL_0021: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0026: ldc.i4.1
    IL_0027: add
    IL_0028: stsfld       int32 ConsoleApp1.Program::k

    // [39 13 - 39 38]
    IL_002d: ldsfld       int32 ConsoleApp1.Program::m
    IL_0032: ldsfld       int32 ConsoleApp1.Program::k
    IL_0037: newobj       instance void string[0...,0...]::.ctor(int32, int32)
    IL_003c: stsfld       string[0...,0...] ConsoleApp1.Program::'field'

    // [40 13 - 40 30]
    IL_0041: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0046: ldc.i4.0
    IL_0047: ldc.i4.0
    IL_0048: ldstr        ""
    IL_004d: call         instance void string[0...,0...]::Set(int32, int32, string)

    // [41 13 - 41 32]
    IL_0052: ldc.i4.1
    IL_0053: stloc.1      // isFirst

    // [42 13 - 42 41]
    IL_0054: newobj       instance void [System.Runtime]System.Text.StringBuilder::.ctor()
    IL_0059: stloc.2      // s

    // [43 18 - 43 27]
    IL_005a: ldc.i4.0
    IL_005b: stloc.3      // i

    IL_005c: br           IL_0226
    // start of loop, entry point: IL_0226

      // [44 13 - 44 14]
      IL_0061: nop

      // [45 22 - 45 31]
      IL_0062: ldc.i4.0
      IL_0063: stloc.s      j

      IL_0065: br           IL_020f
      // start of loop, entry point: IL_020f

        // [46 17 - 46 18]
        IL_006a: nop

        // [47 21 - 47 45]
        IL_006b: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
        IL_0070: ldloc.s      j
        IL_0072: ldloc.3      // i
        IL_0073: call         instance string string[0...,0...]::Get(int32, int32)
        IL_0078: ldnull
        IL_0079: ceq
        IL_007b: stloc.s      V_5

        IL_007d: ldloc.s      V_5
        IL_007f: brfalse.s    IL_0086

        // [47 46 - 47 55]
        IL_0081: br           IL_0209

        // [48 21 - 48 31]
        IL_0086: ldloc.2      // s
        IL_0087: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Clear()
        IL_008c: pop

        // [49 21 - 49 43]
        IL_008d: ldloc.2      // s
        IL_008e: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
        IL_0093: ldloc.s      j
        IL_0095: ldloc.3      // i
        IL_0096: call         instance string string[0...,0...]::Get(int32, int32)
        IL_009b: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Append(string)
        IL_00a0: pop

        // [50 26 - 50 58]
        IL_00a1: ldloc.1      // isFirst
        IL_00a2: brfalse.s    IL_00a7
        IL_00a4: ldc.i4.1
        IL_00a5: br.s         IL_00a8
        IL_00a7: ldc.i4.0
        IL_00a8: stloc.s      l

        IL_00aa: br           IL_01e6
        // start of loop, entry point: IL_01e6

          // [51 21 - 51 22]
          IL_00af: nop

          // [52 25 - 52 41]
          IL_00b0: ldc.i4.0
          IL_00b1: stloc.1      // isFirst

          // [53 25 - 53 50]
          IL_00b2: ldloc.s      j
          IL_00b4: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00b9: ldloc.s      l
          IL_00bb: ldelem.ref
          IL_00bc: ldfld        int32 ConsoleApp1.Triple::a
          IL_00c1: add
          IL_00c2: stloc.s      x

          // [54 25 - 54 50]
          IL_00c4: ldloc.3      // i
          IL_00c5: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00ca: ldloc.s      l
          IL_00cc: ldelem.ref
          IL_00cd: ldfld        int32 ConsoleApp1.Triple::b
          IL_00d2: add
          IL_00d3: stloc.s      y

          // [55 25 - 55 47]
          IL_00d5: ldloc.s      x
          IL_00d7: ldsfld       int32 ConsoleApp1.Program::m
          IL_00dc: bge.s        IL_00ec
          IL_00de: ldloc.s      y
          IL_00e0: ldsfld       int32 ConsoleApp1.Program::k
          IL_00e5: clt
          IL_00e7: ldc.i4.0
          IL_00e8: ceq
          IL_00ea: br.s         IL_00ed
          IL_00ec: ldc.i4.1
          IL_00ed: stloc.s      V_9

          IL_00ef: ldloc.s      V_9
          IL_00f1: brfalse.s    IL_00f8

          // [56 29 - 56 38]
          IL_00f3: br           IL_01e0

          // [57 25 - 57 56]
          IL_00f8: ldloc.2      // s
          IL_00f9: ldloc.2      // s
          IL_00fa: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_00ff: ldc.i4.1
          IL_0100: sub
          IL_0101: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_0106: ldloc.s      l
          IL_0108: ldelem.ref
          IL_0109: ldfld        char ConsoleApp1.Triple::c
          IL_010e: callvirt     instance void [System.Runtime]System.Text.StringBuilder::set_Chars(int32, char)
          IL_0113: nop

          // [58 25 - 58 49]
          IL_0114: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0119: ldloc.s      x
          IL_011b: ldloc.s      y
          IL_011d: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0122: ldnull
          IL_0123: cgt.un
          IL_0125: stloc.s      V_10

          IL_0127: ldloc.s      V_10
          IL_0129: brfalse      IL_01c9

          // [59 25 - 59 26]
          IL_012e: nop

          // [60 29 - 60 63]
          IL_012f: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0134: ldloc.s      x
          IL_0136: ldloc.s      y
          IL_0138: call         instance string string[0...,0...]::Get(int32, int32)
          IL_013d: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_0142: ldloc.2      // s
          IL_0143: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_0148: cgt
          IL_014a: stloc.s      V_11

          IL_014c: ldloc.s      V_11
          IL_014e: brfalse.s    IL_0168

          // [61 29 - 61 30]
          IL_0150: nop

          // [62 33 - 62 60]
          IL_0151: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0156: ldloc.s      x
          IL_0158: ldloc.s      y
          IL_015a: ldloc.2      // s
          IL_015b: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_0160: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [63 29 - 63 30]
          IL_0165: nop

          IL_0166: br.s         IL_01c6

          // [64 34 - 64 69]
          IL_0168: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_016d: ldloc.s      x
          IL_016f: ldloc.s      y
          IL_0171: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0176: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_017b: ldloc.2      // s
          IL_017c: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_0181: ceq
          IL_0183: stloc.s      V_12

          IL_0185: ldloc.s      V_12
          IL_0187: brfalse.s    IL_01c6

          // [65 29 - 65 30]
          IL_0189: nop

          // [66 33 - 66 91]
          IL_018a: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_018f: ldloc.s      x
          IL_0191: ldloc.s      y
          IL_0193: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0198: ldloc.2      // s
          IL_0199: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_019e: call         int32 [System.Runtime]System.String::CompareOrdinal(string, string)
          IL_01a3: ldc.i4.0
          IL_01a4: clt
          IL_01a6: ldc.i4.0
          IL_01a7: ceq
          IL_01a9: stloc.s      V_13

          IL_01ab: ldloc.s      V_13
          IL_01ad: brfalse.s    IL_01c5

          // [67 33 - 67 34]
          IL_01af: nop

          // [68 37 - 68 64]
          IL_01b0: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_01b5: ldloc.s      x
          IL_01b7: ldloc.s      y
          IL_01b9: ldloc.2      // s
          IL_01ba: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_01bf: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [69 33 - 69 34]
          IL_01c4: nop

          // [70 29 - 70 30]
          IL_01c5: nop

          // [71 25 - 71 26]
          IL_01c6: nop

          IL_01c7: br.s         IL_01df

          // [73 25 - 73 26]
          IL_01c9: nop

          // [74 29 - 74 56]
          IL_01ca: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_01cf: ldloc.s      x
          IL_01d1: ldloc.s      y
          IL_01d3: ldloc.2      // s
          IL_01d4: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_01d9: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [75 25 - 75 26]
          IL_01de: nop

          // [76 21 - 76 22]
          IL_01df: nop

          // [50 80 - 50 83]
          IL_01e0: ldloc.s      l
          IL_01e2: ldc.i4.1
          IL_01e3: add
          IL_01e4: stloc.s      l

          // [50 60 - 50 78]
          IL_01e6: ldloc.s      l
          IL_01e8: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_01ed: ldlen
          IL_01ee: conv.i4
          IL_01ef: clt
          IL_01f1: stloc.s      V_14

          IL_01f3: ldloc.s      V_14
          IL_01f5: brtrue       IL_00af
        // end of loop

        // [78 21 - 78 43]
        IL_01fa: ldloc.2      // s
        IL_01fb: ldloc.2      // s
        IL_01fc: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
        IL_0201: ldc.i4.1
        IL_0202: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Remove(int32, int32)
        IL_0207: pop

        // [79 17 - 79 18]
        IL_0208: nop

        // [45 40 - 45 43]
        IL_0209: ldloc.s      j
        IL_020b: ldc.i4.1
        IL_020c: add
        IL_020d: stloc.s      j

        // [45 33 - 45 38]
        IL_020f: ldloc.s      j
        IL_0211: ldsfld       int32 ConsoleApp1.Program::m
        IL_0216: clt
        IL_0218: stloc.s      V_15

        IL_021a: ldloc.s      V_15
        IL_021c: brtrue       IL_006a
      // end of loop

      // [80 13 - 80 14]
      IL_0221: nop

      // [43 36 - 43 39]
      IL_0222: ldloc.3      // i
      IL_0223: ldc.i4.1
      IL_0224: add
      IL_0225: stloc.3      // i

      // [43 29 - 43 34]
      IL_0226: ldloc.3      // i
      IL_0227: ldsfld       int32 ConsoleApp1.Program::k
      IL_022c: clt
      IL_022e: stloc.s      V_16

      IL_0230: ldloc.s      V_16
      IL_0232: brtrue       IL_0061
    // end of loop

    // [82 13 - 82 92]
    IL_0237: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_023c: ldsfld       int32 ConsoleApp1.Program::m
    IL_0241: ldc.i4.1
    IL_0242: sub
    IL_0243: ldsfld       int32 ConsoleApp1.Program::k
    IL_0248: ldc.i4.1
    IL_0249: sub
    IL_024a: call         instance string string[0...,0...]::Get(int32, int32)
    IL_024f: brfalse.s    IL_026b
    IL_0251: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0256: ldsfld       int32 ConsoleApp1.Program::m
    IL_025b: ldc.i4.1
    IL_025c: sub
    IL_025d: ldsfld       int32 ConsoleApp1.Program::k
    IL_0262: ldc.i4.1
    IL_0263: sub
    IL_0264: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0269: br.s         IL_0270
    IL_026b: ldstr        "Wrong"
    IL_0270: call         void [System.Console]System.Console::WriteLine(string)
    IL_0275: nop

    // [83 9 - 83 10]
    IL_0276: ret

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

    // [25 9 - 29 11]
    IL_0000: ldc.i4.s     10 // 0x0a
    IL_0002: newarr       ConsoleApp1.Triple
    IL_0007: dup
    IL_0008: ldc.i4.0
    IL_0009: ldc.i4.6
    IL_000a: ldc.i4.0
    IL_000b: ldc.i4.s     48 // 0x30
    IL_000d: newobj       instance void ConsoleApp1.Triple::.ctor(int32, int32, char)
    IL_0012: stelem.ref
    IL_0013: dup
    IL_0014: ldc.i4.1
    IL_0015: ldc.i4.2
    IL_0016: ldc.i4.1
    IL_0017: ldc.i4.s     49 // 0x31
    IL_0019: newobj       instance void ConsoleApp1.Triple::.ctor(int32, int32, char)
    IL_001e: stelem.ref
    IL_001f: dup
    IL_0020: ldc.i4.2
    IL_0021: ldc.i4.3
    IL_0022: ldc.i4.1
    IL_0023: ldc.i4.s     50 // 0x32
    IL_0025: newobj       instance void ConsoleApp1.Triple::.ctor(int32, int32, char)
    IL_002a: stelem.ref
    IL_002b: dup
    IL_002c: ldc.i4.3
    IL_002d: ldc.i4.2
    IL_002e: ldc.i4.2
    IL_002f: ldc.i4.s     51 // 0x33
    IL_0031: newobj       instance void ConsoleApp1.Triple::.ctor(int32, int32, char)
    IL_0036: stelem.ref
    IL_0037: dup
    IL_0038: ldc.i4.4
    IL_0039: ldc.i4.4
    IL_003a: ldc.i4.0
    IL_003b: ldc.i4.s     52 // 0x34
    IL_003d: newobj       instance void ConsoleApp1.Triple::.ctor(int32, int32, char)
    IL_0042: stelem.ref
    IL_0043: dup
    IL_0044: ldc.i4.5
    IL_0045: ldc.i4.5
    IL_0046: ldc.i4.0
    IL_0047: ldc.i4.s     53 // 0x35
    IL_0049: newobj       instance void ConsoleApp1.Triple::.ctor(int32, int32, char)
    IL_004e: stelem.ref
    IL_004f: dup
    IL_0050: ldc.i4.6
    IL_0051: ldc.i4.4
    IL_0052: ldc.i4.1
    IL_0053: ldc.i4.s     54 // 0x36
    IL_0055: newobj       instance void ConsoleApp1.Triple::.ctor(int32, int32, char)
    IL_005a: stelem.ref
    IL_005b: dup
    IL_005c: ldc.i4.7
    IL_005d: ldc.i4.2
    IL_005e: ldc.i4.1
    IL_005f: ldc.i4.s     55 // 0x37
    IL_0061: newobj       instance void ConsoleApp1.Triple::.ctor(int32, int32, char)
    IL_0066: stelem.ref
    IL_0067: dup
    IL_0068: ldc.i4.8
    IL_0069: ldc.i4.7
    IL_006a: ldc.i4.0
    IL_006b: ldc.i4.s     56 // 0x38
    IL_006d: newobj       instance void ConsoleApp1.Triple::.ctor(int32, int32, char)
    IL_0072: stelem.ref
    IL_0073: dup
    IL_0074: ldc.i4.s     9 // 0x09
    IL_0076: ldc.i4.4
    IL_0077: ldc.i4.1
    IL_0078: ldc.i4.s     57 // 0x39
    IL_007a: newobj       instance void ConsoleApp1.Triple::.ctor(int32, int32, char)
    IL_007f: stelem.ref
    IL_0080: stsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
    IL_0085: ret

  } // end of method Program::.cctor
} // end of class ConsoleApp1.Program
