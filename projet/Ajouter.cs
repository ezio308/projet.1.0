using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace projet
{
    public partial class Ajouter : Form
    {
        SqlConnection cnx = new SqlConnection(@"Data Source=LAPTOP-NJ81HHSQ\SQLSERVER;Initial Catalog=dbdd;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        
        public Ajouter()
        {
            InitializeComponent();
        }

        public void Deconnecter()//ay bd ma7loula tssakerha//
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }

        private void Ajouter_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'dbddDataSet.users'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.usersTableAdapter.Fill(this.dbddDataSet.users);

        }

        private void login_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {    
            
            Deconnecter();
            cnx.Open();
          //  cmd = new SqlCommand("INSERT INTO users   VALUES ('" + login.Text + "','" + password.Text + "','" + id.Text + "','" + email.Text + "','" + prenom.Text + "','" + nom.Text + "','" + adresse.Text + "'," + grade.Text + ",'" + numtel.Text + "','" + codecn.Text + "','" + etatcivil.Text + "','" + nomconjoint.Text + "','" + prenomconjoint.Text + "'," + nbrenf.Text + "," + role.Text + ")", cnx);
            cmd = new SqlCommand("INSERT INTO users (login,password,ID,email,name,lastname,adresse,grade,tel,codecn,etatcivil,nomconjoint,prenomconjoint,nbrenfants,role,datenaiss) VALUES ('" + login.Text + "','" + password.Text + "','" + id.Text + "','" + email.Text + "','" + prenom.Text + "','" + nom.Text + "','" + adresse.Text + "','"+grade1.SelectedItem.ToString()+"','"  + numtel.Text + "','" + codecn.Text + "','" + etatcivil.Text + "','" + nomconjoint.Text + "','" + prenomconjoint.Text + "','"+nbrenf1.SelectedItem.ToString()+"','" +listBox2.SelectedItem.ToString()+"','"+dateTimePicker1.Value.ToString()+"')", cnx);
            int i = cmd.ExecuteNonQuery();
            


            if (i != 0)
            {
                MessageBox.Show("Ajout effectué avec succes","cbon" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cnx.Close();
            this.Hide();

                                      
          
        }
    }
}
    

