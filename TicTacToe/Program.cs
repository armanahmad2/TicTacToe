Console.WriteLine("Let's play TicTacToe");
string Upper1 = "ul", Upper2 = "um", Upper3 = "ur", Middile1 = "ml", Middile2 = "mm", Middile3 = "mr", Lower1 = "ll", Lower2 = "lm", Lower3 = "lr", UserSelection = null, mine = null;
int randomlimit = 0, i = 1;
bool userFirst = false;
Display();
GetUserSelection();
Console.ReadLine();

void Display()
{
    Console.WriteLine("\n");
    ColorConsole($" {Upper1}  ", (Upper1 == mine), false, true, (Upper1 == "ul"));
    Console.Write("║");
    ColorConsole($" {Upper2}  ", (Upper2 == mine), false, true, (Upper2 == "um"));
    Console.Write("║");
    ColorConsole($" {Upper3}  ", (Upper3 == mine), false, true, (Upper3 == "ur"));
    Console.WriteLine("\n══════════════════");
    ColorConsole($" {Middile1}  ", (Middile1 == mine), false, true, (Middile1 == "ml"));
    Console.Write("║");
    ColorConsole($" {Middile2}  ", (Middile2 == mine), false, true, (Middile2 == "mm"));
    Console.Write("║");
    ColorConsole($" {Middile3}  ", (Middile3 == mine), false, true, (Middile3 == "mr"));
    Console.WriteLine("\n══════════════════");
    ColorConsole($" {Lower1}  ", (Lower1 == mine), false, true, (Lower1 == "ll"));
    Console.Write("║");
    ColorConsole($" {Lower2}  ", (Lower2 == mine), false, true, (Lower2 == "lm"));
    Console.Write("║");
    ColorConsole($" {Lower3}  ", (Lower3 == mine), false, true, (Lower3 == "lr"));
    Console.WriteLine("\n");
}

void Reset()
{
    Console.Clear();
    Upper1 = "ul";
    Upper2 = "um";
    Upper3 = "ur";
    Middile1 = "ml";
    Middile2 = "mm";
    Middile3 = "mr";
    Lower1 = "ll";
    Lower2 = "lm";
    Lower3 = "lr";
    i = 1;
}

void GetUserSelection()
{
    Console.WriteLine("Please choose O or X");
    UserSelection = Console.ReadLine().ToUpper();
    if (string.Equals(UserSelection, "O", StringComparison.CurrentCultureIgnoreCase)){
        Console.Write("You choosed ");
        ColorConsole("O", false, false);
        Console.Write(", So mine is ");
        ColorConsole("X", true, false);
        Console.WriteLine();
        UserSelection = " O";
        mine = " X";
    }
    else if (string.Equals(UserSelection, "X", StringComparison.CurrentCultureIgnoreCase)){
        Console.Write("You choosed ");
        ColorConsole("X", false, false);
        Console.Write(", So mine is ");
        ColorConsole("O", true, false);
        Console.WriteLine();
        UserSelection = " X";
        mine = " O";
    }
    else{
        ColorConsole("Wrong input!!! Please enter O or X");
        GetUserSelection();
    }
    GetUserPreferance();
}

void GetUserPostion()
{
    Console.WriteLine("Please select postion like ul for upper left, mm for middle middile, lr for lower right and so on...");
    string? position = Console.ReadLine()?.ToLower();
    if (Enum.TryParse(typeof(TicTacToeEnum), position, out object? userSelectedValue)){
        if (!PutValueUsingSwitch(UserSelection, (int)Enum.Parse(typeof(TicTacToeEnum), position, false))){
            ColorConsole("Wrong input!!!");
            GetUserPostion();
        }
    }
    else{
        ColorConsole("Wrong input!!!");
        GetUserPostion();
    }
    
    i++;
    if (i > 2)
        CheckGameEnd(UserSelection);

    GetRandomPosition();
}

void GetRandomPosition()
{
    if (!PutValueUsingSwitch(mine, GetHardLevelValue(UserSelection)))
        GetRandomPosition();
    
    if (i > 2)
        CheckGameEnd(mine);
    Display();
    GetUserPostion();
}

int GetHardLevelValue(string value)
{
    if (Middile2 == value && Lower3 == value && Upper1 == "ul") return 1;
    if (Upper1 == value && Lower3 == value && Middile2 == "mm") return 5;
    if (Upper1 == value && Middile2 == value && Lower3 == "lr") return 9;
    if (Lower1 == value && Middile2 == value && Upper3 == "ur") return 3;
    if (Upper3 == value && Lower1 == value && Middile2 == "mm") return 5;
    if (Upper3 == value && Middile2 == value && Lower1 == "ll") return 7;
    if (Upper2 == value && Upper3 == value && Upper1 == "ul") return 1;
    if (Upper1 == value && Upper3 == value && Upper2 == "um") return 2;
    if (Upper1 == value && Upper2 == value && Upper3 == "ur") return 3;
    if (Middile2 == value && Middile3 == value && Middile1 == "ml") return 4;
    if (Middile1 == value && Middile3 == value && Middile2 == "mm") return 5;
    if (Middile1 == value && Middile2 == value && Middile3 == "mr") return 6;
    if (Lower2 == value && Lower3 == value && Lower1 == "ll") return 7;
    if (Lower1 == value && Lower3 == value && Lower2 == "lm") return 8;
    if (Lower1 == value && Lower2 == value && Lower3 == "lr") return 9;
    if (Middile1 == value && Lower1 == value && Upper1 == "ul") return 1;
    if (Upper1 == value && Lower1 == value && Middile1 == "ml") return 4;
    if (Upper1 == value && Middile1 == value && Lower1 == "ll") return 7;
    if (Middile2 == value && Lower2 == value && Upper1 == "um") return 2;
    if (Upper2 == value && Lower2 == value && Middile2 == "mm") return 5;
    if (Upper2 == value && Middile2 == value && Lower2 == "lm") return 8;
    if (Middile3 == value && Lower3 == value && Upper3 == "ur") return 3;
    if (Upper3 == value && Lower3 == value && Middile3 == "mr") return 6;
    if (Upper3 == value && Middile3 == value && Lower3 == "lr") return 9;
    if (randomlimit > 6){
        randomlimit = 0;
        if (Upper1 == "ul") return 1;
        if (Upper2 == "um") return 2;
        if (Upper3 == "ur") return 3;
        if (Middile1 == "ml") return 4;
        if (Middile2 == "mm") return 5;
        if (Middile3 == "mr") return 6;
        if (Lower1 == "ll") return 7;
        if (Lower2 == "lm") return 8;
        if (Lower3 == "lr") return 9;
    }
    randomlimit++;
    return new Random().Next(1, 9);
}

void CheckGameEnd(string value)
{
    if ((Upper1 == value && Upper2 == value && Upper3 == value) || (Middile1 == value && Middile2 == value && Middile3 == value) ||
        (Lower1 == value && Lower2 == value && Lower3 == value) || (Upper1 == value && Middile1 == value && Lower1 == value) ||
        (Upper2 == value && Middile2 == value && Lower2 == value) || (Upper3 == value && Middile3 == value && Lower3 == value) ||
        (Upper1 == value && Middile2 == value && Lower3 == value) || (Upper3 == value && Middile2 == value && Lower1 == value)){
        Display();
        ColorConsole($"{(value == UserSelection ? "You" : "I")} win!!!", false);
        PlayAgain((value == UserSelection ? 1 : 0));
    }
    else if (Upper1 != "ul" && Upper2 != "um" && Upper3 != "ur" && Middile1 != "ml" && Middile2 != "mm" && Middile3 != "mr" && Lower1 != "ll" && Lower2 != "lm" && Lower3 != "lr"){
        Display();
        ColorConsole("Oops! Win Win situation. Looks like you're brother from another mother.", false);
        Console.WriteLine("Wanna play again? yes(y) or no(n) ?");
        PlayAgain(5);
    }
}

void GetUserPreferance()
{
    Console.WriteLine("Do you wanna go first? yes (y) or no (n)");
    string userInput = Console.ReadLine().ToLower();
    if (userInput == "yes" || userInput == "y"){
        userFirst = true;
        GetUserPostion();
    }
    else if (userInput == "no" || userInput == "n")
        GetRandomPosition();
    else{
        ColorConsole("Wrong input!!! Please input y for yes or n for no");
        GetUserPreferance();
    }

}

void PlayAgain(int fun)
{
    if(fun == 0)
        Console.WriteLine("Such a loser. Wanna lose again? yes (y) or no (n)");
    if (fun == 1)
        Console.WriteLine("Ahh! this just feels like my life, ALWAYS LOSING!!!. Wanna play again? yes (y) or no (n)");
    
    string userInput = Console.ReadLine().ToLower();
    if (userInput == "yes" || userInput == "y"){
        Reset();
        if (userFirst){
            userFirst = false;
            GetRandomPosition();
        }
        else{
            Display();
            userFirst = true;
            GetUserPostion();
        }
    }
    else if (userInput == "no" || userInput == "n")
        Environment.Exit(0);
    else{
        Console.WriteLine("Wrong input!!! Please input y for yes or n for no");
        PlayAgain(2);
    }
}

bool PutValueUsingSwitch(string value, int valueForSwtichCase)
{
    bool valueAssigned = false;
    switch (valueForSwtichCase)
    {
        case (int)TicTacToeEnum.ul: if (Upper1 == "ul") { Upper1 = value; valueAssigned = true; } break;
        case (int)TicTacToeEnum.um: if (Upper2 == "um") { Upper2 = value; valueAssigned = true; } break;
        case (int)TicTacToeEnum.ur: if (Upper3 == "ur") { Upper3 = value; valueAssigned = true; } break;
        case (int)TicTacToeEnum.ml: if (Middile1 == "ml") { Middile1 = value; valueAssigned = true; } break;
        case (int)TicTacToeEnum.mm: if (Middile2 == "mm") { Middile2 = value; valueAssigned = true; } break;
        case (int)TicTacToeEnum.mr: if (Middile3 == "mr") { Middile3 = value; valueAssigned = true; } break;
        case (int)TicTacToeEnum.ll: if (Lower1 == "ll") { Lower1 = value; valueAssigned = true; } break;
        case (int)TicTacToeEnum.lm: if (Lower2 == "lm") { Lower2 = value; valueAssigned = true; } break;
        case (int)TicTacToeEnum.lr: if (Lower3 == "lr") { Lower3 = value; valueAssigned = true; } break;
    }
    return valueAssigned;
}

void ColorConsole(string value, bool redColor = true, bool isAlert = true, bool isDisplay = false, bool isDisplayNormaltext = false)
{
    if (isDisplay){
        if (isDisplayNormaltext){
            Console.Write(value);
            return;
        }
    }
    Console.ForegroundColor = redColor == true ? ConsoleColor.Red : ConsoleColor.Green;
    if (isAlert)
        Console.WriteLine(value);
    else
        Console.Write(value);
    Console.ResetColor();
}

public enum TicTacToeEnum  { ul = 1, um = 2, ur = 3, ml = 4, mm = 5, mr = 6, ll = 7, lm = 8, lr = 9 }
