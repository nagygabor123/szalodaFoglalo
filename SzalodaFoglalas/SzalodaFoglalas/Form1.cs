using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzalodaFoglalas
{
    
    public partial class Form1 : Form
    {
        private List<foglalas> adatok = new List<foglalas>();

        #region osztaly
        class foglalas
        {
            public string sorszam;
            public string szobaszam;
            public int erkzes;
            public int tavoz;
            public int vendegek;
            public string reggeli;
            public string foglaltnev;
            public int eltoltnapok;
            public foglalas(string sor)
            {
                string[] szet = sor.Split(' ');
                sorszam = szet[0];
                szobaszam = szet[1];
                erkzes = Convert.ToInt32(szet[2]);
                tavoz = Convert.ToInt32(szet[3]);
                vendegek = Convert.ToInt32(szet[4]);
                reggeli = szet[5];
                foglaltnev = szet[6];
                eltoltnapok = Convert.ToInt32(szet[3]) - Convert.ToInt32(szet[2]);
            }

        }
        int length = 0;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void Form1_Load(object sender, EventArgs e)
        {
            #region filebe
            StreamReader olvas = new StreamReader("pitypang.txt");

            while (!olvas.EndOfStream)
            {
                adatok.Add(new foglalas(olvas.ReadLine()));

            }
            olvas.Close();
            length = adatok.Count;
            #endregion

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            IntPtr roundRectRgn = CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 5, 5);
            button1.Region = Region.FromHrgn(roundRectRgn);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 2.feladat
            int maxnapok = int.MinValue;
            string maxnev = "";
            for (int i = 0; i < length; i++)
            {
                if (maxnapok < adatok[i].eltoltnapok)
                {
                    maxnapok = adatok[i].eltoltnapok;
                    maxnev = adatok[i].foglaltnev;
                }
            }
            feladat2.Text = $"{maxnev} - {Convert.ToString(maxnapok)} nap";
            #endregion

            #region 3.feladat
            //tavasz -> 1 - 121
            //nyar -> 152 - 213
            //osz - > 244 - 365

            //tavasz - szoba/9000ft(x naponként)
            //nyar - szoba/10000ft(x naponként)
            //osz - szoba/8000ft(x naponként)

            //potagy/2000ft(maximum egy,naponként)
            //reggeli/1100ft(szemelyenként x naponként)
            int tavasz = 9000;
            int nyar = 10000;
            int osz = 8000;
            int potagy = 2000;
            int reggeli = 1100;


            List<int> penz = new List<int>();
            StreamWriter ir = new StreamWriter("Bevetel.txt");
            for (int i = 0; i < length; i++)
            {
                if (adatok[i].erkzes < 152)
                {
                    int osszertek = adatok[i].eltoltnapok * tavasz;
                    if (adatok[i].vendegek == 3)
                    {
                        osszertek += potagy * adatok[i].eltoltnapok;
                    }
                    if (adatok[i].reggeli == "1")
                    {
                        osszertek += adatok[i].eltoltnapok * adatok[i].vendegek * reggeli;

                    }
                    penz.Add(osszertek);
                    ir.WriteLine(adatok[i].sorszam + ":" + osszertek);
                }

                if (adatok[i].erkzes < 244)
                {
                    int osszertek = adatok[i].eltoltnapok * nyar;
                    if (adatok[i].vendegek == 3)
                    {
                        osszertek += potagy * adatok[i].eltoltnapok;
                    }
                    if (adatok[i].reggeli == "1")
                    {
                        osszertek += adatok[i].eltoltnapok * adatok[i].vendegek * reggeli;

                    }
                    penz.Add(osszertek);
                    ir.WriteLine(adatok[i].sorszam + ":" + osszertek);
                }

                if (adatok[i].erkzes > 243)
                {
                    int osszertek = adatok[i].eltoltnapok * osz;
                    if (adatok[i].vendegek == 3)
                    {
                        osszertek += potagy * adatok[i].eltoltnapok;
                    }
                    if (adatok[i].reggeli == "1")
                    {
                        osszertek += adatok[i].eltoltnapok * adatok[i].vendegek * reggeli;

                    }
                    penz.Add(osszertek);
                    ir.WriteLine(adatok[i].sorszam + ":" + osszertek);
                }
            }

            //richTextBox1.Text = String.Join(Environment.NewLine, penz);
            ir.Close();
            int os = 0;
            for (int i = 0; i < length; i++)
            {
                os += penz[i];
            }
            label5.Text = $"{os:00 000 000} Ft";
            label3.Text = "részletesebben a 'Bevetelek.txt'";
            #endregion

            #region 4.feladat

            //1(január) -> 1-31
            //2(február) -> 32-59
            //3(márcuis) -> 60-90
            //4(április) -> 91-120
            //5(május) -> 121-151
            //6(junius) -> 152-181
            //7(julius) -> 182-212
            //8(agusztus) -> 213-243
            //9(szeptember) -> 244-273
            //10(október) -> 274-304
            //11(november) -> 305-334
            //12(december) -> 335-365

            #region honap valtozok
            int jan = 0;
            int feb = 0;
            int mar = 0;
            int apr = 0;
            int maj = 0;
            int jun = 0;
            int jul = 0;
            int aug = 0;
            int sep = 0;
            int okt = 0;
            int nov = 0;
            int dec = 0;
            #endregion

            for (int i = 0; i < length; i++)
            {
                #region 01 jan
                //1(január) -> 1-31
                //2(február) -> 32-59
                if (adatok[i].erkzes >= 1 &&
                    adatok[i].erkzes < 31 &&
                    adatok[i].tavoz > 1 &&
                    adatok[i].tavoz <= 31)
                {
                    jan += adatok[i].eltoltnapok;
                }
                if (adatok[i].erkzes >= 1 &&
                    adatok[i].erkzes <= 31 &&
                    adatok[i].tavoz > 1 &&
                    adatok[i].tavoz <= 59)
                {
                    jan += adatok[i].eltoltnapok - Math.Abs(adatok[i].tavoz - 31);
                }
                #endregion

                #region 02 feb
                //2(február) -> 32-59
                //3(márcuis) -> 60-90
                if (adatok[i].erkzes >= 32 &&
                    adatok[i].erkzes < 59 &&
                    adatok[i].tavoz > 32 &&
                    adatok[i].tavoz <= 59)
                {
                    feb += adatok[i].eltoltnapok;
                }
                if (adatok[i].erkzes >= 32 &&
                    adatok[i].erkzes <= 59 &&
                    adatok[i].tavoz > 32 &&
                    adatok[i].tavoz <= 90)
                {

                    feb += adatok[i].eltoltnapok - Math.Abs(adatok[i].tavoz - 59);
                }
                #endregion

                #region 03 mar
                //3(márcuis) -> 60-90
                //4(április) -> 91-120
                if (adatok[i].erkzes >= 60 &&
                    adatok[i].erkzes < 90 &&
                    adatok[i].tavoz > 60 &&
                    adatok[i].tavoz <= 90)
                {
                    mar += adatok[i].eltoltnapok;
                }
                if (adatok[i].erkzes >= 60 &&
                    adatok[i].erkzes <= 90 &&
                    adatok[i].tavoz > 60 &&
                    adatok[i].tavoz <= 120)
                {

                    mar += adatok[i].eltoltnapok - Math.Abs(adatok[i].tavoz - 90);
                }
                #endregion

                #region 04 apr
                //4(április) -> 91-120
                //5(május) -> 121-151
                if (adatok[i].erkzes >= 91 &&
                    adatok[i].erkzes < 120 &&
                    adatok[i].tavoz > 91 &&
                    adatok[i].tavoz <= 120)
                {
                    apr += adatok[i].eltoltnapok;
                }
                if (adatok[i].erkzes >= 91 &&
                    adatok[i].erkzes <= 120 &&
                    adatok[i].tavoz > 91 &&
                    adatok[i].tavoz <= 151)
                {

                    apr += adatok[i].eltoltnapok - Math.Abs(adatok[i].tavoz - 120);
                }
                #endregion

                #region 05 maj
                //5(május) -> 121-151
                //6(junius) -> 152-181
                if (adatok[i].erkzes >= 121 &&
                    adatok[i].erkzes < 151 &&
                    adatok[i].tavoz > 121 &&
                    adatok[i].tavoz <= 151)
                {
                    maj += adatok[i].eltoltnapok;
                }
                if (adatok[i].erkzes >= 121 &&
                    adatok[i].erkzes <= 151 &&
                    adatok[i].tavoz > 121 &&
                    adatok[i].tavoz <= 181)
                {

                    maj += adatok[i].eltoltnapok - Math.Abs(adatok[i].tavoz - 151);
                }
                #endregion

                #region 06 jun
                //6(junius) -> 152-181
                //7(julius) -> 182-212
                if (adatok[i].erkzes >= 152 &&
                    adatok[i].erkzes < 181 &&
                    adatok[i].tavoz > 152 &&
                    adatok[i].tavoz <= 181)
                {
                    jun += adatok[i].eltoltnapok;
                }
                if (adatok[i].erkzes >= 152 &&
                    adatok[i].erkzes <= 181 &&
                    adatok[i].tavoz > 152 &&
                    adatok[i].tavoz <= 212)
                {

                    jun += adatok[i].eltoltnapok - Math.Abs(adatok[i].tavoz - 181);
                }
                #endregion

                #region 07 jul
                //7(julius) -> 182-212
                //8(agusztus) -> 213-243
                if (adatok[i].erkzes >= 182 &&
                    adatok[i].erkzes < 212 &&
                    adatok[i].tavoz > 182 &&
                    adatok[i].tavoz <= 212)
                {
                    jul += adatok[i].eltoltnapok;
                }
                if (adatok[i].erkzes >= 182 &&
                    adatok[i].erkzes <= 212 &&
                    adatok[i].tavoz > 182 &&
                    adatok[i].tavoz <= 243)
                {

                    jul += adatok[i].eltoltnapok - Math.Abs(adatok[i].tavoz - 212);
                }
                #endregion

                #region 08 aug
                //8(agusztus) -> 213-243
                //9(szeptember) -> 244-273
                if (adatok[i].erkzes >= 213 &&
                    adatok[i].erkzes < 243 &&
                    adatok[i].tavoz > 213 &&
                    adatok[i].tavoz <= 243)
                {
                    aug += adatok[i].eltoltnapok;
                }
                if (adatok[i].erkzes >= 213 &&
                    adatok[i].erkzes <= 243 &&
                    adatok[i].tavoz > 213 &&
                    adatok[i].tavoz <= 273)
                {

                    aug += adatok[i].eltoltnapok - Math.Abs(adatok[i].tavoz - 243);
                }
                #endregion

                #region 09 sep
                //9(szeptember) -> 244-273
                //10(október) -> 274-304
                if (adatok[i].erkzes >= 244 &&
                    adatok[i].erkzes < 273 &&
                    adatok[i].tavoz > 244 &&
                    adatok[i].tavoz <= 273)
                {
                    sep += adatok[i].eltoltnapok;
                }
                if (adatok[i].erkzes >= 244 &&
                    adatok[i].erkzes <= 273 &&
                    adatok[i].tavoz > 244 &&
                    adatok[i].tavoz <= 304)
                {

                    sep += adatok[i].eltoltnapok - Math.Abs(adatok[i].tavoz - 273);
                }
                #endregion

                #region 10 okt->rosz
                //10(október) -> 274-304
                //11(november) -> 305-334
                if (adatok[i].erkzes >= 274 &&
                    adatok[i].erkzes < 304 &&
                    adatok[i].tavoz > 274 &&
                    adatok[i].tavoz <= 304)
                {
                    okt += adatok[i].eltoltnapok;
                }
                if (adatok[i].erkzes >= 274 &&
                    adatok[i].erkzes <= 304 &&
                    adatok[i].tavoz > 274 &&
                    adatok[i].tavoz <= 334)
                {

                    okt += adatok[i].eltoltnapok - Math.Abs(adatok[i].tavoz - 304);
                }
                #endregion

                #region 11 nov
                //11(november) -> 305-334
                //12(december) -> 335-365
                if (adatok[i].erkzes >= 305 &&
                    adatok[i].erkzes < 334 &&
                    adatok[i].tavoz > 305 &&
                    adatok[i].tavoz <= 334)
                {
                    nov += adatok[i].eltoltnapok;
                }
                if (adatok[i].erkzes >= 305 &&
                    adatok[i].erkzes <= 334 &&
                    adatok[i].tavoz > 305 &&
                    adatok[i].tavoz <= 365)
                {

                    nov += adatok[i].eltoltnapok - Math.Abs(adatok[i].tavoz - 334);
                }
                #endregion

                #region 12 dec
                //12(december) -> 335-365
                if (adatok[i].erkzes >= 335 &&
                    adatok[i].erkzes < 365 &&
                    adatok[i].tavoz > 335 &&
                    adatok[i].tavoz <= 365)
                {
                    dec += adatok[i].eltoltnapok;
                }
                #endregion
            }

            label4.Text = $"Január      {jan}\n" +
                          $"Február:    {feb}\n" +
                          $"Március:    {mar}\n" +
                          $"Április:    {apr}\n" +
                          $"Május:      {maj}\n" +
                          $"Junius:     {jun}\n" +
                          $"Julius:     {jul}\n" +
                          $"Augusztus:  {aug}\n" +
                          $"Szeptember: {sep}\n" +
                          $"Október:    {Math.Abs(okt)}\n" +
                          $"November:   {nov}\n" +
                          $"December:   {dec}";
            #endregion
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            IntPtr roundRectRgn = CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 5, 5);
            panel3.Region = Region.FromHrgn(roundRectRgn);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            IntPtr roundRectRgn = CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 5, 5);
            panel1.Region = Region.FromHrgn(roundRectRgn);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            IntPtr roundRectRgn = CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 5, 5);
            panel4.Region = Region.FromHrgn(roundRectRgn);
        }

        
    }
}
