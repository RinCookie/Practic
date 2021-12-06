using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace Clinica___
{
    class Report
    {
        Word.Application app = new Word.Application();
        Word.Document doc;

        ~Report()
        {
            doc.Saved = true;
            
        }
            public void JournalGen(IList<Journal> Journal)
            {
                if (Journal != null)
                {
                    doc = app.Documents.Add(Template: $@"E:\Практика 48каб\Clinica-_-\Clinica-_-\Templates\Журнал.docx", Visible: true);

                    Word.Range dateTime = doc.Bookmarks["DateTime"].Range;
                    dateTime.Text = DateTime.Now.ToString();

                    Word.Table table = doc.Bookmarks["Table"].Range.Tables[1];
                    int currPage = 1;
                    foreach (var item in Journal)
                    {
                        int page = doc.ComputeStatistics(Word.WdStatistic.wdStatisticPages);

                        Word.Row row = table.Rows.Add();
                        if (page > currPage) //Если запись не влазеет на текущею страницу
                        {
                            row.Range.InsertBreak();
                            table = doc.Tables[doc.Tables.Count];

                            doc.Tables[1].Rows[1].Range.Copy();
                            row.Range.Paste();
                            table.Rows[2].Delete(); //Удаляем пустую строку после заголовка

                            currPage = page;
                            row = table.Rows.Add();
                        }

                        row.Cells[1].Range.Text = item.Patient.Name;
                        row.Cells[2].Range.Text = item.Diagnosis.Name;
                        row.Cells[3].Range.Text = item.Doctor.Name;
                        row.Cells[4].Range.Text = item.Adress.Name;
                    }
                    doc.Bookmarks["Table"].Range.Tables[1].Rows[2].Delete(); //Удаляем строку [текст] [текст] [текст] [текст] в таблице

                    app.Visible = true;
                }
            }
        }
    }
    

