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

        Action respuesta = () =>  acorazados.Iniciar();
        
        respuesta
            .Should()
            .ThrowExactly<InvalidOperationException>()
            .WithMessage("Ambos jugadores deben tener barcos en el tablero");
        
    }

    [Fact]
    public void Si_InicializoElJuego_Debe_EstadoSerNoIniciado()
    {
        var acorazados = new  Acorazados();
        acorazados.EstadoJuego.Should().Be(EstadoJuego.NoIniciado);
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
        
        acorazados.Iniciar();
        
        acorazados.EstadoJuego.Should().Be(EstadoJuego.EnCurso);
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
        acorazados.Iniciar();

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
        acorazados.Iniciar();

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
        acorazados.Iniciar();

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
        acorazados.Iniciar();
        
        acorazados.Disparar(1, 1).Should().Be("Barco hundido");
        acorazados.EstadoJuego.Should().Be(EstadoJuego.Finalizado);
    }

    [Fact]
    public void Si_DisparaYElEstadoDelJuegoEsNoIniciado_Debe_LanzarExcepcion()
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


        Action resultado = () => acorazados.Disparar(1, 1);
        
        resultado.Should().ThrowExactly<InvalidOperationException>("Debe iniciar el juego para poder disparar");
    }
    
    [Fact]
    public void Si_DisparaYElEstadoDelJuegoEsFinalizado_Debe_LanzarExcepcion()
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
        acorazados.Iniciar();
        acorazados.Disparar(1, 1);
        
        Action resultado = () => acorazados.Disparar(1, 1);
        
        resultado.Should().ThrowExactly<InvalidOperationException>("Debe iniciar un juego nuevo");
    }

    
    [Fact]
    public void Si_CualquierJugadorDisparaCoordenadasFueraDelRangoDelTablero_Debe_LanzarExcepcion()
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
        acorazados.Iniciar();
        
        Action resultado = () => acorazados.Disparar(111, 11);
        
        resultado.Should().ThrowExactly<InvalidOperationException>().WithMessage("La coordenada excede el limite del tablero");
    }
    
    [Fact]
    public void Si_ElJugadorUnoTieneUnCanoneroEnLaCoordenada1_1EImprimoElTablero_Debe_MostrarTableroActualDelJugadorUnoConUnCanoneroEnCoordenada1_1()
    {
        var tableroEsperado = 
            "  Jugador: David\n" +
            "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
            "0 |   |   |   |   |   |   |   |   |   |   |\n" +
            "1 |   | g |   |   |   |   |   |   |   |   |\n" +
            "2 |   |   |   |   |   |   |   |   |   |   |\n" +
            "3 |   |   |   |   |   |   |   |   |   |   |\n" +
            "4 |   |   |   |   |   |   |   |   |   |   |\n" +
            "5 |   |   |   |   |   |   |   |   |   |   |\n" +
            "6 |   |   |   |   |   |   |   |   |   |   |\n" +
            "7 |   |   |   |   |   |   |   |   |   |   |\n" +
            "8 |   |   |   |   |   |   |   |   |   |   |\n" +
            "9 |   |   |   |   |   |   |   |   |   |   |";

        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,1);
            } )
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,1);
            }).Construir();
        acorazados.Iniciar();
    
        acorazados.Imprimir().Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_JugadorDosTieneUnCanonerEnLaCoordenada1_1YJugadorUnoDisparaACoordenada2_2_Debe_MostrarTableroActualDelJugadorDosConUnCanoneroYUnTiroFallido()
    {
        var tableroEsperado = 
            "  Jugador: Diego\n" +
            "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
            "0 |   |   |   |   |   |   |   |   |   |   |\n" +
            "1 |   | g |   |   |   |   |   |   |   |   |\n" +
            "2 |   |   | o |   |   |   |   |   |   |   |\n" +
            "3 |   |   |   |   |   |   |   |   |   |   |\n" +
            "4 |   |   |   |   |   |   |   |   |   |   |\n" +
            "5 |   |   |   |   |   |   |   |   |   |   |\n" +
            "6 |   |   |   |   |   |   |   |   |   |   |\n" +
            "7 |   |   |   |   |   |   |   |   |   |   |\n" +
            "8 |   |   |   |   |   |   |   |   |   |   |\n" +
            "9 |   |   |   |   |   |   |   |   |   |   |";
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,2);
            } )
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,1);
            }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(2, 2);
    
        acorazados.Imprimir().Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_JugadorUnoTieneUnCanoneroEnLaCoordenada1_1YJugadorDosDisparaACoordenada3_2_Debe_MostrarTableroActualDelJugadorUnoConUnCanoneroYUnTiroFallido()
    {
        var tableroEsperado = 
            "  Jugador: David\n" +
            "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
            "0 |   |   |   |   |   |   |   |   |   |   |\n" +
            "1 |   | g |   |   |   |   |   |   |   |   |\n" +
            "2 |   |   |   | o |   |   |   |   |   |   |\n" +
            "3 |   |   |   |   |   |   |   |   |   |   |\n" +
            "4 |   |   |   |   |   |   |   |   |   |   |\n" +
            "5 |   |   |   |   |   |   |   |   |   |   |\n" +
            "6 |   |   |   |   |   |   |   |   |   |   |\n" +
            "7 |   |   |   |   |   |   |   |   |   |   |\n" +
            "8 |   |   |   |   |   |   |   |   |   |   |\n" +
            "9 |   |   |   |   |   |   |   |   |   |   |";
        
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,2);
            } )
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,1);
            }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(2, 2);
        
        acorazados.Disparar(3, 2);

        acorazados.Imprimir().Should().Be(tableroEsperado);

    }
    
    [Fact]
    public void Si_JugadorDosTieneUnDestructorEnLaCoordenada1_1EnPosicionHorizontalYJugadorUnoDisparaACoordenada1_1_Debe_MostrarTableroActualDelJugadorDosConUnDestructorYTiroExitoso()
    {
        var tableroEsperado = 
            "  Jugador: Diego\n" +
            "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
            "0 |   |   |   |   |   |   |   |   |   |   |\n" +
            "1 |   | x | d | d |   |   |   |   |   |   |\n" +
            "2 |   |   |   |   |   |   |   |   |   |   |\n" +
            "3 |   |   |   |   |   |   |   |   |   |   |\n" +
            "4 |   |   |   |   |   |   |   |   |   |   |\n" +
            "5 |   |   |   |   |   |   |   |   |   |   |\n" +
            "6 |   |   |   |   |   |   |   |   |   |   |\n" +
            "7 |   |   |   |   |   |   |   |   |   |   |\n" +
            "8 |   |   |   |   |   |   |   |   |   |   |\n" +
            "9 |   |   |   |   |   |   |   |   |   |   |";
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1,2, Orientacion.Horizontal);
            } )
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Destructor, 1,1);
            }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(1, 1);
    
        acorazados.Imprimir().Should().Be(tableroEsperado);
    }
    
    



    
    
}