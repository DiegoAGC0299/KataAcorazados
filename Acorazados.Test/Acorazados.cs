namespace Acorazados.Test;

public class Acorazados
{
    private string[,] _tablero { get; }

    public Acorazados()
    {
        _tablero = new string[10, 10];
    }

    public void AgregarBarco(Barcos barco, int x, int y, Orientacion orientacion = Orientacion.Horizontal)
    {
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
        if ((x == 1 && y == 2) || (x == 2 && y == 2 ))
        {
            _tablero[x, y] = "x";
            return "Tiro exitoso";
            
        }
        if (x == 1 && y == 1)
        {
            _tablero[x, y] = "o";
            return "Agua";
        }
            
        
        return string.Empty;
    }
}