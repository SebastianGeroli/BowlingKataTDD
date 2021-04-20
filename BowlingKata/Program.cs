using System;

namespace BowlingKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Bowling bowling = new Bowling();
            Console.WriteLine($"Realiza tu jugada!(numeros de 0 a 10)");
            for (int i = 0; i < bowling.Turnos.Length;)
            {
                if (i >= 9)
                {
                    if (!bowling.Turnos[i-1].esSpare && !bowling.Turnos[i-1].esStrike) break;
                }
                bowling.RealizarTirada(int.Parse(Console.ReadLine()));
                Console.WriteLine($"Tu puntaje Actual es: {bowling.PuntuacionActual}");

                i = bowling.TurnoActual;
            }
            Console.WriteLine($"Tu puntaje Final es: {bowling.PuntuacionActual}");

        }
    }
    public class Bowling
    {
        private int cantidadPinosDelTurno = 10;
        private const int cantidadMaxTiradasPorTurno = 2;
        Turno[] turnos = new Turno[12];
        public Turno[] Turnos => turnos;
        public int TurnoActual = 0;

        public int PuntuacionActual
        {
            get
            {
                int suma = 0;
                for (int i = 0; i < Turno.turnosMaximos; ++i)
                {
                    if (turnos[i] != null)
                    {
                        suma += turnos[i].cantidadDePinosTirados;

                        if (turnos[i].esSpare && i < turnos.Length - 1 && turnos[i + 1] != null)
                        {
                            suma += turnos[i + 1].cantidadDePinosTirada1;
                        }

                        if (turnos[i].esStrike && i < turnos.Length - 1 && turnos[i + 1] != null)
                        {
                            suma += turnos[i + 1].cantidadDePinosTirados;

                            if (turnos[i + 1].esStrike && i < turnos.Length - 2 && turnos[i + 2] != null)
                            {
                                suma += turnos[i + 2].cantidadDePinosTirada1;
                            }


                        }

                    }
                }
                return suma;
            }
        }

        public bool ValidarPinos(int pinos)
        {
            if (pinos < 0) return false;
            if (pinos > 10) return false;
            return true;
        }

        public int TirarPinos(int pinos)
        {
            int cantidadPinosAntesTirarda = cantidadPinosDelTurno;
            cantidadPinosDelTurno = Math.Max(0, cantidadPinosDelTurno - pinos);
            return cantidadPinosAntesTirarda - cantidadPinosDelTurno;
        }

        public void RealizarTirada(int pinos)
        {
            if (TurnoActual == 0 && turnos[0] == null)
            {
                turnos[0] = new Turno();
            }

            turnos[TurnoActual].cantidadTiradasActuales++;

            if (turnos[TurnoActual].cantidadTiradasActuales == 1)
            {
                turnos[TurnoActual].cantidadDePinosTirada1 = TirarPinos(pinos);
            }
            else
            {
                turnos[TurnoActual].cantidadDePinosTirada2 = TirarPinos(pinos);
            }

            if (turnos[TurnoActual].cantidadTiradasActuales >= cantidadMaxTiradasPorTurno || cantidadPinosDelTurno == 0)
            {
                ResetearTurno();
            }
        }
        void ResetearTurno()
        {
            cantidadPinosDelTurno = 10;
            TurnoActual++;
            if (TurnoActual >= turnos.Length) return;
            turnos[TurnoActual] = new Turno();
        }

        public int CalcularPuntuacion(int cantidadBolosTirados)
        {
            int puntuacion = cantidadBolosTirados;
            return puntuacion;
        }

        public int ObtenerTiradasBonificadas(int turnoJugado, string tipoJugada)
        {
            if (turnoJugado >= Turno.turnosMaximos - 1 && tipoJugada == "strike") return 2;
            if (turnoJugado >= Turno.turnosMaximos - 1 && tipoJugada == "spare") return 1;
            return 0;
        }
    }

    public class Turno
    {
        public const int cantidadMaxTiradasPorTurno = 2;
        public int cantidadTiradasActuales = 0;
        public bool habilitado = true;
        public bool esSpare => cantidadDePinosTirada1 < 10 && cantidadDePinosTirados == 10;
        public bool esStrike => cantidadDePinosTirada1 == 10;
        public int cantidadDePinosTirados => (cantidadDePinosTirada1 + cantidadDePinosTirada2);
        public int cantidadDePinosTirada1;
        public int cantidadDePinosTirada2;
        public static int turnosMaximos = 10;
    }
}
