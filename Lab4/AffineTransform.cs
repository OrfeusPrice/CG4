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
        public static Point GetMovedPoint(Point polyP, int dx, int dy)
        {
            int[][] M = new int[3][]
            {
                    new int[3] {  1,  0, 0 },
                    new int[3] {  0,  1, 0 },
                    new int[3] { dx, dy, 1 }
            };
            int[] inputV = new int[3] { polyP.X, polyP.Y, 1 };
            int[] resultV = GetIntMultVector(M, inputV);
            return new Point(resultV[0], resultV[1]);
        }

        //Task32
        public static Point RotatePoint(Point polyP, Point rotateP, int rotateAngle)
        {
            double pointA, pointB;
            double angle = (rotateAngle) * Math.PI/180.0; //Градусы->радианы

            pointA = -rotateP.X * Math.Cos(angle) + rotateP.Y * Math.Sin(angle) + rotateP.X;
            pointB = -rotateP.X * Math.Sin(angle) - rotateP.Y * Math.Cos(angle) + rotateP.Y;

            int[] inputrV = new int[3] { polyP.X, polyP.Y, 1 };
            double[][] M = new double[3][]
            {
                new double[3] {  Math.Cos(angle),   Math.Sin(angle), 0 },
                new double[3] { -Math.Sin(angle),   Math.Cos(angle), 0 },
                new double[3] { pointA, pointB, 1 }
            };
            double[] resultV = GetDoubleMultVector(M, inputrV);
            return new Point((int)resultV[0], (int)resultV[1]);
        }

        //Task33
        public static Point GetPolygonCenter(List<Point> polygon)
        {
            return new Point((int)polygon.Average(p => p.X), (int)polygon.Average(p => p.Y));
        }

        //Task34
        public static Point ScalePoint(Point polyP, Point scaleP, double kx, double ky)
        {
            int[] inputV = new int[3] { polyP.X - scaleP.X, polyP.Y - scaleP.Y, 1 };
            double[][] Matrix = new double[3][]
            {
                new double[3] { kx, 0, 0 },
                new double[3] { 0, ky, 0 },
                new double[3] { 0, 0, 1 }
            };
            double[] resultV = GetDoubleMultVector(Matrix, inputV);
            return new Point((int)resultV[0] + scaleP.X, (int)resultV[1] + scaleP.Y);
        }
    }
}
