using System;
using System.Collections.Generic;
using System.IO;

namespace RSVPLibrary
{
    public class RSVPProcessor
    {
        private List<string> words;
        private int currentIndex;

        public RSVPProcessor()
        {
            words = new List<string>();
            currentIndex = 0;
        }

        /// <summary>
        /// Inputs new text data. Can either overwrite or append to the current data.
        /// </summary>
        /// <param name="text">The text to input.</param>
        /// <param name="append">If true, appends to current data; otherwise, overwrites.</param>
        public void InputText(string text, bool append = false)
        {
            // If not appending, clear the existing words
            if (!append)
            {
                words.Clear();
                currentIndex = 0;
            }

            // Split text into words and add to the list
            var newWords = text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            words.AddRange(newWords);
        }

        /// <summary>
        /// Inputs new text data from a file. Can either overwrite or append to the current data.
        /// </summary>
        /// <param name="filePath">The path of the file to read from.</param>
        /// <param name="append">If true, appends to current data; otherwise, overwrites.</param>
        public void InputFile(string filePath, bool append = false)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file does not exist.", filePath);

            string text = File.ReadAllText(filePath);
            InputText(text, append);
        }

        /// <summary>
        /// Retrieves the next word in the sequence.
        /// </summary>
        /// <returns>The next word, or null if no more words are available.</returns>
        public string Next()
        {
            if (currentIndex < words.Count)
            {
                return words[currentIndex++];
            }
            else
            {
                return null; // No more words available
            }
        }

        /// <summary>
        /// Clears all stored text data.
        /// </summary>
        public void Clear()
        {
            words.Clear();
            currentIndex = 0;
        }

        /// <summary>
        /// Resets the reading index to start from the beginning of the words.
        /// </summary>
        public void Reset()
        {
            currentIndex = 0;
        }

        /// <summary>
        /// Gets the total number of words in the current data.
        /// </summary>
        public int WordCount => words.Count;

        /// <summary>
        /// Gets the current index of the word being processed.
        /// </summary>
        public int CurrentIndex => currentIndex;
    }
}
