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

    [Fact]
    public void Si_InicialElJuegoYUnoDeLosDosJugadoresNoTieneBarcos_Debe_GenerarExcepcion()
    {
        var acorazados = new  Acorazados();
        acorazados.AgregarJugador("David");
        acorazados.AgregarJugador("Diego");
        var jugadorUno = acorazados.ObtenerJugador(0);
        jugadorUno.Tablero.AgregarBarco(Barcos.Canonero, 1,1);

        Action respuesta = () =>  acorazados.Start();
        
        respuesta
            .Should()
            .ThrowExactly<InvalidOperationException>()
            .WithMessage("Ambos jugadores deben tener barcos en el tablero");
        
    }

    [Fact]
    public void Si_InicializoElJuego_Debe_EstadoSerNoIniciado()
    {
        var acorazados = new  Acorazados();
        acorazados.Estado.Should().Be("NoIniciado");
    }
    
    
    
}