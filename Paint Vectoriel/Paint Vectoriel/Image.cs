using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint_Vectoriel
{
    class Image : Shape
    {
        string location;
        Bitmap bitmap;
        public Image(int x, int y, int width, int height, Color couleur,string location) :base (x,y,width,height,couleur)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.couleur = couleur;
            this.location = location;
            this.bitmap = (Bitmap)Bitmap.FromFile(location);
        }

        public override void Draw(Graphics g)
        {            
            g.DrawImage(bitmap,x, y, width, height);
        }
        public override String GetLocation()
        {
            return location;
        }
    }
}
