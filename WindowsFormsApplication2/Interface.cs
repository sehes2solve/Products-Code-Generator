using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    
    public partial class Code_Manipulator : Form
    {
        
        CODE CODEobj = new CODE();
        public Code_Manipulator()
        {
            InitializeComponent();
        }

        private void btn_validation_Click(object sender, EventArgs e)
        {
            int index_of_invalid, err_id;
            string err_message;
            if (CODEobj.CodeVildation(txt_code_input.Text, out index_of_invalid, out err_id, out err_message))
            {
                lbl_validation_status.Text = "Index : " + index_of_invalid.ToString() + " Valid";
                lbl_error.Text = err_id.ToString() + ": " + err_message;
                btn_reset.Enabled = true;
                txt_step_input.Enabled = true;

            }
            else
            {
                lbl_validation_status.Text = "Index : " + index_of_invalid.ToString() + " Invalid";
                lbl_error.Text = err_id.ToString() + ": " + err_message;
            }
      }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_reset_result.Text = CODEobj.reset(txt_code_input.Text,0);   
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_code_input.Text = "";
            txt_reset_result.Text = "";
            txt_step_input.Text = "";
            txt_code_result.Text = "";
            lbl_debug_steps.Text = "Debug";
        }

        private void txt_code_input_TextChanged(object sender, EventArgs e)
        {
            if (txt_code_input.Text.Trim() != "")
                btn_validation.Enabled = true;
            else
                btn_validation.Enabled = false;
            btn_reset.Enabled = false;
            lbl_validation_status.Text = "Status";
            lbl_error.Text = "Error";
            txt_reset_result.Text = "";
            txt_step_input.Enabled = false;
            btn_inc.Enabled = false;
            btn_dec.Enabled = false;
        }

        
        private void txt_step_input_Leave(object sender, EventArgs e)
        {
            int err_id;
            string err_message;
            if (CODEobj.StepValidation(txt_step_input.Text,out err_id,out err_message))
            {
                lbl_error.Text = err_id.ToString() + ": " + err_message;
                btn_inc.Enabled = true;
                btn_dec.Enabled = true;
            }
            else
                lbl_error.Text = err_id.ToString() + ": " + err_message;
        }

        private void txt_step_input_TextChanged(object sender, EventArgs e)
        {
            btn_inc.Enabled = false;
            btn_dec.Enabled = false;
            lbl_error.Text = "Error";  
        }

        private void btn_inc_Click(object sender, EventArgs e)
        {
            txt_code_result.Text = CODEobj.CodeManipulator(txt_code_input.Text,txt_step_input.Text,true,lbl_debug_steps);
        }

        private void btn_dec_Click(object sender, EventArgs e)
        {
            txt_code_result.Text = CODEobj.CodeManipulator(txt_code_input.Text,txt_step_input.Text,false,lbl_debug_steps);
        }

        
    }
}
