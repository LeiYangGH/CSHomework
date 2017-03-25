using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSKnowledge
{
    public static class DBHelper
    {
        public static void Add(string category, string txt, string imageFileName)
        {
            try
            {
                using (KnowledgeEntities en = new KnowledgeEntities())
                {
                    if (en.KBs.Any(x => x.Category == category && x.Txt == txt))
                    {
                        MessageBox.Show("文本和以前的重复，请修改后再添加!");
                        return;
                    }
                    KB kb = new KB();
                    kb.Category = category;
                    kb.Txt = txt;
                    kb.Pic = File.ReadAllBytes(imageFileName);
                    en.KBs.Add(kb);
                    en.SaveChanges();
                }
                MessageBox.Show("添加成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static KB GetKnowledge(int id)
        {
            try
            {
                using (KnowledgeEntities en = new KnowledgeEntities())
                {
                    KB kb = en.KBs.First(x => x.ID == id);
                    return kb;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public static List<string> GetCategories()
        {
            try
            {
                using (KnowledgeEntities en = new KnowledgeEntities())
                {
                    return en.KBs.Select(x => x.Category).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<string>();
            }

        }
    }
}
