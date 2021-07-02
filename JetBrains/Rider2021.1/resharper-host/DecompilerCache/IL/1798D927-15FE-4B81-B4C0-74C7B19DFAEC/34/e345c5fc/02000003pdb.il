// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1798D927-15FE-4B81-B4C0-74C7B19DFAEC
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

    IL_004b: br           IL_020a
    // start of loop, entry point: IL_020a

      // [43 13 - 43 14]
      IL_0050: nop

      // [44 22 - 44 31]
      IL_0051: ldc.i4.0
      IL_0052: stloc.s      j

      IL_0054: br           IL_01f3
      // start of loop, entry point: IL_01f3

        // [45 17 - 45 18]
        IL_0059: nop

        // [46 21 - 46 45]
        IL_005a: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
        IL_005f: ldsfld       int32 ConsoleApp1.Program::m
        IL_0064: ldsfld       int32 ConsoleApp1.Program::k
        IL_0069: call         instance string string[0...,0...]::Get(int32, int32)
        IL_006e: ldnull
        IL_006f: ceq
        IL_0071: stloc.s      V_5

        IL_0073: ldloc.s      V_5
        IL_0075: brfalse.s    IL_007c

        // [46 46 - 46 55]
        IL_0077: br           IL_01ed

        // [47 21 - 47 35]
        IL_007c: ldloc.2      // s
        IL_007d: ldc.i4.s     32 // 0x20
        IL_007f: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Append(char)
        IL_0084: pop

        // [48 26 - 48 58]
        IL_0085: ldloc.1      // isFirst
        IL_0086: brfalse.s    IL_008b
        IL_0088: ldc.i4.1
        IL_0089: br.s         IL_008c
        IL_008b: ldc.i4.0
        IL_008c: stloc.s      l

        IL_008e: br           IL_01ca
        // start of loop, entry point: IL_01ca

          // [49 21 - 49 22]
          IL_0093: nop

          // [50 25 - 50 41]
          IL_0094: ldc.i4.0
          IL_0095: stloc.1      // isFirst

          // [51 25 - 51 50]
          IL_0096: ldloc.3      // i
          IL_0097: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_009c: ldloc.s      l
          IL_009e: ldelem.ref
          IL_009f: ldfld        int32 ConsoleApp1.Triple::a
          IL_00a4: add
          IL_00a5: stloc.s      x

          // [52 25 - 52 50]
          IL_00a7: ldloc.s      j
          IL_00a9: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00ae: ldloc.s      l
          IL_00b0: ldelem.ref
          IL_00b1: ldfld        int32 ConsoleApp1.Triple::b
          IL_00b6: add
          IL_00b7: stloc.s      y

          // [53 25 - 53 47]
          IL_00b9: ldloc.s      x
          IL_00bb: ldsfld       int32 ConsoleApp1.Program::m
          IL_00c0: bge.s        IL_00d0
          IL_00c2: ldloc.s      y
          IL_00c4: ldsfld       int32 ConsoleApp1.Program::k
          IL_00c9: clt
          IL_00cb: ldc.i4.0
          IL_00cc: ceq
          IL_00ce: br.s         IL_00d1
          IL_00d0: ldc.i4.1
          IL_00d1: stloc.s      V_9

          IL_00d3: ldloc.s      V_9
          IL_00d5: brfalse.s    IL_00dc

          // [54 29 - 54 38]
          IL_00d7: br           IL_01c4

          // [55 25 - 55 56]
          IL_00dc: ldloc.2      // s
          IL_00dd: ldloc.2      // s
          IL_00de: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_00e3: ldc.i4.1
          IL_00e4: sub
          IL_00e5: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00ea: ldloc.s      l
          IL_00ec: ldelem.ref
          IL_00ed: ldfld        char ConsoleApp1.Triple::c
          IL_00f2: callvirt     instance void [System.Runtime]System.Text.StringBuilder::set_Chars(int32, char)
          IL_00f7: nop

          // [56 25 - 56 49]
          IL_00f8: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_00fd: ldloc.s      x
          IL_00ff: ldloc.s      y
          IL_0101: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0106: ldnull
          IL_0107: cgt.un
          IL_0109: stloc.s      V_10

          IL_010b: ldloc.s      V_10
          IL_010d: brfalse      IL_01ad

          // [57 25 - 57 26]
          IL_0112: nop

          // [58 29 - 58 63]
          IL_0113: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0118: ldloc.s      x
          IL_011a: ldloc.s      y
          IL_011c: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0121: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_0126: ldloc.2      // s
          IL_0127: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_012c: cgt
          IL_012e: stloc.s      V_11

          IL_0130: ldloc.s      V_11
          IL_0132: brfalse.s    IL_014c

          // [59 29 - 59 30]
          IL_0134: nop

          // [60 33 - 60 60]
          IL_0135: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_013a: ldloc.s      x
          IL_013c: ldloc.s      y
          IL_013e: ldloc.2      // s
          IL_013f: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_0144: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [61 29 - 61 30]
          IL_0149: nop

          IL_014a: br.s         IL_01aa

          // [62 34 - 62 69]
          IL_014c: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0151: ldloc.s      x
          IL_0153: ldloc.s      y
          IL_0155: call         instance string string[0...,0...]::Get(int32, int32)
          IL_015a: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_015f: ldloc.2      // s
          IL_0160: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_0165: ceq
          IL_0167: stloc.s      V_12

          IL_0169: ldloc.s      V_12
          IL_016b: brfalse.s    IL_01aa

          // [63 29 - 63 30]
          IL_016d: nop

          // [64 33 - 64 91]
          IL_016e: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0173: ldloc.s      x
          IL_0175: ldloc.s      y
          IL_0177: call         instance string string[0...,0...]::Get(int32, int32)
          IL_017c: ldloc.2      // s
          IL_017d: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_0182: call         int32 [System.Runtime]System.String::CompareOrdinal(string, string)
          IL_0187: ldc.i4.0
          IL_0188: clt
          IL_018a: ldc.i4.0
          IL_018b: ceq
          IL_018d: stloc.s      V_13

          IL_018f: ldloc.s      V_13
          IL_0191: brfalse.s    IL_01a9

          // [65 33 - 65 34]
          IL_0193: nop

          // [66 37 - 66 64]
          IL_0194: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0199: ldloc.s      x
          IL_019b: ldloc.s      y
          IL_019d: ldloc.2      // s
          IL_019e: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_01a3: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [67 33 - 67 34]
          IL_01a8: nop

          // [68 29 - 68 30]
          IL_01a9: nop

          // [69 25 - 69 26]
          IL_01aa: nop

          IL_01ab: br.s         IL_01c3

          // [71 25 - 71 26]
          IL_01ad: nop

          // [72 29 - 72 56]
          IL_01ae: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_01b3: ldloc.s      x
          IL_01b5: ldloc.s      y
          IL_01b7: ldloc.2      // s
          IL_01b8: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_01bd: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [73 25 - 73 26]
          IL_01c2: nop

          // [74 21 - 74 22]
          IL_01c3: nop

          // [48 80 - 48 83]
          IL_01c4: ldloc.s      l
          IL_01c6: ldc.i4.1
          IL_01c7: add
          IL_01c8: stloc.s      l

          // [48 60 - 48 78]
          IL_01ca: ldloc.s      l
          IL_01cc: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_01d1: ldlen
          IL_01d2: conv.i4
          IL_01d3: clt
          IL_01d5: stloc.s      V_14

          IL_01d7: ldloc.s      V_14
          IL_01d9: brtrue       IL_0093
        // end of loop

        // [76 21 - 76 43]
        IL_01de: ldloc.2      // s
        IL_01df: ldloc.2      // s
        IL_01e0: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
        IL_01e5: ldc.i4.1
        IL_01e6: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Remove(int32, int32)
        IL_01eb: pop

        // [77 17 - 77 18]
        IL_01ec: nop

        // [44 40 - 44 43]
        IL_01ed: ldloc.s      j
        IL_01ef: ldc.i4.1
        IL_01f0: add
        IL_01f1: stloc.s      j

        // [44 33 - 44 38]
        IL_01f3: ldloc.s      j
        IL_01f5: ldsfld       int32 ConsoleApp1.Program::m
        IL_01fa: clt
        IL_01fc: stloc.s      V_15

        IL_01fe: ldloc.s      V_15
        IL_0200: brtrue       IL_0059
      // end of loop

      // [78 13 - 78 14]
      IL_0205: nop

      // [42 36 - 42 39]
      IL_0206: ldloc.3      // i
      IL_0207: ldc.i4.1
      IL_0208: add
      IL_0209: stloc.3      // i

      // [42 29 - 42 34]
      IL_020a: ldloc.3      // i
      IL_020b: ldsfld       int32 ConsoleApp1.Program::k
      IL_0210: clt
      IL_0212: stloc.s      V_16

      IL_0214: ldloc.s      V_16
      IL_0216: brtrue       IL_0050
    // end of loop

    // [80 13 - 80 92]
    IL_021b: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0220: ldsfld       int32 ConsoleApp1.Program::m
    IL_0225: ldc.i4.1
    IL_0226: sub
    IL_0227: ldsfld       int32 ConsoleApp1.Program::k
    IL_022c: ldc.i4.1
    IL_022d: sub
    IL_022e: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0233: brfalse.s    IL_024f
    IL_0235: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_023a: ldsfld       int32 ConsoleApp1.Program::m
    IL_023f: ldc.i4.1
    IL_0240: sub
    IL_0241: ldsfld       int32 ConsoleApp1.Program::k
    IL_0246: ldc.i4.1
    IL_0247: sub
    IL_0248: call         instance string string[0...,0...]::Get(int32, int32)
    IL_024d: br.s         IL_0254
    IL_024f: ldstr        "Wrong"
    IL_0254: call         void [System.Console]System.Console::WriteLine(string)
    IL_0259: nop

    // [81 9 - 81 10]
    IL_025a: ret

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
