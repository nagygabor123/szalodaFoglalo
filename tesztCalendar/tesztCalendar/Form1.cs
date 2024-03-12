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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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
        int utolsoElem = 0;
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
            dataGridView1.CellClick -= cell_click;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            cellaszinvissza();

            #region filebe
            StreamReader olvas = new StreamReader("pitypang.txt");

            while (!olvas.EndOfStream)
            {
                adatok.Add(new foglalas(olvas.ReadLine()));

            }
            olvas.Close();
            length = adatok.Count;
            utolsoElem = Convert.ToInt32(adatok[adatok.Count - 1].sorszam)+1;
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

            dataGridView1.CellClick += cell_click;

            urescella();
        }

        private void cellaszinvissza()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                    cell.Style.ForeColor = Color.Black;
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
                    row.Cells[index2].Style.BackColor = Color.FromArgb(245, 97, 105);
                    row.Cells[index2].Style.ForeColor = Color.White;
                    
                }
                index2++;
            }      
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ReadOnly = true;
            
            // Oszlop hozzáadása
            dataGridView1.Columns.Add("MColumn", "Hónapok");

            for (int i = 1; i <= 31; i++)
            {
                dataGridView1.Columns.Add("Column"+i," ");
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
                dataGridView1.Rows.Add(row);
            }
            
        }

        

        private void urescella()
        {
            #region urescellak
            
            #region honapok
            Font boldFont = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.Columns[0].Width = 80;
            

            dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount - 32].Style.BackColor = Color.FromArgb(188, 223, 227);
            dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 32].Style.BackColor = Color.FromArgb(188, 223, 227);
            dataGridView1.Rows[2].Cells[dataGridView1.ColumnCount - 32].Style.BackColor = Color.FromArgb(188, 223, 227);
            dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 32].Style.BackColor = Color.FromArgb(188, 223, 227);
            dataGridView1.Rows[4].Cells[dataGridView1.ColumnCount - 32].Style.BackColor = Color.FromArgb(188, 223, 227);
            dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 32].Style.BackColor = Color.FromArgb(188, 223, 227);
            dataGridView1.Rows[6].Cells[dataGridView1.ColumnCount - 32].Style.BackColor = Color.FromArgb(188, 223, 227);
            dataGridView1.Rows[7].Cells[dataGridView1.ColumnCount - 32].Style.BackColor = Color.FromArgb(188, 223, 227);
            dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 32].Style.BackColor = Color.FromArgb(188, 223, 227);
            dataGridView1.Rows[9].Cells[dataGridView1.ColumnCount - 32].Style.BackColor = Color.FromArgb(188, 223, 227);
            dataGridView1.Rows[10].Cells[dataGridView1.ColumnCount - 32].Style.BackColor = Color.FromArgb(188, 223, 227);
            dataGridView1.Rows[11].Cells[dataGridView1.ColumnCount - 32].Style.BackColor = Color.FromArgb(188, 223, 227);

            dataGridView1.Rows[0].Cells[dataGridView1.ColumnCount - 32].Style.Font = boldFont;
            dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 32].Style.Font = boldFont;
            dataGridView1.Rows[2].Cells[dataGridView1.ColumnCount - 32].Style.Font = boldFont;
            dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 32].Style.Font = boldFont;
            dataGridView1.Rows[4].Cells[dataGridView1.ColumnCount - 32].Style.Font = boldFont;
            dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 32].Style.Font = boldFont;
            dataGridView1.Rows[6].Cells[dataGridView1.ColumnCount - 32].Style.Font = boldFont;
            dataGridView1.Rows[7].Cells[dataGridView1.ColumnCount - 32].Style.Font = boldFont;
            dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 32].Style.Font = boldFont;
            dataGridView1.Rows[9].Cells[dataGridView1.ColumnCount - 32].Style.Font = boldFont;
            dataGridView1.Rows[10].Cells[dataGridView1.ColumnCount - 32].Style.Font = boldFont;
            dataGridView1.Rows[11].Cells[dataGridView1.ColumnCount - 32].Style.Font = boldFont;
            #endregion

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
                dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = Color.FromArgb(188, 223, 227);
                dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 2].Style.BackColor = Color.FromArgb(188, 223, 227);
                dataGridView1.Rows[1].Cells[dataGridView1.ColumnCount - 3].Style.BackColor = Color.FromArgb(188, 223, 227);

                #endregion

            #region apr
                dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 1].Value = null;
                
                dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 1].ReadOnly = true;
                
                dataGridView1.Rows[3].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = Color.FromArgb(188, 223, 227);

                #endregion

            #region jun
                dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 1].Value = null;
                
                dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 1].ReadOnly = true;
                
                dataGridView1.Rows[5].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = Color.FromArgb(188, 223, 227);

                #endregion

            #region sep
                dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 1].Value = null;
                
                dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 1].ReadOnly = true;
                
                dataGridView1.Rows[8].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = Color.FromArgb(188, 223, 227);

                #endregion

            #region nov
                dataGridView1.Rows[10].Cells[dataGridView1.ColumnCount - 1].Value = null;
                
                dataGridView1.Rows[10].Cells[dataGridView1.ColumnCount - 1].ReadOnly = true;
                
                dataGridView1.Rows[10].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = Color.FromArgb(188, 223, 227);

                #endregion
            
            #endregion
        }

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

       
        private DataGridViewCell startdate = null;
        private DataGridViewCell enddate = null;


        private void cell_click(object sender, DataGridViewCellEventArgs kivalasztott)
        {
            if (startdate == null)
            {
                startdate = dataGridView1.Rows[kivalasztott.RowIndex].Cells[kivalasztott.ColumnIndex];
                startdate.Style.BackColor = Color.Yellow;
            }
            else if (enddate == null)
            {
                enddate = dataGridView1.Rows[kivalasztott.RowIndex].Cells[kivalasztott.ColumnIndex];
                enddate.Style.BackColor = Color.Yellow;

                ShowPopupForm();
            }
            else
            {
                startdate.Style.BackColor = Color.White;
                enddate.Style.BackColor = Color.White;
                startdate = null;
                enddate = null;
                cell_click(sender, kivalasztott);
            }
        }
        
        private void ShowPopupForm()
        {
            #region Felulet letrehozasa
            Form popupForm = new Form();
            popupForm.Text = "Foglalás";
            popupForm.Size = new Size(400, 250);
            popupForm.ControlBox = false;
            popupForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            popupForm.BackgroundImage = Image.FromFile(@"D:\app\szalodaFoglalo\3.png");

            System.Windows.Forms.Label startLabel = new System.Windows.Forms.Label();
            startLabel.Text = "Érkezés: " + startdate.OwningRow.Cells[0].Value.ToString() + "." + startdate.Value.ToString();
            startLabel.Location = new Point(20, 20);
            startLabel.BackColor = Color.Transparent;
            popupForm.Controls.Add(startLabel);

            System.Windows.Forms.Label endLabel = new System.Windows.Forms.Label();
            endLabel.Text = "Távozás: " + enddate.OwningRow.Cells[0].Value.ToString() + "." + enddate.Value.ToString();
            endLabel.Location = new Point(20, 50);
            endLabel.BackColor = Color.Transparent;
            popupForm.Controls.Add(endLabel);

            System.Windows.Forms.Label roomLabel = new System.Windows.Forms.Label();
            roomLabel.Text = "Szobaszám: " + vszobaszam;
            roomLabel.Location = new Point(20, 80);
            roomLabel.BackColor = Color.Transparent;
            popupForm.Controls.Add(roomLabel);

            System.Windows.Forms.Label nameLabel = new System.Windows.Forms.Label();
            nameLabel.Text = "Név:";
            nameLabel.Location = new Point(130, 20);
            nameLabel.BackColor = Color.Transparent;
            popupForm.Controls.Add(nameLabel);

            System.Windows.Forms.TextBox nameTextBox = new System.Windows.Forms.TextBox();
            nameTextBox.Location = new Point(135, 45);
            popupForm.Controls.Add(nameTextBox);

            System.Windows.Forms.ComboBox letszam = new System.Windows.Forms.ComboBox();
            letszam.Location = new Point(160, 80);
            letszam.Items.Add(1);
            letszam.Items.Add(2);
            letszam.Items.Add(3);
            popupForm.Controls.Add(letszam);

            RadioButton radioBtnZero = new RadioButton();
            radioBtnZero.Text = "Kérek";
            radioBtnZero.Location = new Point(20, 110);
            radioBtnZero.BackColor = Color.Transparent;
            popupForm.Controls.Add(radioBtnZero);

            RadioButton radioBtnOne = new RadioButton();
            radioBtnOne.Text = "Nem kérek";
            radioBtnOne.Location = new Point(20, 140);
            radioBtnOne.BackColor = Color.Transparent;  
            popupForm.Controls.Add(radioBtnOne);

            System.Windows.Forms.Button cancelButton = new System.Windows.Forms.Button();
            cancelButton.Text = "Mégse";
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(20, 170);
            popupForm.Controls.Add(cancelButton);

            System.Windows.Forms.Button reserveButton = new System.Windows.Forms.Button();
            reserveButton.Text = "Foglalás";
            reserveButton.DialogResult = DialogResult.OK;
            reserveButton.Location = new Point(100, 170);
            popupForm.Controls.Add(reserveButton);
            #endregion

            if (popupForm.ShowDialog() == DialogResult.OK)
            {
                #region valtozok letrehozas
                string reggeli = "";
                int erkez = erkezhonapboszam();;
                int tav = tavozhonapboszam();
                string valasztottFo = Convert.ToString(letszam.SelectedItem);
                string nev = nameTextBox.Text;  
                
                if (radioBtnZero.Checked)
                {
                    reggeli = "0";
                }
                else if (radioBtnOne.Checked)
                {
                    reggeli = "1";
                }
                #endregion
                StreamWriter ir = File.AppendText(@"D:\app\szalodaFoglalo\tesztCalendar\tesztCalendar\bin\Debug\pitypang.txt");
                ir.Write($"\n{utolsoElem} {vszobaszam} {erkez} {tav} {valasztottFo} {reggeli} {nev}");
                ir.Close(); 
                MessageBox.Show("Foglalás sikeres!");
            }
        }

        private int erkezhonapboszam()
        {
            string honap = startdate.OwningRow.Cells[0].Value.ToString();
            int nap = Convert.ToInt32(startdate.Value);
            #region honap kivalasztasa
            if (honap == "Január")
            {
                return nap;        
            }
            if (honap == "Február")
            {
                return nap + 32;
            }
            if (honap == "Március")
            {
                return nap + 60;
            }
            if (honap == "Április")
            {
                return nap + 91;
            }
            if (honap == "Május")
            {
                return nap + 121;
            }
            if (honap == "Junius")
            {
                return nap + 152;
            }
            if (honap == "Július")
            {
                return nap + 182;
            }
            if (honap == "Augusztus")
            {
                return nap + 213;
            }
            if (honap == "Szeptember")
            {
                return nap + 244;
            }
            if (honap == "Október")
            {
                return nap + 274;
            }
            if (honap == "November")
            {
                return nap + 305;
            }
            if (honap == "December")
            {
                return nap + 335;
            }
            #endregion
            return nap;   
        }

        private int tavozhonapboszam()
        {
            string honap = enddate.OwningRow.Cells[0].Value.ToString();
            int nap = Convert.ToInt32(enddate.Value);
            #region honap kivalasztasa
            if (honap == "Január")
            {
                return nap;
            }
            if (honap == "Február")
            {
                return nap + 32;
            }
            if (honap == "Március")
            {
                return nap + 60;
            }
            if (honap == "Április")
            {
                return nap + 91;
            }
            if (honap == "Május")
            {
                return nap + 121;
            }
            if (honap == "Junius")
            {
                return nap + 152;
            }
            if (honap == "Július")
            {
                return nap + 182;
            }
            if (honap == "Augusztus")
            {
                return nap + 213;
            }
            if (honap == "Szeptember")
            {
                return nap + 244;
            }
            if (honap == "Október")
            {
                return nap + 274;
            }
            if (honap == "November")
            {
                return nap + 305;
            }
            if (honap == "December")
            {
                return nap + 335;
            }
            #endregion
            return nap;
        }


    }
}


