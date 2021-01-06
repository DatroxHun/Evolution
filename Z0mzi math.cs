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

        public override string ToString()
        {
            return string.Format($"{x}, {y}");
        }
    }
}