using System;
using System.Windows.Forms;
#region #usings
using DevExpress.XtraRichEdit.API.Native;
#endregion #usings

namespace BulletedListExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richEditControl1.CreateNewDocument();
            AddBulletedListToDocument();
        }
        #region #definelist
        private void AddBulletedListToDocument()
        {
            Document doc = richEditControl1.Document;
            // Define an abstract numbered list and add it to the document.
            DefineAbstractList(doc);
            // Create a numbering list. It is based on a previously defined abstract list with ID = 0.
            doc.NumberingLists.Add(0);
        }
        void DefineAbstractList(Document doc)
        {
            doc.BeginUpdate();
            //Describe the pattern used for bulleted list.
            //Specify parameters used to represent each list level.

            AbstractNumberingList list = richEditControl1.Document.AbstractNumberingLists.Add();
            list.NumberingType = NumberingType.Bullet;

            ListLevel level = list.Levels[0];
            level.ParagraphProperties.LeftIndent = 150;
            level.CharacterProperties.FontName = "Symbol";
            level.DisplayFormatString = new string('\u00B7', 1);


            level = list.Levels[1];
            level.ParagraphProperties.LeftIndent = 300;
            level.CharacterProperties.FontName = "Symbol";
            level.DisplayFormatString = new string('\u006F', 1);


            level = list.Levels[2];
            level.ParagraphProperties.LeftIndent = 450;
            level.CharacterProperties.FontName = "Symbol";
            level.DisplayFormatString = new string('\u00B7', 1);
           
            doc.EndUpdate();
        }
            #endregion #definelist

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region #setlistlevel
            // Create a bulleted list item from the selected paragraph. A list pattern with index 0 is used.
            // The list level is specified by selecting an item in a combo box.
            Document doc = richEditControl1.Document;
            if (doc.Selection != null)
            {
                int listLevel = comboBoxEdit1.SelectedIndex;
                doc.BeginUpdate();
                ReadOnlyParagraphCollection paragraphs = doc.Paragraphs.Get(doc.Selection);
                foreach (Paragraph pgf in paragraphs)
                {
                    pgf.ListIndex = 0;
                    pgf.ListLevel = listLevel;
                }
                doc.EndUpdate();
            }
            #endregion #setlistlevel
        }

        private void btnSimpleBullet_Click(object sender, EventArgs e)
        {
            Document doc = richEditControl1.Document;
            doc.BeginUpdate();
            NumberingList numberingList = doc.NumberingLists.Add(0);
            int listIndex = numberingList.Index; 
            // Append list items
            AppendListParagraph(doc, "Level0 Par0", 0, 0, listIndex);
            AppendListParagraph(doc, "Level0 Par1", 1, 0, listIndex);
            AppendListParagraph(doc, "Level0 Par2", 2, 0, listIndex);
            AppendListParagraph(doc, "Level1 Par3", 3, 1, listIndex);
            AppendListParagraph(doc, "Level1 Par4", 4, 1, listIndex);
            AppendListParagraph(doc, "Level2 Par5", 5, 2, listIndex);
            AppendListParagraph(doc, "Level2 Par6", 6, 2, listIndex);
            AppendListParagraph(doc, "Level0 Par7", 7, 0, listIndex);
            AppendListParagraph(doc, "Level1 Par8", 8, 1, listIndex);
            AppendListParagraph(doc, "Level1 Par9", 9, 1, listIndex);
            AppendListParagraph(doc, "Level0 Par10", 10, 0, listIndex);
            doc.Paragraphs.Append();
            doc.EndUpdate();
        }

        void AppendListParagraph(Document doc, string text, int paragraphIndex, int numberingLevel, int numberingIndex)
        {
            doc.AppendText(text);
            doc.Paragraphs.Append();
            Paragraph paragraph = doc.Paragraphs[paragraphIndex];
            paragraph.ListIndex = numberingIndex;
            paragraph.ListLevel = numberingLevel;
        }

    }
    }
