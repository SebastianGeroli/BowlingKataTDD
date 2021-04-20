using System;

namespace BowlingKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Bowling bowling = new Bowling();
            for (int i = 0; i < bowling.Turnos.Length;)
            {
                Console.WriteLine($"Realiza tu jugada!(numeros de 0 a 10)");
                if (i >= 10)
                {
                    if (!bowling.Turnos[i - 1].esSpare && !bowling.Turnos[i - 1].esStrike) break;
                }
                bowling.RealizarTirada(int.Parse(Console.ReadLine()));
                Console.WriteLine($"Tu puntaje Actual es: {bowling.PuntuacionActual}");

                i = bowling.TurnoActual;
            }
            Console.WriteLine($"Tu puntaje Final es: {bowling.PuntuacionActual}");

        }
    }
}
