// Decompiled with JetBrains decompiler
// Type: System.IO.StreamWriter
// Assembly: System.Private.CoreLib, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// MVID: BA9E6474-B363-4C3C-9080-A30AE164265D
// Assembly location: /usr/share/dotnet/shared/Microsoft.NETCore.App/5.0.6/System.Private.CoreLib.dll

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


#nullable enable
namespace System.IO
{
  public class StreamWriter : TextWriter
  {
    public static readonly StreamWriter Null = new StreamWriter(Stream.Null, StreamWriter.UTF8NoBOM, 128, true);

    #nullable disable
    private readonly Stream _stream;
    private readonly Encoding _encoding;
    private readonly Encoder _encoder;
    private readonly byte[] _byteBuffer;
    private readonly char[] _charBuffer;
    private int _charPos;
    private int _charLen;
    private bool _autoFlush;
    private bool _haveWrittenPreamble;
    private readonly bool _closable;
    private bool _disposed;
    private Task _asyncWriteTask = Task.CompletedTask;

    private void CheckAsyncTaskInProgress()
    {
      if (this._asyncWriteTask.IsCompleted)
        return;
      StreamWriter.ThrowAsyncIOInProgress();
    }

    [DoesNotReturn]
    private static void ThrowAsyncIOInProgress() => throw new InvalidOperationException(SR.InvalidOperation_AsyncIOInProgress);


    #nullable enable
    private static Encoding UTF8NoBOM => EncodingCache.UTF8NoBOM;

    public StreamWriter(Stream stream)
      : this(stream, StreamWriter.UTF8NoBOM, 1024, false)
    {
    }

    public StreamWriter(Stream stream, Encoding encoding)
      : this(stream, encoding, 1024, false)
    {
    }

    public StreamWriter(Stream stream, Encoding encoding, int bufferSize)
      : this(stream, encoding, bufferSize, false)
    {
    }

    public StreamWriter(Stream stream, Encoding? encoding = null, int bufferSize = -1, bool leaveOpen = false)
      : base((IFormatProvider) null)
    {
      if (stream == null)
        throw new ArgumentNullException(nameof (stream));
      if (encoding == null)
        encoding = StreamWriter.UTF8NoBOM;
      if (!stream.CanWrite)
        throw new ArgumentException(SR.Argument_StreamNotWritable);
      if (bufferSize == -1)
        bufferSize = 1024;
      else if (bufferSize <= 0)
        throw new ArgumentOutOfRangeException(nameof (bufferSize), SR.ArgumentOutOfRange_NeedPosNum);
      this._stream = stream;
      this._encoding = encoding;
      this._encoder = this._encoding.GetEncoder();
      if (bufferSize < 128)
        bufferSize = 128;
      this._charBuffer = new char[bufferSize];
      this._byteBuffer = new byte[this._encoding.GetMaxByteCount(bufferSize)];
      this._charLen = bufferSize;
      if (this._stream.CanSeek && this._stream.Position > 0L)
        this._haveWrittenPreamble = true;
      this._closable = !leaveOpen;
    }

    public StreamWriter(string path)
      : this(path, false, StreamWriter.UTF8NoBOM, 1024)
    {
    }

    public StreamWriter(string path, bool append)
      : this(path, append, StreamWriter.UTF8NoBOM, 1024)
    {
    }

    public StreamWriter(string path, bool append, Encoding encoding)
      : this(path, append, encoding, 1024)
    {
    }

    public StreamWriter(string path, bool append, Encoding encoding, int bufferSize)
      : this(StreamWriter.ValidateArgsAndOpenPath(path, append, encoding, bufferSize), encoding, bufferSize, false)
    {
    }


    #nullable disable
    private static Stream ValidateArgsAndOpenPath(
      string path,
      bool append,
      Encoding encoding,
      int bufferSize)
    {
      if (path == null)
        throw new ArgumentNullException(nameof (path));
      if (encoding == null)
        throw new ArgumentNullException(nameof (encoding));
      if (path.Length == 0)
        throw new ArgumentException(SR.Argument_EmptyPath);
      if (bufferSize <= 0)
        throw new ArgumentOutOfRangeException(nameof (bufferSize), SR.ArgumentOutOfRange_NeedPosNum);
      return (Stream) new FileStream(path, append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.Read, 4096, FileOptions.SequentialScan);
    }

    public override void Close()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!(!this._disposed & disposing))
          return;
        this.CheckAsyncTaskInProgress();
        this.Flush(true, true);
      }
      finally
      {
        this.CloseStreamFromDispose(disposing);
      }
    }

    private void CloseStreamFromDispose(bool disposing)
    {
      if (!this._closable)
        return;
      if (this._disposed)
        return;
      try
      {
        if (!disposing)
          return;
        this._stream.Close();
      }
      finally
      {
        this._disposed = true;
        this._charLen = 0;
        base.Dispose(disposing);
      }
    }

    public override ValueTask DisposeAsync() => !(this.GetType() != typeof (StreamWriter)) ? this.DisposeAsyncCore() : base.DisposeAsync();

    private async ValueTask DisposeAsyncCore()
    {
      StreamWriter streamWriter = this;
      try
      {
        if (!streamWriter._disposed)
          await streamWriter.FlushAsync().ConfigureAwait(false);
      }
      finally
      {
        streamWriter.CloseStreamFromDispose(true);
      }
      GC.SuppressFinalize((object) streamWriter);
    }

    public override void Flush()
    {
      this.CheckAsyncTaskInProgress();
      this.Flush(true, true);
    }

    private void Flush(bool flushStream, bool flushEncoder)
    {
      this.ThrowIfDisposed();
      if (this._charPos == 0 && !flushStream && !flushEncoder)
        return;
      if (!this._haveWrittenPreamble)
      {
        this._haveWrittenPreamble = true;
        ReadOnlySpan<byte> preamble = this._encoding.Preamble;
        if (preamble.Length > 0)
          this._stream.Write(preamble);
      }
      int bytes = this._encoder.GetBytes(this._charBuffer, 0, this._charPos, this._byteBuffer, 0, flushEncoder);
      this._charPos = 0;
      if (bytes > 0)
        this._stream.Write(this._byteBuffer, 0, bytes);
      if (!flushStream)
        return;
      this._stream.Flush();
    }

    public virtual bool AutoFlush
    {
      get => this._autoFlush;
      set
      {
        this.CheckAsyncTaskInProgress();
        this._autoFlush = value;
        if (!value)
          return;
        this.Flush(true, false);
      }
    }


    #nullable enable
    public virtual Stream BaseStream => this._stream;

    public override Encoding Encoding => this._encoding;

    public override void Write(char value)
    {
      this.CheckAsyncTaskInProgress();
      if (this._charPos == this._charLen)
        this.Flush(false, false);
      this._charBuffer[this._charPos] = value;
      ++this._charPos;
      if (!this._autoFlush)
        return;
      this.Flush(true, false);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Write(char[]? buffer) => this.WriteSpan((ReadOnlySpan<char>) buffer, false);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Write(char[] buffer, int index, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer), SR.ArgumentNull_Buffer);
      if (index < 0)
        throw new ArgumentOutOfRangeException(nameof (index), SR.ArgumentOutOfRange_NeedNonNegNum);
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), SR.ArgumentOutOfRange_NeedNonNegNum);
      if (buffer.Length - index < count)
        throw new ArgumentException(SR.Argument_InvalidOffLen);
      this.WriteSpan((ReadOnlySpan<char>) buffer.AsSpan<char>(index, count), false);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Write(ReadOnlySpan<char> buffer)
    {
      if (this.GetType() == typeof (StreamWriter))
        this.WriteSpan(buffer, false);
      else
        base.Write(buffer);
    }


    #nullable disable
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private unsafe void WriteSpan(ReadOnlySpan<char> buffer, bool appendNewLine)
    {
      this.CheckAsyncTaskInProgress();
      if (buffer.Length <= 4 && buffer.Length <= this._charLen - this._charPos)
      {
        for (int index = 0; index < buffer.Length; ++index)
          this._charBuffer[this._charPos++] = buffer[index];
      }
      else
      {
        this.ThrowIfDisposed();
        char[] charBuffer = this._charBuffer;
        fixed (char* chPtr1 = &MemoryMarshal.GetReference<char>(buffer))
          fixed (char* chPtr2 = &charBuffer[0])
          {
            char* chPtr3 = chPtr1;
            int length = buffer.Length;
            int num1 = this._charPos;
            int num2;
            for (; length > 0; length -= num2)
            {
              if (num1 == charBuffer.Length)
              {
                this.Flush(false, false);
                num1 = 0;
              }
              num2 = Math.Min(charBuffer.Length - num1, length);
              int num3 = num2 * 2;
              Buffer.MemoryCopy((void*) chPtr3, (void*) (chPtr2 + num1), (long) num3, (long) num3);
              this._charPos += num2;
              num1 += num2;
              chPtr3 += num2;
            }
          }
      }
      if (appendNewLine)
      {
        foreach (char ch in this.CoreNewLine)
        {
          if (this._charPos == this._charLen)
            this.Flush(false, false);
          this._charBuffer[this._charPos] = ch;
          ++this._charPos;
        }
      }
      if (!this._autoFlush)
        return;
      this.Flush(true, false);
    }


    #nullable enable
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Write(string? value) => this.WriteSpan((ReadOnlySpan<char>) value, false);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void WriteLine(string? value)
    {
      this.CheckAsyncTaskInProgress();
      this.WriteSpan((ReadOnlySpan<char>) value, true);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void WriteLine(ReadOnlySpan<char> value)
    {
      if (this.GetType() == typeof (StreamWriter))
      {
        this.CheckAsyncTaskInProgress();
        this.WriteSpan(value, true);
      }
      else
        base.WriteLine(value);
    }


    #nullable disable
    private void WriteFormatHelper(string format, ParamsArray args, bool appendNewLine)
    {
      StringBuilder sb = StringBuilderCache.Acquire((format != null ? format.Length : 0) + args.Length * 8).AppendFormatHelper((IFormatProvider) null, format, args);
      StringBuilder.ChunkEnumerator chunks = sb.GetChunks();
      bool flag = chunks.MoveNext();
      while (flag)
      {
        ReadOnlySpan<char> span = chunks.Current.Span;
        flag = chunks.MoveNext();
        this.WriteSpan(span, !flag && appendNewLine);
      }
      StringBuilderCache.Release(sb);
    }


    #nullable enable
    public override void Write(string format, object? arg0)
    {
      if (this.GetType() == typeof (StreamWriter))
        this.WriteFormatHelper(format, new ParamsArray(arg0), false);
      else
        base.Write(format, arg0);
    }

    public override void Write(string format, object? arg0, object? arg1)
    {
      if (this.GetType() == typeof (StreamWriter))
        this.WriteFormatHelper(format, new ParamsArray(arg0, arg1), false);
      else
        base.Write(format, arg0, arg1);
    }

    public override void Write(string format, object? arg0, object? arg1, object? arg2)
    {
      if (this.GetType() == typeof (StreamWriter))
        this.WriteFormatHelper(format, new ParamsArray(arg0, arg1, arg2), false);
      else
        base.Write(format, arg0, arg1, arg2);
    }

    public override void Write(string format, params object?[] arg)
    {
      if (this.GetType() == typeof (StreamWriter))
      {
        if (arg == null)
          throw new ArgumentNullException(format == null ? nameof (format) : nameof (arg));
        this.WriteFormatHelper(format, new ParamsArray(arg), false);
      }
      else
        base.Write(format, arg);
    }

    public override void WriteLine(string format, object? arg0)
    {
      if (this.GetType() == typeof (StreamWriter))
        this.WriteFormatHelper(format, new ParamsArray(arg0), true);
      else
        base.WriteLine(format, arg0);
    }

    public override void WriteLine(string format, object? arg0, object? arg1)
    {
      if (this.GetType() == typeof (StreamWriter))
        this.WriteFormatHelper(format, new ParamsArray(arg0, arg1), true);
      else
        base.WriteLine(format, arg0, arg1);
    }

    public override void WriteLine(string format, object? arg0, object? arg1, object? arg2)
    {
      if (this.GetType() == typeof (StreamWriter))
        this.WriteFormatHelper(format, new ParamsArray(arg0, arg1, arg2), true);
      else
        base.WriteLine(format, arg0, arg1, arg2);
    }

    public override void WriteLine(string format, params object?[] arg)
    {
      if (this.GetType() == typeof (StreamWriter))
      {
        if (arg == null)
          throw new ArgumentNullException(nameof (arg));
        this.WriteFormatHelper(format, new ParamsArray(arg), true);
      }
      else
        base.WriteLine(format, arg);
    }

    public override Task WriteAsync(char value)
    {
      if (this.GetType() != typeof (StreamWriter))
        return base.WriteAsync(value);
      this.ThrowIfDisposed();
      this.CheckAsyncTaskInProgress();
      Task task = StreamWriter.WriteAsyncInternal(this, value, this._charBuffer, this._charPos, this._charLen, this.CoreNewLine, this._autoFlush, false);
      this._asyncWriteTask = task;
      return task;
    }


    #nullable disable
    private static async Task WriteAsyncInternal(
      StreamWriter _this,
      char value,
      char[] charBuffer,
      int charPos,
      int charLen,
      char[] coreNewLine,
      bool autoFlush,
      bool appendNewLine)
    {
      ConfiguredTaskAwaitable configuredTaskAwaitable;
      if (charPos == charLen)
      {
        configuredTaskAwaitable = _this.FlushAsyncInternal(false, false, charBuffer, charPos).ConfigureAwait(false);
        await configuredTaskAwaitable;
        charPos = 0;
      }
      charBuffer[charPos] = value;
      ++charPos;
      if (appendNewLine)
      {
        for (int i = 0; i < coreNewLine.Length; ++i)
        {
          if (charPos == charLen)
          {
            configuredTaskAwaitable = _this.FlushAsyncInternal(false, false, charBuffer, charPos).ConfigureAwait(false);
            await configuredTaskAwaitable;
            charPos = 0;
          }
          charBuffer[charPos] = coreNewLine[i];
          ++charPos;
        }
      }
      if (autoFlush)
      {
        configuredTaskAwaitable = _this.FlushAsyncInternal(true, false, charBuffer, charPos).ConfigureAwait(false);
        await configuredTaskAwaitable;
        charPos = 0;
      }
      _this._charPos = charPos;
    }


    #nullable enable
    public override Task WriteAsync(string? value)
    {
      if (this.GetType() != typeof (StreamWriter))
        return base.WriteAsync(value);
      if (value == null)
        return Task.CompletedTask;
      this.ThrowIfDisposed();
      this.CheckAsyncTaskInProgress();
      Task task = StreamWriter.WriteAsyncInternal(this, value, this._charBuffer, this._charPos, this._charLen, this.CoreNewLine, this._autoFlush, false);
      this._asyncWriteTask = task;
      return task;
    }


    #nullable disable
    private static async Task WriteAsyncInternal(
      StreamWriter _this,
      string value,
      char[] charBuffer,
      int charPos,
      int charLen,
      char[] coreNewLine,
      bool autoFlush,
      bool appendNewLine)
    {
      int count = value.Length;
      int index = 0;
      int count1;
      for (; count > 0; count -= count1)
      {
        if (charPos == charLen)
        {
          await _this.FlushAsyncInternal(false, false, charBuffer, charPos).ConfigureAwait(false);
          charPos = 0;
        }
        count1 = charLen - charPos;
        if (count1 > count)
          count1 = count;
        value.CopyTo(index, charBuffer, charPos, count1);
        charPos += count1;
        index += count1;
      }
      if (appendNewLine)
      {
        for (int i = 0; i < coreNewLine.Length; ++i)
        {
          if (charPos == charLen)
          {
            await _this.FlushAsyncInternal(false, false, charBuffer, charPos).ConfigureAwait(false);
            charPos = 0;
          }
          charBuffer[charPos] = coreNewLine[i];
          ++charPos;
        }
      }
      if (autoFlush)
      {
        await _this.FlushAsyncInternal(true, false, charBuffer, charPos).ConfigureAwait(false);
        charPos = 0;
      }
      _this._charPos = charPos;
    }


    #nullable enable
    public override Task WriteAsync(char[] buffer, int index, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer), SR.ArgumentNull_Buffer);
      if (index < 0)
        throw new ArgumentOutOfRangeException(nameof (index), SR.ArgumentOutOfRange_NeedNonNegNum);
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), SR.ArgumentOutOfRange_NeedNonNegNum);
      if (buffer.Length - index < count)
        throw new ArgumentException(SR.Argument_InvalidOffLen);
      if (this.GetType() != typeof (StreamWriter))
        return base.WriteAsync(buffer, index, count);
      this.ThrowIfDisposed();
      this.CheckAsyncTaskInProgress();
      Task task = StreamWriter.WriteAsyncInternal(this, new ReadOnlyMemory<char>(buffer, index, count), this._charBuffer, this._charPos, this._charLen, this.CoreNewLine, this._autoFlush, false, new CancellationToken());
      this._asyncWriteTask = task;
      return task;
    }

    public override Task WriteAsync(
      ReadOnlyMemory<char> buffer,
      CancellationToken cancellationToken = default (CancellationToken))
    {
      if (this.GetType() != typeof (StreamWriter))
        return base.WriteAsync(buffer, cancellationToken);
      this.ThrowIfDisposed();
      this.CheckAsyncTaskInProgress();
      if (cancellationToken.IsCancellationRequested)
        return Task.FromCanceled(cancellationToken);
      Task task = StreamWriter.WriteAsyncInternal(this, buffer, this._charBuffer, this._charPos, this._charLen, this.CoreNewLine, this._autoFlush, false, cancellationToken);
      this._asyncWriteTask = task;
      return task;
    }


    #nullable disable
    private static async Task WriteAsyncInternal(
      StreamWriter _this,
      ReadOnlyMemory<char> source,
      char[] charBuffer,
      int charPos,
      int charLen,
      char[] coreNewLine,
      bool autoFlush,
      bool appendNewLine,
      CancellationToken cancellationToken)
    {
      ConfiguredTaskAwaitable configuredTaskAwaitable;
      int length;
      for (int copied = 0; copied < source.Length; copied += length)
      {
        if (charPos == charLen)
        {
          configuredTaskAwaitable = _this.FlushAsyncInternal(false, false, charBuffer, charPos, cancellationToken).ConfigureAwait(false);
          await configuredTaskAwaitable;
          charPos = 0;
        }
        length = Math.Min(charLen - charPos, source.Length - copied);
        ReadOnlySpan<char> readOnlySpan = source.Span;
        readOnlySpan = readOnlySpan.Slice(copied, length);
        readOnlySpan.CopyTo(new Span<char>(charBuffer, charPos, length));
        charPos += length;
      }
      if (appendNewLine)
      {
        for (int i = 0; i < coreNewLine.Length; ++i)
        {
          if (charPos == charLen)
          {
            configuredTaskAwaitable = _this.FlushAsyncInternal(false, false, charBuffer, charPos, cancellationToken).ConfigureAwait(false);
            await configuredTaskAwaitable;
            charPos = 0;
          }
          charBuffer[charPos] = coreNewLine[i];
          ++charPos;
        }
      }
      if (autoFlush)
      {
        configuredTaskAwaitable = _this.FlushAsyncInternal(true, false, charBuffer, charPos, cancellationToken).ConfigureAwait(false);
        await configuredTaskAwaitable;
        charPos = 0;
      }
      _this._charPos = charPos;
    }


    #nullable enable
    public override Task WriteLineAsync()
    {
      if (this.GetType() != typeof (StreamWriter))
        return base.WriteLineAsync();
      this.ThrowIfDisposed();
      this.CheckAsyncTaskInProgress();
      Task task = StreamWriter.WriteAsyncInternal(this, ReadOnlyMemory<char>.Empty, this._charBuffer, this._charPos, this._charLen, this.CoreNewLine, this._autoFlush, true, new CancellationToken());
      this._asyncWriteTask = task;
      return task;
    }

    public override Task WriteLineAsync(char value)
    {
      if (this.GetType() != typeof (StreamWriter))
        return base.WriteLineAsync(value);
      this.ThrowIfDisposed();
      this.CheckAsyncTaskInProgress();
      Task task = StreamWriter.WriteAsyncInternal(this, value, this._charBuffer, this._charPos, this._charLen, this.CoreNewLine, this._autoFlush, true);
      this._asyncWriteTask = task;
      return task;
    }

    public override Task WriteLineAsync(string? value)
    {
      if (value == null)
        return this.WriteLineAsync();
      if (this.GetType() != typeof (StreamWriter))
        return base.WriteLineAsync(value);
      this.ThrowIfDisposed();
      this.CheckAsyncTaskInProgress();
      Task task = StreamWriter.WriteAsyncInternal(this, value, this._charBuffer, this._charPos, this._charLen, this.CoreNewLine, this._autoFlush, true);
      this._asyncWriteTask = task;
      return task;
    }

    public override Task WriteLineAsync(char[] buffer, int index, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer), SR.ArgumentNull_Buffer);
      if (index < 0)
        throw new ArgumentOutOfRangeException(nameof (index), SR.ArgumentOutOfRange_NeedNonNegNum);
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), SR.ArgumentOutOfRange_NeedNonNegNum);
      if (buffer.Length - index < count)
        throw new ArgumentException(SR.Argument_InvalidOffLen);
      if (this.GetType() != typeof (StreamWriter))
        return base.WriteLineAsync(buffer, index, count);
      this.ThrowIfDisposed();
      this.CheckAsyncTaskInProgress();
      Task task = StreamWriter.WriteAsyncInternal(this, new ReadOnlyMemory<char>(buffer, index, count), this._charBuffer, this._charPos, this._charLen, this.CoreNewLine, this._autoFlush, true, new CancellationToken());
      this._asyncWriteTask = task;
      return task;
    }

    public override Task WriteLineAsync(
      ReadOnlyMemory<char> buffer,
      CancellationToken cancellationToken = default (CancellationToken))
    {
      if (this.GetType() != typeof (StreamWriter))
        return base.WriteLineAsync(buffer, cancellationToken);
      this.ThrowIfDisposed();
      this.CheckAsyncTaskInProgress();
      if (cancellationToken.IsCancellationRequested)
        return Task.FromCanceled(cancellationToken);
      Task task = StreamWriter.WriteAsyncInternal(this, buffer, this._charBuffer, this._charPos, this._charLen, this.CoreNewLine, this._autoFlush, true, cancellationToken);
      this._asyncWriteTask = task;
      return task;
    }

    public override Task FlushAsync()
    {
      if (this.GetType() != typeof (StreamWriter))
        return base.FlushAsync();
      this.ThrowIfDisposed();
      this.CheckAsyncTaskInProgress();
      Task task = this.FlushAsyncInternal(true, true, this._charBuffer, this._charPos);
      this._asyncWriteTask = task;
      return task;
    }


    #nullable disable
    private Task FlushAsyncInternal(
      bool flushStream,
      bool flushEncoder,
      char[] sCharBuffer,
      int sCharPos,
      CancellationToken cancellationToken = default (CancellationToken))
    {
      if (cancellationToken.IsCancellationRequested)
        return Task.FromCanceled(cancellationToken);
      if (sCharPos == 0 && !flushStream && !flushEncoder)
        return Task.CompletedTask;
      Task task = StreamWriter.FlushAsyncInternal(this, flushStream, flushEncoder, sCharBuffer, sCharPos, this._haveWrittenPreamble, this._encoding, this._encoder, this._byteBuffer, this._stream, cancellationToken);
      this._charPos = 0;
      return task;
    }

    private static async Task FlushAsyncInternal(
      StreamWriter _this,
      bool flushStream,
      bool flushEncoder,
      char[] charBuffer,
      int charPos,
      bool haveWrittenPreamble,
      Encoding encoding,
      Encoder encoder,
      byte[] byteBuffer,
      Stream stream,
      CancellationToken cancellationToken)
    {
      if (!haveWrittenPreamble)
      {
        _this._haveWrittenPreamble = true;
        byte[] preamble = encoding.GetPreamble();
        if (preamble.Length != 0)
          await stream.WriteAsync(new ReadOnlyMemory<byte>(preamble), cancellationToken).ConfigureAwait(false);
      }
      int bytes = encoder.GetBytes(charBuffer, 0, charPos, byteBuffer, 0, flushEncoder);
      if (bytes > 0)
        await stream.WriteAsync(new ReadOnlyMemory<byte>(byteBuffer, 0, bytes), cancellationToken).ConfigureAwait(false);
      if (!flushStream)
        return;
      await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }

    private void ThrowIfDisposed()
    {
      if (!this._disposed)
        return;
      ThrowObjectDisposedException();

      void ThrowObjectDisposedException() => throw new ObjectDisposedException(this.GetType().Name, SR.ObjectDisposed_WriterClosed);
    }
  }
}
