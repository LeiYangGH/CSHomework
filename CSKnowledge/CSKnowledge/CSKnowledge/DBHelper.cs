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

        public static bool Update(int id, string category, string txt, string imageFileName)
        {
            try
            {
                using (KnowledgeEntities en = new KnowledgeEntities())
                {
                    KB kb = en.KBs.First(x => x.ID == id);
                    kb.Category = category;
                    kb.Txt = txt;
                    if (!string.IsNullOrWhiteSpace(imageFileName))
                        kb.Pic = File.ReadAllBytes(imageFileName);
                    en.SaveChanges();
                }
                MessageBox.Show("修改成功！");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
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

        public static List<string> GetTxtUnderCategory(string category)
        {
            try
            {
                using (KnowledgeEntities en = new KnowledgeEntities())
                {
                    return en.KBs.Where(x => x.Category == category).Select(x => x.Txt).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<string>();
            }

        }

        public static KB GetKBByTxt(string txt)
        {
            try
            {
                using (KnowledgeEntities en = new KnowledgeEntities())
                {
                    return en.KBs.First(x => x.Txt == txt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public static bool DeleteKBById(int id)
        {
            try
            {
                using (KnowledgeEntities en = new KnowledgeEntities())
                {
                    KB kb = en.KBs.First(x => x.ID == id);
                    en.KBs.Remove(kb);
                    en.SaveChanges();
                }
                MessageBox.Show("删除成功");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
    }
}
