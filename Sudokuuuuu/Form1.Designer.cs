namespace Sudokuuuuu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            title_label = new Label();
            play_button = new Button();
            solver_button = new Button();
            rules_button = new Button();
            about_button = new Button();
            SuspendLayout();
            // 
            // title_label
            // 
            title_label.AutoSize = true;
            title_label.Font = new Font("Showcard Gothic", 30F);
            title_label.ForeColor = Color.Coral;
            title_label.Location = new Point(240, 59);
            title_label.Name = "title_label";
            title_label.Size = new Size(370, 62);
            title_label.TabIndex = 0;
            title_label.Text = "SUDOKUUUUU";
            // 
            // play_button
            // 
            play_button.BackColor = SystemColors.ControlLightLight;
            play_button.Font = new Font("ROG Fonts", 20F);
            play_button.ForeColor = Color.CornflowerBlue;
            play_button.Location = new Point(322, 141);
            play_button.Name = "play_button";
            play_button.Size = new Size(209, 69);
            play_button.TabIndex = 1;
            play_button.Text = "Play";
            play_button.UseVisualStyleBackColor = false;
            play_button.Click += play_button_Click;
            // 
            // solver_button
            // 
            solver_button.BackColor = SystemColors.ControlLightLight;
            solver_button.Font = new Font("ROG Fonts", 20F);
            solver_button.ForeColor = Color.CornflowerBlue;
            solver_button.Location = new Point(322, 216);
            solver_button.Name = "solver_button";
            solver_button.Size = new Size(209, 69);
            solver_button.TabIndex = 2;
            solver_button.Text = "Solver";
            solver_button.UseVisualStyleBackColor = false;
            // 
            // rules_button
            // 
            rules_button.BackColor = SystemColors.ControlLightLight;
            rules_button.Font = new Font("ROG Fonts", 20F);
            rules_button.ForeColor = Color.CornflowerBlue;
            rules_button.Location = new Point(322, 291);
            rules_button.Name = "rules_button";
            rules_button.Size = new Size(209, 69);
            rules_button.TabIndex = 3;
            rules_button.Text = "Rules";
            rules_button.UseVisualStyleBackColor = false;
            // 
            // about_button
            // 
            about_button.BackColor = SystemColors.ControlLightLight;
            about_button.Font = new Font("ROG Fonts", 20F);
            about_button.ForeColor = Color.CornflowerBlue;
            about_button.Location = new Point(322, 366);
            about_button.Name = "about_button";
            about_button.Size = new Size(209, 69);
            about_button.TabIndex = 4;
            about_button.Text = "About";
            about_button.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(838, 552);
            Controls.Add(about_button);
            Controls.Add(rules_button);
            Controls.Add(solver_button);
            Controls.Add(play_button);
            Controls.Add(title_label);
            ForeColor = SystemColors.ControlText;
            Name = "Form1";
            Text = "Sudokuuuuu";
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title_label;
        private Button play_button;
        private Button solver_button;
        private Button rules_button;
        private Button about_button;

        private Label[,] cells;
        private Label background;
        private Button menu_button;

        private bool is_play_screen;
        private Label active_cell;
        private int active_x, active_y;
    }
}
