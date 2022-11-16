Console.Clear(); 
Console.ResetColor();

const int SHORT = 1;
const int REGULAR = 4;
const int DOUBLE = 3;
const int POINTS = 11;

Console.WriteLine("Welcome to PingPongCounter");
Console.WriteLine("Which type of game do you want to play? [short], [regular], [double] or [custom]");
string game_type = Console.ReadLine()!;

int custom = 0;
int service = Random.Shared.Next(1, 3); 
int service1 = 0;

if (game_type == "custom") //custom = user defined game
{
    do
    {
        Console.WriteLine("How many matches does a player need to win to win the game? [odd number between 0 and 10]");
        custom = int.Parse(Console.ReadLine()!);
        if (custom > 10)
        {
            Console.WriteLine("Your number is too high please try again"); //look if the user selected a number smaller 10
        }
        else if (custom % 2 == 0)
        {
            Console.WriteLine("Your number is even please try again"); //look if the user selected an odd number
        }
    } while (custom > 10 || custom % 2 == 0);
}

int game_length = 0; 
int player1_points = 0; int player2_points = 0;
int player1_game = 0; int player2_game = 0;
int game = 0; int round = 0; int winner = 0;

switch (game_type)
{
    case "short":
        game_length = SHORT;
        break;
    case "regular":
        game_length = REGULAR;
        break;
    case "double":
        game_length = DOUBLE;
        break;
    case "console":
        game_length = custom;
        break;
}
do
{
    game++;
    player1_points = 0; player2_points = 0;
    do
    {
        service1 = (player1_points + player2_points) % 2;
        Console.WriteLine($"player {service} has the service");
        if (service1 == 0 && player1_points != 0 && player2_points != 0)
        {
            if (service == 1)
            {
                service += 1;
            }
            else
            {
                service -= 1;
            }
            Console.WriteLine($"player {service} has the service");
        }
        round++;
        Console.WriteLine($"Who got the {round}. point? player[1] or player[2] [q]");
        string point = Console.ReadLine()!;
        if (point == "1")
        {
            player1_points++;
        }
        else if (point == "q")
        {
            return;
        }
        else
        {
            player2_points++;
        }
        Console.WriteLine($"points: {player1_points}|{player2_points} game: {player1_points}|{player2_points}");
    } while (player1_points < POINTS && player2_points < POINTS);
    
    if (player1_points == 11)
    {
        player1_game++;
        Console.WriteLine($"Player {winner} wins the {game} match");
    }
    else
    {
        player2_game++;
        Console.WriteLine($"Player {winner} wins the {game} match");
    }
} while (game != game_length);

if (player1_game > player2_game)
{
    Console.WriteLine($"Player {winner} wins the game");
}
else
{
    Console.WriteLine($"Player {winner} wins the game");
}

Console.ReadKey();
Console.Clear();