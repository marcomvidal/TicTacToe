# TicTacToe

Jogo da velha (Tic Tac Toe) apresentado em uma aplicação Console. Implementa funcionalidades através da programação orientada a objetos e funcional.

## Ferramentas utilizadas
- C# 8.0
- .NET Core 3.0

## Componentes
- `Core`: Classes principais que controlam o fluxo e personagens do jogo;
- `Verifiers`: Checagens de entrada do usuário, finalização do jogo e seus repectivos padrões;
- `Views`: Exibição de mensagens e renderização do tabuleiro;
- `Program`: Inicialização e injeção de dependências;

## Core
Controla estado e fluxo do jogo. Os jogadores são instâncias de `Player`, que são injetadas em `Game`. Foi adotada uma abordagem fortemente orientada a objetos, buscando forte coesão e desacoplamento.

## Verifiers
Provavelmente a parte mais interessante deste projeto. Divide-se nas seguintes partes: <br />
- `Finalizer`: Contém as condições onde o jogo é finalizado por vitória ou empate; <br />
- `Validator`: Avalia as entradas do usuário e determina se serão aceitas ou novamente solicitadas; <br />
- `WinningPattern`: A razão da existência deste projeto. É descrita em maiores detalhes mais adiante neste documento.

## Views
Exibe mensagens e o tabuleiro do jogo. Foi adotada uma abordagem mais funcional, fazendo uso de funções de primeira ordem para exibição de algumas informações que necessitem de estilização visual.

## WinningPattern
A forma mais óbvia de checar se algum dos jogadores venceu o jogo seria fazer um condicional com todos os padrões possíveis. Apesar de operante, esta abordagem é bastante deselegante e de difícil legibilidade. <br /><br />
Visando avaliar as virtudes da programação funcional, nesta classe foram desenvolvidas funções lambda (`Func<T1, ...>` em C#) que compõem uma lista de padrões para considerar se o jogo foi vencido por algum dos jogadores. <br /><br />
O resultado é bastante satisfatório. Caso seja necessário acrescentar novos padrões, basta criar uma nova função nesta classe e referenciá-la na lista `winningPatterns` da classe `Finalizer`. Esta abordagem se faz, deste modo, muito útil para checagem de padrões em geral.

## Execução
O jogo pode ser executado abrindo o arquivo `TicTacToe.exe`, presente em `/publish`. Foi inicialmente compilado para Windows 7 x86, mas também pode sê-lo para Linux ou outras variações de Windows.<br>
O Windows SmartScreen pode alertá-lo sobre a execução, uma vez que o aplicativo não possui assinatura digital. Neste caso, basta selecionar "Executar assim mesmo".

## Screenshots
* [Jogatina](https://raw.githubusercontent.com/marcomvidal/TicTacToe/master/screenshot_turnos.png)
* [Finais por vitória e empate](https://raw.githubusercontent.com/marcomvidal/TicTacToe/master/screenshot_gameover.png)
