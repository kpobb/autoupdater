using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Autoupdater.AutoupdaterService;

namespace Autoupdater
{
    public partial class AutoupdaterForm : Form
    {
        private readonly BackgroundWorker _backgroundWorker = new BackgroundWorker { WorkerReportsProgress = true };
        private readonly IAutoupdaterService _autoupdaterService;
        private readonly IUpdatableTool _tool;
        private readonly ZipHandler _zip = new ZipHandler();

        public AutoupdaterForm(IAutoupdaterService autoupdaterService, IUpdatableTool tool)
        {
            _autoupdaterService = autoupdaterService;
            _tool = tool;

            _backgroundWorker.DoWork +=_backgroundWorker_DoWork;
            _backgroundWorker.ProgressChanged +=_backgroundWorker_ProgressChanged;

            InitializeComponent();

            ShowDialog();
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);

                _backgroundWorker.ReportProgress(i);
            }
        }

        private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

            progress.Text = e.ProgressPercentage.ToString(CultureInfo.InvariantCulture);
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (!_backgroundWorker.IsBusy)
            {
                _backgroundWorker.RunWorkerAsync();
            }
        }
        
        private bool HasUpdate()
        {
            return _autoupdaterService.HasUpdate(_tool.Id, _tool.Version);
        }

        private void Update()
        {
            var response = _autoupdaterService.UpdateApplication(_tool.Id);

            var destDir = Path.Combine(_tool.Path, "new");

            _zip.Extract(response.File.Source, response.File.Name, destDir);

            SelfExtractor.Update(destDir, _tool.Name);

            Directory.Delete(destDir);
        }
    }
}
