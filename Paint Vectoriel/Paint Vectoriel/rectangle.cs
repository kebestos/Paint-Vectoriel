using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint_Vectoriel
{
    class rectangle : Shape
    {
        public rectangle(int x, int y, int width, int height, Color couleur) :base (x,y,width,height,couleur)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.couleur = couleur;
        }

        public override void Draw(Graphics g)
        {
            SolidBrush sb = new SolidBrush(couleur);
            g.FillRectangle(sb, x, y, width, height);
        }       
    }
}
