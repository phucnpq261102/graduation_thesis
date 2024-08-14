using NeptuneC_Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using System.Drawing.Text;
using System.Timers;
using S7.Net;
namespace NeptuneCSample_CSharp
{
    public partial class CONTROL_PANEL : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;
        private Bitmap bitmapFromFormA;
        private NeptuneC_Interface.NeptuneCDevCheckCallback DeviceCheckCallbackInst;
        private NeptuneC_Interface.NeptuneCFrameCallback FrameCallbackInst;
        private Plc plc_s7_1200;
        public CONTROL_PANEL(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();
            m_refMainForm = refMainForm;
            //Khởi tạo đối tượng PLC
            plc_s7_1200 = new Plc(CpuType.S71200, "192.168.0.5", 0, 1); // Thay đổi IP, Rack và Slot nếu cần
            try
            {
                plc_s7_1200.Open();
                if (plc_s7_1200.IsConnected)
                {
                    Console.WriteLine("Connected to PLC S7-1200.");
                }
                else
                {
                    MessageBox.Show("Cannot connect to PLC S7-1200.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to PLC: " + ex.Message);
            }

        }

        private void CONTROL_PANEL_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            NeptuneC.ntcInit();
        }

        private void CONTROL_PANEL_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Closed...");
            NeptuneC.ntcUninit();
            m_refMainForm.Close();
            SendSignalToPLC(false); // Tắt tín hiệu tới PLC
            if (plc_s7_1200 != null && plc_s7_1200.IsConnected)
            {
                plc_s7_1200.Close(); // Đóng kết nối PLC
            }
        }

        // HÀM CHUYỂN ĐỔI RGB DATA SANG BITMAP
        private Bitmap anhbitmap_camera;
        private void Get_Image_Function_Callback()
        {
            //-------------------------
            ENeptuneError emErr = ENeptuneError.NEPTUNE_ERR_Fail;
            NEPTUNE_IMAGE_SIZE stImageSize = new NEPTUNE_IMAGE_SIZE();
            emErr = NeptuneC.ntcGetImageSize(m_refMainForm.m_pCameraHandle, ref stImageSize);
            if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
            {
                UInt32 uiBufSize = (UInt32)(stImageSize.nSizeX * stImageSize.nSizeY * 3);
                Byte[] arrBuffer = new Byte[uiBufSize];
                emErr = NeptuneC.ntcGetRGBData(m_refMainForm.m_pCameraHandle, arrBuffer, uiBufSize);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    // Tạo một ảnh bitmap từ dữ liệu RGB
                    anhbitmap_camera = new Bitmap(stImageSize.nSizeX, stImageSize.nSizeY, PixelFormat.Format24bppRgb);
                    BitmapData bmpData = anhbitmap_camera.LockBits(new Rectangle(0, 0, stImageSize.nSizeX, stImageSize.nSizeY), ImageLockMode.WriteOnly, anhbitmap_camera.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    System.Runtime.InteropServices.Marshal.Copy(arrBuffer, 0, ptr, arrBuffer.Length);
                    anhbitmap_camera.UnlockBits(bmpData);
                }
            }
        }
        private Bitmap grayBitmap;

        private Bitmap DetectGrayObjects(Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            // Định nghĩa ngưỡng màu xám
            int grayThreshold = 100; // Giá trị ngưỡng có thể điều chỉnh

            // Duyệt qua từng pixel trong ảnh gốc
            for (int y = 0; y < sourceBitmap.Height; y++)
            {
                for (int x = 0; x < sourceBitmap.Width; x++)
                {
                    // Lấy giá trị của pixel
                    Color pixel = sourceBitmap.GetPixel(x, y);

                    // Kiểm tra xem mỗi thành phần màu R, G, B có khác ngưỡng màu xám (giá trị nằm trong khoảng lớn hơn 50 và nhỏ hơn 100) hay không
                    if (pixel.R > 35 && pixel.R < grayThreshold && pixel.G > 35 && pixel.G < grayThreshold && pixel.B > 35 && pixel.B < grayThreshold)
                    {
                        // Pixel có màu xám
                        resultBitmap.SetPixel(x, y, Color.Gray); // Đặt màu đen cho pixel màu xám
                    }
                    else
                    {
                        // Pixel không có màu xám
                        resultBitmap.SetPixel(x, y, Color.White); // Đặt màu trắng cho pixel không phải màu xám
                    }
                }
            }

            return resultBitmap;
        }

        private void CheckDetected(Bitmap resultBitmap)
        {
            int totalPixels = resultBitmap.Width * resultBitmap.Height;
            int blackPixels = 0;

            for (int y = 0; y < resultBitmap.Height; y++)
            {
                for (int x = 0; x < resultBitmap.Width; x++)
                {
                    Color pixel = resultBitmap.GetPixel(x, y);
                    if (pixel.ToArgb() == Color.Gray.ToArgb())
                    {
                        blackPixels++;
                    }
                }
            }

            double blackPercentage = (double)blackPixels / totalPixels;
            Console.WriteLine(blackPercentage.ToString());

            if (blackPercentage >= 0.6)
            {
                labelDetected.Visible = true;
                checkBox1.CheckState = CheckState.Checked;
                SendSignalToPLC(true); // Gửi tín hiệu tới PLC
            }
            else
            {
                labelDetected.Visible = false;
                checkBox1.CheckState = CheckState.Unchecked;
                SendSignalToPLC(false); // Tắt tín hiệu tới PLC
            }

        }
        private void SendSignalToPLC(bool detected)
        {
            if (plc_s7_1200.IsConnected)
            {
                try
                {
                    plc_s7_1200.WriteBit(DataType.Output, 0, 8, 7, detected); // Gửi tín hiệu tới địa chỉ Q1.1
                    plc_s7_1200.WriteBit(DataType.Memory, 0, 11, 7, detected);
                    Console.WriteLine("tin_hieu: " + detected.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gửi tín hiệu tới PLC: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("PLC is not connected.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                button1.Text = "Stop";
                timer1.Start();
            }
            else
            {
                button1.Text = "Start";
                timer1.Stop();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Get_Image_Function_Callback();
            //Console.WriteLine("Running...");

            // Hiển thị ảnh bitmap lên pictureBox1
            pictureBox1.Image = anhbitmap_camera;
            Bitmap grayObjects = DetectGrayObjects(anhbitmap_camera);
            CheckDetected(grayObjects);
            picBox_hinhgoc.Image = grayObjects;
        }
    }
}
