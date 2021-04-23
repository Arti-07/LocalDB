using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace LocalDB
{
    public partial class DB : Form
    {
        public DB()
        {
            InitializeComponent();
        }

        private void companyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.companyBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.localDB_DataDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'localDB_DataDataSet.Person' table. You can move, or remove it, as needed.
            this.personTableAdapter.Fill(this.localDB_DataDataSet.Person);
            // TODO: This line of code loads data into the 'localDB_DataDataSet.Company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.localDB_DataDataSet.Company);

            pieChart.LegendLocation = LegendLocation.Bottom;

        }

        
        Func<ChartPoint, string> label = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);
        private void buttonShow_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();
            foreach(var obj in localDB_DataDataSet.Person)
            {
                series.Add(new PieSeries()
                {
                    Title = obj.Firstname.ToString(),
                    Values = new ChartValues<int> {obj.Salary},
                    DataLabels = true,
                    LabelPoint=label
                });
            }
            pieChart.Series = series;
        }
    }
}
