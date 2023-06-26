using System.ComponentModel.DataAnnotations;

namespace HomeApi.Contracts.Models.Devices
{
	/// <summary>
	/// Добавляет поддержку нового устройства.
	/// </summary>
	public class AddDeviceRequest
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Manufacturer { get; set; }
		[Required]
		public string Model { get; set; }
		[Required]
		public string SerialNumber { get; set; }
		[Required]
		[Range(120, 220, ErrorMessage = "We only support devices from {1} to {2} volts")]
		public int CurrentVolts { get; set; }
		[Required]
		public bool GasUsage { get; set; }
		[Required]
		public string Location { get; set; }
	}
}