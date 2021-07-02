// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 88FA2759-4F0C-4D83-9C98-C3FFF4A02AFA
// Location: /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.dll
// Sequence point data from /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.pdb

.class private auto ansi beforefieldinit
  ConsoleApp1.Program
    extends [System.Runtime]System.Object
{

  .method private hidebysig static int32
    GetNod(
      int32 val1,
      int32 val2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool V_0,
      [1] bool V_1,
      [2] int32 V_2
    )

    // [8 9 - 8 10]
    IL_0000: nop

    IL_0001: br.s         IL_0019
    // start of loop, entry point: IL_0019

      // [10 13 - 10 14]
      IL_0003: nop

      // [11 17 - 11 33]
      IL_0004: ldarg.0      // val1
      IL_0005: ldarg.1      // val2
      IL_0006: cgt
      IL_0008: stloc.0      // V_0

      IL_0009: ldloc.0      // V_0
      IL_000a: brfalse.s    IL_0013

      // [12 21 - 12 34]
      IL_000c: ldarg.0      // val1
      IL_000d: ldarg.1      // val2
      IL_000e: sub
      IL_000f: starg.s      val1

      IL_0011: br.s         IL_0018

      // [14 21 - 14 34]
      IL_0013: ldarg.1      // val2
      IL_0014: ldarg.0      // val1
      IL_0015: sub
      IL_0016: starg.s      val2

      // [15 13 - 15 14]
      IL_0018: nop

      // [9 13 - 9 47]
      IL_0019: ldarg.0      // val1
      IL_001a: brfalse.s    IL_0022
      IL_001c: ldarg.1      // val2
      IL_001d: ldc.i4.0
      IL_001e: cgt.un
      IL_0020: br.s         IL_0023
      IL_0022: ldc.i4.0
      IL_0023: stloc.1      // V_1

      IL_0024: ldloc.1      // V_1
      IL_0025: brtrue.s     IL_0003
    // end of loop

    // [17 13 - 17 41]
    IL_0027: ldarg.0      // val1
    IL_0028: ldarg.1      // val2
    IL_0029: call         int32 [System.Runtime]System.Math::Max(int32, int32)
    IL_002e: stloc.2      // V_2
    IL_002f: br.s         IL_0031

    // [18 9 - 18 10]
    IL_0031: ldloc.2      // V_2
    IL_0032: ret

  } // end of method Program::GetNod

  .method private hidebysig static void
    Main(
      string[] args
    ) cil managed
  {
    .entrypoint
    .maxstack 6
    .locals init (
      [0] string[] arr
    )

    // [21 9 - 21 10]
    IL_0000: nop

    // [22 13 - 22 53]
    IL_0001: call         string [System.Console]System.Console::ReadLine()
    IL_0006: ldc.i4.s     32 // 0x20
    IL_0008: ldc.i4.0
    IL_0009: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_000e: stloc.0      // arr

    // [23 13 - 23 172]
    IL_000f: ldstr        "{0} {1} {2}"
    IL_0014: ldloc.0      // arr
    IL_0015: ldc.i4.0
    IL_0016: ldelem.ref
    IL_0017: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_001c: ldloc.0      // arr
    IL_001d: ldc.i4.1
    IL_001e: ldelem.ref
    IL_001f: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0024: call         int32 ConsoleApp1.Program::GetNod(int32, int32)
    IL_0029: box          [System.Runtime]System.Int32
    IL_002e: ldloc.0      // arr
    IL_002f: ldc.i4.0
    IL_0030: ldelem.ref
    IL_0031: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0036: ldloc.0      // arr
    IL_0037: ldc.i4.2
    IL_0038: ldelem.ref
    IL_0039: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_003e: call         int32 ConsoleApp1.Program::GetNod(int32, int32)
    IL_0043: box          [System.Runtime]System.Int32
    IL_0048: ldloc.0      // arr
    IL_0049: ldc.i4.1
    IL_004a: ldelem.ref
    IL_004b: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0050: ldloc.0      // arr
    IL_0051: ldc.i4.2
    IL_0052: ldelem.ref
    IL_0053: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0058: call         int32 ConsoleApp1.Program::GetNod(int32, int32)
    IL_005d: box          [System.Runtime]System.Int32
    IL_0062: call         string [System.Runtime]System.String::Format(string, object, object, object)
    IL_0067: call         void [System.Console]System.Console::Write(string)
    IL_006c: nop

    // [25 9 - 25 10]
    IL_006d: ret

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
