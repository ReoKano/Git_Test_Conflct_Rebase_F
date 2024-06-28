using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//===================================================
// 更新履歴
//===================================================
// 2024/06/27 : 012020048D : 新規追加
// 2024/06/28 : 012020048D : Task_5 : Search_Maintask_inTxt()追加
//===================================================

public class Search
{
    //===================================================
    // 共通変数
    //===================================================
    static public string Str_undetermined = "未確定";

    //===================================================
    // ファイル内の関数検索
    // str_file_path : 検索対象ファイルのパス
    // str_func_name : 検査対象の関数名
    //===================================================
    static string Search_Maintask_inTxt(string str_file_path, string str_func_name)
    {
        string file_path = str_file_path;
        string func_name = str_func_name;
        string mid_maintask = Str_undetermined;
        string return_maintask = Str_undetermined;
        int line_cnt = 1;

        FileStream fs = new FileStream(str_file_path, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("SHIFT_JIS"));
        try
        {
            // 末尾まで
            while (sr.EndOfStream == false)
            {
                // 1行読み出す
                string line = sr.ReadLine();

                // 7行目（最上位タスク）の場合
                if (line_cnt == 7)
                {
                    // 該当行を格納
                    mid_maintask = line;

                }

                // 検索関数が含まれていた場合
                if (line.Contains(str_funcname))
                {
                    // 戻り値に最上位タスクをセット
                    return_maintask = mid_maintask;
                }

                // 次の行へ
                line_cnt++;

            }   // while()
        }
#pragma warning disable CS0168 // 変数 'exc' は宣言されていますが、使用されていません
        catch (Exception exc)
#pragma warning restore CS0168 // 変数 'exc' は宣言されていますが、使用されていません
        {
        }
        finally
        {
            sr.Close();
            fs.Close();

        }

        return return_maintask;
    }
}