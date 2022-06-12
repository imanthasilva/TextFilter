using System.Collections.Generic;
using TextFilter.Models;

namespace TextFilter.Interfaces
{
    public interface IWorker
    {
        void Process();
        List<Word> GetWordsSeparated(string line);
    }
}