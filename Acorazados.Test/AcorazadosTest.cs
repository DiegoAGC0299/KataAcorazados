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

    [Fact]
    public void Si_AgregoUnCanoneroConLaCoordenada1_1_Debe_ExistirElCañonero_EnLaCoordenada1_1()
    {
        var acorazados = new Acorazados();

        acorazados.AgregarBarco("Cañonero", 1, 1);

        acorazados.ConsultarBarco(1, 1).Should().Be("g");
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

        public void AgregarBarco(string barco, int x, int y)
        {
        }

        public string ConsultarBarco(int x, int y)
        {
            return "g";
        }
    }
}