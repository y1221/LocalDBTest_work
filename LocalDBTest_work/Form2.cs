using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// *************************************************************
// ■サービスベースのデータベース ⇒ データソース
// 追加方法：
// １．サービスベースのデータベースの追加
// ２．その他のウインドウ > データソース
// ３．追加 → データベース → データセット → 新しい接続
// ４．データソース：Microsoft SQL Server データベースファイル
// ５．データベースファイル名：１で作成したmdfファイル
// ６．Windows認証でOK → 次へ → 次へ → テーブルにチェックを付けて完了押下
// mdfファイル名：ServiceDB2.mdf
// 
// 特徴：
// ①テーブル名をドラッグアンドドロップでフォームに追加できる
// ②DB接続は勝手にしてくれる（自動で追加されるソースで行う））
// *************************************************************

namespace LocalDBTest_work
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // ****** 自動で追加される ******
        // データ更新処理
        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.serviceDB2DataSet);

        }

        // データ読み込み処理
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'serviceDB2DataSet.Customer' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.customerTableAdapter.Fill(this.serviceDB2DataSet.Customer);

        }
        // ****** 自動で追加される ******
    }
}
