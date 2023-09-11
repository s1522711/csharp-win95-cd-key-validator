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
                //initialising most of the needed vars
                string Box1 = textBox1.Text[0].ToString() + textBox1.Text[1].ToString() + textBox1.Text[2].ToString();
                string Box2 = textBox1.Text[4].ToString() + textBox1.Text[5].ToString() + textBox1.Text[6].ToString() + textBox1.Text[7].ToString() + textBox1.Text[8].ToString() + textBox1.Text[9].ToString() + textBox1.Text[10].ToString();
                label1.Text = Box1 + Box2;
                int ValidityScore = 0;
                string KeyErrors = "";

                if (Box1 != "333" && Box1 != "444" && Box1 != "555" && Box1 != "666" && Box1 != "777" && Box1 != "888" && Box1 != "999") //check if the first box isnt equal to blacklisted values
                {
                    ValidityScore += 1;
                }
                else { KeyErrors += "The Digits In The First Box Cant Be 333, 444, 555, 666, 777, 888 or 999, "; }

                //get sum of box 2
                Int32 SumOfBox2 = Box2.Split(new char[] { ',' })   //get the "list" of strings
                       .Select(n => Int32.Parse(n)) //get the "list" of integers
                       .Sum();                      //get the sum
                if (SumOfBox2 % 7 == 0)
                {
                    ValidityScore += 1;
                }
                else { KeyErrors += "Sum of Digits In Key Isnt Devisable By 7, "; }

                if (textBox1.Text.Length == 11) //check key length
                {
                    ValidityScore += 1;
                }
                else { KeyErrors += "Key lenght isnt 11"; }


                if (ValidityScore == 3) { label1.ForeColor = Color.Green; label1.Text = "CD Key Valid!"; } //check if enough validity checks have been passed
                else { label1.ForeColor = Color.Red; label1.Text = "CD Key Invalid: " + KeyErrors; }
            }
            catch (Exception IndexOutOfRangeException) //except index out of range errors
            {
                Console.WriteLine(IndexOutOfRangeException);
                label1.ForeColor = Color.Red; label1.Text = "key lenght isnt 11";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = ""; //make label invisible on load
        }
    }
}