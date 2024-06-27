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
// �X�V����
//===================================================
// 2024/06/27 : 012020048D : �V�K�ǉ�
//===================================================

public class Search
{

    //===================================================
    // �t�@�C�����̊֐�����
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
            // �����܂�
            while (sr.EndOfStream == false)
            {
                // 1�s�ǂݏo��
                string line = sr.ReadLine();

                // 7�s�ځi�ŏ�ʃ^�X�N�j�̏ꍇ
                if (line_cnt == 7)
                {
                    // �Y���s���i�[
                    mid_maintask = line;

                }

                // �����֐����܂܂�Ă����ꍇ
                if (line.Contains(func))
                {
                    // �߂�l�ɍŏ�ʃ^�X�N���Z�b�g
                    return_maintask = mid_maintask;
                }

                line_cnt++;

            }
        }
#pragma warning disable CS0168 // �ϐ� 'exc' �͐錾����Ă��܂����A�g�p����Ă��܂���
        catch (Exception exc)
#pragma warning restore CS0168 // �ϐ� 'exc' �͐錾����Ă��܂����A�g�p����Ă��܂���
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