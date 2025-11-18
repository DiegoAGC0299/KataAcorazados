using AwesomeAssertions;

namespace Acorazados.Test;

public class AcorazadosTest
{
    [Fact]
    public void Si_InicializoElJuegoDeAcorazados_Debe_NumeroFilasYColumnasSer10()
    {
        var acorazados = new Acorazados();

        acorazados.ObtenerNumeroFilasTablero().Should().Be(10);
        acorazados.ObtenerNumeroColumnasTablero().Should().Be(10);

    }

    [Fact]
    public void Si_AgregoUnCanoneroConLaCoordenada1_1_Debe_ExistirElCañonero_EnLaCoordenada1_1()
    {
        var acorazados = new Acorazados();

        acorazados.AgregarBarco("Cañonero", 1, 1);

        acorazados.ConsultarBarco(1, 1).Should().Be("g");
    }

    [Fact]
    public void Si_AgregoDestructorConLaCoordenada1_2EnPosicionVertical_Debe_ExistirDestructorEnLaCoordenada1_21_3Y1_4()
    {
        var acorazados = new Acorazados();
        
        acorazados.AgregarBarco("Destructor", 1, 2, "Vertical");
        
        acorazados.ConsultarBarco(1, 2).Should().Be("d");
        acorazados.ConsultarBarco(1, 3).Should().Be("d");
        acorazados.ConsultarBarco(1, 4).Should().Be("d");
    }
    
    [Fact]
    public void Si_AgregoDestructorConLaCoordenada1_2EnPosicionHorizontal_Debe_ExistirDestructorEnLaCoordenada1_22_2Y3_2()
    {
        var acorazados = new Acorazados();
        
        acorazados.AgregarBarco("Destructor", 1, 2, "Horizontal");
        
        acorazados.ConsultarBarco(1, 2).Should().Be("d");
        acorazados.ConsultarBarco(2, 2).Should().Be("d");
        acorazados.ConsultarBarco(3, 2).Should().Be("d");
    }
    
    [Fact]
    public void Si_AgregoPortavionesConLaCoordenada1_3EnPosicionHorizontal_Debe_ExistirPortavionesEnLaCoordenada1_32_3_3_3Y4_3()
    {
        var acorazados = new Acorazados();
        
        acorazados.AgregarBarco("Portaviones", 1, 3, "Horizontal");
        
        acorazados.ConsultarBarco(1, 3).Should().Be("c");
        acorazados.ConsultarBarco(2, 3).Should().Be("c");
        acorazados.ConsultarBarco(3, 3).Should().Be("c");
        acorazados.ConsultarBarco(4, 3).Should().Be("c");
    }
    
    [Fact]
    public void Si_AgregoPortavionesConLaCoordenada1_3EnPosicionVertical_Debe_ExistirPortavionesEnLaCoordenada1_31_4_1_5Y1_6()
    {
        var acorazados = new Acorazados();
        
        acorazados.AgregarBarco("Portaviones", 1, 3, "Vertical");
        
        acorazados.ConsultarBarco(1, 3).Should().Be("c");
        acorazados.ConsultarBarco(1, 4).Should().Be("c");
        acorazados.ConsultarBarco(1, 5).Should().Be("c");
        acorazados.ConsultarBarco(1, 6).Should().Be("c");
    }
    

    
    
    
    
    

    public class Acorazados
    {
        private string[,] _tablero { get; set; }

        public Acorazados()
        {
            _tablero = new string[10, 10];
        }

        public int ObtenerNumeroFilasTablero() => _tablero.GetLength(0);

        public int ObtenerNumeroColumnasTablero() => _tablero.GetLength(1);

        public void AgregarBarco(string barco, int x, int y, string posicion = "Horizontal")
        {
            var indicativoBarco = string.Empty;

            if (barco == "Cañonero")
                indicativoBarco = "g";
            
            if (barco == "Destructor")
                indicativoBarco = "d";
            
            if (barco == "Portaviones")
                indicativoBarco = "c";
            
            _tablero[x, y] = indicativoBarco;

            if (posicion == "Vertical")
            {
                if (indicativoBarco == "d")
                {
                    _tablero[x, y + 1] = indicativoBarco;
                    _tablero[x, y + 2] = indicativoBarco;
                }
                
                if (indicativoBarco == "c")
                {
                    _tablero[x, y + 1] = indicativoBarco;
                    _tablero[x, y + 2] = indicativoBarco; 
                    _tablero[x, y + 3] = indicativoBarco; 
                }
            }

            if (posicion == "Horizontal")
            {
                if (indicativoBarco == "d")
                {
                    _tablero[x + 1, y] = indicativoBarco;
                    _tablero[x + 2, y] = indicativoBarco; 
                }
                
                if (indicativoBarco == "c")
                {
                    _tablero[x + 1, y] = indicativoBarco;
                    _tablero[x + 2, y] = indicativoBarco; 
                    _tablero[x + 3, y] = indicativoBarco; 
                }
            }
        }

        public string ConsultarBarco(int x, int y) => _tablero[x, y];
    }
}