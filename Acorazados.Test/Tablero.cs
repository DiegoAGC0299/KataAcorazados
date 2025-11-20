using System.Text;

namespace Acorazados.Test;

public class Tablero
{
    private const string MarcaTiroAlAgua = "o";
    private const string MarcaTiroExitoso = "x";
    private const string MarcaBarcoHundido = "X";
    private const string MensajeBarcoHundido = "Barco hundido";
    private const string MensajeTiroExitoso = "Tiro exitoso";
    private const string MensajeTiroAlAgua = "Agua";
    private string[,] Cuadro { get; }
    private readonly List<Barcos> _listaBarcos = [];
    private int _indiceXMaximo;
    private int _indiceYMaximo;

    public Tablero()
    {
        Cuadro = new string[10, 10];
        CalcularIndicesMaximos();
    }

    public string DibujarTablero()
    {
        var dibujoTablero = new StringBuilder();
        
        DibujarEncabezado(dibujoTablero);
        DibujarCuadro(dibujoTablero);
        
        return dibujoTablero.ToString();
    }

    private void DibujarCuadro(StringBuilder dibujoTablero)
    {
        for (int fila = 0; fila <= _indiceYMaximo; fila++)
        {
            dibujoTablero.Append($"{fila} ");
            for (int columna = 0; columna <= _indiceXMaximo; columna++)
            {
                var celda =  Cuadro[columna, fila] ?? " ";
                dibujoTablero.Append($"| {celda} ");
            }
            
            dibujoTablero.Append("|");
            if(fila != _indiceXMaximo)
                dibujoTablero.Append("\n");
                
        }
    }

    private void DibujarEncabezado(StringBuilder dibujoTablero)
    {
        dibujoTablero.Append("  ");
        for (int columna = 0; columna <= _indiceXMaximo; columna++)
        {
            dibujoTablero.Append($"| {columna} ");
        }
        dibujoTablero.Append("|\n");
    }

    public void AgregarBarco(Barcos barco, int x, int y, Orientacion orientacion = Orientacion.Horizontal)
    {
        LanzarExcepcionSiNumeroPermitidoDeBarcosSuperaLimite(barco);
        PosicionarBarcoEnCasillas(barco, x, y, orientacion);
    }

    public string ConsultarValorPorCoordenada(int x, int y) => Cuadro[x, y];

    public string RecibirDisparo(int x, int y)
    {
        LanzarExcepcionSiCoordenadaEstaFueraDeLimiteDelTablero(x,y);
        
        if (EsTiroExitoso(x, y))
        {
            var barco = ConsultarBarcoPorCoordenada(x, y);
            
            if (SeDebeHundirBarco(x, y, barco))
                return HundirBarco(barco);
            
            return TiroExitoso(x, y);
        }

        return TiroAlAgua(x, y);
    }

    private bool EsTiroExitoso(int x, int y) => Cuadro[x, y] != null;

    private bool SeDebeHundirBarco(int x, int y, Barcos? barco) => ObtenerCasillasAtacadas(x, y, barco) == barco.Casillas;

    private Barcos? ConsultarBarcoPorCoordenada(int x, int y) =>
        _listaBarcos
            .FirstOrDefault(b =>
                b.Coordenadas.Any(c => c.X == x && c.Y == y));

    private string HundirBarco(Barcos barco)
    {
        foreach (var coordenadaBarco in barco.Coordenadas) Cuadro[coordenadaBarco.X, coordenadaBarco.Y] = MarcaBarcoHundido;
        _listaBarcos.Remove(barco);
        return MensajeBarcoHundido;
    }

    private int ObtenerCasillasAtacadas(int x, int y, Barcos? barco)
    {
        var casillasAtacadas = 0;

        foreach (var coordenadaBarco in barco.Coordenadas)
        {
            if((coordenadaBarco.X == x && coordenadaBarco.Y == y) || Cuadro[coordenadaBarco.X, coordenadaBarco.Y] == MarcaTiroExitoso)
                casillasAtacadas++;
        }
        
        return casillasAtacadas;
    }

    private string TiroExitoso(int x, int y)
    {
        Cuadro[x, y] = MarcaTiroExitoso;
        return MensajeTiroExitoso;
    }

    private string TiroAlAgua(int x, int y)
    {
        Cuadro[x, y] = MarcaTiroAlAgua;
        return MensajeTiroAlAgua;
    }

    private void PosicionarBarcoEnCasillas(Barcos barco, int x, int y, Orientacion orientacion)
    {
        for (var i = 1; i <= barco.Casillas; i++)
        {
            if (i > 1)
            {
                if (orientacion == Orientacion.Vertical) y++;
                if (orientacion == Orientacion.Horizontal) x++;
            }
            
            LanzarExcepcionSiCoordenadaEstaFueraDeLimiteDelTablero(x, y);

            LanzarExcepcionSiSeSobreponeUnBarco(x, y);
            
            Cuadro[x, y] = barco.Simbolo;
            barco.Coordenadas.Add(new Coordenada(x,y));
        }
        
        _listaBarcos.Add(barco);
    }

    private void LanzarExcepcionSiCoordenadaEstaFueraDeLimiteDelTablero(int x, int y)
    {
        if (x > _indiceXMaximo || y > _indiceYMaximo || x < 0 || y < 0)
            throw new InvalidOperationException("La coordenada excede el limite del tablero");
    }

    private void LanzarExcepcionSiSeSobreponeUnBarco(int x, int y)
    {
        if (Cuadro[x, y] != null)
            throw new InvalidOperationException($"Ya se encuentra un barco ubicado en la coordenada {x},{y}");
    }

    private void LanzarExcepcionSiNumeroPermitidoDeBarcosSuperaLimite(Barcos barco)
    {
        if (_listaBarcos.Count(x => x.Tipo == barco.Tipo) == barco.CantidadPermitida)
            throw new InvalidOperationException($"No se puede adicionar otro {barco.Nombre}");
    }
    
    private void CalcularIndicesMaximos()
    {
        _indiceXMaximo = Cuadro.GetLength(0) - 1;
        _indiceYMaximo = Cuadro.GetLength(1) - 1;
    }

    public bool ExistenBarcos()
        => _listaBarcos.Any();

    public int ObtenerDisparosTotales()
        => Cuadro.Cast<string>()
            .Count(x => !string.IsNullOrEmpty(x) && (x == MarcaTiroAlAgua || x == MarcaTiroExitoso || x == MarcaBarcoHundido));
    
    public int ObtenerDisparosFallidos()
        => Cuadro.Cast<string>()
            .Count(x => !string.IsNullOrEmpty(x) && x == MarcaTiroAlAgua);
}