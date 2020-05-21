namespace DG.MiniHTMLTextBox
{
    partial class MiniHTMLTextBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip_actions = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_undo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_redo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox_fontname = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox_fontsize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_cut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_copy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_paste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_bold = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_italic = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_underline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_left = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_center = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_right = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_justify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_orderedlist = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_bulletlist = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_horizontalrule = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_outdent = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_indent = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_viewmode = new System.Windows.Forms.ToolStripButton();
            this.splipContainer_text = new System.Windows.Forms.SplitContainer();
            this.htmlTextBox = new System.Windows.Forms.WebBrowser();
            this.plainTextBox = new System.Windows.Forms.TextBox();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.toolStrip_actions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splipContainer_text)).BeginInit();
            this.splipContainer_text.Panel1.SuspendLayout();
            this.splipContainer_text.Panel2.SuspendLayout();
            this.splipContainer_text.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_actions
            // 
            this.toolStrip_actions.AutoSize = false;
            this.toolStrip_actions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_actions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_undo,
            this.toolStripButton_redo,
            this.toolStripSeparator8,
            this.toolStripComboBox_fontname,
            this.toolStripComboBox_fontsize,
            this.toolStripSeparator1,
            this.toolStripButton_cut,
            this.toolStripButton_copy,
            this.toolStripButton_paste,
            this.toolStripSeparator2,
            this.toolStripButton_bold,
            this.toolStripButton_italic,
            this.toolStripButton_underline,
            this.toolStripSeparator3,
            this.toolStripButton_left,
            this.toolStripButton_center,
            this.toolStripButton_right,
            this.toolStripButton_justify,
            this.toolStripSeparator7,
            this.toolStripButton_orderedlist,
            this.toolStripButton_bulletlist,
            this.toolStripSeparator4,
            this.toolStripButton_horizontalrule,
            this.toolStripSeparator6,
            this.toolStripButton_outdent,
            this.toolStripButton_indent,
            this.toolStripSeparator5,
            this.toolStripButton_viewmode});
            this.toolStrip_actions.Location = new System.Drawing.Point(1, 1);
            this.toolStrip_actions.Name = "toolStrip_actions";
            this.toolStrip_actions.Size = new System.Drawing.Size(398, 25);
            this.toolStrip_actions.TabIndex = 1;
            this.toolStrip_actions.Text = "toolStripMain";
            // 
            // toolStripButton_undo
            // 
            this.toolStripButton_undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_undo.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_undo;
            this.toolStripButton_undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_undo.Name = "toolStripButton_undo";
            this.toolStripButton_undo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_undo.Text = "Undo";
            this.toolStripButton_undo.Click += new System.EventHandler(this.toolStripButton_undo_Click);
            // 
            // toolStripButton_redo
            // 
            this.toolStripButton_redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_redo.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_redo;
            this.toolStripButton_redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_redo.Name = "toolStripButton_redo";
            this.toolStripButton_redo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_redo.Text = "Redo";
            this.toolStripButton_redo.Click += new System.EventHandler(this.toolStripButton_redo_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBox_fontname
            // 
            this.toolStripComboBox_fontname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_fontname.Name = "toolStripComboBox_fontname";
            this.toolStripComboBox_fontname.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox_fontname.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_fontname_SelectedIndexChanged);
            this.toolStripComboBox_fontname.Leave += new System.EventHandler(this.toolStripComboBox_fontname_Leave);
            this.toolStripComboBox_fontname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripComboBox_fontname_KeyDown);
            // 
            // toolStripComboBox_fontsize
            // 
            this.toolStripComboBox_fontsize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_fontsize.DropDownWidth = 75;
            this.toolStripComboBox_fontsize.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.toolStripComboBox_fontsize.Name = "toolStripComboBox_fontsize";
            this.toolStripComboBox_fontsize.Size = new System.Drawing.Size(75, 25);
            this.toolStripComboBox_fontsize.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_fontsize_SelectedIndexChanged);
            this.toolStripComboBox_fontsize.Leave += new System.EventHandler(this.toolStripComboBox_fontsize_Leave);
            this.toolStripComboBox_fontsize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripComboBox_fontsize_KeyDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_cut
            // 
            this.toolStripButton_cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_cut.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_cut;
            this.toolStripButton_cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_cut.Name = "toolStripButton_cut";
            this.toolStripButton_cut.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_cut.Text = "Cut";
            this.toolStripButton_cut.Click += new System.EventHandler(this.toolStripButton_cut_Click);
            // 
            // toolStripButton_copy
            // 
            this.toolStripButton_copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_copy.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_copy;
            this.toolStripButton_copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_copy.Name = "toolStripButton_copy";
            this.toolStripButton_copy.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_copy.Text = "Copy";
            this.toolStripButton_copy.Click += new System.EventHandler(this.toolStripButton_copy_Click);
            // 
            // toolStripButton_paste
            // 
            this.toolStripButton_paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_paste.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_paste;
            this.toolStripButton_paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_paste.Name = "toolStripButton_paste";
            this.toolStripButton_paste.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_paste.Text = "Paste";
            this.toolStripButton_paste.Click += new System.EventHandler(this.toolStripButton_paste_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_bold
            // 
            this.toolStripButton_bold.CheckOnClick = true;
            this.toolStripButton_bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_bold.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_bold;
            this.toolStripButton_bold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_bold.Name = "toolStripButton_bold";
            this.toolStripButton_bold.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_bold.Text = "Bold";
            this.toolStripButton_bold.Click += new System.EventHandler(this.toolStripButton_bold_Click);
            // 
            // toolStripButton_italic
            // 
            this.toolStripButton_italic.CheckOnClick = true;
            this.toolStripButton_italic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_italic.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_italic;
            this.toolStripButton_italic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_italic.Name = "toolStripButton_italic";
            this.toolStripButton_italic.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_italic.Text = "Italic";
            this.toolStripButton_italic.Click += new System.EventHandler(this.toolStripButton_italic_Click);
            // 
            // toolStripButton_underline
            // 
            this.toolStripButton_underline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_underline.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_underline;
            this.toolStripButton_underline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_underline.Name = "toolStripButton_underline";
            this.toolStripButton_underline.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_underline.Text = "Underline";
            this.toolStripButton_underline.Click += new System.EventHandler(this.toolStripButton_underline_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_left
            // 
            this.toolStripButton_left.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_left.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_left;
            this.toolStripButton_left.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_left.Name = "toolStripButton_left";
            this.toolStripButton_left.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_left.Text = "Left";
            this.toolStripButton_left.Click += new System.EventHandler(this.toolStripButton_left_Click);
            // 
            // toolStripButton_center
            // 
            this.toolStripButton_center.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_center.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_center;
            this.toolStripButton_center.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_center.Name = "toolStripButton_center";
            this.toolStripButton_center.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_center.Text = "Center";
            this.toolStripButton_center.Click += new System.EventHandler(this.toolStripButton_center_Click);
            // 
            // toolStripButton_right
            // 
            this.toolStripButton_right.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_right.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_right;
            this.toolStripButton_right.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_right.Name = "toolStripButton_right";
            this.toolStripButton_right.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_right.Text = "Right";
            this.toolStripButton_right.Click += new System.EventHandler(this.toolStripButton_right_Click);
            // 
            // toolStripButton_justify
            // 
            this.toolStripButton_justify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_justify.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_justify;
            this.toolStripButton_justify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_justify.Name = "toolStripButton_justify";
            this.toolStripButton_justify.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_justify.Text = "Justify";
            this.toolStripButton_justify.Click += new System.EventHandler(this.toolStripButton_justify_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_orderedlist
            // 
            this.toolStripButton_orderedlist.CheckOnClick = true;
            this.toolStripButton_orderedlist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_orderedlist.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_orderedlist;
            this.toolStripButton_orderedlist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_orderedlist.Name = "toolStripButton_orderedlist";
            this.toolStripButton_orderedlist.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_orderedlist.Text = "Ordered list";
            this.toolStripButton_orderedlist.Click += new System.EventHandler(this.toolStripButton_orderedlist_Click);
            // 
            // toolStripButton_bulletlist
            // 
            this.toolStripButton_bulletlist.CheckOnClick = true;
            this.toolStripButton_bulletlist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_bulletlist.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_bulletlist;
            this.toolStripButton_bulletlist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_bulletlist.Name = "toolStripButton_bulletlist";
            this.toolStripButton_bulletlist.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_bulletlist.Text = "Bullet List";
            this.toolStripButton_bulletlist.Click += new System.EventHandler(this.toolStripButton_bulletlist_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_horizontalrule
            // 
            this.toolStripButton_horizontalrule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_horizontalrule.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_horizontalrule;
            this.toolStripButton_horizontalrule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_horizontalrule.Name = "toolStripButton_horizontalrule";
            this.toolStripButton_horizontalrule.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_horizontalrule.Text = "Horizontal Rule";
            this.toolStripButton_horizontalrule.Click += new System.EventHandler(this.toolStripButton_horizontalrule_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_outdent
            // 
            this.toolStripButton_outdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_outdent.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_outdent;
            this.toolStripButton_outdent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_outdent.Name = "toolStripButton_outdent";
            this.toolStripButton_outdent.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_outdent.Text = "Outdent";
            this.toolStripButton_outdent.Click += new System.EventHandler(this.toolStripButton_outdent_Click);
            // 
            // toolStripButton_indent
            // 
            this.toolStripButton_indent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_indent.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_indent;
            this.toolStripButton_indent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_indent.Name = "toolStripButton_indent";
            this.toolStripButton_indent.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_indent.Text = "Indent";
            this.toolStripButton_indent.Click += new System.EventHandler(this.toolStripButton_indent_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_viewmode
            // 
            this.toolStripButton_viewmode.CheckOnClick = true;
            this.toolStripButton_viewmode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_viewmode.Image = global::DG.MiniHTMLTextBox.Properties.Resources.icon_code;
            this.toolStripButton_viewmode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_viewmode.Name = "toolStripButton_viewmode";
            this.toolStripButton_viewmode.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_viewmode.Text = "View/Edit Html code";
            this.toolStripButton_viewmode.CheckedChanged += new System.EventHandler(this.toolStripButton_viewmode_CheckedChanged);
            // 
            // splipContainer_text
            // 
            this.splipContainer_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splipContainer_text.Location = new System.Drawing.Point(1, 26);
            this.splipContainer_text.Name = "splipContainer_text";
            this.splipContainer_text.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splipContainer_text.Panel1
            // 
            this.splipContainer_text.Panel1.Controls.Add(this.htmlTextBox);
            // 
            // splipContainer_text.Panel2
            // 
            this.splipContainer_text.Panel2.Controls.Add(this.plainTextBox);
            this.splipContainer_text.Panel2Collapsed = true;
            this.splipContainer_text.Size = new System.Drawing.Size(398, 173);
            this.splipContainer_text.SplitterDistance = 148;
            this.splipContainer_text.TabIndex = 0;
            // 
            // htmlTextBox
            // 
            this.htmlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlTextBox.Location = new System.Drawing.Point(0, 0);
            this.htmlTextBox.MinimumSize = new System.Drawing.Size(20, 20);
            this.htmlTextBox.Name = "htmlTextBox";
            this.htmlTextBox.Size = new System.Drawing.Size(398, 173);
            this.htmlTextBox.TabIndex = 0;
            this.htmlTextBox.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.htmlTextBox_DocumentCompleted);
            // 
            // plainTextBox
            // 
            this.plainTextBox.AcceptsReturn = true;
            this.plainTextBox.AcceptsTab = true;
            this.plainTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plainTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plainTextBox.Location = new System.Drawing.Point(0, 0);
            this.plainTextBox.Multiline = true;
            this.plainTextBox.Name = "plainTextBox";
            this.plainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.plainTextBox.Size = new System.Drawing.Size(150, 46);
            this.plainTextBox.TabIndex = 1;
            this.plainTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.plainTextBox_KeyDown);
            this.plainTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.plainTextBox_KeyPress);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Interval = 1000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // MiniHTMLTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splipContainer_text);
            this.Controls.Add(this.toolStrip_actions);
            this.Name = "MiniHTMLTextBox";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(400, 200);
            this.toolStrip_actions.ResumeLayout(false);
            this.toolStrip_actions.PerformLayout();
            this.splipContainer_text.Panel1.ResumeLayout(false);
            this.splipContainer_text.Panel2.ResumeLayout(false);
            this.splipContainer_text.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splipContainer_text)).EndInit();
            this.splipContainer_text.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_actions;
        private System.Windows.Forms.SplitContainer splipContainer_text;
        private System.Windows.Forms.Timer timerUpdate;
        internal System.Windows.Forms.WebBrowser htmlTextBox;
        internal System.Windows.Forms.TextBox plainTextBox;
        private System.Windows.Forms.ToolStripButton toolStripButton_viewmode;
        private System.Windows.Forms.ToolStripButton toolStripButton_cut;
        private System.Windows.Forms.ToolStripButton toolStripButton_copy;
        private System.Windows.Forms.ToolStripButton toolStripButton_paste;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_fontsize;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_fontname;
        private System.Windows.Forms.ToolStripButton toolStripButton_bold;
        private System.Windows.Forms.ToolStripButton toolStripButton_orderedlist;
        private System.Windows.Forms.ToolStripButton toolStripButton_bulletlist;
        private System.Windows.Forms.ToolStripButton toolStripButton_outdent;
        private System.Windows.Forms.ToolStripButton toolStripButton_indent;
        private System.Windows.Forms.ToolStripButton toolStripButton_italic;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_horizontalrule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton_undo;
        private System.Windows.Forms.ToolStripButton toolStripButton_redo;
        private System.Windows.Forms.ToolStripButton toolStripButton_underline;
        private System.Windows.Forms.ToolStripButton toolStripButton_left;
        private System.Windows.Forms.ToolStripButton toolStripButton_center;
        private System.Windows.Forms.ToolStripButton toolStripButton_right;
        private System.Windows.Forms.ToolStripButton toolStripButton_justify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}
