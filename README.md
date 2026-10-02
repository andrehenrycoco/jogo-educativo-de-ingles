# Jogo Educativo de Inglês

Jogo de console em C# para praticar construção de frases em inglês. O programa embaralha as palavras de uma pergunta e o jogador precisa remontá-la na ordem correta, com direito a dicas que custam pontos.

Projeto desenvolvido durante o curso de Análise e Desenvolvimento de Sistemas, como primeiro exercício prático de lógica de programação em C#.

## Como é uma rodada

```
how / do / children / many / ? / you / have
Quer uma dica? (T/F)T
Dica: - - - - do - -
Sua nota atual é: -0,1
Quer uma dica? (T/F)F
Tente advinhar: - - - - do - -
What is the correct form?
how many children do you have ?
Está certo, parabéns
Sua nota é: 0,9
```

## Regras

São 10 perguntas em inglês, apresentadas em sequência. O jogador tem até 3 tentativas por frase e pode pedir dicas antes de cada tentativa.

Cada dica revela uma palavra na posição correta e desconta 0,1 ponto. Uma posição já revelada nunca é sorteada de novo, e o jogo sempre guarda a última palavra, então não dá para desbloquear a frase inteira só com dicas. Acertar vale 1 ponto, e a pontuação máxima é 10.

Errar as três tentativas encerra a frase com Game over. Aí o jogo pergunta se você quer continuar: responder T segue para a próxima pergunta, responder F encerra e mostra a pontuação final. Terminando as dez frases, a mesma pergunta aparece, e continuar reinicia a partida do zero.

A comparação da resposta ignora maiúsculas e espaçamento, então `How Many Children Do You Have ?` e `howmanychildrendoyouhave?` são aceitas igualmente.

## Tecnologias

- C# em .NET 10
- Aplicação de console
- Nullable reference types e implicit usings habilitados
- Sem dependências externas

## Como rodar

Você precisa do [SDK do .NET 10](https://dotnet.microsoft.com/download) instalado.

```bash
git clone https://github.com/andrehenrycoco/jogo-educativo-de-ingles.git
cd jogo-educativo-de-ingles
dotnet run --project InitialProject
```

## Estrutura

```
jogo-educativo-de-ingles/
├── InitialProject.slnx              # solution no formato novo, em XML
└── InitialProject/
    ├── InitialProject.csproj
    └── EnglishStudies/
        └── Game01.cs                # toda a lógica do jogo
```

## Como funciona

**Embaralhamento.** As frases ficam numa `List<string>` no próprio código. Cada uma é quebrada em palavras com `Split(" ")` e embaralhada com `Random.Shared.Shuffle`, que é a API de shuffle nativa do .NET e dispensa implementar Fisher-Yates na mão. A frase embaralhada aparece separada por barras para deixar claro onde começa e termina cada palavra.

**Dicas.** Existe um array paralelo ao da frase original, preenchido com traços. Quando o jogador pede dica, uma posição é sorteada e o traço daquela posição é trocado pela palavra verdadeira. Se o sorteio cair numa posição já revelada, ele é refeito, para o jogador não pagar por uma dica que não acrescenta nada.

O contador de dicas vive junto com o array de traços, fora do laço de tentativas, e não zera a cada nova tentativa. É o que garante que sempre reste pelo menos um traço no array, e é também o que impede o sorteio de ficar girando sem encontrar posição livre.

**Comparação da resposta.** Em vez de comparar palavra por palavra, os dois lados passam por `Replace(" ", "").ToLower()` antes da igualdade. Resolve de uma vez os dois problemas que mais apareciam no teste: espaço duplo entre palavras e diferença de maiúscula.

**Pontuação.** Os três valores que governam o jogo estão em constantes no topo da classe (`SCORE_REDUCTION_FACTOR`, `SCORE_ADD`, `MAX_TRIES`), então ajustar o balanceamento não exige caçar número solto no meio do código.

**Entrada do usuário.** Com nullable habilitado, todo `Console.ReadLine()` é tratado como possivelmente nulo antes de ser usado.

## Próximos passos

- [ ] Mover as frases para um arquivo JSON externo, para adicionar conteúdo sem recompilar
- [ ] Separar a classe em responsabilidades menores, hoje concentradas no método `Execute`
- [ ] Trocar o `new Random()` do sorteio de dica por `Random.Shared`, para ficar consistente com o embaralhamento
- [ ] Simplificar os laços de repetição da partida, que hoje têm uma camada a mais do que precisam
- [ ] Cobrir a comparação de resposta e o cálculo de pontuação com testes
- [ ] Adicionar níveis de dificuldade pelo tamanho da frase

## Autor

André Henry Barboza Coco

Em transição da psicologia para desenvolvimento back-end. Curso Análise e Desenvolvimento de Sistemas na Universidade Cruzeiro do Sul, com conclusão prevista para 2027.

[LinkedIn](https://www.linkedin.com/in/andrecoco/) · andrehbcoco@gmail.com
