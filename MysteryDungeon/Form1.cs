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
		List<string> directList = new List<string>();
		List<Point> moveList = new List<Point>();
		#endregion

		#region Integers
		int playerX = 0;
		int playerY = 0;
		int runspeed = 2;
		#endregion

		#region Booleans
		bool moving = false;
		bool dialogue = false;
		bool dungeon = true;
		#endregion

		#region direction and feet strings
		string rightLeft = "left";
		string direction = "down";
		#endregion

		#region rectangles boi
		Rectangle debug = new Rectangle(0, 0, 768, 96);
		Rectangle debug1 = new Rectangle(0, 96, 96, 648);
		Rectangle debug2 = new Rectangle(96, 168, 48, 120);
		Rectangle debug3 = new Rectangle(96, 288, 24, 456);
		Rectangle debug4 = new Rectangle(120, 432, 144, 312);
		Rectangle debug5 = new Rectangle(246, 480, 48, 264);
		Rectangle debug6 = new Rectangle(312, 528, 144, 48);
		Rectangle debug7 = new Rectangle(312, 576, 288, 168);
		Rectangle debug8 = new Rectangle(600, 288, 168, 456);
		Rectangle debug9 = new Rectangle(336, 288, 120, 216);
		Rectangle debug10 = new Rectangle(288, 432, 48, 24);
		Rectangle debug11 = new Rectangle(168, 168, 600, 120);
		Rectangle debug12 = new Rectangle(192, 96, 576, 72);
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

		#region

		#endregion

		public MysteryDungeonForm()
		{
			InitializeComponent();
			playerX = 36;
			playerY = 52;
		}

		private void Collider() //Collision Data stored here
		{

			#region Boxes
			debug.X = 0 - playerX;
			debug.Y = 0 - playerY;

			debug1.X = 0 - playerX;
			debug1.Y = 96 - playerY;

			debug2.X = 96 - playerX;
			debug2.Y = 168 - playerY;

			debug3.X = 96 - playerX;
			debug3.Y = 288 - playerY;

			debug4.X = 120 - playerX;
			debug4.Y = 432 - playerY;

			debug5.X = 264 - playerX;
			debug5.Y = 480 - playerY;

			debug6.X = 312 - playerX;
			debug6.Y = 528 - playerY;

			debug7.X = 312 - playerX;
			debug7.Y = 576 - playerY;

			debug8.X = 600 - playerX;
			debug8.Y = 288 - playerY;

			debug9.X = 336 - playerX;
			debug9.Y = 288 - playerY;

			debug10.X = 288 - playerX;
			debug10.Y = 432 - playerY;

			debug11.X = 168 - playerX;
			debug11.Y = 168 - playerY;

			debug12.X = 192 - playerX;
			debug12.Y = 96 - playerY;
			#endregion

			if (Player.Collision(debug) ||
					Player.Collision(debug1) ||
					Player.Collision(debug2) ||
					Player.Collision(debug3) ||
					Player.Collision(debug4) ||
					Player.Collision(debug5) ||
					Player.Collision(debug6) ||
					Player.Collision(debug7) ||
					Player.Collision(debug8) ||
					Player.Collision(debug9) ||
					Player.Collision(debug10) ||
					Player.Collision(debug11) ||
					Player.Collision(debug12))
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
							+ "Box " + Player.isColliding + "\n"
							+ "Box CPU " + Partner.isColliding;
			#endregion

			Refresh();
		}

		private void MysteryDungeon_Paint(object sender, PaintEventArgs e) //All images drawn here
		{
			Pen colliPen = new Pen(Color.Red);

			if (!dungeon)
			{
				e.Graphics.DrawImage(Properties.Resources.generic_ground, (108 - playerX), (68 - playerY), 24, 24);
				e.Graphics.DrawImage(Properties.Resources.pkmnsqre, (0 - playerX), (0 - playerY), 958, 719);
			}
			else
			{
				e.Graphics.DrawImage(Properties.Resources.dungeon, 0 - playerX, 0 - playerY, 768, 744);
			}

			#region Direction Player
			Player.MoveGraphics();
			e.Graphics.DrawImage(Player.sprite, Player.x, Player.y - 6, Player.size, Player.size);
			e.Graphics.DrawImage(Partner.sprite, Partner.x, Partner.y - 6, Partner.size, Partner.size);
			e.Graphics.DrawRectangle(colliPen, playerX, playerY, 5, 5);
			#endregion

			e.Graphics.DrawRectangle(colliPen, debug);
			e.Graphics.DrawRectangle(colliPen, debug1);
			e.Graphics.DrawRectangle(colliPen, debug2);
			e.Graphics.DrawRectangle(colliPen, debug3);
			e.Graphics.DrawRectangle(colliPen, debug4);
			e.Graphics.DrawRectangle(colliPen, debug5);
			e.Graphics.DrawRectangle(colliPen, debug6);
			e.Graphics.DrawRectangle(colliPen, debug7);
			e.Graphics.DrawRectangle(colliPen, debug8);
		}

	}
}

