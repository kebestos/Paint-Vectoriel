using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Paint_Vectoriel
{
    class Shape
    {
        public int x, y, width, height;
        public Color couleur;
        public Shape(int x,int y, int width, int height,Color couleur)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.couleur = couleur;

        }

        public virtual void Draw(Graphics g)
        {

        }

        public virtual String GetLocation()
        {
            return "";
        }

        public virtual String GetTexte()
        {
            return "";
        }



    }
}
