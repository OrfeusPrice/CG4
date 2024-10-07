using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class AffineTransform
    {
        private static int[] GetIntMultVector(int[][] Matrix, int[] array)
        {
            int[] resultVector = new int[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    resultVector[i] += Matrix[j][i] * array[j];
            }
            return resultVector;
        }

        public static Point GetMovedPoint(Point polygonpoint, int dx, int dy)
        {
            int[][] Matrix = new int[3][]
            {
                    new int[3] { 1,   0, 0 },
                    new int[3] { 0,   1, 0 },
                    new int[3] { dx, dy, 1 }
            };
            int[] offsetVector = new int[3] { polygonpoint.X, polygonpoint.Y, 1 };
            int[] resultVector = GetIntMultVector(Matrix, offsetVector);
            return new Point((int)resultVector[0], (int)resultVector[1]);
        }


    }
}
