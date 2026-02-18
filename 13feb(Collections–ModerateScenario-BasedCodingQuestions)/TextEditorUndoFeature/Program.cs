using System;
using System.Collections.Generic;
using System.Text;

namespace TextEditorUndoFeature
{
    public class TextEditorService
    {
        public static string ProcessOperations(List<string> operations)
        {
            if (operations == null)
                throw new ArgumentNullException(nameof(operations));

            var wordStack = new Stack<string>();

            foreach (var operation in operations)
            {
                if (string.IsNullOrWhiteSpace(operation))
                    continue;

                if (operation.StartsWith("TYPE ", StringComparison.OrdinalIgnoreCase))
                {
                    string word = operation.Substring(5).Trim();

                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        wordStack.Push(word);
                    }
                }
                else if (operation.Equals("UNDO", StringComparison.OrdinalIgnoreCase))
                {
                    if (wordStack.Count > 0)
                    {
                        wordStack.Pop();
                    }
                }
            }

            // Stack is LIFO, so reverse to restore original order
            var wordsInOrder = wordStack.ToArray();
            Array.Reverse(wordsInOrder);

            return string.Join(" ", wordsInOrder);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var operations = new List<string>
            {
                "TYPE Hello",
                "TYPE World",
                "UNDO",
                "TYPE CSharp"
            };

            string finalText = TextEditorService.ProcessOperations(operations);

            Console.WriteLine($"Final Text: \"{finalText}\"");
        }
    }
}
