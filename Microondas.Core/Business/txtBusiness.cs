using System;
using System.Collections.Generic;
using System.IO;

namespace Microondas.Core.Business
{
    class txtBusiness
    {
        //caminho completo
        private string _fullPath = @Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + 
            "\\GitHub\\Microondas.Core\\txtMicroondas.txt";

        //local da pasta Meus Documentos/GitHub/Jefter
        private string _directory = @Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + 
            "\\GitHub\\Microondas.Core\\";

        //nome do arquivo
        private string _file = "txtMicroondas.txt";
        
        //retorna se existe o local/arquivo ou nao
        public void returnPath()
        {
            //verifica se arquivo existe
            if (!fileExists())
            {
                if(!Directory.Exists(_directory))
                    Directory.CreateDirectory(_directory);

                firstLoad();
            }
        }

        //retorna se existe o arquivo
        private bool fileExists()
        {
            if (File.Exists(_directory + _file))
                return true;
            return false;
        }

        //preenche o txt pela primeira vez
        private void firstLoad()
        {
            List<string> txt = new List<string>() {
                    "frango,2:00,10",
                    "carne,1:50,8",
                    "porco,1:59,9",
                    "pipoca,1:30,5",
                    "miojo,0:59,6"
                };
            StreamWriter sw = new StreamWriter(_fullPath, true);
            sw.Close();
            File.WriteAllLines(_fullPath, txt);
        }

        //escreve o arquivo
        public void writeTxt(List<string> txt)
        {
            StreamWriter sw = new StreamWriter(_fullPath, true);

            using (sw)
            {
                // Escreve uma nova linha no final do arquivo
                sw.WriteLine(txt);
            }
            sw.Close();
        }

        //consulta o arquivo
        public List<string> readTxt()
        {
            List<string> txt = new List<string>();

            using (StreamReader sr = new StreamReader(_fullPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    txt.Add(line);
                }
            }
            return txt;
        }

        //exclui o arquivo
        public void deleteTxt(List<string> txt, string del)
        {
            using (StreamReader sr = new StreamReader(_fullPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(del))
                    {
                        List<string> empty = new List<string>() { };
                        writeTxt(empty);
                    }
                }
            }
            txt.Contains(del);
        }
    }
}
