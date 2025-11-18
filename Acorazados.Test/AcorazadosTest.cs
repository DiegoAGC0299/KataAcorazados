using AwesomeAssertions;

namespace Acorazados.Test;

public class AcorazadosTest
{
    [Fact]
    public void Si_InicializoElJuegoDeAcorazados_Debe_NumeroFilasYColumnasSer10()
    {
        var acorazados = new Acorazados();

        acorazados.ObtenerNumeroFilasTablero().Should().Be(10);
        acorazados.ObtenerNumeroColumnasTablero().Should().Be(10);

    }
    

    public class Acorazados
    {
        public string[,] Tablero { get; set; }

        public Acorazados()
        {
            Tablero = new string[10, 10];
        }

        public int ObtenerNumeroFilasTablero() => Tablero.GetLength(0);

        public int ObtenerNumeroColumnasTablero() => Tablero.GetLength(1);
    }
}