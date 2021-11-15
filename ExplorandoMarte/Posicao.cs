using System;

public abstract class Posicao
{
    protected const string _direcoespossiveis = "NESW";
    protected const string _comandospossiveis = "LRM";

    private char _direcao;
    private int _coordenadaX;
    private int _coordenadaY;

    public char Direcao
    {
        get { return _direcao; }
        set
        {
            if (_direcoespossiveis.Contains(value) == false)
                throw new Exception("Direção não permitida");
            _direcao = value;
        }
    }
    public int CoordenadaX
    {
        get { return _coordenadaX; }
        set
        {
            if (value < 0)
                throw new Exception("Posição X não permitida");
            _coordenadaX = value;
        }
    }
    public int CoordenadaY
    {
        get { return _coordenadaY; }
        set
        {
            if (value < 0)
                throw new Exception("Posição Y não permitida");
            _coordenadaY = value;
        }
    }
    public static string getDirecoesPossiveis => _direcoespossiveis;
    public static string getComandosPossiveis => _comandospossiveis;

}