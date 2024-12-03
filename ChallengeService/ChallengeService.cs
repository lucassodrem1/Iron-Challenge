namespace Challenge.Services
{
    public static class ChallengeService
    {
        /// <summary>
        /// Store all my expected buttons and their respectives letters.
        /// </summary>
        private static Dictionary<char, char[]> _lettersGroup { get; set; } =
            new Dictionary<char, char[]>
            {
                { '2', ['A', 'B', 'C'] },
                { '3', ['D', 'E', 'F'] },
                { '4', ['G', 'H', 'I'] },
                { '5', ['J', 'K', 'L'] },
                { '6', ['M', 'N', 'O'] },
                { '7', ['P', 'Q', 'R', 'S'] },
                { '8', ['T', 'U', 'V'] },
                { '9', ['W', 'X', 'Y', 'Z'] },
                { '#', [] },
                { ' ', [] },
                { '*', [] }
            };

        /// <summary>
        /// Transform pressed buttons into their respective letters.
        /// </summary>
        /// <param name="input"></param>
        /// <returns> A string that represents the letters after being transformed. </returns>
        public static string OldPhonePad(string input)
        {
            /// <summary>
            /// Store my current pressed button.
            /// </summary>
            char currentGroup;

            /// <summary>
            /// Store the last pressed button.
            /// </summary>
            char lastGroup = new();

            /// <summary>
            /// Counter to store how many times the same button was pressed consecutively.
            /// </summary>
            int counter = 0;

            /// <summary>
            /// Store my final string output.
            /// </summary>
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (_lettersGroup.ContainsKey(input[i]) is false) continue;

                currentGroup = input[i];
                
                if (lastGroup == '*')
                {
                    if (output.Length > 0)
                    {
                        output = output.Remove(output.Length - 1);
                    }
                }

                if (currentGroup == lastGroup || counter == 0)
                {
                    counter++;
                }
                else
                {
                    if (_lettersGroup[lastGroup].Length > 0) //para evitar erro com o espaco
                    {
                        if (counter > _lettersGroup[lastGroup].Length) 
                        {
                            counter = (counter - 1) % _lettersGroup[lastGroup].Length;
                            output += _lettersGroup[lastGroup][counter];
                        }
                        else
                        {
                            output += _lettersGroup[lastGroup][counter - 1];
                        }

                        if (currentGroup == '#') break;                    
                    }
                    counter = 1;
                }

                lastGroup = currentGroup;
            }

            return output;
        }
    }
}