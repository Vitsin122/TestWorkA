using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestWorkA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void GoogleMap_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            GoogleMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance; 
            GoogleMap.MinZoom = 2;
            GoogleMap.MaxZoom = 16; 
            GoogleMap.Zoom = 4;
            GoogleMap.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);
            GoogleMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            GoogleMap.CanDragMap = true;
            GoogleMap.DragButton = MouseButtons.Left;
            GoogleMap.ShowCenter = false;
            GoogleMap.ShowTileGridLines = false;
        }
    }
}
