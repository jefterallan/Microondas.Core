using System;
using Microondas.Core.Business;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Microondas.Core
{
    public partial class frmMicroondas : Form
    {
        private int _time = 0;
        private int _min = 0;
        private int _sec = 0;
        private int _prg = 1;
        private List<string> _newProgram = new List<string>();

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
            m.clean(rtfTempo, rtfPotencia, prgTempo, lblAguarde, timerT, lblAquecer);
        }

        private void BtnPotencia_Click(object sender, System.EventArgs e)
        {
            rtfPotencia.Text = m.addPower(rtfPotencia.Text);
        }      

        private void BtnFrango_Click(object sender, EventArgs e)
        {
            rtfTempo.Text = "2:00";
            rtfPotencia.Text = "10";
            start(btnFrango.Text);
        }

        private void BtnCarne_Click(object sender, EventArgs e)
        {
            rtfTempo.Text = "1:50";
            rtfPotencia.Text = "8";
            start(btnCarne.Text);
        }

        private void BtnPorco_Click(object sender, EventArgs e)
        {
            rtfTempo.Text = "1:59";
            rtfPotencia.Text = "9";
            start(btnPorco.Text);
        }

        private void BtnPipoca_Click(object sender, EventArgs e)
        {
            rtfTempo.Text = "1:30";
            rtfPotencia.Text = "5";
            start(btnPipoca.Text);
        }

        private void BtnMiojo_Click(object sender, EventArgs e)
        {
            rtfTempo.Text = "0:59";
            rtfPotencia.Text = "6";
            start(btnMiojo.Text);
        }

        private void BtnIniciar_Click(object sender, System.EventArgs e)
        {
            start("Padrão");
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            if (btnNovo.Text.Contains("NOVO"))
            {
                if (messageYesNo("new") == DialogResult.Yes)
                {
                    m.firstStep(rtfTempo);
                    btnProximo.Enabled = true;
                    btnNovo.Enabled = false;
                    btnProximo.Text = "Tempo";
                }
            }
            else
            {
                rtfTempo.Text = _newProgram[0];
                rtfPotencia.Text = _newProgram[1];
                start(_newProgram[2]);
            }
        }

        private void BtnProximo_Click(object sender, EventArgs e)
        {
            if (m.step.Equals(1))
            {
                if (messageYesNo("time") == DialogResult.Yes)
                {
                    _newProgram.Add(rtfTempo.Text);
                    m.secondStep(rtfPotencia);
                    btnProximo.Text = "Potencia";
                }
            }
            else if (m.step.Equals(2))
            {
                if (messageYesNo("power") == DialogResult.Yes)
                {
                    _newProgram.Add(rtfPotencia.Text);
                    m.thirdStep(rtfTempo);
                    btnProximo.Text = "Salvar";
                }
            }
            else if (messageYesNo("save") == DialogResult.Yes)
            {
                _newProgram.Add(rtfTempo.Text);
                m.fourthStep(rtfTempo);
                btnProximo.Enabled = false;
                btnNovo.Enabled = true;
                btnNovo.Text = rtfTempo.Text;
                m.clean(rtfTempo, rtfPotencia, prgTempo, lblAguarde, timerT, lblAquecer);
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            _newProgram.Clear();
            btnNovo.Text = "NOVO";
        }

        private void start(string type)
        {
            _prg = 1;
            prgTempo.Value = 0;

            if (m.startDefault(rtfTempo, rtfPotencia))
            {
                lblAquecer.Text = "Aquecendo: " + type;

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
            if (_min > 0)
            {
                if (_sec < 0)
                {
                    _sec = 59;
                    _min--;
                }
            }

            rtfTempo.Text = "0" + _min + ":" + _sec;

            if (_min == 0 && _sec == 0)
            {
                timerT.Enabled = false;
                lblAguarde.Text += " AQUECIDO !!!";
                lblAquecer.Text = "Pronto";
            }
            prgTempo.Value = _prg;
            lblAguarde.Text += ".";

            _prg++;
        }

        public DialogResult messageYesNo(string type)
        {
            switch (type)
            {
                case "new":
                    return MessageBox.Show("Deveja Castrar Novo Programa?", "Novo Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                case "time":
                    return MessageBox.Show("Confirma o Tempo?", "Tempo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                case "power":
                    return MessageBox.Show("Confirma a Potência?", "Potência", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                case "save":
                    return MessageBox.Show("Salvar Programa?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            }
            return DialogResult.No;
        }        
    }
}
