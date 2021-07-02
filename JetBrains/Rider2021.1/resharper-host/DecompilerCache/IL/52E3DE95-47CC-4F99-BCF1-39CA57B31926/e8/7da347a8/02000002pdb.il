// Type: ConsoleApp3.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52E3DE95-47CC-4F99-BCF1-39CA57B31926
// Location: /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.dll
// Sequence point data from /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.pdb

.class private auto ansi beforefieldinit
  ConsoleApp3.Program
    extends [System.Runtime]System.Object
{

  .method private hidebysig static void
    Merge(
      class [System.Collections]System.Collections.Generic.List`1<int64> 'array',
      class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>> time,
      int32 lowIndex,
      int32 middleIndex,
      int32 highIndex
    ) cil managed
  {
    .maxstack 4
    .locals init (
      [0] int32 left,
      [1] int32 right,
      [2] int64[] tempArray,
      [3] valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>[] tempArray1,
      [4] int64 index,
      [5] bool V_5,
      [6] bool V_6,
      [7] int32 i,
      [8] bool V_8,
      [9] int32 i_V_9,
      [10] bool V_10,
      [11] int32 i_V_11,
      [12] bool V_12
    )

    // [12 9 - 12 10]
    IL_0000: nop

    // [13 13 - 13 33]
    IL_0001: ldarg.2      // lowIndex
    IL_0002: stloc.0      // left

    // [14 13 - 14 41]
    IL_0003: ldarg.3      // middleIndex
    IL_0004: ldc.i4.1
    IL_0005: add
    IL_0006: stloc.1      // right

    // [15 13 - 15 64]
    IL_0007: ldarg.s      highIndex
    IL_0009: ldarg.2      // lowIndex
    IL_000a: sub
    IL_000b: ldc.i4.1
    IL_000c: add
    IL_000d: newarr       [System.Runtime]System.Int64
    IL_0012: stloc.2      // tempArray

    // [16 13 - 16 85]
    IL_0013: ldarg.s      highIndex
    IL_0015: ldarg.2      // lowIndex
    IL_0016: sub
    IL_0017: ldc.i4.1
    IL_0018: add
    IL_0019: newarr       valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>
    IL_001e: stloc.3      // tempArray1

    // [17 13 - 17 28]
    IL_001f: ldc.i4.0
    IL_0020: conv.i8
    IL_0021: stloc.s      index

    IL_0023: br.s         IL_008d
    // start of loop, entry point: IL_008d

      // [20 13 - 20 14]
      IL_0025: nop

      // [21 17 - 21 49]
      IL_0026: ldarg.0      // 'array'
      IL_0027: ldloc.0      // left
      IL_0028: callvirt     instance !0/*int64*/ class [System.Collections]System.Collections.Generic.List`1<int64>::get_Item(int32)
      IL_002d: ldarg.0      // 'array'
      IL_002e: ldloc.1      // right
      IL_002f: callvirt     instance !0/*int64*/ class [System.Collections]System.Collections.Generic.List`1<int64>::get_Item(int32)
      IL_0034: cgt
      IL_0036: ldc.i4.0
      IL_0037: ceq
      IL_0039: stloc.s      V_5

      IL_003b: ldloc.s      V_5
      IL_003d: brfalse.s    IL_0063

      // [22 17 - 22 18]
      IL_003f: nop

      // [23 21 - 23 52]
      IL_0040: ldloc.2      // tempArray
      IL_0041: ldloc.s      index
      IL_0043: conv.ovf.i
      IL_0044: ldarg.0      // 'array'
      IL_0045: ldloc.0      // left
      IL_0046: callvirt     instance !0/*int64*/ class [System.Collections]System.Collections.Generic.List`1<int64>::get_Item(int32)
      IL_004b: stelem.i8

      // [24 21 - 24 52]
      IL_004c: ldloc.3      // tempArray1
      IL_004d: ldloc.s      index
      IL_004f: conv.ovf.i
      IL_0050: ldarg.1      // time
      IL_0051: ldloc.0      // left
      IL_0052: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_0057: stelem       valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>

      // [25 21 - 25 28]
      IL_005c: ldloc.0      // left
      IL_005d: ldc.i4.1
      IL_005e: add
      IL_005f: stloc.0      // left

      // [26 17 - 26 18]
      IL_0060: nop

      IL_0061: br.s         IL_0085

      // [28 17 - 28 18]
      IL_0063: nop

      // [29 21 - 29 53]
      IL_0064: ldloc.2      // tempArray
      IL_0065: ldloc.s      index
      IL_0067: conv.ovf.i
      IL_0068: ldarg.0      // 'array'
      IL_0069: ldloc.1      // right
      IL_006a: callvirt     instance !0/*int64*/ class [System.Collections]System.Collections.Generic.List`1<int64>::get_Item(int32)
      IL_006f: stelem.i8

      // [30 21 - 30 53]
      IL_0070: ldloc.3      // tempArray1
      IL_0071: ldloc.s      index
      IL_0073: conv.ovf.i
      IL_0074: ldarg.1      // time
      IL_0075: ldloc.1      // right
      IL_0076: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_007b: stelem       valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>

      // [31 21 - 31 29]
      IL_0080: ldloc.1      // right
      IL_0081: ldc.i4.1
      IL_0082: add
      IL_0083: stloc.1      // right

      // [32 17 - 32 18]
      IL_0084: nop

      // [34 17 - 34 25]
      IL_0085: ldloc.s      index
      IL_0087: ldc.i4.1
      IL_0088: conv.i8
      IL_0089: add
      IL_008a: stloc.s      index

      // [35 13 - 35 14]
      IL_008c: nop

      // [19 13 - 19 66]
      IL_008d: ldloc.0      // left
      IL_008e: ldarg.3      // middleIndex
      IL_008f: bgt.s        IL_009b
      IL_0091: ldloc.1      // right
      IL_0092: ldarg.s      highIndex
      IL_0094: cgt
      IL_0096: ldc.i4.0
      IL_0097: ceq
      IL_0099: br.s         IL_009c
      IL_009b: ldc.i4.0
      IL_009c: stloc.s      V_6

      IL_009e: ldloc.s      V_6
      IL_00a0: brtrue.s     IL_0025
    // end of loop

    // [37 18 - 37 30]
    IL_00a2: ldloc.0      // left
    IL_00a3: stloc.s      i

    IL_00a5: br.s         IL_00d4
    // start of loop, entry point: IL_00d4

      // [38 13 - 38 14]
      IL_00a7: nop

      // [39 17 - 39 45]
      IL_00a8: ldloc.2      // tempArray
      IL_00a9: ldloc.s      index
      IL_00ab: conv.ovf.i
      IL_00ac: ldarg.0      // 'array'
      IL_00ad: ldloc.s      i
      IL_00af: callvirt     instance !0/*int64*/ class [System.Collections]System.Collections.Generic.List`1<int64>::get_Item(int32)
      IL_00b4: stelem.i8

      // [40 17 - 40 45]
      IL_00b5: ldloc.3      // tempArray1
      IL_00b6: ldloc.s      index
      IL_00b8: conv.ovf.i
      IL_00b9: ldarg.1      // time
      IL_00ba: ldloc.s      i
      IL_00bc: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_00c1: stelem       valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>

      // [41 17 - 41 25]
      IL_00c6: ldloc.s      index
      IL_00c8: ldc.i4.1
      IL_00c9: conv.i8
      IL_00ca: add
      IL_00cb: stloc.s      index

      // [42 13 - 42 14]
      IL_00cd: nop

      // [37 50 - 37 53]
      IL_00ce: ldloc.s      i
      IL_00d0: ldc.i4.1
      IL_00d1: add
      IL_00d2: stloc.s      i

      // [37 32 - 37 48]
      IL_00d4: ldloc.s      i
      IL_00d6: ldarg.3      // middleIndex
      IL_00d7: cgt
      IL_00d9: ldc.i4.0
      IL_00da: ceq
      IL_00dc: stloc.s      V_8

      IL_00de: ldloc.s      V_8
      IL_00e0: brtrue.s     IL_00a7
    // end of loop

    // [44 18 - 44 31]
    IL_00e2: ldloc.1      // right
    IL_00e3: stloc.s      i_V_9

    IL_00e5: br.s         IL_0114
    // start of loop, entry point: IL_0114

      // [45 13 - 45 14]
      IL_00e7: nop

      // [46 17 - 46 45]
      IL_00e8: ldloc.2      // tempArray
      IL_00e9: ldloc.s      index
      IL_00eb: conv.ovf.i
      IL_00ec: ldarg.0      // 'array'
      IL_00ed: ldloc.s      i_V_9
      IL_00ef: callvirt     instance !0/*int64*/ class [System.Collections]System.Collections.Generic.List`1<int64>::get_Item(int32)
      IL_00f4: stelem.i8

      // [47 17 - 47 45]
      IL_00f5: ldloc.3      // tempArray1
      IL_00f6: ldloc.s      index
      IL_00f8: conv.ovf.i
      IL_00f9: ldarg.1      // time
      IL_00fa: ldloc.s      i_V_9
      IL_00fc: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_0101: stelem       valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>

      // [48 17 - 48 25]
      IL_0106: ldloc.s      index
      IL_0108: ldc.i4.1
      IL_0109: conv.i8
      IL_010a: add
      IL_010b: stloc.s      index

      // [49 13 - 49 14]
      IL_010d: nop

      // [44 49 - 44 52]
      IL_010e: ldloc.s      i_V_9
      IL_0110: ldc.i4.1
      IL_0111: add
      IL_0112: stloc.s      i_V_9

      // [44 33 - 44 47]
      IL_0114: ldloc.s      i_V_9
      IL_0116: ldarg.s      highIndex
      IL_0118: cgt
      IL_011a: ldc.i4.0
      IL_011b: ceq
      IL_011d: stloc.s      V_10

      IL_011f: ldloc.s      V_10
      IL_0121: brtrue.s     IL_00e7
    // end of loop

    // [51 18 - 51 27]
    IL_0123: ldc.i4.0
    IL_0124: stloc.s      i_V_11

    IL_0126: br.s         IL_0152
    // start of loop, entry point: IL_0152

      // [52 13 - 52 14]
      IL_0128: nop

      // [53 17 - 53 52]
      IL_0129: ldarg.0      // 'array'
      IL_012a: ldarg.2      // lowIndex
      IL_012b: ldloc.s      i_V_11
      IL_012d: add
      IL_012e: ldloc.2      // tempArray
      IL_012f: ldloc.s      i_V_11
      IL_0131: ldelem.i8
      IL_0132: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<int64>::set_Item(int32, !0/*int64*/)
      IL_0137: nop

      // [54 17 - 54 52]
      IL_0138: ldarg.1      // time
      IL_0139: ldarg.2      // lowIndex
      IL_013a: ldloc.s      i_V_11
      IL_013c: add
      IL_013d: ldloc.3      // tempArray1
      IL_013e: ldloc.s      i_V_11
      IL_0140: ldelem       valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>
      IL_0145: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::set_Item(int32, !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/)
      IL_014a: nop

      // [55 13 - 55 14]
      IL_014b: nop

      // [51 51 - 51 54]
      IL_014c: ldloc.s      i_V_11
      IL_014e: ldc.i4.1
      IL_014f: add
      IL_0150: stloc.s      i_V_11

      // [51 29 - 51 49]
      IL_0152: ldloc.s      i_V_11
      IL_0154: ldloc.2      // tempArray
      IL_0155: ldlen
      IL_0156: conv.i4
      IL_0157: clt
      IL_0159: stloc.s      V_12

      IL_015b: ldloc.s      V_12
      IL_015d: brtrue.s     IL_0128
    // end of loop

    // [56 9 - 56 10]
    IL_015f: ret

  } // end of method Program::Merge

  .method private hidebysig static class [System.Collections]System.Collections.Generic.List`1<int64>
    MergeSort(
      class [System.Collections]System.Collections.Generic.List`1<int64> 'array',
      class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>> mas,
      int32 lowIndex,
      int32 highIndex
    ) cil managed
  {
    .maxstack 5
    .locals init (
      [0] bool V_0,
      [1] int32 middleIndex,
      [2] class [System.Collections]System.Collections.Generic.List`1<int64> V_2
    )

    // [58 9 - 58 10]
    IL_0000: nop

    // [59 13 - 59 38]
    IL_0001: ldarg.2      // lowIndex
    IL_0002: ldarg.3      // highIndex
    IL_0003: clt
    IL_0005: stloc.0      // V_0

    IL_0006: ldloc.0      // V_0
    IL_0007: brfalse.s    IL_0032

    // [60 13 - 60 14]
    IL_0009: nop

    // [61 17 - 61 62]
    IL_000a: ldarg.2      // lowIndex
    IL_000b: ldarg.3      // highIndex
    IL_000c: add
    IL_000d: ldc.i4.2
    IL_000e: div
    IL_000f: stloc.1      // middleIndex

    // [62 17 - 62 62]
    IL_0010: ldarg.0      // 'array'
    IL_0011: ldarg.1      // mas
    IL_0012: ldarg.2      // lowIndex
    IL_0013: ldloc.1      // middleIndex
    IL_0014: call         class [System.Collections]System.Collections.Generic.List`1<int64> ConsoleApp3.Program::MergeSort(class [System.Collections]System.Collections.Generic.List`1<int64>, class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>, int32, int32)
    IL_0019: pop

    // [63 17 - 63 67]
    IL_001a: ldarg.0      // 'array'
    IL_001b: ldarg.1      // mas
    IL_001c: ldloc.1      // middleIndex
    IL_001d: ldc.i4.1
    IL_001e: add
    IL_001f: ldarg.3      // highIndex
    IL_0020: call         class [System.Collections]System.Collections.Generic.List`1<int64> ConsoleApp3.Program::MergeSort(class [System.Collections]System.Collections.Generic.List`1<int64>, class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>, int32, int32)
    IL_0025: pop

    // [64 17 - 64 69]
    IL_0026: ldarg.0      // 'array'
    IL_0027: ldarg.1      // mas
    IL_0028: ldarg.2      // lowIndex
    IL_0029: ldloc.1      // middleIndex
    IL_002a: ldarg.3      // highIndex
    IL_002b: call         void ConsoleApp3.Program::Merge(class [System.Collections]System.Collections.Generic.List`1<int64>, class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>, int32, int32, int32)
    IL_0030: nop

    // [65 13 - 65 14]
    IL_0031: nop

    // [67 13 - 67 26]
    IL_0032: ldarg.0      // 'array'
    IL_0033: stloc.2      // V_2
    IL_0034: br.s         IL_0036

    // [68 9 - 68 10]
    IL_0036: ldloc.2      // V_2
    IL_0037: ret

  } // end of method Program::MergeSort

  .method public hidebysig static void
    heapify(
      class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>> mas
    ) cil managed
  {
    .maxstack 4
    .locals init (
      [0] int32 leftChild,
      [1] int32 rightChild,
      [2] int32 largestChild,
      [3] int32 i,
      [4] int32 M,
      [5] valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64> temp,
      [6] bool V_6,
      [7] valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64> V_7,
      [8] bool V_8,
      [9] bool V_9
    )

    // [70 9 - 70 10]
    IL_0000: nop

    // [74 13 - 74 23]
    IL_0001: ldc.i4.0
    IL_0002: stloc.3      // i

    // [75 13 - 75 31]
    IL_0003: ldarg.0      // mas
    IL_0004: callvirt     instance int32 class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Count()
    IL_0009: stloc.s      M

    IL_000b: br           IL_00b9
    // start of loop, entry point: IL_00b9

      // [78 13 - 78 14]
      IL_0010: nop

      // [79 17 - 79 39]
      IL_0011: ldc.i4.2
      IL_0012: ldloc.3      // i
      IL_0013: mul
      IL_0014: ldc.i4.1
      IL_0015: add
      IL_0016: stloc.0      // leftChild

      // [80 17 - 80 40]
      IL_0017: ldc.i4.2
      IL_0018: ldloc.3      // i
      IL_0019: mul
      IL_001a: ldc.i4.2
      IL_001b: add
      IL_001c: stloc.1      // rightChild

      // [81 17 - 81 34]
      IL_001d: ldloc.3      // i
      IL_001e: stloc.2      // largestChild

      // [83 17 - 83 81]
      IL_001f: ldloc.0      // leftChild
      IL_0020: ldloc.s      M
      IL_0022: bge.s        IL_0048
      IL_0024: ldarg.0      // mas
      IL_0025: ldloc.0      // leftChild
      IL_0026: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_002b: stloc.s      V_7
      IL_002d: ldloca.s     V_7
      IL_002f: call         instance !0/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Key()
      IL_0034: ldarg.0      // mas
      IL_0035: ldloc.2      // largestChild
      IL_0036: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_003b: stloc.s      V_7
      IL_003d: ldloca.s     V_7
      IL_003f: call         instance !0/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Key()
      IL_0044: clt
      IL_0046: br.s         IL_0049
      IL_0048: ldc.i4.0
      IL_0049: stloc.s      V_6

      IL_004b: ldloc.s      V_6
      IL_004d: brfalse.s    IL_0053

      // [84 17 - 84 18]
      IL_004f: nop

      // [85 21 - 85 46]
      IL_0050: ldloc.0      // leftChild
      IL_0051: stloc.2      // largestChild

      // [86 17 - 86 18]
      IL_0052: nop

      // [88 17 - 88 83]
      IL_0053: ldloc.1      // rightChild
      IL_0054: ldloc.s      M
      IL_0056: bge.s        IL_007c
      IL_0058: ldarg.0      // mas
      IL_0059: ldloc.1      // rightChild
      IL_005a: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_005f: stloc.s      V_7
      IL_0061: ldloca.s     V_7
      IL_0063: call         instance !0/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Key()
      IL_0068: ldarg.0      // mas
      IL_0069: ldloc.2      // largestChild
      IL_006a: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_006f: stloc.s      V_7
      IL_0071: ldloca.s     V_7
      IL_0073: call         instance !0/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Key()
      IL_0078: clt
      IL_007a: br.s         IL_007d
      IL_007c: ldc.i4.0
      IL_007d: stloc.s      V_8

      IL_007f: ldloc.s      V_8
      IL_0081: brfalse.s    IL_0087

      // [89 17 - 89 18]
      IL_0083: nop

      // [90 21 - 90 47]
      IL_0084: ldloc.1      // rightChild
      IL_0085: stloc.2      // largestChild

      // [91 17 - 91 18]
      IL_0086: nop

      // [93 17 - 93 39]
      IL_0087: ldloc.2      // largestChild
      IL_0088: ldloc.3      // i
      IL_0089: ceq
      IL_008b: stloc.s      V_9

      IL_008d: ldloc.s      V_9
      IL_008f: brfalse.s    IL_0094

      // [94 17 - 94 18]
      IL_0091: nop

      // [95 21 - 95 27]
      IL_0092: br.s         IL_00be

      // [98 17 - 98 56]
      IL_0094: ldarg.0      // mas
      IL_0095: ldloc.3      // i
      IL_0096: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_009b: stloc.s      temp

      // [99 17 - 99 44]
      IL_009d: ldarg.0      // mas
      IL_009e: ldloc.3      // i
      IL_009f: ldarg.0      // mas
      IL_00a0: ldloc.2      // largestChild
      IL_00a1: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_00a6: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::set_Item(int32, !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/)
      IL_00ab: nop

      // [100 17 - 100 42]
      IL_00ac: ldarg.0      // mas
      IL_00ad: ldloc.2      // largestChild
      IL_00ae: ldloc.s      temp
      IL_00b0: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::set_Item(int32, !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/)
      IL_00b5: nop

      // [101 17 - 101 34]
      IL_00b6: ldloc.2      // largestChild
      IL_00b7: stloc.3      // i

      // [102 13 - 102 14]
      IL_00b8: nop

      IL_00b9: br           IL_0010
    // end of loop

    // [103 9 - 103 10]
    IL_00be: ret

  } // end of method Program::heapify

  .method public hidebysig static void
    'add'(
      valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64> 'value',
      class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>> list
    ) cil managed
  {
    .maxstack 4
    .locals init (
      [0] int32 i,
      [1] int32 parent,
      [2] valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64> temp,
      [3] bool V_3,
      [4] valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64> V_4
    )

    // [105 9 - 105 10]
    IL_0000: nop

    // [106 13 - 106 29]
    IL_0001: ldarg.1      // list
    IL_0002: ldarg.0      // 'value'
    IL_0003: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::Add(!0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/)
    IL_0008: nop

    // [107 13 - 107 36]
    IL_0009: ldarg.1      // list
    IL_000a: callvirt     instance int32 class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Count()
    IL_000f: ldc.i4.1
    IL_0010: sub
    IL_0011: stloc.0      // i

    // [108 13 - 108 38]
    IL_0012: ldloc.0      // i
    IL_0013: ldc.i4.1
    IL_0014: sub
    IL_0015: ldc.i4.2
    IL_0016: div
    IL_0017: stloc.1      // parent

    IL_0018: br.s         IL_0044
    // start of loop, entry point: IL_0044

      // [111 13 - 111 14]
      IL_001a: nop

      // [112 17 - 112 57]
      IL_001b: ldarg.1      // list
      IL_001c: ldloc.0      // i
      IL_001d: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_0022: stloc.2      // temp

      // [113 17 - 113 40]
      IL_0023: ldarg.1      // list
      IL_0024: ldloc.0      // i
      IL_0025: ldarg.1      // list
      IL_0026: ldloc.1      // parent
      IL_0027: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_002c: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::set_Item(int32, !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/)
      IL_0031: nop

      // [114 17 - 114 37]
      IL_0032: ldarg.1      // list
      IL_0033: ldloc.1      // parent
      IL_0034: ldloc.2      // temp
      IL_0035: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::set_Item(int32, !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/)
      IL_003a: nop

      // [116 17 - 116 28]
      IL_003b: ldloc.1      // parent
      IL_003c: stloc.0      // i

      // [117 17 - 117 38]
      IL_003d: ldloc.0      // i
      IL_003e: ldc.i4.1
      IL_003f: sub
      IL_0040: ldc.i4.2
      IL_0041: div
      IL_0042: stloc.1      // parent

      // [118 13 - 118 14]
      IL_0043: nop

      // [110 13 - 110 60]
      IL_0044: ldloc.0      // i
      IL_0045: ldc.i4.0
      IL_0046: ble.s        IL_006c
      IL_0048: ldarg.1      // list
      IL_0049: ldloc.1      // parent
      IL_004a: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_004f: stloc.s      V_4
      IL_0051: ldloca.s     V_4
      IL_0053: call         instance !0/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Key()
      IL_0058: ldarg.1      // list
      IL_0059: ldloc.0      // i
      IL_005a: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
      IL_005f: stloc.s      V_4
      IL_0061: ldloca.s     V_4
      IL_0063: call         instance !0/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Key()
      IL_0068: cgt
      IL_006a: br.s         IL_006d
      IL_006c: ldc.i4.0
      IL_006d: stloc.3      // V_3

      IL_006e: ldloc.3      // V_3
      IL_006f: brtrue.s     IL_001a
    // end of loop

    // [119 9 - 119 10]
    IL_0071: ret

  } // end of method Program::'add'

  .method public hidebysig static void
    getMax(
      class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>> list
    ) cil managed
  {
    .maxstack 8

    // [121 9 - 121 10]
    IL_0000: nop

    // [122 13 - 122 44]
    IL_0001: ldarg.0      // list
    IL_0002: ldc.i4.0
    IL_0003: ldarg.0      // list
    IL_0004: ldarg.0      // list
    IL_0005: callvirt     instance int32 class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Count()
    IL_000a: ldc.i4.1
    IL_000b: sub
    IL_000c: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
    IL_0011: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::set_Item(int32, !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/)
    IL_0016: nop

    // [123 13 - 123 43]
    IL_0017: ldarg.0      // list
    IL_0018: ldarg.0      // list
    IL_0019: callvirt     instance int32 class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Count()
    IL_001e: ldc.i4.1
    IL_001f: sub
    IL_0020: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::RemoveAt(int32)
    IL_0025: nop

    // [124 9 - 124 10]
    IL_0026: ret

  } // end of method Program::getMax

  .method private hidebysig static void
    Main(
      string[] args
    ) cil managed
  {
    .entrypoint
    .maxstack 5
    .locals init (
      [0] class [System.Runtime]System.IO.StreamReader reader,
      [1] int32 n,
      [2] class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>> rp,
      [3] class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>> heap,
      [4] class [System.Collections]System.Collections.Generic.List`1<int64> l,
      [5] int64 lday,
      [6] int64 left,
      [7] int64 right,
      [8] int32 flag,
      [9] int64 k,
      [10] class [System.Runtime]System.IO.StreamWriter steam1,
      [11] int32 i,
      [12] string[] arr,
      [13] int64 day,
      [14] bool V_14,
      [15] bool V_15,
      [16] int32 q,
      [17] int64 z,
      [18] bool V_18,
      [19] bool V_19,
      [20] int64 i_V_20,
      [21] bool V_21,
      [22] bool V_22,
      [23] valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64> V_23,
      [24] bool V_24,
      [25] bool V_25,
      [26] bool V_26,
      [27] bool V_27,
      [28] bool V_28
    )

    // [126 9 - 126 10]
    IL_0000: nop

    // [127 13 - 127 66]
    IL_0001: ldstr        "input.txt"
    IL_0006: newobj       instance void [System.Runtime]System.IO.StreamReader::.ctor(string)
    IL_000b: stloc.0      // reader

    // [128 13 - 128 50]
    IL_000c: ldloc.0      // reader
    IL_000d: callvirt     instance string [System.Runtime]System.IO.TextReader::ReadLine()
    IL_0012: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0017: stloc.1      // n

    // [129 13 - 129 59]
    IL_0018: newobj       instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::.ctor()
    IL_001d: stloc.2      // rp

    // [130 13 - 130 61]
    IL_001e: newobj       instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::.ctor()
    IL_0023: stloc.3      // heap

    // [131 13 - 131 38]
    IL_0024: newobj       instance void class [System.Collections]System.Collections.Generic.List`1<int64>::.ctor()
    IL_0029: stloc.s      l

    // [133 13 - 133 27]
    IL_002b: ldc.i4.0
    IL_002c: conv.i8
    IL_002d: stloc.s      lday

    // [134 18 - 134 27]
    IL_002f: ldc.i4.0
    IL_0030: stloc.s      i

    IL_0032: br.s         IL_0093
    // start of loop, entry point: IL_0093

      // [135 13 - 135 14]
      IL_0034: nop

      // [136 17 - 136 56]
      IL_0035: ldloc.0      // reader
      IL_0036: callvirt     instance string [System.Runtime]System.IO.TextReader::ReadLine()
      IL_003b: ldc.i4.s     32 // 0x20
      IL_003d: ldc.i4.0
      IL_003e: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
      IL_0043: stloc.s      arr

      // [137 17 - 137 46]
      IL_0045: ldloc.s      arr
      IL_0047: ldc.i4.1
      IL_0048: ldelem.ref
      IL_0049: call         int32 [System.Runtime]System.Int32::Parse(string)
      IL_004e: conv.i8
      IL_004f: stloc.s      day

      // [138 17 - 138 32]
      IL_0051: ldloc.s      day
      IL_0053: ldloc.s      lday
      IL_0055: cgt
      IL_0057: stloc.s      V_14

      IL_0059: ldloc.s      V_14
      IL_005b: brfalse.s    IL_0063

      // [139 17 - 139 18]
      IL_005d: nop

      // [140 21 - 140 32]
      IL_005e: ldloc.s      day
      IL_0060: stloc.s      lday

      // [141 17 - 141 18]
      IL_0062: nop

      // [142 17 - 142 42]
      IL_0063: ldloc.s      l
      IL_0065: ldloc.s      arr
      IL_0067: ldc.i4.0
      IL_0068: ldelem.ref
      IL_0069: call         int32 [System.Runtime]System.Int32::Parse(string)
      IL_006e: conv.i8
      IL_006f: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<int64>::Add(!0/*int64*/)
      IL_0074: nop

      // [143 17 - 143 79]
      IL_0075: ldloc.2      // rp
      IL_0076: ldloc.s      day
      IL_0078: ldloc.s      arr
      IL_007a: ldc.i4.2
      IL_007b: ldelem.ref
      IL_007c: call         int64 [System.Runtime]System.Int64::Parse(string)
      IL_0081: newobj       instance void valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::.ctor(!0/*int64*/, !1/*int64*/)
      IL_0086: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::Add(!0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/)
      IL_008b: nop

      // [144 13 - 144 14]
      IL_008c: nop

      // [134 36 - 134 39]
      IL_008d: ldloc.s      i
      IL_008f: ldc.i4.1
      IL_0090: add
      IL_0091: stloc.s      i

      // [134 29 - 134 34]
      IL_0093: ldloc.s      i
      IL_0095: ldloc.1      // n
      IL_0096: clt
      IL_0098: stloc.s      V_15

      IL_009a: ldloc.s      V_15
      IL_009c: brtrue.s     IL_0034
    // end of loop

    // [145 13 - 145 44]
    IL_009e: ldloc.s      l
    IL_00a0: ldloc.2      // rp
    IL_00a1: ldc.i4.0
    IL_00a2: ldloc.s      l
    IL_00a4: callvirt     instance int32 class [System.Collections]System.Collections.Generic.List`1<int64>::get_Count()
    IL_00a9: ldc.i4.1
    IL_00aa: sub
    IL_00ab: call         class [System.Collections]System.Collections.Generic.List`1<int64> ConsoleApp3.Program::MergeSort(class [System.Collections]System.Collections.Generic.List`1<int64>, class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>, int32, int32)
    IL_00b0: pop

    // [146 13 - 146 27]
    IL_00b1: ldc.i4.0
    IL_00b2: conv.i8
    IL_00b3: stloc.s      left

    // [147 13 - 147 38]
    IL_00b5: ldc.i8       10000000000 // 0x00000002540be400
    IL_00be: stloc.s      right

    // [148 13 - 148 27]
    IL_00c0: ldc.i4.m1
    IL_00c1: stloc.s      flag

    // [149 13 - 149 25]
    IL_00c3: ldc.i4.0
    IL_00c4: conv.i8
    IL_00c5: stloc.s      k

    IL_00c7: br           IL_0282
    // start of loop, entry point: IL_0282

      // [152 13 - 152 14]
      IL_00cc: nop

      // [153 17 - 153 31]
      IL_00cd: ldloc.s      flag
      IL_00cf: ldc.i4.1
      IL_00d0: ceq
      IL_00d2: stloc.s      V_18

      IL_00d4: ldloc.s      V_18
      IL_00d6: brfalse.s    IL_00de

      // [154 17 - 154 18]
      IL_00d8: nop

      // [155 21 - 155 31]
      IL_00d9: ldloc.s      k
      IL_00db: stloc.s      right

      // [156 17 - 156 18]
      IL_00dd: nop

      // [157 17 - 157 31]
      IL_00de: ldloc.s      flag
      IL_00e0: ldc.i4.2
      IL_00e1: ceq
      IL_00e3: stloc.s      V_19

      IL_00e5: ldloc.s      V_19
      IL_00e7: brfalse.s    IL_00ef

      // [158 17 - 158 18]
      IL_00e9: nop

      // [159 21 - 159 30]
      IL_00ea: ldloc.s      k
      IL_00ec: stloc.s      left

      // [160 17 - 160 18]
      IL_00ee: nop

      // [161 17 - 161 40]
      IL_00ef: ldloc.s      left
      IL_00f1: ldloc.s      right
      IL_00f3: add
      IL_00f4: ldc.i4.2
      IL_00f5: conv.i8
      IL_00f6: div
      IL_00f7: stloc.s      k

      // [162 17 - 162 27]
      IL_00f9: ldc.i4.0
      IL_00fa: stloc.s      q

      // [163 17 - 163 28]
      IL_00fc: ldc.i4.0
      IL_00fd: conv.i8
      IL_00fe: stloc.s      z

      // [164 22 - 164 35]
      IL_0100: ldloc.s      l
      IL_0102: ldc.i4.0
      IL_0103: callvirt     instance !0/*int64*/ class [System.Collections]System.Collections.Generic.List`1<int64>::get_Item(int32)
      IL_0108: stloc.s      i_V_20

      IL_010a: br           IL_026f
      // start of loop, entry point: IL_026f

        // [165 17 - 165 18]
        IL_010f: nop

        IL_0110: br.s         IL_0129
        // start of loop, entry point: IL_0129

          // [167 21 - 167 22]
          IL_0112: nop

          // [168 25 - 168 42]
          IL_0113: ldloc.2      // rp
          IL_0114: ldloc.s      q
          IL_0116: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
          IL_011b: ldloc.3      // heap
          IL_011c: call         void ConsoleApp3.Program::'add'(valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>, class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>)
          IL_0121: nop

          // [169 25 - 169 29]
          IL_0122: ldloc.s      q
          IL_0124: ldc.i4.1
          IL_0125: add
          IL_0126: stloc.s      q

          // [170 21 - 170 22]
          IL_0128: nop

          // [166 21 - 166 53]
          IL_0129: ldloc.s      q
          IL_012b: ldloc.s      l
          IL_012d: callvirt     instance int32 class [System.Collections]System.Collections.Generic.List`1<int64>::get_Count()
          IL_0132: bge.s        IL_0143
          IL_0134: ldloc.s      i_V_20
          IL_0136: ldloc.s      l
          IL_0138: ldloc.s      q
          IL_013a: callvirt     instance !0/*int64*/ class [System.Collections]System.Collections.Generic.List`1<int64>::get_Item(int32)
          IL_013f: ceq
          IL_0141: br.s         IL_0144
          IL_0143: ldc.i4.0
          IL_0144: stloc.s      V_21

          IL_0146: ldloc.s      V_21
          IL_0148: brtrue.s     IL_0112
        // end of loop

        // [171 21 - 171 81]
        IL_014a: ldloc.3      // heap
        IL_014b: callvirt     instance int32 class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Count()
        IL_0150: ldc.i4.0
        IL_0151: ble.s        IL_017d
        IL_0153: ldloc.3      // heap
        IL_0154: ldc.i4.0
        IL_0155: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
        IL_015a: stloc.s      V_23
        IL_015c: ldloca.s     V_23
        IL_015e: call         instance !0/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Key()
        IL_0163: ldloc.s      i_V_20
        IL_0165: bne.un.s     IL_017d
        IL_0167: ldloc.3      // heap
        IL_0168: ldc.i4.0
        IL_0169: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
        IL_016e: stloc.s      V_23
        IL_0170: ldloca.s     V_23
        IL_0172: call         instance !1/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Value()
        IL_0177: ldc.i4.0
        IL_0178: conv.i8
        IL_0179: cgt
        IL_017b: br.s         IL_017e
        IL_017d: ldc.i4.0
        IL_017e: stloc.s      V_22

        IL_0180: ldloc.s      V_22
        IL_0182: brfalse.s    IL_0194

        // [172 21 - 172 22]
        IL_0184: nop

        // [173 25 - 173 34]
        IL_0185: ldc.i4.2
        IL_0186: stloc.s      flag

        // [174 25 - 174 38]
        IL_0188: ldloc.3      // heap
        IL_0189: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::Clear()
        IL_018e: nop

        // [175 25 - 175 31]
        IL_018f: br           IL_0281

        // [177 21 - 177 40]
        IL_0194: ldloc.3      // heap
        IL_0195: callvirt     instance int32 class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Count()
        IL_019a: ldc.i4.0
        IL_019b: cgt
        IL_019d: stloc.s      V_24

        IL_019f: ldloc.s      V_24
        IL_01a1: brfalse.s    IL_01d5

        // [178 21 - 178 22]
        IL_01a3: nop

        // [179 25 - 179 96]
        IL_01a4: ldloc.3      // heap
        IL_01a5: ldc.i4.0
        IL_01a6: ldloc.3      // heap
        IL_01a7: ldc.i4.0
        IL_01a8: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
        IL_01ad: stloc.s      V_23
        IL_01af: ldloca.s     V_23
        IL_01b1: call         instance !0/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Key()
        IL_01b6: ldloc.3      // heap
        IL_01b7: ldc.i4.0
        IL_01b8: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
        IL_01bd: stloc.s      V_23
        IL_01bf: ldloca.s     V_23
        IL_01c1: call         instance !1/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Value()
        IL_01c6: ldloc.s      k
        IL_01c8: sub
        IL_01c9: newobj       instance void valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::.ctor(!0/*int64*/, !1/*int64*/)
        IL_01ce: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::set_Item(int32, !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/)
        IL_01d3: nop

        // [180 21 - 180 22]
        IL_01d4: nop

        // [181 21 - 181 62]
        IL_01d5: ldloc.3      // heap
        IL_01d6: callvirt     instance int32 class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Count()
        IL_01db: ldc.i4.0
        IL_01dc: ble.s        IL_01f7
        IL_01de: ldloc.3      // heap
        IL_01df: ldc.i4.0
        IL_01e0: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
        IL_01e5: stloc.s      V_23
        IL_01e7: ldloca.s     V_23
        IL_01e9: call         instance !1/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Value()
        IL_01ee: ldc.i4.0
        IL_01ef: conv.i8
        IL_01f0: cgt
        IL_01f2: ldc.i4.0
        IL_01f3: ceq
        IL_01f5: br.s         IL_01f8
        IL_01f7: ldc.i4.0
        IL_01f8: stloc.s      V_25

        IL_01fa: ldloc.s      V_25
        IL_01fc: brfalse.s    IL_0264

        // [182 21 - 182 22]
        IL_01fe: nop

        // [183 25 - 183 52]
        IL_01ff: ldloc.3      // heap
        IL_0200: ldc.i4.0
        IL_0201: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
        IL_0206: stloc.s      V_23
        IL_0208: ldloca.s     V_23
        IL_020a: call         instance !1/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Value()
        IL_020f: ldc.i4.m1
        IL_0210: conv.i8
        IL_0211: mul
        IL_0212: stloc.s      z

        // [184 25 - 184 38]
        IL_0214: ldloc.3      // heap
        IL_0215: call         void ConsoleApp3.Program::getMax(class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>)
        IL_021a: nop

        // [185 25 - 185 39]
        IL_021b: ldloc.3      // heap
        IL_021c: call         void ConsoleApp3.Program::heapify(class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>)
        IL_0221: nop

        // [186 25 - 186 44]
        IL_0222: ldloc.3      // heap
        IL_0223: callvirt     instance int32 class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Count()
        IL_0228: ldc.i4.0
        IL_0229: cgt
        IL_022b: stloc.s      V_26

        IL_022d: ldloc.s      V_26
        IL_022f: brfalse.s    IL_0263

        // [187 25 - 187 26]
        IL_0231: nop

        // [188 29 - 188 100]
        IL_0232: ldloc.3      // heap
        IL_0233: ldc.i4.0
        IL_0234: ldloc.3      // heap
        IL_0235: ldc.i4.0
        IL_0236: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
        IL_023b: stloc.s      V_23
        IL_023d: ldloca.s     V_23
        IL_023f: call         instance !0/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Key()
        IL_0244: ldloc.3      // heap
        IL_0245: ldc.i4.0
        IL_0246: callvirt     instance !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/ class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::get_Item(int32)
        IL_024b: stloc.s      V_23
        IL_024d: ldloca.s     V_23
        IL_024f: call         instance !1/*int64*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::get_Value()
        IL_0254: ldloc.s      z
        IL_0256: sub
        IL_0257: newobj       instance void valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>::.ctor(!0/*int64*/, !1/*int64*/)
        IL_025c: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>>::set_Item(int32, !0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<int64, int64>*/)
        IL_0261: nop

        // [189 25 - 189 26]
        IL_0262: nop

        // [190 21 - 190 22]
        IL_0263: nop

        // [191 21 - 191 30]
        IL_0264: ldc.i4.1
        IL_0265: stloc.s      flag

        // [192 17 - 192 18]
        IL_0267: nop

        // [164 51 - 164 54]
        IL_0268: ldloc.s      i_V_20
        IL_026a: ldc.i4.1
        IL_026b: conv.i8
        IL_026c: add
        IL_026d: stloc.s      i_V_20

        // [164 37 - 164 49]
        IL_026f: ldloc.s      i_V_20
        IL_0271: ldloc.s      lday
        IL_0273: ldc.i4.1
        IL_0274: conv.i8
        IL_0275: add
        IL_0276: clt
        IL_0278: stloc.s      V_27

        IL_027a: ldloc.s      V_27
        IL_027c: brtrue       IL_010f
      // end of loop

      // [194 13 - 194 14]
      IL_0281: nop

      // [151 12 - 151 32]
      IL_0282: ldloc.s      left
      IL_0284: ldloc.s      right
      IL_0286: ldc.i4.1
      IL_0287: conv.i8
      IL_0288: sub
      IL_0289: clt
      IL_028b: stloc.s      V_28

      IL_028d: ldloc.s      V_28
      IL_028f: brtrue       IL_00cc
    // end of loop

    // [196 13 - 196 67]
    IL_0294: ldstr        "output.txt"
    IL_0299: newobj       instance void [System.Runtime]System.IO.StreamWriter::.ctor(string)
    IL_029e: stloc.s      steam1

    // [197 13 - 197 33]
    IL_02a0: ldloc.s      steam1
    IL_02a2: ldloc.s      right
    IL_02a4: callvirt     instance void [System.Runtime]System.IO.TextWriter::Write(int64)
    IL_02a9: nop

    // [198 13 - 198 28]
    IL_02aa: ldloc.s      steam1
    IL_02ac: callvirt     instance void [System.Runtime]System.IO.TextWriter::Flush()
    IL_02b1: nop

    // [199 9 - 199 10]
    IL_02b2: ret

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
} // end of class ConsoleApp3.Program
