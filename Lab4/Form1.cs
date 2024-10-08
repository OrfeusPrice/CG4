using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab4.ModeManager;
using static Lab4.AffineTransform;

namespace Lab4
{
    public partial class Form1 : Form
    {
        Mode _curMode;
        List<List<Point>> _polygons;
        List<Point> _points;
        List<Button> _buttons;

        Color _polygonColor = Color.Black;
        Color _selectedPolygonColor = Color.Red;

        Bitmap _bm;
        Graphics _g;
        Size _size;

        int _intFlag = 0;
        bool _pointFlag = true;
        Point _tempPoint;
        List<Point> _tempEdge;
        List<Point> _pointsT4;

        public Form1()
        {
            InitializeComponent();
            _buttons = new List<Button>
            {
                B_DrawPoly,
                B_MovePoly,
                B_PointRotate,
                B_CenterRotate,
                B_PointScale,
                B_CenterScale,
                B_FindPoint,
                B_Check,
                B_Classification,
                B_Clear
            };

            _curMode = new Mode(this);
            _polygons = new List<List<Point>>();
            _points = new List<Point>();

            _size = MainPictureBox.Size;
            _bm = new Bitmap(_size.Width, _size.Height);
            MainPictureBox.Image = _bm;
            _g = Graphics.FromImage(MainPictureBox.Image);

            _tempPoint = new Point();
            _tempEdge = new List<Point>();
            _pointsT4 = new List<Point>();

            CB_SelectedPolygon.Items.Clear();
            CB_SelectedPolygon.Items.Add("");
            CB_SelectedPolygon.SelectedIndex = 0;
        }

        //Включить/выключить кнопки
        void ButtonsEnabler(bool enabled)
        {
            foreach (Button item in _buttons)
                item.Enabled = enabled;
        }

        //Рисует полигон по точкам
        private void DrawPolygons()
        {
            _bm = new Bitmap(_size.Width, _size.Height);
            MainPictureBox.Image = _bm;
            _g = Graphics.FromImage(MainPictureBox.Image);

            for (int j = 0; j < _polygons.Count; j++)
            {
                Color color = CB_SelectedPolygon.SelectedIndex == j + 1 ? _selectedPolygonColor : _polygonColor;
                Pen pen = new Pen(color);

                List<Point> polygon = _polygons[j];
                if (polygon.Count == 1) _g.DrawRectangle(pen, new Rectangle(polygon[0].X, polygon[0].Y, 1, 1));
                else if (polygon.Count == 2) _g.DrawLine(pen, polygon[0].X, polygon[0].Y, polygon[1].X, polygon[1].Y);
                else
                {
                    for (int i = 1; i < polygon.Count; i++)
                        _g.DrawLine(pen, polygon[i - 1].X, polygon[i - 1].Y, polygon[i].X, polygon[i].Y);
                    _g.DrawLine(pen, polygon[0].X, polygon[0].Y, polygon[polygon.Count - 1].X, polygon[polygon.Count - 1].Y);
                }
            }

            MainPictureBox.Image = _bm;
        }

        //===================
        //      Task1
        //===================
        public void CreatePoly(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !_points.Contains(e.Location))
            {
                _points.Add(e.Location);
                _bm.SetPixel(e.Location.X, e.Location.Y, _polygonColor);
                MainPictureBox.Image = _bm;
            }
            else if (e.Button == MouseButtons.Right && _points.Count != 0)
            {
                _polygons.Add(new List<Point>(_points));
                CB_SelectedPolygon.Items.Add($"P{_polygons.Count}");
                _points.Clear();
                
                SetIdle();
                DrawPolygons();
                ButtonsEnabler(true); //Включить кнопки
            }
        }

        //===================
        //      Task2
        //===================
        private void B_Clear_Click(object sender, EventArgs e)
        {
            _polygons.Clear();
            CB_SelectedPolygon.Items.Clear();
            CB_SelectedPolygon.Items.Add("");
            CB_SelectedPolygon.SelectedIndex = 0;
            _g.Clear(MainPictureBox.BackColor);

            _bm = new Bitmap(_size.Width, _size.Height);
            MainPictureBox.Image = _bm;
            _g = Graphics.FromImage(MainPictureBox.Image);
        }

        //===================
        //      Task31
        //===================
        public void MovePoly(object sender, MouseEventArgs e)
        {
            return;
        }

        public void ApplyMovePoly(object sender, EventArgs e)
        {
            string[] input = InputTextBox.Text.Split(' ');
            int dx, dy;

            if (input.Length != 2 || (!int.TryParse(input[0], out dx) || !int.TryParse(input[1], out dy)))
            {
                InfoTextBox.Text = "Ошибка. Вы должны ввести две координаты X и Y: 2 целых числа через пробел, пример ввода: 2 3";
                return;
            }
            else if (CB_SelectedPolygon.SelectedIndex == 0)
            {
                InfoTextBox.Text = "Ошибка. Вы не выбрали полигон";
                return;
            }
            else
            {
                for (int i = 0; i < _polygons[CB_SelectedPolygon.SelectedIndex - 1].Count; i++)
                    _polygons[CB_SelectedPolygon.SelectedIndex - 1][i] = GetMovedPoint(_polygons[CB_SelectedPolygon.SelectedIndex - 1][i], dx, dy);
                
                ButtonsEnabler(true);
                DrawPolygons();
                SetIdle();
            }

        }

        //===================
        //      Task32
        //===================
        public void SetPoint(object sender, MouseEventArgs e)
        {
            if (_pointFlag)
            {
                _g = Graphics.FromImage(MainPictureBox.Image);
                _tempPoint = e.Location;

                _points.Add(_tempPoint);
                _polygons.Add(new List<Point>(_points));
                _points.Clear();

                _g.DrawRectangle(new Pen(Color.Orange, 2), new Rectangle(_tempPoint.X, _tempPoint.Y, 2, 2));
                MainPictureBox.Image = _bm;
                _pointFlag = false;
            }
        }
        public void ApplyPointRotate(object sender, EventArgs e)
        {
            int rotation = 0;
            if (CB_SelectedPolygon.SelectedIndex == 0 || !int.TryParse(InputTextBox.Text, out rotation) || _pointFlag)
            {
                InfoTextBox.Text = "Ошибка. Поставьте точку, выберите полигон в списке \"Полигон\", \nНапишите в поле \"Значение\" угол поворота";
                return;
            }

            for (int i = 0; i < _polygons[CB_SelectedPolygon.SelectedIndex - 1].Count; i++)
                _polygons[CB_SelectedPolygon.SelectedIndex - 1][i] = RotatePoint(_polygons[CB_SelectedPolygon.SelectedIndex - 1][i], _tempPoint, rotation);

            SetIdle();
            ButtonsEnabler(true);

            _polygons.Remove(_polygons.Last());
            DrawPolygons();
            _pointFlag = true;
        }
        //===================
        //      Task33
        //===================
        public void CenterRotate(object sender, MouseEventArgs e)
        {
            return;
        }
        public void ApplyCenterRotate(object sender, EventArgs e)
        {
            int rotation;
            if (CB_SelectedPolygon.SelectedIndex == 0 || !int.TryParse(InputTextBox.Text, out rotation))
            {
                InfoTextBox.Text = "Ошибка. Выберите полигон в списке \"Полигон\", \\nНапишите в поле \"Значение\" угол поворота";
                return;
            }
            Point tempP = GetPolygonCenter(_polygons[CB_SelectedPolygon.SelectedIndex - 1]);
            for (int i = 0; i < _polygons[CB_SelectedPolygon.SelectedIndex - 1].Count; i++)
                _polygons[CB_SelectedPolygon.SelectedIndex - 1][i] = RotatePoint(_polygons[CB_SelectedPolygon.SelectedIndex - 1][i], tempP, rotation);

            SetIdle();
            ButtonsEnabler(true);
            DrawPolygons();
        }

        //===================
        //      Task34
        //===================
        public void PointScale(object sender, MouseEventArgs e)
        {
            SetPoint(sender, e);
        }
        public void ApplyPointScale(object sender, EventArgs e)
        {
            double kx;
            double ky;
            string[] input = InputTextBox.Text.Split(' ');

            if (input.Length !=  2 || CB_SelectedPolygon.SelectedIndex == 0 || !double.TryParse(input[0], out kx) || !double.TryParse(input[1], out ky) || _pointFlag)
            {
                InfoTextBox.Text = "Ошибка. Поставьте точку, выберите полигон в списке \"Полигон\", \\nНапишите в поле \"Значение\" 2 числа: масштабирование по X и по Y";
                return;
            }
            for (int i = 0; i < _polygons[CB_SelectedPolygon.SelectedIndex - 1].Count; i++)
                _polygons[CB_SelectedPolygon.SelectedIndex - 1][i] = ScalePoint(_polygons[CB_SelectedPolygon.SelectedIndex - 1][i], _tempPoint, kx,ky);

            SetIdle();
            ButtonsEnabler(true);
            
            _polygons.Remove(_polygons.Last());
            DrawPolygons();
            _pointFlag = true;
        }

        //===================
        //      Task35
        //===================
        public void CenterScale(object sender, MouseEventArgs e)
        {
            return;
        }
        public void ApplyCenterScale(object sender, EventArgs e)
        {
            double kx;
            double ky;
            string[] input = InputTextBox.Text.Split(' ');

            if (input.Length != 2 || CB_SelectedPolygon.SelectedIndex == 0 || !double.TryParse(input[0], out kx) || !double.TryParse(input[1], out ky))
            {
                InfoTextBox.Text = "Ошибка. Выберите полигон в списке \"Полигон\", \\nНапишите в поле \"Значение\" 2 числа: масштабирование по X и по Y";
                return;
            }

            Point tempP = GetPolygonCenter(_polygons[CB_SelectedPolygon.SelectedIndex - 1]);
            for (int i = 0; i < _polygons[CB_SelectedPolygon.SelectedIndex - 1].Count; i++)
                _polygons[CB_SelectedPolygon.SelectedIndex - 1][i] = ScalePoint(_polygons[CB_SelectedPolygon.SelectedIndex - 1][i], tempP, kx, ky);

            SetIdle();
            ButtonsEnabler(true);
            DrawPolygons();
        }

        //===================
        //      Task4
        //===================

        public void FindPoint(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _pointsT4.Add(e.Location);
                _bm.SetPixel(e.Location.X, e.Location.Y, _polygonColor);
                if (_pointsT4.Count % 2 == 0)
                {
                    _g.DrawLine(new Pen(_polygonColor), _pointsT4[_pointsT4.Count - 2], _pointsT4[_pointsT4.Count - 1]);
                }
                MainPictureBox.Image = _bm;
                if (_pointsT4.Count == 4)
                {
                    Point a = _pointsT4[_pointsT4.Count - 4];
                    Point b = _pointsT4[_pointsT4.Count - 3];
                    Point c = _pointsT4[_pointsT4.Count - 2];
                    Point d = _pointsT4[_pointsT4.Count - 1];
                    Point n = new Point(-(d.Y - c.Y), d.X - c.X);
                    float t = -(float)(n.X * (a.X - c.X) + n.Y * (a.Y - c.Y)) / (n.X * (b.X - a.X) + n.Y * (b.Y - a.Y));
                    if (n.X * (b.X - a.X) + n.Y * (b.Y - a.Y) == 0)
                    {
                        InfoTextBox.Text = "Прямые параллельны";
                    }
                    else
                    {
                        Point res = new Point(a.X + (int)(t * (b.X - a.X)), a.Y + (int)(t * (b.Y - a.Y)));
                        _g.DrawRectangle(new Pen(_selectedPolygonColor), res.X, res.Y, 1, 1);
                        MainPictureBox.Image = _bm;
                        if (res.X >= Math.Min(a.X, b.X) && res.X <= Math.Max(a.X, b.X) && res.Y >= Math.Min(a.Y, b.Y) && res.Y <= Math.Max(a.Y, b.Y)
                            && res.X >= Math.Min(c.X, d.X) && res.X <= Math.Max(c.X, d.X) && res.Y >= Math.Min(c.Y, d.Y) && res.Y <= Math.Max(c.Y, d.Y))
                            InfoTextBox.Text = $"Точка пересечения - ({res.X}, {res.Y}).";
                        else InfoTextBox.Text = $"Рёбра не пересекаются.";
                    }
                }
                else if (_pointsT4.Count >= 4 && _pointsT4.Count % 2 == 0)
                {
                    InfoTextBox.Text = "";
                    for (int i = _pointsT4.Count - 3; i > 0; i -= 2)
                    {
                        Point a = _pointsT4[i - 1];
                        Point b = _pointsT4[i];
                        Point c = _pointsT4[_pointsT4.Count - 2];
                        Point d = _pointsT4[_pointsT4.Count - 1];
                        Point n = new Point(-(d.Y - c.Y), d.X - c.X);

                        float t = -(float)(n.X * (a.X - c.X) + n.Y * (a.Y - c.Y)) / (n.X * (b.X - a.X) + n.Y * (b.Y - a.Y));
                        if (n.X * (b.X - a.X) + n.Y * (b.Y - a.Y) == 0)
                        {
                            InfoTextBox.Text += "Прямые параллельны\n";
                        }
                        else
                        {
                            Point res = new Point(a.X + (int)(t * (b.X - a.X)), a.Y + (int)(t * (b.Y - a.Y)));
                            if (res.X >= Math.Min(a.X, b.X) && res.X <= Math.Max(a.X, b.X) && res.Y >= Math.Min(a.Y, b.Y) && res.Y <= Math.Max(a.Y, b.Y)
                                && res.X >= Math.Min(c.X, d.X) && res.X <= Math.Max(c.X, d.X) && res.Y >= Math.Min(c.Y, d.Y) && res.Y <= Math.Max(c.Y, d.Y))
                            {
                                InfoTextBox.Text += $"Точка пересечения - ({res.X}, {res.Y}).\n";
                                _g.DrawRectangle(new Pen(_selectedPolygonColor), res.X, res.Y, 1, 1);
                                MainPictureBox.Image = _bm;
                            }
                            else InfoTextBox.Text += $"Рёбра не пересекаются.\n";
                        }
                    }
                }
            }

            else if (e.Button == MouseButtons.Right)
            {
                SetIdle(); //В конце возвращаем текущий режим в нейтральное состояние
                ButtonsEnabler(true);
                _pointsT4.Clear();
                DrawPolygons();
            }
        }

        //===================
        //      Task5
        //===================
        public void Check(object sender, MouseEventArgs e)
        {
            //ToDo Проверка принадлежит ли заданная пользователем (с помощью мыши) точка выпуклому и невыпуклому полигонам

        }
        public void ApplyCheck(object sender, EventArgs e)
        {
            //ToDo После выбора точки и полигона нажать на кнопку "Применить" и написать, принадлежит точка или нет

            SetIdle(); //В конце возвращаем текущий режим в нейтральное состояние
            ButtonsEnabler(true); //Включаем кнопочки
        }

        //===================
        //      Task6
        //===================
        public void Classification(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_pointsT4.Count < 2)
                {
                    _pointsT4.Add(e.Location);
                    _bm.SetPixel(e.Location.X, e.Location.Y, _polygonColor);
                    MainPictureBox.Image = _bm;
                    if (_pointsT4.Count == 2)
                    {
                        _g.DrawLine(new Pen(_polygonColor), _pointsT4[0], _pointsT4[1]);
                        MainPictureBox.Image = _bm;
                        InfoTextBox.Text = "Поставьте точку.";
                    }
                }
                else if (_pointsT4.Count == 2)
                {
                   
                    _tempPoint = e.Location;
                    _bm.SetPixel(e.Location.X, e.Location.Y, _polygonColor);
                    MainPictureBox.Image = _bm;
                    Point b = new Point(_tempPoint.X - _pointsT4[0].X, _tempPoint.Y - _pointsT4[0].Y);
                    Point a = new Point(_pointsT4[1].X - _pointsT4[0].X, _pointsT4[1].Y - _pointsT4[0].Y);
                    float res = b.X * a.Y - b.Y * a.X;
                    string str;

                    if (res > 0) str = "Точка слева от ребра.";
                    else if (res < 0) str = "Точка справа от ребра.";
                    else str = "Точка на ребре.";
                    InfoTextBox.Text = str;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                SetIdle(); //В конце возвращаем текущий режим в нейтральное состояние
                ButtonsEnabler(true);
                _pointsT4.Clear();
                DrawPolygons();
            }
        }

        //===================
        //Остальные функции
        //===================

        void SetIdle()
        {
            _curMode = new Mode(this);
            InfoTextBox.Text = "";
        }

        bool IsHasPolygons()
        {
            if (_polygons.Count > 0) return true;
            else
            {
                InfoTextBox.Text = "Нет полигонов.";
                return false;
            }
        }

        private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _curMode?.DoSmth(sender, e);
        }

        private void B_Apply_Click(object sender, EventArgs e)
        {
            _curMode?.Apply(sender, e);
        }

        private void CB_SelectedPolygon_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawPolygons();
        }

        private void B_DrawPoly_Click(object sender, EventArgs e)
        {
            InfoTextBox.Text = "ЛКМ - поставить точку,\n ПКМ - создать полигон.";
            ButtonsEnabler(false); //Отключить кнопки
            _curMode = new MTask1(this);
        }

        private void B_MovePoly_Click(object sender, EventArgs e)
        {
            if (IsHasPolygons())
            {
                InfoTextBox.Text = "Выберите полигон в списке \"Полигон\", \nНапишите в поле \"Значение\" смещение X и Y через пробел";
                ButtonsEnabler(false);
                _curMode = new MTask31(this);
            }
        }

        private void B_PointRotate_Click(object sender, EventArgs e)
        {
            if (IsHasPolygons())
            {
                InfoTextBox.Text = "Поставьте точку, выберите полигон в списке \"Полигон\", \nНапишите в поле \"Значение\" угол поворота";
                ButtonsEnabler(false);
                _curMode = new MTask32(this);
            }
        }

        private void B_CenterRotate_Click(object sender, EventArgs e)
        {
            if (IsHasPolygons())
            {
                InfoTextBox.Text = "Выберите полигон в списке \"Полигон\", \nНапишите в поле \"Значение\" угол поворота";
                ButtonsEnabler(false);
                _curMode = new MTask33(this);
            }
        }

        private void B_PointScale_Click(object sender, EventArgs e)
        {
            if (IsHasPolygons())
            {
                InfoTextBox.Text = "Поставьте точку, выберите полигон в списке \"Полигон\", \nНапишите в поле \"Значение\" 2 числа: масштабирование по X и по Y";
                ButtonsEnabler(false);
                _curMode = new MTask34(this);
            }
        }

        private void B_CenterScale_Click(object sender, EventArgs e)
        {
            if (IsHasPolygons())
            {
                InfoTextBox.Text = "Выберите полигон в списке \"Полигон\", \nНапишите в поле \"Значение\" 2 числа: масштабирование по X и по Y";
                ButtonsEnabler(false);
                _curMode = new MTask35(this);
            }
        }

        private void B_FindPoint_Click(object sender, EventArgs e)
        {
            InfoTextBox.Text = "Нарисуйте ребро (поставьте 2 точки), затем ещё одно ребро";
            ButtonsEnabler(false);
            _curMode = new MTask4(this);
        }

        private void B_Check_Click(object sender, EventArgs e)
        {
            if (IsHasPolygons())
            {
                ButtonsEnabler(false);
                _curMode = new MTask5(this);
            }
        }

        private void B_Classification_Click(object sender, EventArgs e)
        {
            InfoTextBox.Text = "Нарисуйте ребро (поставьте 2 точки)";
            ButtonsEnabler(false);
            _curMode = new MTask6(this);
        }
    }
}
