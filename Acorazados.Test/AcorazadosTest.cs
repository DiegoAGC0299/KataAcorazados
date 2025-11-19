using AwesomeAssertions;

namespace Acorazados.Test;

public class AcorazadosTest
{
    
    [Fact]
    public void Si_AgregoUnJugador_Debe_ExistirUnJugadorConUnTablero()
    {
        var acorazados = new  Acorazados();
        acorazados.AgregarJugador("David");

        var jugador = acorazados.ObtenerJugador(0);
        
        jugador.Should().NotBeNull();
        jugador.Tablero.Should().NotBeNull();
    }
    
    


    
    
    
}