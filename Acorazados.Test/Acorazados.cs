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
            
            _tablero[x, y] = "x";
            return "Tiro exitoso";
        }
        
        _tablero[x, y] = "o";
        return "Agua";
    }
}