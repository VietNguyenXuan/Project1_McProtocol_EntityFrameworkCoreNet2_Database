using McProtocol;
using McProtocol.Mitsubishi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Gateway;
using WindowsFormsApp1.Manager;
using WindowsFormsApp1.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
        InitializeComponent();
        // Đưa con trỏ tại Ip khi bắt đầu chạy chương trình
        this.ActiveControl = textBox_ip1;
        textBox_ip1.Focus();
    }

    RegisterManager _registerManager = new RegisterManager();

    McProtocolTcp mcProtocolTcp;
    private async void button_connect_Click_1(object sender, EventArgs e)
    {
      int port = Convert.ToInt32(textBox_port.Text);
      string iP = textBox_ip1.Text + "." + textBox_ip2.Text + "." + textBox_ip3.Text + "." + textBox_ip4.Text;
            
      mcProtocolTcp = new McProtocolTcp(iP, port, McFrame.MC3E);
      await mcProtocolTcp.Open();

      if (mcProtocolTcp.Connected == true)
      {
        MessageBox.Show("Connect Successful!");
        timer1.Start();
        timer_update_database.Start(); 
      }
    }

    string[] id_register = {"3000", "3001", "3002", "3003", "3004", "3005", "3006", "3007", "3008", "3009" };
    int[] value_register = new int[10];

    //List<dataCollect> data_collect;
    private async void button_write_Click_1(object sender, EventArgs e)
    {      
      int data;
      string register;

      data = int.Parse(textBox_value_write.Text);

      value_register[comboBox_write.SelectedIndex] = data;

      await mcProtocolTcp.WriteDeviceBlock("D3000", 10, value_register);
      MessageBox.Show("Complete");
    }

    public void LoadData()
    {
      var students = _registerManager.GetAll();

      dataGridView1.Rows.Clear();

      int length = students.Count;

      dataGridView1.Rows.Add(students[length - 1].Id, "D3000", students[length - 1].D3000);
      dataGridView1.Rows.Add(students[length - 1].Id, "D3001", students[length - 1].D3001);
      dataGridView1.Rows.Add(students[length - 1].Id, "D3002", students[length - 1].D3002);
      dataGridView1.Rows.Add(students[length - 1].Id, "D3003", students[length - 1].D3003);
      dataGridView1.Rows.Add(students[length - 1].Id, "D3004", students[length - 1].D3004);
      dataGridView1.Rows.Add(students[length - 1].Id, "D3005", students[length - 1].D3005);
      dataGridView1.Rows.Add(students[length - 1].Id, "D3006", students[length - 1].D3006);
      dataGridView1.Rows.Add(students[length - 1].Id, "D3007", students[length - 1].D3007);
      dataGridView1.Rows.Add(students[length - 1].Id, "D3008", students[length - 1].D3008);
      dataGridView1.Rows.Add(students[length - 1].Id, "D3009", students[length - 1].D3009);
    }


    public async void Read_WriteDataDB()
    {
      var oDataNew1 = await mcProtocolTcp.ReadDeviceBlock("D3000", 10);

      for (int i = 0; i < oDataNew1.Length; i++)
        value_register[i] = oDataNew1[i];

      try
      {
        Student student = new Student();

        student.D3000 = value_register[0].ToString();
        student.D3001 = value_register[1].ToString();
        student.D3002 = value_register[2].ToString();
        student.D3003 = value_register[3].ToString();
        student.D3004 = value_register[4].ToString();
        student.D3005 = value_register[5].ToString();
        student.D3006 = value_register[6].ToString();
        student.D3007 = value_register[7].ToString();
        student.D3008 = value_register[8].ToString();
        student.D3009 = value_register[9].ToString();

        
        if (_registerManager.Add(student))
        {
          //MessageBox.Show("Data has been saved database", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          //MessageBox.Show("Data saved database failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private async void comboBox_read_SelectedIndexChanged(object sender, EventArgs e)
    {
      textBox_value_read.Text = value_register[comboBox_read.SelectedIndex].ToString();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Student student = new Student();
      button_status.Visible = !button_status.Visible;
      LoadData();
    }
    private void timer_update_database_Tick(object sender, EventArgs e)
    {
      Read_WriteDataDB();
    }
  }
}
