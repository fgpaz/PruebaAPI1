namespace Models.FromPlanificacion
{
    public class TargetDevengamiento
    {
		public int Legajo { get; set; }
		public DateTime Fecha { get; set; }
		public double Monto { get; set; }
		public string? Sbu { get; set; }
		public float PorcentajeAsignacion { get; set; }

		// EJEMPLO de JSON:
		//"legajo": 734,
		//"fecha": "2021-07-12T00:00:00",
		//"monto": 15453.285714285714,
		//"sbu": "BUAR-VER-CIL",
		//"porcentajeAsignacion": 1.0
	}
}
