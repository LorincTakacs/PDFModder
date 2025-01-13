using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Drawing;
using static System.Windows.Forms.LinkLabel;
using UglyToad.PdfPig.Core;

namespace PDFAddLinksDynamically
{
    static class Globals
    {
        public static string URL { get; set; }
        public static string SELECTEDFILE { get; set; }


        public static string ChooseFile()
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.RestoreDirectory = true;
                fileDialog.Filter = "PDF (*.pdf)|*.pdf";
                fileDialog.Title = "Select a PDF File";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    SELECTEDFILE = fileDialog.FileName;
                }
            }            

            return SELECTEDFILE;

        }

        public static Dictionary<int, List<string>> ExtractText(string filePath)
        {
            var textByPage = new Dictionary<int, List<string>>();

            using (UglyToad.PdfPig.PdfDocument document = UglyToad.PdfPig.PdfDocument.Open(filePath))
            {
                foreach (Page page in document.GetPages())
                {
                    int pageNumber = page.Number;
                    string pageText = page.Text;
                    
                    var words = pageText.Split(' ');
                    
                    textByPage[pageNumber] = new List<string>(words);
                }
            }

            return textByPage;
        }

        public static async void AddHyperLinks(string inputPath, string searchText, Dictionary<int, List<string>> textByPage)
        {            
            PdfSharp.Pdf.PdfDocument document = PdfReader.Open(inputPath, PdfDocumentOpenMode.Modify);
            
            for (int i = 0; i < document.PageCount; i++)
            {
                PdfPage page = document.Pages[i];

                var content = textByPage[i + 1];                
                
                XGraphics gfx = XGraphics.FromPdfPage(page);
                
                for (int j = 0; j < content.Count; j++)
                {
                    
                    if (content[j].Contains(searchText))
                    {
                        UglyToad.PdfPig.Core.PdfRectangle boundingBox = (UglyToad.PdfPig.Core.PdfRectangle) GetCoordinates(inputPath, searchText);

                        XFont fontNormal = new XFont("Arial", 16);
                        //TODO: I should calc the size of the box dynamically to the size of the text
                        var xrect = new XRect(boundingBox.Left+50/*X*/, (((int)page.Height - boundingBox.TopLeft.Y) - 25 + boundingBox.Height*0.5)/*Y*/, 80, 30); //TODO: x-y should be dynamic for the button
                        
                        gfx.DrawRectangle(XBrushes.Transparent, xrect); //The box itself, like a div
                        
                        gfx.DrawString("Irány a Shop!", fontNormal, XBrushes.Black, xrect, XStringFormats.Center); //The btn text
                        
                        var rect = gfx.Transformer.WorldToDefaultPage(xrect);

                        var pdfrect = new PdfSharp.Pdf.PdfRectangle(rect);
                        
                        page.AddWebLink(pdfrect, URL + "/" + searchText);
                    }
                }

            }

            document.Save(inputPath); //TODO: optimize, cuz this its gonna save as many times as it generates a button.
        }

        public static UglyToad.PdfPig.Core.PdfRectangle? GetCoordinates(string inputPath, string searchText)
        {
            using (var pdfDoc = UglyToad.PdfPig.PdfDocument.Open(inputPath))
            {
                foreach (var page in pdfDoc.GetPages())
                {
                    var words = page.GetWords();

                    foreach (var word in words)
                    {
                        if (word.Text.Contains(searchText))
                        {
                            return word.BoundingBox;
                        }
                    }
                }
            }
            return null;
        }

    }
}
