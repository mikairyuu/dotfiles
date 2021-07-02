// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 26AE6F20-0FA3-4286-AEE3-7E30DEDB10DA
// Location: /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.dll
// Sequence point data from /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.pdb

.class private auto ansi beforefieldinit
  ConsoleApp1.Program
    extends [System.Runtime]System.Object
{

  .method private hidebysig static void
    rec(
      class [System.Collections]System.Collections.Generic.List`1<int32> bin,
      int32 n
    ) cil managed
  {
    .maxstack 3
    .locals init (
      [0] bool V_0,
      [1] int32 j,
      [2] bool V_2,
      [3] bool V_3
    )

    // [11 9 - 11 10]
    IL_0000: nop

    // [13 13 - 13 33]
    IL_0001: ldarg.0      // bin
    IL_0002: ldarg.1      // n
    IL_0003: ldc.i4.1
    IL_0004: sub
    IL_0005: callvirt     instance !0/*int32*/ class [System.Collections]System.Collections.Generic.List`1<int32>::get_Item(int32)
    IL_000a: ldc.i4.0
    IL_000b: ceq
    IL_000d: stloc.0      // V_0

    IL_000e: ldloc.0      // V_0
    IL_000f: brfalse.s    IL_0020

    // [14 13 - 14 14]
    IL_0011: nop

    // [15 17 - 15 32]
    IL_0012: ldarg.0      // bin
    IL_0013: ldarg.1      // n
    IL_0014: ldc.i4.1
    IL_0015: sub
    IL_0016: ldc.i4.1
    IL_0017: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<int32>::set_Item(int32, !0/*int32*/)
    IL_001c: nop

    // [16 13 - 16 14]
    IL_001d: nop

    IL_001e: br.s         IL_0060

    // [18 13 - 18 14]
    IL_0020: nop

    // [19 22 - 19 35]
    IL_0021: ldarg.1      // n
    IL_0022: ldc.i4.1
    IL_0023: sub
    IL_0024: stloc.1      // j

    IL_0025: br.s         IL_0054
    // start of loop, entry point: IL_0054

      // [20 17 - 20 18]
      IL_0027: nop

      // [21 21 - 21 37]
      IL_0028: ldarg.0      // bin
      IL_0029: ldloc.1      // j
      IL_002a: callvirt     instance !0/*int32*/ class [System.Collections]System.Collections.Generic.List`1<int32>::get_Item(int32)
      IL_002f: ldc.i4.1
      IL_0030: ceq
      IL_0032: stloc.2      // V_2

      IL_0033: ldloc.2      // V_2
      IL_0034: brfalse.s    IL_0043

      // [22 21 - 22 22]
      IL_0036: nop

      // [23 25 - 23 36]
      IL_0037: ldarg.0      // bin
      IL_0038: ldloc.1      // j
      IL_0039: ldc.i4.0
      IL_003a: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<int32>::set_Item(int32, !0/*int32*/)
      IL_003f: nop

      // [24 21 - 24 22]
      IL_0040: nop

      IL_0041: br.s         IL_004f

      // [26 21 - 26 22]
      IL_0043: nop

      // [27 25 - 27 36]
      IL_0044: ldarg.0      // bin
      IL_0045: ldloc.1      // j
      IL_0046: ldc.i4.1
      IL_0047: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<int32>::set_Item(int32, !0/*int32*/)
      IL_004c: nop

      // [28 25 - 28 31]
      IL_004d: br.s         IL_005f

      // [30 17 - 30 18]
      IL_004f: nop

      // [19 45 - 19 48]
      IL_0050: ldloc.1      // j
      IL_0051: ldc.i4.1
      IL_0052: sub
      IL_0053: stloc.1      // j

      // [19 37 - 19 43]
      IL_0054: ldloc.1      // j
      IL_0055: ldc.i4.0
      IL_0056: clt
      IL_0058: ldc.i4.0
      IL_0059: ceq
      IL_005b: stloc.3      // V_3

      IL_005c: ldloc.3      // V_3
      IL_005d: brtrue.s     IL_0027
    // end of loop

    // [31 13 - 31 14]
    IL_005f: nop

    // [33 9 - 33 10]
    IL_0060: ret

  } // end of method Program::rec

  .method private hidebysig static int32
    check(
      class [System.Collections]System.Collections.Generic.List`1<int32> list,
      class [System.Collections]System.Collections.Generic.List`1<int32> mylist,
      class [System.Collections]System.Collections.Generic.List`1<int64> errors,
      int32 p,
      int32 q
    ) cil managed
  {
    .maxstack 4
    .locals init (
      [0] int32 i,
      [1] int32 w,
      [2] int32 y,
      [3] bool V_3,
      [4] bool V_4,
      [5] bool V_5,
      [6] int32 V_6,
      [7] bool V_7
    )

    // [35 9 - 35 10]
    IL_0000: nop

    // [37 18 - 37 27]
    IL_0001: ldc.i4.0
    IL_0002: stloc.0      // i

    IL_0003: br.s         IL_005e
    // start of loop, entry point: IL_005e

      // [38 13 - 38 14]
      IL_0005: nop

      // [39 17 - 39 27]
      IL_0006: ldc.i4.0
      IL_0007: stloc.1      // w

      // [40 22 - 40 31]
      IL_0008: ldc.i4.0
      IL_0009: stloc.2      // y

      IL_000a: br.s         IL_0034
      // start of loop, entry point: IL_0034

        // [41 17 - 41 18]
        IL_000c: nop

        // [42 21 - 42 57]
        IL_000d: ldarg.0      // list
        IL_000e: ldloc.2      // y
        IL_000f: callvirt     instance !0/*int32*/ class [System.Collections]System.Collections.Generic.List`1<int32>::get_Item(int32)
        IL_0014: ldarg.1      // mylist
        IL_0015: ldloc.0      // i
        IL_0016: ldarg.s      q
        IL_0018: mul
        IL_0019: ldloc.2      // y
        IL_001a: add
        IL_001b: callvirt     instance !0/*int32*/ class [System.Collections]System.Collections.Generic.List`1<int32>::get_Item(int32)
        IL_0020: ceq
        IL_0022: ldc.i4.0
        IL_0023: ceq
        IL_0025: stloc.3      // V_3

        IL_0026: ldloc.3      // V_3
        IL_0027: brfalse.s    IL_002f

        // [43 21 - 43 22]
        IL_0029: nop

        // [44 25 - 44 29]
        IL_002a: ldloc.1      // w
        IL_002b: ldc.i4.1
        IL_002c: add
        IL_002d: stloc.1      // w

        // [45 21 - 45 22]
        IL_002e: nop

        // [46 17 - 46 18]
        IL_002f: nop

        // [40 40 - 40 43]
        IL_0030: ldloc.2      // y
        IL_0031: ldc.i4.1
        IL_0032: add
        IL_0033: stloc.2      // y

        // [40 33 - 40 38]
        IL_0034: ldloc.2      // y
        IL_0035: ldarg.s      q
        IL_0037: clt
        IL_0039: stloc.s      V_4

        IL_003b: ldloc.s      V_4
        IL_003d: brtrue.s     IL_000c
      // end of loop

      // [47 17 - 47 36]
      IL_003f: ldarg.2      // errors
      IL_0040: ldloc.0      // i
      IL_0041: callvirt     instance !0/*int64*/ class [System.Collections]System.Collections.Generic.List`1<int64>::get_Item(int32)
      IL_0046: ldloc.1      // w
      IL_0047: conv.i8
      IL_0048: ceq
      IL_004a: ldc.i4.0
      IL_004b: ceq
      IL_004d: stloc.s      V_5

      IL_004f: ldloc.s      V_5
      IL_0051: brfalse.s    IL_0059

      // [48 17 - 48 18]
      IL_0053: nop

      // [49 21 - 49 30]
      IL_0054: ldc.i4.0
      IL_0055: stloc.s      V_6
      IL_0057: br.s         IL_006d

      // [51 13 - 51 14]
      IL_0059: nop

      // [37 36 - 37 39]
      IL_005a: ldloc.0      // i
      IL_005b: ldc.i4.1
      IL_005c: add
      IL_005d: stloc.0      // i

      // [37 29 - 37 34]
      IL_005e: ldloc.0      // i
      IL_005f: ldarg.3      // p
      IL_0060: clt
      IL_0062: stloc.s      V_7

      IL_0064: ldloc.s      V_7
      IL_0066: brtrue.s     IL_0005
    // end of loop

    // [52 13 - 52 22]
    IL_0068: ldc.i4.1
    IL_0069: stloc.s      V_6
    IL_006b: br.s         IL_006d

    // [53 9 - 53 10]
    IL_006d: ldloc.s      V_6
    IL_006f: ret

  } // end of method Program::check

  .method private hidebysig static void
    Main(
      string[] args
    ) cil managed
  {
    .entrypoint
    .maxstack 5
    .locals init (
      [0] class [System.Runtime]System.IO.StreamReader 'stream',
      [1] string[] arr,
      [2] int32 p,
      [3] int32 q,
      [4] int32 Key,
      [5] class [System.Collections]System.Collections.Generic.List`1<int32> myList,
      [6] class [System.Collections]System.Collections.Generic.List`1<int64> errors,
      [7] class [System.Collections]System.Collections.Generic.List`1<int32> list,
      [8] class [System.Runtime]System.IO.StreamWriter steam1,
      [9] int32 i,
      [10] bool V_10,
      [11] int32 i_V_11,
      [12] string v,
      [13] int32 y,
      [14] bool V_14,
      [15] bool V_15,
      [16] bool V_16,
      [17] int32 k,
      [18] bool V_18,
      [19] bool V_19,
      [20] bool V_20,
      [21] int32 k_V_21,
      [22] bool V_22,
      [23] bool V_23,
      [24] bool V_24,
      [25] int32 i_V_25,
      [26] int32 y_V_26,
      [27] bool V_27,
      [28] bool V_28,
      [29] int32 i_V_29,
      [30] bool V_30,
      [31] bool V_31
    )

    // [57 9 - 57 10]
    IL_0000: nop

    // [58 13 - 58 66]
    IL_0001: ldstr        "input.txt"
    IL_0006: newobj       instance void [System.Runtime]System.IO.StreamReader::.ctor(string)
    IL_000b: stloc.0      // 'stream'

    // [60 13 - 60 52]
    IL_000c: ldloc.0      // 'stream'
    IL_000d: callvirt     instance string [System.Runtime]System.IO.TextReader::ReadLine()
    IL_0012: ldc.i4.s     32 // 0x20
    IL_0014: ldc.i4.0
    IL_0015: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_001a: stloc.1      // arr

    // [61 13 - 61 39]
    IL_001b: ldloc.1      // arr
    IL_001c: ldc.i4.0
    IL_001d: ldelem.ref
    IL_001e: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0023: stloc.2      // p

    // [62 13 - 62 39]
    IL_0024: ldloc.1      // arr
    IL_0025: ldc.i4.1
    IL_0026: ldelem.ref
    IL_0027: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_002c: stloc.3      // q

    // [63 13 - 63 25]
    IL_002d: ldc.i4.0
    IL_002e: stloc.s      Key

    // [64 13 - 64 48]
    IL_0030: newobj       instance void class [System.Collections]System.Collections.Generic.List`1<int32>::.ctor()
    IL_0035: stloc.s      myList

    // [65 13 - 65 50]
    IL_0037: newobj       instance void class [System.Collections]System.Collections.Generic.List`1<int64>::.ctor()
    IL_003c: stloc.s      errors

    // [66 13 - 66 46]
    IL_003e: newobj       instance void class [System.Collections]System.Collections.Generic.List`1<int32>::.ctor()
    IL_0043: stloc.s      list

    // [67 18 - 67 27]
    IL_0045: ldc.i4.0
    IL_0046: stloc.s      i

    IL_0048: br.s         IL_005b
    // start of loop, entry point: IL_005b

      // [68 13 - 68 14]
      IL_004a: nop

      // [69 17 - 69 29]
      IL_004b: ldloc.s      list
      IL_004d: ldc.i4.0
      IL_004e: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<int32>::Add(!0/*int32*/)
      IL_0053: nop

      // [70 13 - 70 14]
      IL_0054: nop

      // [67 36 - 67 39]
      IL_0055: ldloc.s      i
      IL_0057: ldc.i4.1
      IL_0058: add
      IL_0059: stloc.s      i

      // [67 29 - 67 34]
      IL_005b: ldloc.s      i
      IL_005d: ldloc.3      // q
      IL_005e: clt
      IL_0060: stloc.s      V_10

      IL_0062: ldloc.s      V_10
      IL_0064: brtrue.s     IL_004a
    // end of loop

    // [71 18 - 71 27]
    IL_0066: ldc.i4.0
    IL_0067: stloc.s      i_V_11

    IL_0069: br           IL_0188
    // start of loop, entry point: IL_0188

      // [72 13 - 72 14]
      IL_006e: nop

      // [74 17 - 74 43]
      IL_006f: ldloc.0      // 'stream'
      IL_0070: callvirt     instance string [System.Runtime]System.IO.TextReader::ReadLine()
      IL_0075: stloc.s      v

      // [75 22 - 75 31]
      IL_0077: ldc.i4.0
      IL_0078: stloc.s      y

      IL_007a: br.s         IL_00af
      // start of loop, entry point: IL_00af

        // [76 17 - 76 18]
        IL_007c: nop

        // [77 21 - 77 37]
        IL_007d: ldloc.s      v
        IL_007f: ldloc.s      y
        IL_0081: callvirt     instance char [System.Runtime]System.String::get_Chars(int32)
        IL_0086: ldc.i4.s     45 // 0x2d
        IL_0088: ceq
        IL_008a: stloc.s      V_14

        IL_008c: ldloc.s      V_14
        IL_008e: brfalse.s    IL_009d

        // [78 21 - 78 22]
        IL_0090: nop

        // [79 25 - 79 39]
        IL_0091: ldloc.s      myList
        IL_0093: ldc.i4.0
        IL_0094: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<int32>::Add(!0/*int32*/)
        IL_0099: nop

        // [80 21 - 80 22]
        IL_009a: nop

        IL_009b: br.s         IL_00a8

        // [82 21 - 82 22]
        IL_009d: nop

        // [83 25 - 83 39]
        IL_009e: ldloc.s      myList
        IL_00a0: ldc.i4.1
        IL_00a1: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<int32>::Add(!0/*int32*/)
        IL_00a6: nop

        // [84 21 - 84 22]
        IL_00a7: nop

        // [86 17 - 86 18]
        IL_00a8: nop

        // [75 47 - 75 50]
        IL_00a9: ldloc.s      y
        IL_00ab: ldc.i4.1
        IL_00ac: add
        IL_00ad: stloc.s      y

        // [75 33 - 75 45]
        IL_00af: ldloc.s      y
        IL_00b1: ldloc.s      v
        IL_00b3: callvirt     instance int32 [System.Runtime]System.String::get_Length()
        IL_00b8: clt
        IL_00ba: stloc.s      V_15

        IL_00bc: ldloc.s      V_15
        IL_00be: brtrue.s     IL_007c
      // end of loop

      // [87 17 - 87 58]
      IL_00c0: ldloc.s      errors
      IL_00c2: ldloc.0      // 'stream'
      IL_00c3: callvirt     instance string [System.Runtime]System.IO.TextReader::ReadLine()
      IL_00c8: call         int32 [System.Runtime]System.Int32::Parse(string)
      IL_00cd: conv.i8
      IL_00ce: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<int64>::Add(!0/*int64*/)
      IL_00d3: nop

      // [88 17 - 88 38]
      IL_00d4: ldloc.s      errors
      IL_00d6: ldloc.s      i_V_11
      IL_00d8: callvirt     instance !0/*int64*/ class [System.Collections]System.Collections.Generic.List`1<int64>::get_Item(int32)
      IL_00dd: ldc.i4.0
      IL_00de: conv.i8
      IL_00df: ceq
      IL_00e1: stloc.s      V_16

      IL_00e3: ldloc.s      V_16
      IL_00e5: brfalse.s    IL_0138

      // [89 17 - 89 18]
      IL_00e7: nop

      // [90 26 - 90 35]
      IL_00e8: ldc.i4.0
      IL_00e9: stloc.s      k

      IL_00eb: br.s         IL_0128
      // start of loop, entry point: IL_0128

        // [91 21 - 91 22]
        IL_00ed: nop

        // [92 25 - 92 52]
        IL_00ee: ldloc.s      myList
        IL_00f0: ldloc.s      i_V_11
        IL_00f2: ldloc.3      // q
        IL_00f3: mul
        IL_00f4: ldloc.s      k
        IL_00f6: add
        IL_00f7: callvirt     instance !0/*int32*/ class [System.Collections]System.Collections.Generic.List`1<int32>::get_Item(int32)
        IL_00fc: ldc.i4.0
        IL_00fd: ceq
        IL_00ff: stloc.s      V_18

        IL_0101: ldloc.s      V_18
        IL_0103: brfalse.s    IL_0114

        // [93 25 - 93 26]
        IL_0105: nop

        // [94 29 - 94 41]
        IL_0106: ldloc.s      list
        IL_0108: ldloc.s      k
        IL_010a: ldc.i4.1
        IL_010b: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<int32>::set_Item(int32, !0/*int32*/)
        IL_0110: nop

        // [95 25 - 95 26]
        IL_0111: nop

        IL_0112: br.s         IL_0121

        // [97 25 - 97 26]
        IL_0114: nop

        // [98 29 - 98 41]
        IL_0115: ldloc.s      list
        IL_0117: ldloc.s      k
        IL_0119: ldc.i4.0
        IL_011a: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<int32>::set_Item(int32, !0/*int32*/)
        IL_011f: nop

        // [99 25 - 99 26]
        IL_0120: nop

        // [101 21 - 101 22]
        IL_0121: nop

        // [90 44 - 90 47]
        IL_0122: ldloc.s      k
        IL_0124: ldc.i4.1
        IL_0125: add
        IL_0126: stloc.s      k

        // [90 37 - 90 42]
        IL_0128: ldloc.s      k
        IL_012a: ldloc.3      // q
        IL_012b: clt
        IL_012d: stloc.s      V_19

        IL_012f: ldloc.s      V_19
        IL_0131: brtrue.s     IL_00ed
      // end of loop

      // [102 21 - 102 29]
      IL_0133: ldc.i4.1
      IL_0134: stloc.s      Key

      // [103 21 - 103 27]
      IL_0136: br.s         IL_0196

      // [105 17 - 105 36]
      IL_0138: ldloc.s      errors
      IL_013a: ldloc.s      i_V_11
      IL_013c: callvirt     instance !0/*int64*/ class [System.Collections]System.Collections.Generic.List`1<int64>::get_Item(int32)
      IL_0141: ldloc.3      // q
      IL_0142: conv.i8
      IL_0143: ceq
      IL_0145: stloc.s      V_20

      IL_0147: ldloc.s      V_20
      IL_0149: brfalse.s    IL_0181

      // [106 17 - 106 18]
      IL_014b: nop

      // [107 26 - 107 35]
      IL_014c: ldc.i4.0
      IL_014d: stloc.s      k_V_21

      IL_014f: br.s         IL_0171
      // start of loop, entry point: IL_0171

        // [108 21 - 108 22]
        IL_0151: nop

        // [109 25 - 109 53]
        IL_0152: ldloc.s      list
        IL_0154: ldloc.s      k_V_21
        IL_0156: ldloc.s      myList
        IL_0158: ldloc.s      i_V_11
        IL_015a: ldloc.3      // q
        IL_015b: mul
        IL_015c: ldloc.s      k_V_21
        IL_015e: add
        IL_015f: callvirt     instance !0/*int32*/ class [System.Collections]System.Collections.Generic.List`1<int32>::get_Item(int32)
        IL_0164: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<int32>::set_Item(int32, !0/*int32*/)
        IL_0169: nop

        // [110 21 - 110 22]
        IL_016a: nop

        // [107 44 - 107 47]
        IL_016b: ldloc.s      k_V_21
        IL_016d: ldc.i4.1
        IL_016e: add
        IL_016f: stloc.s      k_V_21

        // [107 37 - 107 42]
        IL_0171: ldloc.s      k_V_21
        IL_0173: ldloc.3      // q
        IL_0174: clt
        IL_0176: stloc.s      V_22

        IL_0178: ldloc.s      V_22
        IL_017a: brtrue.s     IL_0151
      // end of loop

      // [111 21 - 111 29]
      IL_017c: ldc.i4.1
      IL_017d: stloc.s      Key

      // [112 21 - 112 27]
      IL_017f: br.s         IL_0196

      // [114 13 - 114 14]
      IL_0181: nop

      // [71 36 - 71 39]
      IL_0182: ldloc.s      i_V_11
      IL_0184: ldc.i4.1
      IL_0185: add
      IL_0186: stloc.s      i_V_11

      // [71 29 - 71 34]
      IL_0188: ldloc.s      i_V_11
      IL_018a: ldloc.2      // p
      IL_018b: clt
      IL_018d: stloc.s      V_23

      IL_018f: ldloc.s      V_23
      IL_0191: brtrue       IL_006e
    // end of loop

    // [115 13 - 115 26]
    IL_0196: ldloc.s      Key
    IL_0198: ldc.i4.0
    IL_0199: ceq
    IL_019b: stloc.s      V_24

    IL_019d: ldloc.s      V_24
    IL_019f: brfalse.s    IL_0205

    // [116 13 - 116 14]
    IL_01a1: nop

    // [117 22 - 117 31]
    IL_01a2: ldc.i4.0
    IL_01a3: stloc.s      i_V_25

    IL_01a5: br.s         IL_01e9
    // start of loop, entry point: IL_01e9

      // [118 17 - 118 18]
      IL_01a7: nop

      // [123 21 - 123 34]
      IL_01a8: ldloc.s      list
      IL_01aa: ldloc.3      // q
      IL_01ab: call         void ConsoleApp1.Program::rec(class [System.Collections]System.Collections.Generic.List`1<int32>, int32)
      IL_01b0: nop

      // [124 25 - 124 32]
      IL_01b1: ldc.i4.0
      IL_01b2: stloc.s      y_V_26

      IL_01b4: br.s         IL_01cb
      // start of loop, entry point: IL_01cb

        // [124 51 - 124 74]
        IL_01b6: ldloc.s      list
        IL_01b8: ldloc.s      y_V_26
        IL_01ba: callvirt     instance !0/*int32*/ class [System.Collections]System.Collections.Generic.List`1<int32>::get_Item(int32)
        IL_01bf: call         void [System.Console]System.Console::Write(int32)
        IL_01c4: nop

        // [124 46 - 124 49]
        IL_01c5: ldloc.s      y_V_26
        IL_01c7: ldc.i4.1
        IL_01c8: add
        IL_01c9: stloc.s      y_V_26

        // [124 33 - 124 45]
        IL_01cb: ldloc.s      y_V_26
        IL_01cd: ldloc.s      list
        IL_01cf: callvirt     instance int32 class [System.Collections]System.Collections.Generic.List`1<int32>::get_Count()
        IL_01d4: clt
        IL_01d6: stloc.s      V_27

        IL_01d8: ldloc.s      V_27
        IL_01da: brtrue.s     IL_01b6
      // end of loop

      // [125 21 - 125 41]
      IL_01dc: call         void [System.Console]System.Console::WriteLine()
      IL_01e1: nop

      // [126 17 - 126 18]
      IL_01e2: nop

      // [117 53 - 117 56]
      IL_01e3: ldloc.s      i_V_25
      IL_01e5: ldc.i4.1
      IL_01e6: add
      IL_01e7: stloc.s      i_V_25

      // [117 33 - 117 51]
      IL_01e9: ldloc.s      i_V_25
      IL_01eb: conv.r8
      IL_01ec: ldc.r8       2
      IL_01f5: ldloc.3      // q
      IL_01f6: conv.r8
      IL_01f7: call         float64 [System.Runtime]System.Math::Pow(float64, float64)
      IL_01fc: clt
      IL_01fe: stloc.s      V_28

      IL_0200: ldloc.s      V_28
      IL_0202: brtrue.s     IL_01a7
    // end of loop

    // [127 13 - 127 14]
    IL_0204: nop

    // [128 13 - 128 67]
    IL_0205: ldstr        "output.txt"
    IL_020a: newobj       instance void [System.Runtime]System.IO.StreamWriter::.ctor(string)
    IL_020f: stloc.s      steam1

    // [129 18 - 129 27]
    IL_0211: ldc.i4.0
    IL_0212: stloc.s      i_V_29

    IL_0214: br.s         IL_0250
    // start of loop, entry point: IL_0250

      // [130 13 - 130 14]
      IL_0216: nop

      // [131 17 - 131 34]
      IL_0217: ldloc.s      list
      IL_0219: ldloc.s      i_V_29
      IL_021b: callvirt     instance !0/*int32*/ class [System.Collections]System.Collections.Generic.List`1<int32>::get_Item(int32)
      IL_0220: ldc.i4.0
      IL_0221: ceq
      IL_0223: stloc.s      V_30

      IL_0225: ldloc.s      V_30
      IL_0227: brfalse.s    IL_023a

      // [132 17 - 132 18]
      IL_0229: nop

      // [133 21 - 133 39]
      IL_022a: ldloc.s      steam1
      IL_022c: ldstr        "-"
      IL_0231: callvirt     instance void [System.Runtime]System.IO.TextWriter::Write(string)
      IL_0236: nop

      // [134 17 - 134 18]
      IL_0237: nop

      IL_0238: br.s         IL_0249

      // [136 17 - 136 18]
      IL_023a: nop

      // [137 21 - 137 39]
      IL_023b: ldloc.s      steam1
      IL_023d: ldstr        "+"
      IL_0242: callvirt     instance void [System.Runtime]System.IO.TextWriter::Write(string)
      IL_0247: nop

      // [138 17 - 138 18]
      IL_0248: nop

      // [139 13 - 139 14]
      IL_0249: nop

      // [129 45 - 129 48]
      IL_024a: ldloc.s      i_V_29
      IL_024c: ldc.i4.1
      IL_024d: add
      IL_024e: stloc.s      i_V_29

      // [129 29 - 129 43]
      IL_0250: ldloc.s      i_V_29
      IL_0252: ldloc.s      list
      IL_0254: callvirt     instance int32 class [System.Collections]System.Collections.Generic.List`1<int32>::get_Count()
      IL_0259: clt
      IL_025b: stloc.s      V_31

      IL_025d: ldloc.s      V_31
      IL_025f: brtrue.s     IL_0216
    // end of loop

    // [140 13 - 140 28]
    IL_0261: ldloc.s      steam1
    IL_0263: callvirt     instance void [System.Runtime]System.IO.TextWriter::Flush()
    IL_0268: nop

    // [141 9 - 141 10]
    IL_0269: ret

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
} // end of class ConsoleApp1.Program
