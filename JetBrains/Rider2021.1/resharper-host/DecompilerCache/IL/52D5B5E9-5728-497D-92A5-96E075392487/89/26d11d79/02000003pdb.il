// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52D5B5E9-5728-497D-92A5-96E075392487
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

    IL_005c: br           IL_0214
    // start of loop, entry point: IL_0214

      // [44 13 - 44 14]
      IL_0061: nop

      // [45 22 - 45 31]
      IL_0062: ldc.i4.0
      IL_0063: stloc.s      j

      IL_0065: br           IL_01fd
      // start of loop, entry point: IL_01fd

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
        IL_0081: br           IL_01f7

        // [48 21 - 48 35]
        IL_0086: ldloc.2      // s
        IL_0087: ldc.i4.s     32 // 0x20
        IL_0089: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Append(char)
        IL_008e: pop

        // [49 26 - 49 58]
        IL_008f: ldloc.1      // isFirst
        IL_0090: brfalse.s    IL_0095
        IL_0092: ldc.i4.1
        IL_0093: br.s         IL_0096
        IL_0095: ldc.i4.0
        IL_0096: stloc.s      l

        IL_0098: br           IL_01d4
        // start of loop, entry point: IL_01d4

          // [50 21 - 50 22]
          IL_009d: nop

          // [51 25 - 51 41]
          IL_009e: ldc.i4.0
          IL_009f: stloc.1      // isFirst

          // [52 25 - 52 50]
          IL_00a0: ldloc.s      j
          IL_00a2: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00a7: ldloc.s      l
          IL_00a9: ldelem.ref
          IL_00aa: ldfld        int32 ConsoleApp1.Triple::a
          IL_00af: add
          IL_00b0: stloc.s      x

          // [53 25 - 53 50]
          IL_00b2: ldloc.3      // i
          IL_00b3: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00b8: ldloc.s      l
          IL_00ba: ldelem.ref
          IL_00bb: ldfld        int32 ConsoleApp1.Triple::b
          IL_00c0: add
          IL_00c1: stloc.s      y

          // [54 25 - 54 47]
          IL_00c3: ldloc.s      x
          IL_00c5: ldsfld       int32 ConsoleApp1.Program::m
          IL_00ca: bge.s        IL_00da
          IL_00cc: ldloc.s      y
          IL_00ce: ldsfld       int32 ConsoleApp1.Program::k
          IL_00d3: clt
          IL_00d5: ldc.i4.0
          IL_00d6: ceq
          IL_00d8: br.s         IL_00db
          IL_00da: ldc.i4.1
          IL_00db: stloc.s      V_9

          IL_00dd: ldloc.s      V_9
          IL_00df: brfalse.s    IL_00e6

          // [55 29 - 55 38]
          IL_00e1: br           IL_01ce

          // [56 25 - 56 56]
          IL_00e6: ldloc.2      // s
          IL_00e7: ldloc.2      // s
          IL_00e8: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_00ed: ldc.i4.1
          IL_00ee: sub
          IL_00ef: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00f4: ldloc.s      l
          IL_00f6: ldelem.ref
          IL_00f7: ldfld        char ConsoleApp1.Triple::c
          IL_00fc: callvirt     instance void [System.Runtime]System.Text.StringBuilder::set_Chars(int32, char)
          IL_0101: nop

          // [57 25 - 57 49]
          IL_0102: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0107: ldloc.s      x
          IL_0109: ldloc.s      y
          IL_010b: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0110: ldnull
          IL_0111: cgt.un
          IL_0113: stloc.s      V_10

          IL_0115: ldloc.s      V_10
          IL_0117: brfalse      IL_01b7

          // [58 25 - 58 26]
          IL_011c: nop

          // [59 29 - 59 63]
          IL_011d: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0122: ldloc.s      x
          IL_0124: ldloc.s      y
          IL_0126: call         instance string string[0...,0...]::Get(int32, int32)
          IL_012b: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_0130: ldloc.2      // s
          IL_0131: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_0136: cgt
          IL_0138: stloc.s      V_11

          IL_013a: ldloc.s      V_11
          IL_013c: brfalse.s    IL_0156

          // [60 29 - 60 30]
          IL_013e: nop

          // [61 33 - 61 60]
          IL_013f: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0144: ldloc.s      x
          IL_0146: ldloc.s      y
          IL_0148: ldloc.2      // s
          IL_0149: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_014e: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [62 29 - 62 30]
          IL_0153: nop

          IL_0154: br.s         IL_01b4

          // [63 34 - 63 69]
          IL_0156: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_015b: ldloc.s      x
          IL_015d: ldloc.s      y
          IL_015f: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0164: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_0169: ldloc.2      // s
          IL_016a: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_016f: ceq
          IL_0171: stloc.s      V_12

          IL_0173: ldloc.s      V_12
          IL_0175: brfalse.s    IL_01b4

          // [64 29 - 64 30]
          IL_0177: nop

          // [65 33 - 65 91]
          IL_0178: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_017d: ldloc.s      x
          IL_017f: ldloc.s      y
          IL_0181: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0186: ldloc.2      // s
          IL_0187: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_018c: call         int32 [System.Runtime]System.String::CompareOrdinal(string, string)
          IL_0191: ldc.i4.0
          IL_0192: clt
          IL_0194: ldc.i4.0
          IL_0195: ceq
          IL_0197: stloc.s      V_13

          IL_0199: ldloc.s      V_13
          IL_019b: brfalse.s    IL_01b3

          // [66 33 - 66 34]
          IL_019d: nop

          // [67 37 - 67 64]
          IL_019e: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_01a3: ldloc.s      x
          IL_01a5: ldloc.s      y
          IL_01a7: ldloc.2      // s
          IL_01a8: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_01ad: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [68 33 - 68 34]
          IL_01b2: nop

          // [69 29 - 69 30]
          IL_01b3: nop

          // [70 25 - 70 26]
          IL_01b4: nop

          IL_01b5: br.s         IL_01cd

          // [72 25 - 72 26]
          IL_01b7: nop

          // [73 29 - 73 56]
          IL_01b8: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_01bd: ldloc.s      x
          IL_01bf: ldloc.s      y
          IL_01c1: ldloc.2      // s
          IL_01c2: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_01c7: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [74 25 - 74 26]
          IL_01cc: nop

          // [75 21 - 75 22]
          IL_01cd: nop

          // [49 80 - 49 83]
          IL_01ce: ldloc.s      l
          IL_01d0: ldc.i4.1
          IL_01d1: add
          IL_01d2: stloc.s      l

          // [49 60 - 49 78]
          IL_01d4: ldloc.s      l
          IL_01d6: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_01db: ldlen
          IL_01dc: conv.i4
          IL_01dd: clt
          IL_01df: stloc.s      V_14

          IL_01e1: ldloc.s      V_14
          IL_01e3: brtrue       IL_009d
        // end of loop

        // [77 21 - 77 43]
        IL_01e8: ldloc.2      // s
        IL_01e9: ldloc.2      // s
        IL_01ea: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
        IL_01ef: ldc.i4.1
        IL_01f0: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Remove(int32, int32)
        IL_01f5: pop

        // [78 17 - 78 18]
        IL_01f6: nop

        // [45 40 - 45 43]
        IL_01f7: ldloc.s      j
        IL_01f9: ldc.i4.1
        IL_01fa: add
        IL_01fb: stloc.s      j

        // [45 33 - 45 38]
        IL_01fd: ldloc.s      j
        IL_01ff: ldsfld       int32 ConsoleApp1.Program::m
        IL_0204: clt
        IL_0206: stloc.s      V_15

        IL_0208: ldloc.s      V_15
        IL_020a: brtrue       IL_006a
      // end of loop

      // [79 13 - 79 14]
      IL_020f: nop

      // [43 36 - 43 39]
      IL_0210: ldloc.3      // i
      IL_0211: ldc.i4.1
      IL_0212: add
      IL_0213: stloc.3      // i

      // [43 29 - 43 34]
      IL_0214: ldloc.3      // i
      IL_0215: ldsfld       int32 ConsoleApp1.Program::k
      IL_021a: clt
      IL_021c: stloc.s      V_16

      IL_021e: ldloc.s      V_16
      IL_0220: brtrue       IL_0061
    // end of loop

    // [81 13 - 81 92]
    IL_0225: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_022a: ldsfld       int32 ConsoleApp1.Program::m
    IL_022f: ldc.i4.1
    IL_0230: sub
    IL_0231: ldsfld       int32 ConsoleApp1.Program::k
    IL_0236: ldc.i4.1
    IL_0237: sub
    IL_0238: call         instance string string[0...,0...]::Get(int32, int32)
    IL_023d: brfalse.s    IL_0259
    IL_023f: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0244: ldsfld       int32 ConsoleApp1.Program::m
    IL_0249: ldc.i4.1
    IL_024a: sub
    IL_024b: ldsfld       int32 ConsoleApp1.Program::k
    IL_0250: ldc.i4.1
    IL_0251: sub
    IL_0252: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0257: br.s         IL_025e
    IL_0259: ldstr        "Wrong"
    IL_025e: call         void [System.Console]System.Console::WriteLine(string)
    IL_0263: nop

    // [82 9 - 82 10]
    IL_0264: ret

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
