namespace TestWorkA
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GoogleMap = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // GoogleMap
            // 
            this.GoogleMap.Bearing = 0F;
            this.GoogleMap.CanDragMap = true;
            this.GoogleMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.GoogleMap.GrayScaleMode = false;
            this.GoogleMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.GoogleMap.LevelsKeepInMemory = 5;
            this.GoogleMap.Location = new System.Drawing.Point(12, 12);
            this.GoogleMap.MarkersEnabled = true;
            this.GoogleMap.MaxZoom = 2;
            this.GoogleMap.MinZoom = 2;
            this.GoogleMap.MouseWheelZoomEnabled = true;
            this.GoogleMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.GoogleMap.Name = "GoogleMap";
            this.GoogleMap.NegativeMode = false;
            this.GoogleMap.PolygonsEnabled = true;
            this.GoogleMap.RetryLoadTile = 0;
            this.GoogleMap.RoutesEnabled = true;
            this.GoogleMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.GoogleMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.GoogleMap.ShowTileGridLines = false;
            this.GoogleMap.Size = new System.Drawing.Size(776, 426);
            this.GoogleMap.TabIndex = 0;
            this.GoogleMap.Zoom = 0D;
            this.GoogleMap.Load += new System.EventHandler(this.GoogleMap_Load);
            this.GoogleMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GoogleMap_MouseDown);
            this.GoogleMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GoogleMap_MouseMove);
            this.GoogleMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GoogleMap_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GoogleMap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl GoogleMap;
    }
}

