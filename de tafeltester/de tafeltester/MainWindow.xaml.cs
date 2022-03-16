using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace de_tafeltester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int index = 0;
        int questionAwnseredCounter = 0;
        string name = "";
        Question[] questionArray = new Question[10];

        public MainWindow()
        {
            InitializeComponent();

            name = Microsoft.VisualBasic.Interaction.InputBox("Wat is je naam?", "De Tafeltester", "Naam");

            btnLvl1.Click += BtnLvl1_Click;
            btnLvl2.Click += BtnLvl2_Click;
            btnLvl3.Click += BtnLvl3_Click;
            btnPrevious.Click += BtnPrevious_Click;
            btnNext.Click += BtnNext_Click;
            btnCheckAwnser.Click += BtnCheckAwnser_Click;
            questionArray = Question.getQuestionArray1();
            PopulateQuestion();
        }

        private void PopulateQuestion()
        {
            // make question string
            // :firstnumber: = first number of sum, :secondnumber: = second number of sum
            string questionString = questionArray[index].text.Replace(":firstNumber:", 
                questionArray[index].sum[questionArray[index].index, 0].ToString());
            questionString = questionString.Replace(":secondNumber:",
                questionArray[index].sum[questionArray[index].index, 1].ToString());

            lblQuestion.Content = questionString;

            // set image if exists
            if (questionArray[index].image != "image")
            {
                imgQuestion.Source = new ImageSourceConverter().ConvertFromString("./images/" + questionArray[index].image) as ImageSource;
            } else
            {
                imgQuestion.Source = null;
            }

            // display question number
            lblQuestionNumber.Content = (index + 1).ToString() + "/10";

            // check if submitted
            if (questionArray[index].correct != null)
            {
                // hide checkAwnser / input
                btnCheckAwnser.Visibility = Visibility.Collapsed;
                txtbAwnser.Visibility = Visibility.Collapsed;
                // change background based on question correct
                if (questionArray[index].correct == true)
                {
                    grdFrame.Background = Brushes.Green;
                }
                else
                {
                    grdFrame.Background = Brushes.Red;
                    // show correct awnser
                    lblCorrectAwnser.Content = "antwoord: " + questionArray[index].awnser[questionArray[index].index].ToString();
                }
            } else
            {
                btnCheckAwnser.Visibility = Visibility.Visible;
                txtbAwnser.Visibility = Visibility.Visible;
                grdFrame.Background = Brushes.White;
                lblCorrectAwnser.Content = "";
            }
        }

        private void BtnCheckAwnser_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtbAwnser.Text, out double awnser))
            {
                if (awnser == questionArray[index].awnser[questionArray[index].index])
                {
                    // play correct sound
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                    player.SoundLocation = "./sounds/correct.wav";
                    player.Play();

                    // bool correct true
                    questionArray[index].correct = true;

                    PopulateQuestion();
                } else
                {
                    // play incorrect sound
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                    player.SoundLocation = "./sounds/incorrect.wav";
                    player.Play();

                    // bool correct false
                    questionArray[index].correct = false;

                    PopulateQuestion();
                }
                questionAwnseredCounter++;
                // check if all questions have been awnsered
                if (questionAwnseredCounter == 10)
                {
                    // calculate score
                    int score = 0;
                    for (int i = 0; i < questionArray.Length; i++)
                    {
                        if (questionArray[i].correct == true)
                        {
                            score++;
                        }
                    }
                    MessageBox.Show("Hallo " + name + ", Je Cijfer is: " + score.ToString() + "/10");
                }
            }
            else
            {
                MessageBox.Show("Vul een geldig nummer in.");
            }
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            index++;
            if (index > 9)
            {
                index = 0;
            }
            PopulateQuestion();
        }

        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            index--;
            if (index < 0)
            {
                index = 9;
            }
            PopulateQuestion();
        }

        private void BtnLvl1_Click(object sender, RoutedEventArgs e)
        {
            // generate question array
            questionArray = Question.getQuestionArray1();
            index = 0;
            questionAwnseredCounter = 0;
            PopulateQuestion();
        }

        private void BtnLvl2_Click(object sender, RoutedEventArgs e)
        {
            // generate question array
            questionArray = Question.getQuestionArray2();
            index = 0;
            questionAwnseredCounter = 0;
            PopulateQuestion();
        }

        private void BtnLvl3_Click(object sender, RoutedEventArgs e)
        {
            // generate question array
            questionArray = Question.getQuestionArray3();
            index = 0;
            questionAwnseredCounter = 0;
            PopulateQuestion();
        }
    }
}
