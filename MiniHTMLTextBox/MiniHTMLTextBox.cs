#region License
// Mini HTML TextBox
//
// Copyright (c), 2020 Davide Gironi <davide.gironi@gmail.com>
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DG.MiniHTMLTextBox
{

    public partial class MiniHTMLTextBox : UserControl
    {
        /// <summary>
        /// Available view modes
        /// </summary>
        public enum ViewModeType { HTML, Text }

        /// <summary>
        /// Update the binding sources OnLeave
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        [Category("MiniHTMLTextBox")]
        public bool WriteBindingSourceValueOnLeave { get; set; } = true;

        /// <summary>
        /// Reference to the htmlTextBox.htm div element
        /// </summary>
        private const string _Id = "htmltextbox";

        /// <summary>
        /// Check if htmlTextBox has to trigger the focus
        /// </summary>
        private bool _htmlTextBoxTriggerFocus = true;

        /// <summary>
        /// Check if htmlTextBox is loaded
        /// </summary>
        private bool IsHtmlTextBoxLoaded { get; set; } = false;

        /// <summary>
        /// Undo list for plainTextBox
        /// </summary>
        private Stack<string> plainTextBoxUndolist = new Stack<string>();

        /// <summary>
        /// Prenvet an event to be triggered
        /// </summary>
        private bool _preventEventTriggering = false;

        /// <summary>
        /// Default action bar row height
        /// </summary>
        private const int ToolStripActionsRowsHeight = 25;

        /// <summary>
        /// Illegal patterns
        /// </summary>
        private string[] _illegalPatterns = IllegalPatternsDefault;

        /// <summary>
        /// Default illegal patterns
        /// </summary>
        private static string[] IllegalPatternsDefault = new string[] {
                @"<script.*?>",
                @"<\w+\s+.*?(j|java|vb|ecma)script:.*?>",
                @"<\w+(\s+|\s+.*?\s+)on\w+\s*=.+?>",
                @"</?input.*?>" };

        /// <summary>
        /// Set the view mode default value
        /// </summary>
        private ViewModeType _viewMode = ViewModeType.HTML;

        /// <summary>
        /// Set the readonly default value
        /// </summary>
        private bool _readOnly = false;

        /// <summary>
        /// Number of rows for the action bar default value
        /// </summary>
        private int _actionBarRows = 1;

        /// <summary>
        /// Actions Undo and Redo visibility default value
        /// </summary>
        private bool _actionsUndoRedoVisible = true;

        /// <summary>
        /// Actions Cut Copy Paste visibility default value
        /// </summary>
        private bool _actionsCutCopyPasteVisible = true;

        /// <summary>
        /// Actions font Name and Size visibility default value
        /// </summary>
        private bool _actionsFontVisible = true;

        /// <summary>
        /// Actions font style visibility default value
        /// </summary>
        private bool _actionsFontStyleVisible = true;

        /// <summary>
        /// Actions text justification visibility default value
        /// </summary>
        private bool _actionsJustifyTextVisible = true;

        /// <summary>
        /// Actions Ordered and Bullet List visibility default value
        /// </summary>
        private bool _actionsListsVisible = true;

        /// <summary>
        /// Actions Indent Outdent visibility default value
        /// </summary>
        private bool _actionsIndentOutdentVisible = true;

        /// <summary>
        /// Actions HorizonalRule visibility default value
        /// </summary>
        private bool _actionsHorizonalRuleVisible = true;

        /// <summary>
        /// Actions ViewMode visibility default value
        /// </summary>
        private bool _actionsViewModeVisible = true;

        /// <summary>
        /// Constructor
        /// </summary>
        public MiniHTMLTextBox()
        {
            InitializeComponent();

            //reload font
            toolStripComboBox_fontname.Items.Clear();
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            toolStripComboBox_fontname.Items.AddRange(installedFontCollection.Families.Select(r => r.Name).Distinct().ToArray());

            //set main content
            htmlTextBox.DocumentText = Properties.Resources.htmlContent;
            htmlTextBox.Focus();
        }


        #region View mode

        /// <summary>
        /// Set the view mode
        /// </summary>
        [DefaultValue(typeof(ViewModeType), "HTML")]
        [Category("MiniHTMLTextBox")]
        public ViewModeType ViewMode
        {
            get { return _viewMode; }
            set
            {
                _viewMode = value;
                HandleViewMode();
            }
        }

        /// <summary>
        /// Handle view mode change
        /// </summary>
        private void HandleViewMode()
        {
            if (ViewMode == ViewModeType.HTML)
            {
                splipContainer_text.Panel1Collapsed = false;
                splipContainer_text.Panel2Collapsed = true;

                toolStripButton_viewmode.Checked = false;

                WaitUntilHtmlTextBoxLoaded();
                HtmlText = PlainText;
                htmlTextBox.Focus();
            }
            else if (ViewMode == ViewModeType.Text)
            {
                splipContainer_text.Panel1Collapsed = true;
                splipContainer_text.Panel2Collapsed = false;

                toolStripButton_viewmode.Checked = true;

                PlainText = HtmlText;
                plainTextBox.Focus();
            }

            //set read only
            plainTextBox.ReadOnly = _readOnly;
            htmlTextBox.Document.All[_Id].SetAttribute("contenteditable", (!_readOnly).ToString());

            //enable or disable actions
            if (!_readOnly)
            {
                toolStripButton_undo.Enabled = true;
                toolStripButton_redo.Enabled = true;
                toolStripButton_cut.Enabled = true;
                toolStripButton_copy.Enabled = true;
                toolStripButton_paste.Enabled = true;
                toolStripButton_bold.Enabled = !toolStripButton_viewmode.Checked;
                toolStripButton_italic.Enabled = !toolStripButton_viewmode.Checked;
                toolStripButton_underline.Enabled = !toolStripButton_viewmode.Checked;
                toolStripComboBox_fontname.Enabled = !toolStripButton_viewmode.Checked;
                toolStripComboBox_fontsize.Enabled = !toolStripButton_viewmode.Checked;
                toolStripButton_orderedlist.Enabled = !toolStripButton_viewmode.Checked;
                toolStripButton_bulletlist.Enabled = !toolStripButton_viewmode.Checked;
                toolStripButton_indent.Enabled = !toolStripButton_viewmode.Checked;
                toolStripButton_outdent.Enabled = !toolStripButton_viewmode.Checked;
                toolStripButton_horizontalrule.Enabled = !toolStripButton_viewmode.Checked;
                toolStripButton_left.Enabled = !toolStripButton_viewmode.Checked;
                toolStripButton_center.Enabled = !toolStripButton_viewmode.Checked;
                toolStripButton_right.Enabled = !toolStripButton_viewmode.Checked;
                toolStripButton_justify.Enabled = !toolStripButton_viewmode.Checked;
                toolStripButton_viewmode.Enabled = true;
            }
            else
            {
                toolStripButton_undo.Enabled = false;
                toolStripButton_redo.Enabled = false;
                toolStripButton_cut.Enabled = false;
                toolStripButton_copy.Enabled = true;
                toolStripButton_paste.Enabled = false;
                toolStripButton_bold.Enabled = false;
                toolStripButton_italic.Enabled = false;
                toolStripButton_underline.Enabled = false;
                toolStripComboBox_fontname.Enabled = false;
                toolStripComboBox_fontsize.Enabled = false;
                toolStripButton_orderedlist.Enabled = false;
                toolStripButton_bulletlist.Enabled = false;
                toolStripButton_indent.Enabled = false;
                toolStripButton_outdent.Enabled = false;
                toolStripButton_horizontalrule.Enabled = false;
                toolStripButton_left.Enabled = false;
                toolStripButton_center.Enabled = false;
                toolStripButton_right.Enabled = false;
                toolStripButton_justify.Enabled = false;
                toolStripButton_viewmode.Enabled = true;
            }
        }

        /// <summary>
        /// View mode changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_viewmode_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripButton_viewmode.Checked)
                _viewMode = ViewModeType.Text;
            else
                _viewMode = ViewModeType.HTML;

            HandleViewMode();
        }

        #endregion


        #region Plain/Html text

        /// <summary>
        /// Set component text
        /// </summary>
        [Category("Appearance")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(BindableSupport.Yes)]
        public override string Text
        {
            get
            {
                if (TextMode == ViewModeType.HTML)
                    return HtmlText;
                else
                    return PlainText;
            }
            set
            {
                HtmlText = value;
                PlainText = value;
            }
        }

        /// <summary>
        /// Set the get Text mode
        /// </summary>
        [DefaultValue(typeof(ViewModeType), "HTML")]
        [Category("MiniHTMLTextBox")]
        public ViewModeType TextMode { get; set; } = ViewModeType.HTML;

        /// <summary>
        /// Text changed hanlder
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new event EventHandler TextChanged
        {
            add
            {
                base.TextChanged += value;
            }
            remove
            {
                base.TextChanged -= value;
            }
        }

        /// <summary>
        /// Get or set Html text
        /// </summary>
        private string HtmlText
        {
            get
            {
                WaitUntilHtmlTextBoxLoaded();
                return SanitizeHtml(htmlTextBox.Document.All[_Id].InnerHtml);
            }
            set
            {
                if (!IsHtmlTextBoxLoaded) return;
                htmlTextBox.Document.All[_Id].InnerHtml = value;
            }
        }

        /// <summary>
        /// Get or set PlainText
        /// </summary>
        private string PlainText
        {
            get
            {
                return SanitizeHtml(plainTextBox.Text);
            }
            set
            {
                if (value != plainTextBox.Text)
                    plainTextBox.Text = value;
            }
        }

        /// <summary>
        /// Illegal patterns setter
        /// </summary>
        [Category("MiniHTMLTextBox")]
        public string[] IllegalPatterns
        {
            get { return _illegalPatterns; }
            set
            {
                if (value != null && value.Length > 0)
                    _illegalPatterns = value;
                else
                    _illegalPatterns = IllegalPatternsDefault;
                _illegalPatterns = _illegalPatterns.Distinct().ToArray();
            }
        }

        /// <summary>
        /// Sanitize HTML
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string SanitizeHtml(string text)
        {
            if (String.IsNullOrEmpty(text))
                return text;
            string ret = text;
            foreach (string pattern in IllegalPatterns)
            {
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
                ret = regex.Replace(ret, String.Empty);
            }
            return ret;
        }

        /// <summary>
        /// Plain TextBox KeyDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plainTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.U && Control.ModifierKeys == Keys.Control && plainTextBoxUndolist.Count > 0)
                plainTextBoxUndolist.Pop();
        }

        /// <summary>
        /// Plain TextBox KeyPress event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plainTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 'u' || Control.ModifierKeys != Keys.Control)
            {
                TextBox textBox = (TextBox)sender;
                plainTextBoxUndolist.Push(textBox.Text);
            }
        }
        #endregion


        #region Timed events

        /// <summary>
        /// Update timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (!(IsHtmlTextBoxLoaded && htmlTextBox.Focused))
                return;
            if (IsDisposed)
                return;

            //check focus
            HandleFocusChanged();

            _preventEventTriggering = true;

            //update action buttons status
            toolStripButton_bold.Checked = (bool)htmlTextBox.Document.InvokeScript("IsBold");
            toolStripButton_italic.Checked = (bool)htmlTextBox.Document.InvokeScript("IsItalic");
            toolStripButton_underline.Checked = (bool)htmlTextBox.Document.InvokeScript("IsUnderline");
            toolStripButton_orderedlist.Checked = (bool)htmlTextBox.Document.InvokeScript("IsOrderedList");
            toolStripButton_bulletlist.Checked = (bool)htmlTextBox.Document.InvokeScript("IsBulletList");
            toolStripButton_left.Checked = (bool)htmlTextBox.Document.InvokeScript("IsLeft");
            toolStripButton_center.Checked = (bool)htmlTextBox.Document.InvokeScript("IsCenter");
            toolStripButton_right.Checked = (bool)htmlTextBox.Document.InvokeScript("IsRight");
            toolStripButton_justify.Checked = (bool)htmlTextBox.Document.InvokeScript("IsJustify");
            if (!toolStripComboBox_fontname.Focused)
                toolStripComboBox_fontname.Text = (htmlTextBox.Document.InvokeScript("GetFontName") ?? String.Empty).ToString();
            if (!toolStripComboBox_fontsize.Focused)
                toolStripComboBox_fontsize.Text = htmlTextBox.Document.InvokeScript("GetFontSize").ToString();

            _preventEventTriggering = false;
        }

        #endregion


        #region Apparence

        /// <summary>
        /// Number of rows for the action bar
        /// </summary>
        [DefaultValue(typeof(int), "1")]
        [Category("MiniHTMLTextBox")]
        public int ActionBarRows
        {
            get { return _actionBarRows; }
            set
            {
                _actionBarRows = value;
                if (value > 1)
                {
                    toolStrip_actions.Height = _actionBarRows * (ToolStripActionsRowsHeight - 2);
                    toolStrip_actions.LayoutStyle = ToolStripLayoutStyle.Flow;
                }
                else
                {
                    toolStrip_actions.Height = ToolStripActionsRowsHeight;
                    toolStrip_actions.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                }

            }
        }

        /// <summary>
        /// Actions Undo and Redo visibility
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        [Category("MiniHTMLTextBox")]
        public bool ActionsUndoRedoVisible
        {
            get { return _actionsUndoRedoVisible; }
            set
            {
                _actionsUndoRedoVisible = value;
                toolStripButton_undo.Visible = value;
                toolStripButton_redo.Visible = value;
                toolStripSeparator8.Visible = false;
            }
        }

        /// <summary>
        /// Actions Cut Copy Paste visibility
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        [Category("MiniHTMLTextBox")]
        public bool ActionsCutCopyPasteRedoVisible
        {
            get { return _actionsCutCopyPasteVisible; }
            set
            {
                _actionsCutCopyPasteVisible = value;
                toolStripButton_cut.Visible = value;
                toolStripButton_copy.Visible = value;
                toolStripButton_paste.Visible = value;
                toolStripSeparator2.Visible = false;
            }
        }

        /// <summary>
        /// Actions font Name and Size visibility
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        [Category("MiniHTMLTextBox")]
        public bool ActionsFontVisible
        {
            get { return _actionsFontVisible; }
            set
            {
                _actionsFontVisible = value;
                toolStripComboBox_fontname.Visible = value;
                toolStripComboBox_fontsize.Visible = value;
                toolStripSeparator1.Visible = false;
            }
        }

        /// <summary>
        /// Actions font style visibility
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        [Category("MiniHTMLTextBox")]
        public bool ActionsFontStyleVisible
        {
            get { return _actionsFontStyleVisible; }
            set
            {
                _actionsFontStyleVisible = value;
                toolStripButton_bold.Visible = value;
                toolStripButton_italic.Visible = value;
                toolStripButton_underline.Visible = value;
                toolStripSeparator3.Visible = false;
            }
        }

        /// <summary>
        /// Actions text justification visibility
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        [Category("MiniHTMLTextBox")]
        public bool ActionsJustifyTextVisible
        {
            get { return _actionsJustifyTextVisible; }
            set
            {
                _actionsJustifyTextVisible = value;
                toolStripButton_left.Visible = value;
                toolStripButton_center.Visible = value;
                toolStripButton_right.Visible = value;
                toolStripButton_justify.Visible = value;
                toolStripSeparator7.Visible = false;
            }
        }

        /// <summary>
        /// Actions Ordered and Bullet List visibility
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        [Category("MiniHTMLTextBox")]
        public bool ActionsListsVisible
        {
            get { return _actionsListsVisible; }
            set
            {
                _actionsListsVisible = value;
                toolStripButton_orderedlist.Visible = value;
                toolStripButton_bulletlist.Visible = value;
                toolStripSeparator4.Visible = false;
            }
        }

        /// <summary>
        /// Actions Indent Outdent visibility
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        [Category("MiniHTMLTextBox")]
        public bool ActionsIndentOutdentVisible
        {
            get { return _actionsIndentOutdentVisible; }
            set
            {
                _actionsIndentOutdentVisible = value;
                toolStripButton_outdent.Visible = value;
                toolStripButton_indent.Visible = value;
                toolStripSeparator5.Visible = false;
            }
        }

        /// <summary>
        /// Actions HorizonalRule visibility
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        [Category("MiniHTMLTextBox")]
        public bool ActionsHorizonalRuleVisible
        {
            get { return _actionsHorizonalRuleVisible; }
            set
            {
                _actionsHorizonalRuleVisible = value;
                toolStripButton_horizontalrule.Visible = value;
                toolStripSeparator6.Visible = false;
            }
        }

        /// <summary>
        /// Actions ViewMode visibility
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        [Category("MiniHTMLTextBox")]
        public bool ActionsViewModeVisible
        {
            get { return _actionsViewModeVisible; }
            set
            {
                _actionsViewModeVisible = value;
                toolStripButton_viewmode.Visible = value;
            }
        }

        #endregion


        #region Focus, Painting and Document management

        /// <summary>
        /// On DocumentCompleted event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void htmlTextBox_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            IsHtmlTextBoxLoaded = true;
            HandleViewMode();
        }

        /// <summary>
        /// Wait until htmlTextBox is loaded
        /// </summary>
        private void WaitUntilHtmlTextBoxLoaded()
        {
            if (IsHtmlTextBoxLoaded)
                return;
            for (int i = 0; i < 60 && !IsHtmlTextBoxLoaded; i++)
            {
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Handle a focus change
        /// </summary>
        private void HandleFocusChanged()
        {
            if (!ContainsFocus)
                return;
            if (htmlTextBox.Focused && _htmlTextBoxTriggerFocus)
            {
                _htmlTextBoxTriggerFocus = false;
                WaitUntilHtmlTextBoxLoaded();
                htmlTextBox.Document.InvokeScript("Focus");
            }
        }

        /// <summary>
        /// GotFocus event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _htmlTextBoxTriggerFocus = true;
            HandleFocusChanged();
        }

        /// <summary>
        /// BorderColorFocused
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "ActiveCaption")]
        public Color BorderColorFocused { get; set; } = SystemColors.ActiveCaption;

        /// <summary>
        /// BorderColorNonFocused
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "ControlDark")]
        public Color BorderColorNonFocused { get; set; } = SystemColors.ControlDark;

        /// <summary>
        /// Draw Border
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, (ContainsFocus ? BorderColorFocused : BorderColorNonFocused), ButtonBorderStyle.Solid);
        }

        /// <summary>
        /// ProcessDialogKey override
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //skip Return key press event
            if (keyData == Keys.Return)
                return false;
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// On component Font changed event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (IsHtmlTextBoxLoaded)
            {
                htmlTextBox.Document.InvokeScript("SetFontName", new object[] { Font.Name });
                htmlTextBox.Document.InvokeScript("SetFontSize", new object[] { Font.Size.ToString(System.Globalization.CultureInfo.InvariantCulture) + "pt" });
            }
        }

        /// <summary>
        /// OnLeave event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (WriteBindingSourceValueOnLeave)
            {
                //update the binding sources
                for (int i = 0; i < DataBindings.Count; i++)
                    DataBindings[i].WriteValue();

            }
        }

        /// <summary>
        /// Set the readonly mode
        /// </summary>
        [DefaultValue(typeof(bool), "false")]
        [Category("MiniHTMLTextBox")]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                HandleViewMode();
            }
        }

        #endregion


        #region Action buttons

        /// <summary>
        /// Cut pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_cut_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            if (ViewMode == ViewModeType.Text)
                plainTextBox.Cut();
            else
            {
                WaitUntilHtmlTextBoxLoaded();
                htmlTextBox.Document.ExecCommand("Cut", false, null);
            }
        }

        /// <summary>
        /// Paste pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_paste_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            if (ViewMode == ViewModeType.Text)
                plainTextBox.Paste();
            else
            {
                WaitUntilHtmlTextBoxLoaded();
                htmlTextBox.Document.ExecCommand("Paste", false, null);
            }
        }

        /// <summary>
        /// Copy pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_copy_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            if (ViewMode == ViewModeType.Text)
                plainTextBox.Copy();
            else
            {
                WaitUntilHtmlTextBoxLoaded();
                htmlTextBox.Document.ExecCommand("Copy", false, null);
            }
        }

        /// <summary>
        /// Bold pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_bold_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("Bold", false, null);
        }

        /// <summary>
        /// Italic pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_italic_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("Italic", false, null);
        }

        /// <summary>
        /// Underline pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_underline_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("Underline", false, null);
        }

        /// <summary>
        /// Indent pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_indent_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("Indent", false, null);
        }

        /// <summary>
        /// Outdent pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_outdent_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("Outdent", false, null);
        }

        /// <summary>
        /// OrderedList pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_orderedlist_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("InsertOrderedList", false, null);
        }

        /// <summary>
        /// BulletList pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_bulletlist_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("InsertUnOrderedList", false, null);
        }


        /// <summary>
        /// Fontname Leave event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox_fontname_Leave(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("FontName", false, toolStripComboBox_fontname.Text);
        }

        /// <summary>
        /// Fontname SelectedIndexChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox_fontname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            toolStripComboBox_fontname_Leave(sender, e);
        }

        /// <summary>
        /// Fontname KeyDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox_fontname_KeyDown(object sender, KeyEventArgs e)
        {
            if (_preventEventTriggering)
                return;

            if (e.KeyCode == Keys.Return)
            {
                toolStripComboBox_fontname_Leave(sender, e);
                htmlTextBox.Focus();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Fontsize Leave event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox_fontsize_Leave(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("FontSize", false, toolStripComboBox_fontsize.Text);
        }

        /// <summary>
        /// Fontsize SelectedIndexChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            toolStripComboBox_fontsize_Leave(sender, e);
        }

        /// <summary>
        /// Fontsize KeyDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox_fontsize_KeyDown(object sender, KeyEventArgs e)
        {
            if (_preventEventTriggering)
                return;

            if (e.KeyCode == Keys.Return)
            {
                toolStripComboBox_fontsize_Leave(sender, e);
                htmlTextBox.Focus();
                e.Handled = true;
            }
        }

        /// <summary>
        /// HorizontalRule pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_horizontalrule_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("InsertHorizontalRule", false, null);
        }

        /// <summary>
        /// Undo pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_undo_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            if (ViewMode == ViewModeType.Text)
                plainTextBox.Undo();
            else
            {
                WaitUntilHtmlTextBoxLoaded();
                htmlTextBox.Document.ExecCommand("Undo", false, null);
            }
        }

        /// <summary>
        /// Redo pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_redo_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            if (ViewMode == ViewModeType.Text)
                plainTextBox.Text = plainTextBoxUndolist.Pop();
            else
            {
                WaitUntilHtmlTextBoxLoaded();
                htmlTextBox.Document.ExecCommand("Redo", false, null);
            }
        }

        /// <summary>
        /// Left pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_left_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("JustifyLeft", false, null);
        }

        /// <summary>
        /// Center pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_center_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("JustifyCenter", false, null);
        }

        /// <summary>
        /// Right pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_right_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("JustifyRight", false, null);
        }

        /// <summary>
        /// Justify pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_justify_Click(object sender, EventArgs e)
        {
            if (_preventEventTriggering)
                return;

            WaitUntilHtmlTextBoxLoaded();
            htmlTextBox.Document.ExecCommand("JustifyFull", false, null);
        }

        #endregion
    }
}
