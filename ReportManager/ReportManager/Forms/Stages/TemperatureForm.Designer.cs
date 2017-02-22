using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace ReportManager.Forms.Stages
{
    partial class TemperatureForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemperatureForm));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY1 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY2 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY3 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView3 = new DevExpress.XtraCharts.SplineSeriesView();
            this.tabNavigationPage3 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.gaugeTemperature = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.labelComponent1 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.gaugeHumidity = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.labelComponent2 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.gaugePressure = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.labelComponent3 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.chartTemp = new DevExpress.XtraCharts.ChartControl();
            this.temperatureFrameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.grdTemp = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdTemperature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdHumidity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdPressure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.digitalBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            this.tabNavigationPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHumidity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugePressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent3)).BeginInit();
            this.tabNavigationPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureFrameBindingSource)).BeginInit();
            this.tabNavigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabNavigationPage3
            // 
            this.tabNavigationPage3.Caption = "Индикаторы";
            this.tabNavigationPage3.Controls.Add(this.gaugeControl1);
            this.tabNavigationPage3.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPage3.Image")));
            this.tabNavigationPage3.Name = "tabNavigationPage3";
            this.tabNavigationPage3.Size = new System.Drawing.Size(1053, 558);
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.BackColor = System.Drawing.SystemColors.Control;
            this.gaugeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.gaugeTemperature,
            this.gaugeHumidity,
            this.gaugePressure});
            this.gaugeControl1.Location = new System.Drawing.Point(0, 0);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(1053, 558);
            this.gaugeControl1.TabIndex = 9;
            // 
            // gaugeTemperature
            // 
            this.gaugeTemperature.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#00FFFFFF");
            this.gaugeTemperature.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.gaugeTemperature.Bounds = new System.Drawing.Rectangle(6, 6, 1041, 178);
            this.gaugeTemperature.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent1});
            this.gaugeTemperature.Name = "gaugeTemperature";
            this.gaugeTemperature.Text = "00.000";
            // 
            // labelComponent1
            // 
            this.labelComponent1.Name = "labelComponent1";
            this.labelComponent1.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(-100F, 50F);
            this.labelComponent1.Text = "Температура (°С)";
            // 
            // gaugeHumidity
            // 
            this.gaugeHumidity.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#00FFFFFF");
            this.gaugeHumidity.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.gaugeHumidity.Bounds = new System.Drawing.Rectangle(6, 190, 1041, 178);
            this.gaugeHumidity.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent2});
            this.gaugeHumidity.Name = "gaugeHumidity";
            this.gaugeHumidity.Text = "00.000";
            // 
            // labelComponent2
            // 
            this.labelComponent2.Name = "labelComponent2";
            this.labelComponent2.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(-100F, 50F);
            this.labelComponent2.Text = "Влажность (%)";
            // 
            // gaugePressure
            // 
            this.gaugePressure.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#00FFFFFF");
            this.gaugePressure.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.gaugePressure.Bounds = new System.Drawing.Rectangle(6, 374, 1041, 178);
            this.gaugePressure.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent3});
            this.gaugePressure.Name = "gaugePressure";
            this.gaugePressure.Text = "00.000";
            // 
            // labelComponent3
            // 
            this.labelComponent3.Name = "labelComponent3";
            this.labelComponent3.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(-100F, 50F);
            this.labelComponent3.Text = "Давление (кПа)";
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "Сводный график";
            this.tabNavigationPage2.Controls.Add(this.chartTemp);
            this.tabNavigationPage2.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPage2.Image")));
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(1051, 558);
            // 
            // chartTemp
            // 
            this.chartTemp.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartTemp.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartTemp.CacheToMemory = true;
            this.chartTemp.DataBindings = null;
            this.chartTemp.DataSource = this.temperatureFrameBindingSource;
            xyDiagram1.AxisX.DateTimeScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Automatic;
            xyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Tickmarks.CrossAxis = true;
            xyDiagram1.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.EnableAxisXZooming = true;
            xyDiagram1.EnableAxisYScrolling = true;
            xyDiagram1.EnableAxisYZooming = true;
            secondaryAxisY1.AxisID = 0;
            secondaryAxisY1.Name = "scaleTemperature";
            secondaryAxisY1.Title.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            secondaryAxisY1.Title.Text = "Температура (°C)";
            secondaryAxisY1.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY1.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY1.VisibleInPanesSerializable = "-1";
            secondaryAxisY2.AxisID = 1;
            secondaryAxisY2.Name = "scaleHumidity";
            secondaryAxisY2.Title.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            secondaryAxisY2.Title.Text = "Влажность (%)";
            secondaryAxisY2.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY2.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY2.VisibleInPanesSerializable = "-1";
            secondaryAxisY3.AxisID = 2;
            secondaryAxisY3.Name = "scalePressure";
            secondaryAxisY3.Title.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            secondaryAxisY3.Title.Text = "Давление (кПа)";
            secondaryAxisY3.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY3.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY3.VisibleInPanesSerializable = "-1";
            xyDiagram1.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY1,
            secondaryAxisY2,
            secondaryAxisY3});
            this.chartTemp.Diagram = xyDiagram1;
            this.chartTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTemp.Legend.Name = "Default Legend";
            this.chartTemp.Location = new System.Drawing.Point(0, 0);
            this.chartTemp.Name = "chartTemp";
            this.chartTemp.SeriesSelectionMode = DevExpress.XtraCharts.SeriesSelectionMode.Point;
            series1.ArgumentDataMember = "Time";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            series1.LegendName = "Default Legend";
            series1.Name = "Температура (°C)";
            series1.ValueDataMembersSerializable = "Temperature";
            splineSeriesView1.AxisYName = "scaleTemperature";
            splineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            splineSeriesView1.LineMarkerOptions.Size = 5;
            splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.View = splineSeriesView1;
            series2.ArgumentDataMember = "Time";
            series2.Name = "Влажность (%)";
            series2.ValueDataMembersSerializable = "Humidity";
            splineSeriesView2.AxisYName = "scaleHumidity";
            splineSeriesView2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(129)))), ((int)(((byte)(189)))));
            splineSeriesView2.LineMarkerOptions.Size = 5;
            splineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.View = splineSeriesView2;
            series3.ArgumentDataMember = "Time";
            series3.Name = "Давление (кПа)";
            series3.ValueDataMembersSerializable = "Pressure";
            splineSeriesView3.AxisYName = "scalePressure";
            splineSeriesView3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(187)))), ((int)(((byte)(89)))));
            splineSeriesView3.LineMarkerOptions.Size = 5;
            splineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.View = splineSeriesView3;
            this.chartTemp.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3};
            this.chartTemp.Size = new System.Drawing.Size(1051, 558);
            this.chartTemp.TabIndex = 0;
            // 
            // temperatureFrameBindingSource
            // 
            this.temperatureFrameBindingSource.DataSource = typeof(ReportManager.Data.DataModel.TemperatureFrame);
            // 
            // tabNavigationPage1
            // 
            this.tabNavigationPage1.Caption = "Таблица";
            this.tabNavigationPage1.Controls.Add(this.grdTemp);
            this.tabNavigationPage1.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPage1.Image")));
            this.tabNavigationPage1.Name = "tabNavigationPage1";
            this.tabNavigationPage1.Size = new System.Drawing.Size(1053, 558);
            // 
            // grdTemp
            // 
            this.grdTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTemp.Location = new System.Drawing.Point(0, 0);
            this.grdTemp.MainView = this.gridView1;
            this.grdTemp.Name = "grdTemp";
            this.grdTemp.Size = new System.Drawing.Size(1053, 558);
            this.grdTemp.TabIndex = 3;
            this.grdTemp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdDateTime,
            this.grdTemperature,
            this.grdHumidity,
            this.grdPressure});
            this.gridView1.GridControl = this.grdTemp;
            this.gridView1.Name = "gridView1";
            // 
            // grdDateTime
            // 
            this.grdDateTime.Caption = "Дата и время";
            this.grdDateTime.DisplayFormat.FormatString = "G";
            this.grdDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grdDateTime.FieldName = "Time";
            this.grdDateTime.Name = "grdDateTime";
            this.grdDateTime.OptionsColumn.AllowEdit = false;
            this.grdDateTime.OptionsColumn.ReadOnly = true;
            this.grdDateTime.Visible = true;
            this.grdDateTime.VisibleIndex = 0;
            // 
            // grdTemperature
            // 
            this.grdTemperature.Caption = "Температура (°С)";
            this.grdTemperature.FieldName = "Temperature";
            this.grdTemperature.Name = "grdTemperature";
            this.grdTemperature.OptionsColumn.AllowEdit = false;
            this.grdTemperature.OptionsColumn.ReadOnly = true;
            this.grdTemperature.Visible = true;
            this.grdTemperature.VisibleIndex = 1;
            // 
            // grdHumidity
            // 
            this.grdHumidity.Caption = "Влажность (кПа)";
            this.grdHumidity.FieldName = "Humidity";
            this.grdHumidity.Name = "grdHumidity";
            this.grdHumidity.OptionsColumn.AllowEdit = false;
            this.grdHumidity.OptionsColumn.ReadOnly = true;
            this.grdHumidity.Visible = true;
            this.grdHumidity.VisibleIndex = 2;
            // 
            // grdPressure
            // 
            this.grdPressure.Caption = "Давление (мПа)";
            this.grdPressure.FieldName = "Pressure";
            this.grdPressure.Name = "grdPressure";
            this.grdPressure.OptionsColumn.AllowEdit = false;
            this.grdPressure.OptionsColumn.ReadOnly = true;
            this.grdPressure.Visible = true;
            this.grdPressure.VisibleIndex = 3;
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNavigationPage1);
            this.tabPane1.Controls.Add(this.tabNavigationPage2);
            this.tabPane1.Controls.Add(this.tabNavigationPage3);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 0);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage1,
            this.tabNavigationPage2,
            this.tabNavigationPage3});
            this.tabPane1.RegularSize = new System.Drawing.Size(1071, 622);
            this.tabPane1.SelectedPage = this.tabNavigationPage2;
            this.tabPane1.Size = new System.Drawing.Size(1071, 622);
            this.tabPane1.TabIndex = 5;
            this.tabPane1.Text = "tabPane1";
            // 
            // digitalBackgroundLayerComponent1
            // 
            this.digitalBackgroundLayerComponent1.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(259.8125F, 99.9625F);
            this.digitalBackgroundLayerComponent1.Name = "digitalBackgroundLayerComponent13";
            this.digitalBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style1;
            this.digitalBackgroundLayerComponent1.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(20F, 0F);
            this.digitalBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // TemperatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 622);
            this.Controls.Add(this.tabPane1);
            this.Name = "TemperatureForm";
            this.Text = "Температурный датчик";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemperatureForm_FormClosing);
            this.tabNavigationPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gaugeTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeHumidity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugePressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent3)).EndInit();
            this.tabNavigationPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureFrameBindingSource)).EndInit();
            this.tabNavigationPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabNavigationPage tabNavigationPage3;
        private TabNavigationPage tabNavigationPage2;
        private TabNavigationPage tabNavigationPage1;
        private GridControl grdTemp;
        private GridView gridView1;
        private TabPane tabPane1;
        private DevExpress.XtraGrid.Columns.GridColumn grdDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdTemperature;
        private DevExpress.XtraGrid.Columns.GridColumn grdHumidity;
        private DevExpress.XtraGrid.Columns.GridColumn grdPressure;
        private DevExpress.XtraCharts.ChartControl chartTemp;
        private System.Windows.Forms.BindingSource temperatureFrameBindingSource;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent digitalBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge gaugeTemperature;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge gaugeHumidity;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge gaugePressure;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent1;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent2;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent3;
    }
}