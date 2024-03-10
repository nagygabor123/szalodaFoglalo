using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace tesztCalendar
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

        string vszobaszam = "1";

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
            urescella();

            #region ComboBox beallitasa
            for (int i = 1; i <= 27; i++)
            {
                comboBox1.Items.Add(i);
            }
            #endregion

            comboBox1.SelectedIndexChanged += comboBox1_DropDownClosed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            SetDataGridViewCellColors(Color.White);

            #region filebe
            StreamReader olvas = new StreamReader("pitypang.txt");

            while (!olvas.EndOfStream)
            {
                adatok.Add(new foglalas(olvas.ReadLine()));

            }
            olvas.Close();
            length = adatok.Count;
            #endregion

            #region honap kivalasztasa
            vszobaszam = comboBox1.SelectedItem.ToString();
            for (int i = 0; i < length; i++)
            {
                //szoba 1-27
                

                #region 01 jan
                //1(január) -> 1-31
                //2(február) -> 32-59
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 1 &&
                    adatok[i].erkzes <= 31 &&
                    adatok[i].tavoz >= 1 &&
                    adatok[i].tavoz <= 31)
                {

                    szinek(1, adatok[i].erkzes, adatok[i].eltoltnapok);
                }
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 1 &&
                    adatok[i].erkzes <= 31 &&
                    adatok[i].tavoz >= 31 &&
                    adatok[i].tavoz <= 59)
                {

                    szinek(1, adatok[i].erkzes, adatok[i].eltoltnapok);
                    szinek(2, 1, adatok[i].tavoz - 31 - 1);
                }

                #endregion

                #region 02 feb
                //2(február) -> 32-59
                //3(márcuis) -> 60-90
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 32 &&
                    adatok[i].erkzes <= 59 &&
                    adatok[i].tavoz >= 32 &&
                    adatok[i].tavoz <= 59)
                {
                    szinek(2, adatok[i].erkzes - 31, adatok[i].eltoltnapok);
                }
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 32 &&
                    adatok[i].erkzes <= 59 &&
                    adatok[i].tavoz >= 59 &&
                    adatok[i].tavoz <= 90)
                {

                    szinek(2, adatok[i].erkzes - 31, adatok[i].eltoltnapok);
                    szinek(3, 1, adatok[i].tavoz - 59 - 1);
                }
                #endregion

                #region 03 mar
                //3(márcuis) -> 60-90
                //4(április) -> 91-120
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 60 &&
                    adatok[i].erkzes <= 90 &&
                    adatok[i].tavoz >= 60 &&
                    adatok[i].tavoz <= 90)
                {
                    szinek(3, adatok[i].erkzes - 59, adatok[i].eltoltnapok);
                }
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 60 &&
                    adatok[i].erkzes <= 90 &&
                    adatok[i].tavoz > 90 &&
                    adatok[i].tavoz <= 120)
                {

                    szinek(3, adatok[i].erkzes - 59, adatok[i].eltoltnapok);
                    szinek(4, 1, adatok[i].tavoz - 90 - 1);
                }
                #endregion

                #region 04 apr
                //4(április) -> 91-120
                //5(május) -> 121-151
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 91 &&
                    adatok[i].erkzes <= 120 &&
                    adatok[i].tavoz >= 91 &&
                    adatok[i].tavoz <= 120)
                {
                    szinek(4, adatok[i].erkzes - 90, adatok[i].eltoltnapok);
                }
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 91 &&
                    adatok[i].erkzes <= 120 &&
                    adatok[i].tavoz >= 120 &&
                    adatok[i].tavoz <= 151)
                {

                    szinek(4, adatok[i].erkzes - 90, adatok[i].eltoltnapok);
                    szinek(5, 1, adatok[i].tavoz - 120 - 1);
                }
                #endregion

                #region 05 maj
                //5(május) -> 121-151
                //6(junius) -> 152-181
                if (adatok[i].szobaszam == vszobaszam
                    && adatok[i].erkzes >= 121 &&
                    adatok[i].erkzes <= 151 &&
                    adatok[i].tavoz >= 121 &&
                    adatok[i].tavoz <= 151)
                {
                    szinek(5, adatok[i].erkzes - 120, adatok[i].eltoltnapok);
                }
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 121 &&
                    adatok[i].erkzes <= 151 &&
                    adatok[i].tavoz >= 151 &&
                    adatok[i].tavoz <= 181)
                {
                    szinek(5, adatok[i].erkzes - 120, adatok[i].eltoltnapok);
                    szinek(6, 1, adatok[i].tavoz - 151 - 1);
                }
                #endregion

                #region 06 jun
                //6(junius) -> 152-181
                //7(julius) -> 182-212
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 152 &&
                    adatok[i].erkzes <= 181 &&
                    adatok[i].tavoz >= 152 &&
                    adatok[i].tavoz <= 181)
                {
                    szinek(6, adatok[i].erkzes - 151, adatok[i].eltoltnapok);
                }
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 152 &&
                    adatok[i].erkzes <= 181 &&
                    adatok[i].tavoz >= 181 &&
                    adatok[i].tavoz <= 212)
                {

                    szinek(6, adatok[i].erkzes - 151, adatok[i].eltoltnapok);
                    szinek(7, 1, adatok[i].tavoz - 181 - 1);
                }
                #endregion

                #region 07 jul
                //7(julius) -> 182-212
                //8(agusztus) -> 213-243
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 182 &&
                    adatok[i].erkzes <= 212 &&
                    adatok[i].tavoz >= 182 &&
                    adatok[i].tavoz <= 212)
                {
                    szinek(7, adatok[i].erkzes - 181, adatok[i].eltoltnapok);
                }
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 182 &&
                    adatok[i].erkzes <= 212 &&
                    adatok[i].tavoz >= 212 &&
                    adatok[i].tavoz <= 243)
                {

                    szinek(7, adatok[i].erkzes - 181, adatok[i].eltoltnapok);
                    szinek(8, 1, adatok[i].tavoz - 212 - 1);
                }
                #endregion

                #region 08 aug
                //8(agusztus) -> 213-243
                //9(szeptember) -> 244-273
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 213 &&
                    adatok[i].erkzes <= 243 &&
                    adatok[i].tavoz >= 213 &&
                    adatok[i].tavoz <= 243)
                {
                    szinek(8, adatok[i].erkzes - 212, adatok[i].eltoltnapok);
                }
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 213 &&
                    adatok[i].erkzes <= 243 &&
                    adatok[i].tavoz >= 243 &&
                    adatok[i].tavoz <= 273)
                {

                    szinek(8, adatok[i].erkzes - 212, adatok[i].eltoltnapok);
                    szinek(9, 1, adatok[i].tavoz - 243 - 1);
                }
                #endregion

                #region 09 sep
                //9(szeptember) -> 244-273
                //10(október) -> 274-304
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 244 &&
                    adatok[i].erkzes <= 273 &&
                    adatok[i].tavoz >= 244 &&
                    adatok[i].tavoz <= 273)
                {
                    szinek(9, adatok[i].erkzes - 243, adatok[i].eltoltnapok);
                }
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 244 &&
                    adatok[i].erkzes <= 273 &&
                    adatok[i].tavoz >= 273 &&
                    adatok[i].tavoz <= 304)
                {

                    szinek(9, adatok[i].erkzes - 243, adatok[i].eltoltnapok);
                    szinek(10, 1, adatok[i].tavoz - 273 - 1);
                }
                #endregion

                #region 10 okt
                //10(október) -> 274-304
                //11(november) -> 305-334
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 274 &&
                    adatok[i].erkzes <= 304 &&
                    adatok[i].tavoz >= 274 &&
                    adatok[i].tavoz <= 304)
                {
                    szinek(10, adatok[i].erkzes - 273, adatok[i].eltoltnapok);
                }
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 274 &&
                    adatok[i].erkzes <= 304 &&
                    adatok[i].tavoz >= 304 &&
                    adatok[i].tavoz <= 334)
                {

                    szinek(10, adatok[i].erkzes - 273, adatok[i].eltoltnapok);
                    szinek(11, 1, adatok[i].tavoz - 304 - 1);
                }
                #endregion

                #region 11 nov
                //11(november) -> 305-334
                //12(december) -> 335-365
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 305 &&
                    adatok[i].erkzes <= 334 &&
                    adatok[i].tavoz >= 305 &&
                    adatok[i].tavoz <= 334)
                {
                    szinek(11, adatok[i].erkzes - 304, adatok[i].eltoltnapok);
                }
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 305 &&
                    adatok[i].erkzes <= 334 &&
                    adatok[i].tavoz >= 334 &&
                    adatok[i].tavoz <= 365)
                {

                    szinek(11, adatok[i].erkzes - 304, adatok[i].eltoltnapok);
                    szinek(12, 1, adatok[i].tavoz - 334 - 1);
                }
                #endregion

                #region 12 dec
                //12(december) -> 335-365
                if (adatok[i].szobaszam == vszobaszam &&
                    adatok[i].erkzes >= 335 &&
                    adatok[i].erkzes <= 365 &&
                    adatok[i].tavoz >= 335 &&
                    adatok[i].tavoz <= 365)
                {
                    szinek(12, adatok[i].erkzes - 334, adatok[i].eltoltnapok);
                }
                #endregion

                
            }
            #endregion

            urescella();
        }

        private void SetDataGridViewCellColors(Color color)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = color;
                }
            }
        }


        private void szinek(int index1,int index2,int elteltnap)
        {
            for (int j = 0; j < elteltnap+1; j++)
            {
                if (index1 > 0 && index1 <= 12 && index2 > 0 && index2 <= 31)
                {
                    DataGridViewRow row = dataGridView1.Rows[index1 - 1];
                    row.Cells[index2].Style.BackColor = Color.DarkRed;
                    
                }
                index2++;
            }      
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            

            // Oszlop hozzáadása
            dataGridView1.Columns.Add("MonthColumn", "Hónap/Nap");

            for (int i = 1; i <= 31; i++)
            {
                dataGridView1.Columns.Add("Column" + i, i.ToString());
            }

            // Sor hozzáadása
            for (int i = 0; i < 12; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = GetMonthName(i + 1);
                
                for (int j = 1; j <= 31; j++)
                {
                    row.Cells[j].Value = j;
                }
                row.Cells[0].Style.BackColor = Color.FromArgb(155, 115, 223);
                dataGridView1.Rows.Add(row);
            }
        }

        private void urescella()
        {
            #region urescellak
            // Ellenőrizzük, hogy van-e legalább egy sor a DataGridView - ban
            if (dataGridView1.Rows.Count > 0)
            {
                #region feb
                // Az első sor utolsó cellájának törlése
                dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 1].Value = null;
                dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 2].Value = null;
                dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 3].Value = null;
                // Az utolsó cella nem szerkeszthető lesz
                dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 1].ReadOnly = true;
                dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 2].ReadOnly = true;
                dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 3].ReadOnly = true;
                // Az utolsó cella háttérszínének beállítása
                dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = Color.Gray;
                dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 2].Style.BackColor = Color.Gray;
                dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 3].Style.BackColor = Color.Gray;
                
                #endregion

                #region apr
                dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 1].Value = null;
                
                dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 1].ReadOnly = true;
                
                dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = Color.Gray;
                
                #endregion

                #region jun
                dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 1].Value = null;
                
                dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 1].ReadOnly = true;
                
                dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = Color.Gray;
                
                #endregion

                #region sep
                dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 1].Value = null;
                
                dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 1].ReadOnly = true;
                
                dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = Color.Gray;
                
                #endregion

                #region nov
                dataGridView1.Rows[10].Cells[dataGridView1.ColumnCount - 1].Value = null;
                
                dataGridView1.Rows[10].Cells[dataGridView1.ColumnCount - 1].ReadOnly = true;
                
                dataGridView1.Rows[10].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = Color.Gray;
                
                #endregion
            }
            #endregion
        }

        // Hónap beallitas 
        private string GetMonthName(int monthNumber)
        {
            switch (monthNumber)
            {
                case 1:
                    return "Január";
                case 2:
                    return "Február";
                case 3:
                    return "Március";
                case 4:
                    return "Április";
                case 5:
                    return "Május";
                case 6:
                    return "Június";
                case 7:
                    return "Július";
                case 8:
                    return "Augusztus";
                case 9:
                    return "Szeptember";
                case 10:
                    return "Október";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "";
            }
        }
    }
}
