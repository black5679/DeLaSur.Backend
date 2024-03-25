namespace DeLaSur.Backend.Domain.Utils
{
    public static class Enums
    {
        public enum MateriaPrima
        {
            Diamante = 1,
            Rubi = 2,
            Zafiro = 3,
            Esmeralda = 4,
            Amatista = 5,
            Citrino = 6,
            Aguamarina = 7,
            Topacio = 8,
            Granate = 9,
            Agata = 10,
            Jade = 11,
            Lapislazuli = 12,
            Turquesa = 13,
            Turmalina = 14,
            Tsfavorita = 15,
            Tanzanita = 16,
            Morganita = 17,
            Opalo = 18,
            Cuarzo = 19,
            Onix = 20,
            Peridoto = 21,
            Zircon = 22,
            Berilo = 23,
            Rubelita = 24,
            Espinela = 25,
            Obsidiana = 26,
            Calcedonia = 27
        }
        public enum Pureza
        {
            FL = 1,
            IF = 2,
            VVS = 3,
            VS = 4,
            SI = 5,
            I = 6,
            Transparente = 7,
            Translucido = 8,
            Opaco = 9
        }
        public enum Forma
        {
            Redonda = 1,
            Ovalada = 2,
            Octagonal = 3,
            Pera = 4,
            Cuadrada = 5,
            Trillon = 6,
            Marquesa = 7,
            Corazon = 8,
            Cojin = 9,
            Rectangular = 10
        }
        public enum Corte
        {
            Excellent = 1,
            VeryGood = 2,
            Good = 3,
            Fair = 4,
            Poor = 5
        }
        public enum Fuente
        {
            CaratOnline = 1
        }
        public enum TipoMovimiento
        {
            EntradaMercaderia = 1,
            Transferencia = 2
        }
        public enum TipoMaterial
        {
            Producto = 1,
            MateriaPrima = 2
        }
        public enum TipoMateriaPrima
        {
            Gema = 1,
            Metal = 2
        }
    }
}
