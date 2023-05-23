using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace comp282assignment2_datagridVersion
{
    public partial class Form1 : Form
    {
        // lines Collection
        private List<Line> _lines = new List<Line>();
        private List<Line> _overlapLines = new List<Line>();

        // record location from two clicks
        private int _clickCount = 0;
        private Point _firstClickPoint;
        private Point _secondClickPoint;

        // Color
        private Color _defaultLineColor = System.Drawing.Color.Black;

        public Form1()
        {
            InitializeComponent();
        }


        private void color_button_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _defaultLineColor = colorDialog.Color;
                colorButton.ForeColor = colorDialog.Color;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell CellFX = row.Cells[0];
            DataGridViewCell CellFY = row.Cells[1];
            DataGridViewCell CellSX = row.Cells[2];
            DataGridViewCell CellSY = row.Cells[3];
            DataGridViewCell lineColor = row.Cells[4];
            // color becomes black, if input
            if (e.ColumnIndex < 4)
            {
                row.Cells[4].Style.BackColor = _defaultLineColor;
            }
            // check if all four grid have inputs.
            for (int i = 0; i<4; i++)
            {
                if (row.Cells[i].Value == null || row.Cells[i].Value.ToString() == "")
                {
                    return;
                }
            }

            if (e.RowIndex < _lines.Count)
            {
                int FX = 0;
                int FY = 0;
                int SX = 0;
                int SY = 0;
                if (!int.TryParse(CellFX.Value.ToString(), out FX) || !int.TryParse(CellFY.Value.ToString(), out FY) || !int.TryParse(CellSX.Value.ToString(), out SX) || !int.TryParse(CellSY.Value.ToString(), out SY))
                {
                    // error, notify user to enter an integer
                    MessageBox.Show("Enter a non-negative integer in the box, plz.");
                    return;
                }
                if(FX<0 || FY<0 || SX<0 || SY < 0)
                {
                    MessageBox.Show("The line is out of boundary. Enter a non-negative integer in the box, plz.");
                    return;
                }
                Point firstPoint = new Point(FX, FY);
                Point secondPoint = new Point(SX, SY);
                Line line = _lines[e.RowIndex];
                line.Point1 = firstPoint;
                line.Point2 = secondPoint;
                line.LineColor = lineColor.Style.BackColor;
                row.Cells[4].Style.BackColor = lineColor.Style.BackColor;
            } 
            else
            {
                int FX = 0;
                int FY = 0;
                int SX = 0;
                int SY = 0;
                if (!int.TryParse(CellFX.Value.ToString(), out FX) || !int.TryParse(CellFY.Value.ToString(), out FY) || !int.TryParse(CellSX.Value.ToString(), out SX) || !int.TryParse(CellSY.Value.ToString(), out SY))
                {
                    // error, notify user to enter an integer
                    MessageBox.Show("Enter a non-negative integer in the box, plz.");
                    return;
                }
                if (FX < 0 || FY < 0 || SX < 0 || SY < 0)
                {
                    MessageBox.Show("The line is out of boundary. Enter a non-negative integer in the box, plz.");
                    return;
                }
                Point firstPoint = new Point(FX, FY);
                Point secondPoint = new Point(SX, SY);
                Line newLine = new Line(firstPoint, secondPoint, colorButton.ForeColor);
                _lines.Add(newLine);
            }
            UpdatePictureBox();

        }

        private void UpdatePictureBox()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(System.Drawing.Color.White);
            Pen pen = new Pen(System.Drawing.Color.Black);

            foreach (Line line in _lines)
            {
                pen.Color = line.LineColor;
                g.DrawLine(pen, line.Point1, line.Point2);
            }

            pictureBox1.Image = bitmap;

            pictureBox1.Invalidate();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    ColorDialog colorDialog = new ColorDialog();
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        for (int i = 0; i < 4; i++)
                        {
                            if (row.Cells[i].Value == null || row.Cells[i].Value.ToString() == "")
                            {
                                MessageBox.Show("Input point location first, or draw a line on the panel first.");
                                return;
                            }
                        }
                        if (e.RowIndex >= _lines.Count)
                        {
                            MessageBox.Show("you have one or more incomplete line(s) before current line, please complete them first.");
                            return;
                        }
                        cell.Style.BackColor = colorDialog.Color;
                        _lines[e.RowIndex].LineColor = cell.Style.BackColor;
                        UpdatePictureBox();
                    }
                }
            } catch(Exception) 
            {
                MessageBox.Show("Input point location first, or draw a line on the panel first.");
            }
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _clickCount++;
            if (_clickCount == 1)
            {
                _firstClickPoint = e.Location;
            }
            else if (_clickCount == 2)
            {
                _secondClickPoint = e.Location;

                //create a new line
                Line newLine = new Line(_firstClickPoint, _secondClickPoint, _defaultLineColor);
                _lines.Add(newLine);
                UpdatePictureBox();

                int trackIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[trackIndex].Cells[0].Value = _firstClickPoint.X;
                dataGridView1.Rows[trackIndex].Cells[1].Value = _firstClickPoint.Y;
                dataGridView1.Rows[trackIndex].Cells[2].Value = _secondClickPoint.X;
                dataGridView1.Rows[trackIndex].Cells[3].Value = _secondClickPoint.Y;
                dataGridView1.Rows[trackIndex].Cells[4].Style.BackColor = _defaultLineColor; 
                _clickCount = 0;
            }
        }

        private bool findIntersection(Point p1, Point p2, Point p3, Point p4, out PointF intersection)
        {
            float line1PointX = p1.X - p2.X;
            float line1PointY = p2.Y - p1.Y;
            float line1Constant = line1PointY * p1.X + line1PointX * p1.Y;

            float line2PointX = p3.X - p4.X;
            float line2PointY = p4.Y - p3.Y;
            float line2Constant = line2PointY * p3.X + line2PointX * p3.Y;

            float determinant = line1PointY * line2PointX - line1PointX * line2PointY;

            if (determinant == 0)
            {
                // calculate the slope and intercept respectively.
                float k1 = line1PointY / line1PointX;
                float b1 = -1 * (k1 * p2.X + p2.Y);
                float k2 = line2PointY / line2PointX;
                float b2 = -1 * (k2 * p4.X + p4.Y);
                // if two parallel lines have the same intercept, then one overlaps the other
                if (b1 == b2)
                {
                    // make intersaction (-1,-1), to identify overlap case.
                    intersection = new PointF(-1, -1);
                    return true;
                }
                intersection = new PointF();
                return false;
            }
            else
            {
                float x = (line1Constant * line2PointX - line1PointX * line2Constant) / determinant;
                float y = (line1PointY * line2Constant - line1Constant * line2PointY) / determinant;
                intersection = new PointF(x, y);

                if (Math.Min(p1.X, p2.X) <= x && x <= Math.Max(p1.X, p2.X) && Math.Min(p1.Y, p2.Y) <= y && y <= Math.Max(p1.Y, p2.Y) &&
                    Math.Min(p3.X, p4.X) <= x && x <= Math.Max(p3.X, p4.X) && Math.Min(p3.Y, p4.Y) <= y && y <= Math.Max(p3.Y, p4.Y))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void DrawIntersections(List<PointF> intersections)
        {
            Bitmap bitmap = pictureBox1.Image as Bitmap;
            if (bitmap == null)
            {
                return;
            }
            Graphics g = Graphics.FromImage(bitmap);
            Color circleColor = _defaultLineColor;
            int circleRadius = 10;
            foreach (PointF intersection in intersections)
            {
                g.DrawEllipse(new Pen(circleColor), intersection.X - circleRadius, intersection.Y - circleRadius, circleRadius * 2, circleRadius * 2);
            }
            pictureBox1.Invalidate();
        }

        private void UpdatePictureBoxWithOverlap()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(System.Drawing.Color.White);
            Pen pen = new Pen(System.Drawing.Color.Black);

            foreach (Line line in _lines)
            {
                pen.Color = line.LineColor;
                g.DrawLine(pen, line.Point1, line.Point2);
            }

            foreach (Line line in _overlapLines)
            {
                pen.Color = line.LineColor;
                g.DrawLine(pen, line.Point1, line.Point2);
            }

            pictureBox1.Image = bitmap;

            pictureBox1.Invalidate();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            List<PointF> intersectionPoints = new List<PointF>();

            for (int i = 0; i < _lines.Count; i++)
            {
                for (int j = i + 1; j < _lines.Count; j++)
                {
                    PointF intersection;
                    Line line1 = _lines[i];
                    Line line2 = _lines[j];
                    if (findIntersection(line1.Point1, line1.Point2, line2.Point1, line2.Point2, out intersection))
                    {
                        // one line overlap the other
                        if (intersection.X == -1 && intersection.Y == -1)
                        {
                            // Compare points's position, find the overlap part.
                            int[] positionX = { line1.Point1.X, line1.Point2.X, line2.Point1.X, line2.Point2.X };
                            Array.Sort(positionX);
                            int[] positionY = { line1.Point1.Y, line1.Point2.Y, line2.Point1.Y, line2.Point2.Y };
                            Array.Sort(positionY);
                            // Because one line overlaps the other,
                            // then the first intersected line's point is the second in the two sorted arrays,
                            // the second intersacted line's point is the third one in the two sorted arrays
                            Point firstPoint = new Point(positionX[1], positionY[1]);
                            Point secondPoint = new Point(positionX[2], positionY[2]);
                            Line newline = new Line(firstPoint, secondPoint, _defaultLineColor);
                            _overlapLines.Add(newline);
                            continue;
                        }
                        // the normal intersection
                        intersectionPoints.Add(intersection);
                    }
                }
            }
            UpdatePictureBoxWithOverlap();
            DrawIntersections(intersectionPoints);
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCell cell = dataGridView1.SelectedCells[0];
                _lines.RemoveAt(cell.RowIndex);
                dataGridView1.Rows.RemoveAt(cell.RowIndex);
                UpdatePictureBox();
            }
            catch(Exception)
            {
                MessageBox.Show("Choose an item to remove, plz.");
            }
            
        }
    }
}

