//Console.WriteLine("Enter input or press enter to use default string.");

//string input = Console.ReadLine();

input = "29535123p48723487597645723645";
char searchChar;

int totalSum = 0;
int sum = 0;

string firstString = string.Empty;
string numberString = string.Empty; //som ska summeras och färgas
string secondString = string.Empty;
bool falseString = false;


//Loop för att gå igenom alla indexering av strängen
for (int i = 0; i < input.Length; i++)
{
    searchChar = input[i]; //Vad som ska letas efter
    firstString += input[i]; //den första delen av strängen.

    if (falseString) //om true ska strängen nollställas.
    {
        numberString = string.Empty;
    }

    for (int j = 0; j < input.Length; j++)
    {
        numberString += input[j]; //lägger till 

        if (input[j] == searchChar) //då har nästa likadana värde hittats
        {
            falseString = int.TryParse(numberString, out sum); //Kör try parse här om det går att konvertera texten.

            if (falseString)
            {
                totalSum += sum; //lägg sum till totalsumman
                //sen ska vi fortsätta att lägga till 
            }

            else
            {
                //Kanske borde lägga nollställningen av nummersträngen här?
                break;
            }

            //om det går har vi ett korrekt värde och sista delen av strängen kan letas upp.
            //annars om det ej är korrekt måste vi börja om på i = 1 och tömma nummer strängen igen.
        }
    }
}