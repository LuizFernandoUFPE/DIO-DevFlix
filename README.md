# DIO-DevFlix
Usando o projeto disponibilizado pela DIO como base, foi criado o DevFlix, um APP em .NET para cadastro de cursos para a área de desenvolvimento voltado para desenvolvedores.



A principal alteração em comparação com o projeto base da DIO, foi a utilização do generic collection Dictionary ao invés da Lista Genérica, entretanto, em primeiro lugar foi implementado alterações no Program.



Assim foi feita uma limpeza, onde além de adicionar textos em partes relevantes e deixar o espaçamento mais organizando entre as linhas de código, também foi adicionado opções para controlar problemas que o usuário possa encontrar, como:



-Colocar uma opção inválida;
-Colocar uma opção fora da margem estabelecida;
-Selecionar um método quando não possui itens cadastrados.


Por uma boa prática de programação, os nomes das classes, métodos, membros, etc.. também foram alterados para melhor atender a quem for ler o código e buscar entender.



A utilização de uma Classe para criar um repositório, atendendo ao Design Pattern: Repository, foi mantida e atualizada para agilizar o funcionamento dos métodos no programa..



Por fim, a principal alteração como mencionada acima, foi levado em conta a utilização de um Dictionary ao invés da Lista utilizada no curso, alterando todo o código na classe com os repositórios, tendo em vista fazer conexão entre os ID's do cadastro, e as keys do Dictionary.



A principal dificuldade encontrada então, foi fazer essa mudança de Lista para Dicionário, mantendo todo o código coeso e funcional com o que era proposto. Para superar, foi utilizado os documentos da Microsoft sobre Dictionary, além da ferramenta de Debug do Visual Studio Code para compreender o que acontecia nas partes em que os erros aconteciam. Dessa forma, também consegui mesclar os dois conceitos e implementar uma nova opção para o usuário utilizando as Listas, onde ele pode imprimir na tela todos os cursos de algum determinado Tema que ela escolheu.


