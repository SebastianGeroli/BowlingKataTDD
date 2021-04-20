using System;

namespace BowlingKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Bowling bowling = new Bowling();
            Random rdm = new Random();
            Console.WriteLine($"¡Bienvenido a Bowling Game!.");
            for (int i = 0; i < bowling.Turnos.Length;)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Presiona Enter para realizar una tirada de pinos.");
                if (i >= 10)
                {
                    if (!bowling.Turnos[i - 1].esSpare && !bowling.Turnos[i - 1].esStrike) break;
                }
                string Tecla = Console.ReadKey().Key.ToString();
                if (Tecla == "Enter") {
                    int pinosTiradosAleatorio = rdm.Next(0, 11);
                    bowling.RealizarTirada(pinosTiradosAleatorio);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Tiraste " + pinosTiradosAleatorio + " pinos !");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Tu puntaje Actual es: {bowling.PuntuacionActual}");
                    
                    i = bowling.TurnoActual;
                    int turnosRestantes = 10 - i;

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Te quedan " + turnosRestantes + " turnos!");

                }
                
                
                
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"¡Juego terminado!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Tu puntaje Final es: {bowling.PuntuacionActual}");

        }
    }
}
