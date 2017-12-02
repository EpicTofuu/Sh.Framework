using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sh.Framework.vnTools
{
    public class TextManager
    {
        //take care of file IO yourself xd

        /// <summary>
        /// manager RPG-like text rendering with vnTools' textmanager class
        /// </summary>
        /// <param name="othergame"></param>
        public TextManager(Game othergame)
        {

        }

        /// <summary>
        /// takes care of rendering a canvas and text for you
        /// J U S T    L I K E   I N     D O K I   D O K I    L I T E R A T U R E    C L U B
        /// </summary>
        /// <param name="person">who is saying this</param>
        /// <param name="message">what is being said</param>
        /// <param name="rate">how many characters should be rendered per frame</param>
        /// <param name="drawColor">colour of text</param>
        public void enterdialogue(string person, string message, Color drawColor, float rate = 4.0f)
        {
            //TODO
        }

        /// <summary>
        /// render a string of text one letter at a time
        /// J U S T    L I K E   I N    N E K O P A R A
        /// </summary>
        /// <param name="message">what is being said, overuse ellipses and hyphens for added effect</param>
        /// <param name="rate">how many characters are being drawn per frame, leave blank for 4</param>
        /// <returns>returns <paramref name="message"/> one character at a time</returns>
        public string renderText(string message, int rate = 4)
        {
            int timer = 0;
            List<char> letters = new List<char>();
            char[] final;

            for (int i = 0; i < message.Length;)
            {
                if (timer >= rate)
                {
                    letters.Add(message[i]);
                    final = letters?.ToArray();
                }
                else
                {
                    timer++;
                }
            }

            return "not finished yet :)";
            //return new string(final);
        }
    }
}
