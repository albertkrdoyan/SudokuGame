using System.Drawing;

namespace Sudokuuuuu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            is_play_screen = false;

            cells = new Label[9, 9];

            int st_x = 135, st_y = 65, size = 50;

            menu_button = new Button()
            {
                Location = new Point(10, 10),
                Size = new Size(175, 50),
                Text = "<- MENU",
                Font = new Font("Segoe UI Black", 15F, FontStyle.Bold),
                BackColor = SystemColors.ControlLightLight,
                TextAlign = ContentAlignment.MiddleCenter
            };
            menu_button.Click += MenuScreeLoad;

            background = new Label()
            {
                BackColor = Color.Black,
                Size = new Size(9 * size + 12, 9 * size + 12),
                Location = new Point(st_x - 3, st_y - 3),
            };

            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    cells[i, j] = new Label()
                    {
                        Name = "CELL " + i.ToString() + " " + j.ToString(),
                        TabIndex = i * 9 + j,
                        Location = new Point(st_x + (j * size) + (j % 3 == 0 ? 5 : 0), st_y + (i * size) + (i % 3 == 0 ? 5 : 0)),
                        Size = new Size(size, size),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Sanserif", 18F, FontStyle.Regular),
                        BorderStyle = BorderStyle.FixedSingle,
                        Text = "",
                        BackColor = Color.White,
                    };
                    cells[i, j].Click += CellClick;
                }
            }
        }

        private void CellClick(object? sender, EventArgs e)
        {
            if (sender is Label cell)
            {
                if (active_cell != null)
                    active_cell.BackColor = SystemColors.ControlLightLight;
                active_cell = cell;

                cell.BackColor = Color.LightBlue;

                //MessageBox.Show(cell.Name);
            }
        }

        private void MenuScreeLoad(object? sender, EventArgs e)
        {
            title_label.Enabled = true;
            play_button.Enabled = true;
            solver_button.Enabled = true;
            rules_button.Enabled = true;
            about_button.Enabled = true;

            title_label.Visible = true;
            play_button.Visible = true;
            solver_button.Visible = true;
            rules_button.Visible = true;
            about_button.Visible = true;

            is_play_screen = false;
            if (active_cell != null)
            {
                active_cell.BackColor = SystemColors.ControlLightLight;
                active_cell = null;
            }

            this.Controls.Remove(background);
            this.Controls.Remove(menu_button);
            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    this.Controls.Remove(cells[i, j]);
                }
            }
        }

        private void play_button_Click(object sender, EventArgs e)
        {
            title_label.Enabled = false;
            play_button.Enabled = false;
            solver_button.Enabled = false;
            rules_button.Enabled = false;
            about_button.Enabled = false;

            title_label.Visible = false;
            play_button.Visible = false;
            solver_button.Visible = false;
            rules_button.Visible = false;
            about_button.Visible = false;

            is_play_screen = true;

            this.Controls.Add(background);
            this.Controls.Add(menu_button);
            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    this.Controls.Add(cells[i, j]);
                    cells[i, j].BringToFront();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            char n = e.KeyData.ToString()[e.KeyData.ToString().Length - 1];
            if (active_cell != null)
            {
                if (n > '0' && n <= '9')
                {
                    active_cell.Text = n.ToString();
                }
                else if (n == 'c' || n == 'C')
                    active_cell.Text = "";
            }
            e.SuppressKeyPress = true;
        }
    }
}
