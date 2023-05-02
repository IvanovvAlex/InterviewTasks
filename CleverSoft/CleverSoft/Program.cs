string[] arrayOfNames = new string[5];
arrayOfNames[0] = "Alex";
arrayOfNames[1] = "Bob";
arrayOfNames[2] = "Cindy";
arrayOfNames[3] = "David";
arrayOfNames[4] = "Eve";

Console.Write("Enter name:");
string name = Console.ReadLine();

bool found = false;

for (int i = 0; i < name.Length; i++)
{
    string trimmedName = name.Substring(0, name.Length - 1);

    if (arrayOfNames.Contains(trimmedName))
    {
        found = true;
        break;
    }
}

if (found)
{
    Console.WriteLine("Name found");
}
else
{
    Console.WriteLine("Name not found");
}
