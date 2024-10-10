using CustomComponents;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Runtime.CompilerServices;
using StoreManager.Database;
using System.Windows.Forms;

namespace StoreManager
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.PnlNavigation = new System.Windows.Forms.Panel();
            this.bunifuButton23 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.bunifuButton22 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.BtnCashier = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.PicBoxSettings = new System.Windows.Forms.PictureBox();
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.PnlContent = new System.Windows.Forms.Panel();
            this.PnlNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlNavigation
            // 
            this.PnlNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PnlNavigation.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PnlNavigation.Controls.Add(this.bunifuButton23);
            this.PnlNavigation.Controls.Add(this.bunifuButton22);
            this.PnlNavigation.Controls.Add(this.BtnCashier);
            this.PnlNavigation.Controls.Add(this.PicBoxSettings);
            this.PnlNavigation.Controls.Add(this.picBoxLogo);
            this.PnlNavigation.Location = new System.Drawing.Point(0, 0);
            this.PnlNavigation.Margin = new System.Windows.Forms.Padding(0);
            this.PnlNavigation.Name = "PnlNavigation";
            this.PnlNavigation.Size = new System.Drawing.Size(203, 682);
            this.PnlNavigation.TabIndex = 0;
            // 
            // bunifuButton23
            // 
            this.bunifuButton23.AllowAnimations = true;
            this.bunifuButton23.AllowMouseEffects = true;
            this.bunifuButton23.AllowToggling = true;
            this.bunifuButton23.AnimationSpeed = 200;
            this.bunifuButton23.AutoGenerateColors = false;
            this.bunifuButton23.AutoRoundBorders = false;
            this.bunifuButton23.AutoSizeLeftIcon = true;
            this.bunifuButton23.AutoSizeRightIcon = true;
            this.bunifuButton23.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton23.BackColor1 = System.Drawing.Color.White;
            this.bunifuButton23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton23.BackgroundImage")));
            this.bunifuButton23.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton23.ButtonText = "ANALYTICS";
            this.bunifuButton23.ButtonTextMarginLeft = 0;
            this.bunifuButton23.ColorContrastOnClick = 45;
            this.bunifuButton23.ColorContrastOnHover = 45;
            this.bunifuButton23.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.bunifuButton23.CustomizableEdges = borderEdges1;
            this.bunifuButton23.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton23.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton23.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton23.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton23.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.bunifuButton23.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuButton23.ForeColor = System.Drawing.Color.Black;
            this.bunifuButton23.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuButton23.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton23.IconLeftPadding = new System.Windows.Forms.Padding(5, 0, 3, 3);
            this.bunifuButton23.IconMarginLeft = 11;
            this.bunifuButton23.IconPadding = 10;
            this.bunifuButton23.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuButton23.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton23.IconRightPadding = new System.Windows.Forms.Padding(2, 3, 7, 3);
            this.bunifuButton23.IconSize = 50;
            this.bunifuButton23.IdleBorderColor = System.Drawing.Color.White;
            this.bunifuButton23.IdleBorderRadius = 5;
            this.bunifuButton23.IdleBorderThickness = 1;
            this.bunifuButton23.IdleFillColor = System.Drawing.Color.White;
            this.bunifuButton23.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton23.IdleIconLeftImage")));
            this.bunifuButton23.IdleIconRightImage = null;
            this.bunifuButton23.IndicateFocus = true;
            this.bunifuButton23.Location = new System.Drawing.Point(12, 265);
            this.bunifuButton23.Name = "bunifuButton23";
            this.bunifuButton23.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton23.OnDisabledState.BorderRadius = 5;
            this.bunifuButton23.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton23.OnDisabledState.BorderThickness = 1;
            this.bunifuButton23.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton23.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton23.OnDisabledState.IconLeftImage = null;
            this.bunifuButton23.OnDisabledState.IconRightImage = null;
            this.bunifuButton23.onHoverState.BorderColor = System.Drawing.Color.Gray;
            this.bunifuButton23.onHoverState.BorderRadius = 5;
            this.bunifuButton23.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton23.onHoverState.BorderThickness = 1;
            this.bunifuButton23.onHoverState.FillColor = System.Drawing.Color.Gray;
            this.bunifuButton23.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.bunifuButton23.onHoverState.IconLeftImage = null;
            this.bunifuButton23.onHoverState.IconRightImage = null;
            this.bunifuButton23.OnIdleState.BorderColor = System.Drawing.Color.White;
            this.bunifuButton23.OnIdleState.BorderRadius = 5;
            this.bunifuButton23.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton23.OnIdleState.BorderThickness = 1;
            this.bunifuButton23.OnIdleState.FillColor = System.Drawing.Color.White;
            this.bunifuButton23.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.bunifuButton23.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton23.OnIdleState.IconLeftImage")));
            this.bunifuButton23.OnIdleState.IconRightImage = null;
            this.bunifuButton23.OnPressedState.BorderColor = System.Drawing.Color.DimGray;
            this.bunifuButton23.OnPressedState.BorderRadius = 5;
            this.bunifuButton23.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton23.OnPressedState.BorderThickness = 1;
            this.bunifuButton23.OnPressedState.FillColor = System.Drawing.Color.DimGray;
            this.bunifuButton23.OnPressedState.ForeColor = System.Drawing.Color.Black;
            this.bunifuButton23.OnPressedState.IconLeftImage = null;
            this.bunifuButton23.OnPressedState.IconRightImage = null;
            this.bunifuButton23.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuButton23.Size = new System.Drawing.Size(178, 55);
            this.bunifuButton23.TabIndex = 3;
            this.bunifuButton23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuButton23.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bunifuButton23.TextMarginLeft = 0;
            this.bunifuButton23.TextPadding = new System.Windows.Forms.Padding(0);
            this.bunifuButton23.UseDefaultRadiusAndThickness = true;
            // 
            // bunifuButton22
            // 
            this.bunifuButton22.AllowAnimations = true;
            this.bunifuButton22.AllowMouseEffects = true;
            this.bunifuButton22.AllowToggling = true;
            this.bunifuButton22.AnimationSpeed = 200;
            this.bunifuButton22.AutoGenerateColors = false;
            this.bunifuButton22.AutoRoundBorders = false;
            this.bunifuButton22.AutoSizeLeftIcon = true;
            this.bunifuButton22.AutoSizeRightIcon = true;
            this.bunifuButton22.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton22.BackColor1 = System.Drawing.Color.White;
            this.bunifuButton22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton22.BackgroundImage")));
            this.bunifuButton22.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton22.ButtonText = "INVENTORY";
            this.bunifuButton22.ButtonTextMarginLeft = 0;
            this.bunifuButton22.ColorContrastOnClick = 45;
            this.bunifuButton22.ColorContrastOnHover = 45;
            this.bunifuButton22.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.bunifuButton22.CustomizableEdges = borderEdges2;
            this.bunifuButton22.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton22.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton22.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton22.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton22.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.bunifuButton22.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuButton22.ForeColor = System.Drawing.Color.Black;
            this.bunifuButton22.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuButton22.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton22.IconLeftPadding = new System.Windows.Forms.Padding(5, 0, 3, 3);
            this.bunifuButton22.IconMarginLeft = 11;
            this.bunifuButton22.IconPadding = 10;
            this.bunifuButton22.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuButton22.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton22.IconRightPadding = new System.Windows.Forms.Padding(2, 3, 7, 3);
            this.bunifuButton22.IconSize = 50;
            this.bunifuButton22.IdleBorderColor = System.Drawing.Color.White;
            this.bunifuButton22.IdleBorderRadius = 5;
            this.bunifuButton22.IdleBorderThickness = 1;
            this.bunifuButton22.IdleFillColor = System.Drawing.Color.White;
            this.bunifuButton22.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton22.IdleIconLeftImage")));
            this.bunifuButton22.IdleIconRightImage = null;
            this.bunifuButton22.IndicateFocus = true;
            this.bunifuButton22.Location = new System.Drawing.Point(12, 204);
            this.bunifuButton22.Name = "bunifuButton22";
            this.bunifuButton22.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton22.OnDisabledState.BorderRadius = 5;
            this.bunifuButton22.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton22.OnDisabledState.BorderThickness = 1;
            this.bunifuButton22.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton22.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton22.OnDisabledState.IconLeftImage = null;
            this.bunifuButton22.OnDisabledState.IconRightImage = null;
            this.bunifuButton22.onHoverState.BorderColor = System.Drawing.Color.Gray;
            this.bunifuButton22.onHoverState.BorderRadius = 5;
            this.bunifuButton22.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton22.onHoverState.BorderThickness = 1;
            this.bunifuButton22.onHoverState.FillColor = System.Drawing.Color.Gray;
            this.bunifuButton22.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.bunifuButton22.onHoverState.IconLeftImage = null;
            this.bunifuButton22.onHoverState.IconRightImage = null;
            this.bunifuButton22.OnIdleState.BorderColor = System.Drawing.Color.White;
            this.bunifuButton22.OnIdleState.BorderRadius = 5;
            this.bunifuButton22.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton22.OnIdleState.BorderThickness = 1;
            this.bunifuButton22.OnIdleState.FillColor = System.Drawing.Color.White;
            this.bunifuButton22.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.bunifuButton22.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton22.OnIdleState.IconLeftImage")));
            this.bunifuButton22.OnIdleState.IconRightImage = null;
            this.bunifuButton22.OnPressedState.BorderColor = System.Drawing.Color.DimGray;
            this.bunifuButton22.OnPressedState.BorderRadius = 5;
            this.bunifuButton22.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton22.OnPressedState.BorderThickness = 1;
            this.bunifuButton22.OnPressedState.FillColor = System.Drawing.Color.DimGray;
            this.bunifuButton22.OnPressedState.ForeColor = System.Drawing.Color.Black;
            this.bunifuButton22.OnPressedState.IconLeftImage = null;
            this.bunifuButton22.OnPressedState.IconRightImage = null;
            this.bunifuButton22.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuButton22.Size = new System.Drawing.Size(178, 55);
            this.bunifuButton22.TabIndex = 2;
            this.bunifuButton22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuButton22.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bunifuButton22.TextMarginLeft = 0;
            this.bunifuButton22.TextPadding = new System.Windows.Forms.Padding(0);
            this.bunifuButton22.UseDefaultRadiusAndThickness = true;
            this.bunifuButton22.Click += new System.EventHandler(this.BtnInventory_Click);
            // 
            // BtnCashier
            // 
            this.BtnCashier.AllowAnimations = true;
            this.BtnCashier.AllowMouseEffects = true;
            this.BtnCashier.AllowToggling = true;
            this.BtnCashier.AnimationSpeed = 200;
            this.BtnCashier.AutoGenerateColors = false;
            this.BtnCashier.AutoRoundBorders = false;
            this.BtnCashier.AutoSizeLeftIcon = true;
            this.BtnCashier.AutoSizeRightIcon = true;
            this.BtnCashier.BackColor = System.Drawing.Color.Transparent;
            this.BtnCashier.BackColor1 = System.Drawing.Color.White;
            this.BtnCashier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnCashier.BackgroundImage")));
            this.BtnCashier.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnCashier.ButtonText = "CASHIERING";
            this.BtnCashier.ButtonTextMarginLeft = 0;
            this.BtnCashier.ColorContrastOnClick = 45;
            this.BtnCashier.ColorContrastOnHover = 45;
            this.BtnCashier.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.BtnCashier.CustomizableEdges = borderEdges3;
            this.BtnCashier.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnCashier.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnCashier.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnCashier.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnCashier.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.BtnCashier.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCashier.ForeColor = System.Drawing.Color.Black;
            this.BtnCashier.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCashier.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCashier.IconLeftPadding = new System.Windows.Forms.Padding(5, 0, 3, 3);
            this.BtnCashier.IconMarginLeft = 11;
            this.BtnCashier.IconPadding = 10;
            this.BtnCashier.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCashier.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCashier.IconRightPadding = new System.Windows.Forms.Padding(2, 3, 7, 3);
            this.BtnCashier.IconSize = 50;
            this.BtnCashier.IdleBorderColor = System.Drawing.Color.White;
            this.BtnCashier.IdleBorderRadius = 5;
            this.BtnCashier.IdleBorderThickness = 1;
            this.BtnCashier.IdleFillColor = System.Drawing.Color.White;
            this.BtnCashier.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("BtnCashier.IdleIconLeftImage")));
            this.BtnCashier.IdleIconRightImage = null;
            this.BtnCashier.IndicateFocus = true;
            this.BtnCashier.Location = new System.Drawing.Point(12, 143);
            this.BtnCashier.Name = "BtnCashier";
            this.BtnCashier.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnCashier.OnDisabledState.BorderRadius = 5;
            this.BtnCashier.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnCashier.OnDisabledState.BorderThickness = 1;
            this.BtnCashier.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnCashier.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnCashier.OnDisabledState.IconLeftImage = null;
            this.BtnCashier.OnDisabledState.IconRightImage = null;
            this.BtnCashier.onHoverState.BorderColor = System.Drawing.Color.Gray;
            this.BtnCashier.onHoverState.BorderRadius = 5;
            this.BtnCashier.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnCashier.onHoverState.BorderThickness = 1;
            this.BtnCashier.onHoverState.FillColor = System.Drawing.Color.Gray;
            this.BtnCashier.onHoverState.ForeColor = System.Drawing.Color.Black;
            this.BtnCashier.onHoverState.IconLeftImage = null;
            this.BtnCashier.onHoverState.IconRightImage = null;
            this.BtnCashier.OnIdleState.BorderColor = System.Drawing.Color.White;
            this.BtnCashier.OnIdleState.BorderRadius = 5;
            this.BtnCashier.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnCashier.OnIdleState.BorderThickness = 1;
            this.BtnCashier.OnIdleState.FillColor = System.Drawing.Color.White;
            this.BtnCashier.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.BtnCashier.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("BtnCashier.OnIdleState.IconLeftImage")));
            this.BtnCashier.OnIdleState.IconRightImage = null;
            this.BtnCashier.OnPressedState.BorderColor = System.Drawing.Color.DimGray;
            this.BtnCashier.OnPressedState.BorderRadius = 5;
            this.BtnCashier.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.BtnCashier.OnPressedState.BorderThickness = 1;
            this.BtnCashier.OnPressedState.FillColor = System.Drawing.Color.DimGray;
            this.BtnCashier.OnPressedState.ForeColor = System.Drawing.Color.Black;
            this.BtnCashier.OnPressedState.IconLeftImage = null;
            this.BtnCashier.OnPressedState.IconRightImage = null;
            this.BtnCashier.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnCashier.Size = new System.Drawing.Size(178, 55);
            this.BtnCashier.TabIndex = 1;
            this.BtnCashier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCashier.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnCashier.TextMarginLeft = 0;
            this.BtnCashier.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnCashier.UseDefaultRadiusAndThickness = true;
            this.BtnCashier.Click += new System.EventHandler(this.BtnPos_Click);
            // 
            // PicBoxSettings
            // 
            this.PicBoxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PicBoxSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PicBoxSettings.BackgroundImage")));
            this.PicBoxSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicBoxSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicBoxSettings.Location = new System.Drawing.Point(3, 653);
            this.PicBoxSettings.Name = "PicBoxSettings";
            this.PicBoxSettings.Size = new System.Drawing.Size(33, 26);
            this.PicBoxSettings.TabIndex = 0;
            this.PicBoxSettings.TabStop = false;
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxLogo.BackgroundImage")));
            this.picBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBoxLogo.Location = new System.Drawing.Point(12, 12);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(178, 80);
            this.picBoxLogo.TabIndex = 0;
            this.picBoxLogo.TabStop = false;
            // 
            // PnlContent
            // 
            this.PnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlContent.Location = new System.Drawing.Point(203, 0);
            this.PnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Size = new System.Drawing.Size(1168, 682);
            this.PnlContent.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1370, 681);
            this.Controls.Add(this.PnlContent);
            this.Controls.Add(this.PnlNavigation);
            this.Name = "MainWindow";
            this.Text = "CLC Store Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.PnlNavigation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }


        //this.PnlOrdersPanel.AddOrder(new CartItem(123, "jed", "small", 240));

        //private 
        //private OrdersPanel PnlOrdersPanel;
        //private ProductsPanel PnlProductsPanel;

        #endregion
        private Panel PnlNavigation;
        private PictureBox picBoxLogo;
        private PictureBox PicBoxSettings;
        private Panel PnlContent;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 BtnCashier;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 bunifuButton23;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 bunifuButton22;
    }
}
