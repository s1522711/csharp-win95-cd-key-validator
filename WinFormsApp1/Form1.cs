namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // initialising most of the needed vars
                string Box1 = textBox1.Text[0].ToString() + textBox1.Text[1].ToString() + textBox1.Text[2].ToString();
                string Box2 = textBox1.Text[4].ToString() + textBox1.Text[5].ToString() + textBox1.Text[6].ToString() + textBox1.Text[7].ToString() + textBox1.Text[8].ToString() + textBox1.Text[9].ToString() + textBox1.Text[10].ToString();
                label1.Text = Box1 + Box2;
                string KeyErrors = "";

                if (Box1[0] == Box1[1] && Box1[0] == Box1[2]) // check if the first box isnt equal to blacklisted values
                {
                    KeyErrors += "The Digits In The First Box Cant Be Equal, ";
                }

                // get sum of box 2
                int SumOfBox2 = 0;
                var x = Box2.ToCharArray();
                Console.WriteLine(x);
                for (int I = 0; I <= x.Length - 1; I++)
                {
                    if (x[I] > '0' && x[I] <= '9')
                    {
                        SumOfBox2 += x[I] - '0';
                    }
                }
                //label2.Text = SumOfBox2.ToString();
                if (SumOfBox2 % 7 != 0)
                {
                    KeyErrors += "Sum of Digits In Key Isnt Divisible By 7, ";
                }

                if (textBox1.Text.Length != 11) // check key length
                {
                    KeyErrors += "Key length isn't 11";
                }

                if (KeyErrors.Length == 0) { label1.ForeColor = Color.Green; label1.Text = "CD Key Valid!"; } // check if the license key is valid
                else { label1.ForeColor = Color.Red; label1.Text = "CD Key Invalid: " + KeyErrors; }
            }
            catch (Exception IndexOutOfRangeException) // except index out of range errors
            {
                Console.WriteLine(IndexOutOfRangeException);
                label1.ForeColor = Color.Red; label1.Text = "Key length isn't 11";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = ""; // make label invisible on load
            label2.Text = "";
        }
    }
}
