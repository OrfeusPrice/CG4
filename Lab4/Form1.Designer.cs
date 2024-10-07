namespace Lab4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.B_DrawPoly = new System.Windows.Forms.Button();
            this.B_MovePoly = new System.Windows.Forms.Button();
            this.B_PointRotate = new System.Windows.Forms.Button();
            this.B_CenterRotate = new System.Windows.Forms.Button();
            this.B_PointScale = new System.Windows.Forms.Button();
            this.B_CenterScale = new System.Windows.Forms.Button();
            this.B_FindPoint = new System.Windows.Forms.Button();
            this.B_Check = new System.Windows.Forms.Button();
            this.B_Classification = new System.Windows.Forms.Button();
            this.B_Clear = new System.Windows.Forms.Button();
            this.InfoTextBox = new System.Windows.Forms.TextBox();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.CB_SelectedPolygon = new System.Windows.Forms.ComboBox();
            this.B_Apply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.MainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainPictureBox.Location = new System.Drawing.Point(370, 12);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(800, 630);
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseDown);
            // 
            // B_DrawPoly
            // 
            this.B_DrawPoly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.B_DrawPoly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_DrawPoly.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_DrawPoly.Location = new System.Drawing.Point(13, 13);
            this.B_DrawPoly.Name = "B_DrawPoly";
            this.B_DrawPoly.Size = new System.Drawing.Size(351, 29);
            this.B_DrawPoly.TabIndex = 1;
            this.B_DrawPoly.Text = "Нарисовать полигон";
            this.B_DrawPoly.UseVisualStyleBackColor = false;
            this.B_DrawPoly.Click += new System.EventHandler(this.B_DrawPoly_Click);
            // 
            // B_MovePoly
            // 
            this.B_MovePoly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.B_MovePoly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_MovePoly.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_MovePoly.Location = new System.Drawing.Point(13, 42);
            this.B_MovePoly.Name = "B_MovePoly";
            this.B_MovePoly.Size = new System.Drawing.Size(351, 29);
            this.B_MovePoly.TabIndex = 2;
            this.B_MovePoly.Text = "Сместить полигон";
            this.B_MovePoly.UseVisualStyleBackColor = false;
            this.B_MovePoly.Click += new System.EventHandler(this.B_MovePoly_Click);
            // 
            // B_PointRotate
            // 
            this.B_PointRotate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.B_PointRotate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_PointRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_PointRotate.Location = new System.Drawing.Point(13, 71);
            this.B_PointRotate.Name = "B_PointRotate";
            this.B_PointRotate.Size = new System.Drawing.Size(351, 29);
            this.B_PointRotate.TabIndex = 3;
            this.B_PointRotate.Text = "Поворот вокруг точки";
            this.B_PointRotate.UseVisualStyleBackColor = false;
            this.B_PointRotate.Click += new System.EventHandler(this.B_PointRotate_Click);
            // 
            // B_CenterRotate
            // 
            this.B_CenterRotate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.B_CenterRotate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_CenterRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_CenterRotate.Location = new System.Drawing.Point(13, 100);
            this.B_CenterRotate.Name = "B_CenterRotate";
            this.B_CenterRotate.Size = new System.Drawing.Size(351, 29);
            this.B_CenterRotate.TabIndex = 4;
            this.B_CenterRotate.Text = "Поворот вокруг собственного центра";
            this.B_CenterRotate.UseVisualStyleBackColor = false;
            this.B_CenterRotate.Click += new System.EventHandler(this.B_CenterRotate_Click);
            // 
            // B_PointScale
            // 
            this.B_PointScale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.B_PointScale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_PointScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_PointScale.Location = new System.Drawing.Point(13, 129);
            this.B_PointScale.Name = "B_PointScale";
            this.B_PointScale.Size = new System.Drawing.Size(351, 29);
            this.B_PointScale.TabIndex = 5;
            this.B_PointScale.Text = "Масштабирование относительно точки";
            this.B_PointScale.UseVisualStyleBackColor = false;
            this.B_PointScale.Click += new System.EventHandler(this.B_PointScale_Click);
            // 
            // B_CenterScale
            // 
            this.B_CenterScale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.B_CenterScale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_CenterScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_CenterScale.Location = new System.Drawing.Point(13, 158);
            this.B_CenterScale.Name = "B_CenterScale";
            this.B_CenterScale.Size = new System.Drawing.Size(351, 29);
            this.B_CenterScale.TabIndex = 6;
            this.B_CenterScale.Text = "Масштабирование относительно центра";
            this.B_CenterScale.UseVisualStyleBackColor = false;
            this.B_CenterScale.Click += new System.EventHandler(this.B_CenterScale_Click);
            // 
            // B_FindPoint
            // 
            this.B_FindPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.B_FindPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_FindPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_FindPoint.Location = new System.Drawing.Point(13, 187);
            this.B_FindPoint.Name = "B_FindPoint";
            this.B_FindPoint.Size = new System.Drawing.Size(351, 29);
            this.B_FindPoint.TabIndex = 7;
            this.B_FindPoint.Text = "Найти точку пересечения двух рёбер";
            this.B_FindPoint.UseVisualStyleBackColor = false;
            this.B_FindPoint.Click += new System.EventHandler(this.B_FindPoint_Click);
            // 
            // B_Check
            // 
            this.B_Check.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.B_Check.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Check.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Check.Location = new System.Drawing.Point(13, 216);
            this.B_Check.Name = "B_Check";
            this.B_Check.Size = new System.Drawing.Size(351, 29);
            this.B_Check.TabIndex = 8;
            this.B_Check.Text = "Проверить принадлежность точки";
            this.B_Check.UseVisualStyleBackColor = false;
            this.B_Check.Click += new System.EventHandler(this.B_Check_Click);
            // 
            // B_Classification
            // 
            this.B_Classification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.B_Classification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Classification.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Classification.Location = new System.Drawing.Point(13, 245);
            this.B_Classification.Name = "B_Classification";
            this.B_Classification.Size = new System.Drawing.Size(351, 29);
            this.B_Classification.TabIndex = 9;
            this.B_Classification.Text = "Классифицировать положение точки";
            this.B_Classification.UseVisualStyleBackColor = false;
            this.B_Classification.Click += new System.EventHandler(this.B_Classification_Click);
            // 
            // B_Clear
            // 
            this.B_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.B_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Clear.Location = new System.Drawing.Point(12, 567);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(352, 43);
            this.B_Clear.TabIndex = 10;
            this.B_Clear.Text = "Очистить";
            this.B_Clear.UseVisualStyleBackColor = false;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // InfoTextBox
            // 
            this.InfoTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.InfoTextBox.Enabled = false;
            this.InfoTextBox.Location = new System.Drawing.Point(13, 274);
            this.InfoTextBox.Multiline = true;
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.Size = new System.Drawing.Size(351, 180);
            this.InfoTextBox.TabIndex = 11;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.InputTextBox.Location = new System.Drawing.Point(90, 460);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(274, 22);
            this.InputTextBox.TabIndex = 12;
            // 
            // CB_SelectedPolygon
            // 
            this.CB_SelectedPolygon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CB_SelectedPolygon.FormattingEnabled = true;
            this.CB_SelectedPolygon.Location = new System.Drawing.Point(90, 488);
            this.CB_SelectedPolygon.Name = "CB_SelectedPolygon";
            this.CB_SelectedPolygon.Size = new System.Drawing.Size(274, 24);
            this.CB_SelectedPolygon.TabIndex = 13;
            // 
            // B_Apply
            // 
            this.B_Apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.B_Apply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Apply.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Apply.Location = new System.Drawing.Point(12, 518);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(352, 43);
            this.B_Apply.TabIndex = 14;
            this.B_Apply.Text = "Применить";
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Значение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 491);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Полигон";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_Apply);
            this.Controls.Add(this.CB_SelectedPolygon);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.InfoTextBox);
            this.Controls.Add(this.B_Clear);
            this.Controls.Add(this.B_Classification);
            this.Controls.Add(this.B_Check);
            this.Controls.Add(this.B_FindPoint);
            this.Controls.Add(this.B_CenterScale);
            this.Controls.Add(this.B_PointScale);
            this.Controls.Add(this.B_CenterRotate);
            this.Controls.Add(this.B_PointRotate);
            this.Controls.Add(this.B_MovePoly);
            this.Controls.Add(this.B_DrawPoly);
            this.Controls.Add(this.MainPictureBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Affin";
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button B_DrawPoly;
        private System.Windows.Forms.Button B_MovePoly;
        private System.Windows.Forms.Button B_PointRotate;
        private System.Windows.Forms.Button B_CenterRotate;
        private System.Windows.Forms.Button B_PointScale;
        private System.Windows.Forms.Button B_CenterScale;
        private System.Windows.Forms.Button B_FindPoint;
        private System.Windows.Forms.Button B_Check;
        private System.Windows.Forms.Button B_Classification;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.TextBox InfoTextBox;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.ComboBox CB_SelectedPolygon;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

