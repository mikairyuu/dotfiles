// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0CB89FD2-0476-4985-9773-3A9704200652
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

    // [40 13 - 40 32]
    IL_0041: ldc.i4.1
    IL_0042: stloc.1      // isFirst

    // [41 13 - 41 41]
    IL_0043: newobj       instance void [System.Runtime]System.Text.StringBuilder::.ctor()
    IL_0048: stloc.2      // s

    // [42 18 - 42 27]
    IL_0049: ldc.i4.0
    IL_004a: stloc.3      // i

    IL_004b: br           IL_0203
    // start of loop, entry point: IL_0203

      // [43 13 - 43 14]
      IL_0050: nop

      // [44 22 - 44 31]
      IL_0051: ldc.i4.0
      IL_0052: stloc.s      j

      IL_0054: br           IL_01ec
      // start of loop, entry point: IL_01ec

        // [45 17 - 45 18]
        IL_0059: nop

        // [46 21 - 46 45]
        IL_005a: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
        IL_005f: ldloc.3      // i
        IL_0060: ldloc.s      j
        IL_0062: call         instance string string[0...,0...]::Get(int32, int32)
        IL_0067: ldnull
        IL_0068: ceq
        IL_006a: stloc.s      V_5

        IL_006c: ldloc.s      V_5
        IL_006e: brfalse.s    IL_0075

        // [46 46 - 46 55]
        IL_0070: br           IL_01e6

        // [47 21 - 47 35]
        IL_0075: ldloc.2      // s
        IL_0076: ldc.i4.s     32 // 0x20
        IL_0078: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Append(char)
        IL_007d: pop

        // [48 26 - 48 58]
        IL_007e: ldloc.1      // isFirst
        IL_007f: brfalse.s    IL_0084
        IL_0081: ldc.i4.1
        IL_0082: br.s         IL_0085
        IL_0084: ldc.i4.0
        IL_0085: stloc.s      l

        IL_0087: br           IL_01c3
        // start of loop, entry point: IL_01c3

          // [49 21 - 49 22]
          IL_008c: nop

          // [50 25 - 50 41]
          IL_008d: ldc.i4.0
          IL_008e: stloc.1      // isFirst

          // [51 25 - 51 50]
          IL_008f: ldloc.3      // i
          IL_0090: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_0095: ldloc.s      l
          IL_0097: ldelem.ref
          IL_0098: ldfld        int32 ConsoleApp1.Triple::a
          IL_009d: add
          IL_009e: stloc.s      x

          // [52 25 - 52 50]
          IL_00a0: ldloc.s      j
          IL_00a2: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00a7: ldloc.s      l
          IL_00a9: ldelem.ref
          IL_00aa: ldfld        int32 ConsoleApp1.Triple::b
          IL_00af: add
          IL_00b0: stloc.s      y

          // [53 25 - 53 47]
          IL_00b2: ldloc.s      x
          IL_00b4: ldsfld       int32 ConsoleApp1.Program::m
          IL_00b9: bge.s        IL_00c9
          IL_00bb: ldloc.s      y
          IL_00bd: ldsfld       int32 ConsoleApp1.Program::k
          IL_00c2: clt
          IL_00c4: ldc.i4.0
          IL_00c5: ceq
          IL_00c7: br.s         IL_00ca
          IL_00c9: ldc.i4.1
          IL_00ca: stloc.s      V_9

          IL_00cc: ldloc.s      V_9
          IL_00ce: brfalse.s    IL_00d5

          // [54 29 - 54 38]
          IL_00d0: br           IL_01bd

          // [55 25 - 55 56]
          IL_00d5: ldloc.2      // s
          IL_00d6: ldloc.2      // s
          IL_00d7: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_00dc: ldc.i4.1
          IL_00dd: sub
          IL_00de: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00e3: ldloc.s      l
          IL_00e5: ldelem.ref
          IL_00e6: ldfld        char ConsoleApp1.Triple::c
          IL_00eb: callvirt     instance void [System.Runtime]System.Text.StringBuilder::set_Chars(int32, char)
          IL_00f0: nop

          // [56 25 - 56 49]
          IL_00f1: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_00f6: ldloc.s      x
          IL_00f8: ldloc.s      y
          IL_00fa: call         instance string string[0...,0...]::Get(int32, int32)
          IL_00ff: ldnull
          IL_0100: cgt.un
          IL_0102: stloc.s      V_10

          IL_0104: ldloc.s      V_10
          IL_0106: brfalse      IL_01a6

          // [57 25 - 57 26]
          IL_010b: nop

          // [58 29 - 58 63]
          IL_010c: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0111: ldloc.s      x
          IL_0113: ldloc.s      y
          IL_0115: call         instance string string[0...,0...]::Get(int32, int32)
          IL_011a: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_011f: ldloc.2      // s
          IL_0120: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_0125: cgt
          IL_0127: stloc.s      V_11

          IL_0129: ldloc.s      V_11
          IL_012b: brfalse.s    IL_0145

          // [59 29 - 59 30]
          IL_012d: nop

          // [60 33 - 60 60]
          IL_012e: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0133: ldloc.s      x
          IL_0135: ldloc.s      y
          IL_0137: ldloc.2      // s
          IL_0138: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_013d: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [61 29 - 61 30]
          IL_0142: nop

          IL_0143: br.s         IL_01a3

          // [62 34 - 62 69]
          IL_0145: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_014a: ldloc.s      x
          IL_014c: ldloc.s      y
          IL_014e: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0153: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_0158: ldloc.2      // s
          IL_0159: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_015e: ceq
          IL_0160: stloc.s      V_12

          IL_0162: ldloc.s      V_12
          IL_0164: brfalse.s    IL_01a3

          // [63 29 - 63 30]
          IL_0166: nop

          // [64 33 - 64 91]
          IL_0167: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_016c: ldloc.s      x
          IL_016e: ldloc.s      y
          IL_0170: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0175: ldloc.2      // s
          IL_0176: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_017b: call         int32 [System.Runtime]System.String::CompareOrdinal(string, string)
          IL_0180: ldc.i4.0
          IL_0181: clt
          IL_0183: ldc.i4.0
          IL_0184: ceq
          IL_0186: stloc.s      V_13

          IL_0188: ldloc.s      V_13
          IL_018a: brfalse.s    IL_01a2

          // [65 33 - 65 34]
          IL_018c: nop

          // [66 37 - 66 64]
          IL_018d: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0192: ldloc.s      x
          IL_0194: ldloc.s      y
          IL_0196: ldloc.2      // s
          IL_0197: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_019c: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [67 33 - 67 34]
          IL_01a1: nop

          // [68 29 - 68 30]
          IL_01a2: nop

          // [69 25 - 69 26]
          IL_01a3: nop

          IL_01a4: br.s         IL_01bc

          // [71 25 - 71 26]
          IL_01a6: nop

          // [72 29 - 72 56]
          IL_01a7: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_01ac: ldloc.s      x
          IL_01ae: ldloc.s      y
          IL_01b0: ldloc.2      // s
          IL_01b1: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_01b6: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [73 25 - 73 26]
          IL_01bb: nop

          // [74 21 - 74 22]
          IL_01bc: nop

          // [48 80 - 48 83]
          IL_01bd: ldloc.s      l
          IL_01bf: ldc.i4.1
          IL_01c0: add
          IL_01c1: stloc.s      l

          // [48 60 - 48 78]
          IL_01c3: ldloc.s      l
          IL_01c5: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_01ca: ldlen
          IL_01cb: conv.i4
          IL_01cc: clt
          IL_01ce: stloc.s      V_14

          IL_01d0: ldloc.s      V_14
          IL_01d2: brtrue       IL_008c
        // end of loop

        // [76 21 - 76 43]
        IL_01d7: ldloc.2      // s
        IL_01d8: ldloc.2      // s
        IL_01d9: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
        IL_01de: ldc.i4.1
        IL_01df: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Remove(int32, int32)
        IL_01e4: pop

        // [77 17 - 77 18]
        IL_01e5: nop

        // [44 40 - 44 43]
        IL_01e6: ldloc.s      j
        IL_01e8: ldc.i4.1
        IL_01e9: add
        IL_01ea: stloc.s      j

        // [44 33 - 44 38]
        IL_01ec: ldloc.s      j
        IL_01ee: ldsfld       int32 ConsoleApp1.Program::m
        IL_01f3: clt
        IL_01f5: stloc.s      V_15

        IL_01f7: ldloc.s      V_15
        IL_01f9: brtrue       IL_0059
      // end of loop

      // [78 13 - 78 14]
      IL_01fe: nop

      // [42 36 - 42 39]
      IL_01ff: ldloc.3      // i
      IL_0200: ldc.i4.1
      IL_0201: add
      IL_0202: stloc.3      // i

      // [42 29 - 42 34]
      IL_0203: ldloc.3      // i
      IL_0204: ldsfld       int32 ConsoleApp1.Program::k
      IL_0209: clt
      IL_020b: stloc.s      V_16

      IL_020d: ldloc.s      V_16
      IL_020f: brtrue       IL_0050
    // end of loop

    // [80 13 - 80 92]
    IL_0214: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0219: ldsfld       int32 ConsoleApp1.Program::m
    IL_021e: ldc.i4.1
    IL_021f: sub
    IL_0220: ldsfld       int32 ConsoleApp1.Program::k
    IL_0225: ldc.i4.1
    IL_0226: sub
    IL_0227: call         instance string string[0...,0...]::Get(int32, int32)
    IL_022c: brfalse.s    IL_0248
    IL_022e: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0233: ldsfld       int32 ConsoleApp1.Program::m
    IL_0238: ldc.i4.1
    IL_0239: sub
    IL_023a: ldsfld       int32 ConsoleApp1.Program::k
    IL_023f: ldc.i4.1
    IL_0240: sub
    IL_0241: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0246: br.s         IL_024d
    IL_0248: ldstr        "Wrong"
    IL_024d: call         void [System.Console]System.Console::WriteLine(string)
    IL_0252: nop

    // [81 9 - 81 10]
    IL_0253: ret

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
