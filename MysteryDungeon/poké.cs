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

		public void TheorheticalGraphics()
		{

		}

		public void MoveGraphics()
		{
			#region Graphics
			Image fSprite = null;
			Image bSprite = null;
			Image lSprite = null;
			Image rSprite = null;
			//Diagonals
			Image flSprite = null;
			Image frSprite = null;
			Image blSprite = null;
			Image brSprite = null;

			if (name == "Treecko")
			{
				fSprite = Properties.Resources.treecko_F;
				bSprite = Properties.Resources.treecko_B;
				lSprite = Properties.Resources.treecko_L;
				rSprite = Properties.Resources.treecko_R;

				flSprite = Properties.Resources.treecko_fl;
				frSprite = Properties.Resources.treecko_fr;
				blSprite = Properties.Resources.treecko_bl;
				brSprite = Properties.Resources.treecko_br;
			}

			if (name == "Torchic")
			{
				fSprite = Properties.Resources.Torchic_F;
				bSprite = Properties.Resources.Torchic_B;
				lSprite = Properties.Resources.Torchic_L;
				rSprite = Properties.Resources.Torchic_R;

				flSprite = Properties.Resources.Torchic_fl;
				frSprite = Properties.Resources.Torchic_fr;
				blSprite = Properties.Resources.Torchic_bl;
				brSprite = Properties.Resources.Torchic_br;
			}
			#endregion

			#region Directions
			switch (direction)
			{
				case "up":
					sprite = bSprite;
					break;

				case "left":
					sprite = lSprite;
					break;

				case "right":
					sprite = rSprite;
					break;

				case "down":
					sprite = fSprite;
					break;

				case "upleft":
					sprite = blSprite;
					break;

				case "downleft":
					sprite = flSprite;
					break;

				case "upright":
					sprite = brSprite;
					break;

				case "downright":
					sprite = frSprite;
					break;
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
