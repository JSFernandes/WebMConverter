﻿using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace WebMConverter
{
    public partial class RateForm : Form
    {
        public RateFilter GeneratedFilter;

        private TimeSpan _originalDuration;
        private const string PreviewBoxFormat = @"hh\:mm\:ss";
        private readonly RateFilter _filterToEdit;

        public RateForm()
        {
            InitializeComponent();
        }

        public RateForm(RateFilter filterToEdit) : this()
        {
            _filterToEdit = filterToEdit;
        }

        private void RateForm_Load(object sender, EventArgs e)
        {
            _originalDuration = new TimeSpan((long)(((MainForm) Owner).GetDuration() / (_filterToEdit != null ? (double)_filterToEdit.Multiplier / 100 : 1) * 10000000));
            boxPreviewOriginal.Text = _originalDuration.ToString(PreviewBoxFormat);

            if (_filterToEdit != null)
            {
                trackRate.Value = _filterToEdit.Multiplier;
            }

            boxPreviewScaled.Text = new TimeSpan((long)(_originalDuration.Ticks / GetValue())).ToString(PreviewBoxFormat);
        }

        private float GetValue()
        {
            float outvalue;
            var value = trackRate.Value;
            var negative = value < 100;

            value -= 100;
            value = Math.Abs(Math.Max(-99, value));
            outvalue = value;

            outvalue = (100 + ((negative ? -1 : 1) * outvalue)) / 100;

            return outvalue;
        }

        private void trackRate_ValueChanged(object sender, EventArgs e)
        {
            var outvalue = GetValue();

            labelPercentIndicator.Text = outvalue.ToString("P");

            boxPreviewScaled.Text = new TimeSpan((long)(_originalDuration.Ticks / outvalue)).ToString(PreviewBoxFormat);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            GeneratedFilter = new RateFilter(trackRate.Value);
        }
    }

    public class RateFilter
    {
        public int Multiplier { get; private set; }

        /// <summary>
        /// {0} is multiplier
        /// {1} is divisor
        /// </summary>
        private const string BaseCommand = "AssumeScaledFPS({0}, 100, true)";

        private readonly CultureInfo _commaCultureInfo;

        public RateFilter(int multiplier)
        {
            Multiplier = multiplier;

            _commaCultureInfo = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            _commaCultureInfo.NumberFormat.NumberDecimalSeparator = ",";
        }

        public override string ToString()
        {
            return string.Format(BaseCommand, Multiplier);
        }
    }
}
