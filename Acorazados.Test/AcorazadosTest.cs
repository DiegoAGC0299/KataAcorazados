using AwesomeAssertions;

namespace Acorazados.Test;

public class AcorazadosTest
{
    [Fact]
    public void Si_InicializoElJuegoDeAcorazados_DebeExistirUnTableroDe10x10()
    {
        var acorazados = new Acorazados();

        acorazados.Tablero.Should().NotBeNull();
    }
    

    public class Acorazados
    {
        public object Tablero { get; set; }
    }
}