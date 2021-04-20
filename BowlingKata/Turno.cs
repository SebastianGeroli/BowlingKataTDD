namespace BowlingKata
{
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
