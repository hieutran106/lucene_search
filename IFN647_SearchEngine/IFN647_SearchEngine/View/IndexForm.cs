using IFN647_SearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lucene.Net.Documents;
using System.Diagnostics;
using System.IO;

namespace IFN647_SearchEngine
{
    public partial class IndexForm : Form
    {
        private List<JournalArticle> articles;

        private IndexSetting indexSetting;

        private LuceneSearch luceneIndex_app;

        //constructor
        public IndexForm()
        {
            InitializeComponent();
            indexSetting = new IndexSetting();
            luceneIndex_app = new LuceneSearch();
            articles = new List<JournalArticle>();

            //default path for index object and articles
            docPathLabel.Text = @"D:\IFN647_prj\crandocs";
            indexPathLabel.Text = @"D:\IFN647_prj\index";
        }

        //button click action to select path to the articles
        private void documentPathBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                docPathLabel.Text = folderBrowserDialog.SelectedPath;
            }
        }

        //button click action to select path to where the index will be saved
        private void indexPathBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                indexPathLabel.Text = folderBrowserDialog.SelectedPath;
            }
        }

        //button click action to start indexing
        private void indexBtn_Click(object sender, EventArgs e)
        {
            if (docPathLabel.Text !="" && indexPathLabel.Text !="")
            {
                string documentPath = docPathLabel.Text;
                //Read all text file in document directory
                textBox.AppendText(indexSetting.ToString());
                WalkDirectoryTree(documentPath);
                //Index
                IndexDocuments();

            } else
            {
                MessageBox.Show("Please specify document and index path.",
                "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
        }

        //function contains the actions called when indexing documents
        private void IndexDocuments()
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            //luceneSearch_app = new LuceneSearch();

            string indexPath = indexPathLabel.Text;
            luceneIndex_app.CreateIndex(indexPath);

            float coun_all = 0.0f;
            float step = (float)(100.0f / articles.Count);
            progressBar1.Visible = true;

            
            textBox.AppendText("Found " + articles.Count + " articles \r\n");
            textBox.AppendText("Start indexing ...\r\n");
            foreach (JournalArticle article in articles)
            {
                luceneIndex_app.IndexText(article);
                coun_all += step;
                progressBar1.Value = (int)coun_all;
            }
            progressBar1.Value = 100;            
            stopwatch.Stop();            
            textBox.AppendText("All documents added.\r\n");
            textBox.AppendText("The indexing lasted for " + stopwatch.ElapsedMilliseconds + "ms\r\n");
            luceneIndex_app.CleanUpIndexer();

            //auto complete

            textBox.AppendText("Start indexing autocomplete...please wait!\r\n");
            stopwatch.Restart();
            luceneIndex_app.AutoCompleteInit();
            stopwatch.Stop();
            textBox.AppendText("The indexing autocomplete lasted for " + stopwatch.ElapsedMilliseconds + "ms\r\n");
            // Load WordNet dataset
            textBox.AppendText("Loading WordNet database...please wait!\r\n");
            luceneIndex_app.WordNetInit();

            textBox.AppendText("Please click Start button to start searching");
            nextBtn.Enabled = true;
            nextBtn.Visible = true;
        }

        //function to traverse through the directory path and find article files
        private void WalkDirectoryTree(String path)
        {
            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(path);
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder 
            try
            {
                files = root.GetFiles("*.txt");
            }

            catch (UnauthorizedAccessException e)
            {
                System.Console.WriteLine(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    string name = fi.FullName;
                    JournalArticle journalArticle = new JournalArticle(name);
                    articles.Add(journalArticle);
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    string name = dirInfo.FullName;
                    WalkDirectoryTree(name);
                }
            }
        }

        //button click action to show the main search form
        private void nextBtn_Click(object sender, EventArgs e)
        {
            luceneIndex_app.SetupSearch();
            SearchCore mainForm = new SearchCore(luceneIndex_app,articles);
            mainForm.Show();
            this.Close();
        }
        
    }
}
