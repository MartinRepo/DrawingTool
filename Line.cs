using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp282assignment2_datagridVersion
{
    internal class Line
    {
        private Point _point1;
        private Point _point2;
        private Color _lineColor;

        public Line(Point point1, Point point2, Color lineColor)
        {
            _point1 = point1;
            _point2 = point2;
            _lineColor = lineColor;
        }

        public Point Point1
        {
            get { return _point1; }
            set { _point1 = value; }
        }

        public Point Point2
        {
            get { return _point2; }
            set { _point2 = value; }
        }

        public Color LineColor
        {
            get { return _lineColor; }
            set { _lineColor = value; }
        }

        public override string ToString()
        {
            return $"Firtst Point: ({Point1.X}, {Point1.Y}), Second Point: ({Point2.X}, {Point2.Y})";
        }
    }
}
