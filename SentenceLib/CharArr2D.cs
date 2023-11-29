using System.Text.RegularExpressions;

namespace SentenceLib
{
    /// <summary>
    /// Class to save sentence in char array of arrays.
    /// </summary>
    public class CharArr2D
    {
        // Private char array of arrays.
        private char[][] _charArr;

        /// <summary>
        /// Constructor with string signature.
        /// </summary>
        /// <param name="sentence">String to convert into char array of arrays.</param>
        /// <exception cref="ArgumentException">Wrong Sentence.</exception>
        public CharArr2D(String sentence)
        {
            char[][] charArr;

            // Check input data on correcting.
            if (!Help.TryToCharArr(sentence, out charArr) || !Help.IsCorrect(charArr))
                throw new ArgumentException("Invalid sentence");

            _charArr = charArr;
        }
        /// <summary>
        /// Consteructor with array of char arrays.
        /// </summary>
        /// <param name="charArr">Array to copy.</param>
        /// <exception cref="ArgumentException">Wrong array.</exception>
        public CharArr2D(char[][] charArr)
        {
            // Check input data on correcting.
            if (!Help.IsCorrect(charArr))
                throw new ArgumentException("Invalid sentence");

            _charArr = new char[charArr.Length][];
            charArr.CopyTo(_charArr, 0);
        }
        /// <summary>
        /// Find words that not include constants.
        /// </summary>
        /// <returns>Words that not include consotants</returns>
        public char[][] NotConsonants()
        {
            bool[] isCons = new bool[_charArr.Length];

            // Count consonants words.
            int resLenght = 0;
            for(int i = 0; i < _charArr.Length; i++)
            {
                bool isCorrect = true;
                for(int j = 0; j < _charArr[i].Length; j++)
                    isCorrect &= !Help.Consonants.Contains(_charArr[i][j]);
                
                isCons[i] = isCorrect;

                resLenght += isCorrect ? 1 : 0;
            }

            char[][] res = new char[resLenght][];
            int curIndex = 0;

            // Save consonants words.
            for(int i = 0; i < _charArr.Length; i++)
            {
                if (isCons[i])
                {
                    res[curIndex] = _charArr[i];
                    curIndex++;
                }
            }

            return res;
        }

        /// <summary>
        /// Lenght of array.
        /// </summary>
        /// <returns>Lenght of array.</returns>
        public int Lenght() => _charArr.Length;

        /// <summary>
        /// Override toString.
        /// </summary>
        /// <returns>Sentence</returns>
        public override string ToString()
        {
            string res = " ";
            foreach (char[] a in _charArr)
            {
                foreach(char c in a)
                    res += c;

                res += " ";
            }

            return res.Trim(' ')+". ";
        }
    }

    /// <summary>
    /// class help CharArr2D to work with data.
    /// </summary>
    class Help
    {
        // Consonants in English Alphabet.
        public static char[] Consonants = { 'a', 'e', 'u', 'i', 'o', 'A', 'E', 'U', 'I', 'O' };

        /// <summary>
        /// Try convert to char array.
        /// </summary>
        /// <param name="sentence">sentence to convert.</param>
        /// <param name="charArr" converted array.></param>
        /// <returns>Is operation good.</returns>
        public static bool TryToCharArr(string sentence, out char[][] charArr)
        {
            // Find double spaces.
            for (int i = 0; i < Math.Log2(sentence.Length); i++)
                sentence = sentence.Replace("  ", "1");


            string[] arr = sentence.TrimEnd('.').Split(' ');

            charArr = new char[arr.Length][];

            for(int i = 0; i < arr.Length; i++)
                charArr[i] = arr[i].ToCharArray();

            // Is last char is dot.
            return sentence[^1] == '.';
        }

        /// <summary>
        /// Check sentence to correct.
        /// </summary>
        /// <param name="sentence"> Sentence to check.</param>
        /// <returns>Is correct.</returns>
        public static bool IsCorrect(char[][] sentence)
        {
            bool isCorrect = true;

            for(int i = 0; i < sentence.Length; i++)
                for(int j = 0; j < sentence[i].Length; j++)
                    isCorrect &= Regex.IsMatch(Convert.ToString(sentence[i][j]), "^[a-zA-Z]*$");

            return isCorrect;
        }
    }
}


