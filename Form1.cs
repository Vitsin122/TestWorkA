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
using System.Configuration;
using System.Collections.ObjectModel;
using TestWorkA.Models;
using TestWorkA.SqlTransactions;

namespace TestWorkA
{
    public partial class Form1 : Form
    {
        private GMapMarker _selectedMarker;
        private List<Technic> _technics;
        private Technic _selectedTechnic;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _technics = TechnicsTransaction.GetAllTechnics();

            SetAllTechnicMarkers();
        }
        private void GoogleMap_Load(object sender, EventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            GoogleMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance; 
            GoogleMap.MinZoom = 2;
            GoogleMap.MaxZoom = 16; 
            GoogleMap.Zoom = 4;
            GoogleMap.Position = new PointLatLng(67.4169575018027, 94.25025752215694);
            GoogleMap.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            GoogleMap.CanDragMap = true;
            GoogleMap.DragButton = MouseButtons.Left;
            GoogleMap.ShowCenter = true;
            GoogleMap.ShowTileGridLines = false;
        }

        #region MoveMarker
        private void GoogleMap_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedMarker = GoogleMap.Overlays.SelectMany(m => m.Markers).FirstOrDefault(m => m.IsMouseOver);

            if (_selectedMarker != null)
            {
                _selectedTechnic = _technics.Where(m =>
                {
                    PointLatLng point = new PointLatLng(m.Xposition, m.Yposition);
                    return point.Equals(_selectedMarker.Position);
                }).FirstOrDefault();
            }
        }

        private void GoogleMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selectedMarker == null)
                return;

            var latlng = GoogleMap.FromLocalToLatLng(e.X, e.Y);

            _selectedMarker.Position = latlng;
        }

        private void GoogleMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (_selectedTechnic != null)
            {
                if (_selectedTechnic.Xposition != _selectedMarker.Position.Lat || _selectedTechnic.Yposition != _selectedMarker.Position.Lng)
                {
                    _selectedTechnic.isModifide = true;
                    _selectedTechnic.Xposition = _selectedMarker.Position.Lat;
                    _selectedTechnic.Yposition = _selectedMarker.Position.Lng;
                    TechnicsTransaction.UpdateOneUser(_selectedTechnic);
                }
            }
            _selectedMarker = null;
        }
        #endregion

        private void SetAllTechnicMarkers()
        {
            if (_technics != null)
            {
                GMapOverlay overlay = new GMapOverlay("AllTech");

                foreach (var tecnic in  _technics)
                {
                    GMarkerGoogle gMarker = new GMarkerGoogle(new PointLatLng(tecnic.Xposition, tecnic.Yposition), GMarkerGoogleType.red);
                    overlay.Markers.Add(gMarker);
                    GoogleMap.Overlays.Add(overlay);
                }

                MessageBox.Show("Successfully added");
                return;
            }

            MessageBox.Show("Error. List of Technics are empty.");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TechnicsTransaction.SaveAllTechnics(_technics);
        }
    }
}
