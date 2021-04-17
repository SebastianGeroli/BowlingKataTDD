using System;

namespace BowlingKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello World!");
        }
    }
    public class Bowling
    {

        private int cantidadPinosDelTurno = 10;

        public bool ValidarPinos(int pinos)
        {
            if (pinos < 0) return false;
            if (pinos > 10) return false;
            return true;
        }

        public int TirarPinos(int pinos)
        {
            int cantidadPinosAntesTirarda = cantidadPinosDelTurno;
            cantidadPinosDelTurno = Math.Max(0, cantidadPinosDelTurno-pinos);
            return cantidadPinosAntesTirarda- cantidadPinosDelTurno;
        }
    }
}
