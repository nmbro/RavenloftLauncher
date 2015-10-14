using System.Windows.Forms;
using System;
using System.Drawing;

public class AutoFontLabel : Label
{
    public AutoFontLabel()
        : base()
    {
        this.AutoEllipsis = true;
    }

    protected override void OnPaddingChanged(EventArgs e)
    {
        UpdateFontSize();
        base.OnPaddingChanged(e);
    }

    protected override void OnResize(EventArgs e)
    {
        UpdateFontSize();
        base.OnResize(e);
    }

    private void UpdateFontSize()
    {
        int textHeight = this.ClientRectangle.Height
            - this.Padding.Top - this.Padding.Bottom;

        if (textHeight > 0)
        {
            this.Font = new Font(this.Font.FontFamily,
                textHeight, GraphicsUnit.Pixel);
        }
    }
}