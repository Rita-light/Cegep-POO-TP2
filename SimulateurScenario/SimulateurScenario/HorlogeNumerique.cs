using System;
using System.Drawing;
using Timer = System.Windows.Forms.Timer;

public class HorlogeNumerique : Label
{
    private Timer timer;
    private TimeSpan elapsedTime;

    public HorlogeNumerique()
    {
        this.Font = new Font("Arial", 16, FontStyle.Bold);
        this.ForeColor = Color.Red;
        this.BackColor = Color.Transparent;
        this.AutoSize = true;

        elapsedTime = TimeSpan.Zero;

        timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += (s, e) =>
        {
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
            this.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        };
        timer.Start();
        this.Text = "00:00:00";
    }

    public void Reinitialiser()
    {
        elapsedTime = TimeSpan.Zero;
        this.Text = "00:00:00";
    }
}