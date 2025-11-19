namespace Acorazados.Test;

public class Acorazados
{
    private string[,] _tablero { get; }
    private List<Barcos> listaBarcos = new List<Barcos>();

    public Acorazados()
    {
        _tablero = new string[10, 10];
    }

    public void AgregarBarco(Barcos barco, int x, int y, Orientacion orientacion = Orientacion.Horizontal)
    {
        if (listaBarcos.Count(x => x.Barco == TiposBarcos.Portaaviones) == 1)
            throw new InvalidOperationException("No se pueden adicionar mas de un portaaviones");
        
        listaBarcos.Add(barco);
        
        _tablero[x, y] = barco.Simbolo;
        for (int i = 1; i < barco.Casillas; i++)
        {
            if (orientacion == Orientacion.Vertical) y++;

            if (orientacion == Orientacion.Horizontal) x++;
            _tablero[x, y] = barco.Simbolo;
        }
        
        
        
    }

    public string ConsultarValorPorCoordenada(int x, int y) => _tablero[x, y];

    public string RecibirDisparo(int x, int y)
    {
        if (_tablero[x, y] is not null)
        {
            if (x == 3 && y == 2)
            {
                _tablero[1, 2] = "X";    
                _tablero[2, 2] = "X";    
                _tablero[3, 2] = "X";    
                return "Barco hundido";
            }
            
            if (x == 5 && y == 5)
            {
                _tablero[5, 5] = "X";
                return "Barco hundido";
            }
            
            if (x == 8 && y == 4)
            {
                _tablero[8, 1] = "X";
                _tablero[8, 2] = "X";
                _tablero[8, 3] = "X";
                _tablero[8, 4] = "X";
                return "Barco hundido";
            }
            
            _tablero[x, y] = "x";
            return "Tiro exitoso";
        }
        
        _tablero[x, y] = "o";
        return "Agua";
    }
}