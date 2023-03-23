using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class Form1 : Form
    {
        string optiune;
        string prenume;
        
        public Form1()
        {
            InitializeComponent();
            salonDataSet.EnforceConstraints = false;
            
        }

        private void angajatiBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.angajatiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.salonDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'salonDataSet.specializari' table. You can move, or remove it, as needed.
            this.specializariTableAdapter.Fill(this.salonDataSet.specializari);
            // TODO: This line of code loads data into the 'salonDataSet.programare' table. You can move, or remove it, as needed.
            this.programareTableAdapter.Fill(this.salonDataSet.programare);
            // TODO: This line of code loads data into the 'salonDataSet.optiuni' table. You can move, or remove it, as needed.
            this.optiuniTableAdapter.Fill(this.salonDataSet.optiuni);
            // TODO: This line of code loads data into the 'salonDataSet.clienti' table. You can move, or remove it, as needed.
            this.clientiTableAdapter.Fill(this.salonDataSet.clienti);
            // TODO: This line of code loads data into the 'salonDataSet.angajati' table. You can move, or remove it, as needed.
            this.angajatiTableAdapter.Fill(this.salonDataSet.angajati);
            optiuniTableAdapter.afisare_optiuni(salonDataSet.optiuni);
            listBox1.Hide();
            richTextBox3.Hide();
            label20.Hide();
          

        }

        private void paginaDePornireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
           

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
                   
            


        }

        private void clientiDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            optiune= listBox2.Text;
            richTextBox2.Clear();
            this.specializariTableAdapter.afisare_angajat_specializare(salonDataSet.specializari, optiune.ToString());
            DataTable dt = salonDataSet.specializari;
            listBox3.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
                listBox3.Items.Add( dt.Rows[i]["prenume"].ToString() );
            this.optiuniTableAdapter.afisare_idop(salonDataSet.optiuni, optiune.ToString());
            DataTable dt1 = this.salonDataSet.optiuni;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                richTextBox2.Text+= dt1.Rows[i]["pret"].ToString() + "lei";
                textBox4.Text =dt1.Rows[i]["idop"].ToString();
            }



            
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            prenume = listBox3.Text;
            
            this.angajatiTableAdapter.afisare_ida(salonDataSet.angajati, prenume.ToString());
            DataTable dt = this.salonDataSet.angajati;
            for (int i = 0; i < dt.Rows.Count; i++)
               textBox5.Text = dt.Rows[i]["ida"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Show();
            if (radioButton3.Checked == true)
            {
                this.optiuniTableAdapter.afisare_dupa_specializare(salonDataSet.optiuni, "coafeza");
                DataTable dt = this.salonDataSet.optiuni;
                listBox1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                    listBox1.Items.Add(dt.Rows[i]["denumire"] + " " + dt.Rows[i]["pret"] + " lei");

            }
            else
                if (radioButton4.Checked == true)
                {
                    this.optiuniTableAdapter.afisare_dupa_specializare(salonDataSet.optiuni, "manichiurista");
                    DataTable dt = this.salonDataSet.optiuni;
                    listBox1.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                        listBox1.Items.Add(dt.Rows[i]["denumire"] + " " + dt.Rows[i]["pret"] + " lei");

                }
                else
                    if (radioButton5.Checked == true)
                    {
                        this.optiuniTableAdapter.afisare_dupa_specializare(salonDataSet.optiuni, "cosmeticiana");
                        DataTable dt = this.salonDataSet.optiuni;
                        listBox1.Items.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                            listBox1.Items.Add(dt.Rows[i]["denumire"] + " " + dt.Rows[i]["pret"] + " lei");

                    }



        }

        private void programariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            this.optiuniTableAdapter.Fill(this.salonDataSet.optiuni);
            DataTable dt = this.salonDataSet.optiuni;
            listBox2.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
                listBox2.Items.Add(dt.Rows[i]["denumire"]);
        }

        private void angajațiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            this.angajatiTableAdapter.Fill(this.salonDataSet.angajati);
            DataTable dt = this.salonDataSet.angajati;
            listBox4.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
                listBox4.Items.Add(dt.Rows[i]["prenume"]);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sex;
            try
            {
                if (radioButton1.Checked == true)
                    sex = "feminin";
                else
                    sex = "masculin";
                clientiTableAdapter.adaugare_clienti(textBox1.Text, textBox2.Text, textBox3.Text, sex);
                clientiTableAdapter.Update(salonDataSet);
                programareTableAdapter.inserare_programare(dateTimePicker1.Value.ToString(), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
                programareTableAdapter.Update(salonDataSet);
                MessageBox.Show("comanda dumenvoastra a fost inregistrata");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox1.Focus();
                listBox2.ClearSelected();
                listBox3.ClearSelected();
                
            }
            catch
            {
                MessageBox.Show("nu ati introdus toate datele necesare");
            }
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Show();
            if (radioButton3.Checked == true)
            {
                this.optiuniTableAdapter.tratament_de_lux(salonDataSet.optiuni, "coafeza");
                DataTable dt = this.salonDataSet.optiuni;
                listBox1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                    listBox1.Items.Add(dt.Rows[i]["denumire"] + " " + dt.Rows[i]["pret"] + " lei");

            }
            else
                if (radioButton4.Checked == true)
                {
                    this.optiuniTableAdapter.tratament_de_lux(salonDataSet.optiuni, "manichiurista");
                    DataTable dt = this.salonDataSet.optiuni;
                    listBox1.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                        listBox1.Items.Add(dt.Rows[i]["denumire"] + " " + dt.Rows[i]["pret"] + " lei");

                }
                else
                    if (radioButton5.Checked == true)
                    {
                        this.optiuniTableAdapter.tratament_de_lux(salonDataSet.optiuni, "cosmeticiana");
                        DataTable dt = this.salonDataSet.optiuni;
                        listBox1.Items.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                            listBox1.Items.Add(dt.Rows[i]["denumire"] + " " + dt.Rows[i]["pret"] + " lei");

                    }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Show();
            if (radioButton3.Checked == true)
            {
                this.optiuniTableAdapter.tratamente_accesibile(salonDataSet.optiuni, "coafeza");
                DataTable dt = this.salonDataSet.optiuni;
                listBox1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                    listBox1.Items.Add(dt.Rows[i]["denumire"] + " " + dt.Rows[i]["pret"] + " lei");

            }
            else
                if (radioButton4.Checked == true)
                {
                    this.optiuniTableAdapter.tratamente_accesibile(salonDataSet.optiuni, "manichiurista");
                    DataTable dt = this.salonDataSet.optiuni;
                    listBox1.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                        listBox1.Items.Add(dt.Rows[i]["denumire"] + " " + dt.Rows[i]["pret"] + " lei");

                }
                else
                    if (radioButton5.Checked == true)
                    {
                        this.optiuniTableAdapter.tratamente_accesibile(salonDataSet.optiuni, "cosmeticiana");
                        DataTable dt = this.salonDataSet.optiuni;
                        listBox1.Items.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                            listBox1.Items.Add(dt.Rows[i]["denumire"] + " " + dt.Rows[i]["pret"] + " lei");

                    }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string angajat = listBox4.Text;
            richTextBox3.Show();
            label20.Show();
            richTextBox3.Clear();
            this.angajatiTableAdapter.detalii_angajat(salonDataSet.angajati, angajat.ToString());
            DataTable dt = this.salonDataSet.angajati;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                richTextBox3.Text += "nume angajat: " + dt.Rows[i]["nume"] + " " + dt.Rows[i]["prenume"] + "\n";
                richTextBox3.Text += "telefon: " + dt.Rows[i]["telefon"] + "\n";
            }
            if (angajat == "Mihaela")
            {
                richTextBox3.Text += "manichiurista de 3 ani la salonul nostru" + "\n";
                richTextBox3.Text += "fire prietenoasa si recomandata de toate clientele sale" + "\n";
            }
            else
                if (angajat == "Cristina")
                {
                    richTextBox3.Text += "cosmeticiana de 2 ani la salonul nostru" + "\n";
                    richTextBox3.Text += "este dedicata in ceea ce face si nu da gresi niciodata" + "\n";
                }
                else
                    if (angajat == "Ioana")
                    {
                        richTextBox3.Text += "manichiurista de 5 ani la salonul nostru" + "\n";
                        richTextBox3.Text += "este pasionata in ceea ce face si da tot ce are mai bun pentru fiecare clienta" + "\n";
                    }
                    else
                        if (angajat == "Maria")
                        {
                            richTextBox3.Text += "coafeza de 3 ani la salonul nostru" + "\n";
                            richTextBox3.Text += "este intelegatoare si pregatita sa indeplineasca toate dorintele clientului ei" + "\n";
                        }
                        else
                            if (angajat == "Irina")
                            {
                                richTextBox3.Text += "coafeza de 4 ani la salonul nostru" + "\n";
                                richTextBox3.Text += "este muncitoare si nu renunta pana nu isi vede clientul multumit in totalitate" + "\n";
                            }
                            else
                              if (angajat == "Andra")
                                {
                                    richTextBox3.Text += "cosmeticiana de 2 ani la salonul nostru" + "\n";
                                    richTextBox3.Text += "este apreciata de toate clinetele sale si lucreaza cu pasiune" + "\n";
                                }
              


                

            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_2(object sender, EventArgs e)
        {
           
                this.programareTableAdapter.Fill(this.salonDataSet.programare);
                this.programareTableAdapter.afisare_programari_angajati(salonDataSet.programare, textBox6.Text.ToString(), textBox7.Text.ToString());
                DataTable dt = this.salonDataSet.programare;
                richTextBox1.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                    richTextBox1.Text += "id programare:" + dt.Rows[i]["idp"] + " data programarii:" + dt.Rows[i]["data"] + " id optiune:" + dt.Rows[i]["idop"] + '\n';
                
            
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            this.angajatiTableAdapter.Fill(this.salonDataSet.angajati);
            DataTable dt = this.salonDataSet.angajati;
            listBox4.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
                listBox4.Items.Add(dt.Rows[i]["prenume"]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            this.optiuniTableAdapter.Fill(this.salonDataSet.optiuni);
            DataTable dt = this.salonDataSet.optiuni;
            listBox2.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
                listBox2.Items.Add(dt.Rows[i]["denumire"]);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button10_Click(object sender, EventArgs e)

        {
            tabControl1.SelectedTab = tabPage1;
        }
    }
}
