for(int i=1; i<=100; i++)
{
    if (i % 2 != 0)
    {
        Console.WriteLine(i);
    }
}

int j = 1;
while (j <= 100)
{
    if (j % 2 != 0)
    {
        Console.WriteLine(j);
    }
    j++;
}

int k = 0;
do
{
    k++;
    if (k % 2 != 0)
    {
        Console.WriteLine(k);
    }
} while (k < 100);
