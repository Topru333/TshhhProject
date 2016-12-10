using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PaSaver
{
    class VigenerCoder
    {
        public VigenerCoder(ArrayList Keys)
        {
            
            this.keys = Keys;
        }
        #region Алфавиты
        private static char[] characters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
                                                'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                                                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z','А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ь',
                                                'Э', 'Ю', 'Я',
                                                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
                                                'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ',
                                                'э', 'ю', 'я','1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0', ' ', '@', '!', '$', '|', '_', '-', '.', ','};
        #endregion
        private int N = characters.Length;
        private ArrayList keys;
        /// <summary>
        /// Метод шифрования 
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="key">Ключ шифровки</param>
        /// <returns>Зашифрованная строка</returns>
        public string Encode(string input, string key)
        {
            string result = "";
            int key_index = 0;
            
            foreach (char symbol in input)
            {
                //int.TryParse(symbol)

                int c = (Array.IndexOf(characters, symbol) + Array.IndexOf(characters, key[key_index])) % N;
                result += characters[c];
                if ((key_index + 1) == key.Length) key_index = 0;
                key_index++;
            }
            return result; 
        }
        public string MultiEncode(string input)
        {
            if (keys.Count > 0)
            {
                foreach (string k in keys.ToArray())
                {
                    input = Encode(input, k);
                }
            }
            return input;
        }
        /// <summary>
        /// Метод расшифровки
        /// </summary>
        /// <param name="input">Строка которую нужно расш.</param>
        /// <param name="key">Ключ шифровки</param>
        /// <returns>Расшифрованная строка</returns>
        public string Decode(string input, string key)
        {
            string result = "";
            int key_index = 0;

            foreach(char symbol in input)
            {
                int p = ((Array.IndexOf(characters, symbol) + N) - Array.IndexOf(characters, key[key_index])) % N;
                result += characters[p];
                if ((key_index + 1) == key.Length) key_index = 0;
                key_index++;
            }
            return result;
        }
        public string MultiDecode(string input)
        {
            if (keys.Count > 0)
            {
                foreach (string k in keys.ToArray().Reverse())
                {
                    input = Decode(input, k);
                }
            }
            return input;
        }

    }
}
