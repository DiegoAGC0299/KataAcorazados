using AwesomeAssertions;

namespace Acorazados.Test;

public class AcorazadosTest
{
    [Fact]
    public void Si_CreoUnTablero_Debe_EstarSinBarcos()
    {
        var acorazados = new Acorazados();

        acorazados.CrearTablero();

        acorazados.CantidadBarcos.Should().Be(0);
    }

    public class Acorazados
    {
        
        public object CantidadBarcos { get; set; }

        public void CrearTablero()
        {
            throw new NotImplementedException();
        }

        
    }
}