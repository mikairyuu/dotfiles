// Type: Solution1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 33F64886-F0BA-460E-AEE3-115DC3FCABC2
// Location: /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.dll
// Sequence point data from /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.pdb

.class private auto ansi beforefieldinit
  Solution1.Program
    extends [System.Runtime]System.Object
{

  .method private hidebysig static void
    Main(
      string[] args
    ) cil managed
  {
    .entrypoint
    .maxstack 2
    .locals init (
      [0] int32 n,
      [1] class [System.Collections]System.Collections.Generic.List`1<string> l,
      [2] int32 i,
      [3] bool V_3
    )

    // [9 9 - 9 10]
    IL_0000: nop

    // [10 13 - 10 51]
    IL_0001: call         string [System.Console]System.Console::ReadLine()
    IL_0006: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_000b: stloc.0      // n

    // [11 13 - 11 40]
    IL_000c: newobj       instance void class [System.Collections]System.Collections.Generic.List`1<string>::.ctor()
    IL_0011: stloc.1      // l

    // [12 18 - 12 27]
    IL_0012: ldc.i4.0
    IL_0013: stloc.2      // i

    IL_0014: br.s         IL_0028
    // start of loop, entry point: IL_0028

      // [13 13 - 13 14]
      IL_0016: nop

      // [14 17 - 14 43]
      IL_0017: ldloc.1      // l
      IL_0018: call         string [System.Console]System.Console::ReadLine()
      IL_001d: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<string>::Add(!0/*string*/)
      IL_0022: nop

      // [15 13 - 15 14]
      IL_0023: nop

      // [12 36 - 12 39]
      IL_0024: ldloc.2      // i
      IL_0025: ldc.i4.1
      IL_0026: add
      IL_0027: stloc.2      // i

      // [12 29 - 12 34]
      IL_0028: ldloc.2      // i
      IL_0029: ldloc.0      // n
      IL_002a: clt
      IL_002c: stloc.3      // V_3

      IL_002d: ldloc.3      // V_3
      IL_002e: brtrue.s     IL_0016
    // end of loop

    // [17 13 - 17 22]
    IL_0030: ldloc.1      // l
    IL_0031: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<string>::Sort()
    IL_0036: nop

    // [18 13 - 18 37]
    IL_0037: ldloc.1      // l
    IL_0038: ldc.i4.0
    IL_0039: callvirt     instance !0/*string*/ class [System.Collections]System.Collections.Generic.List`1<string>::get_Item(int32)
    IL_003e: call         void [System.Console]System.Console::WriteLine(string)
    IL_0043: nop

    // [19 9 - 19 10]
    IL_0044: ret

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
} // end of class Solution1.Program
