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

        enum Letters : int { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };

        public static List<Microsoft.Xna.Framework.Rectangle> characterList = new List<Microsoft.Xna.Framework.Rectangle>();

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

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(0, 0), characterList[(int)Letters.A], new Microsoft.Xna.Framework.Color(0, 0, 0, 255));
        }
    }
}
