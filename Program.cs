bool inimigoproximo = false;
bool ferido = false;
bool procurando = true;
bool atacando = false;
bool fugindo = false;
bool morto = false;

Console.Clear();
Random ramdom = new Random();

// Começando o código
Console.WriteLine(@"---MUITO PRAZER MEU QUERIDÍSSIMO JOGADOR---");
Console.WriteLine("Escolha o nome daquele que você irá presenciar a jornada");
string NomeNPC = Console.ReadLine();

while (!morto)  // Enquanto o NPC não estiver morto
{
    if (inimigoproximo == false && procurando == true)
    {
        Procurando();
    }

    if (inimigoproximo == true && atacando == true && ferido == false)
    {
        Atacando();
    }

    if (ferido == true && fugindo == true)
    {
        Fugindo();
    }

    if (morto == true)
    {
        Morto();
        break; // Sai do loop após a morte
    }
}

void Procurando()
{
    int rand = ramdom.Next(3);

    if (rand == 1)
    {
        if (ferido == false)
        {
            Console.WriteLine($"-{NomeNPC} encontrou uma poção de cura, contudo ela estava vazia :)-");
            Thread.Sleep(2000);
        }
        else
        {
            Console.WriteLine($"-{NomeNPC} encontrou uma poção de cura, meu parabéns, {NomeNPC} se curou -");
            ferido = false;
            Thread.Sleep(2000);
        }
    }
    else if (rand == 2)
    {
        Console.WriteLine($"-O meu deus, {NomeNPC} encontrou um monstro-");
        Thread.Sleep(2000);
        inimigoproximo = true;
        atacando = true;  // Habilita o combate
    }
}

void Atacando()
{
    if (inimigoproximo == true && ferido == false) // Usando um 'if' ao invés de 'while'
    {
        int rand = ramdom.Next(3);
        if (rand == 1)
        {
            int fer2 = ramdom.Next(3);
            if (fer2 == 1)
            {
                Console.WriteLine($"Oh não, {NomeNPC} foi ferido!");
                ferido = true;
                Thread.Sleep(2000);
                inimigoproximo = false;
                fugindo = true;
            }
            else if (fer2 == 2)
            {
                Console.WriteLine($"Infelizmente, {NomeNPC} morreu no combate...");
                morto = true;
                Thread.Sleep(2000);
            }
        }
        else if (rand == 2)
        {
            Console.WriteLine($"O inimigo foi totalmente derrotado pelo {NomeNPC}");
            procurando = true; // Recomeça a procura
            Thread.Sleep(2000);
            inimigoproximo = false;
            atacando = false; // Desativa o combate
        }
    }
}

void Fugindo()
{
    int fug = ramdom.Next(5);
    if (fug == 1)
    {
        Console.WriteLine($"Infelizmente o {NomeNPC} foi de F");
        morto = true;
        Thread.Sleep(2000);
    }
    else if (fug == 2)
    {
        Console.WriteLine($"Oh my god, o NPC {NomeNPC} achou uma poção de cura!");
        Console.WriteLine($"\nO {NomeNPC} foi curado.");
        ferido = false;
        Thread.Sleep(2000);
    }
    else if (fug == 3 || fug == 4)
    {
        Console.WriteLine("O inimigo que estava te atacando desistiu!!");
        inimigoproximo = false;
        Thread.Sleep(2000);
    }
}

void Morto()
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine(@"  ____                       ___                 
 / ___| __ _ _ __ ___   ___ / _ \__   _____ _ __ 
| |  _ / _` | '_ ` _ \ / _ \ | | \ \ / / _ \ '__|
| |_| | (_| | | | | | |  __/ |_| |\ V /  __/ |   
 \____|\__,_|_| |_| |_|\___|\___/  \_/ \___|_|    ");
    Console.ResetColor();
    Thread.Sleep(2000);
}
