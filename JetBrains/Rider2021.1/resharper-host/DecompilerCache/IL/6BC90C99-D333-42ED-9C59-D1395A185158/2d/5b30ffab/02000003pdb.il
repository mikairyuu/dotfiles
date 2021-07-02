// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6BC90C99-D333-42ED-9C59-D1395A185158
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
      [2] int32 x,
      [3] int32 y,
      [4] class [System.Runtime]System.Text.StringBuilder s,
      [5] int32 i,
      [6] int32 j,
      [7] bool V_7,
      [8] int32 l,
      [9] bool V_9,
      [10] bool V_10,
      [11] bool V_11,
      [12] bool V_12,
      [13] bool V_13,
      [14] bool V_14,
      [15] bool V_15,
      [16] bool V_16
    )

    // [36 9 - 36 10]
    IL_0000: nop

    // [37 13 - 37 55]
    IL_0001: call         string [System.Console]System.Console::ReadLine()
    IL_0006: ldc.i4.s     32 // 0x20
    IL_0008: ldc.i4.0
    IL_0009: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_000e: stloc.0      // input

    // [38 13 - 38 41]
    IL_000f: ldloc.0      // input
    IL_0010: ldc.i4.0
    IL_0011: ldelem.ref
    IL_0012: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0017: ldc.i4.1
    IL_0018: add
    IL_0019: stsfld       int32 ConsoleApp1.Program::m

    // [39 13 - 39 41]
    IL_001e: ldloc.0      // input
    IL_001f: ldc.i4.1
    IL_0020: ldelem.ref
    IL_0021: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0026: ldc.i4.1
    IL_0027: add
    IL_0028: stsfld       int32 ConsoleApp1.Program::k

    // [40 13 - 40 38]
    IL_002d: ldsfld       int32 ConsoleApp1.Program::m
    IL_0032: ldsfld       int32 ConsoleApp1.Program::k
    IL_0037: newobj       instance void string[0...,0...]::.ctor(int32, int32)
    IL_003c: stsfld       string[0...,0...] ConsoleApp1.Program::'field'

    // [41 13 - 41 32]
    IL_0041: ldc.i4.1
    IL_0042: stloc.1      // isFirst

    // [43 13 - 43 41]
    IL_0043: newobj       instance void [System.Runtime]System.Text.StringBuilder::.ctor()
    IL_0048: stloc.s      s

    // [44 18 - 44 27]
    IL_004a: ldc.i4.0
    IL_004b: stloc.s      i

    IL_004d: br           IL_01e5
    // start of loop, entry point: IL_01e5

      // [45 13 - 45 14]
      IL_0052: nop

      // [46 22 - 46 31]
      IL_0053: ldc.i4.0
      IL_0054: stloc.s      j

      IL_0056: br           IL_01cc
      // start of loop, entry point: IL_01cc

        // [47 17 - 47 18]
        IL_005b: nop

        // [48 21 - 48 45]
        IL_005c: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
        IL_0061: ldsfld       int32 ConsoleApp1.Program::m
        IL_0066: ldsfld       int32 ConsoleApp1.Program::k
        IL_006b: call         instance string string[0...,0...]::Get(int32, int32)
        IL_0070: ldnull
        IL_0071: ceq
        IL_0073: stloc.s      V_7

        IL_0075: ldloc.s      V_7
        IL_0077: brfalse.s    IL_007e

        // [48 46 - 48 55]
        IL_0079: br           IL_01c6

        // [49 26 - 49 58]
        IL_007e: ldloc.1      // isFirst
        IL_007f: brfalse.s    IL_0084
        IL_0081: ldc.i4.1
        IL_0082: br.s         IL_0085
        IL_0084: ldc.i4.0
        IL_0085: stloc.s      l

        IL_0087: br           IL_01b1
        // start of loop, entry point: IL_01b1

          // [50 21 - 50 22]
          IL_008c: nop

          // [51 25 - 51 41]
          IL_008d: ldc.i4.0
          IL_008e: stloc.1      // isFirst

          // [52 25 - 52 46]
          IL_008f: ldloc.s      i
          IL_0091: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_0096: ldloc.s      l
          IL_0098: ldelem.ref
          IL_0099: ldfld        int32 ConsoleApp1.Triple::a
          IL_009e: add
          IL_009f: stloc.2      // x

          // [53 25 - 53 46]
          IL_00a0: ldloc.s      j
          IL_00a2: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00a7: ldloc.s      l
          IL_00a9: ldelem.ref
          IL_00aa: ldfld        int32 ConsoleApp1.Triple::b
          IL_00af: add
          IL_00b0: stloc.3      // y

          // [54 25 - 54 47]
          IL_00b1: ldloc.2      // x
          IL_00b2: ldsfld       int32 ConsoleApp1.Program::m
          IL_00b7: bge.s        IL_00c6
          IL_00b9: ldloc.3      // y
          IL_00ba: ldsfld       int32 ConsoleApp1.Program::k
          IL_00bf: clt
          IL_00c1: ldc.i4.0
          IL_00c2: ceq
          IL_00c4: br.s         IL_00c7
          IL_00c6: ldc.i4.1
          IL_00c7: stloc.s      V_9

          IL_00c9: ldloc.s      V_9
          IL_00cb: brfalse.s    IL_00d2

          // [55 29 - 55 38]
          IL_00cd: br           IL_01ab

          // [56 25 - 56 48]
          IL_00d2: ldloc.s      s
          IL_00d4: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00d9: ldloc.s      l
          IL_00db: ldelem.ref
          IL_00dc: ldfld        int32 ConsoleApp1.Triple::c
          IL_00e1: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Append(int32)
          IL_00e6: pop

          // [57 25 - 57 49]
          IL_00e7: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_00ec: ldloc.2      // x
          IL_00ed: ldloc.3      // y
          IL_00ee: call         instance string string[0...,0...]::Get(int32, int32)
          IL_00f3: ldnull
          IL_00f4: cgt.un
          IL_00f6: stloc.s      V_10

          IL_00f8: ldloc.s      V_10
          IL_00fa: brfalse      IL_0195

          // [58 25 - 58 26]
          IL_00ff: nop

          // [59 29 - 59 63]
          IL_0100: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0105: ldloc.2      // x
          IL_0106: ldloc.3      // y
          IL_0107: call         instance string string[0...,0...]::Get(int32, int32)
          IL_010c: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_0111: ldloc.s      s
          IL_0113: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_0118: cgt
          IL_011a: stloc.s      V_11

          IL_011c: ldloc.s      V_11
          IL_011e: brfalse.s    IL_0137

          // [60 29 - 60 30]
          IL_0120: nop

          // [61 33 - 61 60]
          IL_0121: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0126: ldloc.2      // x
          IL_0127: ldloc.3      // y
          IL_0128: ldloc.s      s
          IL_012a: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_012f: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [62 29 - 62 30]
          IL_0134: nop

          IL_0135: br.s         IL_0192

          // [63 34 - 63 69]
          IL_0137: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_013c: ldloc.2      // x
          IL_013d: ldloc.3      // y
          IL_013e: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0143: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_0148: ldloc.s      s
          IL_014a: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_014f: ceq
          IL_0151: stloc.s      V_12

          IL_0153: ldloc.s      V_12
          IL_0155: brfalse.s    IL_0192

          // [64 29 - 64 30]
          IL_0157: nop

          // [65 33 - 65 91]
          IL_0158: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_015d: ldloc.2      // x
          IL_015e: ldloc.3      // y
          IL_015f: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0164: ldloc.s      s
          IL_0166: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_016b: call         int32 [System.Runtime]System.String::CompareOrdinal(string, string)
          IL_0170: ldc.i4.0
          IL_0171: clt
          IL_0173: ldc.i4.0
          IL_0174: ceq
          IL_0176: stloc.s      V_13

          IL_0178: ldloc.s      V_13
          IL_017a: brfalse.s    IL_0191

          // [66 33 - 66 34]
          IL_017c: nop

          // [67 37 - 67 64]
          IL_017d: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0182: ldloc.2      // x
          IL_0183: ldloc.3      // y
          IL_0184: ldloc.s      s
          IL_0186: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_018b: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [68 33 - 68 34]
          IL_0190: nop

          // [69 29 - 69 30]
          IL_0191: nop

          // [70 25 - 70 26]
          IL_0192: nop

          IL_0193: br.s         IL_01aa

          // [72 25 - 72 26]
          IL_0195: nop

          // [73 29 - 73 56]
          IL_0196: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_019b: ldloc.2      // x
          IL_019c: ldloc.3      // y
          IL_019d: ldloc.s      s
          IL_019f: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_01a4: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [74 25 - 74 26]
          IL_01a9: nop

          // [75 21 - 75 22]
          IL_01aa: nop

          // [49 80 - 49 83]
          IL_01ab: ldloc.s      l
          IL_01ad: ldc.i4.1
          IL_01ae: add
          IL_01af: stloc.s      l

          // [49 60 - 49 78]
          IL_01b1: ldloc.s      l
          IL_01b3: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_01b8: ldlen
          IL_01b9: conv.i4
          IL_01ba: clt
          IL_01bc: stloc.s      V_14

          IL_01be: ldloc.s      V_14
          IL_01c0: brtrue       IL_008c
        // end of loop

        // [76 17 - 76 18]
        IL_01c5: nop

        // [46 40 - 46 43]
        IL_01c6: ldloc.s      j
        IL_01c8: ldc.i4.1
        IL_01c9: add
        IL_01ca: stloc.s      j

        // [46 33 - 46 38]
        IL_01cc: ldloc.s      j
        IL_01ce: ldsfld       int32 ConsoleApp1.Program::m
        IL_01d3: clt
        IL_01d5: stloc.s      V_15

        IL_01d7: ldloc.s      V_15
        IL_01d9: brtrue       IL_005b
      // end of loop

      // [77 13 - 77 14]
      IL_01de: nop

      // [44 36 - 44 39]
      IL_01df: ldloc.s      i
      IL_01e1: ldc.i4.1
      IL_01e2: add
      IL_01e3: stloc.s      i

      // [44 29 - 44 34]
      IL_01e5: ldloc.s      i
      IL_01e7: ldsfld       int32 ConsoleApp1.Program::k
      IL_01ec: clt
      IL_01ee: stloc.s      V_16

      IL_01f0: ldloc.s      V_16
      IL_01f2: brtrue       IL_0052
    // end of loop

    // [78 13 - 78 92]
    IL_01f7: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_01fc: ldsfld       int32 ConsoleApp1.Program::m
    IL_0201: ldc.i4.1
    IL_0202: sub
    IL_0203: ldsfld       int32 ConsoleApp1.Program::k
    IL_0208: ldc.i4.1
    IL_0209: sub
    IL_020a: call         instance string string[0...,0...]::Get(int32, int32)
    IL_020f: brfalse.s    IL_022b
    IL_0211: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0216: ldsfld       int32 ConsoleApp1.Program::m
    IL_021b: ldc.i4.1
    IL_021c: sub
    IL_021d: ldsfld       int32 ConsoleApp1.Program::k
    IL_0222: ldc.i4.1
    IL_0223: sub
    IL_0224: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0229: br.s         IL_0230
    IL_022b: ldstr        "Wrong"
    IL_0230: call         void [System.Console]System.Console::WriteLine(string)
    IL_0235: nop

    // [79 9 - 79 10]
    IL_0236: ret

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

    // [25 9 - 30 11]
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
