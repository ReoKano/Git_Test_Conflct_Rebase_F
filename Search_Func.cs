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
//===================================================

public class Search
{

    //===================================================
    // ファイル内の関数検索
    //===================================================
    static string Search_maintask_inTxt(string path, string func)
    {
        string file_path = path;
        string func_name = func;
        string mid_maintask = Str_undetermined;
        string return_maintask = Str_undetermined;
        int line_cnt = 1;

        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
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
                if (line.Contains(func))
                {
                    // 戻り値に最上位タスクをセット
                    return_maintask = mid_maintask;
                }

                line_cnt++;

            }
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