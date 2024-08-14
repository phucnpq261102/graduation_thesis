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
    public partial class PopupUserSetForm : Form
    {
        private NeptuneCSampleForm m_refMainForm = null;

        public PopupUserSetForm(NeptuneCSampleForm refMainForm)
        {
            InitializeComponent();

            m_refMainForm = refMainForm;
        }

        private void InitControls()
        {
        }

        public void UpdateForm()
        {
            m_cbUserSet.Items.Clear();

            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_USERSET stUserSet = new NEPTUNE_USERSET();
                ENeptuneError emErr = NeptuneC.ntcGetUserSet(m_refMainForm.m_pCameraHandle, ref stUserSet);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        UInt16 uiBit = (UInt16)(0x01 << i);
                        if ((stUserSet.SupportUserSet & uiBit) == uiBit)
                        {
                            if (i == 0)
                            {
                                m_cbUserSet.Items.Add(new ItemData("Default", i));
                            }
                            else
                            {
                                m_cbUserSet.Items.Add(new ItemData("UserSet" + i.ToString(), i));
                            }
                        }
                    }

                    m_cbUserSet.SelectedIndex = (int)stUserSet.UserSetIndex;
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcGetUserSet Failed.", emErr);
                }
            }
        }

        private void PopupUserSetForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitControls();
            UpdateForm();
        }

        private void PopupUserSetForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_refMainForm.m_formPopupUserSet = null;
        }

        private void m_btnLoad_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_USERSET stUserSet = new NEPTUNE_USERSET();
                stUserSet.UserSetIndex = (ENeptuneUserSet)((ItemData)m_cbUserSet.SelectedItem).m_nValue;
                stUserSet.Command = ENeptuneUserSetCommand.NEPTUNE_USERSET_CMD_LOAD;
                ENeptuneError emErr = NeptuneC.ntcSetUserSet(m_refMainForm.m_pCameraHandle, stUserSet);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.UpdatePopupForms(false);
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Load UserSet: UserSet" + ((int)stUserSet.UserSetIndex).ToString());

                    m_refMainForm.UpdateCameraInfo();
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetUserSet Failed.", emErr);
                }
            }
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                NEPTUNE_USERSET stUserSet = new NEPTUNE_USERSET();
                stUserSet.UserSetIndex = (ENeptuneUserSet)((ItemData)m_cbUserSet.SelectedItem).m_nValue;
                stUserSet.Command = ENeptuneUserSetCommand.NEPTUNE_USERSET_CMD_SAVE;
                ENeptuneError emErr = NeptuneC.ntcSetUserSet(m_refMainForm.m_pCameraHandle, stUserSet);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "Save UserSet: UserSet" + ((int)stUserSet.UserSetIndex).ToString());
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetUserSet Failed.", emErr);
                }
            }
        }

        private void m_btnSetDefault_Click(object sender, EventArgs e)
        {
            if (m_refMainForm.m_pCameraHandle != IntPtr.Zero)
            {
                ENeptuneUserSet emUserSet = (ENeptuneUserSet)((ItemData)m_cbUserSet.SelectedItem).m_nValue;
                ENeptuneError emErr = NeptuneC.ntcSetPowerOnDefaultUserSet(m_refMainForm.m_pCameraHandle, emUserSet);
                if (emErr == ENeptuneError.NEPTUNE_ERR_Success)
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_INFORMATION, "PowerOnDefault: UserSet" + ((int)emUserSet).ToString());
                }
                else
                {
                    m_refMainForm.InsertLog(EM_LOG_LEVEL.TYPE_ERROR, "ntcSetPowerOnDefaultUserSet Failed.", emErr);
                }
            }
        }
    }
}
