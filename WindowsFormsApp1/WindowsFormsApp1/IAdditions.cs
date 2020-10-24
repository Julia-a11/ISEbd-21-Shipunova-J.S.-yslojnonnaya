using System.Drawing;

namespace Laboratornaya
{
    public interface IAdditions
    {
        int Digit { set; }
        void DrawAdditions(Graphics g, float _startPosX, float _startPosY);
    }
}
