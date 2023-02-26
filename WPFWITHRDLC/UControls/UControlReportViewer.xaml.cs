using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using Microsoft.Reporting.WinForms;


namespace WPFWITHRDLC.UControls
{
    /// <summary>
    /// Interaction logic for UControlReportViewer.xaml
    /// </summary>
    public partial class UControlReportViewer : UserControl
    {
        public UControlReportViewer()
        {
            InitializeComponent();
        }

        private void reportViewer_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("ID", typeof(int)));

            dt.Columns.Add(new DataColumn("Name", typeof(string)));

            dt.Columns.Add(new DataColumn("City", typeof(string)));

            dt.Columns.Add(new DataColumn("OrderAmount", typeof(int)));

            DataRow dr = dt.NewRow();

            dr["ID"] = 1;
            dr["Name"] = "Belal Hossain";
            dr["City"] = "Bangladesh";
            dr["OrderAmount"] = 500;

            dt.Rows.Add(dr);

          ReportDataSource reportDataSource = new ReportDataSource();

          reportDataSource.Name = "CustomerDataSet"; // Name of the DataSet we set in .rdlc
          reportDataSource.Value = dt;

          string RDLCFilePath = System.Windows.Forms.Application.StartupPath;
          RDLCFilePath = RDLCFilePath.Replace("\\bin\\Debug", "");
          //reportViewer.LocalReport.ReportPath = "E:\\Practice\\WPFWITHRDLC\\WPFWITHRDLC\\StudentReport.rdlc"; // Path of the rdlc file
            reportViewer.LocalReport.ReportPath = RDLCFilePath + @"\Reports\StudentReport.rdlc"; // Path of the rdlc file
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.RefreshReport();
        }
    }
}
