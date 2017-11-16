using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFN647_SearchEngine
{
    public partial class Abs_view_f : Form
    {
        public Abs_view_f(JournalArticle article)
        {
            //Initialize new form to display suitable document
            InitializeComponent();   
            //Load form components and data
            this.Text = "Abstract View - DocID: " + article.ID;          
            AV_title.Text = "Title: " + article.Title + "\n";
            AV_author.Text = "Author: " + article.Author + "\n";
            AV_abs.Text = "Abstract:\n" + article.Words + "\n";
          

        }
    }
}
