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
        private static int[] GetIntMultVector(int[][] M, int[] array)
        {
            int[] resultV = new int[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    resultV[i] += M[j][i] * array[j];
            }
            return resultV;
        }
        private static double[] GetDoubleMultVector(double[][] M, int[] array)
        {
            double[] resultV = new double[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    resultV[i] += M[j][i] * array[j];
            }
            return resultV;
        }

        //Task31
        public static Point GetMovedPoint(Point polygonpoint, int dx, int dy)
        {
            int[][] M = new int[3][]
            {
                    new int[3] { 1,   0, 0 },
                    new int[3] { 0,   1, 0 },
                    new int[3] { dx, dy, 1 }
            };
            int[] inputV = new int[3] { polygonpoint.X, polygonpoint.Y, 1 };
            int[] resultV = GetIntMultVector(M, inputV);
            return new Point(resultV[0], resultV[1]);
        }

        //Tadk32
        public static Point RotatePoint(Point polygonpoint, Point PointofRotate, int rotateAngle)
        {
            double pointA, pointB;
            double angle = (rotateAngle / 180D) * Math.PI;

            pointA = -PointofRotate.X * Math.Cos(angle) + PointofRotate.Y * Math.Sin(angle) + PointofRotate.X;
            pointB = -PointofRotate.X * Math.Sin(angle) - PointofRotate.Y * Math.Cos(angle) + PointofRotate.Y;

            int[] offsetVector = new int[3] { polygonpoint.X, polygonpoint.Y, 1 };
            double[][] Matrix = new double[3][]
            {
                new double[3] {  Math.Cos(angle),   Math.Sin(angle), 0 },
                new double[3] { -Math.Sin(angle),   Math.Cos(angle), 0 },
                new double[3] { pointA, pointB, 1 }
            };
            double[] resultVector = GetDoubleMultVector(Matrix, offsetVector);
            return new Point((int)resultVector[0], (int)resultVector[1]);
        }
    }
}
