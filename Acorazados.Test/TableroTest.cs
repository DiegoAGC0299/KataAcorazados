using AwesomeAssertions;

namespace Acorazados.Test;

public class TableroTest
{
    [Fact]
    public void Si_AgregoUnCanoneroConLaCoordenada1_1_Debe_ExistirElCañonero_EnLaCoordenada1_1()
    {
        var tablero = new Tablero();

        tablero.AgregarBarco(Barcos.Canonero, 1, 1);

        tablero.ConsultarValorPorCoordenada(1, 1).Should().Be("g");
    }

    [Fact]
    public void Si_AgregoDestructorConLaCoordenada1_2EnPosicionVertical_Debe_ExistirDestructorEnLaCoordenada1_21_3Y1_4()
    {
        var tablero = new Tablero();
        
        tablero.AgregarBarco(Barcos.Destructor, 1, 2, Orientacion.Vertical);
        
        tablero.ConsultarValorPorCoordenada(1, 2).Should().Be("d");
        tablero.ConsultarValorPorCoordenada(1, 3).Should().Be("d");
        tablero.ConsultarValorPorCoordenada(1, 4).Should().Be("d");
    }
    
    [Fact]
    public void Si_AgregoDestructorConLaCoordenada1_2EnPosicionHorizontal_Debe_ExistirDestructorEnLaCoordenada1_22_2Y3_2()
    {
        var tablero = new Tablero();
        
        tablero.AgregarBarco(Barcos.Destructor, 1, 2, Orientacion.Horizontal);
        
        tablero.ConsultarValorPorCoordenada(1, 2).Should().Be("d");
        tablero.ConsultarValorPorCoordenada(2, 2).Should().Be("d");
        tablero.ConsultarValorPorCoordenada(3, 2).Should().Be("d");
    }
    
    [Fact]
    public void Si_AgregoPortavionesConLaCoordenada1_3EnPosicionHorizontal_Debe_ExistirPortavionesEnLaCoordenada1_32_3_3_3Y4_3()
    {
        var tablero = new Tablero();
        
        tablero.AgregarBarco(Barcos.Portaaviones, 1, 3, Orientacion.Horizontal);
        
        tablero.ConsultarValorPorCoordenada(1, 3).Should().Be("c");
        tablero.ConsultarValorPorCoordenada(2, 3).Should().Be("c");
        tablero.ConsultarValorPorCoordenada(3, 3).Should().Be("c");
        tablero.ConsultarValorPorCoordenada(4, 3).Should().Be("c");
    }
    
    [Fact]
    public void Si_AgregoPortavionesConLaCoordenada1_3EnPosicionVertical_Debe_ExistirPortavionesEnLaCoordenada1_31_4_1_5Y1_6()
    {
        var tablero = new Tablero();
        
        tablero.AgregarBarco(Barcos.Portaaviones, 1, 3, Orientacion.Vertical);
        
        tablero.ConsultarValorPorCoordenada(1, 3).Should().Be("c");
        tablero.ConsultarValorPorCoordenada(1, 4).Should().Be("c");
        tablero.ConsultarValorPorCoordenada(1, 5).Should().Be("c");
        tablero.ConsultarValorPorCoordenada(1, 6).Should().Be("c");
    }
    
    [Fact]
    public void Si_NoHayBarcosEnElTablero_ReciboUnDisparoConCoordenada1_1_Debe_RetornarMensajeAguaYMarcarLaCoordenadaConO()
    {
        var tablero = new Tablero();

        var mensaje = tablero.RecibirDisparo(1, 1);

        mensaje.Should().Be("Agua");
        tablero.ConsultarValorPorCoordenada(1, 1).Should().Be("o");

    }
    
    [Fact]
    public void Si_HayUnDestructorEnElTablero_ReciboUnDisparoConCoordenada1_2_Debe_RetornarMensajeTiroExitosoYMarcarLaCoordenadaConx()
    {
        var tablero = new Tablero();
        tablero.AgregarBarco(Barcos.Destructor, 1, 2);

        var mensaje = tablero.RecibirDisparo(1, 2);

        mensaje.Should().Be("Tiro exitoso");
        tablero.ConsultarValorPorCoordenada(1, 2).Should().Be("x");

    }
    
    [Fact]
    public void Si_HayUnDestructorEnElTablero_ReciboDosDisparoConCoordenada1_2Y2_2_Debe_SegundoDisparoRetornarMensajeTiroExitosoYMarcarLaCoordenadasConx()
    {
        var tablero = new Tablero();
        tablero.AgregarBarco(Barcos.Destructor, 1, 2);
        tablero.RecibirDisparo(1, 2);
        
        var mensajeSegundoDisparo  = tablero.RecibirDisparo(2, 2);

        mensajeSegundoDisparo.Should().Be("Tiro exitoso");
        tablero.ConsultarValorPorCoordenada(1, 2).Should().Be("x");
        tablero.ConsultarValorPorCoordenada(2, 2).Should().Be("x");

    }
    
    [Fact]
    public void Si_HayUnDestructorEnElTablero_ReciboTresDisparoConCoordenada1_22_2Y3_2_Debe_TercerDisparoRetornarMensajeBarcoHundidoYMarcarLaCoordenadasConX()
    {
        var tablero = new Tablero();
        tablero.AgregarBarco(Barcos.Destructor, 1, 2);
        tablero.RecibirDisparo(1, 2);
        tablero.RecibirDisparo(2, 2);
        
        var mensajeTercerDisparo  = tablero.RecibirDisparo(3, 2);

        mensajeTercerDisparo.Should().Be("Barco hundido");
        tablero.ConsultarValorPorCoordenada(1, 2).Should().Be("X");
        tablero.ConsultarValorPorCoordenada(2, 2).Should().Be("X");
        tablero.ConsultarValorPorCoordenada(3, 2).Should().Be("X");

    }
    
    [Fact]
    public void Si_HayUnCanoneroEnElTableroConCoordenada5_5_ReciboDisparoConCoordenada5_5_Debe_DisparoRetornarMensajeBarcoHundidoYMarcarLaCoordenada5_5ConX()
    {
        var tablero = new Tablero();
        tablero.AgregarBarco(Barcos.Canonero, 5, 5);
        
        var mensaje  = tablero.RecibirDisparo(5, 5);

        mensaje.Should().Be("Barco hundido");
        tablero.ConsultarValorPorCoordenada(5, 5).Should().Be("X");

    }
    
    [Fact]
    public void Si_HayUnPortaavionesEnElTableroConCoordenada_5_ReciboDisparoConCoordenada1_8_Debe_DisparoRetornarMensajeBarcoHundidoYMarcarLasCoordenadasDelBarcoConX()
    {
        var tablero = new Tablero();
        tablero.AgregarBarco(Barcos.Portaaviones, 8, 1, Orientacion.Vertical);
        tablero.RecibirDisparo(8, 1);
        tablero.RecibirDisparo(8, 2);
        tablero.RecibirDisparo(8, 3);
                
        var mensaje  = tablero.RecibirDisparo(8, 4);

        mensaje.Should().Be("Barco hundido");
        tablero.ConsultarValorPorCoordenada(8, 1).Should().Be("X");
        tablero.ConsultarValorPorCoordenada(8, 2).Should().Be("X");
        tablero.ConsultarValorPorCoordenada(8, 3).Should().Be("X");
        tablero.ConsultarValorPorCoordenada(8, 4).Should().Be("X");
    }
    

    [Fact]
    public void Si_AgregoUnSegundoPortaaviones_Debe_ArrojarExcepcion ()
    {
        var tablero = new Tablero();
        tablero.AgregarBarco(Barcos.Portaaviones, 8, 1, Orientacion.Vertical);
        
       Action respuesta = () => tablero.AgregarBarco(Barcos.Portaaviones, 7, 1, Orientacion.Vertical);
        
       respuesta.Should().ThrowExactly<InvalidOperationException>()
           .WithMessage("No se puede adicionar otro portaaviones");
    }
    [Fact]
    public void Si_AgregoTresDestructores_Debe_ArrojarExcepcion ()
    {
        var tablero = new Tablero();
        tablero.AgregarBarco(Barcos.Destructor, 8, 1, Orientacion.Vertical);
        tablero.AgregarBarco(Barcos.Destructor, 7, 1, Orientacion.Vertical);
        
        Action respuesta = () => tablero.AgregarBarco(Barcos.Destructor, 6, 1, Orientacion.Vertical);
        
        respuesta.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("No se puede adicionar otro destructor");
    }
    
    [Fact]
    public void Si_AgregoCincoCanoneros_Debe_ArrojarExcepcion ()
    {
        var tablero = new Tablero();
        tablero.AgregarBarco(Barcos.Canonero, 8, 1, Orientacion.Vertical);
        tablero.AgregarBarco(Barcos.Canonero, 7, 1, Orientacion.Vertical);
        tablero.AgregarBarco(Barcos.Canonero, 6, 1, Orientacion.Vertical);
        tablero.AgregarBarco(Barcos.Canonero, 5, 1, Orientacion.Vertical);
        
        Action respuesta = () => tablero.AgregarBarco(Barcos.Canonero, 4, 1, Orientacion.Vertical);
        
        respuesta.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("No se puede adicionar otro cañonero");
    }
    
    [Fact]
    public void Si_AgregoDosCanonerosEnLaCoordenada1_1_Debe_ArrojarExcepcion()
    {
        var tablero = new Tablero();
        tablero.AgregarBarco(Barcos.Canonero, 1, 1);
        
        Action respuesta = () => tablero.AgregarBarco(Barcos.Canonero, 1, 1);
        
        respuesta.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("Ya se encuentra un barco ubicado en la coordenada 1,1");
    }

    [Fact]
    public void Si_PosicionoUnPortaavionesEn1_3HorizontalYUnDestructorEn1_1Vertical_Debe_ArrojarExcepcion()
    {
        var tablero = new Tablero();
        tablero.AgregarBarco(Barcos.Portaaviones, 1, 3, Orientacion.Horizontal);
        
        Action respuesta = () => tablero.AgregarBarco(Barcos.Destructor, 1, 1, Orientacion.Vertical);
        
        respuesta.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("Ya se encuentra un barco ubicado en la coordenada 1,3");
    }
    
    [Fact]
    public void Si_PosicionoUnPortaavionesEn9_1Horizontal_Debe_ArrojarExcepcionPorFueraDeltablero()
    {
        var tablero = new Tablero();
        
        Action respuesta = () => tablero.AgregarBarco(Barcos.Portaaviones, 9, 1);
        
        respuesta.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("La coordenada excede el limite del tablero");
    }
    
    [Fact]
    public void Si_PosicionoUnPortaavionesEn9_9Vertical_Debe_ArrojarExcepcionPorFueraDeltablero()
    {
        var tablero = new Tablero();
        
        Action respuesta = () => tablero.AgregarBarco(Barcos.Portaaviones, 9, 9, Orientacion.Vertical);
        
        respuesta.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("La coordenada excede el limite del tablero");
    }
}