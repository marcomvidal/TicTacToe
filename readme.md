# TicTacToe

Jogo da velha (Tic Tac Toe) apresentado em uma aplicação Console. Implementa funcionalidades através da programação Orientada a Objetos e Funcional.

## Ferramentas utilizadas
- C# 7.0
- .NET Core 2.2

## Componentes
- `Game`: Classe principal. Reune estado e fluxo do jogo;
- `Finalizer`: Condições para finalização do jogo, seja por vitória ou empate;
- `Player`: Entidade que representa o jogador;
- `Presenter`: Mensagens e exibição da jogadas;
- `Program`: Inicialização e injeção de dependências;
- `Spacing`: Enumerador para definição de espaçamento em mensagens do `Presenter`;
- `Validator`: Validação das entradas de posição oriundas do usuário;
- `WinningPattern`: Repositório

## Repositórios
Todas as operações realizadas - seja em ADO.NET ou Dapper - são rigorosamente as mesmas e estão descritas nas interfaces de `Repository`. Os tipos retornados são sempre aqueles contidos em `Model`. <br />
O `Repository` padrão é `Dapper`. Para alternar, basta alterar a importação de `using CRUDMySQL.Repository.Dapper;` para `using CRUDMySQL.Repository.AdoNet;` em `Program`.

## Apresentação
A camada de apresentação foi desenvolvida em Console, está contida em `View` e foi separada nas seguintes partes: <br />
- `UserInterface`: Controla a interação do usuário, aciona o `Repository` quando necessário e possui todas as condicionais necessárias para lidar com possíveis erros de entrada. É invocada por `Program`, sendo o ponto de chamadas da aplicação; <br />
- `Presenter`: Contém componentes da interface com o usuário que são puramente visuais ou que se repetem, como menus e formulários.

## Desacoplamento das Views
É possível implementar toda a lógica desta aplicação em aplicações desktop, web ou de qualquer outro tipo sem grandes alterações. Neste caso, basta ignorar o conteúdo de `View` e injetar as classes do `Repository` em formulários ou controladores de seu projeto.


