// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6928EBB3-4E3B-4A9F-B9CE-473FCFCDACD3
// Location: /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.dll
// Sequence point data from /home/gohan/RiderProjects/Solution1/Solution1/bin/Debug/net5.0/Solution1.pdb

.class private auto ansi beforefieldinit
  ConsoleApp1.Program
    extends [System.Runtime]System.Object
{

  .class nested private sealed auto ansi serializable beforefieldinit
    '<>c'
      extends [System.Runtime]System.Object
  {
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
      = (01 00 00 00 )

    .field public static initonly class ConsoleApp1.Program/'<>c' '<>9'

    .field public static class [System.Runtime]System.Func`2<string, bool> '<>9__0_0'

    .method private hidebysig static specialname rtspecialname void
      .cctor() cil managed
    {
      .maxstack 8

      IL_0000: newobj       instance void ConsoleApp1.Program/'<>c'::.ctor()
      IL_0005: stsfld       class ConsoleApp1.Program/'<>c' ConsoleApp1.Program/'<>c'::'<>9'
      IL_000a: ret

    } // end of method '<>c'::.cctor

    .method public hidebysig specialname rtspecialname instance void
      .ctor() cil managed
    {
      .maxstack 8

      IL_0000: ldarg.0      // this
      IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
      IL_0006: nop
      IL_0007: ret

    } // end of method '<>c'::.ctor

    .method assembly hidebysig instance bool
      '<Main>b__0_0'(
        string i
      ) cil managed
    {
      .maxstack 8

      // [12 35 - 12 54]
      IL_0000: ldarg.1      // i
      IL_0001: ldc.i4.0
      IL_0002: callvirt     instance char [System.Runtime]System.String::get_Chars(int32)
      IL_0007: call         bool [System.Runtime]System.Char::IsLetter(char)
      IL_000c: ret

    } // end of method '<>c'::'<Main>b__0_0'
  } // end of class '<>c'

  .method private hidebysig static void
    Main(
      string[] args
    ) cil managed
  {
    .entrypoint
    .maxstack 3
    .locals init (
      [0] string s,
      [1] string[] sb,
      [2] int32 t
    )

    // [9 9 - 9 10]
    IL_0000: nop

    // [10 13 - 10 40]
    IL_0001: call         string [System.Console]System.Console::ReadLine()
    IL_0006: stloc.0      // s

    // [11 13 - 11 35]
    IL_0007: ldloc.0      // s
    IL_0008: ldstr        " "
    IL_000d: ldc.i4.0
    IL_000e: callvirt     instance string[] [System.Runtime]System.String::Split(string, valuetype [System.Runtime]System.StringSplitOptions)
    IL_0013: stloc.1      // sb

    // [12 13 - 12 56]
    IL_0014: ldloc.1      // sb
    IL_0015: ldsfld       class [System.Runtime]System.Func`2<string, bool> ConsoleApp1.Program/'<>c'::'<>9__0_0'
    IL_001a: dup
    IL_001b: brtrue.s     IL_0034
    IL_001d: pop
    IL_001e: ldsfld       class ConsoleApp1.Program/'<>c' ConsoleApp1.Program/'<>c'::'<>9'
    IL_0023: ldftn        instance bool ConsoleApp1.Program/'<>c'::'<Main>b__0_0'(string)
    IL_0029: newobj       instance void class [System.Runtime]System.Func`2<string, bool>::.ctor(object, native int)
    IL_002e: dup
    IL_002f: stsfld       class [System.Runtime]System.Func`2<string, bool> ConsoleApp1.Program/'<>c'::'<>9__0_0'
    IL_0034: call         int32 [System.Linq]System.Linq.Enumerable::Count<string>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0/*string*/>, class [System.Runtime]System.Func`2<!!0/*string*/, bool>)
    IL_0039: stloc.2      // t

    // [13 13 - 13 30]
    IL_003a: ldloc.2      // t
    IL_003b: call         void [System.Console]System.Console::Write(int32)
    IL_0040: nop

    // [14 9 - 14 10]
    IL_0041: ret

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
