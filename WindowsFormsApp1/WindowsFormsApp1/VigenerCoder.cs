using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coders
{
    class VigenerCoder
    {
        public VigenerCoder()
        {
            characters = SummCharacters(SummCharacters(charactersEng, charactersRus), charactersSym);
        }
        #region Алфавиты
        public static char[] Characters
        {
            get { return characters; }
            set {; }
        }
        private static char[] characters;
        private static char[] charactersEng = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
                                                'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                                                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        private static char[] charactersRus = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я',
                                                'а', 'б', 'в', 'г', 'д', 'у', 'ё', 'ж', 'з', 'и',
                                                'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ',
                                                'э', 'ю', 'я'};
        private static char[] charactersSym = new char[] {'1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0', ' ', '@', '!', '$', '|', '_', '-', '.', ','};
        #endregion
        /// <summary>
        /// Сумирование двух алфавитов
        /// </summary>
        /// <param name="c1">Первый массив символов</param>
        /// <param name="c2">Второй массив символов</param>
        /// <returns></returns>
        private char[] SummCharacters(char[] c1, char[] c2)
        {
            if (c1.Length > 0 && c2.Length > 0)
            {
                int i = 0;
                char[] c = new char[c1.Length + c2.Length];
                foreach (char ch in c1)
                {
                    c[i] = ch;
                    i++;
                }
                foreach (char ch in c2)
                {
                    c[i] = ch;
                    i++;
                }
                return c;
            }
            else
            {
                if (c1.Length > 0)
                {
                    return c1;
                }
                else if (c2.Length > 0)
                {
                    return c2;
                }
                else
                {
                    return null;
                }
            }
            
        }
        private int N = Characters.Length;
        /// <summary>
        /// Метод шифрования 
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="key">Ключ шифровки</param>
        /// <returns>Зашифрованная строка</returns>
        public string Encode(string input, string key)
        {
            input = input.ToUpper();
            key = key.ToUpper();
            string result = "";
            int key_index = 0;
            
            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(characters, symbol) + Array.IndexOf(characters, key[key_index])) % N;
                result += characters[c];
                key_index++;
                if ((key_index + 1) == key.Length) key_index = 0;
            }
            return result; 
        }
        /// <summary>
        /// Метод расшифровки
        /// </summary>
        /// <param name="input">Строка которую нужно расш.</param>
        /// <param name="key">Ключ шифровки</param>
        /// <returns>Расшифрованная строка</returns>
        public string Decode(string input, string key)
        {
            input = input.ToUpper();
            key = key.ToUpper();
            string result = "";
            int key_index = 0;

            foreach(char symbol in input)
            {
                int p = (Array.IndexOf(characters, symbol) + N - Array.IndexOf(characters, key[key_index])) % N;
                result += characters[p];
                key_index++;
                if ((key_index + 1) == key.Length) key_index = 0;
            }
            return result;
        }
        /// <summary>
        /// Генерируем псевдослучайный ключ (метод гаммирования)
        /// </summary>
        /// <param name="length">Длина ключа</param>
        /// <param name="startSeed">Число инициализации генератора случайных чисел(всегда должен быть одним и тем же)</param>
        /// <returns>Псевдослучайный ключ</returns>
        public string Generate_Pseudorandom_Key(int length, int startSeed)
        {
            Random rand = new Random(startSeed);
            string result = "";
            for (int i = 0; i < length;i++)
            {
                result += characters[rand.Next(0, characters.Length)];
            }
            return result;
        }
    }
}
