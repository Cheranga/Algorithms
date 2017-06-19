using System.Collections.Generic;
using System.Text;

namespace Interesting
{
    public class ReverseStringWithStacks : IReverseString
    {
        public string Get(string input, char delimeter)
        {
            //
            // Using "IsNullOrEmpty" because it's not a string manipulation function
            //
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var stack = new Stack<char>();
            var stackList = new List<Stack<char>>(new[] {stack});
            
            foreach (var character in input)
            {
                if (character == delimeter)
                {
                    stack = new Stack<char>();
                    stackList.Add(stack);
                }
                else
                {
                    stack.Push(character);
                }
            }

            var stringBuilder = new StringBuilder();

            for (var index = 0; index < stackList.Count; index++)
            {
                var currentStack = stackList[index];
                var stackOutput = new string(currentStack.ToArray());
                //
                // If it's the last item don't append the delimeter
                //
                if (index == stackList.Count - 1)
                {
                    stringBuilder.Append(stackOutput);
                }
                else
                {
                    stringBuilder.Append(stackOutput).Append(delimeter);
                }
            }

            var output = stringBuilder.ToString();

            return output;
        }

       
    }
}