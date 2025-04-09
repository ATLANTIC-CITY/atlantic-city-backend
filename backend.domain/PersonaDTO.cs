namespace backend.domain
{
    public class PersonaDTO
    {
        public int? nIdCompania { get; set; }
        public int? nIdPersona { get; set; }
        public string? sPriNombre { get; set; }
        public string? sSegNombre { get; set; }
        public string? sApePaterno { get; set; }
        public string? sApeMaterno { get; set; }
        public string? sNombreCompleto { get; set; }
        public DateTime? dFechaNac { get; set; }
        public string? sFechaNac { get; set; }
        public int? nIdUbigeoNac { get; set; }
        public string? sUbigeoNac { get; set; }
        public int? nIdGenero { get; set; }
        public string? sGenero { get; set; }
        public int? nIdEstadoCivil { get; set; }
        public string? sEstadoCivil { get; set; }
        public string? sCorreo { get; set; }
        public string? sCelular { get; set; }
        public string? sCelular2 { get; set; }
        public string? sTelefono { get; set; }
        public string? sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sRUC { get; set; }
        public int? nIdDireccion { get; set; }
        public string? sDireccion { get; set; }
        public int? nIdUbigeoDir { get; set; }
        public string? sUbigeoDir { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public string? sFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
        public string? sFecha_mod { get; set; }
        public int? nIdProspecto { get; set; }
    }
}
