using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;
public class ChallengeInput
{
    public List<string> Inputs { get; set; }
    public ChallengeInput(StreamReader inputStream, Func<string, string> inputProcessor = null)
    {
        Inputs = new List<string>();

        while (inputStream.EndOfStream == false)
        {
            if(inputProcessor != null)
                Inputs.Add(inputProcessor(inputStream.ReadLine()));
            else
                Inputs.Add(inputStream.ReadLine());
        }
    }
    public ChallengeInput(List<string> inputList, Func<string, string> inputProcessor = null)
        : this(StreamReaderFromList(inputList), inputProcessor)
    {
    }

    private static StreamReader StreamReaderFromList(List<string> inputList)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        
        foreach (var input in inputList)
            writer.WriteLine(input);
        
        writer.Flush();
        stream.Position = 0;
        return new StreamReader(stream);
    }
}

