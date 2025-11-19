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
    public void Si_NoHayBarcosEnElTablero_ReciboUnDisparoConCoordenadaIndicadaYEsMar_Debe_RetornarMensajeAguaYMarcarLaCoordenadaConO()
    {
        var acorazados = new Acorazados();

        var mensaje = acorazados.RecibirDisparo(1, 1);

        mensaje.Should().Be("Agua");
        acorazados.ConsultarValorPorCoordenada(1, 1).Should().Be("o");

    }
    
    [Fact]
    public void Si_HayUnBarcoEnElTablero_ReciboUnDisparoConCoordenadaIndicadaYHayCoincidencia_Debe_RetornarMensajeTiroExitosoYMarcarLaCoordenadaConX()
    {
        var acorazados = new Acorazados();
        acorazados.AgregarBarco(Barcos.Destructor, 1, 2);

        var mensaje = acorazados.RecibirDisparo(1, 2);

        mensaje.Should().Be("Tiro exitoso");
        acorazados.ConsultarValorPorCoordenada(1, 2).Should().Be("x");

    }
    
}