using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsForms.DataAccess.Repositories;
using WindowsForms.Domain.ViewModels;
using WindowsForms.Service.Services;
using WindowsForms.Domain.Models;
using SQLite;


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
			if (registerPanel.Visible == false)
			{
				registerPanel.Visible = true;
				loginPanel.Visible = false;
				registerLogin.Focus();
			}
		}

		private void guna2Button1_Click(object sender, EventArgs e)
		{
			if (registerPanel.Visible == true)
			{
				registerPanel.Visible = false;
				loginPanel.Visible = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (loginPassword.PasswordChar == '●')
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
			if (registerPassword.PasswordChar == '●')
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

		Repository repository = new Repository();

		private async void guna2GradientButton2_Click(object sender, EventArgs e)
		{
			try
			{
				Repository repository = new Repository();
				repository.Initialize();
				UserRepository repository1 = new UserRepository();
				User user = await repository1.FindByLoginAsync(registerLogin.Text);
				if (user.Login == registerLogin.Text)
				{
					label5.ForeColor = Color.Red;
					label5.Text = "Login Already exists";
				}



				if (!(registerLogin.Text == "" && registerConfirm.Text == "" && registerPassword.Text == ""))
				{
					UserViewModel userViewModel = new UserViewModel(registerLogin.Text, registerPassword.Text);
					UserServise userServise = new UserServise();
					var result = await userServise.RegistrationAsync(userViewModel);

					if (result)
					{
						MessageBox.Show("You are registered succesfully");
						loginPanel.Visible = true;
						registerPanel.Visible = false;
					}
					else MessageBox.Show("Login is already exists");
				}
				else MessageBox.Show("Fill the all boxes");
			}
			catch
			{
				MessageBox.Show("Something went wrong");
			}
			finally
			{
			}
		}

		private void guna2GradientButton1_Click(object sender, EventArgs e)
		{
			
		}

		// Validate username
		private void login_validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(registerLogin.Text))
			{
				e.Cancel = true;
				registerLogin.Focus();
				errorProvider1.SetError(registerLogin, "Name is required!");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(registerLogin, "");
			}
		}

		private void registerPassword_TextChanged(object sender, EventArgs e)
		{
			var hasNumber = new Regex(@"[0-9]+");
			var hasUpperChar = new Regex(@"[A-Z]+");
			var hasMinimum8Chars = new Regex(@".{8,}");


			if (!hasUpperChar.IsMatch(registerPassword.Text))
			{
				label4.ForeColor = Color.Red;
				label4.Text = "Password should contain At least one upper case letter";
			}
			else if (!hasMinimum8Chars.IsMatch(registerPassword.Text))
			{
				label4.ForeColor = Color.Red;
				label4.Text = "Password should not be less than 8 charcters";
			}
			else if (!hasNumber.IsMatch(registerPassword.Text))
			{
				label4.ForeColor = Color.Red;
				label4.Text = "Password should contain At least one numeric value";
			}
			else label4.Text = "";
		}

		private void registerPanel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void registerConfirm_TextChanged_1(object sender, EventArgs e)
		{
			if (!(registerPassword.Text == registerConfirm.Text))
			{
				label3.ForeColor = Color.Red;
				label3.Text = "Not confirmed";
			}
			else
			{
				label3.Text = "";
			}
		}

		private async void registerLogin_TextChanged(object sender, EventArgs e)
		{
			var hasMinimum8Chars = new Regex(@".{8,50}");
			if (!hasMinimum8Chars.IsMatch(registerLogin.Text))
			{
				label5.ForeColor = Color.Red;
				label5.Text = "Login should not be less than 8 charcters";
			}
			else
			{
				label5.Text = "";
			}
		}

		private void ChildForm_Load(object sender, EventArgs e)
		{
			if (!System.IO.File.Exists(@"C:\Users\davok\OneDrive\Рабочий стол\WinForm.Login.Register.App\form-db.db3"))
			{
				//do
			}
			else
			{
				var db = new SQLiteConnection(@"C:\Users\davok\OneDrive\Рабочий стол\WinForm.Login.Register.App\form-db.db3");
				db.CreateTable<User>();
				db.Close();
			}
		}
	}
}
