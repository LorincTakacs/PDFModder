using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFAddLinksDynamically
{
    public partial class Form1 : Form
    {
        public Ui ui { get; set; }

        public Form1()
        {
            InitializeComponent();
            ui = new Ui(this);

            Globals.URL = "https://www.youtube.com/results?search_query=";
            defaultUrlText.Text = Globals.URL;

            ui.SetSysMessage("Program használatra készen áll");
        }

        private void startBtn_Click(object sender, EventArgs e) => Main();

        private async Task Main()
        {
            try
            {
                string file = Globals.ChooseFile(); //await Task.Run(() => Globals.ChooseFile());

                if (string.IsNullOrEmpty(file))
                {
                    throw new Exception("Nem választott fájlt");
                }

                var textByPage = await Task.Run(() => Globals.ExtractText(file));

                List<string> searchTextTestArr = new List<string>{"G11294", "G07013" };//TODO: This is just atest string im lookin for so far

                foreach (string searchTextTest in searchTextTestArr)
                {
                    await Task.Run(() => Globals.AddHyperLinks(file, searchTextTest, textByPage));
                }                

                ui.SetSysMessage("Pacek!");

            }
            catch (Exception ex)
            {
                ui.SetSysMessage(ex.Message);
            }
        }
    }
}
