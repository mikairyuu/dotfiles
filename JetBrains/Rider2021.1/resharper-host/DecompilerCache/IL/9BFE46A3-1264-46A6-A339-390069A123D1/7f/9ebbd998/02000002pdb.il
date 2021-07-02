// Type: ConsoleApp1.Program 
// Assembly: Solution1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BFE46A3-1264-46A6-A339-390069A123D1
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

    .field public static class [System.Runtime]System.Func`3<char, char, bool> '<>9__0_0'

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
      '<compare>b__0_0'(
        char x,
        char y
      ) cil managed
    {
      .maxstack 8

      // [12 51 - 12 57]
      IL_0000: ldarg.1      // x
      IL_0001: ldarg.2      // y
      IL_0002: ceq
      IL_0004: ret

    } // end of method '<>c'::'<compare>b__0_0'
  } // end of class '<>c'

  .method private hidebysig static bool
    compare(
      valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32> entry,
      string test
    ) cil managed
  {
    .maxstack 4
    .locals init (
      [0] class [System.Runtime]System.Collections.Generic.IEnumerable`1<bool> a,
      [1] bool V_1
    )

    // [11 9 - 11 10]
    IL_0000: nop

    // [12 13 - 12 59]
    IL_0001: ldarga.s     entry
    IL_0003: call         instance !0/*string*/ valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>::get_Key()
    IL_0008: ldarg.1      // test
    IL_0009: ldsfld       class [System.Runtime]System.Func`3<char, char, bool> ConsoleApp1.Program/'<>c'::'<>9__0_0'
    IL_000e: dup
    IL_000f: brtrue.s     IL_0028
    IL_0011: pop
    IL_0012: ldsfld       class ConsoleApp1.Program/'<>c' ConsoleApp1.Program/'<>c'::'<>9'
    IL_0017: ldftn        instance bool ConsoleApp1.Program/'<>c'::'<compare>b__0_0'(char, char)
    IL_001d: newobj       instance void class [System.Runtime]System.Func`3<char, char, bool>::.ctor(object, native int)
    IL_0022: dup
    IL_0023: stsfld       class [System.Runtime]System.Func`3<char, char, bool> ConsoleApp1.Program/'<>c'::'<>9__0_0'
    IL_0028: call         class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!2/*bool*/> [System.Linq]System.Linq.Enumerable::Zip<char, char, bool>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0/*char*/>, class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!1/*char*/>, class [System.Runtime]System.Func`3<!!0/*char*/, !!1/*char*/, !!2/*bool*/>)
    IL_002d: stloc.0      // a

    // [14 13 - 14 25]
    IL_002e: ldc.i4.1
    IL_002f: stloc.1      // V_1
    IL_0030: br.s         IL_0032

    // [15 9 - 15 10]
    IL_0032: ldloc.1      // V_1
    IL_0033: ret

  } // end of method Program::compare

  .method private hidebysig static void
    Main(
      string[] args
    ) cil managed
  {
    .entrypoint
    .maxstack 3
    .locals init (
      [0] class [System.Runtime]System.IO.StreamReader sr,
      [1] class [System.Runtime]System.IO.StreamWriter sw,
      [2] string[] buf,
      [3] int32 p,
      [4] int32 q,
      [5] class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>> list,
      [6] int32 i,
      [7] bool V_7
    )

    // [18 9 - 18 10]
    IL_0000: nop

    // [19 13 - 19 52]
    IL_0001: ldstr        "input.txt"
    IL_0006: newobj       instance void [System.Runtime]System.IO.StreamReader::.ctor(string)
    IL_000b: stloc.0      // sr

    // [20 13 - 20 53]
    IL_000c: ldstr        "output.txt"
    IL_0011: newobj       instance void [System.Runtime]System.IO.StreamWriter::.ctor(string)
    IL_0016: stloc.1      // sw

    // [21 13 - 21 48]
    IL_0017: ldloc.0      // sr
    IL_0018: callvirt     instance string [System.Runtime]System.IO.TextReader::ReadLine()
    IL_001d: ldc.i4.s     32 // 0x20
    IL_001f: ldc.i4.0
    IL_0020: callvirt     instance string[] [System.Runtime]System.String::Split(char, valuetype [System.Runtime]System.StringSplitOptions)
    IL_0025: stloc.2      // buf

    // [22 13 - 22 39]
    IL_0026: ldloc.2      // buf
    IL_0027: ldc.i4.0
    IL_0028: ldelem.ref
    IL_0029: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_002e: stloc.3      // p

    // [23 13 - 23 39]
    IL_002f: ldloc.2      // buf
    IL_0030: ldc.i4.1
    IL_0031: ldelem.ref
    IL_0032: call         int32 [System.Runtime]System.Int32::Parse(string)
    IL_0037: stloc.s      q

    // [24 13 - 24 62]
    IL_0039: newobj       instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>>::.ctor()
    IL_003e: stloc.s      list

    // [25 18 - 25 27]
    IL_0040: ldc.i4.0
    IL_0041: stloc.s      i

    IL_0043: br.s         IL_0069
    // start of loop, entry point: IL_0069

      // [26 17 - 26 98]
      IL_0045: ldloc.s      list
      IL_0047: ldloc.0      // sr
      IL_0048: callvirt     instance string [System.Runtime]System.IO.TextReader::ReadLine()
      IL_004d: ldloc.0      // sr
      IL_004e: callvirt     instance string [System.Runtime]System.IO.TextReader::ReadLine()
      IL_0053: call         int32 [System.Runtime]System.Int32::Parse(string)
      IL_0058: newobj       instance void valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>::.ctor(!0/*string*/, !1/*int32*/)
      IL_005d: callvirt     instance void class [System.Collections]System.Collections.Generic.List`1<valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>>::Add(!0/*valuetype [System.Runtime]System.Collections.Generic.KeyValuePair`2<string, int32>*/)
      IL_0062: nop

      // [25 36 - 25 39]
      IL_0063: ldloc.s      i
      IL_0065: ldc.i4.1
      IL_0066: add
      IL_0067: stloc.s      i

      // [25 29 - 25 34]
      IL_0069: ldloc.s      i
      IL_006b: ldloc.3      // p
      IL_006c: clt
      IL_006e: stloc.s      V_7

      IL_0070: ldloc.s      V_7
      IL_0072: brtrue.s     IL_0045
    // end of loop

    // [27 9 - 27 10]
    IL_0074: ret

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
