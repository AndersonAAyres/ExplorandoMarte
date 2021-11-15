using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExplorandoMarteTest
{
    [TestClass]
    public class TesteUnitarioSonda
    {
        private Sonda _sonda;

        [TestInitialize] 
        public void Incializar()
        { 
            _sonda = new Sonda();
            _sonda.CoordenadaX = 0;
            _sonda.CoordenadaY = 0;
            _sonda.Direcao = 'N';
        }

        [TestMethod]
        public void ComandosValidos()
        {
            try
            {
                _sonda.MovimentaSonda("M", $"{_sonda.CoordenadaX} {_sonda.CoordenadaY} {_sonda.Direcao}");
                Assert.IsTrue(true);
            }
            catch (System.Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void ComandosInvalidos()
        {
            try
            {
                _sonda.MovimentaSonda("X", $"{_sonda.CoordenadaX} {_sonda.CoordenadaY} {_sonda.Direcao}");
                Assert.IsTrue(false);
            }
            catch (System.Exception)
            {
                Assert.IsTrue(true);
            }
            
        }

        [TestMethod]
        public void MoveSondaparaDireira()
        {
            _sonda.MovimentaSonda("R", $"{_sonda.CoordenadaX} {_sonda.CoordenadaY} {_sonda.Direcao}");
            Assert.IsTrue(_sonda.Direcao == 'E');
        }

        [TestMethod]
        public void MoveSondaparaEsquerda()
        {
            _sonda.MovimentaSonda("L", $"{_sonda.CoordenadaX} {_sonda.CoordenadaY} {_sonda.Direcao}");
            Assert.IsTrue(_sonda.Direcao == 'W');
        }

        [TestMethod]
        public void MoveSondaparaFrente()
        {
            _sonda.MovimentaSonda("M", $"{_sonda.CoordenadaX} {_sonda.CoordenadaY} {_sonda.Direcao}");
            Assert.IsTrue(_sonda.CoordenadaY == 1);
        }
    }
}
