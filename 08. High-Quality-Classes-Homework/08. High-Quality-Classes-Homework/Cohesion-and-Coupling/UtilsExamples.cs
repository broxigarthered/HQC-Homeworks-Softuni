using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(StringUtils.GetFileExtension("example"));
            Console.WriteLine(StringUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(StringUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(StringUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(StringUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(StringUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                CalculationsUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                CalculationsUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            CalculationsUtils.Width = 3;
            CalculationsUtils.Height = 4;
            CalculationsUtils.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", CalculationsUtils.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", CalculationsUtils.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", CalculationsUtils.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", CalculationsUtils.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", CalculationsUtils.CalcDiagonalYZ());
        }
    }
}
