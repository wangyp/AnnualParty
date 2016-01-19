using System;
using System.Collections.Generic;
using System.Text;

namespace AnnualPartyAdmin
{
    class Pinyin
    {
        public Pinyin()
        {
            var lines = AnnualPartyAdmin.Properties.Resources.SinglePinYin.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            pinyinDic = new Dictionary<char, string>();
            foreach (string line in lines)
            {
                char key = line.Split(',')[0][0];
                string py = line.Split(',')[1];
                pinyinDic.Add(key, py);
            }
        }

        private Dictionary<char, string> pinyinDic;
        public string GetPinyinShort(string name)
        {
            string py = "";
            if (name.Length > 5)
            {
                return "";
            }
            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];
                string p = pinyinDic[c];
                py += p[0];
            }
            return py;
        }
    }
}
