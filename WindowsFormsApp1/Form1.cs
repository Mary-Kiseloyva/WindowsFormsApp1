using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "DLL Files (*.dll)|*.dll|All Files (*.*)|*.*";

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    string selectedFilePath = dialog.FileName;
                    label1.Text = selectedFilePath;
                    Assembly assembly = Assembly.LoadFrom(selectedFilePath);
                    Type interfaceType = assembly.GetType("task5.Vehicle");
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (interfaceType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract && !type.IsInterface)
                        {
                            comboBox1.Items.Add(type.FullName);
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
            {
                throw new System.NotImplementedException();
            }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedClass = comboBox1.SelectedItem.ToString();
                Assembly assembly = Assembly.LoadFrom(label1.Text);
                Type classType = assembly.GetType(selectedClass);

                if (classType != null)
                {
                    MethodInfo[] methods = classType.GetMethods();
                    string methodsText = string.Join(Environment.NewLine, methods.Select(m => m.Name));
                    label2.Text = methodsText;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
    }
