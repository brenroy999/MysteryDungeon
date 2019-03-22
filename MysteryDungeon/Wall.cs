using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MysteryDungeon
{
	class Wall
	{
		public Point loc, global, size;
		public string isColliding = "False";

		public Wall(Point _loc, Point _global, Point _size)
		{
			loc = _loc;
			size = _size;
			global = _global;
		}

		public bool Collision(Rectangle collide)
		{
			Rectangle wall = new Rectangle(loc.X, loc.Y, size.X, size.Y);

			if (wall.IntersectsWith(collide))
			{
				isColliding = "true";
				return true;
			}
			else
			{
				isColliding = "false";
				return false;
			}
		}
	}
}
