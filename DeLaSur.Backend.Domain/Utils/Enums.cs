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
            Espinela = 25
        }
        public enum Pureza
        {
            FL = 1,
            IF = 2,
            VVS = 3,
            VS = 4,
            SI = 5,
            I = 6,
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
