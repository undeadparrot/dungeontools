/*
 * Created by SharpDevelop.
 * User: smatu
 * Date: 10/7/2015
 * Time: 7:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
namespace WpfTestProject
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public BindingList<NamedRectangle> NamedRects{get;set;}
		public NamedRectangle CurrentlySelectedNamedRect{get;set;}
		Point MousePos;
		double scaleFactor=5.0;
		public Window1()
		{
			NamedRects=new BindingList<NamedRectangle>();
			NamedRects.ListChanged+=HandleListChangedEventHandler;;
			CurrentlySelectedNamedRect=NamedRects.AddNew();
			NamedRects.AddNew();
			NamedRects.AddNew();
			FixDuplicateNames();
			var TestString="She sells seashells on the seashore";
			InitializeComponent();
			lstRects.ItemsSource=NamedRects;
		}
		void button1_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Cave");
		}
		void CanVas_MouseMove(object sender, MouseEventArgs e)
		{
			var pos=e.GetPosition(canVas);
			
			MousePos=pos;
			
			HandleCursorMove();
			
			
		}
		void canVas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var pos=MousePos;//e.GetPosition(canVas);
			var oldrect=CurrentlySelectedNamedRect.Rectangle;
			var newrect=new Rect(pos.X,
			                  pos.Y,
			                  oldrect.Width,
			                  oldrect.Height);
			CurrentlySelectedNamedRect.SetRect(newrect);
			RefreshCanvasRectangle();
		}
		void CanVas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			var pos=MousePos;//e.GetPosition(canVas);
			var oldrect=CurrentlySelectedNamedRect.Rectangle;
			var newrect=new Rect(oldrect.X,
			                  oldrect.Y,
			                  pos.X-oldrect.X,
			                  pos.Y-oldrect.Y
			                  );
			CurrentlySelectedNamedRect.SetRect(newrect);
			RefreshCanvasRectangle();
			
		}

		void HandleCursorMove()
		{
			var pos=MousePos;
			var guideOffset=scaleFactor/2.0;
			
			var transform = new TransformGroup();
			transform.Children.Add((new ScaleTransform(scaleFactor, scaleFactor)));
			transform.Children.Add(new TranslateTransform((-pos.X * scaleFactor) + (scrollZoom.Width / 2) - guideOffset, (-pos.Y * scaleFactor) + (scrollZoom.Height / 2) - guideOffset));
			canZoom.RenderTransform = transform;
			
			lineMouseHor.X1 = pos.X - 16;
			lineMouseHor.X2 = pos.X + 16;
			lineMouseHor.Y1 = pos.Y;
			lineMouseHor.Y2 = pos.Y;
			lineMouseVer.X1 = pos.X;
			lineMouseVer.X2 = pos.X;
			lineMouseVer.Y1 = pos.Y - 16;
			lineMouseVer.Y2 = pos.Y + 16;
			
			lblStatusCoords.Text=string.Format("{0,5},{0,5}",pos.X,pos.Y);
			
		}

		void lstRects_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(CurrentlySelectedNamedRect!=null)
			{
				CurrentlySelectedNamedRect = lstRects.SelectedItem as NamedRectangle;
				txtName.Text=CurrentlySelectedNamedRect.Name;
				RefreshCanvasRectangle();
			}
			canVas.Focus();
		}
		void BtnAddRect_Click(object sender, RoutedEventArgs e)
		{
			var newRect= new NamedRectangle();
			NamedRects.Add(newRect);
			CurrentlySelectedNamedRect=newRect;
			FixDuplicateNames();
			RefreshCanvasRectangle();
		}
		void BtnRemoveRect_Click(object sender, RoutedEventArgs e)
		{
			if(NamedRects.Contains(CurrentlySelectedNamedRect)){
				var index = NamedRects.IndexOf(CurrentlySelectedNamedRect);
				CurrentlySelectedNamedRect=null;
				NamedRects.RemoveAt(index);
				RefreshCanvasRectangle();
			}
		}
		void MenuItemOpen_Click(object sender, RoutedEventArgs e)
		{
			var open = new OpenFileDialog();
			if(open.ShowDialog()==true)
			{
				var filename=open.FileName;
				var bmp=new BitmapImage(new Uri(filename));
				imgMain.Source=bmp;
				canVas.Width=imgMain.Source.Width;
				canVas.Height=imgMain.Source.Height;
			}
			
		}
		void MenuItemOpenJson_Click(object sender, RoutedEventArgs e)
		{
			var open = new OpenFileDialog();
			if(open.ShowDialog()==true)
			{
				var filename=open.FileName;
				//var json= new JObject();
				NamedRects=new BindingList<NamedRectangle>();
				NamedRects = (BindingList<NamedRectangle>)JsonConvert.DeserializeObject(File.ReadAllText(filename), typeof(BindingList<NamedRectangle>));
			}
			lstRects.ItemsSource=NamedRects;
		}
		void MenuItemSave_Click(object sender, RoutedEventArgs e)
		{
			var json = new JObject();
			json["regions"]=new JObject();
			var jsonRegions=json["regions"];
			foreach(NamedRectangle r in NamedRects)
			{
				jsonRegions[r.Name]=new JObject();
				jsonRegions[r.Name]["Top"]=r.Rectangle.Top;
				jsonRegions[r.Name]["Left"]=r.Rectangle.Left;
				jsonRegions[r.Name]["Bottom"]=r.Rectangle.Bottom;
				jsonRegions[r.Name]["Right"]=r.Rectangle.Right;
			}
			var log = new SaveFileDialog();
			if(log.ShowDialog()==true){
				File.WriteAllText(log.FileName,JsonConvert.SerializeObject(NamedRects).ToString());
			}
		}

		void RefreshCanvasRectangle()
		{
			if(imgMain.Source==null){
				return;
			}
			if(CurrentlySelectedNamedRect==null)
			{
				rectCanvas.Width=imgMain.Source.Width;
				rectCanvas.Height=imgMain.Source.Height;
				Canvas.SetLeft(rectCanvas,0);
				Canvas.SetTop(rectCanvas,0);
				rectZoom.Width=imgMain.Source.Width;
				rectZoom.Height=imgMain.Source.Height;
				Canvas.SetLeft(rectZoom,0);
				Canvas.SetTop(rectZoom,0);
				return;
			}
			rectCanvas.Width=CurrentlySelectedNamedRect.Rectangle.Width;
			rectCanvas.Height=CurrentlySelectedNamedRect.Rectangle.Height;
			Canvas.SetLeft(rectCanvas,CurrentlySelectedNamedRect.Rectangle.Left);
			Canvas.SetTop(rectCanvas,CurrentlySelectedNamedRect.Rectangle.Top);
			rectZoom.Width=CurrentlySelectedNamedRect.Rectangle.Width;
			rectZoom.Height=CurrentlySelectedNamedRect.Rectangle.Height;
			Canvas.SetLeft(rectZoom,CurrentlySelectedNamedRect.Rectangle.Left);
			Canvas.SetTop(rectZoom,CurrentlySelectedNamedRect.Rectangle.Top);
		}

		void HandleListChangedEventHandler(object sender, ListChangedEventArgs e)
		{
			
		}
		void FixDuplicateNames()
		{
			foreach(NamedRectangle nrOriginal in NamedRects)
			{
				var i = 1;
				foreach(var nr in NamedRects.Where(r=>r.Name==nrOriginal.Name && r!=nrOriginal))
				{
					nr.Name+="_"+i++;
				}
			}
			NamedRects[0]=NamedRects[0];
		}
		void TxtName_KeyUp(object sender, KeyEventArgs e)
		{
			CurrentlySelectedNamedRect.Name=txtName.Text;
			FixDuplicateNames();
		}
		void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if(txtName.IsFocused)
			{
				return;
			}
			var distance=1.0f;
			if(e.KeyboardDevice.IsKeyDown(Key.LeftShift)||e.KeyboardDevice.IsKeyDown(Key.RightShift)){
				distance=5.0f;
			}
			switch(e.Key){
			case Key.Right:   
				MousePos.X+=1.0f;
				HandleCursorMove();
				e.Handled=true;
				break;
			case Key.Down:   
				MousePos.Y+=distance;
				HandleCursorMove();
				e.Handled=true;
				break;
			case Key.Left:   
				if(MousePos.X-distance>0)
				{MousePos.X-=1.0f;}
				HandleCursorMove();
				e.Handled=true;
				break;
			case Key.Up:   
				if(MousePos.Y-distance>0.0F)
				{MousePos.Y-=distance;}
				HandleCursorMove();
				e.Handled=true;
				break;
			case Key.Z:
				canVas_MouseLeftButtonDown(null,null);
				e.Handled=true;
				break;
			case Key.X:
				CanVas_MouseRightButtonDown(null,null);
				e.Handled=true;
				break;
			case Key.PageUp:
				if(lstRects.SelectedIndex>0)
				{lstRects.SelectedIndex--;}
				break;
			case Key.PageDown:
				if(lstRects.SelectedIndex<NamedRects.Count-1)
				{lstRects.SelectedIndex++;}
				break;
			case Key.Add:
				scaleFactor++;
				break;
			}
			
		}
		void chkShadeRect_Checked(object sender, RoutedEventArgs e)
		{
			rectCanvas.Fill=new SolidColorBrush(Color.FromArgb(101,200,200,50));
		}
		void chkShadeRect_Unchecked(object sender, RoutedEventArgs e)
		{
			rectCanvas.Fill=Brushes.Transparent;
		}
	}
	public class NamedRectangle{
		public string Name{get;set;}
		public Rect Rectangle{get;set;}
		public NamedRectangle(){
			Name="Nice Rectangle";
			Rectangle=new Rect(0,0,32,32);
		}
		public void SetRect(Rect newrect)
		{
			Rectangle=newrect;
		}
	}
}