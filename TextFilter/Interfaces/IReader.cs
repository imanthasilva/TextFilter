using System;
using TextFilter.Events;

namespace TextFilter.Interfaces
{
    public interface IReader
    {
        void ReadLines();
        event EventHandler<LineReadEventArgs> LineRead;
    }
}