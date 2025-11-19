using AwesomeAssertions;

namespace Acorazados.Test;

public class AcorazadosTest
{

    [Fact]
    public void Si_AgregoUnCanoneroConLaCoordenada1_1_Debe_ExistirElCañonero_EnLaCoordenada1_1()
    {
        var acorazados = new Acorazados();

        acorazados.AgregarBarco(Barcos.Canonero, 1, 1);

        acorazados.ConsultarBarco(1, 1).Should().Be("g");
    }

    [Fact]
    public void Si_AgregoDestructorConLaCoordenada1_2EnPosicionVertical_Debe_ExistirDestructorEnLaCoordenada1_21_3Y1_4()
    {
        var acorazados = new Acorazados();
        
        acorazados.AgregarBarco(Barcos.Destructor, 1, 2, Orientacion.Vertical);
        
        acorazados.ConsultarBarco(1, 2).Should().Be("d");
        acorazados.ConsultarBarco(1, 3).Should().Be("d");
        acorazados.ConsultarBarco(1, 4).Should().Be("d");
    }
    
    [Fact]
    public void Si_AgregoDestructorConLaCoordenada1_2EnPosicionHorizontal_Debe_ExistirDestructorEnLaCoordenada1_22_2Y3_2()
    {
        var acorazados = new Acorazados();
        
        acorazados.AgregarBarco(Barcos.Destructor, 1, 2, Orientacion.Horizontal);
        
        acorazados.ConsultarBarco(1, 2).Should().Be("d");
        acorazados.ConsultarBarco(2, 2).Should().Be("d");
        acorazados.ConsultarBarco(3, 2).Should().Be("d");
    }
    
    [Fact]
    public void Si_AgregoPortavionesConLaCoordenada1_3EnPosicionHorizontal_Debe_ExistirPortavionesEnLaCoordenada1_32_3_3_3Y4_3()
    {
        var acorazados = new Acorazados();
        
        acorazados.AgregarBarco(Barcos.Portaaviones, 1, 3, Orientacion.Horizontal);
        
        acorazados.ConsultarBarco(1, 3).Should().Be("c");
        acorazados.ConsultarBarco(2, 3).Should().Be("c");
        acorazados.ConsultarBarco(3, 3).Should().Be("c");
        acorazados.ConsultarBarco(4, 3).Should().Be("c");
    }
    
    [Fact]
    public void Si_AgregoPortavionesConLaCoordenada1_3EnPosicionVertical_Debe_ExistirPortavionesEnLaCoordenada1_31_4_1_5Y1_6()
    {
        var acorazados = new Acorazados();
        
        acorazados.AgregarBarco(Barcos.Portaaviones, 1, 3, Orientacion.Vertical);
        
        acorazados.ConsultarBarco(1, 3).Should().Be("c");
        acorazados.ConsultarBarco(1, 4).Should().Be("c");
        acorazados.ConsultarBarco(1, 5).Should().Be("c");
        acorazados.ConsultarBarco(1, 6).Should().Be("c");
    }
    
}