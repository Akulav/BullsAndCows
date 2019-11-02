using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        List<string> answers = Shuffle(Permutations(ANSWER_SIZE)).ToList();


        int bulls, cows;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            bulls = Convert.ToInt32(textBox1.Text);
            cows = Convert.ToInt32(textBox2.Text);
           
            
           
                string guess = answers[0];
                //label3.Text="My guess is "+ guess;
                
                
                    for (int ans = answers.Count - 1; ans >= 0; ans--)
                    {
                        int tb = 0, tc = 0;
                        for (int ix = 0; ix < ANSWER_SIZE; ix++)
                            if (answers[ans][ix] == guess[ix])
                                tb++;
                            else if (answers[ans].Contains(guess[ix]))
                                tc++;
                        if ((tb != bulls) || (tc != cows))
                            answers.RemoveAt(ans);
                    }
            
            if (answers.Count == 1)
                label2.Text= answers[0];
            else
                Console.WriteLine("No possible answer fits the scores you gave.");

        }
        const int ANSWER_SIZE = 4;

        static IEnumerable<string> Permutations(int size)
        {
            if (size > 0)
            {
                foreach (string s in Permutations(size - 1))
                    foreach (char n in "123456789")
                        if (!s.Contains(n))
                            yield return s + n;
            }
            else
                yield return "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            string guess = answers[0];
            label1.Text = guess;
        }

        static IEnumerable<T> Shuffle<T>(IEnumerable<T> source)
        {
            Random random = new Random();
            List<T> list = source.ToList();
            while (list.Count > 0)
            {
                int ix = random.Next(list.Count);
                yield return list[ix];
                list.RemoveAt(ix);
            }
        }
    }
}
