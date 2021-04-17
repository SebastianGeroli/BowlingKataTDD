using NUnit.Framework;
using BowlingKata;
namespace BowlingTest
{
    public class BowlingShould
    {
        [TestCase(-1, false)]
        [TestCase(11, false)]
        [TestCase(0, true)]
        [TestCase(10, true)]
        public void ValidarPinos(int pinos, bool esperado)
        {
            //Given
            Bowling bowling = new Bowling();
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
            //Given
            Bowling bowling = new Bowling();
            //When
            int result =bowling.TirarPinos(pinos);
            //Assert
            Assert.AreEqual(esperado, result);
        }
    }
}