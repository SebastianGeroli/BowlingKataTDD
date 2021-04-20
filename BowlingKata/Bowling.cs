using System;

namespace BowlingKata
{
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
}
