using System;
using TextFilter.Events;
using TextFilter.Interfaces;

namespace TextFilter.Models
{
    public abstract class ReaderAbstract : IReader
    {
        public abstract void ReadLines();
        public event EventHandler<LineReadEventArgs> LineRead;
        protected virtual void OnLineRead(string line)
        {
            var lineReadEvent = new LineReadEventArgs()
            {
                Line = line
            };
            LineRead?.Invoke(this, lineReadEvent);
        }
    }
}