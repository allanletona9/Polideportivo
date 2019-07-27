﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace Polideportivo_Administrativo.Mantenimientos
{
    public partial class frm_adminEquipos : Form
    {
        bool bBoton_ingreso = false;
        bool bBoton_modificar = false;
        bool bBoton_eliminar = false;
        OdbcCommand cmd;

        public frm_adminEquipos()
        {
            //Autor: Allan Letona
            InitializeComponent();
        }

        private void frm_adminEquipos_Load(object sender, EventArgs e)
        {
            Txt_codigoEquipo.Enabled = false;
        }

        private void Btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_equipos equipos = new frm_equipos();
            equipos.Show();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        void habilitarBotones()
        {
            Txt_nombreEquipo.Enabled = true;
            Txt_descripcionEquipo.Enabled = true;
            Gpb_estado.Enabled = true;
        }

        void bloquearBotones()
        {
            Btn_eliminar.Enabled = false;
            Btn_ingresar.Enabled = false;
            Btn_modificar.Enabled = false;
        }

        void habilitarTodo()
        {
            Txt_nombreEquipo.Enabled = true;
            Txt_descripcionEquipo.Enabled = true;
            Gpb_estado.Enabled = true;
            Btn_eliminar.Enabled = true;
            Btn_ingresar.Enabled = true;
            Btn_modificar.Enabled = true;
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            habilitarBotones();
            bloquearBotones();
            Txt_nombreEquipo.Text = "";
            Txt_descripcionEquipo.Text = "";
            Gpb_estado.Enabled = false;
            bBoton_ingreso = true;
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            habilitarBotones();
            bloquearBotones();
            bBoton_modificar = true;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            habilitarBotones();
            bloquearBotones();
            bBoton_eliminar = true;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            bool bIngresoCorrecto = true;
            if (bBoton_ingreso==true)
            {
                
                try
                {

                    if ((Txt_nombreEquipo.Text == "" || Txt_descripcionEquipo.Text == ""))
                    {
                        MessageBox.Show("Hacen Falta Campos Por Llenar", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bIngresoCorrecto = false;
                    }
                    else
                    {
                        cmd = new OdbcCommand("INSERT INTO tbl_equipos(nombre_equipo, descripcion_equipo, estado_equipo) VALUES ('"+Txt_nombreEquipo.Text+"', '"+Txt_descripcionEquipo.Text+"', 1)", conexion.conectar());
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show(ex.Message);
                    bIngresoCorrecto = false;
                }

                if (bIngresoCorrecto)
                {
                    MessageBox.Show("Equipo Ingresado Correctamente");
                    Txt_nombreEquipo.Text = " ";
                    Txt_descripcionEquipo.Text = " ";
                    habilitarTodo();
                }
            }
            else if(bBoton_modificar==true)
            {
                //bool ingresoCorrecto = true;
                try
                {

                    if ((Txt_nombreEquipo.Text == "" || Txt_descripcionEquipo.Text == ""))
                    {
                        MessageBox.Show("Hacen Falta Campos Por Llenar", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bIngresoCorrecto = false;
                    }
                    else
                    {
                        if (Rdb_habilitado.Checked == true)
                        {
                            cmd = new OdbcCommand("UPDATE tbl_equipos SET nombre_equipo='"+Txt_nombreEquipo.Text+"', descripcion_equipo='"+Txt_descripcionEquipo.Text+"', estado_equipo=1 WHERE PK_idEquipo = '"+Txt_codigoEquipo.Text+"'", conexion.conectar());
                            cmd.ExecuteNonQuery();
                            

                        }
                        else if (Rbd_deshabilitado.Checked == true)
                        {
                            cmd = new OdbcCommand("UPDATE tbl_equipos SET nombre_equipo='" + Txt_nombreEquipo.Text + "', descripcion_equipo='" + Txt_descripcionEquipo.Text + "', estado_equipo=0 WHERE PK_idEquipo = '" + Txt_codigoEquipo.Text + "'", conexion.conectar());
                            cmd.ExecuteNonQuery();
                        }

                    }
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show(ex.Message);
                    bIngresoCorrecto = false;
                }

                if (bIngresoCorrecto)
                {
                    MessageBox.Show("Equipo Modificado Correctamente");
                    Txt_codigoEquipo.Text = " ";
                    Txt_nombreEquipo.Text = " ";
                    Txt_descripcionEquipo.Text = " ";
                    Rdb_habilitado.Checked =false;
                    Rbd_deshabilitado.Checked = false;
                    habilitarTodo();
                }
            }
            else if(bBoton_eliminar==true)
            {
                //bool ingresoCorrecto = true;
                try
                {
                    cmd = new OdbcCommand("UPDATE tbl_equipos SET estado_equipo=0 WHERE PK_idEquipo ='"
                   + Txt_codigoEquipo.Text + "'", conexion.conectar());
                    cmd.ExecuteNonQuery();
                }
                catch(OdbcException ex)
                {
                    MessageBox.Show(ex.Message);
                    bIngresoCorrecto = false;
                }

                if (bIngresoCorrecto)
                {
                    MessageBox.Show("Equipo Eliminado Correctamente");
                    Txt_codigoEquipo.Text = " ";
                    Txt_nombreEquipo.Text = " ";
                    Txt_descripcionEquipo.Text = " ";
                    Rdb_habilitado.Checked = false;
                    Rbd_deshabilitado.Checked = false;
                    habilitarTodo();
                }
            }
        }

        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            frm_equipos equipos = new frm_equipos();
            equipos.Show();
            this.Close();
        }
    }
}
