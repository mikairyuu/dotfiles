// Type: ConsoleApp1.Triple 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1798D927-15FE-4B81-B4C0-74C7B19DFAEC
// Location: /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.dll
// Sequence point data from /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.pdb

.class private auto ansi beforefieldinit
  ConsoleApp1.Triple
    extends [System.Runtime]System.Object
{

  .field public int32 a

  .field public int32 b

  .field public char c

  .method public hidebysig specialname rtspecialname instance void
    .ctor(
      int32 a,
      int32 b,
      char c
    ) cil managed
  {
    .maxstack 8

    // [13 9 - 13 44]
    IL_0000: ldarg.0      // this
    IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
    IL_0006: nop

    // [14 9 - 14 10]
    IL_0007: nop

    // [15 13 - 15 24]
    IL_0008: ldarg.0      // this
    IL_0009: ldarg.1      // a
    IL_000a: stfld        int32 ConsoleApp1.Triple::a

    // [16 13 - 16 24]
    IL_000f: ldarg.0      // this
    IL_0010: ldarg.2      // b
    IL_0011: stfld        int32 ConsoleApp1.Triple::b

    // [17 13 - 17 24]
    IL_0016: ldarg.0      // this
    IL_0017: ldarg.3      // c
    IL_0018: stfld        char ConsoleApp1.Triple::c

    // [18 9 - 18 10]
    IL_001d: ret

  } // end of method Triple::.ctor
} // end of class ConsoleApp1.Triple
