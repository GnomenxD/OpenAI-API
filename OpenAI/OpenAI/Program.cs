Setup setup = new Setup("sk-");

while(true)
{
	string? input = Console.ReadLine();

	if (string.IsNullOrEmpty(input))
		continue;
	if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
		break;
}