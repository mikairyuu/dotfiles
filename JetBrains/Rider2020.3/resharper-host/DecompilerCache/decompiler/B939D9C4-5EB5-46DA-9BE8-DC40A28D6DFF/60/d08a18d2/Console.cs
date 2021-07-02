// Decompiled with JetBrains decompiler
// Type: System.Console
// Assembly: System.Console, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: B939D9C4-5EB5-46DA-9BE8-DC40A28D6DFF
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.3/System.Console.dll

using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;


#nullable enable
namespace System
{
  public static class Console
  {
    private static readonly 
    #nullable disable
    object s_syncObject = new object();
    private static TextReader s_in;
    private static TextWriter s_out;
    private static TextWriter s_error;
    private static Encoding s_inputEncoding;
    private static Encoding s_outputEncoding;
    private static bool s_isOutTextWriterRedirected;
    private static bool s_isErrorTextWriterRedirected;
    private static ConsoleCancelEventHandler s_cancelCallbacks;
    private static ConsolePal.ControlCHandlerRegistrar s_registrar;
    private static StrongBox<bool> _isStdInRedirected;
    private static StrongBox<bool> _isStdOutRedirected;
    private static StrongBox<bool> _isStdErrRedirected;

    [UnsupportedOSPlatform("browser")]
    public static 
    #nullable enable
    TextReader In
    {
      get
      {
        return Volatile.Read<TextReader>(ref Console.s_in) ?? EnsureInitialized();

        static 
        #nullable disable
        TextReader EnsureInitialized()
        {
          ConsolePal.EnsureConsoleInitialized();
          lock (Console.s_syncObject)
          {
            if (Console.s_in == null)
              Volatile.Write<TextReader>(ref Console.s_in, ConsolePal.GetOrCreateReader());
            return Console.s_in;
          }
        }
      }
    }

    [UnsupportedOSPlatform("browser")]
    public static 
    #nullable enable
    Encoding InputEncoding
    {
      get
      {
        Encoding encoding = Volatile.Read<Encoding>(ref Console.s_inputEncoding);
        if (encoding == null)
        {
          lock (Console.s_syncObject)
          {
            if (Console.s_inputEncoding == null)
              Volatile.Write<Encoding>(ref Console.s_inputEncoding, ConsolePal.InputEncoding);
            encoding = Console.s_inputEncoding;
          }
        }
        return encoding;
      }
      set
      {
        Console.CheckNonNull((object) value, nameof (value));
        lock (Console.s_syncObject)
        {
          ConsolePal.SetConsoleInputEncoding(value);
          Volatile.Write<Encoding>(ref Console.s_inputEncoding, (Encoding) value.Clone());
          Volatile.Write<TextReader>(ref Console.s_in, (TextReader) null);
        }
      }
    }

    public static Encoding OutputEncoding
    {
      get
      {
        Encoding encoding = Volatile.Read<Encoding>(ref Console.s_outputEncoding);
        if (encoding == null)
        {
          lock (Console.s_syncObject)
          {
            if (Console.s_outputEncoding == null)
              Volatile.Write<Encoding>(ref Console.s_outputEncoding, ConsolePal.OutputEncoding);
            encoding = Console.s_outputEncoding;
          }
        }
        return encoding;
      }
      set
      {
        Console.CheckNonNull((object) value, nameof (value));
        lock (Console.s_syncObject)
        {
          ConsolePal.SetConsoleOutputEncoding(value);
          if (Console.s_out != null && !Console.s_isOutTextWriterRedirected)
          {
            Console.s_out.Flush();
            Volatile.Write<TextWriter>(ref Console.s_out, (TextWriter) null);
          }
          if (Console.s_error != null && !Console.s_isErrorTextWriterRedirected)
          {
            Console.s_error.Flush();
            Volatile.Write<TextWriter>(ref Console.s_error, (TextWriter) null);
          }
          Volatile.Write<Encoding>(ref Console.s_outputEncoding, (Encoding) value.Clone());
        }
      }
    }

    public static bool KeyAvailable
    {
      get
      {
        if (Console.IsInputRedirected)
          throw new InvalidOperationException(SR.InvalidOperation_ConsoleKeyAvailableOnFile);
        return ConsolePal.KeyAvailable;
      }
    }

    [UnsupportedOSPlatform("browser")]
    public static ConsoleKeyInfo ReadKey() => ConsolePal.ReadKey(false);

    [UnsupportedOSPlatform("browser")]
    public static ConsoleKeyInfo ReadKey(bool intercept) => ConsolePal.ReadKey(intercept);

    public static TextWriter Out
    {
      get
      {
        return Volatile.Read<TextWriter>(ref Console.s_out) ?? EnsureInitialized();

        static 
        #nullable disable
        TextWriter EnsureInitialized()
        {
          lock (Console.s_syncObject)
          {
            if (Console.s_out == null)
              Volatile.Write<TextWriter>(ref Console.s_out, Console.CreateOutputWriter(Console.OpenStandardOutput()));
            return Console.s_out;
          }
        }
      }
    }

    public static 
    #nullable enable
    TextWriter Error
    {
      get
      {
        return Volatile.Read<TextWriter>(ref Console.s_error) ?? EnsureInitialized();

        static 
        #nullable disable
        TextWriter EnsureInitialized()
        {
          lock (Console.s_syncObject)
          {
            if (Console.s_error == null)
              Volatile.Write<TextWriter>(ref Console.s_error, Console.CreateOutputWriter(Console.OpenStandardError()));
            return Console.s_error;
          }
        }
      }
    }

    private static TextWriter CreateOutputWriter(Stream outputStream)
    {
      StreamWriter streamWriter;
      if (outputStream != Stream.Null)
        streamWriter = new StreamWriter(outputStream, Console.OutputEncoding.RemovePreamble(), 256, true)
        {
          AutoFlush = true
        };
      else
        streamWriter = StreamWriter.Null;
      return TextWriter.Synchronized((TextWriter) streamWriter);
    }

    public static bool IsInputRedirected
    {
      get
      {
        return (Volatile.Read<StrongBox<bool>>(ref Console._isStdInRedirected) ?? EnsureInitialized()).Value;

        static StrongBox<bool> EnsureInitialized()
        {
          Volatile.Write<StrongBox<bool>>(ref Console._isStdInRedirected, new StrongBox<bool>(ConsolePal.IsInputRedirectedCore()));
          return Console._isStdInRedirected;
        }
      }
    }

    public static bool IsOutputRedirected
    {
      get
      {
        return (Volatile.Read<StrongBox<bool>>(ref Console._isStdOutRedirected) ?? EnsureInitialized()).Value;

        static StrongBox<bool> EnsureInitialized()
        {
          Volatile.Write<StrongBox<bool>>(ref Console._isStdOutRedirected, new StrongBox<bool>(ConsolePal.IsOutputRedirectedCore()));
          return Console._isStdOutRedirected;
        }
      }
    }

    public static bool IsErrorRedirected
    {
      get
      {
        return (Volatile.Read<StrongBox<bool>>(ref Console._isStdErrRedirected) ?? EnsureInitialized()).Value;

        static StrongBox<bool> EnsureInitialized()
        {
          Volatile.Write<StrongBox<bool>>(ref Console._isStdErrRedirected, new StrongBox<bool>(ConsolePal.IsErrorRedirectedCore()));
          return Console._isStdErrRedirected;
        }
      }
    }

    public static int CursorSize
    {
      [UnsupportedOSPlatform("browser")] get => ConsolePal.CursorSize;
      [SupportedOSPlatform("windows")] set => ConsolePal.CursorSize = value;
    }

    [SupportedOSPlatform("windows")]
    public static bool NumberLock => ConsolePal.NumberLock;

    [SupportedOSPlatform("windows")]
    public static bool CapsLock => ConsolePal.CapsLock;

    [UnsupportedOSPlatform("browser")]
    public static ConsoleColor BackgroundColor
    {
      get => ConsolePal.BackgroundColor;
      set => ConsolePal.BackgroundColor = value;
    }

    [UnsupportedOSPlatform("browser")]
    public static ConsoleColor ForegroundColor
    {
      get => ConsolePal.ForegroundColor;
      set => ConsolePal.ForegroundColor = value;
    }

    [UnsupportedOSPlatform("browser")]
    public static void ResetColor() => ConsolePal.ResetColor();

    public static int BufferWidth
    {
      [UnsupportedOSPlatform("browser")] get => ConsolePal.BufferWidth;
      [SupportedOSPlatform("windows")] set => ConsolePal.BufferWidth = value;
    }

    public static int BufferHeight
    {
      [UnsupportedOSPlatform("browser")] get => ConsolePal.BufferHeight;
      [SupportedOSPlatform("windows")] set => ConsolePal.BufferHeight = value;
    }

    [SupportedOSPlatform("windows")]
    public static void SetBufferSize(int width, int height) => ConsolePal.SetBufferSize(width, height);

    public static int WindowLeft
    {
      get => ConsolePal.WindowLeft;
      [SupportedOSPlatform("windows")] set => ConsolePal.WindowLeft = value;
    }

    public static int WindowTop
    {
      get => ConsolePal.WindowTop;
      [SupportedOSPlatform("windows")] set => ConsolePal.WindowTop = value;
    }

    public static int WindowWidth
    {
      [UnsupportedOSPlatform("browser")] get => ConsolePal.WindowWidth;
      [SupportedOSPlatform("windows")] set => ConsolePal.WindowWidth = value;
    }

    public static int WindowHeight
    {
      [UnsupportedOSPlatform("browser")] get => ConsolePal.WindowHeight;
      [SupportedOSPlatform("windows")] set => ConsolePal.WindowHeight = value;
    }

    [SupportedOSPlatform("windows")]
    public static void SetWindowPosition(int left, int top) => ConsolePal.SetWindowPosition(left, top);

    [SupportedOSPlatform("windows")]
    public static void SetWindowSize(int width, int height) => ConsolePal.SetWindowSize(width, height);

    [UnsupportedOSPlatform("browser")]
    public static int LargestWindowWidth => ConsolePal.LargestWindowWidth;

    [UnsupportedOSPlatform("browser")]
    public static int LargestWindowHeight => ConsolePal.LargestWindowHeight;

    public static bool CursorVisible
    {
      [SupportedOSPlatform("windows")] get => ConsolePal.CursorVisible;
      [UnsupportedOSPlatform("browser")] set => ConsolePal.CursorVisible = value;
    }

    [UnsupportedOSPlatform("browser")]
    public static int CursorLeft
    {
      get => ConsolePal.GetCursorPosition().Left;
      set => Console.SetCursorPosition(value, Console.CursorTop);
    }

    [UnsupportedOSPlatform("browser")]
    public static int CursorTop
    {
      get => ConsolePal.GetCursorPosition().Top;
      set => Console.SetCursorPosition(Console.CursorLeft, value);
    }

    [UnsupportedOSPlatform("browser")]
    public static (int Left, int Top) GetCursorPosition() => ConsolePal.GetCursorPosition();

    public static 
    #nullable enable
    string Title
    {
      [SupportedOSPlatform("windows")] get => ConsolePal.Title;
      [UnsupportedOSPlatform("browser")] set => ConsolePal.Title = value ?? throw new ArgumentNullException(nameof (value));
    }

    [UnsupportedOSPlatform("browser")]
    public static void Beep() => ConsolePal.Beep();

    [SupportedOSPlatform("windows")]
    public static void Beep(int frequency, int duration) => ConsolePal.Beep(frequency, duration);

    [SupportedOSPlatform("windows")]
    public static void MoveBufferArea(
      int sourceLeft,
      int sourceTop,
      int sourceWidth,
      int sourceHeight,
      int targetLeft,
      int targetTop)
    {
      ConsolePal.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, ' ', ConsoleColor.Black, Console.BackgroundColor);
    }

    [SupportedOSPlatform("windows")]
    public static void MoveBufferArea(
      int sourceLeft,
      int sourceTop,
      int sourceWidth,
      int sourceHeight,
      int targetLeft,
      int targetTop,
      char sourceChar,
      ConsoleColor sourceForeColor,
      ConsoleColor sourceBackColor)
    {
      ConsolePal.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);
    }

    public static void Clear() => ConsolePal.Clear();

    [UnsupportedOSPlatform("browser")]
    public static void SetCursorPosition(int left, int top)
    {
      if (left < 0 || left >= (int) short.MaxValue)
        throw new ArgumentOutOfRangeException(nameof (left), (object) left, SR.ArgumentOutOfRange_ConsoleBufferBoundaries);
      if (top < 0 || top >= (int) short.MaxValue)
        throw new ArgumentOutOfRangeException(nameof (top), (object) top, SR.ArgumentOutOfRange_ConsoleBufferBoundaries);
      ConsolePal.SetCursorPosition(left, top);
    }

    [UnsupportedOSPlatform("browser")]
    public static event ConsoleCancelEventHandler? CancelKeyPress
    {
      add
      {
        ConsolePal.EnsureConsoleInitialized();
        lock (Console.s_syncObject)
        {
          Console.s_cancelCallbacks += value;
          if (Console.s_registrar != null)
            return;
          Console.s_registrar = new ConsolePal.ControlCHandlerRegistrar();
          Console.s_registrar.Register();
        }
      }
      remove
      {
        lock (Console.s_syncObject)
        {
          Console.s_cancelCallbacks -= value;
          if (Console.s_registrar == null || Console.s_cancelCallbacks != null)
            return;
          Console.s_registrar.Unregister();
          Console.s_registrar = (ConsolePal.ControlCHandlerRegistrar) null;
        }
      }
    }

    [UnsupportedOSPlatform("browser")]
    public static bool TreatControlCAsInput
    {
      get => ConsolePal.TreatControlCAsInput;
      set => ConsolePal.TreatControlCAsInput = value;
    }

    [UnsupportedOSPlatform("browser")]
    public static Stream OpenStandardInput() => ConsolePal.OpenStandardInput();

    [UnsupportedOSPlatform("browser")]
    public static Stream OpenStandardInput(int bufferSize)
    {
      if (bufferSize < 0)
        throw new ArgumentOutOfRangeException(nameof (bufferSize), SR.ArgumentOutOfRange_NeedNonNegNum);
      return Console.OpenStandardInput();
    }

    public static Stream OpenStandardOutput() => ConsolePal.OpenStandardOutput();

    public static Stream OpenStandardOutput(int bufferSize)
    {
      if (bufferSize < 0)
        throw new ArgumentOutOfRangeException(nameof (bufferSize), SR.ArgumentOutOfRange_NeedNonNegNum);
      return Console.OpenStandardOutput();
    }

    public static Stream OpenStandardError() => ConsolePal.OpenStandardError();

    public static Stream OpenStandardError(int bufferSize)
    {
      if (bufferSize < 0)
        throw new ArgumentOutOfRangeException(nameof (bufferSize), SR.ArgumentOutOfRange_NeedNonNegNum);
      return Console.OpenStandardError();
    }

    [UnsupportedOSPlatform("browser")]
    public static void SetIn(TextReader newIn)
    {
      Console.CheckNonNull((object) newIn, nameof (newIn));
      newIn = (TextReader) SyncTextReader.GetSynchronizedTextReader(newIn);
      lock (Console.s_syncObject)
        Volatile.Write<TextReader>(ref Console.s_in, newIn);
    }

    public static void SetOut(TextWriter newOut)
    {
      Console.CheckNonNull((object) newOut, nameof (newOut));
      newOut = TextWriter.Synchronized(newOut);
      lock (Console.s_syncObject)
      {
        Console.s_isOutTextWriterRedirected = true;
        Volatile.Write<TextWriter>(ref Console.s_out, newOut);
      }
    }

    public static void SetError(TextWriter newError)
    {
      Console.CheckNonNull((object) newError, nameof (newError));
      newError = TextWriter.Synchronized(newError);
      lock (Console.s_syncObject)
      {
        Console.s_isErrorTextWriterRedirected = true;
        Volatile.Write<TextWriter>(ref Console.s_error, newError);
      }
    }

    private static void CheckNonNull(
    #nullable disable
    object obj, string paramName)
    {
      if (obj == null)
        throw new ArgumentNullException(paramName);
    }

    [UnsupportedOSPlatform("browser")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Read() => Console.In.Read();

    [UnsupportedOSPlatform("browser")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static 
    #nullable enable
    string? ReadLine() => Console.In.ReadLine();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine() => Console.Out.WriteLine();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(bool value) => Console.Out.WriteLine(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(char value) => Console.Out.WriteLine(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(char[]? buffer) => Console.Out.WriteLine(buffer);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(char[] buffer, int index, int count) => Console.Out.WriteLine(buffer, index, count);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(Decimal value) => Console.Out.WriteLine(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(double value) => Console.Out.WriteLine(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(float value) => Console.Out.WriteLine(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(int value) => Console.Out.WriteLine(value);

    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(uint value) => Console.Out.WriteLine(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(long value) => Console.Out.WriteLine(value);

    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(ulong value) => Console.Out.WriteLine(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(object? value) => Console.Out.WriteLine(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(string? value) => Console.Out.WriteLine(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(string format, object? arg0) => Console.Out.WriteLine(format, arg0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(string format, object? arg0, object? arg1) => Console.Out.WriteLine(format, arg0, arg1);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(string format, object? arg0, object? arg1, object? arg2) => Console.Out.WriteLine(format, arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void WriteLine(string format, params object?[]? arg)
    {
      if (arg == null)
        Console.Out.WriteLine(format, (object) null, (object) null);
      else
        Console.Out.WriteLine(format, arg);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(string format, object? arg0) => Console.Out.Write(format, arg0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(string format, object? arg0, object? arg1) => Console.Out.Write(format, arg0, arg1);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(string format, object? arg0, object? arg1, object? arg2) => Console.Out.Write(format, arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(string format, params object?[]? arg)
    {
      if (arg == null)
        Console.Out.Write(format, (object) null, (object) null);
      else
        Console.Out.Write(format, arg);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(bool value) => Console.Out.Write(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(char value) => Console.Out.Write(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(char[]? buffer) => Console.Out.Write(buffer);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(char[] buffer, int index, int count) => Console.Out.Write(buffer, index, count);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(double value) => Console.Out.Write(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(Decimal value) => Console.Out.Write(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(float value) => Console.Out.Write(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(int value) => Console.Out.Write(value);

    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(uint value) => Console.Out.Write(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(long value) => Console.Out.Write(value);

    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(ulong value) => Console.Out.Write(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(object? value) => Console.Out.Write(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Write(string? value) => Console.Out.Write(value);

    internal static bool HandleBreakEvent(ConsoleSpecialKey controlKey)
    {
      ConsoleCancelEventHandler cancelCallbacks = Console.s_cancelCallbacks;
      if (cancelCallbacks == null)
        return false;
      ConsoleCancelEventArgs e = new ConsoleCancelEventArgs(controlKey);
      cancelCallbacks((object) null, e);
      return e.Cancel;
    }
  }
}
