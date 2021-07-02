// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 71DE1DF1-C3FE-40C9-B58A-9DBF8C73F620
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

    IL_005c: br           IL_022f
    // start of loop, entry point: IL_022f

      // [44 13 - 44 14]
      IL_0061: nop

      // [45 22 - 45 31]
      IL_0062: ldc.i4.0
      IL_0063: stloc.s      j

      IL_0065: br           IL_0218
      // start of loop, entry point: IL_0218

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
        IL_0081: br           IL_0212

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

        // [50 21 - 50 35]
        IL_00a1: ldloc.2      // s
        IL_00a2: ldc.i4.s     32 // 0x20
        IL_00a4: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Append(char)
        IL_00a9: pop

        // [51 26 - 51 58]
        IL_00aa: ldloc.1      // isFirst
        IL_00ab: brfalse.s    IL_00b0
        IL_00ad: ldc.i4.1
        IL_00ae: br.s         IL_00b1
        IL_00b0: ldc.i4.0
        IL_00b1: stloc.s      l

        IL_00b3: br           IL_01ef
        // start of loop, entry point: IL_01ef

          // [52 21 - 52 22]
          IL_00b8: nop

          // [53 25 - 53 41]
          IL_00b9: ldc.i4.0
          IL_00ba: stloc.1      // isFirst

          // [54 25 - 54 50]
          IL_00bb: ldloc.s      j
          IL_00bd: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00c2: ldloc.s      l
          IL_00c4: ldelem.ref
          IL_00c5: ldfld        int32 ConsoleApp1.Triple::a
          IL_00ca: add
          IL_00cb: stloc.s      x

          // [55 25 - 55 50]
          IL_00cd: ldloc.3      // i
          IL_00ce: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_00d3: ldloc.s      l
          IL_00d5: ldelem.ref
          IL_00d6: ldfld        int32 ConsoleApp1.Triple::b
          IL_00db: add
          IL_00dc: stloc.s      y

          // [56 25 - 56 47]
          IL_00de: ldloc.s      x
          IL_00e0: ldsfld       int32 ConsoleApp1.Program::m
          IL_00e5: bge.s        IL_00f5
          IL_00e7: ldloc.s      y
          IL_00e9: ldsfld       int32 ConsoleApp1.Program::k
          IL_00ee: clt
          IL_00f0: ldc.i4.0
          IL_00f1: ceq
          IL_00f3: br.s         IL_00f6
          IL_00f5: ldc.i4.1
          IL_00f6: stloc.s      V_9

          IL_00f8: ldloc.s      V_9
          IL_00fa: brfalse.s    IL_0101

          // [57 29 - 57 38]
          IL_00fc: br           IL_01e9

          // [58 25 - 58 56]
          IL_0101: ldloc.2      // s
          IL_0102: ldloc.2      // s
          IL_0103: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_0108: ldc.i4.1
          IL_0109: sub
          IL_010a: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_010f: ldloc.s      l
          IL_0111: ldelem.ref
          IL_0112: ldfld        char ConsoleApp1.Triple::c
          IL_0117: callvirt     instance void [System.Runtime]System.Text.StringBuilder::set_Chars(int32, char)
          IL_011c: nop

          // [59 25 - 59 49]
          IL_011d: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0122: ldloc.s      x
          IL_0124: ldloc.s      y
          IL_0126: call         instance string string[0...,0...]::Get(int32, int32)
          IL_012b: ldnull
          IL_012c: cgt.un
          IL_012e: stloc.s      V_10

          IL_0130: ldloc.s      V_10
          IL_0132: brfalse      IL_01d2

          // [60 25 - 60 26]
          IL_0137: nop

          // [61 29 - 61 63]
          IL_0138: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_013d: ldloc.s      x
          IL_013f: ldloc.s      y
          IL_0141: call         instance string string[0...,0...]::Get(int32, int32)
          IL_0146: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_014b: ldloc.2      // s
          IL_014c: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_0151: cgt
          IL_0153: stloc.s      V_11

          IL_0155: ldloc.s      V_11
          IL_0157: brfalse.s    IL_0171

          // [62 29 - 62 30]
          IL_0159: nop

          // [63 33 - 63 60]
          IL_015a: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_015f: ldloc.s      x
          IL_0161: ldloc.s      y
          IL_0163: ldloc.2      // s
          IL_0164: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_0169: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [64 29 - 64 30]
          IL_016e: nop

          IL_016f: br.s         IL_01cf

          // [65 34 - 65 69]
          IL_0171: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0176: ldloc.s      x
          IL_0178: ldloc.s      y
          IL_017a: call         instance string string[0...,0...]::Get(int32, int32)
          IL_017f: callvirt     instance int32 [System.Runtime]System.String::get_Length()
          IL_0184: ldloc.2      // s
          IL_0185: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
          IL_018a: ceq
          IL_018c: stloc.s      V_12

          IL_018e: ldloc.s      V_12
          IL_0190: brfalse.s    IL_01cf

          // [66 29 - 66 30]
          IL_0192: nop

          // [67 33 - 67 91]
          IL_0193: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_0198: ldloc.s      x
          IL_019a: ldloc.s      y
          IL_019c: call         instance string string[0...,0...]::Get(int32, int32)
          IL_01a1: ldloc.2      // s
          IL_01a2: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_01a7: call         int32 [System.Runtime]System.String::CompareOrdinal(string, string)
          IL_01ac: ldc.i4.0
          IL_01ad: clt
          IL_01af: ldc.i4.0
          IL_01b0: ceq
          IL_01b2: stloc.s      V_13

          IL_01b4: ldloc.s      V_13
          IL_01b6: brfalse.s    IL_01ce

          // [68 33 - 68 34]
          IL_01b8: nop

          // [69 37 - 69 64]
          IL_01b9: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_01be: ldloc.s      x
          IL_01c0: ldloc.s      y
          IL_01c2: ldloc.2      // s
          IL_01c3: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_01c8: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [70 33 - 70 34]
          IL_01cd: nop

          // [71 29 - 71 30]
          IL_01ce: nop

          // [72 25 - 72 26]
          IL_01cf: nop

          IL_01d0: br.s         IL_01e8

          // [74 25 - 74 26]
          IL_01d2: nop

          // [75 29 - 75 56]
          IL_01d3: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
          IL_01d8: ldloc.s      x
          IL_01da: ldloc.s      y
          IL_01dc: ldloc.2      // s
          IL_01dd: callvirt     instance string [System.Runtime]System.Object::ToString()
          IL_01e2: call         instance void string[0...,0...]::Set(int32, int32, string)

          // [76 25 - 76 26]
          IL_01e7: nop

          // [77 21 - 77 22]
          IL_01e8: nop

          // [51 80 - 51 83]
          IL_01e9: ldloc.s      l
          IL_01eb: ldc.i4.1
          IL_01ec: add
          IL_01ed: stloc.s      l

          // [51 60 - 51 78]
          IL_01ef: ldloc.s      l
          IL_01f1: ldsfld       class ConsoleApp1.Triple[] ConsoleApp1.Program::triples
          IL_01f6: ldlen
          IL_01f7: conv.i4
          IL_01f8: clt
          IL_01fa: stloc.s      V_14

          IL_01fc: ldloc.s      V_14
          IL_01fe: brtrue       IL_00b8
        // end of loop

        // [79 21 - 79 43]
        IL_0203: ldloc.2      // s
        IL_0204: ldloc.2      // s
        IL_0205: callvirt     instance int32 [System.Runtime]System.Text.StringBuilder::get_Length()
        IL_020a: ldc.i4.1
        IL_020b: callvirt     instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::Remove(int32, int32)
        IL_0210: pop

        // [80 17 - 80 18]
        IL_0211: nop

        // [45 40 - 45 43]
        IL_0212: ldloc.s      j
        IL_0214: ldc.i4.1
        IL_0215: add
        IL_0216: stloc.s      j

        // [45 33 - 45 38]
        IL_0218: ldloc.s      j
        IL_021a: ldsfld       int32 ConsoleApp1.Program::m
        IL_021f: clt
        IL_0221: stloc.s      V_15

        IL_0223: ldloc.s      V_15
        IL_0225: brtrue       IL_006a
      // end of loop

      // [81 13 - 81 14]
      IL_022a: nop

      // [43 36 - 43 39]
      IL_022b: ldloc.3      // i
      IL_022c: ldc.i4.1
      IL_022d: add
      IL_022e: stloc.3      // i

      // [43 29 - 43 34]
      IL_022f: ldloc.3      // i
      IL_0230: ldsfld       int32 ConsoleApp1.Program::k
      IL_0235: clt
      IL_0237: stloc.s      V_16

      IL_0239: ldloc.s      V_16
      IL_023b: brtrue       IL_0061
    // end of loop

    // [83 13 - 83 92]
    IL_0240: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_0245: ldsfld       int32 ConsoleApp1.Program::m
    IL_024a: ldc.i4.1
    IL_024b: sub
    IL_024c: ldsfld       int32 ConsoleApp1.Program::k
    IL_0251: ldc.i4.1
    IL_0252: sub
    IL_0253: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0258: brfalse.s    IL_0274
    IL_025a: ldsfld       string[0...,0...] ConsoleApp1.Program::'field'
    IL_025f: ldsfld       int32 ConsoleApp1.Program::m
    IL_0264: ldc.i4.1
    IL_0265: sub
    IL_0266: ldsfld       int32 ConsoleApp1.Program::k
    IL_026b: ldc.i4.1
    IL_026c: sub
    IL_026d: call         instance string string[0...,0...]::Get(int32, int32)
    IL_0272: br.s         IL_0279
    IL_0274: ldstr        "Wrong"
    IL_0279: call         void [System.Console]System.Console::WriteLine(string)
    IL_027e: nop

    // [84 9 - 84 10]
    IL_027f: ret

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
