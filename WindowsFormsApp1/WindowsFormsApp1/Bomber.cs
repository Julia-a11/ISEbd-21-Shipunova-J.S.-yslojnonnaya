using System.Drawing;

namespace Laboratornaya
{
    class Bomber : IAdditions
    {
        public void DrawAdditions(Graphics g, float _startPosX, float _startPosY)
        {
            switch (planeEnum)
            {
                case PlanesEnum.Three:
                    DrawBomberThree(g, _startPosX, _startPosY);
                    break;
                case PlanesEnum.Four:
                    DrawBomberFour(g, _startPosX, _startPosY);
                    break;
                case PlanesEnum.Five:
                    DrawBobmerFive(g, _startPosX, _startPosY);
                    break;
            }
        }

        public int Digit { set => planeEnum = (PlanesEnum)value; }

        private PlanesEnum planeEnum;

        public Bomber(int digit)
        {
            Digit = digit;
        }

        private void DrawBomber(Graphics g, float _startPosX, float _startPosY)
        {
            g.FillEllipse(new SolidBrush(Color.DarkGreen), _startPosX + 10, _startPosY + 30, 25, 8);
            g.DrawLine(new Pen(Color.Black), _startPosX + 35, _startPosY + 34, _startPosX + 38, _startPosY + 34);
            g.FillEllipse(new SolidBrush(Color.Black), _startPosX + 38, _startPosY + 31, 6, 6);
            Point[] points = new Point[4]
            {
                   new Point((int)(_startPosX + 25), (int)(_startPosY + 35)),
                   new Point((int)(_startPosX + 17), (int)(_startPosY + 26)),
                   new Point((int)(_startPosX + 17), (int)(_startPosY + 22 )),
                   new Point((int)(_startPosX + 33 ), (int)(_startPosY + 35)),
            };
            g.FillPolygon(new SolidBrush(Color.DarkGreen), points);

            points = new Point[4]
            {
                   new Point((int)(_startPosX + 20), (int)(_startPosY + 38)),
                   new Point((int)(_startPosX + 17), (int)(_startPosY + 42)),
                   new Point((int)(_startPosX + 17), (int)(_startPosY + 46 )),
                   new Point((int)(_startPosX + 33 ), (int)(_startPosY + 33)),
            };
            g.FillPolygon(new SolidBrush(Color.DarkGreen), points);

            points = new Point[4]
            {
                   new Point((int)(_startPosX + 13), (int)(_startPosY + 35)),
                   new Point((int)(_startPosX + 5), (int)(_startPosY + 24)),
                   new Point((int)(_startPosX + 5), (int)(_startPosY + 28 )),
                   new Point((int)(_startPosX + 9 ), (int)(_startPosY + 35)),
            };
            g.FillPolygon(new SolidBrush(Color.DarkGreen), points);

            points = new Point[4]
            {
                   new Point((int)(_startPosX + 9), (int)(_startPosY + 35)),
                   new Point((int)(_startPosX + 5), (int)(_startPosY + 40)),
                   new Point((int)(_startPosX + 5), (int)(_startPosY + 44 )),
                   new Point((int)(_startPosX + 13 ), (int)(_startPosY + 35)),
            };
            g.FillPolygon(new SolidBrush(Color.DarkGreen), points);
        }

        private void DrawBomberThree(Graphics g, float _startPosX, float _startPosY)
        {
            DrawBomber(g, _startPosX + 10, _startPosY + 1);
            DrawBomber(g, _startPosX + 40, _startPosY + 27);
            DrawBomber(g, _startPosX + 50, _startPosY + 1);
        }

        private void DrawBomberFour(Graphics g, float _startPosX, float _startPosY)
        {
            DrawBomberThree(g, _startPosX, _startPosY);
            DrawBomber(g, _startPosX + 80, _startPosY + 29);
        }

        private void DrawBobmerFive(Graphics g, float _startPosX, float _startPosY)
        {
            DrawBomberFour(g, _startPosX, _startPosY);
            DrawBomber(g, _startPosX + 90, _startPosY + 1);
        }
    }
}
