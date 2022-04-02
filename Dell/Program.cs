using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

/* @author Eduardo Pasqualotto Riboli - Ciência da Computação (PUCRS)
 * @email EduardoRiboli71@gmail.com
 */

namespace Dell
{
    public class Program
    {
        // Criação da lista Bolsistas para armazenar cada linha do csv (que corresponde a um bolsista)
        static List<Bolsistas> listBolsistas = new List<Bolsistas>();

        static List<char> final = new List<char>();
        static List<char> finals = new List<char>();

        // Caminho atual para o arquivo .csv ser lido.
        static string path = @"C:\Prog\ws-csharp\Dell\Data\br-capes-bolsistas-uab.csv";

        static void Main(string[] args)
        {
            // O projeto começa como falso e, caso não ocorra nenhum erro, será atribuido "true" ao final dele.
            bool work = false;

            // Caso exista o arquivo, ele realiza a leitura do mesmo.
            if (File.Exists(path))
            {
                try
                {
                    // Tenta ler o arquivo csv
                    using (StreamReader sr = new StreamReader(path))
                    {
                        // Cria-se a variável "line" para ler cada linha do arquivo csv
                        var line = sr.ReadLine();
                        // Atribui uma nova linha à variável "line" para ela começar a ler as linhas após o nome das colunas.
                        line = sr.ReadLine();
                        // Lê linha por linha do arquivo
                        while (line != null)
                        {
                            // Cada linha do arquivo csv se torna um array com índice correspondente a sua posição, separado por ";"
                            string[] parts = line.Split(';');

                            // Atribuindo cada índice do array a uma variável
                            string nomeBolsista = parts[0];
                            string cpfBolsista = parts[1];
                            string entidadeEnsino = parts[2];
                            int referencia = int.Parse(parts[3]);
                            int anoReferencia = int.Parse(parts[4]);
                            string diretoria = parts[5];
                            string sistemaOrigem = parts[6];
                            int modalidade = int.Parse(parts[7]);
                            string modalidadePagamento = parts[8];
                            string moeda = parts[9];
                            int pagamento = int.Parse(parts[10]);

                            // Instância o objeto Bolsistas e atribui as variáveis com cada índice do array acima
                            Bolsistas bolsistas = new Bolsistas(nomeBolsista, cpfBolsista, entidadeEnsino, referencia,
                                anoReferencia, diretoria, sistemaOrigem, modalidade, modalidadePagamento, moeda, pagamento);

                            // Adiciona o objeto instanciado na lista de Bolsistas
                            listBolsistas.Add(bolsistas);
                            line = sr.ReadLine();

                            // Se não houver nenhum erro, work passa a valer true
                            work = true;
                        }
                    }
                    var teste = listBolsistas;
                }
                catch (Exception ex)
                {
                    // Caso haja alguma exceção, ela será mostrada aqui
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                // Caso não exista o arquivo selecionado, exibe essa mensagem avisando que o arquivo não existe.
                Console.WriteLine("O arquivo " + path + "não existe.");
            }

            if (work)
            {
                menu();
            }
        }

        public static void menu()
        {
            // Aqui será mostrada as opções que o usuário poderá escolher.
            Console.WriteLine("Digite o número da opção abaixo:");
            Console.WriteLine("1 - Consultar bolsa zero/Ano");
            Console.WriteLine("2 - Codificar nomes");
            Console.WriteLine("3 - Consultar média anual");
            Console.WriteLine("4 - Ranking valores de bolsa");
            Console.WriteLine("5 - Terminar o Programa");
            Console.WriteLine();
            Console.Write("Opção: ");

            int option;

            option = menuOptions();

            // O switch serve para pegar o número que o usuário digitar e executar sua determinada opção.
            switch (option)
            {
                case 1:
                    option1();
                    Console.WriteLine();
                    break;
                case 2:
                    option2();
                    Console.WriteLine();
                    break;
                case 3:
                    option3();
                    Console.WriteLine();
                    break;
                case 4:
                    option4();
                    Console.WriteLine();
                    break;
                case 5:
                    option5();
                    break;
                default:
                    // Caso o usuário não digite um número de 1 a 6, pede-se que ele digite de novo, aparecendo novamente o menu.
                    Console.WriteLine("Você digitou uma opção inválida, por favor, digite um número de 1 a 6");
                    menu();
                    break;
            }
            menu();
        }
        // Método criado para armazenar o valor digitado pelo usuário e retornando o mesmo.
        public static int menuOptions()
        {
            int option;
            try
            {
                // Recebe a opção digitada pelo usuário em formato de string e converte para inteiro.
                option = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            catch
            {
                // Se o usuário não digitar um número válido, avisa o usuário e repete as opções
                Console.WriteLine("Você digitou uma opção inválida, por favor, digite um número de 1 a 6");
                menu();
                option = menuOptions();
            }
            return option;
        }

        public static void option1()
        {
            Console.Write("Digite o ano que desejar para obter a informação do primeiro bolsista: ");

            try
            {   
                // Armazena na variável 'anoDigitado' o ano digitado pelo usuário.
                int anoDigitado = int.Parse(Console.ReadLine());
                foreach (Bolsistas bolsistas in listBolsistas)
                {
                    // Se o ano digitado for igual ao primeiro bolsista daquele ano, ele executará o if.
                    if (bolsistas.getAno().Equals(anoDigitado))
                    {
                        Console.WriteLine(bolsistas.getNome() + ", " + bolsistas.getCpf() + ", "
                                        + bolsistas.getEntidade() + " e " + bolsistas.getPagamento());
                        break;
                    }
                }
            }
            // Caso ocorra alguma exceção, ela será mostrada aqui.
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }

        }

        public static void option2()
        {
            try
            {
                Console.Write("Digite o nome do bolsista que você procura: ");
                // Captura o nome digitado pelo usuário e converte para letra maiúscula.
                string nomeBolsista = Console.ReadLine().ToUpper();
                // Armazenei em um array de string, todos os caracteres possíveis que não são letras.
                string[] charsRemove = new string[] {"@", ",", ".", ";", "'", "á", "â", "ã", "à", "é", "ê", "í", "ì",
                                                 "ó", "ô", "õ", "ú", "!", "#", "$", "%", "&", "*", "(", ")", "-",
                                                 "_", "|", ">", "<", "{", "}", "[", "]", "+", "=", "?", "1", "2",
                                                 "3", "4", "5", "6", "7", "8", "9", "0", "¨"};

                // Cria-se 2 listas que serão utilizadas para armazenar as letras de cada nome do usuário.
                List<char> primeiraParte = new List<char>();
                List<char> segundaParte = new List<char>();

                foreach (string caracter in charsRemove)
                {
                    // Utiliza-se esse laço de repetição para remover quaisquer caracteres indesejados no nome do bolsista.
                    nomeBolsista = nomeBolsista.Replace(caracter, string.Empty);
                }

                foreach (Bolsistas bolsistas in listBolsistas)
                {
                    // Se o nome do bolsista contém alguma parte do nome digitado pelo usuário, ele executa todas as opções abaixo.
                    if (bolsistas.getNome().Contains(nomeBolsista))
                    {
                        // Armazena o ano, a entidade e o valor da bolsa desse bolsista.
                        int ano = bolsistas.getAno();
                        string entidade = bolsistas.getEntidade();
                        int valor = bolsistas.getPagamento();

                        // Separa o nome do bolsista por espaço, separando assim o nome, nome do meio, sobrenome, e assim por diante.
                        string[] shaffleName = bolsistas.getNome().Split(' ');

                        // A partir de quantas palavras contém o nome completo do bolsista, realiza-se um laço de repetição.
                        for (int i = 0; i < shaffleName.Length; i++)
                        {
                            // Transforma a palavra do nome do bolsista em um array de char, pegando letra por letra.
                            char[] charArray = shaffleName[i].ToCharArray();

                            // Se a nome do bolsista contém apenas 3 letras, ele troca de lugar somente a primeira e a última palavra.
                            if (shaffleName[i].Length == 3)
                            {
                                char substitut = charArray[0];
                                charArray[0] = charArray[2];
                                charArray[2] = substitut;

                            }

                            // Caso o tamanho do nome do bolsista for ímpar, ele executará um laço de repetição específico para esse nome ímpar.
                            else if (shaffleName[i].Length % 2 == 1)
                            {
                                // Preferi dividir o nome em 2 metades, a 'primeiraParte', fica com o número ímpar e a 'segundaParte' fica com o número par.
                                // Exemplo nome: Roberto
                                // primeiraParte: Rob
                                // segundaParte: erto
                                for (int j = 0; j < shaffleName[i].Length / 2; j++)
                                {
                                    if (j == 0)
                                    {
                                        // Se for a primeira letra da palavra, ele armazenará direto na variável final pois ela permanecerá na primeira posição.
                                        final.Add(charArray[0]);
                                    }
                                    // Contudo, ele adiciona também ela na primeira parte, para obtermos o resultado ímpar como o exemplo citado acima.
                                    primeiraParte.Add(charArray[j]);

                                }
                                // Nessa segunda parte, ele começa o laço de repetição após a última palavra adicionada do laço anterior.
                                for (int k = shaffleName[i].Length / 2; k < shaffleName[i].Length; k++)
                                {
                                    // Adiciona cada letra na lista 'segundaParte'.
                                    segundaParte.Add(charArray[k]);
                                }
                                // Chama o método Change() para realizar a troca de letras da palavra ímpar das duas listas (primeiraParte e segundaParte).
                                ChangeOdd(primeiraParte, segundaParte);
                                // Após realizar a troca, ele chama novamente o método para adicionar as letras codificadas à lista 'finals'.
                                ChangeOdd(segundaParte, primeiraParte);
                            }
                            // Caso tamanho do nome do bolsista não for ímpar (ou seja, par), ele executará um laço de repetição específico para esse nome par.
                            else
                            {
                                for (int j = 0; j < shaffleName[i].Length / 2; j++)
                                {
                                    // Se for par, preferi fazer como se fosse ímpar, já que estava utilizando aquela lógica, assim já envio a primeira letra da palavra para a variável
                                    // final, deixando, deste modo, a palavra com metade ímpar e metade par.
                                    // Exemplo: Carlos
                                    // C -> é enviado para a variável final
                                    // primeiraParte: ar
                                    // segundaParte: los
                                    if (j == 0)
                                    {
                                        // Se for a primeira letra, converte ela para a próxima letra do alfabeto e já armazena na variável que será utilizada para a impressão (finals).
                                        finals.Add(alpha(charArray[0]));
                                    }
                                    else
                                    {
                                        // Adiciona letra por letra, até chegar na metade da palavra, na lista 'primeiraLista'
                                        primeiraParte.Add(charArray[j]);
                                    }
                                }
                                // Nessa segunda parte, ele começa o laço de repetição após a última palavra adicionada do laço anterior.
                                for (int k = shaffleName[i].Length / 2; k < shaffleName[i].Length; k++)
                                {
                                    // Adiciona letra por letra na lista 'segundaParte'
                                    segundaParte.Add(charArray[k]);
                                }
                                // Chama o método ChangeEven() para realizar a troca de letras da palavra par das duas listas (primeiraParte e segundaParte).
                                ChangeEven(primeiraParte, segundaParte);
                                // Após realizar a troca, ele chama novamente o método para adicionar as letras codificadas à lista 'finals'.
                                ChangeEven(segundaParte, primeiraParte);
                            }
                        }
                        Console.Write("Ano: " + ano + ", entidade: " + entidade + ", valor: " + valor + " e o nome codificado é: ");
                    }
                    // Esse laço é o responsável por imprimir na tela o nome completo do usuário codificado armazenado na lista 'finals'
                    for (int i = 0; i < finals.Count; i++)
                    {
                        Console.Write(finals[i]);
                    }

                    // Se após a impressão, houver algum valor na variável finals, ele limpará a variável e encerrará o laço de repetição.
                    if (finals.Count > 0)
                    {
                        finals.Clear();
                        final.Clear();
                        break;
                    }
                }              
            } 
            // Caso ocorra algum erro, ele será mostrado aqui.
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void option3()
        {
            Console.Write("Digite o ano que desejar para obter a média dos valores da bolsa: ");
            try { 
                // Variável para armazenar o ano digitado pelo usuário;
                int anoDigitado = int.Parse(Console.ReadLine());

                // Cria-se uma lista para armazenar o valor das bolsas dos bolsistas daquele ano digitado.
                List<int> pagamento = new List<int>();

                // Cria-se uma variável para somar todos os valores das bolsas do ano digitado.
                int soma = 0;

                foreach (Bolsistas bolsistas in listBolsistas)
                {
                    if (bolsistas.getAno().Equals(anoDigitado))
                    {
                        // Soma o valor da bolsa aos valores já armazenados anteriormente.
                        soma += bolsistas.getPagamento();
                        // Adiciona o valor da bolsa na lista pagamento.
                        pagamento.Add(bolsistas.getPagamento());
                    }
                }
                // Calcula-se a média pegando a soma total dos valores das bolsas e dividindo pela quantidade elementos na lista pagamento.
                double total = (double) soma / pagamento.Count;
                Console.WriteLine("A média dos valores das bolsas dos bolsistas no ano de " + anoDigitado +
                    " é " + total.ToString("F2", CultureInfo.InvariantCulture)); // Adiciona-se o CultureInfo.InvariantCulture para deixar o "." como separador decimal.
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void option4()
        {
            List<int> valores = new List<int>(); // Lista criada para armazenar os valores das bolsas dos bolsistas
            List<string> nome = new List<string>(); // Lista criada para armazenar os nomes dos bolsistas dos correspondentes valores acima.
            List<int> max = new List<int>(); // Lista criada para armazenar o valor máximo possível de uma bolsa.
            List<int> min = new List<int>(); // Lista criada para armazenar o valor mínimo possível de uma bolsa.
            List<string> nomeMax = new List<string>(); // Lista criada para armazenar os 3 nomes com os valores máximos de bolsa.
            List<string> nomeMin = new List<string>(); // Lista criada para armazenar os 3 nomes com os valores mínimos de bolsa.

            foreach (Bolsistas bolsistas in listBolsistas)
            {
                // Obtêm, através do foreach, todos os nomes e valoes de bolsa dos bolsistas.
                valores.Add(bolsistas.getPagamento());
                nome.Add(bolsistas.getNome());
            }

            // Adiciona em suas respectívas listas, o valor máximo e mínimo das bolsas.
            max.Add(valores.Max());
            min.Add(valores.Min());

            foreach (Bolsistas bolsista in listBolsistas)
            {
                // Se o valor da bolsa for igual ao valor máximo, ele obtém o nome desse 3 bolsistas.
                if(bolsista.getPagamento() == max.Max())
                {
                    if (nomeMax.Count < 3)
                    {
                        string name = bolsista.getNome();
                        nomeMax.Add(name);
                    }
                }

                // Se o valor da bolsa for igual ao valor mínimo, ele obtém o nome desse 3 bolsistas.
                if (bolsista.getPagamento() == min.Min())
                {
                    if (nomeMin.Count < 3)
                    {
                        string name = bolsista.getNome();
                        nomeMin.Add(name);
                    }
                }
            }

            // Escreve no console, por meio do for, os 3 bolsistas com as bolsas máximas e mínimas, correspondentemente.
            for (int i = 0; i < nomeMax.Count; i++)
            {
                Console.WriteLine(i + 1 + "° aluno com a maior bolsa: " + nomeMax[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < nomeMin.Count; i++)
            {
                Console.WriteLine(i + 1 + "° aluno com a menor bolsa: " + nomeMin[i]);
            }
        }

        public static void option5()
        {
            // Ele força a saída do programa, parando o console.
            Console.WriteLine("Saindo...");
            Environment.Exit(0);
        }

        // Esse método é o responsável por realizar as trocas das letras das palavras ímpares.
        public static void ChangeOdd(List<char> change, List<char> swap)
        {
            // Se a quantidade de elementos da lista change for maior que a da lista swap, ele armazena os valores na lista finals.
            if (change.Count > swap.Count)
            {
                // Utiliza-se em ambos foreach o método alpha() para trocar a letra correspondente para a próxima letra do alfabeto.
                foreach (char c in swap)
                {
                    finals.Add(alpha(c));
                }
                foreach (char c in change)
                {
                    finals.Add(alpha(c));
                }
                // Após armazenar os valores na lista, ele da um "espaço em branco" de distância de cada palavra e limpa a lista change e swap.
                finals.Add(' ');
                change.Clear();
                swap.Clear();
            } 
            else
            {
                // Caso change não for maior que swap, ele executará esse laço.
                for (int i = 1; i < change.Count; i++)
                {
                    // Caso a palavra tiver mais que duas letras, ele trocará de posição as letras conforme o valor de i
                    if (change.Count > 2)
                    {
                        // Essa é uma troca básica, pegando o valor na posição i e o valor na posição final - i, desse modo, trocando ambos de lugar.
                        char substitut = change[i];
                        change[i] = swap[swap.Count - i - 1];
                        swap[swap.Count - i - 1] = substitut;

                        // Adiciona a letra resultante desse processo na lista final.
                        final.Add(change[i]);
                    }
                    else
                    {
                        // Caso a lista change só tiver 1 letra, ele pega esse letra e troca pela primeira letra da lista swap.
                        char substitut = change[i];
                        change[i] = swap[i];
                        swap[i] = substitut;

                        // Adiciona as duas letras na lista final em suas respectivas ordens e quebra o laço de repetição.
                        final.Add(change[i]);
                        final.Add(swap[i]);
                        break;
                    }
                }
            }
        }

        // Esse método é o responsável por realizar as trocas das letras das palavras pares.
        // Tive que criar outro método pois facilitaria na troca das letras das palavras pares pois em nenhum momento haverá uma letra que seria o termo médio da palavra.
        public static void ChangeEven(List<char> change, List<char> swap)
        {
            // Se a lista 'change' for maior que a lista 'swap', ele adicionará letra por letra na lista 'finals'.
            if (change.Count > swap.Count)
            {
                // Utiliza-se em ambos foreach o método alpha() para trocar a letra correspondente para a próxima letra do alfabeto.
                foreach (char c in swap)
                {   
                    finals.Add(alpha(c));
                }
                foreach (char c in change)
                {
                    finals.Add(alpha(c));
                }
                // Após adicionar todas as letras, ele da espaço entre as palavras e limpa as duas listas (change e swap).
                finals.Add(' ');
                change.Clear();
                swap.Clear();
            }
            else
            {
                for (int i = 0; i < change.Count; i++)
                {
                    if (change.Count > 1)
                {
                    // Essa é uma troca básica, pegando o valor na posição i e o valor na posição final - i - 2, desse modo, trocando ambos de lugar.
                    char substitut = change[i];
                    change[i] = swap[swap.Count - i - 2];
                    swap[swap.Count - i - 2] = substitut;

                    // Adiciona a letra resultante desse processo na lista final.
                    final.Add(change[i]);
                }
                else
                {                     
                    // Esse laço, simplesmente substituirá a letra armazenada na lista change na posição i pela letra armazenada na lista swap na posição i e vice-versa.
                    char substitut = change[i];
                    change[i] = swap[i];
                    swap[i] = substitut;

                    // Após a troca, ele armazena as duas letras na lista 'final' e quebra o laço de repetição.
                    final.Add(change[i]);
                    final.Add(swap[i]);
                    break;
                    }
                }
            }
        }

        // Esse método é utilizado somente para a troca de uma letra pela sua sucessora no alfabeto.
        public static char alpha(char finals)
        {
            // Cria-se uma string com todas as letras do alfabeto.
            string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // Converte a respectiva letra que viria como parametro no método e converte para número.
            int pos = alfabeto.IndexOf(finals);
            // Adiciona um número 
            pos++;
            // Converte o novo número em um caractér sucessor a letra que veio como parâmetro e retorna o mesmo para ele poder ser adicionado na lista 'finals'.
            finals = Convert.ToChar(alfabeto[pos]);
            return finals;
        }
    }
}
