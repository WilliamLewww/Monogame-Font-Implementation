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

        int OFFSET = 10;

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

            newCharacterList = DrawString("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int a = 0;

            for (int x = 0; x < newCharacterList.Count; x++)
            {
                spriteBatch.Draw(texture, new Vector2(a + (OFFSET * x), 0), newCharacterList[x], new Microsoft.Xna.Framework.Color(0, 0, 0, 255));
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
                case 'A':
                    return 0;
                case 'B':
                    return 1;
                case 'C':
                    return 2;
                case 'D':
                    return 3;
                case 'E':
                    return 4;
                case 'F':
                    return 5;
                case 'G':
                    return 6;
                case 'H':
                    return 7;
                case 'I':
                    return 8;
                case 'J':
                    return 9;
                case 'K':
                    return 10;
                case 'L':
                    return 11;
                case 'M':
                    return 12;
                case 'N':
                    return 13;
                case 'O':
                    return 14;
                case 'P':
                    return 15;
                case 'Q':
                    return 16;
                case 'R':
                    return 17;
                case 'S':
                    return 18;
                case 'T':
                    return 19;
                case 'U':
                    return 20;
                case 'V':
                    return 21;
                case 'W':
                    return 22;
                case 'X':
                    return 23;
                case 'Y':
                    return 24;
                case 'Z':
                    return 25;
            }

            return -1;
        }
    }
}
