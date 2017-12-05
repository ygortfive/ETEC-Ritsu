using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RITSU.One_for_All
{
    class ApresentacaoFinal
    {
        ActionProcess ActionProcess = new ActionProcess(); //Processos do Windows;
        Calculation Calculation = new Calculation(); //Realizar operações 
        Commands Commands = new Commands(); // Comandos pre programados
        CommandsEmail Email = new CommandsEmail(); //Email

        public void FinalShow()
        {
            //Commands.Execute("media player");

            //---Introdução---
            Speaker.Speak("Sejam muito bem vindos a feira de projetos da ETEC de Barueri.");
            Speaker.Speak("Me chamo Ritsu e hoje quero lhes mostrar o que a tecnologia é capaz de fazer.");
            Speaker.Speak("Fui desenvolvida por essa equipe a sua frente com a intenção de otimizar e auxiliar usuário, principalmente aqueles com deficiencias fisicas ou motoras.");
            Speaker.Speak("Mas devem estar se perguntando: 'Tá bom Ritsu, muito mimimi, o que você faz?'");
            Speaker.Speak("Posso fazer tarefas simples como dizer que agora são");
            Commands.Execute("que horas sao");            
            Speaker.Speak("de uma");
            Thread.Sleep(42000);
            Commands.Execute("que dia e hoje");            
            
            //---Media player---
            //Thread.Sleep(4000);
            Speaker.Speak("A música que estava tocando eu possuo total controle. Vamos ver o que estava tocando.");
            Thread.Sleep(4000);         
            /*
            Commands.Execute("continuar");            
            Thread.Sleep(30000);
            Commands.Execute("pausar");            
            Speaker.Speak("Não gosto dessa música, vamos para próxima.");
            Thread.Sleep(5000);
            Commands.Execute("proximo");
            Thread.Sleep(1000);
            Commands.Execute("continuar");
            Thread.Sleep(20000);
            Speaker.Speak("Melhorou um pouco");
            Speaker.Speak("Agora está tocando: ");
            Thread.Sleep(2000);
            Commands.Execute("que arquivo esta tocando");
            //Thread.Sleep(10000);
            for (int i = 0; i == 3; i++) { Commands.Execute("diminuir volume"); }  
         
            

            //---Bloco de notas---
            Speaker.Speak("Tenho funções para executar e manipular programas. No momento só possuo funções para o WORD, porém em breve meu leque irá expandir.");
            Thread.Sleep(5000);

            //---Calculadora---
            Speaker.Speak("Vejamos... Sou equipada com auxilio para provas de matematica:");
            Speaker.Speak("18 vezes 35 é igual a ");
            Speaker.Speak(Calculation.calcSolve("18 vezes 35"));
            Thread.Sleep(2000);
            Speaker.Speak("87 mais 24 é igual a ");
            Speaker.Speak(Calculation.calcSolve("87 mais 24"));
            Thread.Sleep(2000);
            Speaker.Speak("50 porcento 90 é igual a ");
            Speaker.Speak(Calculation.calcSolve("50 porcento 90"));
            

            //---Processo windows---
            Speaker.Speak("Vamos dar uma olhada nos processos que estão abertos.");
            ActionProcess.OpenOrClose("abrir gerenciador de tarefas");
            Thread.Sleep(2000);
            Speaker.Speak("Eu também possuo o meu gerenciador.");
            Commands.Execute("lista de processos");
            Speaker.Speak("Por mais simples que pareça em comparação, em breve poderei ter acesso para abrir e finalizar processos com extrema facilidade");

            //---Lista de comandos--
            Speaker.Speak("Para qualquer dúvida eu possuo uma janela com todos meus comandos, basta dizer 'lista de comandos'");
            Commands.Execute("lista de comandos");
            Thread.Sleep(5000);

            //--EMAIL---
            Speaker.Speak("E so para finalizar, alguém poderia me enviar um email?");            
            Commands.Execute("ver email");
             */
        }


    }
}
