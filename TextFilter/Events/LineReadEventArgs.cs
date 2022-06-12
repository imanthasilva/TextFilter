using System;

namespace TextFilter.Events
{
    public class LineReadEventArgs : EventArgs
    {
        public string Line { get; set; }
    }
}