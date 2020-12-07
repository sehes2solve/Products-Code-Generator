namespace WindowsFormsApplication2
{
    partial class Code_Manipulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Code_Manipulator));
            this.txt_code_input = new System.Windows.Forms.TextBox();
            this.btn_validation = new System.Windows.Forms.Button();
            this.lbl_validation_status = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.txt_reset_result = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.txt_step_input = new System.Windows.Forms.TextBox();
            this.btn_inc = new System.Windows.Forms.Button();
            this.btn_dec = new System.Windows.Forms.Button();
            this.txt_code_result = new System.Windows.Forms.TextBox();
            this.lbl_debug_steps = new System.Windows.Forms.Label();
            this.lbl_error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_code_input
            // 
            this.txt_code_input.Location = new System.Drawing.Point(12, 28);
            this.txt_code_input.Name = "txt_code_input";
            this.txt_code_input.Size = new System.Drawing.Size(157, 20);
            this.txt_code_input.TabIndex = 0;
            this.txt_code_input.TextChanged += new System.EventHandler(this.txt_code_input_TextChanged);
            // 
            // btn_validation
            // 
            this.btn_validation.Enabled = false;
            this.btn_validation.Location = new System.Drawing.Point(12, 57);
            this.btn_validation.Name = "btn_validation";
            this.btn_validation.Size = new System.Drawing.Size(157, 23);
            this.btn_validation.TabIndex = 1;
            this.btn_validation.Text = "Validation";
            this.btn_validation.UseVisualStyleBackColor = true;
            this.btn_validation.Click += new System.EventHandler(this.btn_validation_Click);
            // 
            // lbl_validation_status
            // 
            this.lbl_validation_status.AutoSize = true;
            this.lbl_validation_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_validation_status.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_validation_status.Location = new System.Drawing.Point(379, 32);
            this.lbl_validation_status.Name = "lbl_validation_status";
            this.lbl_validation_status.Size = new System.Drawing.Size(53, 21);
            this.lbl_validation_status.TabIndex = 2;
            this.lbl_validation_status.Text = "Status";
            // 
            // btn_reset
            // 
            this.btn_reset.Enabled = false;
            this.btn_reset.Location = new System.Drawing.Point(191, 57);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(166, 23);
            this.btn_reset.TabIndex = 3;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // txt_reset_result
            // 
            this.txt_reset_result.Enabled = false;
            this.txt_reset_result.Location = new System.Drawing.Point(191, 28);
            this.txt_reset_result.Name = "txt_reset_result";
            this.txt_reset_result.Size = new System.Drawing.Size(166, 20);
            this.txt_reset_result.TabIndex = 4;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(379, 56);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(138, 23);
            this.btn_clear.TabIndex = 5;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // txt_step_input
            // 
            this.txt_step_input.Enabled = false;
            this.txt_step_input.Location = new System.Drawing.Point(12, 86);
            this.txt_step_input.Name = "txt_step_input";
            this.txt_step_input.Size = new System.Drawing.Size(157, 20);
            this.txt_step_input.TabIndex = 6;
            this.txt_step_input.TextChanged += new System.EventHandler(this.txt_step_input_TextChanged);
            this.txt_step_input.Leave += new System.EventHandler(this.txt_step_input_Leave);
            // 
            // btn_inc
            // 
            this.btn_inc.Enabled = false;
            this.btn_inc.Location = new System.Drawing.Point(94, 112);
            this.btn_inc.Name = "btn_inc";
            this.btn_inc.Size = new System.Drawing.Size(75, 23);
            this.btn_inc.TabIndex = 7;
            this.btn_inc.Text = "Increment";
            this.btn_inc.UseVisualStyleBackColor = true;
            this.btn_inc.Click += new System.EventHandler(this.btn_inc_Click);
            // 
            // btn_dec
            // 
            this.btn_dec.Enabled = false;
            this.btn_dec.Location = new System.Drawing.Point(12, 112);
            this.btn_dec.Name = "btn_dec";
            this.btn_dec.Size = new System.Drawing.Size(75, 23);
            this.btn_dec.TabIndex = 8;
            this.btn_dec.Text = "Decrement";
            this.btn_dec.UseVisualStyleBackColor = true;
            this.btn_dec.Click += new System.EventHandler(this.btn_dec_Click);
            // 
            // txt_code_result
            // 
            this.txt_code_result.Enabled = false;
            this.txt_code_result.Location = new System.Drawing.Point(257, 86);
            this.txt_code_result.Name = "txt_code_result";
            this.txt_code_result.Size = new System.Drawing.Size(237, 20);
            this.txt_code_result.TabIndex = 9;
            // 
            // lbl_debug_steps
            // 
            this.lbl_debug_steps.AutoSize = true;
            this.lbl_debug_steps.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_debug_steps.Location = new System.Drawing.Point(253, 109);
            this.lbl_debug_steps.Name = "lbl_debug_steps";
            this.lbl_debug_steps.Size = new System.Drawing.Size(49, 19);
            this.lbl_debug_steps.TabIndex = 10;
            this.lbl_debug_steps.Text = "Debug";
            // 
            // lbl_error
            // 
            this.lbl_error.AutoSize = true;
            this.lbl_error.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_error.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_error.Location = new System.Drawing.Point(12, 147);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(47, 21);
            this.lbl_error.TabIndex = 11;
            this.lbl_error.Text = "Error";
            // 
            // Code_Manipulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(536, 218);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.lbl_debug_steps);
            this.Controls.Add(this.txt_code_result);
            this.Controls.Add(this.btn_dec);
            this.Controls.Add(this.btn_inc);
            this.Controls.Add(this.txt_step_input);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.txt_reset_result);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.lbl_validation_status);
            this.Controls.Add(this.btn_validation);
            this.Controls.Add(this.txt_code_input);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Code_Manipulator";
            this.Text = "Code Manipulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_code_input;
        private System.Windows.Forms.Button btn_validation;
        private System.Windows.Forms.Label lbl_validation_status;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.TextBox txt_reset_result;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.TextBox txt_step_input;
        private System.Windows.Forms.Button btn_inc;
        private System.Windows.Forms.Button btn_dec;
        private System.Windows.Forms.TextBox txt_code_result;
        public System.Windows.Forms.Label lbl_debug_steps;
        private System.Windows.Forms.Label lbl_error;
    }
}

