namespace StoreManager
{
    partial class FormCheckoutDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCheckoutDialog));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.DataGridReceipt = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblTotalLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblCashPrompt = new Bunifu.UI.WinForms.BunifuLabel();
            this.TbCash = new Bunifu.UI.WinForms.BunifuTextBox();
            this.TbTotal = new Bunifu.UI.WinForms.BunifuTextBox();
            this.BtnConfirm = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridReceipt
            // 
            this.DataGridReceipt.AllowCustomTheming = false;
            this.DataGridReceipt.AllowUserToAddRows = false;
            this.DataGridReceipt.AllowUserToDeleteRows = false;
            this.DataGridReceipt.AllowUserToResizeColumns = false;
            this.DataGridReceipt.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.DataGridReceipt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridReceipt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridReceipt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridReceipt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridReceipt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridReceipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridReceipt.ColumnHeadersHeight = 40;
            this.DataGridReceipt.ColumnHeadersVisible = false;
            this.DataGridReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.Quantity,
            this.Subtotal});
            this.DataGridReceipt.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.DataGridReceipt.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataGridReceipt.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridReceipt.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.DataGridReceipt.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.DataGridReceipt.CurrentTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.DataGridReceipt.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.DataGridReceipt.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.DataGridReceipt.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.DataGridReceipt.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridReceipt.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.DataGridReceipt.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DataGridReceipt.CurrentTheme.Name = null;
            this.DataGridReceipt.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.DataGridReceipt.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataGridReceipt.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridReceipt.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.DataGridReceipt.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridReceipt.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridReceipt.EnableHeadersVisualStyles = false;
            this.DataGridReceipt.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.DataGridReceipt.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.DataGridReceipt.HeaderBgColor = System.Drawing.Color.Empty;
            this.DataGridReceipt.HeaderForeColor = System.Drawing.Color.White;
            this.DataGridReceipt.Location = new System.Drawing.Point(12, 12);
            this.DataGridReceipt.MultiSelect = false;
            this.DataGridReceipt.Name = "DataGridReceipt";
            this.DataGridReceipt.ReadOnly = true;
            this.DataGridReceipt.RowHeadersVisible = false;
            this.DataGridReceipt.RowTemplate.Height = 40;
            this.DataGridReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridReceipt.Size = new System.Drawing.Size(332, 323);
            this.DataGridReceipt.TabIndex = 0;
            this.DataGridReceipt.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            // 
            // LblTotalLabel
            // 
            this.LblTotalLabel.AllowParentOverrides = false;
            this.LblTotalLabel.AutoEllipsis = false;
            this.LblTotalLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblTotalLabel.CursorType = System.Windows.Forms.Cursors.Default;
            this.LblTotalLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalLabel.ForeColor = System.Drawing.Color.White;
            this.LblTotalLabel.Location = new System.Drawing.Point(12, 350);
            this.LblTotalLabel.Name = "LblTotalLabel";
            this.LblTotalLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblTotalLabel.Size = new System.Drawing.Size(48, 25);
            this.LblTotalLabel.TabIndex = 1;
            this.LblTotalLabel.Text = "Total:";
            this.LblTotalLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblTotalLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblCashPrompt
            // 
            this.LblCashPrompt.AllowParentOverrides = false;
            this.LblCashPrompt.AutoEllipsis = false;
            this.LblCashPrompt.CursorType = null;
            this.LblCashPrompt.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCashPrompt.ForeColor = System.Drawing.Color.White;
            this.LblCashPrompt.Location = new System.Drawing.Point(12, 411);
            this.LblCashPrompt.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.LblCashPrompt.Name = "LblCashPrompt";
            this.LblCashPrompt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblCashPrompt.Size = new System.Drawing.Size(93, 25);
            this.LblCashPrompt.TabIndex = 1;
            this.LblCashPrompt.Text = "Enter cash:";
            this.LblCashPrompt.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LblCashPrompt.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // TbCash
            // 
            this.TbCash.AcceptsReturn = false;
            this.TbCash.AcceptsTab = false;
            this.TbCash.AnimationSpeed = 200;
            this.TbCash.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TbCash.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TbCash.AutoSizeHeight = true;
            this.TbCash.BackColor = System.Drawing.Color.Transparent;
            this.TbCash.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TbCash.BackgroundImage")));
            this.TbCash.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.TbCash.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.TbCash.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.TbCash.BorderColorIdle = System.Drawing.Color.Silver;
            this.TbCash.BorderRadius = 10;
            this.TbCash.BorderThickness = 1;
            this.TbCash.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.TbCash.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TbCash.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbCash.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbCash.DefaultText = "";
            this.TbCash.FillColor = System.Drawing.Color.White;
            this.TbCash.HideSelection = true;
            this.TbCash.IconLeft = null;
            this.TbCash.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.TbCash.IconPadding = 10;
            this.TbCash.IconRight = null;
            this.TbCash.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.TbCash.Lines = new string[0];
            this.TbCash.Location = new System.Drawing.Point(111, 391);
            this.TbCash.MaxLength = 32767;
            this.TbCash.MinimumSize = new System.Drawing.Size(1, 1);
            this.TbCash.Modified = false;
            this.TbCash.Multiline = false;
            this.TbCash.Name = "TbCash";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TbCash.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.TbCash.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TbCash.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TbCash.OnIdleState = stateProperties4;
            this.TbCash.Padding = new System.Windows.Forms.Padding(3);
            this.TbCash.PasswordChar = '\0';
            this.TbCash.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.TbCash.PlaceholderText = "Enter cash";
            this.TbCash.ReadOnly = false;
            this.TbCash.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TbCash.SelectedText = "";
            this.TbCash.SelectionLength = 0;
            this.TbCash.SelectionStart = 0;
            this.TbCash.ShortcutsEnabled = true;
            this.TbCash.Size = new System.Drawing.Size(233, 54);
            this.TbCash.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.TbCash.TabIndex = 2;
            this.TbCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TbCash.TextMarginBottom = 0;
            this.TbCash.TextMarginLeft = 3;
            this.TbCash.TextMarginTop = 1;
            this.TbCash.TextPlaceholder = "Enter cash";
            this.TbCash.UseSystemPasswordChar = false;
            this.TbCash.WordWrap = true;
            this.TbCash.TextChange += new System.EventHandler(this.TbCash_TextChange);
            this.TbCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbCash_KeyPress);
            // 
            // TbTotal
            // 
            this.TbTotal.AcceptsReturn = false;
            this.TbTotal.AcceptsTab = false;
            this.TbTotal.AnimationSpeed = 200;
            this.TbTotal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TbTotal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TbTotal.AutoSizeHeight = true;
            this.TbTotal.BackColor = System.Drawing.Color.Transparent;
            this.TbTotal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TbTotal.BackgroundImage")));
            this.TbTotal.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.TbTotal.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.TbTotal.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.TbTotal.BorderColorIdle = System.Drawing.Color.Silver;
            this.TbTotal.BorderRadius = 10;
            this.TbTotal.BorderThickness = 1;
            this.TbTotal.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.TbTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TbTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbTotal.DefaultFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTotal.DefaultText = "";
            this.TbTotal.Enabled = false;
            this.TbTotal.FillColor = System.Drawing.Color.White;
            this.TbTotal.HideSelection = true;
            this.TbTotal.IconLeft = null;
            this.TbTotal.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.TbTotal.IconPadding = 10;
            this.TbTotal.IconRight = null;
            this.TbTotal.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.TbTotal.Lines = new string[0];
            this.TbTotal.Location = new System.Drawing.Point(111, 339);
            this.TbTotal.MaxLength = 32767;
            this.TbTotal.MinimumSize = new System.Drawing.Size(1, 1);
            this.TbTotal.Modified = false;
            this.TbTotal.Multiline = false;
            this.TbTotal.Name = "TbTotal";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TbTotal.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.TbTotal.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TbTotal.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TbTotal.OnIdleState = stateProperties8;
            this.TbTotal.Padding = new System.Windows.Forms.Padding(3);
            this.TbTotal.PasswordChar = '\0';
            this.TbTotal.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.TbTotal.PlaceholderText = "Enter text";
            this.TbTotal.ReadOnly = false;
            this.TbTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TbTotal.SelectedText = "";
            this.TbTotal.SelectionLength = 0;
            this.TbTotal.SelectionStart = 0;
            this.TbTotal.ShortcutsEnabled = true;
            this.TbTotal.Size = new System.Drawing.Size(233, 40);
            this.TbTotal.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.TbTotal.TabIndex = 2;
            this.TbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TbTotal.TextMarginBottom = 0;
            this.TbTotal.TextMarginLeft = 3;
            this.TbTotal.TextMarginTop = 1;
            this.TbTotal.TextPlaceholder = "Enter text";
            this.TbTotal.UseSystemPasswordChar = false;
            this.TbTotal.WordWrap = true;
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.AllowAnimations = true;
            this.BtnConfirm.AllowMouseEffects = true;
            this.BtnConfirm.AllowToggling = false;
            this.BtnConfirm.AnimationSpeed = 200;
            this.BtnConfirm.AutoGenerateColors = false;
            this.BtnConfirm.AutoRoundBorders = false;
            this.BtnConfirm.AutoSizeLeftIcon = true;
            this.BtnConfirm.AutoSizeRightIcon = true;
            this.BtnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.BtnConfirm.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnConfirm.BackgroundImage")));
            this.BtnConfirm.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnConfirm.ButtonText = "CONFIRM";
            this.BtnConfirm.ButtonTextMarginLeft = 0;
            this.BtnConfirm.ColorContrastOnClick = 45;
            this.BtnConfirm.ColorContrastOnHover = 45;
            this.BtnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.BtnConfirm.CustomizableEdges = borderEdges1;
            this.BtnConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnConfirm.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnConfirm.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnConfirm.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnConfirm.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.BtnConfirm.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirm.ForeColor = System.Drawing.Color.Black;
            this.BtnConfirm.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConfirm.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnConfirm.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnConfirm.IconMarginLeft = 11;
            this.BtnConfirm.IconPadding = 10;
            this.BtnConfirm.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnConfirm.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnConfirm.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnConfirm.IconSize = 25;
            this.BtnConfirm.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnConfirm.IdleBorderRadius = 10;
            this.BtnConfirm.IdleBorderThickness = 1;
            this.BtnConfirm.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnConfirm.IdleIconLeftImage = null;
            this.BtnConfirm.IdleIconRightImage = null;
            this.BtnConfirm.IndicateFocus = false;
            this.BtnConfirm.Location = new System.Drawing.Point(12, 471);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnConfirm.OnDisabledState.BorderRadius = 10;
            this.BtnConfirm.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnConfirm.OnDisabledState.BorderThickness = 1;
            this.BtnConfirm.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnConfirm.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnConfirm.OnDisabledState.IconLeftImage = null;
            this.BtnConfirm.OnDisabledState.IconRightImage = null;
            this.BtnConfirm.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnConfirm.onHoverState.BorderRadius = 10;
            this.BtnConfirm.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnConfirm.onHoverState.BorderThickness = 1;
            this.BtnConfirm.onHoverState.FillColor = System.Drawing.Color.Green;
            this.BtnConfirm.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnConfirm.onHoverState.IconLeftImage = null;
            this.BtnConfirm.onHoverState.IconRightImage = null;
            this.BtnConfirm.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnConfirm.OnIdleState.BorderRadius = 10;
            this.BtnConfirm.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnConfirm.OnIdleState.BorderThickness = 1;
            this.BtnConfirm.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnConfirm.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.BtnConfirm.OnIdleState.IconLeftImage = null;
            this.BtnConfirm.OnIdleState.IconRightImage = null;
            this.BtnConfirm.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnConfirm.OnPressedState.BorderRadius = 10;
            this.BtnConfirm.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnConfirm.OnPressedState.BorderThickness = 1;
            this.BtnConfirm.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnConfirm.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnConfirm.OnPressedState.IconLeftImage = null;
            this.BtnConfirm.OnPressedState.IconRightImage = null;
            this.BtnConfirm.Size = new System.Drawing.Size(332, 39);
            this.BtnConfirm.TabIndex = 3;
            this.BtnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnConfirm.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnConfirm.TextMarginLeft = 0;
            this.BtnConfirm.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnConfirm.UseDefaultRadiusAndThickness = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // FormCheckoutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(356, 522);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.TbTotal);
            this.Controls.Add(this.TbCash);
            this.Controls.Add(this.LblCashPrompt);
            this.Controls.Add(this.LblTotalLabel);
            this.Controls.Add(this.DataGridReceipt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCheckoutDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCheckoutDialog";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridReceipt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuDataGridView DataGridReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private Bunifu.UI.WinForms.BunifuLabel LblTotalLabel;
        private Bunifu.UI.WinForms.BunifuLabel LblCashPrompt;
        private Bunifu.UI.WinForms.BunifuTextBox TbCash;
        private Bunifu.UI.WinForms.BunifuTextBox TbTotal;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 BtnConfirm;
    }
}