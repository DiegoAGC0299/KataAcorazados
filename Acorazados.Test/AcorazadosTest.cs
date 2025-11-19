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
        
        jugador.Nombre.Should().Be("David");
        jugador.Tablero.Should().NotBeNull();
    }

    [Fact]
    public void Si_AgregoMasDeDosJugadores_Debe_LanzarExcepcion()
    {
        var acorazados = new  Acorazados();
        acorazados.AgregarJugador("David");
        acorazados.AgregarJugador("Diego");
        
        Action resultado = () => acorazados.AgregarJugador("Juan");
        
        resultado.Should().ThrowExactly<InvalidOperationException>("No se pueden agregar más de dos jugadores");
    }
    
}