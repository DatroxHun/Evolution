using System;

namespace Z0mziMath
{
    public class Mathf
    {

    }
    public class Vector2
    {
        public Vector2(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public int x;
        public int y;
        public static Vector2 operator +(Vector2 one, Vector2 two)
        {
            return new Vector2(one.x + two.x, one.y + two.y);
        }

        public override string ToString()
        {
            return string.Format($"{x}, {y}");
        }
    }
}