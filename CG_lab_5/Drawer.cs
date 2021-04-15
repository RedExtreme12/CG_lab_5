using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Drawer
    {
        private static int GRID_DIVISIONS = 10;
        private static Font DEFAULT_FONT => new Font("Arial", 8);
        private static Brush BACKGROUND_BRUSH = new SolidBrush(Color.FromArgb(50, 50, 50));
        private static Brush TEXT_BRUSH = new SolidBrush(Color.FromArgb(200, 200, 200));

        private static Pen GRID_PEN = new Pen(Color.FromArgb(100, 100, 100));
        private static Pen RECTANGLE_PEN = new Pen(Color.FromArgb(0, 0, 150), 3);
        private static Pen BASE_LINE_PEN = new Pen(Color.FromArgb(150, 0, 0), 2);
        private static Pen CLIPPED_LINE_PEN = new Pen(Color.FromArgb(0, 150, 0), 2);

        private Bitmap bitmap;
        private Graphics graphics;
        private Rectangle clippingRect;
        private Rectangle imageRect;

        private const byte BIT_MAX_Y_INTERSECTION = 1;
        private const byte BIT_MAX_X_INTERSECTION = 1 << 1;
        private const byte BIT_MIN_Y_INTERSECTION = 1 << 2;
        private const byte BIT_MIN_X_INTERSECTION = 1 << 3;

        public void Start(Rectangle clippingRect)
        {
            this.clippingRect = clippingRect;
            imageRect = new Rectangle(clippingRect.X - this.clippingRect.Width / 2,
                clippingRect.Y - this.clippingRect.Height / 2,
                this.clippingRect.Width * 2, this.clippingRect.Height * 2);

            bitmap = new Bitmap(imageRect.Width, imageRect.Height);
            graphics = Graphics.FromImage(bitmap);

            graphics.FillRectangle(BACKGROUND_BRUSH, new Rectangle(0, 0, imageRect.Width, imageRect.Height));
            int gridXStep = imageRect.Width / GRID_DIVISIONS;
            int gridYStep = imageRect.Height / GRID_DIVISIONS;

            for (int x = 0; x < imageRect.Width; x += gridXStep)
            {
                graphics.DrawLine(GRID_PEN, x, 0, x, imageRect.Height);
                if (x != 0)
                {
                    graphics.DrawString(String.Format("{0}x", x + imageRect.X), DEFAULT_FONT, TEXT_BRUSH, x, 0);
                }
            }

            for (int y = 0; y < imageRect.Height; y += gridYStep)
            {
                graphics.DrawLine(GRID_PEN, 0, y, imageRect.Width, y);
                if (y != 0)
                {
                    graphics.DrawString(String.Format("{0}y", y + imageRect.Y), DEFAULT_FONT, TEXT_BRUSH, 0, y);
                }
            }

            graphics.DrawRectangle(RECTANGLE_PEN, new Rectangle(clippingRect.X - imageRect.X,
                clippingRect.Y - imageRect.Y, clippingRect.Width, clippingRect.Height));
        }

        public void DrawLine(int x0, int y0, int x1, int y1)
        {
            graphics.DrawLine(BASE_LINE_PEN, x0 - imageRect.X, y0 - imageRect.Y, 
                x1 - imageRect.X, y1 - imageRect.Y);
            DrawLineWithMedianPointClipping(x0, y0, x1, y1);
        }

        private void DrawLineWithMedianPointClipping(float x0, float y0, float x1, float y1)
        {
            float dx = Math.Abs(x1 - x0);
            float dy = Math.Abs(y1 - y0);

            if (Math.Sqrt(Math.Pow(x1 - x0, 2) + Math.Pow(y1 - y0, 2)) <= 1.0f)
            {
                return;
            }

            byte code0 = PlacementCode(x0, y0);
            byte code1 = PlacementCode(x1, y1);

            if ((code0 & code1) != 0)
            {
                return;
            }

            if ((code0 | code1) == 0)
            {
                graphics.DrawLine(CLIPPED_LINE_PEN, x0 - imageRect.X, y0 - imageRect.Y, 
                    x1 - imageRect.X, y1 - imageRect.Y);
                return;
            }

            float mx = x0 + (x1 - x0) / 2;
            float my = y0 + (y1 - y0) / 2;

            DrawLineWithMedianPointClipping(x0, y0, mx, my);
            DrawLineWithMedianPointClipping(mx, my, x1, y1);
        }

        private byte PlacementCode(float x, float y)
        {
            byte code = 0;
            if (y > clippingRect.Y + clippingRect.Height) code |= BIT_MAX_Y_INTERSECTION;
            if (x > clippingRect.X + clippingRect.Width) code |= BIT_MAX_X_INTERSECTION;
            if (y < clippingRect.Y) code |= BIT_MIN_Y_INTERSECTION;
            if (x < clippingRect.X) code |= BIT_MIN_X_INTERSECTION;
            return code;
        }

        public void DrawPolygon(List<Point> points)
        {
            DrawPolygonByPoints(BASE_LINE_PEN, points);
            DrawPolygonByPoints(CLIPPED_LINE_PEN, ClipPolygon(points));
        }

        private void DrawPolygonByPoints(Pen pen, List<Point> points)
        {
            for (int index = 0; index < points.Count; ++index)
            {
                Point current = points[index];
                Point next = points[(index + 1) % points.Count];
                graphics.DrawLine(pen, current.X - imageRect.X, current.Y - imageRect.Y,
                    next.X - imageRect.X, next.Y - imageRect.Y);
            }
        }

        private List<Point> ClipPolygon(List<Point> points)
        {
            List<Point> result = new List<Point>();
            if (!points.Any())
            {
                return result;
            }

            for (byte line = 1; line <= 8; line *= 2)
            {
                byte currentCode;
                byte nextCode = PlacementCode(points[0].X, points[0].Y);

                for (int index = 0; index < points.Count; ++index)
                {
                    Point current = points[index];
                    Point next = points[(index + 1) % points.Count];

                    currentCode = nextCode;
                    nextCode = PlacementCode(next.X, next.Y);

                    if ((currentCode & line) != 0 && (nextCode & line) != 0)
                    {
                        continue;
                    }

                    if ((currentCode & line) == 0)
                    {
                        result.Add(current);
                    }

                    AddIntermediatePoint(current, next, currentCode, line, result);
                    AddIntermediatePoint(current, next, nextCode, line, result);
                }

                points = result;
                result = new List<Point>();
            }

            return points;
        }

        private void AddIntermediatePoint(Point current, Point next, byte mask, byte clipper, List<Point> result)
        {
            if ((mask & clipper) != 0)
            {
                switch (clipper)
                {
                    case BIT_MAX_Y_INTERSECTION:
                        TestYIntersection(current, next, clippingRect.Y + clippingRect.Height, clipper, result);
                        break;
                    case BIT_MIN_Y_INTERSECTION:
                        TestYIntersection(current, next, clippingRect.Y, clipper, result);
                        break;
                    case BIT_MAX_X_INTERSECTION:
                        TestXIntersection(current, next, clippingRect.X + clippingRect.Width, clipper, result);
                        break;
                    case BIT_MIN_X_INTERSECTION:
                        TestXIntersection(current, next, clippingRect.X, clipper, result);
                        break;
                }
            }
        }

        private bool TestYIntersection(Point current, Point next, int y, byte clipper, List<Point> output)
        {
            int dX = next.X - current.X;
            int dY = next.Y - current.Y;

            if (dY == 0)
            {
                return false;
            }

            int x = (int)Math.Round(current.X + dX * (y - current.Y) / (float)dY);
            if ((PlacementCode(x, y) & clipper) == 0)
            {
                output.Add(new Point(x, y));
                return true;
            }

            return false;
        }

        private bool TestXIntersection(Point current, Point next, int x, byte clipper, List<Point> output)
        {
            int dX = next.X - current.X;
            int dY = next.Y - current.Y;

            if (dX == 0)
            {
                return false;
            }
            
            int y = (int)Math.Round(current.Y + dY * (x - current.X) / (float)dX);
            if ((PlacementCode(x, y) & clipper) == 0)
            {
                output.Add(new Point(x, y));
                return true;
            }

            return false;
        }

        public Bitmap End()
        {
            graphics.Dispose();
            return bitmap;
        }
    }
}
