using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WindowsForms.Domain.ViewModels;
using WindowsForms.Service.Services;

namespace WindowsForms.App.Windows
{
	public partial class ChildForm : Form
	{
		public ChildForm()
		{
			InitializeComponent();
			registerPanel.Visible = false;
			loginPanel.Visible = true;
		}

		private void guna2Button2_Click(object sender, EventArgs e)
		{
			if(registerPanel.Visible == false)
			{
				registerPanel.Visible = true;
				loginPanel.Visible = false;
			}
		}

		private void guna2Button1_Click(object sender, EventArgs e)
		{
			if(registerPanel.Visible == true)
			{
				registerPanel.Visible = false;
				loginPanel.Visible = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(loginPassword.PasswordChar == '●')
			{
				button3.BringToFront();
				loginPassword.PasswordChar = '\0';
			}

		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (loginPassword.PasswordChar == '\0')
			{
				button1.BringToFront();
				loginPassword.PasswordChar = '●';
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (registerConfirm.PasswordChar == '●')
			{
				button4.BringToFront();
				registerConfirm.PasswordChar = '\0';
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (registerConfirm.PasswordChar == '\0')
			{
				button2.BringToFront();
				registerConfirm.PasswordChar = '●';
			}

		}

		private void button6_Click(object sender, EventArgs e)
		{
			if(registerPassword.PasswordChar == '●')
			{
				button5.BringToFront();
				registerPassword.PasswordChar = '\0';
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (registerPassword.PasswordChar == '\0')
			{
				button6.BringToFront();
				registerPassword.PasswordChar = '●';
			}
		}

		private async void guna2GradientButton2_Click(object sender, EventArgs e)
		{
			try
			{
				if (registerPassword.Text.Length > 7)
				{
					if (registerPassword.Text == registerConfirm.Text)
					{
						UserViewModel userViewModel = new UserViewModel(registerLogin.Text, registerPassword.Text);
						UserServise userServise = new UserServise();
						var result = await userServise.RegistrationAsync(userViewModel);
						
						if (result.IsSuccesful)
						{
							MessageBox.Show("You are registered succesfully");
							registerPanel.Visible = false;
							loginPanel.Visible = true;
						}
						else MessageBox.Show("Login is already exists");

					}
					else MessageBox.Show("Passwor is not confirmed");
				}
				else MessageBox.Show("Use minimum 8 characters");

			}
			catch
			{
				MessageBox.Show("Something went wrong");
			}
			finally
			{
				registerLogin.Text = "";
				registerPassword.Text = "";
				registerConfirm.Text = "";
			}
		}

		private void guna2GradientButton1_Click(object sender, EventArgs e)
		{
			Form1 form = new Form1();
			form.Show();
			
		}
	}
}
