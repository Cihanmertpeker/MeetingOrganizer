
/*
You have a text that some of the words in reverse order.
The text also contains some words in the correct order, and they are wrapped in parenthesis.
Write a function fixes all of the words and,
remove the parenthesis that is used for marking the correct words.

Your function should return the same text defined in the constant correctAnswer, please keep in mind
that shortest way possible will get you extra points.
*/

internal class Program
{
    private static void Main(string[] args)
    {
        var inputText = "nhoJ (Griffith) nodnoL saw (an) (American) ,tsilevon ,tsilanruoj (and) laicos .tsivitca ((A) reenoip (of) laicremmoc noitcif (and) naciremA ,senizagam (he) saw eno (of) (the) tsrif (American) srohtua (to) emoceb (an) lanoitanretni ytirbelec (and) nrae a egral enutrof (from) ).gnitirw";
        var correctAnswer = "John Griffith London was an American novelist, journalist, and social activist. (A pioneer of commercial fiction and American magazines, he was one of the first American authors to become an international celebrity and earn a large fortune from writing.)";


        string ReverseText(string input)
        {

            string[] words = inputText.Split(' ');

            string[] result = new string[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                if (word.StartsWith("(") && word.EndsWith(")"))
                {
                    result[i] = word.Substring(1, word.Length - 2);
                }
                else
                {
                    result[i] = new string(word.Reverse().ToArray());
                }
            }

            return string.Join(" ", result);


        }




        Console.WriteLine(ReverseText(inputText) == correctAnswer ? "Correct !!!" : "Wrong answer...!");
    }
}