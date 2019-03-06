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
	public partial class MysteryDungeon : Form
	{
		public MysteryDungeon()
		{
			InitializeComponent();
		}

		#region Lists
		List<poké> Pokés = new List<poké>();

		#endregion

		#region Integers
		int playerX;
		int playerY;
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
		Rectangle player = new Rectangle(108, 68, 24, 24);
		Rectangle debug = new Rectangle(0, 0, 240, 20);
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

		poké Player = new poké("Treecko", "down", 108, 68, 24);

		private void Collider() //Collision Data stored here
		{
			debug.X = 0 - playerX;
			debug.Y = 0 - playerY;

			if (player.IntersectsWith(debug))
			{
				switch (direction)
				{
					case "up":
						{
							playerY = playerY + 1;
						}
						break;
					case "down":
						{
							playerY = playerY - 1;
						}
						break;
					case "left":
						{
							playerX = playerX + 1;
						}
						break;
					case "right":
						{
							playerX = playerX - 1;
						}
						break;

					#region Diagonal collisions
					case "upleft":
						playerX = playerX + 1;
						playerY = playerY + 1;
						break;
					case "upright":
						playerX = playerX - 1;
						playerY = playerY + 1;
						break;
					case "downleft":
						playerX = playerX + 1;
						playerY = playerY - 1;
						break;
					case "downright":
						playerX = playerX - 1;
						playerY = playerY - 1;
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
							direction = "up";
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
							direction = "down";
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
							direction = "left";
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
							direction = "right";
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
							direction = "upleft";
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
							direction = "upright";
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
							direction = "downright";
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
							direction = "downleft";
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
					direction = "up";
					playerY -= runspeed;
				}
				if (downS)
				{
					direction = "down";
					playerY += runspeed;
				}
				if (downA)
				{
					direction = "left";
					playerX -= runspeed;
				}
				if (downD)
				{
					direction = "right";
					playerX += runspeed;
				}


				#region Diagonals
				if (downW && downA)
				{
					direction = "upleft";
				}

				if (downW && downD)
				{
					direction = "upright";
				}

				if (downS && downA)
				{
					direction = "downleft";
				}

				if (downS && downD)
				{
					direction = "downright";
				}
				#endregion
			}

			#region debug label
			debugLabel.Text = playerX + "\n"
							+ playerY + "\n"
							+ debug.X + "\n"
							+ debug.Y + "\n"
							+ direction;
			#endregion

			Refresh();
		}

		private void MysteryDungeon_Paint(object sender, PaintEventArgs e) //All images drawn here
		{
			Pen colliPen = new Pen(Color.Red);

			e.Graphics.DrawImage(Properties.Resources.generic_ground, (108 - playerX), (68 - playerY), 24, 24);
			e.Graphics.DrawImage(Properties.Resources.pkmnsqre, (9 - playerX), (-313 - playerY), 958, 719);

			#region Direction Player
			if (direction == "up")
			{
				e.Graphics.DrawImage(Properties.Resources.treecko_B, player);
			}
			if (direction == "down")
			{
				e.Graphics.DrawImage(Properties.Resources.treecko_F, player);
			}
			if (direction == "right")
			{
				e.Graphics.DrawImage(Properties.Resources.treecko_R, player);
			}
			if (direction == "left")
			{
				e.Graphics.DrawImage(Properties.Resources.treecko_L, player);
			}

			if (direction == "upleft")
			{
				e.Graphics.DrawImage(Properties.Resources.treecko_bl, player);
			}
			if (direction == "downleft")
			{
				e.Graphics.DrawImage(Properties.Resources.treecko_fl, player);
			}
			if (direction == "upright")
			{
				e.Graphics.DrawImage(Properties.Resources.treecko_br, player);
			}
			if (direction == "downright")
			{
				e.Graphics.DrawImage(Properties.Resources.treecko_fr, player);
			}
			#endregion

			e.Graphics.DrawRectangle(colliPen, debug);
		}
	}
}
