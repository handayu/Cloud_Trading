using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//LINK:https://blog.csdn.net/merry3688/article/details/38728563
//主要是想截屏，然后对截屏的图片进行扫描
namespace WeChartNotify
{
    public partial class FormShootPictureHoldString : Form
    {
        public FormShootPictureHoldString()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]//获取窗口句柄
        public static extern IntPtr FindWindow(
         string lpClassName,
         string lpWindowName
         );

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(
               IntPtr hwnd
               );

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(
               IntPtr hdc, // handle to DC
               int nWidth, // width of bitmap, in pixels
               int nHeight // height of bitmap, in pixels
               );

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(
                IntPtr hdc // handle to DC
                );

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(
               IntPtr hdc, // handle to DC
               IntPtr hgdiobj // handle to object
               );

        [DllImport("user32.dll")]
        public static extern bool PrintWindow(
               IntPtr hwnd, // Window to copy,Handle to the window that will be copied. 
               IntPtr hdcBlt, // HDC to print into,Handle to the device context. 
               UInt32 nFlags // Optional flags,Specifies the drawing options. It can be one of the following values. 
               );

        [DllImport("gdi32.dll")]

        public static extern int DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern int DeleteObject(IntPtr hdc);


        public static Bitmap GetImg(IntPtr hWnd, int Width, int Height)//得到窗口截图
        {
            IntPtr hscrdc = GetWindowDC(hWnd);
            IntPtr hbitmap = CreateCompatibleBitmap(hscrdc, Width, Height);
            IntPtr hmemdc = CreateCompatibleDC(hscrdc);
            SelectObject(hmemdc, hbitmap);
            PrintWindow(hWnd, hmemdc, 0);
            Bitmap bmp = Bitmap.FromHbitmap(hbitmap);
            DeleteDC(hscrdc);//删除用过的对象
            DeleteObject(hbitmap);//删除用过的对象
            DeleteDC(hmemdc);//删除用过的对象
            return bmp;
        }

        //private static string Recognition(string strFileName)//获取扫描信息
        //{
        //    string strResult = string.Empty;
        //    MODI.Document modiDocument = new MODI.Document();
        //    modiDocument.Create(strFileName);
        //    MODI.Image modiImage = (MODI.Image)modiDocument.Images[0];
        //    modiImage.OCR(MODI.MiLANGUAGES.miLANG_CHINESE_SIMPLIFIED, false, false);//在这里设置要识别的语言的种类。
        //    strResult = modiImage.Layout.Text;
        //    modiDocument.Close(false);
        //    strResult = strResult.Replace(" ", "");
        //    return strResult;
        //}

        //hWnd = FindWindow(null, "记事本");//得到名称为“记事本”的窗口句柄。

        //savePath="D\\temp.bmp";//设置图片的临时保存路径。

        //Bitmap img = GetImg(hWnd, X, Y);//X,Y为所要获取截图的窗口宽度和高度。

        //img.Save(savePath, ImageFormat.Bmp);//保存得到的截图。

        //resultStr = Recognition(saveImg);//获取截图的扫描结果。



    }
}
