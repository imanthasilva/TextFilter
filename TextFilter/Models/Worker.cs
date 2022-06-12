using System;
using System.Collections.Generic;
using System.Linq;
using TextFilter.Events;
using TextFilter.ExtensionMethods;
using TextFilter.Interfaces;

namespace TextFilter.Models
{
    public class Worker : IWorker
    {
        private readonly IReader _reader;
        private readonly IEnumerable<IFilter> _filters;

        public Worker(IReader reader, IEnumerable<IFilter> filters)
        {
            _reader = reader;
            _filters = filters;
        }
        public void Process()
        {
            _reader.LineRead += OnLineRead;
            _reader.ReadLines();
        }
        private void OnLineRead(object sender, LineReadEventArgs e)
        {
            var words = GetWordsSeparated(e.Line);
            //PrintFullOutput(words);
            PrintFilteredOutput(words);
        }

        private void PrintFilteredOutput(List<Word> words)
        {
            foreach (var word in words)
            {
                if (word.IsWord)
                {
                    var filteredWord = ApplyFilters(word.Text);
                    if (!filteredWord.Equals(string.Empty))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(word.Text);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(word.Text);
                }
            }
            Console.WriteLine();
        }

        private void PrintFullOutput(List<Word> words)
        {
            foreach (var word in words)
            {
                if (word.IsWord)
                {
                    var filteredWord = ApplyFilters(word.Text);
                    if (filteredWord.Equals(string.Empty))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(word.Text);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(word.Text);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(word.Text);
                }
            }
            Console.WriteLine();
        }

        //This will algorithm will not pick up words similar to it's , that's etc as one word.
        public List<Word> GetWordsSeparated(string line)
        {
            List<Word> words = new List<Word>();
            var word = new List<char>();

            foreach (var c in line)
            {
                if (c.IsEnglishLetter())
                {
                    if (word.All(x => x.IsEnglishLetter()))
                    {
                        word.Add(c);
                    }
                    else
                    {
                        var newWord = new string(word.ToArray());
                        words.Add(new Word()
                        {
                            Text = newWord,
                            IsWord = false
                        });
                        word.Clear();
                        word.Add(c);
                    }
                }
                else
                {
                    if (word.All(x => x.IsEnglishLetter()))
                    {
                        var newWord = new string(word.ToArray());

                        words.Add(new Word()
                        {
                            Text = newWord,
                            IsWord = true
                        });
                        word.Clear();
                        word.Add(c);
                    }
                    else
                    {
                        word.Add(c);
                    }
                }
            }

            //add last word to list
            var lastWord = new string(word.ToArray());
            words.Add(new Word()
            {
                Text = lastWord,
                IsWord = lastWord.All(x => x.IsEnglishLetter())
            });
           
            return words;
        }

        public string ApplyFilters(string word)
        {
            foreach (var filter in _filters)
            {
                if (!word.Equals(string.Empty))
                {
                    word = filter.FilterWord(word);
                }
            }
            return word;
        }
    }
}