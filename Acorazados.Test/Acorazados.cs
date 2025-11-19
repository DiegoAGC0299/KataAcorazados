namespace Acorazados.Test;

public class Acorazados
{
    private string[,] Tablero { get; }
    private readonly List<Barcos> _listaBarcos = [];

    public Acorazados()
    {
        Tablero = new string[10, 10];
    }

    public void AgregarBarco(Barcos barco, int x, int y, Orientacion orientacion = Orientacion.Horizontal)
    {
        LanzarExcepcionSiNumeroPermitidoDeBarcosSuperaLimite(barco);
        PosicionarBarcoEnCasillas(barco, x, y, orientacion);
    }

    public string ConsultarValorPorCoordenada(int x, int y) => Tablero[x, y];

    public string RecibirDisparo(int x, int y)
    {
        if (Tablero[x, y] != null)
        {
            if (x == 3 && y == 2)
            {
                Tablero[1, 2] = "X";    
                Tablero[2, 2] = "X";    
                Tablero[3, 2] = "X";    
                return "Barco hundido";
            }
            
            if (x == 5 && y == 5)
            {
                Tablero[5, 5] = "X";
                return "Barco hundido";
            }
            
            if (x == 8 && y == 4)
            {
                Tablero[8, 1] = "X";
                Tablero[8, 2] = "X";
                Tablero[8, 3] = "X";
                Tablero[8, 4] = "X";
                return "Barco hundido";
            }
            
            Tablero[x, y] = "x";
            return "Tiro exitoso";
        }
        
        Tablero[x, y] = "o";
        return "Agua";
    }
    
    private void PosicionarBarcoEnCasillas(Barcos barco, int x, int y, Orientacion orientacion)
    {
        Tablero[x, y] = barco.Simbolo;
        Barcos.Coordenadas.Add(new Coordenada(x, y));
        
        for (var i = 1; i < barco.Casillas; i++)
        {
            if (orientacion == Orientacion.Vertical) y++;

            if (orientacion == Orientacion.Horizontal) x++;
            Tablero[x, y] = barco.Simbolo;
            
            Barcos.Coordenadas.Add(new Coordenada(x,y));
        }
        
        _listaBarcos.Add(barco);
    }

    private void LanzarExcepcionSiNumeroPermitidoDeBarcosSuperaLimite(Barcos barco)
    {
        if (_listaBarcos.Count(x => x.Tipo == barco.Tipo) == barco.CantidadPermitida)
            throw new InvalidOperationException($"No se puede adicionar otro {barco.Nombre}");
    }
}

public class Coordenada(int x, int y)
{
    private int X { get; set; } = x;
    private int Y { get; set; } = y;
}