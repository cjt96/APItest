namespace TestForm
{
    partial class Mainform
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
            this.btnPokeNear = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGetSpawn = new System.Windows.Forms.Button();
            this.btnGetWild = new System.Windows.Forms.Button();
            this.btnGetCatchable = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPokeNear
            // 
            this.btnPokeNear.Location = new System.Drawing.Point(12, 116);
            this.btnPokeNear.Name = "btnPokeNear";
            this.btnPokeNear.Size = new System.Drawing.Size(241, 23);
            this.btnPokeNear.TabIndex = 0;
            this.btnPokeNear.Text = "Get Nearby Pokémon";
            this.btnPokeNear.UseVisualStyleBackColor = true;
            this.btnPokeNear.Click += new System.EventHandler(this.btnPokeNear_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 67);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(241, 43);
            this.listBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(178, 38);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnGetSpawn
            // 
            this.btnGetSpawn.Location = new System.Drawing.Point(12, 145);
            this.btnGetSpawn.Name = "btnGetSpawn";
            this.btnGetSpawn.Size = new System.Drawing.Size(241, 23);
            this.btnGetSpawn.TabIndex = 4;
            this.btnGetSpawn.Text = "Get Spawn Points";
            this.btnGetSpawn.UseVisualStyleBackColor = true;
            this.btnGetSpawn.Click += new System.EventHandler(this.btnGetSpawn_Click);
            // 
            // btnGetWild
            // 
            this.btnGetWild.Location = new System.Drawing.Point(12, 174);
            this.btnGetWild.Name = "btnGetWild";
            this.btnGetWild.Size = new System.Drawing.Size(241, 23);
            this.btnGetWild.TabIndex = 5;
            this.btnGetWild.Text = "Get Wild Pokémon";
            this.btnGetWild.UseVisualStyleBackColor = true;
            this.btnGetWild.Click += new System.EventHandler(this.btnGetWild_Click);
            // 
            // btnGetCatchable
            // 
            this.btnGetCatchable.Location = new System.Drawing.Point(12, 203);
            this.btnGetCatchable.Name = "btnGetCatchable";
            this.btnGetCatchable.Size = new System.Drawing.Size(241, 23);
            this.btnGetCatchable.TabIndex = 6;
            this.btnGetCatchable.Text = "Catchable Available Pokémon";
            this.btnGetCatchable.UseVisualStyleBackColor = true;
            this.btnGetCatchable.Click += new System.EventHandler(this.btnGetCatchable_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Update Location";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGetCatchable);
            this.Controls.Add(this.btnGetWild);
            this.Controls.Add(this.btnGetSpawn);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnPokeNear);
            this.Name = "Mainform";
            this.Text = "Mainform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPokeNear;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnGetSpawn;
        private System.Windows.Forms.Button btnGetWild;
        private System.Windows.Forms.Button btnGetCatchable;
        private System.Windows.Forms.Button button1;
    }
}