// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3033FCB-C6E1-46A7-A9D8-09DE23862FF6
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

    // [42 13 - 42 41]
    IL_0043: newobj       instance void [System.Runtime]System.Text.StringBuilder::.ctor()
    IL_0048: stloc.s      s

    // [43 18 - 43 27]
    IL_004a: ldc.i4.0
    IL_004b: stloc.s      i

    IL_004d: br           IL_01ea
    // start of loop, entry point: IL_01ea

      // [44 13 - 44 14]
      IL_0052: nop

      // [45 22 - 45 31]
      IL_0053: ldc.i4.0
      IL_0054: stloc.s      j

      IL_0056: br           IL_01d1
      // start of loop, entry point: IL_01d1

        // [46 17 - 46 18]
        IL_005b: nop

        // [47 21 - 47 45]
        IL_005c: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
        IL_0061: ldsfld       int32 ConsoleApp1.Program::m
        IL_0066: ldsfld       int32 ConsoleApp1.Program::k
        IL_006b: call         instance string string[0...,0...]::Get(int32, int32)
        IL_0070: ldnull
        IL_0071: ceq
        IL_0073: stloc.s      V_7

        IL_0075: ldloc.s      V_7
        IL_0077: brfalse.s    IL_007e

        // [47 46 - 47 55]
        IL_0079: br           IL_01cb

        // [48 21 - 48 35]
        IL_007e: ldloc.s      s
        IL_0080: ldc.i4.s     32 // 0x20
        IL_0082: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Append(char)
        IL_0087: pop

        // [49 26 - 49 58]
        IL_0088: ldloc.1      // isFirst
        IL_0089: brfalse.s    IL_008e
        IL_008b: ldc.i4.1
        IL_008c: br.s         IL_008f
        IL_008e: ldc.i4.0
        IL_008f: stloc.s      l

        IL_0091: br           IL_01a6
        // start of loop, entry point: IL_01a6

          // [50 21 - 50 22]
          IL_0096: nop

          // [51 25 - 51 41]
          IL_0097: ldc.i4.0
          IL_0098: stloc.1      // isFirst

          // [52 25 - 52 46]
          IL_0099: ldloc.s      i
          IL_009b: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00a0: ldloc.s      l
          IL_00a2: ldelem.ref
          IL_00a3: ldfld        int32 ConsoleApp1.Triple::a
          IL_00a8: add
          IL_00a9: stloc.2      // x

          // [53 25 - 53 46]
          IL_00aa: ldloc.s      j
          IL_00ac: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00b1: ldloc.s      l
          IL_00b3: ldelem.ref
          IL_00b4: ldfld        int32 ConsoleApp1.Triple::b
          IL_00b9: add
          IL_00ba: stloc.3      // y

          // [54 25 - 54 47]
          IL_00bb: ldloc.2      // x
          IL_00bc: ldsfld       int32 ConsoleApp1.Program::m
          IL_00c1: bge.s        IL_00d0
          IL_00c3: ldloc.3      // y
          IL_00c4: ldsfld       int32 ConsoleApp1.Program::k
          IL_00c9: clt
          IL_00cb: ldc.i4.0
          IL_00cc: ceq
          IL_00ce: br.s         IL_00d1
          IL_00d0: ldc.i4.1
          IL_00d1: stloc.s      V_9

          IL_00d3: ldloc.s      V_9
          IL_00d5: brfalse.s    IL_00dc

          // [55 29 - 55 38]
          IL_00d7: br           IL_01a0

          // [57 25 - 57 49]
          IL_00dc: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_00e1: ldloc.2      // x
          IL_00e2: ldloc.3      // y
          IL_00e3: call         instance string string[0...,0...]::Get(int32, int32)
          IL_00e8: ldnull
          IL_00e9: cgt.un
          IL_00eb: stloc.s      V_10

          IL_00ed: ldloc.s      V_10
          IL_00ef: brfalse      IL_018a

          // [58 25 - 58 26]
          IL_00f4: nop

          // [59 29 - 59 63]
          IL_00f5: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_00fa: ldloc.2      // x
          IL_00fb: ldloc.3      // y
          IL_00fc: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0101: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_0106: ldloc.s      s
          IL_0108: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_010d: cgt
          IL_010f: stloc.s      V_11

          IL_0111: ldloc.s      V_11
          IL_0113: brfalse.s    IL_012c

          // [60 29 - 60 30]
          IL_0115: nop

          // [61 33 - 61 60]
          IL_0116: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_011b: ldloc.2      // x
          IL_011c: ldloc.3      // y
          IL_011d: ldloc.s      s
          IL_011f: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_0124: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [62 29 - 62 30]
          IL_0129: nop

          IL_012a: br.s         IL_0187

          // [63 34 - 63 69]
          IL_012c: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0131: ldloc.2      // x
          IL_0132: ldloc.3      // y
          IL_0133: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0138: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_013d: ldloc.s      s
          IL_013f: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_0144: ceq
          IL_0146: stloc.s      V_12

          IL_0148: ldloc.s      V_12
          IL_014a: brfalse.s    IL_0187

          // [64 29 - 64 30]
          IL_014c: nop

          // [65 33 - 65 91]
          IL_014d: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0152: ldloc.2      // x
          IL_0153: ldloc.3      // y
          IL_0154: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0159: ldloc.s      s
          IL_015b: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_0160: call         int32 [System.Runtime]System.String::CompareOrdinal(string, string)
          IL_0165: ldc.i4.0
          IL_0166: clt
          IL_0168: ldc.i4.0
          IL_0169: ceq
          IL_016b: stloc.s      V_13

          IL_016d: ldloc.s      V_13
          IL_016f: brfalse.s    IL_0186

          // [66 33 - 66 34]
          IL_0171: nop

          // [67 37 - 67 64]
          IL_0172: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0177: ldloc.2      // x
          IL_0178: ldloc.3      // y
          IL_0179: ldloc.s      s
          IL_017b: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_0180: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [68 33 - 68 34]
          IL_0185: nop

          // [69 29 - 69 30]
          IL_0186: nop

          // [70 25 - 70 26]
          IL_0187: nop

          IL_0188: br.s         IL_019f

          // [72 25 - 72 26]
          IL_018a: nop

          // [73 29 - 73 56]
          IL_018b: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0190: ldloc.2      // x
          IL_0191: ldloc.3      // y
          IL_0192: ldloc.s      s
          IL_0194: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_0199: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [74 25 - 74 26]
          IL_019e: nop

          // [75 21 - 75 22]
          IL_019f: nop

          // [49 80 - 49 83]
          IL_01a0: ldloc.s      l
          IL_01a2: ldc.i4.1
          IL_01a3: add
          IL_01a4: stloc.s      l

          // [49 60 - 49 78]
          IL_01a6: ldloc.s      l
          IL_01a8: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_01ad: ldlen
          IL_01ae: conv.i4
          IL_01af: clt
          IL_01b1: stloc.s      V_14

          IL_01b3: ldloc.s      V_14
          IL_01b5: brtrue       IL_0096
        // end of loop

        // [77 21 - 77 43]
        IL_01ba: ldloc.s      s
        IL_01bc: ldloc.s      s
        IL_01be: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
        IL_01c3: ldc.i4.1
        IL_01c4: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Remove(int32, int32)
        IL_01c9: pop

        // [78 17 - 78 18]
        IL_01ca: nop

        // [45 40 - 45 43]
        IL_01cb: ldloc.s      j
        IL_01cd: ldc.i4.1
        IL_01ce: add
        IL_01cf: stloc.s      j

        // [45 33 - 45 38]
        IL_01d1: ldloc.s      j
        IL_01d3: ldsfld       int32 ConsoleApp1.Program::m
        IL_01d8: clt
        IL_01da: stloc.s      V_15

        IL_01dc: ldloc.s      V_15
        IL_01de: brtrue       IL_005b
      // end of loop

      // [79 13 - 79 14]
      IL_01e3: nop

      // [43 36 - 43 39]
      IL_01e4: ldloc.s      i
      IL_01e6: ldc.i4.1
      IL_01e7: add
      IL_01e8: stloc.s      i

      // [43 29 - 43 34]
      IL_01ea: ldloc.s      i
      IL_01ec: ldsfld       int32 ConsoleApp1.Program::k
      IL_01f1: clt
      IL_01f3: stloc.s      V_16

      IL_01f5: ldloc.s      V_16
      IL_01f7: brtrue       IL_0052
    // end of loop

    // [81 13 - 81 92]
    IL_01fc: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0201: ldsfld       int32 ConsoleApp1.Program::m
    IL_0206: ldc.i4.1
    IL_0207: sub
    IL_0208: ldsfld       int32 ConsoleApp1.Program::k
    IL_020d: ldc.i4.1
    IL_020e: sub
    IL_020f: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0214: brfalse.s    IL_0230
    IL_0216: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_021b: ldsfld       int32 ConsoleApp1.Program::m
    IL_0220: ldc.i4.1
    IL_0221: sub
    IL_0222: ldsfld       int32 ConsoleApp1.Program::k
    IL_0227: ldc.i4.1
    IL_0228: sub
    IL_0229: call         instance string string[0...,0...]::Get(int32, int32)
    IL_022e: br.s         IL_0235
    IL_0230: ldstr        "Wrong"
    IL_0235: call         void [System.Console]System.Console::WriteLine(string)
    IL_023a: nop

    // [82 9 - 82 10]
    IL_023b: ret

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
