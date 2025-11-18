using AwesomeAssertions;

namespace Acorazados.Test;

public class AcorazadosTest
{
    [Fact]
    public void Si_InicializoElJuegoDeAcorazados_DebeExistirUnTableroDe10x10()
    {
        var acorazados = new Acorazados();

        acorazados.ObtenerNumeroFilasTablero().Should().Be(10);
        acorazados.NumeroColumnas().Should().Be(10);

    }
    

    public class Acorazados
    {
        public string[,] Tablero { get; set; }

        public int ObtenerNumeroFilasTablero()
        {
            return 10;
        }

        public int NumeroColumnas()
        {
            return 10;
        }
    }
}