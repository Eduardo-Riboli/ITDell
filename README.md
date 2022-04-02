Problema
Dados relativos a bolsas de estudo do governo

Instruções para Desenvolvimento e Empacotamento
Esta atividade avaliativa consiste em duas etapas, sendo a primeira composta de três
questões de lógica e a segunda no desenvolvimento de um programa de computador.
Você deve realizar as duas etapas e entregá-las em um único arquivo em formato .zip
(favor não usar outros formatos de compactação, como .tar ou .7z ou ainda .rar).
Para a etapa 1, copie as perguntas e as suas respostas para um arquivo PDF.
Para a etapa 2, desenvolva uma solução para o problema utilizando a linguagem/ambiente
que preferir. Mesmo que não consiga concluir, que faça apenas partes da solução ou que
tenha uma solução com erros, faça o envio e entregue o que tiver conseguido fazer.
Também deve ser enviado um arquivo em PDF com a explicação da solução. Além dessa
explicação, o arquivo também poderá conter capturas de tela demonstrando a execução,
os resultados e os seus testes, utilizando as estratégias e as ferramentas que conhecer.
Para explicações do código fonte adicione comentários. O PDF desta etapa deverá conter
uma seção de autoavaliação, em que você deverá redigir um parágrafo sobre o seu
desempenho, comentando quais foram os pontos de destaque e os pontos em que teve
alguma dificuldade.

Descrição
O governo brasileiro, junto com a Capes, tem participação na distribuição de bolsas de
estudo e pesquisas no âmbito dos programas de formação de professores para a educação
básica ofertados pela Universidade Aberta do Brasil – UAB. Os dados relativos a essas
bolsas estão disponíveis publicamente no portal de dados abertos da Capes neste link:

https://dadosabertos.capes.gov.br/dataset/629aa27e-141d-4e7a-abbe-
13d8ee461b72/resource/a408841d-8d6a-4883-b450-570d6fee5cba/download/metadados-
bolsistas-uab-2013-a-2016.pdf

Etapa 1 – Enunciado
Para ganhar a bolsa os candidatos precisam fazer algumas provas, são elas:
Conhecimento Gerais (CG), Conhecimento Específicos (CE), Português (P) e Matemática
(M). Cada prova tem a duração de 50 minutos e podem ser alocadas de hora em hora.
Devido ao número reduzido de fiscais:
 As provas serão num sábado, nos horários 8:00, 9:00, 10:00 e 11:00.
 A prova de Conhecimento Gerais deve ser às 8:00.
 A prova de Conhecimento Específico deve ser após a prova de Português e também
após a prova de Conhecimento Gerais.
 As provas de Matemática e Conhecimento Específico devem ser em horários
consecutivos, nessa ordem.
Questão 1. Se a prova de CG for às 8:00, a prova de M deverá ser às:
(A) 9:00
(B) 10:00
(C) 11:00
Questão 2. Se as provas CG e P forem respectivamente às 8:00 e 9:00, a prova de
CE deve ser:
(A) 10:00
(B) 8:00
(C) 11:00
(D) 9:00
Questão 3. Qual das seguintes afirmações é necessariamente verdadeira
(A) A prova de P é após a prova de CE.
(B) A prova de M pode ser realizada antes da prova de P.
(C) A prova de CG é a primeira e a de CE é a última a ser realizada.
(D) Se mudar a prova de CG para 10:00 então a prova de M deve ser as 8:00.
(continua...)

Etapa 2 - Enunciado
Nesta etapa, você vai escrever um programa de computador. Para isso deve ser feita a
leitura do arquivo .csv enviado junto com este enunciado. Neste arquivo você encontra
dados sobre bolsas de estudo no Brasil. Você deve implementar as seguintes
funcionalidades:
1. [Consultar bolsa zero/Ano] Permitir que o usuário informe o ano que desejar e como
resultado o programa deverá exibir:
a. As informações sobre o bolsista zero, ou seja, o primeiro bolsista daquele
ano (Nome, CPF, Entidade de Ensino e Valor da Bolsa);

2. [Codificar nomes] Em alguns casos o nome do aluno bolsista não deve ser exibido
por questão de sigilo. Esta funcionalidade deverá codificar o nome de um bolsista.
Para isso, permitir que o usuário busque um bolsista digitando todo o nome ou parte
dele. Ao localizar o respectivo bolsista, seu nome deve ser codificado e exibido com
as seguintes informações: Nome codificado, Ano, Entidade de ensino, Valor da
Bolsa. A codificação dos caracteres deve ser deduzida a partir dos seguintes
exemplos*:
PERIGO => OERIGP => PGIREO => QHJSFP
FUGA => AUGF => FGUA => GHVB
PAZ => ZAP => ABQ
* Os nomes deverão ser sempre tratados apenas em letras maiúsculas. Letras
acentuadas deverão ser convertidas para as respectivas letras sem os acentos.
Outros sinais deverão ser descartados. Ex. Lúcia D’Ávila  LUCIA DAVILA.

3. [Consultar média anual] Permitir que o usuário informe o ano desejado. Como
resultado, o programa deverá exibir a média dos valores das bolsas daquele ano;

4. [Ranking valores de bolsa] O programa deverá listar dois tipos de colocações:
a. Os três alunos com os valores da bolsa mais altos;
b. Os três alunos com os valores da bolsa mais baixos;

5. [Terminar o programa] Permitir que o usuário saia do programa.

Observações:
a) Sugere-se o desenvolvimento de um programa na linguagem de sua preferência,
com uma interface também de sua preferência podendo ser gráfica ou
textual/console, com um menu com as opções enumeradas nos requisitos;
b) Juntamente a este enunciado foi fornecido um arquivo no formato CSV contendo
nomes, CPFs, datas em um formato tabular, valores em decimais;
c) Você deve escrever o código que lê o arquivo e armazena os dados lidos em
memória (do jeito que você quiser).
d) Não é necessário gravar dados em nenhum formato, nem usar sistemas de banco
de dados.
e) O programa deverá lidar com dados de entrada inválidos e informar uma mensagem
adequada caso ocorram.
f) Para facilitar, não é necessário lidar com a acentuação de palavras.
g) Na escrita do relatório apresente comentários sobre como você realizou os testes.
Não esqueça de incluir uma autoavaliação.
