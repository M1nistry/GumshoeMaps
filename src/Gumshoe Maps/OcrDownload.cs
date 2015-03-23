using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Gumshoe_Maps
{
    public partial class OcrDownload : Form
    {
        private WebClient _webClient;

        private readonly string _filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GumshoeMaps\tessdata\";
        public OcrDownload()
        {
            InitializeComponent();
            _webClient = new WebClient();
            _webClient.DownloadFileCompleted += _webClient_DownloadFileComplete;
            _webClient.DownloadProgressChanged += _webClient_DownloadProgressChanged;
            DownloadOcr();
            AddStatus("Downloading OCR Data...");
        }

        public void AddStatus(string text)
        {
            textBoxDownloadLog.Text += @"[" + DateTime.Now.ToShortTimeString() + @"] " + text + Environment.NewLine;
        }


        private void DownloadOcr()
        {
            var downloadUri = new Uri("http://ministry.happynuke.net/gumshoe/deploy/ocr/eng.tesseract.zip");
            Directory.CreateDirectory(_filePath);
            if (Directory.GetFiles(_filePath).Length > 0) return;
            using (_webClient)
            {
                _webClient.DownloadFileAsync(downloadUri, "eng.tesseract.zip");
            }
        }

        private void UnzipOcr()
        {
            var filePath = _filePath + @"eng.tesseract.zip";
            if (File.Exists(filePath))
            {
                AddStatus("Unzipping OCR Data...");
                ZipFile.ExtractToDirectory(filePath, _filePath);
                while (Directory.GetFiles(_filePath).Length != 10) Thread.Sleep(1000);
                AddStatus("Finished unzipping!");
                File.Delete(filePath);
                Visible = false;
                Dispose(true);
            }
        }

        private void _webClient_DownloadFileComplete(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null & e.Cancelled == false)
            {
                AddStatus("OCR Download finished!");
                File.Move(Environment.CurrentDirectory + @"\eng.tesseract.zip", _filePath + @"eng.tesseract.zip");
                UnzipOcr();
            }

        }

        private void _webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void OcrDownload_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
    }
}
