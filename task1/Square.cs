using System;
using System.Collections.Generic;
class Square
{
    private Dictionary<int, Func<int, int, bool>> spellBook = new Dictionary<int, Func<int, int, bool>> {
            {0, (int x, int y) => true },
            {1, (int x, int y) =>  x > y},
            {2, (int x, int y) =>  x == y},
            {3, (int x, int y) =>  x == 24 - y},
            {4, (int x, int y) =>  x + y < 30},
            {5, (int x, int y) =>  x == y * 2 || x == y * 2 + 1},
            {6, (int x, int y) =>  x < 10 || y < 10},
            {7, (int x, int y) =>  x > 15 && y > 15},
            {8, (int x, int y) =>  x == 0 || y == 0},
            {9, (int x, int y) =>  y - x > 10 || y - x < - 10},
            {10, (int x, int y) =>  x - 1 >= y && x - 1 < y * 2 + 1},
            {11, (int x, int y) =>  y == 1 || x == 1 || y == 23 || x == 23},
            {12, (int x, int y) =>  Math.Pow(x, 2) + Math.Pow(y, 2) <= 400},
            {13, (int x, int y) =>  x + y >= 20 && x + y <= 28},
            {14, (int x, int y) =>  Math.Pow(27 - x, 2) + Math.Pow(27 - y, 2) >= 529}, // не соответствует картинке, но лучше чем x*y <= 400
            {15, (int x, int y) =>  Math.Abs(y - x) >= 10 && Math.Abs(y - x) <= 20},
            {16, (int x, int y) =>  9 - Math.Abs(x - 12) >= Math.Abs(y - 12) },
            {17, (int x, int y) =>  (24 - Math.Abs(Math.Sin(x * 0.17 - 1.055) * 14)) <= y}, // тоже не совсем то, но в отличии от (Math.sin(x/3) <= y / 8 - 2) работает
            {18, (int x, int y) =>  !(x == 0 && y == 0) && (x <= 1 || y <= 1)},
            {19, (int x, int y) =>  x == 0 || x == 24 || y == 0 || y == 24},
            {20, (int x, int y) =>  (x + y) % 2 == 0},
            {21, (int x, int y) =>  x % (y + 1) == 0}, // не осилил
            {22, (int x, int y) =>  (x + y) % 3 == 0},
            {23, (int x, int y) =>  y % 3 == 0 && x % 2 == 0},
            {24, (int x, int y) =>  x == y || 24 - x == y},
            {25, (int x, int y) =>  x % 6 == 0 || y % 6 == 0},
        };
    public Square(int spellNumber)
    {
        var spell = getSpell(spellNumber);
        paintSqare(spell);
    }
    private void paintSqare(Func<int, int, bool> spell)
    {
        for (int y = 0; y < 25; y++)
        {
            for (int x = 0; x < 25; x++)
            {
                Console.Write(spell(x, y) ? "#" : ".");
            }

            Console.WriteLine();
        }
    }
    private Func<int, int, bool> getSpell(int key)
    {
        if (!spellBook.ContainsKey(key)) key = 0;

        var pattern = spellBook[key];

        return pattern;
    }
}