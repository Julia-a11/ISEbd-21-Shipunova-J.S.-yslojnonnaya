using System.Drawing;

namespace Laboratornaya
{
    class Plane : IAdditions
    {
        private PlanesEnum planeEnum;

        public Plane(int digit)
        {
            Digit = digit;
        }

        public int Digit { set => planeEnum = (PlanesEnum)value; }

        public void DrawAdditions(Graphics g, float _startPosX, float _startPosY)
        {
            switch (planeEnum)
            {
                case PlanesEnum.Three:
                    DrawPlaneThree(g, _startPosX, _startPosY);
                    break;
                case PlanesEnum.Four:
                    DrawPlaneFour(g, _startPosX, _startPosY);
                    break;
                case PlanesEnum.Five:
                    DrawPlaneFive(g, _startPosX, _startPosY);
                    break;
            }
        }

        private void DrawPlaneThree(Graphics g, float _startPosX, float _startPosY)
        {
            g.DrawLine(new Pen(Color.Black), _startPosX + 104, _startPosY + 27, _startPosX + 104, _startPosY + 43);
            g.DrawLine(new Pen(Color.Black), _startPosX + 104, _startPosY + 35, _startPosX + 120, _startPosY + 35);
            g.FillRectangle(new SolidBrush(Color.LightSlateGray), _startPosX + 111, _startPosY + 26, 5, 20);

            g.DrawLine(new Pen(Color.Black), _startPosX + 40, _startPosY + 27, _startPosX + 40, _startPosY + 43);
            g.DrawLine(new Pen(Color.Black), _startPosX + 40, _startPosY + 35, _startPosX + 56, _startPosY + 35);
            g.FillRectangle(new SolidBrush(Color.LightSlateGray), _startPosX + 47, _startPosY + 26, 5, 20);

            g.DrawLine(new Pen(Color.Black), _startPosX + 56, _startPosY + 48, _startPosX + 56, _startPosY + 64);
            g.DrawLine(new Pen(Color.Black), _startPosX + 56, _startPosY + 56, _startPosX + 72, _startPosY + 56);
            g.FillRectangle(new SolidBrush(Color.LightSlateGray), _startPosX + 63, _startPosY + 49, 5, 18);
        }

        private void DrawPlaneFour(Graphics g, float _startPosX, float _startPosY)
        {
            DrawPlaneThree(g, _startPosX, _startPosY);
            g.DrawLine(new Pen(Color.Black), _startPosX + 72, _startPosY + 27, _startPosX + 72, _startPosY + 43);
            g.DrawLine(new Pen(Color.Black), _startPosX + 72, _startPosY + 35, _startPosX + 88, _startPosY + 35);
            g.FillRectangle(new SolidBrush(Color.LightSlateGray), _startPosX + 79, _startPosY + 26, 5, 20);
        }

        private void DrawPlaneFive(Graphics g, float _startPosX, float _startPosY)
        {
            DrawPlaneFour(g, _startPosX, _startPosY);
            g.DrawLine(new Pen(Color.Black), _startPosX + 88, _startPosY + 48, _startPosX + 88, _startPosY + 64);
            g.DrawLine(new Pen(Color.Black), _startPosX + 88, _startPosY + 56, _startPosX + 104, _startPosY + 56);
            g.FillRectangle(new SolidBrush(Color.LightSlateGray), _startPosX + 95, _startPosY + 49, 5, 18);
        }
    }
}