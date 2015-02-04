﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace WebMConverter
{
    public partial class CaptionForm : Form
    {
        readonly CaptionFilter InputFilter;
        public CaptionFilter GeneratedFilter;

        Point point;

        Size videoResolution;
        Point held;
        Point beforeheld;

        public CaptionForm(CaptionFilter filterToEdit = null)
        {
            InitializeComponent();

            InputFilter = filterToEdit;

            previewFrame.Picture.Paint += new System.Windows.Forms.PaintEventHandler(this.previewPicture_Paint);
            previewFrame.Picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.previewPicture_MouseDown);
            previewFrame.Picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.previewPicture_MouseMove);
        }

        void CaptionForm_Load(object sender, EventArgs e)
        {
            if (InputFilter != null)
            {
                point = InputFilter.Placement;
                boxText.Text = InputFilter.Text;
                fontDialog1.Font = InputFilter.Style;
                colorDialogTextColor.Color = InputFilter.TextColor;
                colorDialogBorderColor.Color = InputFilter.BorderColor;
                numericBorderThickness.Value = InputFilter.BorderThickness;
            }

            if ((Owner as MainForm).SarCompensate)
            {
                videoResolution = new Size((Owner as MainForm).SarWidth, (Owner as MainForm).SarHeight);
            }
            else
            {
                FFMSSharp.Frame frame = Program.VideoSource.GetFrame(previewFrame.Frame);
                videoResolution = frame.EncodedResolution;
                previewFrame.GeneratePreview(true);
            }

            if ((Owner as MainForm).boxAdvancedScripting.Checked) return;

            if (Filters.Trim != null)
            {
                previewFrame.Frame = Filters.Trim.TrimStart;
                trimTimingToolStripMenuItem.Enabled = true;
            }
            if (Filters.MultipleTrim != null)
            {
                previewFrame.Frame = Filters.MultipleTrim.Trims[0].TrimStart;
                trimTimingToolStripMenuItem.Enabled = true;
            }
        }

        Point getBasePoint(PictureBox pictureBox)
        {
            int basex = pictureBox.Size.Width == pictureBox.ClientSize.Width ? 0 : pictureBox.Size.Width - pictureBox.ClientSize.Width / 2;
            int basey = pictureBox.Size.Height == pictureBox.ClientSize.Height ? 0 : pictureBox.Size.Height - pictureBox.ClientSize.Height / 2;

            return new Point(basex, basey);
        }

        float getPictureScale(PictureBox pictureBox)
        {
            return (float)pictureBox.ClientSize.Width / (float)videoResolution.Width;
        }

        void previewPicture_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var path = new GraphicsPath();

            var pictureBox = sender as PictureBox;

            var basePoint = getBasePoint(pictureBox);
            var scale = getPictureScale(pictureBox);

            var scaledsize = fontDialog1.Font.Size * scale;
            var scaledpoint = new Point(basePoint.X + (int)(point.X * scale), basePoint.Y + (int)(point.Y * scale));

            path.AddString(boxText.Text, fontDialog1.Font.FontFamily, (int)fontDialog1.Font.Style, scaledsize, scaledpoint, StringFormat.GenericDefault);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPath(new SolidBrush(colorDialogTextColor.Color), path);
            g.DrawPath(new Pen(new SolidBrush(colorDialogBorderColor.Color), (float)numericBorderThickness.Value * scale), path);
        }

        void previewPicture_MouseDown(object sender, MouseEventArgs e)
        {
            held = e.Location;
            beforeheld = point;

            previewPicture_MouseMove(sender, e);
        }

        void previewPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.None)
                return;

            var scale = getPictureScale(previewFrame.Picture);

            point.X = beforeheld.X + (int)((e.X - held.X) / scale);
            point.Y = beforeheld.Y + (int)((e.Y - held.Y) / scale);

            previewFrame.Picture.Invalidate();
        }

        private void UpdateTextLayout(object sender, EventArgs e)
        {
            previewFrame.Picture.Invalidate();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            UpdateTextLayout(sender, e);
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialogTextColor.ShowDialog();
            UpdateTextLayout(sender, e);
        }

        private void borderColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialogBorderColor.ShowDialog();
            UpdateTextLayout(sender, e);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            GeneratedFilter = new CaptionFilter(point, boxText.Text, fontDialog1.Font, colorDialogTextColor.Color, colorDialogBorderColor.Color, (int)numericBorderThickness.Value);

            DialogResult = DialogResult.OK;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previewFrame.Frame = Filters.Trim.TrimStart;
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previewFrame.Frame = Filters.Trim.TrimEnd;
        }

        private void frameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new InputDialog<int>("Frame", previewFrame.Frame))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    previewFrame.Frame = Math.Max(0, Math.Min(Program.VideoSource.NumberOfFrames - 1, dialog.Value)); // Make sure we don't go out of bounds.
                }
            }
        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new InputDialog<TimeSpan>("Time", Program.FrameToTimeSpan(previewFrame.Frame)))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int i = Program.TimeSpanToFrame(dialog.Value);
                    i = Math.Max(0, Math.Min(Program.VideoSource.NumberOfFrames - 1, i)); // Make sure we don't go out of bounds.
                    previewFrame.Frame = i;
                }
            }
        }
    }

    public class CaptionFilter
    {
        public readonly Point Placement;
        public readonly string Text;
        public readonly Font Style;
        public readonly Color TextColor;
        public readonly Color BorderColor;
        public readonly int BorderThickness;

        string renderedCaptionFilename;

        public CaptionFilter(Point placement, string text, Font style, Color textColor, Color borderColor, int borderThickness)
        {
            Placement = placement;
            Text = text;
            Style = style;
            TextColor = textColor;
            BorderColor = borderColor;
            BorderThickness = borderThickness;
        }

        public void BeforeEncode(Size resolution)
        {
            renderedCaptionFilename = Path.Combine(Path.GetTempPath(), "webmconverter-caption.png");

            using (var renderedCaption = new Bitmap(resolution.Width, resolution.Height))
            using (var g = Graphics.FromImage(renderedCaption))
            {
                var path = new GraphicsPath();

                path.AddString(Text, Style.FontFamily, (int)Style.Style, Style.Size, Placement, StringFormat.GenericDefault);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillPath(new SolidBrush(TextColor), path);
                g.DrawPath(new Pen(new SolidBrush(BorderColor), BorderThickness), path);

                renderedCaption.Save(renderedCaptionFilename, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        public override string ToString()
        {
            return string.Format("Overlay(ImageSource(\"{0}\"), mask=ImageSource(\"{0}\",pixel_type=\"RGB32\").ShowAlpha(pixel_type=\"RGB32\"))", renderedCaptionFilename);
        }
    }
}
