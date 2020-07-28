using System;
using System.Windows.Forms;
using Loja.DTO;
using Loja.BLL;
using System.Collections.Generic;

namespace Loja
{
    public partial class Cadastro_usuario : Form
    {
        string modo = "";
        int codUsuSelecionado = -1;
        public Cadastro_usuario()
        {
            InitializeComponent();
        }

        private void Cadastro_usuario_Load(object sender, EventArgs e)
        {
            CarregaGrid();
            lblMensagem.Text = "";
        }

        private void CarregaGrid() 
        { 
            try
            {
                IList<usuario_DTO> listUsuario_DTO = new List<usuario_DTO>();
                listUsuario_DTO = new UsuarioBLL().CargaUsuario();

                dataGridView1.DataSource = listUsuario_DTO;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sel = dataGridView1.CurrentRow.Index;

            txtNome.Text = Convert.ToString(dataGridView1["nome", sel].Value);
            txtLogin.Text = Convert.ToString(dataGridView1["login", sel].Value);
            txtEmail.Text = Convert.ToString(dataGridView1["email", sel].Value);
            txtSenha.Text = Convert.ToString(dataGridView1["senha", sel].Value);
            txtCadastro.Text = Convert.ToString(dataGridView1["cadastro", sel].Value);

            codUsuSelecionado = Convert.ToInt32(dataGridView1["cod_usuario", sel].Value);

            if (Convert.ToString(dataGridView1["situacao", sel].Value)== "A")
            {
                cboSituacao.Text = "Ativo";
            }else
            {
                cboSituacao.Text = "Inativo";
                cboPerfil.Text = Convert.ToString(dataGridView1["perfil", sel].Value);
            }

            switch(Convert.ToString(dataGridView1["perfil", sel].Value))
            {
                case "1":
                    cboPerfil.Text = "Administrador";
                    break;
                case "2":
                    cboPerfil.Text = "Operador";
                    break;
                case "3":
                    cboPerfil.Text = "Gerencial";
                    break;
            }
        }
        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpar_campos();
            txtCadastro.Text = Convert.ToString(System.DateTime.Now);
            modo = "novo";
        }

        private void Limpar_campos()
        {
            txtNome.Text  =  "";
            txtLogin.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtCadastro.Text = "";
            cboPerfil.Text = "";
            cboSituacao.Text = "";
            lblMensagem.Text = "";
            codUsuSelecionado = -1;
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (modo.ToString().Equals("novo"))
            {
                try
                {
                    usuario_DTO USU = new usuario_DTO();
                    USU.Nome = txtNome.Text;
                    USU.Login = txtLogin.Text;
                    USU.Email = txtEmail.Text;
                    USU.Cadastro = DateTime.Now;
                    USU.Senha = txtSenha.Text;

                    if(cboSituacao.Text == "Ativo")
                    {
                        USU.Situacao = "A";
                    }
                    else
                    {
                        USU.Situacao = "I";
                    }

                    switch (cboPerfil.Text)
                    {
                        case "Administrador":
                            USU.Perfil = 1;
                            break;

                        case "Operador":
                            USU.Perfil = 2;
                            break;

                        case "Gerencial":
                            USU.Perfil = 3;
                            break;
                    }

                    int x = new UsuarioBLL().InsereUsuario(USU);
                    if (x > 0)
                    {
                        MessageBox.Show("Gravado com Sucesso!");
                    }

                    CarregaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado" + ex.Message);
                }

                modo = "";
            }

            if (modo.ToString().Equals("altera"))
            {
                /*Tratamento de Erros, exibe msg*/
                try
                {
                    if (codUsuSelecionado < 0)
                    {
                        lblMensagem.Text = "Selecione um usuario antes de prosseguir";
                        return;
                    }
                    /*Objeto USU, assim como feito no modo="novo"
                    Lê os textbox com os dados alterados*/
                    usuario_DTO USU = new usuario_DTO();
                    USU.Cod_usuario = codUsuSelecionado;
                    USU.Nome = txtNome.Text;
                    USU.Login = txtLogin.Text;
                    USU.Email = txtEmail.Text;

                    USU.Senha = txtSenha.Text;
                    if (cboSituacao.Text == "Ativo")
                    {
                        USU.Situacao = "A";
                    }
                    else
                    {
                        USU.Situacao = "I";
                    }
                    switch (cboPerfil.Text)
                    {
                        case "Administrador":
                            USU.Perfil = 1;
                            break;
                        case "Operador":
                            USU.Perfil = 2;
                            break;
                        case "Gerencial":
                            USU.Perfil = 3;
                            break;
                    }
                    int x = new UsuarioBLL().EditaUsuario(USU);
                    /*Verifica se houve alguma gravação*/
                    if (x > 0)
                    {
                        lblMensagem.Text = "";
                        MessageBox.Show("Alterado com Sucesso!");
                    }
                    /*Recarrega o Grid após os dados serem gravados*/
                    CarregaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado" + ex.Message);
                }
            }

            if (modo.ToString().Equals("excluir"))
            {
                try
                {
                    if (codUsuSelecionado < 0)
                    {
                        lblMensagem.Text = "Selecione um usuario antes de prosseguir";
                        return;
                    }
                    usuario_DTO USU = new usuario_DTO();
                    USU.Cod_usuario = codUsuSelecionado;
                    int x = new UsuarioBLL().DeletaUsuario(USU);
                    if (x > 0)
                    {
                        MessageBox.Show("Excluido com Sucesso!");
                    }
                    /*Recarrega o Grid após os dados serem gravados*/
                    CarregaGrid();
                    Limpar_campos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado" + ex.Message);
                }
            }
            modo = "";

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (codUsuSelecionado < 0)
            {
                lblMensagem.Text = "*Selecione um usuário antes de prosseguir";
                return;
            }
            modo = "altera";
            MessageBox.Show("Para editar o usuario, clique em Confirmar");
        }

        private void BtnDeletar_Click(object sender, EventArgs e)
        {
            if (codUsuSelecionado < 0)
            {
                lblMensagem.Text = "*Selecione um usuário antes";
                return;
            }
            else
            {
                lblMensagem.Text = "";
                modo = "excluir";
                MessageBox.Show("Para excluir o usuario, clique em Confirmar");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            modo = "";
            Limpar_campos();
        }
    }
}
