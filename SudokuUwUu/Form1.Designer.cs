﻿using System.Drawing;
using System.Windows.Forms;

namespace SudokuUwUu
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title_label = new System.Windows.Forms.Label();
            this.play_button = new System.Windows.Forms.Label();
            this.solver_button = new System.Windows.Forms.Label();
            this.rules_button = new System.Windows.Forms.Label();
            this.about_button = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Showcard Gothic", 30F);
            this.title_label.ForeColor = System.Drawing.Color.Coral;
            this.title_label.Location = new System.Drawing.Point(227, 55);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(370, 62);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "SUDOKUUUUU";
            // 
            // play_button
            // 
            this.play_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.play_button.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.play_button.Font = new System.Drawing.Font("ROG Fonts", 20F);
            this.play_button.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.play_button.Location = new System.Drawing.Point(309, 121);
            this.play_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.play_button.Name = "play_button";
            this.play_button.Size = new System.Drawing.Size(209, 55);
            this.play_button.TabIndex = 1;
            this.play_button.Text = "Play";
            this.play_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.play_button.Click += new System.EventHandler(this.Play_button_Click);
            // 
            // solver_button
            // 
            this.solver_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.solver_button.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.solver_button.Font = new System.Drawing.Font("ROG Fonts", 20F);
            this.solver_button.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.solver_button.Location = new System.Drawing.Point(309, 181);
            this.solver_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.solver_button.Name = "solver_button";
            this.solver_button.Size = new System.Drawing.Size(209, 55);
            this.solver_button.TabIndex = 2;
            this.solver_button.Text = "Solver";
            this.solver_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.solver_button.Click += new System.EventHandler(this.Solver_button_Click);
            // 
            // rules_button
            // 
            this.rules_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rules_button.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rules_button.Font = new System.Drawing.Font("ROG Fonts", 20F);
            this.rules_button.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.rules_button.Location = new System.Drawing.Point(309, 241);
            this.rules_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rules_button.Name = "rules_button";
            this.rules_button.Size = new System.Drawing.Size(209, 55);
            this.rules_button.TabIndex = 3;
            this.rules_button.Text = "Rules";
            this.rules_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rules_button.Click += new System.EventHandler(this.Rules_button_Click);
            // 
            // about_button
            // 
            this.about_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.about_button.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.about_button.Font = new System.Drawing.Font("ROG Fonts", 20F);
            this.about_button.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.about_button.Location = new System.Drawing.Point(309, 301);
            this.about_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.about_button.Name = "about_button";
            this.about_button.Size = new System.Drawing.Size(209, 55);
            this.about_button.TabIndex = 4;
            this.about_button.Text = "About";
            this.about_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.about_button.Click += new System.EventHandler(this.About_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(832, 413);
            this.Controls.Add(this.about_button);
            this.Controls.Add(this.rules_button);
            this.Controls.Add(this.solver_button);
            this.Controls.Add(this.play_button);
            this.Controls.Add(this.title_label);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudokuuuuu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label title_label;
        private Label play_button;
        private Label solver_button;
        private Label rules_button;
        private Label about_button;

        private Label[,] cells;
        private Label background;
        private Label active_cell;
        private Label menu_button;
        private Label mode_button;
        private Label reset_button;
        private Label solve_button;
        private Label attempts_show_label;

        private bool is_play_screen;
        private bool is_edit_mode;
        private bool new_game;
        private int active_x, active_y;
        private int attempts;
        private int difficulty;
        private int unsolved_cells_left;

        private int[,] main_board;
        private bool[,] editable_positions;
    }
}

