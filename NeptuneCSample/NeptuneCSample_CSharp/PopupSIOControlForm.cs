using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NeptuneC_Interface;

namespace NeptuneCSample_CSharp
{
    public partial class PopupSIOControlForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;

        public PopupSIOControlForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;
        }

        private void InitControls()
        {
            m_cbBaudRate.Items.Clear();
            m_cbBaudRate.Items.Add(new ItemData("300", 300));
            m_cbBaudRate.Items.Add(new ItemData("600", 600));
            m_cbBaudRate.Items.Add(new ItemData("1200", 1200));
            m_cbBaudRate.Items.Add(new ItemData("2400", 2400));
            m_cbBaudRate.Items.Add(new ItemData("4800", 4800));
            m_cbBaudRate.Items.Add(new ItemData("9600", 9600));
            m_cbBaudRate.Items.Add(new ItemData("19200", 19200));
            m_cbBaudRate.Items.Add(new ItemData("38400", 38400));
            m_cbBaudRate.Items.Add(new ItemData("57600", 57600));
            m_cbBaudRate.Items.Add(new ItemData("115200", 115200));
            m_cbBaudRate.Items.Add(new ItemData("230400", 230400));
            m_cbBaudRate.SelectedIndex = 7;

            m_cbParityBits.Items.Clear();
            m_cbParityBits.Items.Add(new ItemData("None", (int)ENeptuneSIOParity.NEPTUNE_SIO_PARITY_NONE));
            m_cbParityBits.Items.Add(new ItemData("Odd", (int)ENeptuneSIOParity.NEPTUNE_SIO_PARITY_ODD));
            m_cbParityBits.Items.Add(new ItemData("Even", (int)ENeptuneSIOParity.NEPTUNE_SIO_PARITY_EVEN));
            m_cbParityBits.SelectedIndex = 0;

            m_cbDataBits.Items.Clear();
            m_cbDataBits.Items.Add(new ItemData("7", 7));
            m_cbDataBits.Items.Add(new ItemData("8", 8));
            m_cbDataBits.SelectedIndex = 1;

            m_cbStopBits.Items.Clear();
            m_cbStopBits.Items.Add(new ItemData("1", 1));
            m_cbStopBits.Items.Add(new ItemData("2", 2));
            m_cbStopBits.SelectedIndex = 0;
        }

        public void UpdateForm()
        {
        }

        private void PopupSIOControlForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitControls();
            UpdateForm();
        }

        private void PopupSIOControlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupSIOControl = null;
        }

        private void m_btnApply_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_SIO_PROPERTY stProperty = new NEPTUNE_SIO_PROPERTY();
                stProperty.bEnable = (m_ckEnable.Checked ? ENeptuneBoolean.NEPTUNE_BOOL_TRUE : ENeptuneBoolean.NEPTUNE_BOOL_FALSE);
                stProperty.Baudrate = (UInt32)((ItemData)m_cbBaudRate.SelectedItem).m_nValue;
                stProperty.Parity = (ENeptuneSIOParity)((ItemData)m_cbParityBits.SelectedItem).m_nValue;
                stProperty.DataBit = (UInt32)((ItemData)m_cbDataBits.SelectedItem).m_nValue;
                stProperty.StopBit = (UInt32)((ItemData)m_cbStopBits.SelectedItem).m_nValue;
                ENeptuneError emErr = NeptuneC.ntcSetSIO(m_refMainForm.m_pCameraHandle, stProperty);
                if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetSIO Failed.", emErr);
                }
            }
        }

        private void m_btnSend_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_SIO stSIO = new NEPTUNE_SIO();
                stSIO.strText = m_edData.Text;
                ENeptuneError emErr = NeptuneC.ntcWriteSIO(m_refMainForm.m_pCameraHandle, stSIO);
                if (emErr != ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcWriteSIO Failed.", emErr);
                }
            }
        }

        private void m_btnReceive_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_SIO stSIO = new NEPTUNE_SIO();
                ENeptuneError emErr = NeptuneC.ntcReadSIO(m_refMainForm.m_pCameraHandle, ref stSIO);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_edData.Text = stSIO.strText;
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcReadSIO Failed.", emErr);
                }
            }
        }
    }
}
