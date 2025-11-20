using AwesomeAssertions;

namespace Acorazados.Test;

public class AcorazadosTest
{
    private readonly IAcorazadosBuilder _acorazadosBuilder = new AcorazadosBuilder();

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
        acorazados.Estado.Should().Be(EstadoJuego.NoIniciado);
    }
    
    [Fact]
    public void Si_ComienzoElJuegoConJugadoresYBarcos_Debe_EstadoSerIniciado()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,1);
            } )
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,1);
            }).Construir();
        
        acorazados.Start();
        
        acorazados.Estado.Should().Be(EstadoJuego.EnCurso);
    }
    
    [Fact]
    public void Si_JugadorUnoDisparaAlJugadorDosConCoordenada1_1_Debe_MostrarTiroExitoso()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero =>
            {
                tablero.AgregarBarco(Barcos.Destructor, 1,2);
            } )
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Destructor, 1,1);
            }).Construir();
        acorazados.Start();

        acorazados.Disparar(1, 1).Should().Be("Tiro exitoso");
    }
    
    
    [Fact]
    public void Si_JugadorUnoDisparaAlJugadorDosConCoordenada5_5_Debe_MostrarAgua()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,2);
            } )
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,1);
            }).Construir();
        acorazados.Start();

        acorazados.Disparar(5, 5).Should().Be("Agua");
    }
    
    [Fact]
    public void Si_JugadorUnoDisparoYJugadorDosDisparaAlJugadorUnoConCoordenada1_2_Debe_MostrarTiroExitoso()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero =>
            {
                tablero.AgregarBarco(Barcos.Destructor, 1,2);
            } )
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Destructor, 1,1);
            }).Construir();
        acorazados.Start();

        acorazados.Disparar(5, 5);
        
        acorazados.Disparar(1, 2).Should().Be("Tiro exitoso");
    }
    
    [Fact]
    public void Si_JugadorUnoDisparaYJugadorDosQuedaConTodosLosBarcosHundidos_Debe_EstadoDelJuegoEstarFinalizado()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,2);
            } )
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,1);
            }).Construir();
        acorazados.Start();
        
        acorazados.Disparar(1, 1).Should().Be("Barco hundido");
        acorazados.Estado.Should().Be(EstadoJuego.Finalizado);
    }

    
    
}