using MySql.Data.MySqlClient;
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

namespace TesteOxxy.Cadastro
{
    public partial class FormCadastro : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;

        string foto;

        public FormCadastro()
        {
            InitializeComponent();
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {
            LimparFoto();
            Listar();
        }

        private void Listar()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM cadastroveiculo ORDER BY id ";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharConexao();
        }

        private void habilitarCampos()
        {
            btnFoto.Enabled = true;
            btnSalvar.Enabled = true;
            textBoxRenavam.Enabled = true;
            textBoxAnoFab.Enabled = true;
            textBoxAnoMod.Enabled = true;
            textBoxChassi.Enabled = true;
            textBoxMotor.Enabled = true;
            textBoxPlaca.Enabled = true;
            textBoxMarca.Enabled = true;
            btnNovo.Enabled = false;
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void LimparCampos()
        {
            textBoxAnoFab.Text = "";
            textBoxAnoMod.Text = "";
            textBoxChassi.Text = "";
            textBoxMarca.Text = "";
            textBoxMotor.Text = "";
            textBoxPlaca.Text = "";
            textBoxRenavam.Text = "";
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (textBoxRenavam.Text == "")
            {
                MessageBox.Show("Preencha o campo Renavam", "Cadastro de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxRenavam.Text = "";
                textBoxRenavam.Focus();
                return;
            }

            con.AbrirConexao();
            sql = "INSERT INTO cadastroveiculo(renavam, anofabricacao, anomodelo, placa, motor, marca, chassi, data, foto) VALUES (@renavam, @anofabricacao, @anomodelo, @placa, @motor, @marca, @chassi, curdate(), @foto)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@renavam", textBoxRenavam.Text);
            cmd.Parameters.AddWithValue("@anofabricacao", textBoxAnoFab.Text);
            cmd.Parameters.AddWithValue("@anomodelo", textBoxAnoMod.Text);
            cmd.Parameters.AddWithValue("@placa", textBoxPlaca.Text);
            cmd.Parameters.AddWithValue("@motor", textBoxMotor.Text);
            cmd.Parameters.AddWithValue("@marca", textBoxMarca.Text);
            cmd.Parameters.AddWithValue("@chassi", textBoxChassi.Text);
            cmd.Parameters.AddWithValue("@foto", img());
            cmd.ExecuteNonQuery();
            con.FecharConexao();

            LimparFoto();
            LimparCampos();

            MessageBox.Show("Cadastro realizado com sucesso!", "Cadastro de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirFoto = new OpenFileDialog();
            abrirFoto.Filter = "Imagens(*.jpg; *.png) | *.jpg, *png";
            if (abrirFoto.ShowDialog() == DialogResult.OK) 
            {
                foto = abrirFoto.FileName.ToString();
                image.ImageLocation = foto;
                //alterouImagem = "sim";
            }
        }

        private byte[] img()
        {
            byte[] image_byte = null;
            if (foto == "")
            {
                return null;
            }

            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs);

            image_byte = br.ReadBytes((int)fs.Length);

            return image_byte;

        }

        private void LimparFoto()
        {
            image.Image = Properties.Resources.download;
            foto = "img/download.png";
        }
    }
}
