// Decompiled with JetBrains decompiler
// Type: System.Collections.BlockingQueue
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System.Threading;

namespace System.Collections
{
  public class BlockingQueue : Queue
  {
    private bool open;

    public BlockingQueue(ICollection col)
      : base(col)
      => this.open = true;

    public BlockingQueue(int capacity, float growFactor)
      : base(capacity, growFactor)
      => this.open = true;

    public BlockingQueue(int capacity)
      : base(capacity)
      => this.open = true;

    public BlockingQueue() => this.open = true;

    ~BlockingQueue() => this.Close();

    public override void Clear()
    {
      lock (this.SyncRoot)
        base.Clear();
    }

    public void Close()
    {
      lock (this.SyncRoot)
      {
        this.open = false;
        base.Clear();
        Monitor.PulseAll(this.SyncRoot);
      }
    }

    public override object Dequeue() => this.Dequeue(-1);

    public object Dequeue(TimeSpan timeout) => this.Dequeue(timeout.Milliseconds);

    public object Dequeue(int timeout)
    {
      lock (this.SyncRoot)
      {
        while (this.open && this.Count == 0)
        {
          if (!Monitor.Wait(this.SyncRoot, timeout))
            throw new InvalidOperationException("Timeout");
        }
        if (this.open)
          return base.Dequeue();
        throw new InvalidOperationException("Queue Closed");
      }
    }

    public override void Enqueue(object obj)
    {
      lock (this.SyncRoot)
      {
        base.Enqueue(obj);
        Monitor.Pulse(this.SyncRoot);
      }
    }

    public void Open()
    {
      lock (this.SyncRoot)
        this.open = true;
    }

    public bool Closed => !this.open;
  }
}
