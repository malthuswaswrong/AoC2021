namespace AoC_2021_02;
public class NavigatingSub
{
    private int distance, depth, aim = 0;
    public int Answer => distance * depth;
    public void ProcessCommand(string command)
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
    public void ProcessCommandWithAim(string command)
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