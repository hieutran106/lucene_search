using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFN647_SearchEngine
{
    public partial class SearchCore : Form
        /*Main class to handle search GUI and display result.*/
    {   

        class FieldSelectItem
        {
            public String Name { get; set; }
            
            public FieldSelectItem(String Name)
            {
                this.Name = Name;
            }

            public override string ToString()
            {
                return Name;
            }

        }

        public LuceneSearch LuceneSearch_app { get; private set; }
        public List<JournalArticle> Articles { get; private set; }
        private int currentPage;
        private int totalPage;
        private string[] delim = { " .  ", " !  ", " ?  ", " .\n", " !\n", " ?\n" };
        private string S_query_ori = "Search Query: ";
        private PorterStemmer stemmer = new PorterStemmer();

        //Field Select
        const string FIELD_ALL = "All";
        const string FIELD_TITLE = LuceneSearch.TITLE_FN;
        const string FIELD_AUTHOR = LuceneSearch.AUTHOR_FN;
        const string FIELD_BILI = LuceneSearch.BILI_FN;
        const string FIELD_WORD = LuceneSearch.WORD_FN;

        public SearchCore(LuceneSearch luceneSearch, List<JournalArticle> articles)
            /*Main constructor for the search form*/
        {
            //Initialize components for search form
            InitializeComponent();
            LuceneSearch_app = luceneSearch;
            Articles = articles;
            search_query.Visible = false;

            //Initialize SearchFieldCB
            SearchFieldCB.Items.Add(new FieldSelectItem(FIELD_ALL));
            SearchFieldCB.Items.Add(new FieldSelectItem(FIELD_TITLE));
            SearchFieldCB.Items.Add(new FieldSelectItem(FIELD_AUTHOR));
            SearchFieldCB.Items.Add(new FieldSelectItem(FIELD_BILI));
            SearchFieldCB.Items.Add(new FieldSelectItem(FIELD_WORD));
            SearchFieldCB.SelectedIndex = 0;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
            /*Exit when closing new*/
        {
            Application.Exit();
        }

        private void search_btn_Click(object sender, EventArgs e)
            /*Handle the event when clicking search button
             Search main routine*/
        {
            dataGridView.Rows.Clear();
            search_query.Visible = true;
            if (string.IsNullOrEmpty(search_input.Text))
            {
                next_button.Enabled = false;
                LastButton.Enabled = false;
                SearchTimeLabel.Visible = false;
                page_label.Visible = false;
                search_query.Text = "> Status: Please input a query";
                return;
            }
            string query = search_input.Text;
            Stopwatch stopwatch = Stopwatch.StartNew();
            if (!Skip_process.Checked)
            {
                query = PreProcessQuery(query);
            }
            if (string.IsNullOrEmpty(query.Trim()))
            {
                next_button.Enabled = false;
                LastButton.Enabled = false;
                SearchTimeLabel.Visible = false;
                page_label.Visible = false;
                search_query.Text = "> Status: All of input is filtered by pre-processsing";
                return;
            }
            search_query.Text = S_query_ori + "\n" + query;
            totalPage = LuceneSearch_app.Search(query, SearchFieldCB.SelectedItem.ToString());
            if (totalPage == 0)
            {
                currentPage = 0;
                prev_button.Enabled = false;
                next_button.Enabled = false;
                FirstButton.Enabled = false;
                LastButton.Enabled = false;
            }
            else
            {
                currentPage = 1;
                prev_button.Enabled = false;
                next_button.Enabled = false;
                LastButton.Enabled = false;
                FirstButton.Enabled = false;
                if (totalPage > 1)
                {
                    next_button.Enabled = true;
                    LastButton.Enabled = true;
                }
                ShowResults(currentPage);
            }
            stopwatch.Stop();
            SearchTimeLabel.Text = string.Format("Found {0} result(s) in about {1}ms",
                LuceneSearch_app.ScoreDocs.Length, stopwatch.ElapsedMilliseconds);
            SearchTimeLabel.Visible = true;
            UpdatePageLabel();
        }

        private void ShowResults(int index)
            /*Put the search result into data grid area*/
        {
            List<string[]> results = LuceneSearch_app.GetResultCollection(index);
            dataGridView.Rows.Clear();
            foreach (string[] item in results)
            {
                item[4] = getFirstSentence(item[4]);
                dataGridView.Rows.Add(item);
            }
        }

        private string getFirstSentence(string input)
            /*Get the first sentence of the abstract to display into the result field*/
        {
            string[] sentences = input.Split(delim, 2, StringSplitOptions.RemoveEmptyEntries);
            return sentences[0];
        }

        private void UpdatePageLabel()
            /*Update the page label in main search form*/
        {
            page_label.Visible = true;
            page_label.Text = "Page: " + currentPage + " / " + totalPage;
        }

        private string PreProcessQuery(string query)
            /*Enable Preprocess function including Stop word removal and Query Expansion*/
        {
            //pre-process algorithm here
            string result = RemoveStopWords(query);
            if(QueryExpandCB.Checked)
            {
                result = QueryExpansion(result);
            }
            return result;
        }

        //FUNCTIONS TO CONVERT INFORMATION NEEDS TO QUERY
        private string RemoveStopWords(string input)
            /*Remove the stop word from the input query string*/
        {
            string result = LuceneSearch_app.GetProcessedQueryText(input, true);
            return result;
        }

        private string QueryExpansion(string input)
            /*Expand the query from original word to synonym word list based on WORDNET library*/
        {
            string[] delim = { " " };
            string[] words = input.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            Regex rgx = new Regex("[^a-zA-z]");
            string result = input;

            foreach (string word in words)
            {

                //get expansion here
                List<string> synonyms = LuceneSearch_app.GetSynonym(stemmer.stemTerm(rgx.Replace(word, "")));
                string temp = "";

                foreach (string synonym in synonyms)
                {
                    temp += " " + synonym;
                }

                if (word.StartsWith("\""))
                {
                    result += temp;
                }
                else
                {
                    result = result.Replace(word, (word + "^10" + temp));
                }

            }

        
            return result;
        }

        private void prev_button_Click(object sender, EventArgs e)
            /*Handle event when cliking Previous button*/
        {
            currentPage--;
            if (currentPage == 1)
            {
                prev_button.Enabled = false;
                FirstButton.Enabled = false;
            }
            next_button.Enabled = true;
            LastButton.Enabled = true;

            ShowResults(currentPage);
            UpdatePageLabel();
        }

        private void next_button_Click(object sender, EventArgs e)
            /*Handle event when cliking Next button*/
        {
            currentPage++;
            if (currentPage == totalPage)
            {
                next_button.Enabled = false;
                LastButton.Enabled = false;
            }
            prev_button.Enabled = true;
            FirstButton.Enabled = true;

            ShowResults(currentPage);
            UpdatePageLabel();
        }

        private void FirstButton_Click(object sender, EventArgs e)
            /*Handle event when cliking First button*/
        {
            currentPage = 1;
            FirstButton.Enabled = false;
            prev_button.Enabled = false;
            next_button.Enabled = true;
            LastButton.Enabled = true;

            ShowResults(currentPage);
            UpdatePageLabel();
        }

        private void LastButton_Click(object sender, EventArgs e)
            /*Handle event when cliking Last button*/
        {
            currentPage = totalPage;
            FirstButton.Enabled = true;
            prev_button.Enabled = true;
            next_button.Enabled = false;
            LastButton.Enabled = false;

            ShowResults(currentPage);
            UpdatePageLabel();
        }

        public JournalArticle GetArticle(string DocID)
            /*
             */
        {
            JournalArticle result = null;
            for (int i = 0; i < Articles.Count; i++)
            {
                JournalArticle article = Articles[i];
                if (article.ID == DocID)
                {
                    result = article;
                    break;
                }
            }
            return result;
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
            /* Handle event when clicking a data row -> click an search result.
             */
        {
            //
            Size Limit_size = SystemInformation.MaxWindowTrackSize;
            if (e.RowIndex != -1)
            {
                string doc_id = dataGridView.Rows[e.RowIndex].Cells["DOCID"].FormattedValue.ToString();
                Abs_view_f abs_View = new Abs_view_f(GetArticle(doc_id));

                Limit_size.Height -= 100;

                if (abs_View.Height > Limit_size.Height)
                {
                    abs_View.MaximumSize = Limit_size;
                    abs_View.AV_tableLayout.MaximumSize = Limit_size;
                    Limit_size.Width = abs_View.Width;
                    Limit_size.Height -= 10;
                    abs_View.Size = Limit_size;

                    abs_View.AutoSize = false;
                    abs_View.AV_tableLayout.AutoSize = false;
                    abs_View.AV_tableLayout.AutoScroll = true;

                    abs_View.AV_tableLayout.Height = Limit_size.Height - 50;
                    abs_View.AV_tableLayout.Width += 50;

                }
                abs_View.Show();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EduSearch IR\r\n\r\n Students:\r\nManh Tuan Nguyen\r\nLe Minh Tri Phan\r\nTrung Hieu Tran",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
        }

        private void saveBtn_Click(object sender, EventArgs e)
            /*Event trigger when Save button is clicked
             Save the result of query into a text file. require a querry ID is input into querry ID text box
             It will append into an existing file or create a new file is given name is not available*/
        {
            int queryId;
            //Parse the query ID from query text box
            bool result = Int32.TryParse(queryIdLabel.Text, out queryId);
            if (result)
            {
                //result is an integer number then check if there is valid search result
                if (LuceneSearch_app.ScoreDocs != null & LuceneSearch_app.ScoreDocs.Length > 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    //Identify file extension filter
                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    saveFileDialog1.OverwritePrompt = false;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //save file with given queryID
                        string path = saveFileDialog1.FileName;
                        LuceneSearch_app.AppendSearchResult(path, queryId);
                    }
                }

            }
            else
            {
                //show warning if no suitable query ID provided.
                MessageBox.Show("Please enter query identification",
               "About",
               MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation,
               MessageBoxDefaultButton.Button1);
            }
        }

        private void search_input_TextChanged(object sender, EventArgs e)
            /*Event trigger when a text input into search text box
             * Used to catch the word from input string and call suggestion feature*/
        {

            //Identify the start position of latest word in search text box
            int wordEndPosition = search_input.SelectionStart;
            int currentPosition = wordEndPosition;

            while (currentPosition > 0 && search_input.Text[currentPosition - 1] != ' ')
            {
                currentPosition--;
            }

            //Read out the last word
            string word = search_input.Text.Substring(currentPosition, wordEndPosition - currentPosition);

            //Process if the read word is not whitespace/null and is more than 2 characters.
            if (!String.IsNullOrWhiteSpace(word) && (word.Length > 2))
            {
                //Get the suggest word(s) from the original word
                string[] suggestword = LuceneSearch_app.AutoCompleteSuggestion(word);
                //Fit 3 words at most into the suggest word labels
                switch (suggestword.Length)
                {
                    case 1:
                        autoText1.Text = suggestword[0];
                        autoText1.Visible = true;
                        SpellCheckLabel.Visible = true;
                        break;
                    case 2:
                        autoText1.Text = suggestword[0];
                        autoText1.Visible = true;
                        autoText2.Text = suggestword[1];
                        autoText2.Visible = true;
                        SpellCheckLabel.Visible = true;
                        break;
                    case 3:
                        autoText1.Text = suggestword[0];
                        autoText1.Visible = true;
                        autoText2.Text = suggestword[1];
                        autoText2.Visible = true;
                        autoText3.Text = suggestword[2];
                        autoText3.Visible = true;
                        SpellCheckLabel.Visible = true;
                        break;
                    default:
                        break;
                }

            }
            else
            {
                //Disable all labels when there is nothing to suggest.
                autoText1.Visible = false;
                autoText2.Visible = false;
                autoText3.Visible = false;
                autoText1.Text = null;
                SpellCheckLabel.Visible = false;
                search_query.Visible = false;
            }

        }

        private void search_input_Leave(object sender, EventArgs e)
            /* Disable Suggest word when input search text box is no more focus */
        {
            autoText1.Visible = false;
            autoText2.Visible = false;
            autoText3.Visible = false;
            SpellCheckLabel.Visible = false;
        }

        private void AutoText_Clicked(object sender, EventArgs e)
            /* Handle the event when click into a suggested word, shared between 3 words.*/
        {
            //Identify the start position of latest word in search text box
            int wordEndPosition = search_input.SelectionStart;
            int currentPosition = 0;

            if (wordEndPosition > 2)
            {
                currentPosition = wordEndPosition - 1;
                while (currentPosition > 0 && search_input.Text[currentPosition - 1] != ' ')
                {
                    currentPosition--;
                }
            }
            //Read the string inside search text box except latest word
            string word = search_input.Text.Substring(0, currentPosition);
            //Read which suggestion word is clicked and append it into the string
            Label thisLabel = (Label)sender;
            search_input.Text = word + thisLabel.Text + " ";

            //Set the cursor pointer to the end of the string for continue input
            search_input.Focus();
            search_input.SelectionStart = Math.Max(0, search_input.Text.Length);
            search_input.SelectionLength = 0;
        }

        private void search_input_KeyPress(object sender, KeyPressEventArgs e)
        /*Event trigger by key press in search input text box
            Prevent the tab key become tab cursor in search text box*/
        {
            if (e.KeyChar == '\t' || e.KeyChar == (char)13)
            {
                e.Handled = true;
            }
        }

        private void search_input_KeyDown(object sender, KeyEventArgs e)
        /*Event trigger by key press down in search input text box
         Used to input the first suggested word into search text box by the Tab key*/
        {
            //Tab Key is press and there is a suggestion word.
            if (e.KeyCode == Keys.Tab && !String.IsNullOrWhiteSpace(autoText1.Text))
            {
                //Identify the start position of latest word in search text box
                int wordEndPosition = search_input.SelectionStart;
                int currentPosition = 0;

                if (wordEndPosition > 2)
                {
                    currentPosition = wordEndPosition - 1;
                    while (currentPosition > 0 && search_input.Text[currentPosition - 1] != ' ')
                    {
                        currentPosition--;
                    }
                }
                //Read the string inside search text box except latest word
                string word = search_input.Text.Substring(0, currentPosition);
                
                //Combine the string with 1st suggest word
                search_input.Text = word + autoText1.Text;

                //Set the cursor pointer to the end of the string for continue input
                search_input.SelectionLength = 0;
                search_input.SelectionStart = search_input.Text.Length; 
            }
        }

        private void Skip_process_CheckedChanged(object sender, EventArgs e)
        /*Event trigger when changing the status of Skip Processing Check Box
         Control the Query Expansion check box */
        {
            if(Skip_process.Checked)
            {
                //Disable and Unchecked Query Expansion check box
                QueryExpandCB.Checked = false;
                QueryExpandCB.Enabled = false;
            }
            else
            {
                //Enable Query Expansion Check box
                QueryExpandCB.Enabled = true;
            }
        }
    }
}
