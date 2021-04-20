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
                bowling.RealizarTirada(jugada);
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

        [TestCase(20, 4, 3, 3, 3, 5, 2)]
        [TestCase(1, 1)]
        //[TestCase(12,10,10,10,10,10,10,10,10,10,10,10,10)]
        public void ValidarPuntuacionDespuesDeTiradas(int puntuacionEsperada, params int[] jugadas)
        {
            //Given

            //When
            foreach (var jugada in jugadas)
            {
                bowling.RealizarTirada(jugada);
            }
            //Assert
            Assert.AreEqual(puntuacionEsperada, bowling.PuntuacionActual);
        }

        [TestCase(20, 3,7,5,0)]// turno 0 = 15   TOTAL = 20;
        //[TestCase(12,10,10,10,10,10,10,10,10,10,10,10,10)]
        public void ValidarPuntuacionConSpare(int puntuacionEsperada, params int[] jugadas)
        {
            //Given

            //When
            foreach (var jugada in jugadas)
            {
                bowling.RealizarTirada(jugada);
            }
            //Assert
            Assert.AreEqual(puntuacionEsperada, bowling.PuntuacionActual);
        }

        [TestCase(20, 10,5,0)]// turno 0 = 15   TOTAL = 20;
        [TestCase(30, 10,10,0,0)]//
        [TestCase(60,10,10,10)]//turno 0 = 30, turno 1= 20, turno 3 = 10 Subtotal = 60
        [TestCase(46,10,9,1,8,0)]// turno 0 = 20, turno 1 = 18 turno 2 = 8   Subtotal = 46
        [TestCase(300,10,10,10,10,10,10,10,10,10,10,10,10)] // 300 Total
        [TestCase(114,5,3,10,6,0,2,5,6,4,4,0,0,0,6,3,2,8,10,10,10)]// 114 total
        public void ValidarPuntuacionConStrike(int puntuacionEsperada, params int[] jugadas)
        {
            //Given

            //When
            foreach (var jugada in jugadas)
            {
                bowling.RealizarTirada(jugada);
            }
            //Assert
            Assert.AreEqual(puntuacionEsperada, bowling.PuntuacionActual);
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