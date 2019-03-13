# TicTacToe

Jogo da velha (Tic Tac Toe) apresentado em uma aplicação Console. Implementa funcionalidades através da programação orientada a objetos e funcional.

## Ferramentas utilizadas
- C# 7.0
- .NET Core 2.1

## Componentes
- `Core`: Classes principais que controlam o fluxo e personagens do jogo;
- `Verification`: Checagens de entrada do usuário, finalização do jogo e seus repectivos padrões;
- `View`: Exibição de mensagens e renderização do tabuleiro;
- `Program`: Inicialização e injeção de dependências;

## Core
Controla estado e fluxo do jogo. Os jogadores são instâncias de `Player`, que são injetadas em `Game`. Foi adotada uma abordagem fortemente orientada a objetos, buscando forte coesão e desacoplamento.

## Verification
Provavelmente a parte mais interessante deste projeto. Divide-se nas seguintes partes: <br />
- `Finalizer`: Contém as condições onde o jogo é finalizado por vitória ou empate; <br />
- `Validator`: Avalia as entradas do usuário e determina se serão aceitas ou novamente solicitadas; <br />
- `WinningPattern`: A razão da existência deste projeto. É descrita em maiores detalhes mais adiante neste documento.

## View
Exibe mensagens e o tabuleiro do jogo. Foi adotada uma abordagem mais funcional, fazendo uso de funções de primeira ordem para exibição de algumas informações que necessitem de estilização visual.

## WinningPattern
A forma mais óbvia de checar se algum dos jogadores venceu o jogo seria fazer um condicional com todos os padrões possíveis. Apesar de operante, esta abordagem é bastante deselegante e de difícil legibilidade. <br /><br />
Visando avaliar as virtudes da programação funcional, nesta classe foram desenvolvidas funções lambda (`Func<T1, ...>` em C#) que compõem uma lista de padrões para considerar se o jogo foi vencido por algum dos jogadores. <br /><br />
O resultado é bastante satisfatório. Caso seja necessário acrescentar novos padrões, basta criar uma nova função nesta classe e referenciá-la na lista `winningPatterns` da classe `Finalizer`. Esta abordagem se faz, deste modo, muito útil para checagem de padrões em geral.

## Execução
O jogo pode ser executado abrindo o arquivo TicTacToe.exe, presente em bin\Release\netcoreapp2.1\win7-x86. Foi inicialmente compilado para Windows 7 x86, mas também pode sê-lo para Linux ou outras variações de Windows.


