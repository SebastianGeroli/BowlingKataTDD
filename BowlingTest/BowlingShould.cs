using NUnit.Framework;
using BowlingKata;
namespace BowlingTest
{
    public class BowlingShould
    {
        Bowling bowling;
        [SetUp]
        public void Setup()
        {
            bowling = new Bowling();
        }

        [TestCase(-1, false)]
        [TestCase(11, false)]
        [TestCase(0, true)]
        [TestCase(10, true)]
        public void ValidarPinos(int pinos, bool esperado)
        {
            //When
            bool _10pinos = bowling.ValidarPinos(pinos);
            //Assert
            Assert.AreEqual(_10pinos, esperado);
        }


        [TestCase(0, 0)]
        [TestCase(10, 10)]
        [TestCase(15, 10)]
        public void TirarPinos(int pinos, int esperado)
        {
            //When
            int result = bowling.TirarPinos(pinos);
            //Assert
            Assert.AreEqual(esperado, result);
        }


        // tiradas
        // 5 , 4 = 9 turno terminado // turno 0
        // 5 , 5 = 10 turno terminado // turno 1
        // 10 = turno terminado // turno 2
        // turno 3 esperando jugada..
        [TestCase(3, 4, 3, 3, 3, 5, 2)]
        [TestCase(12,10,10,10,10,10,10,10,10,10,10,10,10)]
        public void ValidarMaxCantidadTiradasPorTurno(int turnoEsperado, params int[] jugadas)
        {
            //Given

            //When
            foreach (var jugada in jugadas)
            {
                bowling.TirarPinos(jugada);
            }

            //Assert
            Assert.AreEqual(turnoEsperado, bowling.TurnoActual);
        }
        [TestCase(0,0)]
        [TestCase(8, 8)]
        [TestCase(1,1)]
        [TestCase(2,2)]
        public void ValidarPuntuacionTurnoSinSpareSinStrike(int cantidadBolosTirados,int esperado) {
            //When
            int resultado = bowling.CalcularPuntuacion(cantidadBolosTirados);
            //Assert
            Assert.AreEqual(resultado, esperado);
        }

        //Historia 10mo Turno
        [TestCase(8, "", 0)]
        [TestCase(9, "", 0)]
        [TestCase(8, "strike", 0)]
        [TestCase(8, "spare", 0)]
        [TestCase(9, "strike", 2)]
        [TestCase(9, "spare", 1)]
        public void SumarTiradasBonificadas(int turnoJugado, string tipoJugada, int tiradasEsperadas)
        {
            //When
            int resultado = bowling.ObtenerTiradasBonificadas(turnoJugado, tipoJugada);
            //Assert
            Assert.AreEqual(tiradasEsperadas, resultado);
        }
    }
}