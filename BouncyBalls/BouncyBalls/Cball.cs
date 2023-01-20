using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace BouncyBalls
{
    internal class Cball
    {
        private Point _position;
        private Point _direction;
        private Color _colour;
        private int _size;

        public Cball(Color colour)
        {
            this._colour = colour;
            this._size = 50;
            this._direction = new Point(100, 20);
            this._position = new Point(400, 300);
        }

        public Cball(Color colour, Point direction) : this(colour)
        {
            this._direction = direction;
        }

        public void Move()
        {
            if ((this._position.X < 0) || (this._position.X > 799))
            {
                this._direction.X = this._direction.X * (-1);
                this._size -= 2;
            }

            if ((this._position.Y < 0) || (this._position.Y > 600))
            {
                this._direction.Y = this._direction.Y * (-1);
                this._size -= 2;
            }

            this._position.X += this._direction.X;
            this._position.Y += this._direction.Y;
        }

        public void Render(CDrawer canvas)
        {
            if (this._size < 1) return;
            canvas.AddCenteredEllipse(this._position, this._size, this._size, this._colour, 2, Color.Black);
            canvas.Render();
        }

    }
}
