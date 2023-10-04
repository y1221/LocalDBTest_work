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
// ■SQL Serverデータベース
// 追加方法：サーバーエクスプローラー → データ接続右クリック → 新しいSQL Serverデータベースの作成
// サーバー名：(localdb)\mssqllocaldb ※デフォルトで用意されているサーバー
// DB名：SQLServerDB
// 
// 特徴：
// ①作成時にサーバーを指定して、DB名を付ける
// ②DB接続にはInitialCatalogを使う
// *************************************************************


// *************************************************************
// Form2でやったデータセットと、Form3でやったSQL Serverデータベースは
// ローカルサーバー上にDBが作られている（sys.databasesを確認済み）
// 逆にForm1でやったサービスベースは、DBは作られずにファイルでのみ管理するもの？
// *************************************************************

namespace LocalDBTest_work
{
    public partial class Form3 : Form
    {
        private SqlConnection sqlCon;
        private SqlCommand sqlCom;
        private SqlDataAdapter sqlDA;
        private DataTable returnDB;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                InitialCatalog = @"SQLServerDB",
                IntegratedSecurity = true,
                Pooling = false
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
