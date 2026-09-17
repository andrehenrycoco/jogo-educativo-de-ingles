namespace InitialProject.EnglishStudies;

// 1. Somente checar a ordem das palavras sem levar em conta os espaços. 
// 2. Mostrar uma palavra aleatória (tipo jogo da forca) -> "_ _ _ many _ _ _ " -> Posso pedir quantas dicas eu quiser até restar uma palavra para adivinhar.
// 3. A comparação de strings seja "case insensitive"
// 4. Quando der GameOver, pergunte para o usuário se ele quer começar um novo jogo.

public class Program
{
    public static void Main()
    {
        var game01 = new Game01();
        game01.Execute();
    }
}

public class Game01
{
    public void Execute()
    {
        var score = 0.0;

        Console.WriteLine("oi");

        var list = new List<string>()
        {
            "how many children do you have ?",
            "is your job interesting ?",
            "what color is his car ?",
            "where does your brother work ?",
            "do you work with computers ?",
            "what kind of magazines do you read ?",
            "what does he do on the weekend ?",
            "are you stressed in your job ?",
            "where does your sister live ?",
            "how do you say that in English ?"
        };

        for (int i = 0; i < list.Count; i++)
        {
            var myTry = 0;
            bool correct = false;

            string[] words = list[i].Split(" ");
            Random.Shared.Shuffle(words);
            string wordsScrambled = string.Join(" / ", words);
            Console.WriteLine(wordsScrambled);

            string[] originalWords = list[i].Split(' ');
            string[] tipWords = new string[originalWords.Length];

            for (int j = 0; j < originalWords.Length; j++)
            {
                tipWords[j] = "-";
            }

            bool askTip = true;

            while (!correct && myTry < 3)
            {


                while (askTip)
                {
                    Console.Write("Quer uma dica? (true/false)");
                    string? tip = Console.ReadLine();

                    if (tip != null && tip.Trim().ToLower() == "true")
                    {

                        List<int> wordIndices = new List<int>();


                        for (int w = 0; w < tipWords.Length; w++)
                        {
                            if (tipWords[w] == "-")
                            {
                                wordIndices.Add(w);

                            }
                        }


                        if (wordIndices.Count > 1)
                        {

                            var randomIndex = Random.Shared.Next(0, wordIndices.Count);
                            int wordToReveal = wordIndices[randomIndex];

                            tipWords[wordToReveal] = originalWords[wordToReveal];

                            score = score - 0.10;
                            Console.WriteLine("Dica: " + string.Join(" ", tipWords));
                            Console.WriteLine("Sua nota atual é: " + score);
                        }


                        if (wordIndices.Count == 1)
                        {
                            Console.WriteLine("Consumiu todas as dicas");
                            askTip = false;
                        }

                        


                    }
                    if (tip != null && tip.Trim().ToLower() == "false")
                    {
                        Console.WriteLine("What is the correct form?");
                    }


                }


            }




            Console.WriteLine("What is the correct form?");
            Console.Write("");
            string? userResponse = Console.ReadLine();

            string responseFormatted = userResponse != null ? userResponse.Replace(" ", "") : "";
            string correctFormatted = list[i].Replace(" ", "");

            if (responseFormatted == correctFormatted)
            {
                Console.WriteLine("Está certo, parabéns");
                score = score + 1;
                Console.WriteLine("Sua nota é:" + score);
                correct = true;
            }

            if (responseFormatted != correctFormatted)
            {
                Console.WriteLine("Errou");
                myTry = myTry + 1;



                if (myTry == 3)
                {
                    Console.WriteLine("Game over!");
                }

            }


            Console.WriteLine($"Sua pontuação final foi: {score} de 10 pontos.");
        }

    }
}