using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// *************************************************************
// ■サービスベースのデータベース
// 追加方法：ソリューションエクスプローラー → プロジェクト名右クリック → 追加 → 新しい項目 → サービスベースのデータベース
// mdfファイル名：ServiceDB.mdf
// 
// 特徴：
// ①作成時にmdfファイル名を付ける ⇒ これはイコールDB名ではない
// ②DB接続にはAttachDBFilenameを使う
// *************************************************************

namespace LocalDBTest_work
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlCon;
        private SqlCommand sqlCom;
        private SqlDataAdapter sqlDA;
        private DataTable returnDB;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = @"C:\Users\yuto\Documents\学習関連\C#\DB接続（整理用）\LocalDBTest_work\LocalDBTest_work\ServiceDB.mdf",
                IntegratedSecurity = true
            };

            using (sqlCon = new SqlConnection(builder.ConnectionString))
            {
                sqlCon.Open();

                string query = "SELECT * FROM Customer";

                using (sqlCom = new SqlCommand(query, sqlCon))
                {
                    sqlDA = new SqlDataAdapter(sqlCom);

                    returnDB = new DataTable();
                    sqlDA.Fill(returnDB);
                }
            }

            dataGridView1.DataSource = returnDB;
        }
    }
}
