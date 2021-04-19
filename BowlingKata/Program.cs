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
        private const int cantidadMaxTiradasPorTurno = 2;
        Turno turno = new Turno();
        public int TurnoActual = 0;
        public bool ValidarPinos(int pinos)
        {
            if (pinos < 0) return false;
            if (pinos > 10) return false;
            return true;
        }

        public int TirarPinos(int pinos)
        {
            turno.cantidadTiradasActuales++;
            int cantidadPinosAntesTirarda = cantidadPinosDelTurno;
            cantidadPinosDelTurno = Math.Max(0, cantidadPinosDelTurno - pinos);
            int result = cantidadPinosAntesTirarda - cantidadPinosDelTurno;


            if (turno.cantidadTiradasActuales > 1)
            {
                cantidadPinosDelTurno = 10;
                turno.cantidadTiradasActuales = 0;
                TurnoActual++;
            }
            if (cantidadPinosDelTurno == 0)
            {
                turno.cantidadTiradasActuales = 0;
                cantidadPinosDelTurno = 10;
                TurnoActual++;
            }
            return result;
        }

        public bool RealizarTirada()
        {
            turno.cantidadTiradasActuales++;
            if (turno.cantidadTiradasActuales > cantidadMaxTiradasPorTurno)
            {
                return false;
            }
            return true;
        }

        public int CalcularPuntuacion(int cantidadBolosTirados)
        {
            int puntuacion = cantidadBolosTirados;
            return puntuacion;
        }
    }

    public class Turno
    {
        public const int cantidadMaxTiradasPorTurno = 2;
        public int cantidadTiradasActuales = 0;
        public bool habilitado = true;
    }
}
