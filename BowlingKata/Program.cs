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
        Turno[] turnos = new Turno[12];
        public int TurnoActual = 0;
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

        public void RealizarTirada(int pinos)
        {
            // if(TurnoActual == 0){
            //     turnos[0]= new Turno();
            // }
             turno.cantidadTiradasActuales++;           

            int pinosRestantes = TirarPinos(pinos);

            if (turno.cantidadTiradasActuales >= cantidadMaxTiradasPorTurno)
            {
                cantidadPinosDelTurno = 10;
                turno.cantidadTiradasActuales = 0;
                TurnoActual++;
            }

            // if(pinosRestantes ==  0 && turnos[TurnoActual].cantidadTiradasActuales == 0){
            //     turnos[TurnoActual].esStrike = true;
            // }else if(pinosRestantes == 0){
            //     turnos[TurnoActual].esSpare = true;
            // }

            if (pinosRestantes == 0)
            {
                cantidadPinosDelTurno = 10;
                turno.cantidadTiradasActuales = 0;
                TurnoActual++;
            }
           
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
        public bool esSpare;
        public bool esStrike;
        public int cantidadDePinosTirados;
    }
}
