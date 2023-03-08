namespace WinFormCalculator
{
	public partial class Form1 : Form
	{

		public Form1()
		{
			InitializeComponent();
		}

		void UpdateResult()
		{
			string resultText;
			try
			{
				double opr1 = double.Parse(txtOpr1.Text), opr2 = double.Parse(txtOpr2.Text), result = double.NaN;
				var opt = cboOpt.Text;
				switch (opt)
				{
					case "+": result = opr1 + opr2; break;
					case "-": result = opr1 - opr2; break;
					case "*": result = opr1 * opr2; break;
					case "/": result = opr1 / opr2; break;
					default: throw new Exception();
				}
				resultText = result.ToString();
			}
			catch (Exception)
			{
				resultText = "Error";
			}
			lblResult.Text = resultText;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			UpdateResult();
		}

		private void cboOpt_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateResult();
		}

		private void txtOpr1_TextChanged(object sender, EventArgs e)
		{
			UpdateResult();
		}

		private void txtOpr2_TextChanged(object sender, EventArgs e)
		{
			UpdateResult();
		}

		private void cboOpt_TextChanged(object sender, EventArgs e)
		{
			UpdateResult();
		}
	}
}