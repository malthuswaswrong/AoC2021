using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;

public class SyntaxChecker : ChallengeBase
{
    private readonly ChallengeInput input;
    private readonly Part part;
    private Dictionary<char, int> scoringTable;
    private readonly string openingCharacters;
    private readonly string closingCharacters;

    public SyntaxChecker(ChallengeInput input, Part part) : base(input, part)
    {
        this.input = input;
        this.part = part;
        openingCharacters = "([{<";
        closingCharacters = ")]}>";
        scoringTable = new();
        scoringTable.Add(')', 3);
        scoringTable.Add(']', 57);
        scoringTable.Add('}', 1197);
        scoringTable.Add('>', 25137);
    }

    public override long Answer
    {
        get
        {
            if (part == Part.ONE)
            {
                int answer = 0;
                foreach (var line in input.Inputs)
                {
                    List<char> syntaxStack = new();
                    foreach (char c in line)
                    {
                        if (openingCharacters.Contains(c))
                        {
                            syntaxStack.Add(c);
                        }
                        else
                        {
                            if(closingCharacters.Contains(c))
                            {
                                if (syntaxStack.Last() == openingCharacters[closingCharacters.IndexOf(c)])
                                {
                                    syntaxStack.RemoveAt(syntaxStack.Count - 1);
                                }
                                else
                                {
                                    answer+=scoringTable[c];
                                    break;
                                }
                            }
                        }

                    }
                }
                return answer;
            }
            throw new NotImplementedException();
        }
    }
}

