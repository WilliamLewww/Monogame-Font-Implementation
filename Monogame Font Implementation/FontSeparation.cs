using System.Drawing;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FontSeparation
{
    class FontSeparation
    {
        static Bitmap font;
        public List<int[]> coordinateList = new List<int[]>();

        public void LoadBitmap(Bitmap bitmap)
        {
            font = bitmap;

            bool a = false;
            int minX = -1, minY = bitmap.Height, maxX = 0, maxY = 0;

            for (int x = 0; x < bitmap.Width; x++)
            {
                a = false;

                for (int y = 0; y < bitmap.Height; y++)
                {
                    if (bitmap.GetPixel(x, y).A != 0)
                    {
                        a = true;

                        if (minX == -1)
                            minX = x;

                        if (y < minY)
                            minY = y;

                        if (x > maxX)
                            maxX = x;

                        if (y > maxY)
                            maxY = y;
                    }
                }

                if (a == false)
                {
                    if (minX != -1)
                        coordinateList.Add(new int[4] { minX, minY, (maxX + 1) - minX, (maxY + 1) - minY });

                    minX = -1;
                    minY = bitmap.Height;
                    maxX = 0;
                    maxY = 0;
                }
            }
        }
    }

    class Character
    {
        Texture2D texture;
        FontSeparation fontSeparation;

        int OFFSET = 5;

        public static List<Microsoft.Xna.Framework.Rectangle> characterList = new List<Microsoft.Xna.Framework.Rectangle>();
        List<Microsoft.Xna.Framework.Rectangle> newCharacterList = new List<Microsoft.Xna.Framework.Rectangle>();

        private static ContentManager content;
        public static ContentManager Content
        {
            set { content = value; }
        }

        public Character(string image)
        {
            texture = content.Load<Texture2D>("font.png");

            fontSeparation = new FontSeparation();
            fontSeparation.LoadBitmap(new Bitmap(image));

            foreach (int[] coordinate in fontSeparation.coordinateList)
                characterList.Add(new Microsoft.Xna.Framework.Rectangle(coordinate[0], coordinate[1], coordinate[2], coordinate[3]));

            newCharacterList = DrawString("1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int a = 0, b = 0;

            for (int x = 0; x < characterList.Count; x++)
                if (x != 42 && x != 45 && x != 51 && x != 52 && x != 60)
                    if (characterList[x].Height > b)
                        b = characterList[x].Height;

            for (int x = 0; x < newCharacterList.Count; x++)
            {
                spriteBatch.Draw(texture, new Vector2(a + (OFFSET * x), b - newCharacterList[x].Height), newCharacterList[x], new Microsoft.Xna.Framework.Color(0, 0, 0, 255));
                a += newCharacterList[x].Width;
            }
        }

        public List<Microsoft.Xna.Framework.Rectangle> DrawString(string text)
        {
            List<Microsoft.Xna.Framework.Rectangle> newCharacterList = new List<Microsoft.Xna.Framework.Rectangle>();

            foreach (char c in text)
            {
                newCharacterList.Add(characterList[GetIndexFromChar(c)]);
            }

            return newCharacterList;
        }

        public int GetIndexFromChar(char c)
        {
            switch (c)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;
                case 'G':
                    return 16;
                case 'H':
                    return 17;
                case 'I':
                    return 18;
                case 'J':
                    return 19;
                case 'K':
                    return 20;
                case 'L':
                    return 21;
                case 'M':
                    return 22;
                case 'N':
                    return 23;
                case 'O':
                    return 24;
                case 'P':
                    return 25;
                case 'Q':
                    return 26;
                case 'R':
                    return 27;
                case 'S':
                    return 28;
                case 'T':
                    return 29;
                case 'U':
                    return 30;
                case 'V':
                    return 31;
                case 'W':
                    return 32;
                case 'X':
                    return 33;
                case 'Y':
                    return 34;
                case 'Z':
                    return 35;
                case 'a':
                    return 36;
                case 'b':
                    return 37;
                case 'c':
                    return 38;
                case 'd':
                    return 39;
                case 'e':
                    return 40;
                case 'f':
                    return 41;
                case 'g':
                    return 42;
                case 'h':
                    return 43;
                case 'i':
                    return 44;
                case 'j':
                    return 45;
                case 'k':
                    return 46;
                case 'l':
                    return 47;
                case 'm':
                    return 48;
                case 'n':
                    return 49;
                case 'o':
                    return 50;
                case 'p':
                    return 51;
                case 'q':
                    return 52;
                case 'r':
                    return 53;
                case 's':
                    return 54;
                case 't':
                    return 55;
                case 'u':
                    return 56;
                case 'v':
                    return 57;
                case 'w':
                    return 58;
                case 'x':
                    return 59;
                case 'y':
                    return 60;
                case 'z':
                    return 61;
            }

            return -1;
        }
    }
}
