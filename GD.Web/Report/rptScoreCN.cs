using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using GD.Web.Models;
using System.Collections.Generic;

namespace GD.Web.Report
{
    public partial class rptScoreCN : DevExpress.XtraReports.UI.XtraReport
    {
        public rptScoreCN()
        {
            InitializeComponent();
        }

        List<ScoreViewModel> datasource;

        public rptScoreCN(List<ScoreViewModel> _datasource, string manageBy, string schoolName, string course, string grade)
        {
            datasource = _datasource;

            InitializeComponent();

            lbManageBy.Text = manageBy.ToUpper();
            lbSchool.Text = schoolName.ToUpper();

            lbPrintDate.Text = "(In ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString() + ")";

            if (_datasource[0].Type == 1)
            {
                lbNameHK.Text = "KẾT QUẢ HỌC TẬP HỌC KỲ I";
            }
            else if (_datasource[0].Type == 2)
            {
                lbNameHK.Text = "KẾT QUẢ HỌC TẬP HỌC KỲ II";
            }
            else
            {
                lbNameHK.Text = "KẾT QUẢ HỌC TẬP CẢ NĂM";
            }

            lbCourse.Text = "Môn học: " + course;
            lbGrade.Text = grade;

            BindData();
        }

        private void BindData()
        {
            cellCode.DataBindings.Add(new XRBinding("Text", null, "Code"));
            cellFullName.DataBindings.Add(new XRBinding("Text", null, "FullName"));
            cellBirthDay.DataBindings.Add(new XRBinding("Text", null, "BirthDayText"));
            cellDTBHKI.DataBindings.Add(new XRBinding("Text", null, "PointDDGGK"));
            cellDTBHKII.DataBindings.Add(new XRBinding("Text", null, "PointDDGCK"));
            cellDTBCN.DataBindings.Add(new XRBinding("Text", null, "PointDTBMHK"));

            DataSource = datasource;
        }
    }
}
