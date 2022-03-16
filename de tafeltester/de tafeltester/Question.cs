using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de_tafeltester
{
    internal class Question
    {
        public string text;
        public string image;
        public double[,] sum;
        public double[] awnser;
        public int index;
        public bool? correct;

        public Question(string text, string image, double[,] sum, double[] awnser, int index)
        {
            this.text = text;
            this.image = image;
            this.sum = sum;
            this.awnser = awnser;
            this.index = index;
        }

        public static Question[] getQuestionArray1()
        {
            Random rnd = new Random();

            // set questionarray
            // TODO: make questions (none made yet)
            Question[] questionArray = new Question[10];

            // generate 4 * sums
            for (int i = 0; i < 4; i++)
            {
                double firstNumber = rnd.Next(10);
                double secondNumber = rnd.Next(10);
                double awnser = firstNumber * secondNumber;
                questionArray[i] = new Question(":firstNumber: * :secondNumber:", "image", new double[,]
                {
                    { firstNumber, secondNumber }
                }, new double[] { awnser }, 0);
            }
            // generate 4 : sums
            for (int i = 4; i < 8; i++)
            {
                double awnser = rnd.Next(10);
                double secondNumber = rnd.Next(10);
                double firstNumber = secondNumber * awnser;
                questionArray[i] = new Question(":firstNumber: : :secondNumber:", "image", new double[,]
                {
                    { firstNumber, secondNumber }
                }, new double[] { awnser }, 0);
            }
            // generate 1 + sum
            for (int i = 8; i < 9; i++)
            {
                double firstNumber = rnd.Next(20);
                double secondNumber = rnd.Next(20);
                double awnser = firstNumber + secondNumber;
                questionArray[i] = new Question(":firstNumber: + :secondNumber:", "image", new double[,]
                {
                    { firstNumber, secondNumber }
                }, new double[] { awnser }, 0);
            }
            // generate 1 - sum
            for (int i = 9; i < 10; i++)
            {
                double firstNumber = rnd.Next(20);
                double secondNumber = rnd.Next(20);
                double awnser = firstNumber - secondNumber;
                questionArray[i] = new Question(":firstNumber: - :secondNumber:", "image", new double[,]
                {
                    { firstNumber, secondNumber }
                }, new double[] { awnser }, 0);
            }

            // shuffle the array
            questionArray = questionArray.OrderBy(x => rnd.Next()).ToArray();
            return questionArray;
        }

        public static Question[] getQuestionArray2()
        {
            Random rnd = new Random();

            // set questionarray
            // TODO: make questions (none made yet)
            Question[] questionArray = new Question[]
            {
                new Question("Hoeveel procent van het figuur is grijs gekleurd?", "2_1.jpg", new double[,]
                {
                    { 0, 0 }
                }, new double[] { 35 }, 0),

                new Question("Welk getal hoort bij de pijl?", "2_2.jpg", new double[,]
                {
                    { 0, 0 }
                }, new double[] { 8.35 }, 0),

                new Question("Met een kilogram lijm kun je :firstNumber: m² tegels lijmen.\n" +
                "Hoeveel vierkante meter tegels kun je lijmen met een hele zak lijn?", "2_3.jpg", new double[,]
                {
                    { 0.5, 0 }, { 1.5, 0 }
                }, new double[] { 10, 30 }, rnd.Next(2)),

                new Question("Je gaat met de metro van Muiderpoort naar Centraal Station.\n" +
                "Op welke metrolijn kun je als eerste overstappen?\n" +
                "Metrolijn nummer:", "2_4.jpg", new double[,]
                {
                    { 0, 0 }
                }, new double[] { 3 }, 0),

                new Question("Hoeveel euro ontvangt iemand van :firstNumber: jaar gemiddeld aan \n" +
                "zakgeld en kleedgeld samen per week.", "2_5.jpg", new double[,]
                {
                    { 16, 0 }, { 17, 0 }, { 12, 0 }
                }, new double[] { 18.4, 19.2, 12.4 }, rnd.Next(3)),

                new Question("Welk deel van de Nederlandse Google+ gebruikers maakt dagelijks\n" +
                "gebruik van deze dienst?\n" +
                "1 op de ", "2_6.jpg", new double[,]
                {
                    { 0, 0 }
                }, new double[] { 3 }, 0),

                new Question("Hoeveel procent van de blokken is grijs gekleurd?", "2_7.jpg", new double[,]
                {
                    { 0, 0 }
                }, new double[] { 25 }, 0),

                new Question("Een eetcafé zoekt studenten die willen werken op oudejaarsavond.\n" +
                "De werktijden zijn van 17:30 tot 1:30 uur.\n" +
                "Het uurloon is :firstNumber: euro.\n" +
                "De pauzes worden doorbetaald.\n" +
                "Hoeveel euro kunnen studenten op deze avond verdienen.", "image", new double[,]
                {
                    { 15, 0 }, { 25, 0 }, { 30, 0 }
                }, new double[] { 120, 200, 240 }, rnd.Next(3)),

                new Question("Hoeveel uur zaten ze in de glazen kas?", "2_8.jpg", new double[,]
                {
                    { 0, 0 }
                }, new double[] { 120 }, 0),

                new Question(":firstNumber: x (:secondNumber: + 12)", "image", new double[,]
                {
                    { 6, 44 }, { 5, 48 }, { 10, 46 }
                }, new double[] { 336, 300, 580 }, rnd.Next(3)),

                new Question(":firstNumber: + :secondNumber:", "image", new double[,]
                {
                    { -3, 7 }, { -4, 8 }, { -3, 9 }
                }, new double[] { 4, 4, 6 }, rnd.Next(3)),

                new Question(":firstNumber: : :secondNumber:", "image", new double[,]
                {
                    { 7, 0.2 }
                }, new double[] { 35 }, 0),

                new Question(":firstNumber:% van :secondNumber:", "image", new double[,]
                {
                    { 20, 45 }, { 8, 40 }
                }, new double[] { 9, 8 }, rnd.Next(2)),

                new Question(":firstNumber: - :secondNumber:", "image", new double[,]
                {
                    { 1633, 751 }, { 1622, 745 }
                }, new double[] { 882, 877 }, rnd.Next(2)),

                new Question(":firstNumber: x :secondNumber:", "image", new double[,]
                {
                    { 6, 8.4 }
                }, new double[] { 50.4 }, 0),
            };

            // shuffle the array
            questionArray = questionArray.OrderBy(x => rnd.Next()).ToArray();
            // limit array to 10
            questionArray = questionArray.SkipLast(5).ToArray();

            return questionArray;
        }

        public static Question[] getQuestionArray3()
        {
            Random rnd = new Random();

            // set questionarray
            Question[] questionArray = new Question[]
            {
                new Question("Je maakt :firstNumber: muffins. \nHoeveel zelfrijzend bakmeel heb je nodig? (in gram)", 
                "3_1.jpg", new double[,]
                {
                    { 10, 0 }, { 15, 0 }
                }, new double[] { 160, 240 }, rnd.Next(2)),

                new Question("Je rijst per auto naar parijs. De rijsafstand is :firstNumber: kilometer.\n" +
                    "Je verwacht gemiddeld 100 kilometer per uur te rijden.\nJe vertrekt om 7.00 uur.\n" +
                    "Hoelaat verwacht je in Parijs aan te komen? \n(schrijf op als 1800 als het 18:00 is)", "image", new double[,]
                {
                    { 425, 0 }, { 475, 0 }, { 550, 0 }
                }, new double[] { 1115, 1145, 1230 }, rnd.Next(3)),

                new Question("Je gaat een wand verven van 5 bij 2,4 meter. \n" +
                "Je gebruikt verf waarvan het verbruik 1 liter per :firstNumber: m² is.\n" +
                "Hoeveel liter verf heb je nodig?", "image", new double[,]
                {
                    { 6, 0 }, { 12, 0 }, { 18, 0 }
                }, new double[] { 2, 3, 4 }, rnd.Next(3)),

                new Question("Welk getal ontbreekt?", "3_2.jpg", new double[,]
                {
                    { 0, 0 }
                }, new double[] { 9984 }, 0),

                new Question("Je maakt gebruik van deze aanbieding en koopt :firstNumber: flessen shampoo.\n" +
                "Hoeveel moet je hiervoor betalen volgens deze aanbieding?", "3_3.jpg", new double[,]
                {
                    { 6, 0 }, { 8, 0 }, { 12, 0 }
                }, new double[] { 16.05, 21.40, 31.10 }, rnd.Next(3)),

                new Question("Je wilt een tuin van :firstNumber: bij :firstNumber: meter en 10 centimeter tuinaarde bedekken.\n" +
                "De tuinaarde is verpakt in zakken van :secondNumber: liter.\n" +
                "Hoeveel zakken tuinaarde heb je hiervoor nodig?", "image", new double[,]
                {
                    { 4, 40 }, { 5, 50 }, { 6, 60 }
                }, new double[] { 40, 50, 60 }, rnd.Next(3)),

                new Question("Een fiets rijdt de tocht met een gemiddelde snelheid van :firstNumber: km/uur.\n" +
                "Boven op elk van de twee bergoppen pauzeert hij :secondNumber: minuten.\n" +
                "Hoeveel uur duurt de tocht inclusief pauzes?", "3_4.jpg", new double[,]
                {
                    { 20, 30 }
                }, new double[] { 9 }, 0),

                new Question("Met hoeveel procent is de prijs door de aanbieding\ngedaald vergeleken met de normale verkoopprijs?",
                "3_5.jpg", new double[,]
                {
                    { 0, 0 }
                }, new double[] { 80 }, 0),

                new Question("De concerten die Adele op 1 en 3 juni gaf, waren na :firstNumber: minuten uitverkocht.\n" +
                "In totaal zijn er :secondNumber: kaarten verkocht.\n" +
                "Hoeveel kaarten zijn er gemiddeld per seconde verkocht voor deze \ntwee concerten samen?", "image", new double[,]
                {
                    { 25, 33000 }, { 50, 72000 }, { 25, 36000 }, { 50, 66000 }
                }, new double[] { 11, 12, 12, 11 }, rnd.Next(4)),

                new Question(":firstNumber: : :secondNumber:", "image", new double[,]
                {
                    { 935, 11 }, { 1140, 12 }
                }, new double[] { 85, 95}, rnd.Next(2)),

                new Question(":firstNumber: is % van :secondNumber:", "image", new double[,]
                {
                    { 0.8, 1 }, { 0.75, 1 }, { 0.7, 1 }, { 0.6, 1 }
                }, new double[] { 80, 75, 70, 60 }, rnd.Next(4)),

                new Question(":firstNumber: + :secondNumber:", "image", new double[,]
                {
                    { 53, 769 }, { 57, 876 }, { 533, 48 }, { 69, 437 }
                }, new double[] { 822, 933, 581, 506 }, rnd.Next(4)),

                new Question(":firstNumber: + :secondNumber: + 35", "image", new double[,]
                {
                    { 123, 187 }, { 184, 239 }
                }, new double[] { 345, 458 }, rnd.Next(2)),

                new Question(":firstNumber: - :secondNumber:", "image", new double[,]
                {
                    { 1.3, 0.12 }, { 1.6, 0.32 }, { 2.7, 0.45 }
                }, new double[] { 1.18, 1.28, 2.25 }, rnd.Next(3)),

                new Question(":firstNumber: x :secondNumber:", "image", new double[,]
                {
                    { 0.7, 0.6 }
                }, new double[] { 4.2 }, 0),
            };

            // shuffle the array
            questionArray = questionArray.OrderBy(x => rnd.Next()).ToArray();
            // limit array to 10
            questionArray = questionArray.SkipLast(5).ToArray();

            return questionArray;
        }
    }
}
