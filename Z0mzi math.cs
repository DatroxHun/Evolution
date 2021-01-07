using System;

namespace Z0mziMath
{
    public static class Mathf
    {
        public static double Map(double input, double inMin, double inMax, double outMin, double outMax)
        {
            return (input - inMin) / (inMax - inMin) * (outMax - outMin) + outMin;
        }

        public static int Clamp(int input, int min, int max)
        {
            return Math.Min(max, Math.Max(min, input));
        }

        public static double Clamp(double input, double min, double max)
        {
            return Math.Min(max, Math.Max(min, input));
        }
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