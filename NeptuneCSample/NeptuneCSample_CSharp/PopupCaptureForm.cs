using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using NeptuneC_Interface;
using System.Drawing.Imaging;

namespace NeptuneCSample_CSharp
{
    public partial class PopupCaptureForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;
        private bool m_bRecording = false;

        public PopupCaptureForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;
        }

        private void InitControls()
        {
            m_wndFolderBrowser.SelectedPath = Application.StartupPath;
            m_edSavePath.Text = m_wndFolderBrowser.SelectedPath;
            m_cbImageForamt.Items.Clear();
            m_cbImageForamt.Items.Add("RGB");
            m_cbImageForamt.Items.Add("BMP");
            m_cbImageForamt.Items.Add("JPG");
            m_cbImageForamt.Items.Add("TIF");
            m_cbImageForamt.Items.Add("AVI");
            m_cbImageForamt.SelectedIndex = 0;
        }

        public void UpdateForm()
        {
        }

        private void PopupCaptureForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitControls();
            UpdateForm();
        }

        private void PopupCaptureForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupCapture = null;
        }

        private void m_btnBrowser_Click(object sender, EventArgs e)
        {
            if (m_wndFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                m_edSavePath.Text = m_wndFolderBrowser.SelectedPath;
            }
        }

        private void m_cbImageForamt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_cbImageForamt.SelectedIndex != -1)
            {
                m_btnSaveImage.Enabled = !m_cbImageForamt.SelectedItem.Equals("AVI");
                m_btnStartRecord.Enabled = m_cbImageForamt.SelectedItem.Equals("AVI");
                m_btnStopRecord.Enabled = false;
                if (!m_cbImageForamt.SelectedItem.Equals("AVI") && m_bRecording)
                {
                    m_btnStopRecord.PerformClick();
                }
            }
        }

        private void m_btnSaveImage_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                DateTime dt = DateTime.Now;
                String strPathName = "Capture_" + dt.ToString("HHmmss_fff.") + m_cbImageForamt.SelectedItem.ToString();
                strPathName = System.IO.Path.Combine(m_edSavePath.Text, strPathName);
                Console.WriteLine(m_edSavePath.Text);
                Console.WriteLine(m_cbImageForamt.SelectedItem.ToString());
                ENeptuneError emErr = ENeptuneError.NEPTUNE_ERR_Fail;
                if (m_cbImageForamt.SelectedItem.Equals("RGB"))
                {
                    NEPTUNE_IMAGE_SIZE stImageSize = new NEPTUNE_IMAGE_SIZE();
                    emErr = NeptuneC.ntcGetImageSize(m_refMainForm.m_pCameraHandle, ref stImageSize);
                    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                    {
                        UInt32 uiBufSize = (UInt32)(stImageSize.nSizeX * stImageSize.nSizeY * 3);
                        Byte[] arrBuffer = new Byte[uiBufSize];
                        emErr = NeptuneC.ntcGetRGBData(m_refMainForm.m_pCameraHandle, arrBuffer, uiBufSize);
                        if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                        {
                            try
                            {
                                using (System.IO.FileStream stream = new System.IO.FileStream(strPathName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                                {
                                    stream.Write(arrBuffer, 0, arrBuffer.Length);
                                    stream.Close();
                                    // Tạo một ảnh bitmap từ dữ liệu RGB
                                    //Bitmap bitmap = new Bitmap(stImageSize.nSizeX, stImageSize.nSizeY, PixelFormat.Format24bppRgb);
                                    //BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, stImageSize.nSizeX, stImageSize.nSizeY), ImageLockMode.WriteOnly, bitmap.PixelFormat);
                                    //IntPtr ptr = bmpData.Scan0;
                                    //System.Runtime.InteropServices.Marshal.Copy(arrBuffer, 0, ptr, arrBuffer.Length);
                                    //bitmap.UnlockBits(bmpData);

                                    // Hiển thị ảnh bitmap lên pictureBox1
                                    //pictureBox1.Image = bitmap;
                                }
                            }
                            catch (System.Exception ex)
                            {
                                emErr = ENeptuneError.NEPTUNE_ERR_Fail;
                                m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, ex.Message, emErr);
                            }
                        }
                        Console.WriteLine("HIIIIII");
                    }
                }
                else
                {
                    emErr = NeptuneC.ntcSaveImage(m_refMainForm.m_pCameraHandle, strPathName, 100);
                }

                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Save Image: " + strPathName);
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSaveImage Failed.", emErr);
                }
            }

            //-------------------------
            //ENeptuneError emErr = ENeptuneError.NEPTUNE_ERR_Fail;
            //NEPTUNE_IMAGE_SIZE stImageSize = new NEPTUNE_IMAGE_SIZE();
            //emErr = NeptuneC.ntcGetImageSize(m_refMainForm.m_pCameraHandle, ref stImageSize);
            //if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
            //{
            //    UInt32 uiBufSize = (UInt32)(stImageSize.nSizeX * stImageSize.nSizeY * 3);
            //    Byte[] arrBuffer = new Byte[uiBufSize];
            //    emErr = NeptuneC.ntcGetRGBData(m_refMainForm.m_pCameraHandle, arrBuffer, uiBufSize);
            //    if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
            //    {
            //        // Tạo một ảnh bitmap từ dữ liệu RGB
            //        Bitmap bitmap = new Bitmap(stImageSize.nSizeX, stImageSize.nSizeY, PixelFormat.Format24bppRgb);
            //        BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, stImageSize.nSizeX, stImageSize.nSizeY), ImageLockMode.WriteOnly, bitmap.PixelFormat);
            //        IntPtr ptr = bmpData.Scan0;
            //        System.Runtime.InteropServices.Marshal.Copy(arrBuffer, 0, ptr, arrBuffer.Length);
            //        bitmap.UnlockBits(bmpData);
            //        // In ra kích thước của ảnh bitmap
            //        Console.WriteLine("Width: " + bitmap.Width);
            //        Console.WriteLine("Height: " + bitmap.Height);
            //        // Hiển thị ảnh bitmap lên pictureBox1
            //        // pictureBox1.Image = bitmap;
            //    }
            //}
            //-------------------------
        }

        private void m_btnStartRecord_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                DateTime dt = DateTime.Now;
                String strPathName = "Capture_" + dt.ToString("HHmmss_fff.") + m_cbImageForamt.SelectedItem.ToString();
                strPathName = System.IO.Path.Combine(m_edSavePath.Text, strPathName);

                ENeptuneError emErr = NeptuneC.ntcStartStreamCapture(m_refMainForm.m_pCameraHandle, strPathName, ENeptuneBoolean.NEPTUNE_BOOL_TRUE, 4000, (float)1.0);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_bRecording = true;
                    m_btnStartRecord.Enabled = !m_bRecording;
                    m_btnStopRecord.Enabled = m_bRecording;
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Start Recording: " + strPathName);
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcStartStreamCapture Failed.", emErr);
                }
            }
        }

        private void m_btnStopRecord_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneError emErr = NeptuneC.ntcStopStreamCapture(m_refMainForm.m_pCameraHandle);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_bRecording = false;
                    m_btnStartRecord.Enabled = !m_bRecording;
                    m_btnStopRecord.Enabled = m_bRecording;
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Stop Recording.");
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcStopStreamCapture Failed.", emErr);
                }
            }
        }
    }
}
