﻿using Task2.Interface;

namespace Task2.Class
{
    internal class Triangle(double a, double b) : IPolygon
    {
        public double A { get; set; } = a;
        public double B { get; set; } = b;

        public double GetArea() => A * B / 2;

        public override string ToString() => GetArea().ToString();
    }
}
