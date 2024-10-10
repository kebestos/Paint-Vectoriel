using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint_Vectoriel
{
    
    class Texte : Shape
    {
        private Font font;
        private String str;

        public Texte(int x, int y, int width, int height, Color couleur, Font font, String str) :base (x,y,width,height,couleur)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.couleur = couleur;
            this.font = font;
            this.str = str;
        }

        public override void Draw(Graphics g)
        {
            Rectangle rectangle = new Rectangle(x, y, width, height);
            SolidBrush sb = new SolidBrush(couleur);
            g.DrawString(str,font,sb,rectangle);
        }

        public override String GetTexte()
        {
            return str;
        }
    }
}
