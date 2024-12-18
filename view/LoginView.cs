﻿using System;
using System.Windows.Forms;
using MedSys.controller;

namespace MedSys.view
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public void btnEntrar_Click(object sender, EventArgs e)
        {
            VerificaUsuario(txtUsuario.Text, txtSenha.Text);
        }
        public void VerificaUsuario(string nomeUsuario, string senhaUsuario)
        {
            UserController usuarioController = new UserController();

            if(usuarioController.ValidarUsuarioSenha(nomeUsuario, senhaUsuario) != null)
            {
                
                Form form = new TelaPrincipalView();
                form.Show();

                this.Hide();
            }
        }
    }
}