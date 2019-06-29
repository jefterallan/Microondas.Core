using System;
using System.Windows.Forms;

namespace Microondas.Core.Business
{
    class MicroondasBusiness
    {
        private string _time = "";
        private int _power = 0;

        public string addNumber(object sender, RichTextBox r)
        {
            Button b = sender as Button; //cria um botao para ser possivel acessar as propriedades dele a partir do object sender

            _maxLength(b.Text, r.Text, r.Text.Length); // chama a função para verificação de limites da documentação

            return _time;//retorna para tela o valor clicado
        }

        //verifica se as entradas não estouram o tempo máximo estipulado na documentação
        private void _maxLength(string b, string r, int l)
        {
            //verifica se esta na 1ª posição
            if (l == 0)
                if (Convert.ToInt32(b) > 2)// verifica se a entrada é maior que 2, se for exibe msg
                {
                    MessageBox.Show("Não é Permitido inserir mais de 2 Minutos");
                    b = "";
                }

            var s = r.Split(':'); // quebra a string onde tem ':' criando um tipo string[]

            if (s[0].Contains("0"))//verifica se na 1ª posição tem o número '0'
                if (l == 1 || l == 2)//verifica se o tamanho do texto na tela é igual a 1 ou 2
                    if (Convert.ToInt32(b) > 5)// verifica se a entrada é maior que 5, se for exibe msg
                    {
                        MessageBox.Show("Máximo 59 segundos");
                        b = "";//'zera' o numero para nao ser adicionado na tela
                    }

            if (s[0].Contains("1"))//verifica se na 1ª posição tem o número '1'
                if (l == 1 || l == 2)//verifica se o tamanho do texto na tela é igual a 1 ou 2
                    if (Convert.ToInt32(b) > 5)// verifica se a entrada é maior que 2, se for exibe msg
                    {
                        MessageBox.Show("Máximo 1:59 segundos");
                        b = "";//'zera' o numero para nao ser adicionado na tela
                    }

            if (s[0].Contains("2"))//verifica se na 1ª posição tem o número '1'
                if (l == 1 || l == 2 || l == 3)//verifica se o tamanho do texto na tela é igual a 1 ou 2 ou 3
                    if (Convert.ToInt32(b) > 0)// verifica se a entrada é maior que 0, se for exibe msg
                    {
                        MessageBox.Show("Não é Permitido inserir mais de 2:00 Minutos");
                        b = "";//'zera' o numero para nao ser adicionado na tela
                    }

            //verifica se já existe a separação de minutos:segundos, se não ele insere o separador ':'
            if (!r.Contains(":") && l == 1)
                _time = _time + ":";

            //adiciona o numeros enquanto o tamanho exibido na tela for de 4 digitos '00:00', senão ele ignora
            if (l < 4)
                _time = _time + b;
        }
        
        //limpa os dados da tela
        public void clean(RichTextBox t, RichTextBox p, ProgressBar pr, Label l, Timer timer)
        {
            _time = ""; //limpar variavel _time
            _power = 0;//limpar variavel _power
            t.Clear();//limpar RichTextBox time
            p.Clear();//limpar RichTextBox potencia
            pr.Value = 0;//limpar ProgressBar tempo
            l.Text = "Aguarde";//limpar Label Aguarde
            timer.Enabled = false;//limpar Label Aguarde
        }

        //adiciona potencia
        public string addPower(string p)
        {
            p = (p == "") ? "0" : p;//if ternario para verificar se a string é vazia

            if (Convert.ToInt32(p) == 10)//verifica se a potencia esta no maximo (10), se sim reseta pra 1
                _power = 1;
            else
                _power = _power + 1;//senao adiciona +1 

            return _power.ToString();//retorna potencia para tela
        }

        public bool startDefault(RichTextBox t, RichTextBox p)
        {
            if (t.Text.Length.Equals(0))//verifica se a tela esta vazia, se sim adiciona parametros de inicio rápido
            {
                t.Text = "0:30";
                p.Text = "8";
                return true;
            }

            if (t.Text.Equals("0:00"))//verifica tempo de inicio se esta zerado, se sim solta msg para usuario de minimo 0:01 segundos
            {
                MessageBox.Show("Mínimo para Inicio de 0:01 segundos");
                return false;
            }

            if (t.Text.Length < 4)//verifica se a tela esta preenchida corretamente, senao solta msg
            {
                MessageBox.Show("Preencha com dados entre 00:01 a 02:00");
                return false;
            }

            if (p.Text.Equals(""))//verifica tempo de inicio se esta zerado, se sim solta msg para usuario de minimo 0:01 segundos
            {
                MessageBox.Show("Informe a Potencia para Iniciar");
                return false;
            }

            return true;
        }
    }
}
