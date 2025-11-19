using AwesomeAssertions;

namespace Acorazados.Test;

public class AcorazadosTest
{

    [Fact]
    public void Si_AgregoUnCanoneroConLaCoordenada1_1_Debe_ExistirElCañonero_EnLaCoordenada1_1()
    {
        var acorazados = new Acorazados();

        acorazados.AgregarBarco(Barcos.Canonero, 1, 1);

        acorazados.ConsultarValorPorCoordenada(1, 1).Should().Be("g");
    }

    [Fact]
    public void Si_AgregoDestructorConLaCoordenada1_2EnPosicionVertical_Debe_ExistirDestructorEnLaCoordenada1_21_3Y1_4()
    {
        var acorazados = new Acorazados();
        
        acorazados.AgregarBarco(Barcos.Destructor, 1, 2, Orientacion.Vertical);
        
        acorazados.ConsultarValorPorCoordenada(1, 2).Should().Be("d");
        acorazados.ConsultarValorPorCoordenada(1, 3).Should().Be("d");
        acorazados.ConsultarValorPorCoordenada(1, 4).Should().Be("d");
    }
    
    [Fact]
    public void Si_AgregoDestructorConLaCoordenada1_2EnPosicionHorizontal_Debe_ExistirDestructorEnLaCoordenada1_22_2Y3_2()
    {
        var acorazados = new Acorazados();
        
        acorazados.AgregarBarco(Barcos.Destructor, 1, 2, Orientacion.Horizontal);
        
        acorazados.ConsultarValorPorCoordenada(1, 2).Should().Be("d");
        acorazados.ConsultarValorPorCoordenada(2, 2).Should().Be("d");
        acorazados.ConsultarValorPorCoordenada(3, 2).Should().Be("d");
    }
    
    [Fact]
    public void Si_AgregoPortavionesConLaCoordenada1_3EnPosicionHorizontal_Debe_ExistirPortavionesEnLaCoordenada1_32_3_3_3Y4_3()
    {
        var acorazados = new Acorazados();
        
        acorazados.AgregarBarco(Barcos.Portaaviones, 1, 3, Orientacion.Horizontal);
        
        acorazados.ConsultarValorPorCoordenada(1, 3).Should().Be("c");
        acorazados.ConsultarValorPorCoordenada(2, 3).Should().Be("c");
        acorazados.ConsultarValorPorCoordenada(3, 3).Should().Be("c");
        acorazados.ConsultarValorPorCoordenada(4, 3).Should().Be("c");
    }
    
    [Fact]
    public void Si_AgregoPortavionesConLaCoordenada1_3EnPosicionVertical_Debe_ExistirPortavionesEnLaCoordenada1_31_4_1_5Y1_6()
    {
        var acorazados = new Acorazados();
        
        acorazados.AgregarBarco(Barcos.Portaaviones, 1, 3, Orientacion.Vertical);
        
        acorazados.ConsultarValorPorCoordenada(1, 3).Should().Be("c");
        acorazados.ConsultarValorPorCoordenada(1, 4).Should().Be("c");
        acorazados.ConsultarValorPorCoordenada(1, 5).Should().Be("c");
        acorazados.ConsultarValorPorCoordenada(1, 6).Should().Be("c");
    }
    
    [Fact]
    public void Si_NoHayBarcosEnElTablero_ReciboUnDisparoConCoordenada1_1_Debe_RetornarMensajeAguaYMarcarLaCoordenadaConO()
    {
        var acorazados = new Acorazados();

        var mensaje = acorazados.RecibirDisparo(1, 1);

        mensaje.Should().Be("Agua");
        acorazados.ConsultarValorPorCoordenada(1, 1).Should().Be("o");

    }
    
    [Fact]
    public void Si_HayUnDestructorEnElTablero_ReciboUnDisparoConCoordenada1_2_Debe_RetornarMensajeTiroExitosoYMarcarLaCoordenadaConx()
    {
        var acorazados = new Acorazados();
        acorazados.AgregarBarco(Barcos.Destructor, 1, 2);

        var mensaje = acorazados.RecibirDisparo(1, 2);

        mensaje.Should().Be("Tiro exitoso");
        acorazados.ConsultarValorPorCoordenada(1, 2).Should().Be("x");

    }
    
    [Fact]
    public void Si_HayUnDestructorEnElTablero_ReciboDosDisparoConCoordenada1_2Y2_2_Debe_SegundoDisparoRetornarMensajeTiroExitosoYMarcarLaCoordenadasConx()
    {
        var acorazados = new Acorazados();
        acorazados.AgregarBarco(Barcos.Destructor, 1, 2);
        acorazados.RecibirDisparo(1, 2);
        
        var mensajeSegundoDisparo  = acorazados.RecibirDisparo(2, 2);

        mensajeSegundoDisparo.Should().Be("Tiro exitoso");
        acorazados.ConsultarValorPorCoordenada(1, 2).Should().Be("x");
        acorazados.ConsultarValorPorCoordenada(2, 2).Should().Be("x");

    }
    
    [Fact]
    public void Si_HayUnDestructorEnElTablero_ReciboTresDisparoConCoordenada1_22_2Y3_2_Debe_TercerDisparoRetornarMensajeBarcoHundidoYMarcarLaCoordenadasConX()
    {
        var acorazados = new Acorazados();
        acorazados.AgregarBarco(Barcos.Destructor, 1, 2);
        acorazados.RecibirDisparo(1, 2);
        acorazados.RecibirDisparo(2, 2);
        
        var mensajeTercerDisparo  = acorazados.RecibirDisparo(3, 2);

        mensajeTercerDisparo.Should().Be("Barco hundido");
        acorazados.ConsultarValorPorCoordenada(1, 2).Should().Be("X");
        acorazados.ConsultarValorPorCoordenada(2, 2).Should().Be("X");
        acorazados.ConsultarValorPorCoordenada(3, 2).Should().Be("X");

    }
    
    [Fact]
    public void Si_HayUnCanoneroEnElTableroConCoordenada5_5_ReciboDisparoConCoordenada5_5_Debe_DisparoRetornarMensajeBarcoHundidoYMarcarLaCoordenada5_5ConX()
    {
        var acorazados = new Acorazados();
        acorazados.AgregarBarco(Barcos.Canonero, 5, 5);
        
        var mensaje  = acorazados.RecibirDisparo(5, 5);

        mensaje.Should().Be("Barco hundido");
        acorazados.ConsultarValorPorCoordenada(5, 5).Should().Be("X");

    }
    
    [Fact]
    public void Si_HayUnPortaavionesEnElTableroConCoordenada_5_ReciboDisparoConCoordenada1_8_Debe_DisparoRetornarMensajeBarcoHundidoYMarcarLasCoordenadasDelBarcoConX()
    {
        var acorazados = new Acorazados();
        acorazados.AgregarBarco(Barcos.Portaaviones, 8, 1, Orientacion.Vertical);
        acorazados.RecibirDisparo(8, 1);
        acorazados.RecibirDisparo(8, 2);
        acorazados.RecibirDisparo(8, 3);
                
        var mensaje  = acorazados.RecibirDisparo(8, 4);

        mensaje.Should().Be("Barco hundido");
        acorazados.ConsultarValorPorCoordenada(8, 1).Should().Be("X");
        acorazados.ConsultarValorPorCoordenada(8, 2).Should().Be("X");
        acorazados.ConsultarValorPorCoordenada(8, 3).Should().Be("X");
        acorazados.ConsultarValorPorCoordenada(8, 4).Should().Be("X");
    }

    [Fact]
    public void Si_AgregoUnSegundoPortaaviones_Debe_ArrojarExcepcion ()
    {
        var acorazados = new Acorazados();
        acorazados.AgregarBarco(Barcos.Portaaviones, 8, 1, Orientacion.Vertical);
        
       Action respuesta = () => acorazados.AgregarBarco(Barcos.Portaaviones, 7, 1, Orientacion.Vertical);
        
       respuesta.Should().ThrowExactly<InvalidOperationException>()
           .WithMessage("No se puede adicionar otro portaaviones");
    }
    [Fact]
    public void Si_AgregoTresDestructores_Debe_ArrojarExcepcion ()
    {
        var acorazados = new Acorazados();
        acorazados.AgregarBarco(Barcos.Destructor, 8, 1, Orientacion.Vertical);
        acorazados.AgregarBarco(Barcos.Destructor, 7, 1, Orientacion.Vertical);
        
        Action respuesta = () => acorazados.AgregarBarco(Barcos.Destructor, 6, 1, Orientacion.Vertical);
        
        respuesta.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("No se puede adicionar otro destructor");
    }
    
    [Fact]
    public void Si_AgregoCincoCanoneros_Debe_ArrojarExcepcion ()
    {
        var acorazados = new Acorazados();
        acorazados.AgregarBarco(Barcos.Canonero, 8, 1, Orientacion.Vertical);
        acorazados.AgregarBarco(Barcos.Canonero, 7, 1, Orientacion.Vertical);
        acorazados.AgregarBarco(Barcos.Canonero, 6, 1, Orientacion.Vertical);
        acorazados.AgregarBarco(Barcos.Canonero, 5, 1, Orientacion.Vertical);
        
        Action respuesta = () => acorazados.AgregarBarco(Barcos.Canonero, 4, 1, Orientacion.Vertical);
        
        respuesta.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("No se puede adicionar otro cañonero");
    }
    
    [Fact]
    public void Si_AgregoDosCanonerosEnLaCoordenada1_1_Debe_ArrojarExcepcion()
    {
        var acorazados = new Acorazados();
        acorazados.AgregarBarco(Barcos.Canonero, 1, 1);
        
        Action respuesta = () => acorazados.AgregarBarco(Barcos.Canonero, 1, 1);
        
        respuesta.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("Ya se encuentra un barco ubicado en la coordenada 1,1");
    }

    [Fact]
    public void Si_PosicionoUnPortaavionesEn1_3HorizontalYUnDestructorEn1_1Vertical_Debe_ArrojarExcepcion()
    {
        var acorazados = new Acorazados();
        acorazados.AgregarBarco(Barcos.Portaaviones, 1, 3, Orientacion.Horizontal);
        
        Action respuesta = () => acorazados.AgregarBarco(Barcos.Destructor, 1, 1, Orientacion.Vertical);
        
        respuesta.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("Ya se encuentra un barco ubicado en la coordenada 1,3");
    }
    
    [Fact]
    public void Si_PosicionoUnPortaavionesEn9_1Horizontal_Debe_ArrojarExcepcionPorFueraDeltablero()
    {
        var acorazados = new Acorazados();
        
        Action respuesta = () => acorazados.AgregarBarco(Barcos.Portaaviones, 9, 1);
        
        respuesta.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("Excede el limite del tablero");
    }


    
    
    
}