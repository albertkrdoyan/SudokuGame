using System;
using System.Drawing;
using System.Windows.Forms;

namespace SudokuUwUu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Load1();
        }

        private void Load1()
        {
            is_play_screen = false;

            cells = new Label[9, 9];

            int st_x = 70, st_y = 65, size = 60;
            int st_x_fixed = st_x;

            menu_button = new Button()
            {
                Location = new Point(10, 10),
                Size = new Size(150, 40),
                Text = "<- MENU",
                Font = new Font("Segoe UI Black", 15F, FontStyle.Bold),
                BackColor = SystemColors.ControlLightLight,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = play_button.ForeColor
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
                        Location = new Point(st_x, st_y),
                        Size = new Size(size, size),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Sanserif", 28F, FontStyle.Regular),
                        BorderStyle = BorderStyle.FixedSingle,
                        Text = "",
                        BackColor = Color.White,
                    };                                                          
                    this.Controls.Add(cells[i, j]);
                    cells[i, j].Click += CellClick;
                    cells[i, j].BringToFront();
                    cells[i, j].Visible = false;

                    st_x += size + ((j + 1) % 3 == 0 ? 3 : 0);
                }
                st_x = st_x_fixed;
                st_y += size + ((i + 1) % 3 == 0 ? 3 : 0);
            }

            mode_button = new Label()
            {
                Font = menu_button.Font,
                Size = menu_button.Size,
                BackColor = menu_button.BackColor,
                ForeColor = menu_button.ForeColor,
                Location = new Point(cells[0, 3].Location.X + size / 2, menu_button.Location.Y),
                Text = "Mode: Final",
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle
            };
            mode_button.Click += new EventHandler(Mode_change_click);
            is_edit_mode = false;

            this.Controls.Add(mode_button);
            this.Controls.Add(background);
            this.Controls.Add(menu_button);
            mode_button.Visible = background.Visible = menu_button.Visible = false;
        }

        private void Mode_change_click(object sender, EventArgs e)
        {
            if (is_edit_mode)
                mode_button.Text = "Mode: Final";
            else
                mode_button.Text = "Mode: Edit";

            is_edit_mode = !is_edit_mode;
            this.Focus();
        }

        private void CellClick(object sender, EventArgs e)
        {
            if (sender is Label cell)
            {
                if (active_cell != null)
                    active_cell.BackColor = SystemColors.ControlLightLight;
                active_cell = cell;

                cell.BackColor = Color.LightBlue;
            }
        }

        private void MenuScreeLoad(object sender, EventArgs e)
        {
            this.Height = 460;
            this.Width = 640;
            this.DesktopLocation = new Point(this.Location.X + 120, this.Location.Y + 90);            

            is_play_screen = false;
            if (active_cell != null)
            {
                active_cell.BackColor = SystemColors.ControlLightLight;
                active_cell = null;
            }

            title_label.Enabled = title_label.Visible = true;
            play_button.Enabled = play_button.Visible = true;
            solver_button.Enabled = solver_button.Visible = true;
            rules_button.Enabled = rules_button.Visible = true;
            about_button.Enabled = about_button.Visible = true;
            mode_button.Visible = background.Visible = menu_button.Visible = false;

            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                    cells[i, j].Visible = false;
            }            
        }

        private void Play_button_Click(object sender, EventArgs e)
        {
            title_label.Enabled = title_label.Visible = false;
            play_button.Enabled = play_button.Visible = false;
            solver_button.Enabled = solver_button.Visible = false;
            rules_button.Enabled = rules_button.Visible = false;
            about_button.Enabled = about_button.Visible = false;

            this.Height = 670;
            this.Width = 750;
            this.DesktopLocation = new Point(this.Location.X - 120, this.Location.Y - 90);

            is_play_screen = is_edit_mode = false;

            mode_button.Text = "Mode: Final";

            mode_button.Visible = background.Visible = menu_button.Visible = true;

            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                    cells[i, j].Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            char n = e.KeyData.ToString()[e.KeyData.ToString().Length - 1];
            if (active_cell != null)
            {
                if (n > '0' && n <= '9')
                {
                    if (!is_edit_mode)
                    {
                        if (active_cell != null)
                            active_cell.Font = new Font("Sanserif", 28F, FontStyle.Regular);
                        active_cell.Text = n.ToString();
                    }
                    else
                    {
                        if (active_cell != null)
                            active_cell.Font = new Font("Sanserif", 12F, FontStyle.Regular);
                        active_cell.Text = MakeEditableCell(n - '0');
                    }
                }
                else if (n == 'c' || n == 'C')
                    active_cell.Text = "";
            }
            e.SuppressKeyPress = true;
        }

        private string MakeEditableCell(int pressed_num)
        {
            string res = active_cell.Text;

            bool[] nums = new bool[9];

            if (res.Length > 1)
            {
                for (int i = 0; i < res.Length; i++)
                {
                    if (res[i] > '0' && res[i] <= '9')
                        nums[res[i] - '0' - 1] = true;
                }
            }

            nums[pressed_num - 1] = !nums[pressed_num - 1];

            res = "";
            for (int i = 0; i < 9; ++i)
            {
                if (nums[i])
                    res += (i + 1).ToString();
                else
                    res += "  ";
                                
                if ((i + 1) % 3 == 0)
                    res += "\n";
                else
                    res += "  ";
            }

            return res;
        }

        int[,] GetNewSudokuBoard()
        {
            int[,] board = new int[9, 9];



            return board;
        }
    }
}
