namespace Models.FromPlanificacion
{
    public class CrudoDevengamiento
    {
        public int Legajo { get; set; }
		public DateTime Fecha { get; set; }
		public double Monto { get; set; }
		public string? Estado { get; set; }
		public string? Cliente { get; set; }
		public string? Sbu { get; set; }
		public double Horas { get; set; }

		// Relaciones
		//public Proyecto? Proyecto { get; set; }
		public string? Proyecto { get; set; }
		public int ProyectoId { get; set; }

		// EJEMPLO de JSON:
		//"legajo": 734,
		//"fecha": "2021-07-15T09:00:00Z",
		//"monto": 10826.666666666666,
		//"proyecto": "QUILMES 2021 - Equipo Integraciones",
		//"proyectoId": "5f5918af-db23-435f-a912-011127562146",
		//"estado": "Cerrado",
		//"cliente": "QUILMES",
		//"sbu": "BUAR-VER-CIL",
		//"horas": 3.7333333333333334
	}
}
