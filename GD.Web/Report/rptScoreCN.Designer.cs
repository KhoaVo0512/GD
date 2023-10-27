namespace GD.Web.Report
{
    partial class rptScoreCN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lbManageBy = new DevExpress.XtraReports.UI.XRLabel();
            this.lbSchool = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTitleScore = new DevExpress.XtraReports.UI.XRLabel();
            this.lbPrintDate = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNameHK = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCourse = new DevExpress.XtraReports.UI.XRLabel();
            this.lbGrade = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellSTT = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellCode = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellFullName = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellBirthDay = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellDTBHKI = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellDTBHKII = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellDTBCN = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 35F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 38F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.lbManageBy,
            this.lbSchool,
            this.lbTitleScore,
            this.lbPrintDate,
            this.lbNameHK,
            this.lbCourse,
            this.lbGrade});
            this.ReportHeader.HeightF = 242.5F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lbManageBy
            // 
            this.lbManageBy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbManageBy.LocationFloat = new DevExpress.Utils.PointFloat(42.5832F, 25.83336F);
            this.lbManageBy.Multiline = true;
            this.lbManageBy.Name = "lbManageBy";
            this.lbManageBy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbManageBy.SizeF = new System.Drawing.SizeF(463.6667F, 23F);
            this.lbManageBy.StylePriority.UseFont = false;
            this.lbManageBy.StylePriority.UseTextAlignment = false;
            this.lbManageBy.Text = "BỘ GIÁO DỤC VÀ ĐÀO TẠO";
            this.lbManageBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbSchool
            // 
            this.lbSchool.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbSchool.LocationFloat = new DevExpress.Utils.PointFloat(42.5832F, 48.83336F);
            this.lbSchool.Multiline = true;
            this.lbSchool.Name = "lbSchool";
            this.lbSchool.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbSchool.SizeF = new System.Drawing.SizeF(463.6667F, 23F);
            this.lbSchool.StylePriority.UseFont = false;
            this.lbSchool.StylePriority.UseTextAlignment = false;
            this.lbSchool.Text = "TRƯỜNG ABC";
            this.lbSchool.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbTitleScore
            // 
            this.lbTitleScore.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.lbTitleScore.LocationFloat = new DevExpress.Utils.PointFloat(300.4168F, 127.9167F);
            this.lbTitleScore.Multiline = true;
            this.lbTitleScore.Name = "lbTitleScore";
            this.lbTitleScore.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTitleScore.SizeF = new System.Drawing.SizeF(422.0834F, 23.00001F);
            this.lbTitleScore.StylePriority.UseFont = false;
            this.lbTitleScore.StylePriority.UseTextAlignment = false;
            this.lbTitleScore.Text = "BẢNG ĐIỂM HỌC TẬP";
            this.lbTitleScore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbPrintDate
            // 
            this.lbPrintDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic);
            this.lbPrintDate.LocationFloat = new DevExpress.Utils.PointFloat(300.4168F, 150.9167F);
            this.lbPrintDate.Multiline = true;
            this.lbPrintDate.Name = "lbPrintDate";
            this.lbPrintDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbPrintDate.SizeF = new System.Drawing.SizeF(422.0834F, 23F);
            this.lbPrintDate.StylePriority.UseFont = false;
            this.lbPrintDate.StylePriority.UseTextAlignment = false;
            this.lbPrintDate.Text = "lbPrintDate";
            this.lbPrintDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbNameHK
            // 
            this.lbNameHK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbNameHK.LocationFloat = new DevExpress.Utils.PointFloat(600.4166F, 25.83333F);
            this.lbNameHK.Multiline = true;
            this.lbNameHK.Name = "lbNameHK";
            this.lbNameHK.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNameHK.SizeF = new System.Drawing.SizeF(399.5834F, 23F);
            this.lbNameHK.StylePriority.UseFont = false;
            this.lbNameHK.StylePriority.UseTextAlignment = false;
            this.lbNameHK.Text = "KẾT QUẢ HỌC TẬP HỌC KỲ";
            this.lbNameHK.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbCourse
            // 
            this.lbCourse.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbCourse.LocationFloat = new DevExpress.Utils.PointFloat(600.4166F, 48.83336F);
            this.lbCourse.Multiline = true;
            this.lbCourse.Name = "lbCourse";
            this.lbCourse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCourse.SizeF = new System.Drawing.SizeF(399.5834F, 23F);
            this.lbCourse.StylePriority.UseFont = false;
            this.lbCourse.StylePriority.UseTextAlignment = false;
            this.lbCourse.Text = "Môn học:";
            this.lbCourse.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbGrade
            // 
            this.lbGrade.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbGrade.LocationFloat = new DevExpress.Utils.PointFloat(600.4166F, 71.83334F);
            this.lbGrade.Multiline = true;
            this.lbGrade.Name = "lbGrade";
            this.lbGrade.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbGrade.SizeF = new System.Drawing.SizeF(399.5834F, 23F);
            this.lbGrade.StylePriority.UseFont = false;
            this.lbGrade.StylePriority.UseTextAlignment = false;
            this.lbGrade.Text = "Lớp:";
            this.lbGrade.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 217.5F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1111F, 25F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "STT";
            this.xrTableCell1.Weight = 0.45977554107180707D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Mã";
            this.xrTableCell2.Weight = 0.90996278168666667D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "Họ tên";
            this.xrTableCell3.Weight = 1.6302616772415259D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "Ngày sinh";
            this.xrTableCell4.Weight = 1D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "ĐTB HKI";
            this.xrTableCell5.Weight = 1D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "ĐTB HKII";
            this.xrTableCell6.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.Text = "ĐTB CN";
            this.xrTableCell7.Weight = 1D;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1111F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellSTT,
            this.cellCode,
            this.cellFullName,
            this.cellBirthDay,
            this.cellDTBHKI,
            this.cellDTBHKII,
            this.cellDTBCN});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // cellSTT
            // 
            this.cellSTT.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRecordNumber()")});
            this.cellSTT.Multiline = true;
            this.cellSTT.Name = "cellSTT";
            this.cellSTT.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.cellSTT.Summary = xrSummary1;
            this.cellSTT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cellSTT.Weight = 0.4597755910304242D;
            // 
            // cellCode
            // 
            this.cellCode.Multiline = true;
            this.cellCode.Name = "cellCode";
            this.cellCode.Text = "cellCode";
            this.cellCode.Weight = 0.90996278168666689D;
            // 
            // cellFullName
            // 
            this.cellFullName.Multiline = true;
            this.cellFullName.Name = "cellFullName";
            this.cellFullName.Text = "cellFullName";
            this.cellFullName.Weight = 1.6302616272829089D;
            // 
            // cellBirthDay
            // 
            this.cellBirthDay.Multiline = true;
            this.cellBirthDay.Name = "cellBirthDay";
            this.cellBirthDay.StylePriority.UseTextAlignment = false;
            this.cellBirthDay.Text = "cellBirthDay";
            this.cellBirthDay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cellBirthDay.Weight = 1D;
            // 
            // cellDTBHKI
            // 
            this.cellDTBHKI.Multiline = true;
            this.cellDTBHKI.Name = "cellDTBHKI";
            this.cellDTBHKI.StylePriority.UseTextAlignment = false;
            this.cellDTBHKI.Text = "cellDTBHKI";
            this.cellDTBHKI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cellDTBHKI.Weight = 1D;
            // 
            // cellDTBHKII
            // 
            this.cellDTBHKII.Multiline = true;
            this.cellDTBHKII.Name = "cellDTBHKII";
            this.cellDTBHKII.StylePriority.UseTextAlignment = false;
            this.cellDTBHKII.Text = "cellDTBHKII";
            this.cellDTBHKII.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cellDTBHKII.Weight = 1D;
            // 
            // cellDTBCN
            // 
            this.cellDTBCN.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.cellDTBCN.Multiline = true;
            this.cellDTBCN.Name = "cellDTBCN";
            this.cellDTBCN.StylePriority.UseBorders = false;
            this.cellDTBCN.StylePriority.UseTextAlignment = false;
            this.cellDTBCN.Text = "cellDTBCN";
            this.cellDTBCN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cellDTBCN.Weight = 1D;
            // 
            // rptScoreCN
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader,
            this.ReportFooter});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(29, 29, 35, 38);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "20.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel lbManageBy;
        private DevExpress.XtraReports.UI.XRLabel lbSchool;
        private DevExpress.XtraReports.UI.XRLabel lbTitleScore;
        private DevExpress.XtraReports.UI.XRLabel lbPrintDate;
        private DevExpress.XtraReports.UI.XRLabel lbNameHK;
        private DevExpress.XtraReports.UI.XRLabel lbCourse;
        private DevExpress.XtraReports.UI.XRLabel lbGrade;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell cellSTT;
        private DevExpress.XtraReports.UI.XRTableCell cellCode;
        private DevExpress.XtraReports.UI.XRTableCell cellFullName;
        private DevExpress.XtraReports.UI.XRTableCell cellBirthDay;
        private DevExpress.XtraReports.UI.XRTableCell cellDTBHKI;
        private DevExpress.XtraReports.UI.XRTableCell cellDTBHKII;
        private DevExpress.XtraReports.UI.XRTableCell cellDTBCN;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
    }
}
