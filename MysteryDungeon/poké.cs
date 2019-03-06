using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryDungeon
{
	class poké
	{
		public string name, direction;
		public int x, y, size;
		public Image sprite;
		public string isColliding = "False";

		#region unused stats
		//public int level, hp, spd, atk, spatk, def, spdef;
		#endregion

		public poké(string _name, string _direction, int _x, int _y, int _size, Image _sprite)
		{
			name = _name;
			direction = _direction;
			x = _x;
			y = _y;
			size = _size;
			sprite = _sprite;

			//level = _level;
			//hp = _hp;
			//spd = _spd;
			//atk = _atk;
			//spatk = _spatk;
			//def = _def;
			//spdef = _spdef;
		}

		public void MoveGraphics()
		{

			#region Directions
			if (direction == "up")
			{
				sprite = Properties.Resources.treecko_B;
			}
			if (direction == "left")
			{
				sprite = Properties.Resources.treecko_L;
			}
			if (direction == "right")
			{
				sprite = Properties.Resources.treecko_R;
			}
			if (direction == "down")
			{
				sprite = Properties.Resources.treecko_F;
			}

			if (direction == "upleft")
			{
				sprite = Properties.Resources.treecko_bl;
			}
			if (direction == "downleft")
			{
				sprite = Properties.Resources.treecko_fl;
			}
			if (direction == "upright")
			{
				sprite = Properties.Resources.treecko_br;
			}
			if (direction == "downright")
			{
				sprite = Properties.Resources.treecko_fr;
			}
			#endregion
		}

		public bool Collision(Rectangle collide)
		{
			Rectangle player = new Rectangle(x, y, size, size);

			if (player.IntersectsWith(collide))
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
