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
            new_game = true;
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
                for (int j = 0; j < 9; ++j)
                    cells[i, j].Visible = false;
        }

        private void Play_button_Click(object sender, EventArgs e)
        {
            if (new_game)
            {
                new_game = false;
                LoadTheBoard();
            }
            else
            {
                DialogResult res = MessageBox.Show("Start new game???", "Game", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                    LoadTheBoard();
            }

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
                for (int j = 0; j < 9; ++j)
                    cells[i, j].Visible = true;
        }

        private void LoadTheBoard()
        {
            main_board = GetRandomSudokuBoard();

            for (int i = 0; i < 9; ++i)
                for (int j = 0; j < 9; ++j)
                    cells[i, j].Text = (main_board[i, j] == 0 ? "" : main_board[i, j].ToString());
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
                        {
                            int i = active_cell.Name[5] - '0', j = active_cell.Name[7] - '0';
                            main_board[i, j] = n - '0';
                            active_cell.Font = new Font("Sanserif", 28F, FontStyle.Regular);
                            active_cell.ForeColor = Color.SteelBlue;

                            if (!CheckBoard(ref main_board, i, j))
                            {
                                main_board[i, j] = 0;
                                active_cell.Text = "";
                            }
                            else
                            {
                                active_cell.Text = n.ToString();

                                for (int k = 0; k < 9; ++k)
                                {
                                    if (j != k && cells[i, k].Text.Length > 2)
                                        MakeEditableCell(n - '0', ref cells[i, k], true);
                                    if (i != k && cells[k, j].Text.Length > 2)
                                        MakeEditableCell(n - '0', ref cells[k, j], true);
                                }

                                for (int y = 3 * (i / 3); y < 3 * (i / 3) + 3; ++y)
                                    for (int x = 3 * (j / 3); x < 3 * (j / 3) + 3; ++x)
                                        if (i != y && j != x && cells[y, x].Text.Length > 2)
                                            MakeEditableCell(n - '0', ref cells[y, x], true);
                            }
                        }
                    }
                    else
                    {
                        if (active_cell != null)
                            active_cell.Font = new Font("Sanserif", 12F, FontStyle.Regular);
                        MakeEditableCell(n - '0', ref active_cell);
                    }
                }
                else if (n == 'c' || n == 'C')
                    active_cell.Text = "";
            }
            e.SuppressKeyPress = true;
        }

        private void MakeEditableCell(int pressed_num, ref Label act_cell, bool remove = false)
        {
            string res = act_cell.Text;

            bool[] nums = new bool[9];

            if (res.Length > 1)
                for (int i = 0; i < res.Length; i++)
                    if (res[i] > '0' && res[i] <= '9')
                        nums[res[i] - '0' - 1] = true;

            if (!remove)
                nums[pressed_num - 1] = !nums[pressed_num - 1];
            else
                nums[pressed_num - 1] = false;

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

            act_cell.Text = res;
        }

        int[,] GetRandomSudokuBoard()
        {
            int[,] board = new int[9, 9];
            int[] row = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < 9; ++i)
            {
                Shuffle(ref row);
                for (int j = 0; j < 9; ++j)
                {
                    board[i, j] = row[j];
                    
                }
            }

            return board;
        }

        void Shuffle(ref int[] row)
        {
            Random random = new Random();
            for (int i = 0; i < 9; ++i)
            {
                int j = i + random.Next(0, 9 - i);
                (row[j], row[i]) = (row[i], row[j]);
            }
        }

        bool CheckBoard(ref int[,] board, int i, int j)
        {
            for (int k = 0; k < 9; ++k)
                if ((i != k && board[k, j] == board[i, j]) || (j != k && board[i, k] == board[i, j]))
                    return false;

            for (int y = 3 * (i / 3); y < 3 * (i / 3) + 3; ++y)
                for (int x = 3 * (j / 3); x < 3 * (j / 3) + 3; ++x)
                    if (i != y && j != x && board[y, x] == board[i, j])
                        return false;

            return true;
        }
    }
}
