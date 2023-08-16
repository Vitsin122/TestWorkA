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
using GMap.NET;

namespace TestWorkA
{
    public partial class Form1 : Form
    {
        private GMapMarker _selectedMarker;

        public Form1()
        {
            InitializeComponent();
        }
        private void GoogleMap_Load(object sender, EventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            GoogleMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance; 
            GoogleMap.MinZoom = 2;
            GoogleMap.MaxZoom = 16; 
            GoogleMap.Zoom = 4;
            GoogleMap.Position = new PointLatLng(66.4169575018027, 94.25025752215694);
            GoogleMap.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            GoogleMap.CanDragMap = true;
            GoogleMap.DragButton = MouseButtons.Left;
            GoogleMap.ShowCenter = false;
            GoogleMap.ShowTileGridLines = false;
            GMarkerGoogle gMarker = new GMarkerGoogle(new PointLatLng(60, 60), GMarkerGoogleType.red);
            GMapOverlay gOverlay = new GMapOverlay("Name");
            gOverlay.Markers.Add(gMarker);
            GoogleMap.Overlays.Add(gOverlay);
        }

        private void GoogleMap_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedMarker = GoogleMap.Overlays.SelectMany(m => m.Markers).FirstOrDefault(m=>m.IsMouseOver);
        }

        private void GoogleMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selectedMarker == null)
                return;

            var latlng = GoogleMap.FromLocalToLatLng(e.X, e.Y);

            _selectedMarker.Position = latlng;
        }

        private void GoogleMap_MouseUp(object sender, MouseEventArgs e) => _selectedMarker = null;
    }
}
