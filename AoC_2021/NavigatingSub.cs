namespace AoC2021;
public class NavigatingSub : ChallengeBase
{
    public enum MODE
    {
        WITHAIM,
        NOAIM
    }
    private int distance, depth, aim = 0;

    public NavigatingSub(ChallengeInput input, Part part) : base(input, part)
    {
        if(part == Part.TWO)
        {
            input.Inputs.ForEach(x => ProcessCommandWithAim(x));
        }
        else
        {
            input.Inputs.ForEach(x => ProcessCommand(x));
        }
    }

    public override int Answer => distance * depth;
    private void ProcessCommand(string command)
    {
        var args = command.Split(' ');
        int value = int.Parse(args[1]);
        if (args[0] == "forward")
            distance += value;
        else if (args[0] == "down")
            depth += value;
        else if (args[0] == "up")
            depth -= value;
    }
    private void ProcessCommandWithAim(string command)
    {
        var args = command.Split(' ');
        int value = int.Parse(args[1]);
        if (args[0] == "forward")
        {
            distance += value;
            depth += value * aim;
        }
        else if (args[0] == "down")
            aim += value;
        else if (args[0] == "up")
            aim -= value;
    }
}