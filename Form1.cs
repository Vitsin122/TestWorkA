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
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache; //выбор подгрузки карты – онлайн или из ресурсов
            GoogleMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance; //какой провайдер карт используется (в нашем случае гугл) 
            GoogleMap.MinZoom = 2; //минимальный зум
            GoogleMap.MaxZoom = 16; //максимальный зум
            GoogleMap.Zoom = 4; // какой используется зум при открытии
            GoogleMap.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);// точка в центре карты при открытии (центр России)
            GoogleMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter; // как приближает (просто в центр карты или по положению мыши)
            GoogleMap.CanDragMap = true; // перетаскивание карты мышью
            GoogleMap.DragButton = MouseButtons.Left; // какой кнопкой осуществляется перетаскивание
            GoogleMap.ShowCenter = false; //показывать или скрывать красный крестик в центре
            GoogleMap.ShowTileGridLines = false; //показывать или скрывать тайлы
        }
    }
}
