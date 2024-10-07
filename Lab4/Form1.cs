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

        public Form1()
        {
            InitializeComponent();
            _buttons = new List<Button>();
            _buttons.Add(B_DrawPoly);
            _buttons.Add(B_MovePoly);
            _buttons.Add(B_PointRotate);
            _buttons.Add(B_CenterRotate);
            _buttons.Add(B_PointScale);
            _buttons.Add(B_CenterScale);
            _buttons.Add(B_FindPoint);
            _buttons.Add(B_Check);
            _buttons.Add(B_Classification);
            _buttons.Add(B_Clear);

            _curMode = new Mode(this);
            _polygons = new List<List<Point>>();
            _points = new List<Point>();

            _size = MainPictureBox.Size;
            _bm = new Bitmap(_size.Width, _size.Height);
            MainPictureBox.Image = _bm;
            _g = Graphics.FromImage(MainPictureBox.Image);

            _tempPoint = new Point();
            _tempEdge = new List<Point>();

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
                CB_SelectedPolygon.Items.Add($"polygon{_polygons.Count}");
                _points.Clear();
                _curMode = new Mode(this);
                InfoTextBox.Text = "";
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

        }
        public void ApplyMovePoly(object sender, EventArgs e)
        {

        }

        //===================
        //      Task32
        //===================
        public void PointRotate(object sender, MouseEventArgs e)
        {

        }
        public void ApplyPointRotate(object sender, EventArgs e)
        {

        }
        //===================
        //      Task33
        //===================
        public void CenterRotate(object sender, MouseEventArgs e)
        {

        }
        public void ApplyCenterRotate(object sender, EventArgs e)
        {

        }

        //===================
        //      Task34
        //===================
        public void PointScale(object sender, MouseEventArgs e)
        {

        }
        public void ApplyPointScale(object sender, EventArgs e)
        {

        }

        //===================
        //      Task35
        //===================
        public void CenterScale(object sender, MouseEventArgs e)
        {

        }
        public void ApplyCenterScale(object sender, EventArgs e)
        {

        }

        //===================
        //      Task4
        //===================
        public void FindPoint(object sender, MouseEventArgs e)
        {
            //ToDo Поиск точки пересечения двух ребер (добавление второго ребра мышкой, динамически).
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
        }

        //===================
        //      Task6
        //===================
        public void Classification(object sender, MouseEventArgs e)
        {
            //ToDo Классифицировать положение точки относительно ребра (справа или слева)
        }

        //===================
        //Остальные функции
        //===================

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
            _curMode.DoSmth(sender, e);
        }

        private void B_DrawPoly_Click(object sender, EventArgs e)
        {
            ButtonsEnabler(false); //Отключить кнопки
            _curMode = new MTask1(this);
        }

        private void B_MovePoly_Click(object sender, EventArgs e)
        {
            if (IsHasPolygons())
            {
                ButtonsEnabler(false);
                _curMode = new MTask31(this);
            }
        }

        private void B_PointRotate_Click(object sender, EventArgs e)
        {
            if (IsHasPolygons())
            {
                ButtonsEnabler(false);
                _curMode = new MTask32(this);
            }
        }

        private void B_CenterRotate_Click(object sender, EventArgs e)
        {
            if (IsHasPolygons())
            {
                ButtonsEnabler(false);
                _curMode = new MTask33(this);
            }
        }

        private void B_PointScale_Click(object sender, EventArgs e)
        {
            if (IsHasPolygons())
            {
                ButtonsEnabler(false);
                _curMode = new MTask34(this);
            }
        }

        private void B_CenterScale_Click(object sender, EventArgs e)
        {
            if (IsHasPolygons())
            {
                ButtonsEnabler(false);
                _curMode = new MTask35(this);
            }
        }

        private void B_FindPoint_Click(object sender, EventArgs e)
        {
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
            ButtonsEnabler(false);
            _curMode = new MTask6(this);
        }

        private void B_Apply_Click(object sender, EventArgs e)
        {
            _curMode?.Apply(sender, e);
        }
    }
}
