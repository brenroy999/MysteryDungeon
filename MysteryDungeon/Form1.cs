using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MysteryDungeon
{
	public partial class MysteryDungeonForm : Form
	{
		#region Lists
		List<poké> Pokémon = new List<poké>();
		List<townshopkeep> SquareShops = new List<townshopkeep>();
		List<Rectangle> Walls = new List<Rectangle>();
		#endregion

		#region Integers
		int playerX = -109;
		int playerY = 243;
		int runspeed = 2;
		#endregion

		#region Booleans
		bool moving = false;
		bool dialogue = false;
		bool dungeon = false;
		#endregion

		#region direction and feet strings
		string rightLeft = "left";
		string direction = "down";
		#endregion

		#region rectangles boi
		Rectangle debug = new Rectangle(0, 256, 54, 47);
		Rectangle debug1 = new Rectangle(98, 280, 20, 11);
		Rectangle debug2 = new Rectangle(0, 343, 216, 376);
		#endregion

		#region Key Bools
		bool downW = false;
		bool downA = false;
		bool downS = false;
		bool downD = false;
		bool aButton = false;
		bool bButton = false;
		bool startButton = false;
		#endregion

		poké Player = new poké("Treecko", "down", 108, 68, 24, Properties.Resources.treecko_F);
		poké Partner = new poké("Torchic", "down", 108, 92, 24, Properties.Resources.Torchic_F);

		public MysteryDungeonForm()
		{
			InitializeComponent();
			Walls.Add(debug);
		}

		private void Collider() //Collision Data stored here
		{
			debug.X = 0 - playerX;
			debug.Y = 256 - playerY;
			debug1.X = 98 - playerX;
			debug1.Y = 280 - playerY;
			debug2.X = 0 - playerX;
			debug2.Y = 343 - playerY;

			if (Player.Collision(debug)|| Player.Collision(debug1) || Player.Collision(debug2))
			{
				switch (Player.direction)
				{
					case "up":
						{
							playerY += runspeed;
						}
						break;
					case "down":
						{
							playerY -= runspeed;
						}
						break;
					case "left":
						{
							playerX += runspeed;
						}
						break;
					case "right":
						{
							playerX -= runspeed;
						}
						break;

					#region Diagonal collisions
					case "upleft":
						playerX += runspeed;
						playerY += runspeed;
						break;
					case "upright":
						playerX -= runspeed;
						playerY += runspeed;
						break;
					case "downleft":
						playerX += runspeed;
						playerY -= runspeed;
						break;
					case "downright":
						playerX -= runspeed;
						playerY -= runspeed;
						break;
						#endregion
				}
			}
		}

		private void MysteryDungeon_KeyDown(object sender, KeyEventArgs e) //All inputs stored here
		{
			switch (e.KeyCode)
			{
				case Keys.W:
					downW = true;
					break;

				case Keys.A:
					downA = true;
					break;

				case Keys.S:
					downS = true;
					break;

				case Keys.D:
					downD = true;
					break;

				#region Buttons
				case Keys.NumPad0:
					startButton = true;
					break;

				case Keys.NumPad4:
					aButton = true;
					break;

				case Keys.NumPad6:
					bButton = true;
					break;
					#endregion
			}
		}

		private void MysteryDungeon_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.W:
					downW = false;
					break;

				case Keys.A:
					downA = false;
					break;

				case Keys.S:
					downS = false;
					break;

				case Keys.D:
					downD = false;
					break;

				case Keys.NumPad0:
					startButton = false;
					break;

				case Keys.NumPad4:
					aButton = false;
					break;

				case Keys.NumPad6:
					bButton = false;
					break;
			}
		}

		private void PokeSquare()
		{
			dungeon = false;
		}

		private void MockDungeon()
		{
			dungeon = true;
		}

		private void gameTimer_Tick(object sender, EventArgs e) //All animation is calculated here
		{
			if (dungeon) //Dungeon Movement
			{
				if (!moving || !dialogue)
				{
					if (downW && !downA && !downD)
					{
						moving = true;
						for (int r = 0; r <= 23; r++)
						{
							Player.direction = "up";
							playerY--;

							Collider();
							Refresh();
						}
						moving = false;
					}

					if (downS && !downA && !downD)
					{
						moving = true;
						for (int r = 0; r <= 23; r++)
						{
							Player.direction = "down";
							playerY++;

							Collider();
							Refresh();
						}
						moving = false;
					}

					if (downA && !downW && !downS)
					{
						moving = true;
						for (int r = 0; r <= 23; r++)
						{
							Player.direction = "left";
							playerX--;

							Collider();
							Refresh();
						}
						moving = false;
					}

					if (downD && !downW && !downS)
					{
						moving = true;
						for (int r = 0; r <= 23; r++)
						{
							Player.direction = "right";
							playerX++;

							Collider();
							Refresh();
						}
						moving = false;
					}

					#region diagonals

					if (downW && downA)
					{
						moving = true;
						for (int r = 0; r <= 23; r++)
						{
							Player.direction = "upleft";
							playerX--;
							playerY--;

							Collider();
							Refresh();
						}
						moving = false;
					}

					if (downW && downD)
					{
						moving = true;
						for (int r = 0; r <= 23; r++)
						{
							Player.direction = "upright";
							playerX++;
							playerY--;

							Collider();
							Refresh();
						}
						moving = false;
					}

					if (downS && downD)
					{
						moving = true;
						for (int r = 0; r <= 23; r++)
						{
							Player.direction = "downright";
							playerX++;
							playerY++;

							Collider();
							Refresh();
						}
						moving = false;
					}

					if (downS && downA)
					{
						moving = true;
						for (int r = 0; r <= 23; r++)
						{
							Player.direction = "downleft";
							playerX--;
							playerY++;

							Collider();
							Refresh();
						}
						moving = false;
					}

					#endregion
				}
			}

			else //Pokémon Square and Friend Areas
			{
				if (bButton)
				{
					runspeed = 8;
				}
				else
				{
					runspeed = 4;
				}
				gameTimer.Interval = 2;

				if (downW)
				{
					Player.direction = "up";
					playerY -= runspeed;
				}
				if (downS)
				{
					Player.direction = "down";
					playerY += runspeed;
				}
				if (downA)
				{
					Player.direction = "left";
					playerX -= runspeed;
				}
				if (downD)
				{
					Player.direction = "right";
					playerX += runspeed;
				}


				#region Diagonals
				if (downW && downA)
				{
					Player.direction = "upleft";
				}

				if (downW && downD)
				{
					Player.direction = "upright";
				}

				if (downS && downA)
				{
					Player.direction = "downleft";
				}

				if (downS && downD)
				{
					Player.direction = "downright";
				}

				Collider();
				#endregion
			}

			#region debug label
			debugLabel.Text = playerX + "\n"
							+ playerY + "\n"
							+ debug.X + "\n"
							+ debug.Y + "\n"
							+ direction + "\n"
							+ "W " + downW + "\n"
							+ "A " + downA + "\n"
							+ "S " + downS + "\n"
							+ "D " + downD + "\n"
							+ "Box " + Player.isColliding;
			#endregion

			Refresh();
		}

		private void MysteryDungeon_Paint(object sender, PaintEventArgs e) //All images drawn here
		{
			Pen colliPen = new Pen(Color.Red);

			e.Graphics.DrawImage(Properties.Resources.generic_ground, (108 - playerX), (68 - playerY), 24, 24);
			e.Graphics.DrawImage(Properties.Resources.pkmnsqre, (0 - playerX), (0 - playerY), 958, 719);

			#region Direction Player
			Player.MoveGraphics();
			e.Graphics.DrawImage(Player.sprite, Player.x, Player.y, Player.size, Player.size);
			e.Graphics.DrawImage(Partner.sprite, Partner.x, Partner.y, Partner.size, Partner.size);

			//if (direction == "up")
			//{
			//	e.Graphics.DrawImage(Properties.Resources.treecko_B, player);
			//}
			//if (direction == "down")
			//{
			//	e.Graphics.DrawImage(Properties.Resources.treecko_F, player);
			//}
			//if (direction == "right")
			//{
			//	e.Graphics.DrawImage(Properties.Resources.treecko_R, player);
			//}
			//if (direction == "left")
			//{
			//	e.Graphics.DrawImage(Properties.Resources.treecko_L, player);
			//}

			//if (direction == "upleft")
			//{
			//	e.Graphics.DrawImage(Properties.Resources.treecko_bl, player);
			//}
			//if (direction == "downleft")
			//{
			//	e.Graphics.DrawImage(Properties.Resources.treecko_fl, player);
			//}
			//if (direction == "upright")
			//{
			//	e.Graphics.DrawImage(Properties.Resources.treecko_br, player);
			//}
			//if (direction == "downright")
			//{
			//	e.Graphics.DrawImage(Properties.Resources.treecko_fr, player);
			//}
			#endregion

			e.Graphics.DrawRectangle(colliPen, debug);
			e.Graphics.DrawRectangle(colliPen, debug1);
			e.Graphics.DrawRectangle(colliPen, debug2);
		}

	}
}

