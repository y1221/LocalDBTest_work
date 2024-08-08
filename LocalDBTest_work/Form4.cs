using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalDBTest_work
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'serviceDB2DataSet1.Customer' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.customerTableAdapter.Fill(this.serviceDB2DataSet1.Customer);

            dataGridView1.DataSource = bindingSource1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = serviceDB2DataSet1.Customer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int target = int.Parse(textBox1.Text);
            var query = from rs in this.serviceDB2DataSet1.Customer
                        where rs.Id == target
                        select rs;

            bindingSource1.DataSource = query;

            //bindingSource1.DataSource = serviceDB2DataSet1.Customer.Where(r => r.Id == target);
        }
    }
}
