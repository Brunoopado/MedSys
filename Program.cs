﻿using System;
using System.Windows.Forms;
using MedSys.view;

namespace MedSys
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BuscarView());
        }
    }
}
