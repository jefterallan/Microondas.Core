using System;
using Microondas.Core.Business;
using System.Windows.Forms;

namespace Microondas.Core
{
    public partial class frmMicroondas : Form
    {
        private int _time = 0;
        private int _min = 0;
        private int _sec = 0;
        private int _prg = 1;

        MicroondasBusiness m = new MicroondasBusiness();

        public frmMicroondas()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, System.EventArgs e)
        {
            rtfTempo.Text = m.addNumber(sender,rtfTempo);
        }

        private void Btn2_Click(object sender, System.EventArgs e)
        {
            rtfTempo.Text = m.addNumber(sender, rtfTempo);
        }

        private void Btn3_Click(object sender, System.EventArgs e)
        {
            rtfTempo.Text = m.addNumber(sender, rtfTempo);
        }

        private void Btn4_Click(object sender, System.EventArgs e)
        {
            rtfTempo.Text = m.addNumber(sender, rtfTempo);
        }

        private void Btn5_Click(object sender, System.EventArgs e)
        {
            rtfTempo.Text = m.addNumber(sender, rtfTempo);
        }

        private void Btn6_Click(object sender, System.EventArgs e)
        {
            rtfTempo.Text = m.addNumber(sender, rtfTempo);
        }

        private void Btn7_Click(object sender, System.EventArgs e)
        {
            rtfTempo.Text = m.addNumber(sender, rtfTempo);
        }

        private void Btn8_Click(object sender, System.EventArgs e)
        {
            rtfTempo.Text = m.addNumber(sender, rtfTempo);
        }

        private void Btn9_Click(object sender, System.EventArgs e)
        {
            rtfTempo.Text = m.addNumber(sender, rtfTempo);
        }

        private void Btn0_Click(object sender, System.EventArgs e)
        {
            rtfTempo.Text = m.addNumber(sender, rtfTempo);
        }

        private void BtnCancelar_Click(object sender, System.EventArgs e)
        {
            m.clean(rtfTempo, rtfPotencia, prgTempo, lblAguarde, timerT);
        }

        private void BtnPotencia_Click(object sender, System.EventArgs e)
        {
            rtfPotencia.Text = m.addPower(rtfPotencia.Text);
        }

        private void BtnIniciar_Click(object sender, System.EventArgs e)
        {
            _prg = 1;
            prgTempo.Value = 0;

            if(m.startDefault(rtfTempo, rtfPotencia))
            {
                string[] time = rtfTempo.Text.Split(':');
                TimeSpan ts = new TimeSpan(0, Convert.ToInt32(time[0]), Convert.ToInt32(time[1]));
                int seconds = Convert.ToInt32(ts.TotalSeconds);

                prgTempo.Maximum = seconds;

                _time = Convert.ToInt32(seconds);

                if (_time >= 60)
                {
                    _min = _time / 60;
                    _sec = _time % 60;
                }
                else
                {
                    _min = 0;
                    _sec = _time;
                }
                timerT.Enabled = true;
            }            
        }

        private void T_Tick(object sender, System.EventArgs e)
        {
            _sec--;
            if(_min > 0)
            {
                if(_sec < 0)
                {
                    _sec = 59;
                    _min--;
                }
            }

            rtfTempo.Text = "0" + _min + ":" + _sec;

            if(_min == 0 && _sec == 0)
            {
                timerT.Enabled = false;
                lblAguarde.Text += " AQUECIDO !!!";
            }
            prgTempo.Value = _prg;
            lblAguarde.Text += ".";

            _prg++;
        }
    }
}
