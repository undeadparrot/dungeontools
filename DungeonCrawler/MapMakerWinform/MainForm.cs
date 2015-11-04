/*
 * Created by SharpDevelop.
 * User: smatu
 * Date: 11/01/2015
 * Time: 12:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace MapMakerWinform
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		BufferedGraphicsContext bgc;
		BufferedGraphics bg;
		Graphics g;  
		Graphics mg;
		Point MousePos;
		MouseButtons MouseButt;
		CursorButtonEnum CursorButt;
		Point CursorPos;
		Point WalkerPos;
		ArrowDirection WalkerDirection;
		
		GameTile[,] Map;
		
		int s = 40;
		int w = 20;
		int h = 20;
		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			
			Map=new GameTile[w,h];
			
			SetupMapGraphics();
			
			var clone=btnPal.Clone();
			clone.MouseClick+=BtnPalMouseClick;
			clone.MouseDown+=BtnPalMouseDown;
			flowPal.Controls.Add(clone);
			clone=btnPal.Clone();
			clone.MouseClick+=BtnPalMouseClick;
			clone.MouseDown+=BtnPalMouseDown;
			flowPal.Controls.Add(clone);
			clone=btnPal.Clone();
			clone.MouseClick+=BtnPalMouseClick;
			clone.MouseDown+=BtnPalMouseDown;
			flowPal.Controls.Add(clone);
			
			var t = new Timer();
			t.Interval=50;
			t.Tick+=(s2, e2) => DrawMap();
			t.Start();
			
			
			
		}

		void SetupMapGraphics()
		{
			bgc = BufferedGraphicsManager.Current;
			bg = bgc.Allocate(this.CreateGraphics(), pnlMap.DisplayRectangle);
			mg = pnlMap.CreateGraphics();
			g = bg.Graphics;
		}

		Pen penHighlight;

		Pen penLine;

		Pen penGold;

		Pen penGoldenArrow;

		void DrawMap()
		{
			
			
			//pnlMap.Width
			
			penLine = Pens.ForestGreen;
			penHighlight = new Pen(Color.SlateGray, 6F) {
				EndCap = LineCap.Triangle,
				StartCap = LineCap.Triangle
			};
			g.SmoothingMode=SmoothingMode.None;
			
			penGold = new Pen(Color.Gold, 6F) {
				EndCap = LineCap.Triangle,
				StartCap = LineCap.Triangle
			};
			
			penGoldenArrow = new Pen(Color.Gold, 5F) {
				EndCap = LineCap.ArrowAnchor,
				StartCap = LineCap.Round
			};
			
			g.Clear(Color.DarkSlateGray);
			
			DrawMapGrid(s, w, h, penLine, penHighlight);
			
			var target=WhatIsMouseOver();
			
			if(target.type==MouseQueryTypeEnum.WallVertical){
				var z = target.y * s;
				var offs = s * 0.15F;
				g.DrawLine(penGold, target.x * s, z + offs, target.x * s, z + s - offs);
			}else if(target.type==MouseQueryTypeEnum.WallHorizontal){
				var z = target.x * s;
				var offs = s * 0.15F;
				g.DrawLine(penGold, z + offs, target.y * s, z + s - offs, target.y * s);
			}
			
			g.DrawEllipse(penGold,-3+CursorPos.X*s,-3+CursorPos.Y*s,4F,4F);
			var walkerXlength=0;
			var walkerYlength=0;
			switch(WalkerDirection){
				case ArrowDirection.Left:
					walkerXlength-=s/2;
					break;
				case ArrowDirection.Right:
					walkerXlength+=s/2;
					break;
				case ArrowDirection.Down:
					walkerYlength+=s/2;
					break;
				case ArrowDirection.Up:
					walkerYlength-=s/2;
					break;
			}
			g.DrawLine(penGoldenArrow,(s/2)+WalkerPos.X*s,(s/2)+WalkerPos.Y*s,walkerXlength+(s/2)+WalkerPos.X*s,walkerYlength+((s/2)+WalkerPos.Y*s));
			
			bg.Render();
			bg.Render(mg);
		}

		void DrawMapGrid(int s, int w, int h, Pen penLine, Pen penPink)
		{
			for (int x = 0; x < w; x++) {
				g.DrawLine(penLine, x * s, 0, x * s, h * s);
				for (int y = 0; y < h; y++) {
					var z = y * s;
					var offs = s * 0.15F;
					if(Map[x,y].Vertical!=0)
					{
						g.DrawLine(penPink, x * s, z + offs, x * s, z + s - offs);
					}
				}
			}
			for (int y = 0; y < h; y++) {
				g.DrawLine(penLine, w * s, y * s, 0, y * s);
				for (int x = 0; x < w; x++) {
					var z = x * s;
					var offs = s * 0.15F;
					if(Map[x,y].Horizontal!=0){
						g.DrawLine(penPink, z + offs, y * s, z + s - offs, y * s);
					}
				}
			}
		}

		void PnlMapPaint(object sender, PaintEventArgs e)
		{
			
			
			
		}
		void PnlMapResize(object sender, EventArgs e)
		{
			SetupMapGraphics();
		}
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			bg.Dispose();
			bgc.Dispose();
			//mg.ReleaseHdc();
			mg.Dispose();
		}

		MouseQuery WhatIsMouseOver()
		{
			var p=MousePos;
			
			var threshold=0.20F;
			var cornerThreshold=threshold*1.0F*s;
			
			float xf=p.X/(float)s;
			xf = (float)Math.Round(xf);
			float yf=p.Y/(float)s;
			yf = (float)Math.Round(yf);
			
			float xdiff=Math.Abs((xf*s)-p.X);
            float ydiff=Math.Abs((yf*s)-p.Y);
            
            bool xsnap=xdiff<s*threshold;
            bool ysnap=ydiff<s*threshold;
            
            bool xbeforey=xdiff<=ydiff;
            
            lblStatusCoords.Text=string.Format("{0} : {1} {2} : {3}",xf,yf,xsnap,ysnap);
			
			var result= new MouseQuery(){
				x=(int)xf,
				y=(int)yf
			};
			
			if((!xsnap&&!ysnap) || (xdiff<cornerThreshold && ydiff<cornerThreshold)){
				result.type=MouseQueryTypeEnum.None;
			}else if( (xsnap && !ysnap) ||  xbeforey){
				result.type=MouseQueryTypeEnum.WallVertical;
				result.y = (int)Math.Floor(p.Y / (float)s);
			}else{
				result.type=MouseQueryTypeEnum.WallHorizontal;
				result.x = (int)Math.Floor(p.X / (float)s);
			}
			return result;
		}

		void HandleMouseClick()
		{
			var target=WhatIsMouseOver();
			if(MouseButt==MouseButtons.Left){
				if(target.type==MouseQueryTypeEnum.WallVertical){
					Map[target.x,target.y].Vertical=GetPalVal();
				}else if(target.type==MouseQueryTypeEnum.WallHorizontal){
					Map[target.x,target.y].Horizontal=GetPalVal();   
				}
			}else if(MouseButt==MouseButtons.Right){
				if(target.type==MouseQueryTypeEnum.WallVertical){
					Map[target.x,target.y].Vertical=0;
				}else if(target.type==MouseQueryTypeEnum.WallHorizontal){
					Map[target.x,target.y].Horizontal=0;
				}
			}
			else{
				
			}
		}
		void PnlMapMouseMove(object sender, MouseEventArgs e)
		{
			MousePos=e.Location;
			WhatIsMouseOver();
			if(MouseButt!=MouseButtons.None)
			{
				HandleMouseClick();
			}
		}
		
		void MainFormMouseClick(object sender, MouseEventArgs e)
		{
			//MouseButt=e.Button;
			
		}
		void PnlMapMouseDown(object sender, MouseEventArgs e)
		{
			MouseButt=e.Button;
			HandleMouseClick();
		}
		void PnlMapMouseLeave(object sender, EventArgs e)
		{
			MouseButt=MouseButtons.None;
		}
		void PnlMapMouseUp(object sender, MouseEventArgs e)
		{
			MouseButt=MouseButtons.None;
		}
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			//MessageBox.Show(e.KeyCode.ToString());
			
			
		}
		void MainFormKeyUp(object sender, KeyEventArgs e)
		{
			HandleKeysUp(e.KeyCode);
		}
		void BtnPalClick(object sender, EventArgs e)
		{
			
			var btn=(Button)sender;
			
			
		}
		void BtnPalMouseCaptureChanged(object sender, EventArgs e)
		{
	
		}
		void BtnPalMouseClick(object sender, MouseEventArgs e)
		{
			var btn=(Button)sender;
			if(e.Button==MouseButtons.Left){
				foreach (var control in flowPal.Controls) {
					if(control.GetType() ==typeof(Button))
					{
						((Button)control).FlatStyle=FlatStyle.Flat;
						((Button)control).FlatAppearance.BorderColor=Color.DarkSlateGray;
						((Button)control).FlatAppearance.BorderSize=1;
						//((Button)control).Visible=false;
						lblStatusMessage.Text="Blah";
					}
				}
				//btn.Visible=true;
				btn.FlatStyle=FlatStyle.Flat;
				btn.FlatAppearance.BorderColor=Color.Yellow;
				btn.FlatAppearance.BorderSize=3;
			}
		}
		void BtnPalMouseDown(object sender, MouseEventArgs e)
		{
			var btn=(Button)sender;
			if(e.Button==MouseButtons.Right){
				var log=new ColorDialog();
				if(log.ShowDialog()==DialogResult.OK){
					btn.BackColor=log.Color;
				}
			}
		}
		void MainFormPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			//MessageBox.Show("");
			HandleKeysDown(e.KeyCode);
		}
		
		void DrawConeOfVision()
		{
			var maxStride=3;
			var maxStrafe=3;
			for (int stride = 0; stride < maxStride; stride++) {
				
				for (int strafe = 0; strafe < maxStrafe; strafe++) {
					
				} 
				
				
				
				
			}
		}
		
		void DrawPreview(){
			var e = pnlPreview.CreateGraphics();
			
			e.Clear(Color.DarkSlateGray);
			
			
			
			//e.DrawImage(imgwallset,x,y,new Rectangle,GraphicsUnit.Pixel);
			
		}
		
		
//		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
//		{
//			if(msg.Msg==0x100)
//			{
//				HandleKeysDown(keyData);
//			}
//			else if(msg.Msg==0x101)
//			{
//				HandleKeysUp(keyData);
//			}
//			return base.ProcessCmdKey(ref msg,keyData);
//		}
		const int WM_KEYDOWN = 0x100;
const int WM_KEYUP = 0x101;

protected override bool ProcessKeyPreview(ref Message m)
{
    if (m.Msg == WM_KEYDOWN )
    {
    	HandleKeysDown((Keys)m.WParam);
    }
    else if (m.Msg == WM_KEYUP )
    {
    	HandleKeysUp((Keys)m.WParam);
    }

    return base.ProcessKeyPreview(ref m);
}

		int GetPalVal()
		{
			return 1;
		}

		void HandleKeysDown(Keys key)
		{
			switch (key) {
				case Keys.W:
					PedalWalker(1);
					break;
				case Keys.Up:
					if (CursorPos.Y != 0) {
						CursorPos.Y -= 1;
						if (CursorButt != CursorButtonEnum.None) {
							Map[CursorPos.X, CursorPos.Y].Vertical = (CursorButt == CursorButtonEnum.Draw) ? GetPalVal() : 0;
						}
					}
					break;
				case Keys.Q:
					TurnWalker(false);
					break;
				case Keys.A:
					SideStepWalker(-1);
					break;
				case Keys.Left:
					if (CursorPos.X != 0) {
						CursorPos.X -= 1;
						if (CursorButt != CursorButtonEnum.None) {
							Map[CursorPos.X, CursorPos.Y].Horizontal = (CursorButt == CursorButtonEnum.Draw) ? GetPalVal() : 0;
						}
					}
					break;
				case Keys.S:
					PedalWalker(-1);
					break;
				case Keys.Down:
					if (CursorPos.Y + 1 <= h) {
						if (CursorButt != CursorButtonEnum.None) {
							Map[CursorPos.X, CursorPos.Y].Vertical = (CursorButt == CursorButtonEnum.Draw) ? GetPalVal() : 0;
						}
						CursorPos.Y += 1;
					}
					break;
				case Keys.E:
					TurnWalker(true);
					break;
				case Keys.D:
					SideStepWalker(+1);
					break;
				case Keys.Right:
					if (CursorPos.X + 1 < w) {
						if (CursorButt != CursorButtonEnum.None) {
							Map[CursorPos.X, CursorPos.Y].Horizontal = (CursorButt == CursorButtonEnum.Draw) ? GetPalVal() : 0;
						}
						CursorPos.X += 1;
					}
					break;
				case Keys.Z:
				case Keys.Space:
					CursorButt = CursorButtonEnum.Draw;
					break;
				case Keys.X:
					CursorButt = CursorButtonEnum.Erase;
					break;
				default:
					break;
			}
		}	

		void TurnWalker(bool b)
		{
			switch(WalkerDirection){
				case ArrowDirection.Down:
					WalkerDirection=b?ArrowDirection.Left:ArrowDirection.Right;
					break;
				case ArrowDirection.Left:
					WalkerDirection=b?ArrowDirection.Up:ArrowDirection.Down;	
					break;
				case ArrowDirection.Right:
					WalkerDirection=b?ArrowDirection.Down:ArrowDirection.Up;	
					break;
				case ArrowDirection.Up:
					WalkerDirection=b?ArrowDirection.Right:ArrowDirection.Left;
					break;
			}
		}

		void PedalWalker(int i)
		{	
			switch(WalkerDirection){
				case ArrowDirection.Left:
					i*=-1;
					goto case ArrowDirection.Right;
				case ArrowDirection.Right:
					if (WalkerPos.X + i < w && WalkerPos.X + i >= 0 ) {
						WalkerPos.X += i;
					}	
					break;
				
				case ArrowDirection.Up:
					i*=-1;
					goto case ArrowDirection.Down;
				case ArrowDirection.Down:
					if (WalkerPos.Y + i < h && WalkerPos.Y + i >= 0 ) {
						WalkerPos.Y += i;
					}
					break;
			}
		}
		void SideStepWalker(int i)
		{	
			switch(WalkerDirection){
				case ArrowDirection.Left:
					i*=-1;
					goto case ArrowDirection.Right;
				case ArrowDirection.Right:
					if (WalkerPos.Y + i < w && WalkerPos.Y + i >= 0 ) {
						WalkerPos.Y += i;
					}	
					break;
				
				case ArrowDirection.Down:
					i*=-1;
					goto case ArrowDirection.Up;
				case ArrowDirection.Up:
					if (WalkerPos.X + i < h && WalkerPos.X + i >= 0 ) {
						WalkerPos.X += i;
					}
					break;
			}
		}
		public void HandleKeysUp(Keys key){
			switch(key)
			{
				case Keys.Z:
				case Keys.Space:
					CursorButt=CursorButtonEnum.None;
					break;
				case Keys.X:
					CursorButt=CursorButtonEnum.None;
					break;
				default:
					break;
					
			}
		}
		void ContentPanelLoad(object sender, EventArgs e)
		{
	
		}
		void OpenMapToolStripMenuItemClick(object sender, EventArgs e)
		{
	
		}
		void SaveMapToolStripMenuItemClick(object sender, EventArgs e)
		{
	
		}
		void SaveMapAsToolStripMenuItemClick(object sender, EventArgs e)
		{
	
		}

		
	}
	public enum MouseQueryTypeEnum{
		None,
		WallHorizontal,
		WallVertical
	}
	public struct MouseQuery{
		public MouseQueryTypeEnum type;
		public int x;
		public int y;
	}
	public enum CursorButtonEnum{
		None,
		Draw,
		Erase
	}
	public struct GameTile{
		public int Vertical;
		public int Horizontal;
	}
	public static class ControlExtensions
	{
	    public static T Clone<T>(this T controlToClone) 
	        where T : Control
	    {
	        PropertyInfo[] controlProperties = typeof(T).GetProperties((System.Reflection.BindingFlags)(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance));
	
	        T instance = Activator.CreateInstance<T>();
	
	        foreach (PropertyInfo propInfo in controlProperties)
	        {
	            if (propInfo.CanWrite)
	            {
	                if(propInfo.Name != "WindowTarget")
	                    propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
	            }
	        }
	
	        return instance;
	    }
	}
}
