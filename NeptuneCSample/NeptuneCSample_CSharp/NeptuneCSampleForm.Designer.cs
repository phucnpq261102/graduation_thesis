namespace NeptuneCSample_CSharp
{
    partial class NeptuneCSampleForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeptuneCSampleForm));
            this.m_stcDisplayWnd = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_btnRefresh = new System.Windows.Forms.Button();
            this.m_cbCameraList = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_ckMirror = new System.Windows.Forms.CheckBox();
            this.m_ckFlip = new System.Windows.Forms.CheckBox();
            this.m_ckFit = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cbBayerLayout = new System.Windows.Forms.ComboBox();
            this.m_cbPixelFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cbBayerConvert = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_edFPS = new System.Windows.Forms.TextBox();
            this.m_stcReceiveFrame = new System.Windows.Forms.Label();
            this.m_btnFpsApply = new System.Windows.Forms.Button();
            this.m_cb1394FPS = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_stcReceiveFps = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_btnPlay = new System.Windows.Forms.Button();
            this.m_btnStop = new System.Windows.Forms.Button();
            this.m_btnControl = new System.Windows.Forms.Button();
            this.m_btnFeature = new System.Windows.Forms.Button();
            this.m_btnCapture = new System.Windows.Forms.Button();
            this.m_btnTrigger = new System.Windows.Forms.Button();
            this.m_btnStrobe = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_btnStackedROI = new System.Windows.Forms.Button();
            this.m_btnATLLedControl = new System.Windows.Forms.Button();
            this.m_btnThermalControl = new System.Windows.Forms.Button();
            this.m_btnLUT = new System.Windows.Forms.Button();
            this.m_btnAutoFocus = new System.Windows.Forms.Button();
            this.m_btnUserSet = new System.Windows.Forms.Button();
            this.m_btnSIOControl = new System.Windows.Forms.Button();
            this.m_btnFrameSave = new System.Windows.Forms.Button();
            this.m_btnResolution = new System.Windows.Forms.Button();
            this.m_TimerReceiveFPS = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_btnShot = new System.Windows.Forms.Button();
            this.m_edMultiShotCnt = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.m_cbAcquisitionMode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_btnClearList = new System.Windows.Forms.Button();
            this.m_ckAutoScroll = new System.Windows.Forms.CheckBox();
            this.m_listLog = new System.Windows.Forms.ListView();
            this.m_TimerReceiveFrame = new System.Windows.Forms.Timer(this.components);
            this.CONTROL_PANEL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_stcDisplayWnd)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_edMultiShotCnt)).BeginInit();
            this.SuspendLayout();
            // 
            // m_stcDisplayWnd
            // 
            this.m_stcDisplayWnd.Location = new System.Drawing.Point(10, 13);
            this.m_stcDisplayWnd.Name = "m_stcDisplayWnd";
            this.m_stcDisplayWnd.Size = new System.Drawing.Size(411, 477);
            this.m_stcDisplayWnd.TabIndex = 0;
            this.m_stcDisplayWnd.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_btnRefresh);
            this.groupBox1.Controls.Add(this.m_cbCameraList);
            this.groupBox1.Location = new System.Drawing.Point(427, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera List";
            // 
            // m_btnRefresh
            // 
            this.m_btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("m_btnRefresh.Image")));
            this.m_btnRefresh.Location = new System.Drawing.Point(229, 20);
            this.m_btnRefresh.Name = "m_btnRefresh";
            this.m_btnRefresh.Size = new System.Drawing.Size(21, 24);
            this.m_btnRefresh.TabIndex = 1;
            this.m_btnRefresh.UseVisualStyleBackColor = true;
            this.m_btnRefresh.Click += new System.EventHandler(this.m_btnRefresh_Click);
            // 
            // m_cbCameraList
            // 
            this.m_cbCameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbCameraList.FormattingEnabled = true;
            this.m_cbCameraList.Location = new System.Drawing.Point(5, 22);
            this.m_cbCameraList.Name = "m_cbCameraList";
            this.m_cbCameraList.Size = new System.Drawing.Size(219, 21);
            this.m_cbCameraList.TabIndex = 0;
            this.m_cbCameraList.SelectedIndexChanged += new System.EventHandler(this.m_cbCameraList_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_ckMirror);
            this.groupBox2.Controls.Add(this.m_ckFlip);
            this.groupBox2.Controls.Add(this.m_ckFit);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.m_cbBayerLayout);
            this.groupBox2.Controls.Add(this.m_cbPixelFormat);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_cbBayerConvert);
            this.groupBox2.Location = new System.Drawing.Point(427, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 142);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image Control";
            // 
            // m_ckMirror
            // 
            this.m_ckMirror.AutoSize = true;
            this.m_ckMirror.Location = new System.Drawing.Point(201, 112);
            this.m_ckMirror.Name = "m_ckMirror";
            this.m_ckMirror.Size = new System.Drawing.Size(52, 17);
            this.m_ckMirror.TabIndex = 9;
            this.m_ckMirror.Text = "Mirror";
            this.m_ckMirror.UseVisualStyleBackColor = true;
            this.m_ckMirror.CheckedChanged += new System.EventHandler(this.m_ckMirror_CheckedChanged);
            // 
            // m_ckFlip
            // 
            this.m_ckFlip.AutoSize = true;
            this.m_ckFlip.Location = new System.Drawing.Point(151, 112);
            this.m_ckFlip.Name = "m_ckFlip";
            this.m_ckFlip.Size = new System.Drawing.Size(42, 17);
            this.m_ckFlip.TabIndex = 8;
            this.m_ckFlip.Text = "Flip";
            this.m_ckFlip.UseVisualStyleBackColor = true;
            this.m_ckFlip.CheckedChanged += new System.EventHandler(this.m_ckFlip_CheckedChanged);
            // 
            // m_ckFit
            // 
            this.m_ckFit.AutoSize = true;
            this.m_ckFit.Location = new System.Drawing.Point(106, 112);
            this.m_ckFit.Name = "m_ckFit";
            this.m_ckFit.Size = new System.Drawing.Size(37, 17);
            this.m_ckFit.TabIndex = 7;
            this.m_ckFit.Text = "Fit";
            this.m_ckFit.UseVisualStyleBackColor = true;
            this.m_ckFit.CheckedChanged += new System.EventHandler(this.m_ckFit_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Display Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bayer Layout";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bayer Convert";
            // 
            // m_cbBayerLayout
            // 
            this.m_cbBayerLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbBayerLayout.FormattingEnabled = true;
            this.m_cbBayerLayout.Location = new System.Drawing.Point(106, 81);
            this.m_cbBayerLayout.Name = "m_cbBayerLayout";
            this.m_cbBayerLayout.Size = new System.Drawing.Size(145, 21);
            this.m_cbBayerLayout.TabIndex = 5;
            this.m_cbBayerLayout.SelectedIndexChanged += new System.EventHandler(this.m_cbBayerLayout_SelectedIndexChanged);
            // 
            // m_cbPixelFormat
            // 
            this.m_cbPixelFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbPixelFormat.FormattingEnabled = true;
            this.m_cbPixelFormat.Location = new System.Drawing.Point(106, 25);
            this.m_cbPixelFormat.Name = "m_cbPixelFormat";
            this.m_cbPixelFormat.Size = new System.Drawing.Size(145, 21);
            this.m_cbPixelFormat.TabIndex = 1;
            this.m_cbPixelFormat.SelectedIndexChanged += new System.EventHandler(this.m_cbPixelFormat_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pixel Format";
            // 
            // m_cbBayerConvert
            // 
            this.m_cbBayerConvert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbBayerConvert.FormattingEnabled = true;
            this.m_cbBayerConvert.Location = new System.Drawing.Point(106, 53);
            this.m_cbBayerConvert.Name = "m_cbBayerConvert";
            this.m_cbBayerConvert.Size = new System.Drawing.Size(145, 21);
            this.m_cbBayerConvert.TabIndex = 3;
            this.m_cbBayerConvert.SelectedIndexChanged += new System.EventHandler(this.m_cbBayerConvert_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_edFPS);
            this.groupBox3.Controls.Add(this.m_stcReceiveFrame);
            this.groupBox3.Controls.Add(this.m_btnFpsApply);
            this.groupBox3.Controls.Add(this.m_cb1394FPS);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.m_stcReceiveFps);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(427, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 116);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Frame Rate";
            // 
            // m_edFPS
            // 
            this.m_edFPS.Location = new System.Drawing.Point(106, 81);
            this.m_edFPS.Name = "m_edFPS";
            this.m_edFPS.Size = new System.Drawing.Size(97, 20);
            this.m_edFPS.TabIndex = 8;
            // 
            // m_stcReceiveFrame
            // 
            this.m_stcReceiveFrame.AutoSize = true;
            this.m_stcReceiveFrame.Location = new System.Drawing.Point(190, 28);
            this.m_stcReceiveFrame.Name = "m_stcReceiveFrame";
            this.m_stcReceiveFrame.Size = new System.Drawing.Size(13, 13);
            this.m_stcReceiveFrame.TabIndex = 3;
            this.m_stcReceiveFrame.Text = "0";
            // 
            // m_btnFpsApply
            // 
            this.m_btnFpsApply.Location = new System.Drawing.Point(207, 53);
            this.m_btnFpsApply.Name = "m_btnFpsApply";
            this.m_btnFpsApply.Size = new System.Drawing.Size(43, 51);
            this.m_btnFpsApply.TabIndex = 6;
            this.m_btnFpsApply.Text = "Apply";
            this.m_btnFpsApply.UseVisualStyleBackColor = true;
            this.m_btnFpsApply.Click += new System.EventHandler(this.m_btnFpsApply_Click);
            // 
            // m_cb1394FPS
            // 
            this.m_cb1394FPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb1394FPS.FormattingEnabled = true;
            this.m_cb1394FPS.Location = new System.Drawing.Point(106, 53);
            this.m_cb1394FPS.Name = "m_cb1394FPS";
            this.m_cb1394FPS.Size = new System.Drawing.Size(97, 21);
            this.m_cb1394FPS.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "GigE && USB3:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "1394:";
            // 
            // m_stcReceiveFps
            // 
            this.m_stcReceiveFps.AutoSize = true;
            this.m_stcReceiveFps.Location = new System.Drawing.Point(106, 28);
            this.m_stcReceiveFps.Name = "m_stcReceiveFps";
            this.m_stcReceiveFps.Size = new System.Drawing.Size(28, 13);
            this.m_stcReceiveFps.TabIndex = 1;
            this.m_stcReceiveFps.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Receive FPS:";
            // 
            // m_btnPlay
            // 
            this.m_btnPlay.Location = new System.Drawing.Point(106, 23);
            this.m_btnPlay.Name = "m_btnPlay";
            this.m_btnPlay.Size = new System.Drawing.Size(64, 25);
            this.m_btnPlay.TabIndex = 1;
            this.m_btnPlay.Text = "Start";
            this.m_btnPlay.UseVisualStyleBackColor = true;
            this.m_btnPlay.Click += new System.EventHandler(this.m_btnPlay_Click);
            // 
            // m_btnStop
            // 
            this.m_btnStop.Location = new System.Drawing.Point(186, 23);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(64, 25);
            this.m_btnStop.TabIndex = 2;
            this.m_btnStop.Text = "Stop";
            this.m_btnStop.UseVisualStyleBackColor = true;
            this.m_btnStop.Click += new System.EventHandler(this.m_btnStop_Click);
            // 
            // m_btnControl
            // 
            this.m_btnControl.Location = new System.Drawing.Point(15, 26);
            this.m_btnControl.Name = "m_btnControl";
            this.m_btnControl.Size = new System.Drawing.Size(105, 25);
            this.m_btnControl.TabIndex = 0;
            this.m_btnControl.Text = "Control Dialog";
            this.m_btnControl.UseVisualStyleBackColor = true;
            this.m_btnControl.Click += new System.EventHandler(this.m_btnControl_Click);
            // 
            // m_btnFeature
            // 
            this.m_btnFeature.Location = new System.Drawing.Point(14, 63);
            this.m_btnFeature.Name = "m_btnFeature";
            this.m_btnFeature.Size = new System.Drawing.Size(105, 25);
            this.m_btnFeature.TabIndex = 1;
            this.m_btnFeature.Text = "Feature";
            this.m_btnFeature.UseVisualStyleBackColor = true;
            this.m_btnFeature.Click += new System.EventHandler(this.m_btnFeature_Click);
            // 
            // m_btnCapture
            // 
            this.m_btnCapture.Location = new System.Drawing.Point(14, 100);
            this.m_btnCapture.Name = "m_btnCapture";
            this.m_btnCapture.Size = new System.Drawing.Size(105, 25);
            this.m_btnCapture.TabIndex = 2;
            this.m_btnCapture.Text = "Capture";
            this.m_btnCapture.UseVisualStyleBackColor = true;
            this.m_btnCapture.Click += new System.EventHandler(this.m_btnCapture_Click);
            // 
            // m_btnTrigger
            // 
            this.m_btnTrigger.Location = new System.Drawing.Point(14, 174);
            this.m_btnTrigger.Name = "m_btnTrigger";
            this.m_btnTrigger.Size = new System.Drawing.Size(105, 25);
            this.m_btnTrigger.TabIndex = 5;
            this.m_btnTrigger.Text = "Trigger";
            this.m_btnTrigger.UseVisualStyleBackColor = true;
            this.m_btnTrigger.Click += new System.EventHandler(this.m_btnTrigger_Click);
            // 
            // m_btnStrobe
            // 
            this.m_btnStrobe.Location = new System.Drawing.Point(14, 211);
            this.m_btnStrobe.Name = "m_btnStrobe";
            this.m_btnStrobe.Size = new System.Drawing.Size(105, 25);
            this.m_btnStrobe.TabIndex = 6;
            this.m_btnStrobe.Text = "Strobe";
            this.m_btnStrobe.UseVisualStyleBackColor = true;
            this.m_btnStrobe.Click += new System.EventHandler(this.m_btnStrobe_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_btnStackedROI);
            this.groupBox4.Controls.Add(this.m_btnATLLedControl);
            this.groupBox4.Controls.Add(this.m_btnThermalControl);
            this.groupBox4.Controls.Add(this.m_btnLUT);
            this.groupBox4.Controls.Add(this.m_btnAutoFocus);
            this.groupBox4.Controls.Add(this.m_btnUserSet);
            this.groupBox4.Controls.Add(this.m_btnSIOControl);
            this.groupBox4.Controls.Add(this.m_btnFrameSave);
            this.groupBox4.Controls.Add(this.m_btnResolution);
            this.groupBox4.Controls.Add(this.m_btnFeature);
            this.groupBox4.Controls.Add(this.m_btnCapture);
            this.groupBox4.Controls.Add(this.m_btnControl);
            this.groupBox4.Controls.Add(this.m_btnStrobe);
            this.groupBox4.Controls.Add(this.m_btnTrigger);
            this.groupBox4.Location = new System.Drawing.Point(698, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(134, 547);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // m_btnStackedROI
            // 
            this.m_btnStackedROI.Location = new System.Drawing.Point(14, 509);
            this.m_btnStackedROI.Name = "m_btnStackedROI";
            this.m_btnStackedROI.Size = new System.Drawing.Size(105, 25);
            this.m_btnStackedROI.TabIndex = 15;
            this.m_btnStackedROI.Text = "Stacked ROI Control";
            this.m_btnStackedROI.UseVisualStyleBackColor = true;
            this.m_btnStackedROI.Click += new System.EventHandler(this.m_btnStackedROI_Click);
            // 
            // m_btnATLLedControl
            // 
            this.m_btnATLLedControl.Location = new System.Drawing.Point(15, 472);
            this.m_btnATLLedControl.Name = "m_btnATLLedControl";
            this.m_btnATLLedControl.Size = new System.Drawing.Size(105, 25);
            this.m_btnATLLedControl.TabIndex = 14;
            this.m_btnATLLedControl.Text = "ATL LED Control";
            this.m_btnATLLedControl.UseVisualStyleBackColor = true;
            this.m_btnATLLedControl.Click += new System.EventHandler(this.m_btnATLLedControl_Click);
            // 
            // m_btnThermalControl
            // 
            this.m_btnThermalControl.Location = new System.Drawing.Point(15, 433);
            this.m_btnThermalControl.Name = "m_btnThermalControl";
            this.m_btnThermalControl.Size = new System.Drawing.Size(105, 25);
            this.m_btnThermalControl.TabIndex = 13;
            this.m_btnThermalControl.Text = "Thermal Control";
            this.m_btnThermalControl.UseVisualStyleBackColor = true;
            this.m_btnThermalControl.Click += new System.EventHandler(this.m_btnThermalControl_Click);
            // 
            // m_btnLUT
            // 
            this.m_btnLUT.Location = new System.Drawing.Point(14, 358);
            this.m_btnLUT.Name = "m_btnLUT";
            this.m_btnLUT.Size = new System.Drawing.Size(105, 25);
            this.m_btnLUT.TabIndex = 10;
            this.m_btnLUT.Text = "Look Up Table";
            this.m_btnLUT.UseVisualStyleBackColor = true;
            this.m_btnLUT.Click += new System.EventHandler(this.m_btnLUT_Click);
            // 
            // m_btnAutoFocus
            // 
            this.m_btnAutoFocus.Location = new System.Drawing.Point(14, 248);
            this.m_btnAutoFocus.Name = "m_btnAutoFocus";
            this.m_btnAutoFocus.Size = new System.Drawing.Size(105, 25);
            this.m_btnAutoFocus.TabIndex = 7;
            this.m_btnAutoFocus.Text = "Auto Focus";
            this.m_btnAutoFocus.UseVisualStyleBackColor = true;
            this.m_btnAutoFocus.Click += new System.EventHandler(this.m_btnAutoFocus_Click);
            // 
            // m_btnUserSet
            // 
            this.m_btnUserSet.Location = new System.Drawing.Point(14, 285);
            this.m_btnUserSet.Name = "m_btnUserSet";
            this.m_btnUserSet.Size = new System.Drawing.Size(105, 25);
            this.m_btnUserSet.TabIndex = 8;
            this.m_btnUserSet.Text = "User Set";
            this.m_btnUserSet.UseVisualStyleBackColor = true;
            this.m_btnUserSet.Click += new System.EventHandler(this.m_btnUserSet_Click);
            // 
            // m_btnSIOControl
            // 
            this.m_btnSIOControl.Location = new System.Drawing.Point(14, 322);
            this.m_btnSIOControl.Name = "m_btnSIOControl";
            this.m_btnSIOControl.Size = new System.Drawing.Size(105, 25);
            this.m_btnSIOControl.TabIndex = 9;
            this.m_btnSIOControl.Text = "SIO Control";
            this.m_btnSIOControl.UseVisualStyleBackColor = true;
            this.m_btnSIOControl.Click += new System.EventHandler(this.m_btnSIOControl_Click);
            // 
            // m_btnFrameSave
            // 
            this.m_btnFrameSave.Location = new System.Drawing.Point(15, 395);
            this.m_btnFrameSave.Name = "m_btnFrameSave";
            this.m_btnFrameSave.Size = new System.Drawing.Size(105, 25);
            this.m_btnFrameSave.TabIndex = 11;
            this.m_btnFrameSave.Text = "1394 FrameSave";
            this.m_btnFrameSave.UseVisualStyleBackColor = true;
            this.m_btnFrameSave.Click += new System.EventHandler(this.m_btnFrameSave_Click);
            // 
            // m_btnResolution
            // 
            this.m_btnResolution.Location = new System.Drawing.Point(14, 137);
            this.m_btnResolution.Name = "m_btnResolution";
            this.m_btnResolution.Size = new System.Drawing.Size(105, 25);
            this.m_btnResolution.TabIndex = 4;
            this.m_btnResolution.Text = "Resolution";
            this.m_btnResolution.UseVisualStyleBackColor = true;
            this.m_btnResolution.Click += new System.EventHandler(this.m_btnResolution_Click);
            // 
            // m_TimerReceiveFPS
            // 
            this.m_TimerReceiveFPS.Enabled = true;
            this.m_TimerReceiveFPS.Interval = 1000;
            this.m_TimerReceiveFPS.Tick += new System.EventHandler(this.m_TimerReceiveFPS_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.m_btnShot);
            this.groupBox5.Controls.Add(this.m_edMultiShotCnt);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.m_cbAcquisitionMode);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.m_btnPlay);
            this.groupBox5.Controls.Add(this.m_btnStop);
            this.groupBox5.Location = new System.Drawing.Point(427, 347);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 146);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Acquisition";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "One/Multi Shot";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(191, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "(1 ~ 65535)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Multi-Shot Count";
            // 
            // m_btnShot
            // 
            this.m_btnShot.Location = new System.Drawing.Point(106, 108);
            this.m_btnShot.Name = "m_btnShot";
            this.m_btnShot.Size = new System.Drawing.Size(143, 25);
            this.m_btnShot.TabIndex = 9;
            this.m_btnShot.Text = "Shot";
            this.m_btnShot.UseVisualStyleBackColor = true;
            this.m_btnShot.Click += new System.EventHandler(this.m_btnShot_Click);
            // 
            // m_edMultiShotCnt
            // 
            this.m_edMultiShotCnt.Location = new System.Drawing.Point(106, 81);
            this.m_edMultiShotCnt.Name = "m_edMultiShotCnt";
            this.m_edMultiShotCnt.Size = new System.Drawing.Size(79, 20);
            this.m_edMultiShotCnt.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Acquisition Mode";
            // 
            // m_cbAcquisitionMode
            // 
            this.m_cbAcquisitionMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbAcquisitionMode.FormattingEnabled = true;
            this.m_cbAcquisitionMode.Location = new System.Drawing.Point(106, 53);
            this.m_cbAcquisitionMode.Name = "m_cbAcquisitionMode";
            this.m_cbAcquisitionMode.Size = new System.Drawing.Size(145, 21);
            this.m_cbAcquisitionMode.TabIndex = 4;
            this.m_cbAcquisitionMode.SelectedIndexChanged += new System.EventHandler(this.m_cbAcquisitionMode_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Acquisition State";
            // 
            // m_btnClearList
            // 
            this.m_btnClearList.Location = new System.Drawing.Point(713, 589);
            this.m_btnClearList.Name = "m_btnClearList";
            this.m_btnClearList.Size = new System.Drawing.Size(104, 25);
            this.m_btnClearList.TabIndex = 7;
            this.m_btnClearList.Text = "Clear";
            this.m_btnClearList.UseVisualStyleBackColor = true;
            this.m_btnClearList.Click += new System.EventHandler(this.m_btnClearList_Click);
            // 
            // m_ckAutoScroll
            // 
            this.m_ckAutoScroll.AutoSize = true;
            this.m_ckAutoScroll.Location = new System.Drawing.Point(726, 566);
            this.m_ckAutoScroll.Name = "m_ckAutoScroll";
            this.m_ckAutoScroll.Size = new System.Drawing.Size(77, 17);
            this.m_ckAutoScroll.TabIndex = 6;
            this.m_ckAutoScroll.Text = "Auto Scroll";
            this.m_ckAutoScroll.UseVisualStyleBackColor = true;
            this.m_ckAutoScroll.CheckedChanged += new System.EventHandler(this.m_ckAutoScroll_CheckedChanged);
            // 
            // m_listLog
            // 
            this.m_listLog.HideSelection = false;
            this.m_listLog.Location = new System.Drawing.Point(10, 499);
            this.m_listLog.MultiSelect = false;
            this.m_listLog.Name = "m_listLog";
            this.m_listLog.Size = new System.Drawing.Size(673, 160);
            this.m_listLog.TabIndex = 8;
            this.m_listLog.UseCompatibleStateImageBehavior = false;
            this.m_listLog.View = System.Windows.Forms.View.Details;
            // 
            // m_TimerReceiveFrame
            // 
            this.m_TimerReceiveFrame.Tick += new System.EventHandler(this.m_TimerReceiveFrame_Tick);
            // 
            // CONTROL_PANEL
            // 
            this.CONTROL_PANEL.BackColor = System.Drawing.Color.SpringGreen;
            this.CONTROL_PANEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONTROL_PANEL.Location = new System.Drawing.Point(698, 625);
            this.CONTROL_PANEL.Name = "CONTROL_PANEL";
            this.CONTROL_PANEL.Size = new System.Drawing.Size(137, 34);
            this.CONTROL_PANEL.TabIndex = 14;
            this.CONTROL_PANEL.Text = "CONTROL PANEL";
            this.CONTROL_PANEL.UseVisualStyleBackColor = false;
            this.CONTROL_PANEL.Click += new System.EventHandler(this.CONTROL_PANEL_Click);
            // 
            // NeptuneCSampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 669);
            this.Controls.Add(this.CONTROL_PANEL);
            this.Controls.Add(this.m_listLog);
            this.Controls.Add(this.m_ckAutoScroll);
            this.Controls.Add(this.m_btnClearList);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_stcDisplayWnd);
            this.Name = "NeptuneCSampleForm";
            this.Text = "NeptuneCSample_CShrap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NeptuneCSample_FormClosing);
            this.Load += new System.EventHandler(this.NeptuneCSample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_stcDisplayWnd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_edMultiShotCnt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_stcDisplayWnd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button m_btnRefresh;
        private System.Windows.Forms.ComboBox m_cbCameraList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox m_ckFit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cbBayerLayout;
        private System.Windows.Forms.ComboBox m_cbPixelFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cbBayerConvert;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button m_btnFpsApply;
        private System.Windows.Forms.TextBox m_edFPS;
        private System.Windows.Forms.ComboBox m_cb1394FPS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label m_stcReceiveFps;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button m_btnPlay;
        private System.Windows.Forms.Button m_btnStop;
        private System.Windows.Forms.Button m_btnControl;
        private System.Windows.Forms.CheckBox m_ckMirror;
        private System.Windows.Forms.CheckBox m_ckFlip;
        private System.Windows.Forms.Button m_btnFeature;
        private System.Windows.Forms.Button m_btnCapture;
        private System.Windows.Forms.Button m_btnTrigger;
        private System.Windows.Forms.Button m_btnStrobe;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Timer m_TimerReceiveFPS;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button m_btnClearList;
        private System.Windows.Forms.CheckBox m_ckAutoScroll;
        private System.Windows.Forms.Button m_btnUserSet;
        private System.Windows.Forms.Button m_btnLUT;
        private System.Windows.Forms.Button m_btnSIOControl;
        private System.Windows.Forms.Button m_btnFrameSave;
        private System.Windows.Forms.Button m_btnAutoFocus;
        private System.Windows.Forms.Button m_btnResolution;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button m_btnShot;
        private System.Windows.Forms.NumericUpDown m_edMultiShotCnt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox m_cbAcquisitionMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView m_listLog;
        private System.Windows.Forms.Label m_stcReceiveFrame;
        private System.Windows.Forms.Timer m_TimerReceiveFrame;
        private System.Windows.Forms.Button m_btnThermalControl;
        private System.Windows.Forms.Button m_btnATLLedControl;
        private System.Windows.Forms.Button m_btnStackedROI;
        private System.Windows.Forms.Button CONTROL_PANEL;
    }
}

